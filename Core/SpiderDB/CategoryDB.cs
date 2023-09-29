using System;
using System.Collections.Generic;
using GAC_Collection.Helper;
using System.Data.SQLite;
using GAC_Collection.Class;
using GacDB.Properties;

namespace GAC_Collection
{
    public class CategoryDB
    {
        SQLiteHelper sql = null;
        private const string sql_rule_tablename = "G_Category";
        public CategoryDB()
        {
            sql= new SQLiteHelper(System.Environment.CurrentDirectory+ Resources.UserData+ "Config.db");

        }
        public List<RuleCategory> CategoryGet(int ParentId=0)
        {
            return sql.ExecuteQuery<RuleCategory>("select * from  \"" + sql_rule_tablename + "\" where ParentID=@ParentID", new SQLiteParameter("@ParentID", ParentId));
        }
        public int CategoryGetCount(int ParentId = 0)
        {
            return Convert.ToInt32( sql.ExecuteQuery("select count(*) from  \"" + sql_rule_tablename + "\" where ParentID=@ParentID", new SQLiteParameter("@ParentID", ParentId)).Rows[0][0].ToString());
        }
        public bool CategoryDelete(int Id,bool IsCategory=true)
        {
            return sql.ExecuteNonQuery("delete FROM \"" + sql_rule_tablename + "\" where ID=@ID and RuleType=@RuleType", new SQLiteParameter("@ID", Id), new SQLiteParameter("@RuleType", IsCategory)) >0;
        }
        public bool CategoryUpdate(RuleCategory Category, bool IsCategory = true)
        {
            string sqlstr = "update  \"" + sql_rule_tablename + "\" Set ParentID=@ParentID,Name=@Name,Remarks=@Remarks,RuleType=@RuleType,GetUrl=@GetUrl,GetContent=@GetContent,Send=@Send,LastDate=@LastDate where ID=@ID";
            return sql.ExecuteNonQuery(sqlstr, new SQLiteParameter("@ID", Category.Id),
                new SQLiteParameter("@ParentID", Category.ParentId),
                new SQLiteParameter("@Name", Category.Name),
                new SQLiteParameter("@Remarks", Category.Remarks),
                new SQLiteParameter("@RuleType", IsCategory),
                new SQLiteParameter("@GetUrl", Category.GetUrl),
                new SQLiteParameter("@GetContent", Category.GetContent),
                new SQLiteParameter("@Send", Category.Send),
                new SQLiteParameter("@LastDate",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                ) > 0;
        }
        public bool CategoryAdd(RuleCategory Category, bool IsCategory = true)
        {
            string sqlstr = "INSERT INTO \"" + sql_rule_tablename + "\"(ParentID,Name,Remarks,RuleType,GetUrl,GetContent,Send,LastDate) VALUES (@ParentID, @Name, @Remarks,@RuleType, @GetUrl, @GetContent, @Send,@LastDate)";
            return sql.ExecuteNonQuery(sqlstr, new SQLiteParameter("@ParentID",Category.ParentId),
                new SQLiteParameter("@Name", Category.Name),
                new SQLiteParameter("@Remarks", Category.Remarks),
                new SQLiteParameter("@RuleType", IsCategory), 
                new SQLiteParameter("@GetUrl", Category.GetUrl),
                new SQLiteParameter("@GetContent", Category.GetContent),
                new SQLiteParameter("@Send", Category.Send),
                 new SQLiteParameter("@LastDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                ) >0;
        }
    }
}
