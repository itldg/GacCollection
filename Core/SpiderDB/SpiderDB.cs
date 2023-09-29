using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GacXml;
using Gac;
using System.IO;
using GAC_Collection.Common;
using SpiderDB;
using GacDB.Properties;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace GAC_Collection
{
    public class GacDB
    {
        string databaseConfig = System.Environment.CurrentDirectory +Resources.Configuration + "Database.xml";
        public DbConfig dbConfig;
        public string DbName = "";

        public GacDB()
        {
            ReadDbConfig();
        }
        private void ReadDbConfig()
        {
            XmlHelper xml = new XmlHelper();
            dbConfig = xml.XmlToEntityFromFile<DbConfig>(databaseConfig);
        }

        public void SaveDbConfig(DbConfig NewConfig)
        {
            XmlHelper xml = new XmlHelper();
           string xmlstr= xml.EntityToXml<DbConfig>(NewConfig);
            File.WriteAllText(databaseConfig,xmlstr);
            ReadDbConfig();
        }
        JobDB jobdb = new JobDB();
        
        public string ConvertDb(int JobId,string JobXml)
        {
            try
            {
                string database = dbConfig.DatabaseType[0];
                string SqlContent = GetSqlContent(JobId, database);
                DataHelper db = new DataHelper(SqlContent, database);
                
                

                XmlHelper xh = new XmlHelper();

                GacXml.GacJob taskxml = xh.XmlToEntity<GacXml.GacJob>(JobXml);
                string sqlstr = "";
                if (database == "Access")
                {
                    try
                    {
                        db.ExecuteSql("DROP TABLE `Content`;");
                    }
                    catch (Exception)
                    {
                    }
                    //  m_boolean   bit    default yes 
                    sqlstr = "create table Content (Id counter primary key,已采 bit,已发 bit,";
                    foreach (var item in taskxml.SortLabel)
                    {
                        sqlstr += "`"+item + "` longtext,";
                    }
                    sqlstr += "`PageUrl` longtext)";
                }
                else
                {
                    try
                    {
                        db.ExecuteSql("DROP TABLE  IF EXISTS `Content`;");
                    }
                    catch (Exception)
                    {
                    }
                    if (database == "Sqlite")
                    {
                        sqlstr = @"CREATE TABLE ""Content""(""Id"" integer PRIMARY KEY AUTOINCREMENT,""已采"" tinyint(1) DEFAULT 0,""已发"" tinyint(1) DEFAULT 0,";
                        foreach (var item in taskxml.SortLabel)
                        {
                            sqlstr += "\"" + item + "\" Text,";
                        }
                        sqlstr+= "\"PageUrl\" Text);";
                    }
                    else
                    {
                        sqlstr = "CREATE TABLE `Data_Content_"+JobId+"` (`Id` long unsigned NOT NULL AUTO_INCREMENT,`已采` bit NOT NULL DEFAULT 0,`已发` bit NOT NULL DEFAULT 0,";
                        foreach (var item in taskxml.SortLabel)
                        {
                            sqlstr += "`" + item + "` longtext NOT NULL DEFAULT '',";
                        }
                        sqlstr += "`PageUrl` longtext NOT NULL DEFAULT '') ENGINE = MyISAM AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;";
                    }
                    
                }
                
                db.ExecuteSql(sqlstr);
                return "成功";
            }
            catch (Exception ex)
            {

                return "失败，原因：" + ex.Message;
            }
           
        }
        public string GetSqlContent(int JobId,string DataBase)
        {
           
            string SqlContent = "";
            switch (DataBase)
            {
                case "Sqlite":
                    string db3 = System.Environment.CurrentDirectory + "\\Data\\" + JobId + "\\GacCollection.db3";
                    if (!File.Exists(db3))
                    {
                        string dir = Path.GetDirectoryName(db3);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                        string db3old = System.Environment.CurrentDirectory + Resources.Configuration + "Sample\\Data.db3";
                        File.Copy(db3old, db3);
                    }
                    
                    SqlContent = "Data Source=" + db3 + ";Pooling=true;FailIfMissing=false";
                    break;
                case "MySql":  
                    SqlContent = dbConfig.ConnCollection[0].MySql;
                    break;
                case "SqlServer":
                    SqlContent = dbConfig.ConnCollection[0].SqlServer;
                    break;
                case "Access":
                default:
                    string mdbfile = System.Environment.CurrentDirectory + "\\Data\\" + JobId + "\\GacCollection.mdb";
                    if (!File.Exists(mdbfile))
                    {
                        string dir = Path.GetDirectoryName(mdbfile);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                        string mdbfileold = System.Environment.CurrentDirectory + Resources.Configuration + "Sample\\Data.mdb";
                        File.Copy(mdbfileold, mdbfile);
                    }
                    SqlContent = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbfile;
                    break;
            }
            return SqlContent;
        }
        public string GetDbName(int JobId)
        {
            switch (dbConfig.DatabaseType[0])
            {
                case "Access":
                case "Sqlite": return "Content";
                default:return "Data_Content_" + JobId;
            }
        }
        public DbParameter[] GetDbParameter(Dictionary<string, string> dic)
        {
            string Prefix = GetParaPrefix();
            DbParameter[] result = new DbParameter[dic.Count];
            string[] kyes = dic.Keys.ToArray<string>();
            for (int i = 0; i < kyes.Length; i++)
            {
                switch (dbConfig.DatabaseType[0])
                {
                    case "Access": result[i] = new OleDbParameter(Prefix + kyes[i], dic[kyes[i]]); break;
                    case "Sqlite": result[i] = new SQLiteParameter(Prefix + kyes[i], dic[kyes[i]]); break;
                    case "MySql": result[i] = new MySqlParameter(Prefix + kyes[i], dic[kyes[i]]); break;
                    case "SqlServer": result[i] = new SqlParameter(Prefix + kyes[i], dic[kyes[i]]); break;
                }
            }
            return result;

        }
        public DbParameter[] GetDbParameter(Dictionary<string, object> dic)
        {
            string Prefix= GetParaPrefix();
            DbParameter[] result = new DbParameter[dic.Count];
            string[] kyes = dic.Keys.ToArray<string>();
            for (int i = 0; i < kyes.Length; i++)
            {
                switch (dbConfig.DatabaseType[0])
                {
                    case "Access":result[i] = new OleDbParameter(Prefix + kyes[i], dic[kyes[i]]);break;
                    case "Sqlite": result[i] = new SQLiteParameter(Prefix + kyes[i], dic[kyes[i]]); break;
                    case "MySql": result[i] = new MySqlParameter(Prefix + kyes[i], dic[kyes[i]]); break;
                    case "SqlServer": result[i] = new SqlParameter(Prefix + kyes[i], dic[kyes[i]]); break;
                }
            }
            return result;

        }

        public string GetParaPrefix()
        {
            switch (dbConfig.DatabaseType[0])
            {
                case "Sqlite":
                case "MySql": return "@";// return "?";
                case "Access": 
                case "SqlServer": return "@";
            }
            return "";
        }
    }
    public class SpiderDB
    {
        GacDB gacdb = new GacDB();
        string DbName = "";
        string Prefix = "";
        string listLables = "";
        int JobId = 0;
        public string LabelNotRepeat = "";
        public SpiderDB(int JobId)
        {
            this.JobId = JobId;
        }
        public void SetListLables(List<string> listLables)
        {
            this.listLables = "";
            foreach (var item in listLables)
            {
                this.listLables += ",`"+item+"`";
            }
        }
        public void SetLabelNotRepeat(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                sb.Append("`" + list[i] + "`=@" + list[i]);
            }
            LabelNotRepeat = sb.ToString();
        }
        DataHelper db;
        /// <summary>
        /// 初始化数据库信息
        /// </summary>
        /// <returns>成功返回ok  失败返回失败原因</returns>
        public string Init()
        {
          
            string sqlconnet = gacdb.GetSqlContent(JobId, gacdb.dbConfig.DatabaseType[0]);
            db = new DataHelper(sqlconnet, gacdb.dbConfig.DatabaseType[0]);
            string result= db.Connect();
            if (result=="ok")
            {
                DbName = gacdb.GetDbName(JobId);
                Prefix =gacdb. GetParaPrefix(); 
            }
            return result;
        }
        public bool UrlCheck(string url,int MaxCount=0)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("PageUrl", url);
            DbParameter[] param = gacdb.GetDbParameter(dic);
            string result= db.ExecuteString("select count(*) from " + DbName + " where `PageUrl`="+Prefix+"PageUrl", param);
            int count= Convert.ToInt32(result);
            if (MaxCount == 0)
            {
                return count == 0;
            }
            else
            {
                return MaxCount > count;
            }
        }
        public bool UrlInsert(string url,Dictionary<string,string> dic)
        {
            Dictionary<string, object> dicsql = new Dictionary<string, object>();
            dicsql.Add("PageUrl", url);
            StringBuilder sbname = new StringBuilder();
            StringBuilder sbvalue = new StringBuilder();
            if (dic!=null)
            {
                foreach (var item in dic)
                {
                    if (item.Key != "GAC当前层级" && item.Key != "GAC提示文本")
                    {
                        dicsql.Add(item.Key, item.Value);
                        sbname.Append(",`" + item.Key + "`");
                        sbvalue.Append("," + Prefix + item.Key);
                    }

                }
            }
            DbParameter[] param = gacdb.GetDbParameter(dicsql);
            int result = db.ExecuteSql("insert into " + DbName + "(`PageUrl`,`已采`,`已发`"+sbname.ToString()+") VALUES ("+Prefix + "PageUrl,0,0"+sbvalue.ToString()+")", param);
            return result > 0;
        }
        /// <summary>
        /// 获取网址数量
        /// </summary>
        /// <param name="Type">获取类型
        /// 0为获取全部
        /// 1为获取未采集
        /// 2为获取未发</param>
        /// <returns></returns>
        public int UrlGetCount(int Type=0)
        {
            string sql = "select count(*) from " + DbName;
            if (Type>0)
            {
                if (Type == 1)
                {
                    sql += " where `已采`=0";
                } else
                {
                    sql += " where `已采`=1 and `已发`=0";
                }
                
            }
            string result = db.ExecuteString(sql);
            int count = Convert.ToInt32(result);
            return count;
        }

        public List<Dictionary<string, string>> CotentGetTop(int Index = 0, int Count = 20,int Type = 0)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            string where = "";
            if (Type > 0)
            {
                if (Type == 1)
                {
                    where = " and `已采`=0";
                }
                else
                {
                    where = " and `已采`=1 and `已发`=0";
                }

            }
            string cloud = " `Id`,`PageUrl`" + listLables;
            if (Type==2)
            {
                cloud = "*";
            }


            string sql = "";
            if (gacdb.dbConfig.DatabaseType[0] == "Access")
            {
                //select top 1 a,id from tablename order by a, id
                sql = "select top " + Count +  cloud + " from " + DbName + " where Id>@Id "+ where;
            }
            else
            {
                sql = "select "+ cloud + " from " + DbName + " where Id>@Id "+ where + " limit "+Count;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Id", Index);
            DbParameter[] dp = gacdb.GetDbParameter(dic);
            DbDataReader dr= db.ExecuteReader(sql, dp);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Dictionary<string, string> diclable = new Dictionary<string, string>();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        string name = dr.GetName(i).Trim();
                        string value=dr[i].ToString();
                        diclable.Add(name,  value );
                    }
                    list.Add(diclable);
                }
                
            }
            return list;
        }
        public bool ContentUpdate(int Id,LableMergeInfo lmi)
        {
           
                StringBuilder sbupdate = new StringBuilder();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                string[] keys = lmi.Dic.Keys.ToArray();
                for (int i = 0; i < keys.Length; i++)
                {
                    if (i > 0)
                    {
                        sbupdate.Append(",");
                    }
                    dic.Add(keys[i], lmi.Dic[keys[i]]);
                    sbupdate.Append("`" + keys[i] + "`=@" + keys[i]);
                    
                }
                dic.Add("已采", "1");
                sbupdate.Append(",`已采`=@已采");
                string sql = "UPDATE " + DbName + " SET " + sbupdate.ToString() + " where `Id`=" + Id;
                DbParameter[] dp = gacdb.GetDbParameter(dic);
                bool result = db.ExecuteSql(sql, dp) > 0;
                return result;

           
            
        }
        /// <summary>
        /// 设置数据已发状态,如果ID小于等于0 则设置全部
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool OutContentUpdate(int Id,bool Ok=true)
        {

            StringBuilder sbupdate = new StringBuilder();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("已发", Ok?1:0);
            sbupdate.Append("`已发`=@已发");
            string sql = "UPDATE " + DbName + " SET " + sbupdate.ToString();
            if (Id>0)
            {
                sql += " where `Id`=" + Id;
            }
            DbParameter[] dp = gacdb.GetDbParameter(dic);
            bool result = db.ExecuteSql(sql, dp) > 0;
            return result;



        }
        public bool ContentInsert(LableMergeInfo lmi)
        {

            StringBuilder sbname = new StringBuilder();
            StringBuilder sbvalue = new StringBuilder();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string[] keys = lmi.Dic.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                dic.Add(keys[i], lmi.Dic[keys[i]]);
                sbname.Append(",`" + keys[i] + "`");
                sbvalue.Append(",@" + keys[i]);
            }
            dic.Add("已采", "1");
            dic.Add("已发", "0");
            string sql = "insert into " + DbName + "(`已采`,`已发`" + sbname + ") VALUES (@已采,@已发" + sbvalue.ToString() + ")";
            DbParameter[] dp = gacdb.GetDbParameter(dic);
            bool result = db.ExecuteSql(sql, dp) > 0;
            return result;
        }
        /// <summary>
        /// 标签是否重复
        /// </summary>
        /// <param name="list">标签结果</param>
        /// <returns>返回true为重复</returns>
        public bool ChecktLabelNotRepeat(LableMergeInfo lmi)
        {
            if (string.IsNullOrEmpty(LabelNotRepeat))//如果没有字段需要检测则直接返回不重复
            {
                return false;
            }

            DbParameter[] param = gacdb.GetDbParameter(lmi.Dic);
            string result = db.ExecuteString("select count(*) from " + DbName + " where "+LabelNotRepeat, param);
            int count = Convert.ToInt32(result);
            return count > 0;
        
        }
        public string Clear()
        {
            try
            {
                int count = db.ExecuteSql("delete from " + DbName);
                return "成功删除" + count + "条数据";
            }
            catch (Exception ex)
            {
                return "清空失败，" + ex.Message;
            }
        }

    }

}
