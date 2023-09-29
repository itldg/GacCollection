using GAC_Collection.Helper;
using GacDB.Class;
using GacDB.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace GAC_Collection.Common
{
    /// <summary>
    /// 模块配置信息数据库类
    /// </summary>
    public class ModuleDb
    {
        static SQLiteHelper sql = null;
        private const string sql_rule_tablename = "G_WebPost";

        public ModuleDb()
        {
            if (sql==null)
            {
                sql = new SQLiteHelper(System.Environment.CurrentDirectory + Resources.UserData + "Config.db");
            }
        }
        /// <summary>
        /// 获取模块配置列表
        /// </summary>
        /// <returns>返回模块配置列表</returns>
        public List<ClassModule> GetList()
        {
            return sql.ExecuteQuery<ClassModule>("select * from  \"" + sql_rule_tablename+"\"");
        }
        /// <summary>
        /// 获取模块配置信息
        /// </summary>
        /// <returns>返回模块配置列表</returns>
        public ClassModule GetClassModule(int ModuleId)
        {
            return sql.ExecuteQueryOne<ClassModule>("select * from  \"" + sql_rule_tablename + "\" where  ID=@ID",new SQLiteParameter("@ID", ModuleId));
        }
        /// <summary>
        /// 更新或者新增模块配置信息
        /// </summary>
        /// <param name="Module">要添加或者更新的模块配置信息</param>
        /// <returns>成功更新数量或者新增ID 失败返回-1 </returns>
        public int ModuleUpdate(ClassModule Module)
        {
            string sqlstr = "update  \"" + sql_rule_tablename + "\" Set PostName=@PostName,XmlData=@XmlData,ModifyOn=@ModifyOn where  ID=@ID";
            if (Module.ID == 0)
            {
                sqlstr = "INSERT INTO \"" + sql_rule_tablename + "\"(PostName,XmlData,ModifyOn) VALUES (@PostName,@XmlData,@ModifyOn)";
            }
            int result = sql.ExecuteSql(sqlstr, new SQLiteParameter("@ID", Module.ID),
                new SQLiteParameter("@PostName", Module.PostName),
                new SQLiteParameter("@XmlData", Module.XmlData),
                new SQLiteParameter("@ModifyOn", Module.ModifyOn)
                );
            if (Module.ID == 0)
            {
                Module.ID = result;
            }
            return result;
        }
        /// <summary>
        /// 模块配置信息删除
        /// </summary>
        /// <param name="Id">要删除的ID</param>
        /// <returns>返回删除结果</returns>
        public bool ModuleDelete(int Id)
        {
            return sql.ExecuteNonQuery("delete FROM \"" + sql_rule_tablename + "\" where ID=@ID", new SQLiteParameter("@ID", Id)) > 0;
        }


    }
}
