using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Reflection;

namespace GAC_Collection.Helper
{

    ///
    /// SQLiteHelper类
    ///
    public class SQLiteHelper
    {
        private SQLiteConnection conn = null;
        private SQLiteCommand cmd = null;
        private SQLiteDataReader sdr = null;
        ///
        /// 构造函数
        ///
        public SQLiteHelper(string dbPath)
        {
            // string connStr = "";
            //"Data Source =" + dbPath)
            conn = new SQLiteConnection("Data Source =" + dbPath);
        }
        ///
        /// 获取连接结果，未连接打开连接
        ///
        /// 连接结果
        private SQLiteConnection GetConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        ///
        /// 该方法执行传入的增删改SQL语句
        ///
        /// 要执行的增删改SQL语句
        /// 返回更新的记录数
        public int ExecuteNonQuery(string sql)
        {
            int res;
            try
            {
                cmd = new SQLiteCommand(sql, GetConn());
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = -1;
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }
        ///
        /// 执行带参数的SQL增删改语句
        ///
        /// SQL增删改语句
        /// 参数集合
        /// 返回更新的记录数
        public int ExecuteNonQuery(string sql, params SQLiteParameter[] paras)
        {
            int res;
            using (cmd = new SQLiteCommand(sql, GetConn()))
            {
                cmd.Parameters.AddRange(paras);
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }
        public int ExecuteSql(string sql, params SQLiteParameter[] paras)
        {
            int res;
            if (sql.ToLower().IndexOf("insert") != -1)
            {
                sql += ";select last_insert_rowid();";
            }
            using (cmd = new SQLiteCommand(sql, GetConn()))
            {
                try
                {

                    cmd.Parameters.AddRange(paras);
                    if (sql.ToLower().IndexOf("insert") != -1)
                        res = Convert.ToInt32(cmd.ExecuteScalar());
                    else
                        res = cmd.ExecuteNonQuery();

                }
                catch (SQLiteException)
                {
                    return -1;
                }
            }
            return res;

        }
        ///
        /// 该方法执行传入的SQL查询语句
        ///
        /// SQL查询语句
        /// 返回数据集合
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            cmd = new SQLiteCommand(sql, GetConn());
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        ///
        /// 执行带参数的SQL查询语句
        ///
        /// SQL查询语句
        /// 参数集合
        /// 返回数据集合
        public DataTable ExecuteQuery(string sql, params SQLiteParameter[] paras)
        {
            DataTable dt = new DataTable();
            cmd = new SQLiteCommand(sql, GetConn());
            cmd.Parameters.AddRange(paras);
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        ///
        /// 执行带参数的SQL查询判断语句
        ///
        /// SQL查询语句
        /// 参数集合
        /// 返回是否为空
        public bool BoolExecuteQuery(string sql, params SQLiteParameter[] paras)
        {
            DataTable dt = new DataTable();
            cmd = new SQLiteCommand(sql, GetConn());
            cmd.Parameters.AddRange(paras);
            try
            {
                using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    dt.Load(sdr);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            DataRow[] rows = dt.Select();
            bool temp = false;
            if (rows.Length > 0)
            {
                temp = true;
            }
            return temp;
        }
        ///
        /// 该方法执行传入的SQL查询判断语句
        ///
        /// SQL查询语句
        /// 返回是否为空
        public bool BoolExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            cmd = new SQLiteCommand(sql, GetConn());
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            DataRow[] rows = dt.Select();
            bool temp = false;
            if (rows.Length > 0)
            {
                temp = true;
            }
            return temp;
        }
        /// <summary>
        /// 执行带参数的SQL查询判断语句
        /// </summary>
        /// <typeparam name="T">返回数据</typeparam>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public T ExecuteQueryOne<T>(string sql, params SQLiteParameter[] paras) where T : class, new()
        {
            DataTable dt = ExecuteQuery(sql, paras);
            if (dt.Rows.Count > 0)
            {
                Type type = typeof(T);

                //  创建一个类T的实例
                //object entity = type.Assembly.CreateInstance(type.FullName);

                PropertyInfo[] pArray = type.GetProperties();
                T entity = new T();
                foreach (PropertyInfo p in pArray)
                {
                    if (dt.Rows[0][p.Name] is Int64)
                    {
                        if (p.PropertyType.Name == "Boolean")
                        {
                            p.SetValue(entity, Convert.ToBoolean(dt.Rows[0][p.Name]), null);
                        }
                        else
                        {
                            p.SetValue(entity, Convert.ToInt32(dt.Rows[0][p.Name]), null);
                        }
                    }
                    else if (dt.Rows[0][p.Name] is byte)
                    {
                        p.SetValue(entity, Convert.ToBoolean(dt.Rows[0][p.Name]), null);
                    }
                    else if (p.PropertyType.Name  == "DateTime")
                    {
                        p.SetValue(entity, Convert.ToDateTime(dt.Rows[0][p.Name]), null);
                    }
                    else
                    {
                        p.SetValue(entity, dt.Rows[0][p.Name], null);
                    }
                }
                return entity;
            }
            return null;
        }
        /// <summary>
        /// 执行带参数的SQL查询判断语句
        /// </summary>
        /// <typeparam name="T">返回数据</typeparam>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public List<T> ExecuteQuery<T>(string sql, params SQLiteParameter[] paras) where T : class, new()
        {
            DataTable dt = ExecuteQuery(sql, paras);
            return TableToEntity<T>(dt);
        }
        private List<T> TableToEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                PropertyInfo[] pArray = type.GetProperties();
                T entity = new T();
                foreach (PropertyInfo p in pArray)
                {
                    if (row[p.Name] is Int64)
                    {
                        if (p.PropertyType.Name == "Boolean")
                        {
                            p.SetValue(entity, Convert.ToBoolean(row[p.Name]), null);
                        }
                        else
                        {
                            p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        }
                    }
                    else if (row[p.Name] is byte)
                    {
                        
                        p.SetValue(entity, Convert.ToBoolean(row[p.Name]), null);
                    }
                    else if (p.PropertyType.Name == "DateTime")
                    {
                        p.SetValue(entity, Convert.ToDateTime(row[p.Name]), null);
                    }
                    else
                    {
                        p.SetValue(entity, row[p.Name], null);
                    }
                }
                list.Add(entity);
            }
            return list;
        }

    }
}