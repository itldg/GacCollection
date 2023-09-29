using GAC_Collection.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GAC_Collection.Class;
using System.Data.SQLite;
using GacDB.Properties;

namespace GAC_Collection.Common
{
    public class JobDB
    {
        SQLiteHelper sql = null;
        private const string sql_rule_tablename = "G_Job";
        public JobDB()
        {
            sql = new SQLiteHelper(System.Environment.CurrentDirectory + Resources.UserData + "Config.db");

        }
        public List<ClassJob> JobGetList(int CategoryId = 0)
        {
            return sql.ExecuteQuery<ClassJob>("select * from  \"" + sql_rule_tablename + "\" where CategoryId=@CategoryId", new SQLiteParameter("@CategoryId", CategoryId));
        }
        public List<ClassJob> JobGetList(string Where)
        {
            return sql.ExecuteQuery<ClassJob>("select * from  \"" + sql_rule_tablename + "\" where "+Where);
        }
        public ClassJob JobGet(int JobId = 0)
        {
            List< ClassJob > list= sql.ExecuteQuery<ClassJob>("select * from  \"" + sql_rule_tablename + "\" where JobId=@JobId", new SQLiteParameter("@JobId", JobId));
            if (list.Count>0)
            {
                return list[0];
            }
            return null;
        }
        /// <summary>
        /// 失败返回-1 成功更新数量
        /// </summary>
        /// <param name="Job"></param>
        /// <returns></returns>
        public int JobUpdate(ClassJob Job)
        {
            string sqlstr = "update  \"" + sql_rule_tablename + "\" Set CategoryId=@CategoryId,JobName=@JobName,XmlData=@XmlData,SpiderUrl=@SpiderUrl,SpiderContent=@SpiderContent,OutContent=@OutContent,Status=@Status where  JobId=@JobId";
            if (Job.JobId==0)
            {
                sqlstr = "INSERT INTO \"" + sql_rule_tablename + "\"(CategoryId,JobName,XmlData,SpiderUrl,SpiderContent,OutContent,Status) VALUES (@CategoryId,@JobName,@XmlData,@SpiderUrl,@SpiderContent,@OutContent,@Status)";
            }
            int result = sql.ExecuteSql(sqlstr, new SQLiteParameter("@JobId", Job.JobId),
                new SQLiteParameter("@CategoryId", Job.CategoryId),
                new SQLiteParameter("@JobName", Job.JobName),
                new SQLiteParameter("@XmlData", Job.XmlData),
                new SQLiteParameter("@SpiderUrl", Job.SpiderUrl),
                new SQLiteParameter("@SpiderContent", Job.SpiderContent),
                new SQLiteParameter("@OutContent", Job.OutContent),
                new SQLiteParameter("@Status", Job.Status)
                ) ;
            if (Job.JobId == 0)
            {
                Job.JobId = result;
            }
            return result;
            //if (result<=0)
            //{
            //    return -1;
            //}
            //return Job.JobId;
        }
        /// <summary>
        /// 更新任务状态
        /// </summary>
        /// <param name="JobId">任务ID</param>
        /// <param name="UpdateType">更新字段
        /// 0 采集网址
        /// 1 采集内容
        /// 2 发布数据
        /// </param>
        /// <param name="NewValue"></param>
        /// <returns></returns>
        public bool JobUpdate(int JobId, int UpdateType=0, bool NewValue=true)
        {
            string name = "SpiderUrl";
            switch (UpdateType)
            {
                case 1:name = "SpiderContent"; break;
                case 2: name = "OutContent"; break;
                default:break;
            }
            string sqlstr = "update  \"" + sql_rule_tablename + "\" Set "+ name + "=@"+ name + " where JobId=@JobId";
            int result = sql.ExecuteSql(sqlstr, new SQLiteParameter("@JobId", JobId),
                new SQLiteParameter("@"+ name, NewValue)
                );
            return result>0;
        }
        public bool JobDelete(int JobId)
        {
            return sql.ExecuteNonQuery("delete FROM \"" + sql_rule_tablename + "\" where JobId=@JobId", new SQLiteParameter("@JobId", JobId)) > 0;
        }

    }
}
