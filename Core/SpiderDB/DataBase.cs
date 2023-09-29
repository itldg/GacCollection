using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

namespace SpiderDB
{
    /// <summary>
    /// 数据访问基础类
    /// </summary>
    public class DataHelper
    {
        string connectionString;
        DbProviderFactory provider;
        public DataHelper(string connectionString,string DbType)
        {
            string ProviderName = "";
            switch (DbType)
            {
                case "Sqlite":
                    ProviderName = "System.Data.SQLite";
                    break;
                case "MySql":
                    ProviderName = "MySql.Data.MySqlClient";
                    break;
                case "SqlServer":
                    ProviderName = "System.Data.SqlClient";
                    break;
                case "MongoDb":
                    ProviderName = "MongoDB.Driver";
                    break;
                default:
                    ProviderName = "System.Data.OleDb";
                    break;
            }



             //System.Data.OleDb
             //System.Data.SqlClient
            this.connectionString = connectionString;
            provider = DbProviderFactories.GetFactory(ProviderName);
        }

        #region  执行简单SQL语句
        public string Connect()
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                try
                {
                    connection.Open();
                    connection.Close();
                    connection.Dispose();
                    return "ok";
                }
                catch (DbException E)
                {
                    return E.Message;
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SQLString;
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (DbException E)
                    {
                        connection.Close();
                        connection.Dispose();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>        
        public void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = conn;
                    using (DbTransaction tx = conn.BeginTransaction())
                    {
                        cmd.Transaction = tx;
                        try
                        {
                            for (int n = 0; n < SQLStringList.Count; n++)
                            {
                                string strsql = SQLStringList[n].ToString();
                                if (strsql.Trim().Length > 1)
                                {
                                    cmd.CommandText = strsql;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            tx.Commit();
                        }
                        catch (DbException ex)
                        {
                            tx.Rollback();
                            conn.Close();
                            conn.Dispose();
                            throw ex;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SQLString;
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (DbException e)
                    {
                        connection.Close();
                        connection.Dispose();
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public DbDataReader ExecuteReader(string strSQL)
        {
            DbConnection connection = provider.CreateConnection();
            connection.ConnectionString = connectionString;
            DbCommand cmd = provider.CreateCommand();
            cmd.Connection = connection;
            cmd.CommandText = strSQL;
            try
            {
                connection.Open();
                DbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.Common.DbException e)
            {
                connection.Close();
                connection.Dispose();
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 返回文本 如果数据有多条,返回一条
        /// </summary>
        /// <returns></returns>
        public string ExecuteString(string Sql)
        {

            DbDataReader myReader = ExecuteReader(Sql);
           
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    string result = myReader[0].ToString();
                    myReader.Close();
                    return result;
                }
            }
            myReader.Close();
            return "";
           
        }

        /// <summary>
        /// 返回文本数组
        /// </summary>
        /// <returns></returns>
        public List<string> GetList(string Sql)
        {

            DbDataReader myReader = ExecuteReader(Sql);
            List<string> list_tblName = new List<string>();
            if (myReader.HasRows)
            {
                list_tblName = new List<string>();
                while (myReader.Read())
                {
                    string t = myReader.GetString(0);
                    list_tblName.Add(t);
                }
            }
            myReader.Close();
            return list_tblName;
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string SQLString)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SQLString;
                    try
                    {
                        DataSet ds = new DataSet();
                        DbDataAdapter adapter = provider.CreateDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds, "ds");
                        return ds;
                    }
                    catch (DbException ex)
                    {
                        connection.Close();
                        connection.Dispose();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, DbParameter[] cmdParms)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SQLString;
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (DbException E)
                    {
                        connection.Close();
                        connection.Dispose();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    using (DbCommand cmd = provider.CreateCommand())
                    {
                        try
                        {
                            //循环
                            foreach (DictionaryEntry myDE in SQLStringList)
                            {
                                string cmdText = myDE.Key.ToString();
                                DbParameter[] cmdParms = (DbParameter[])myDE.Value;
                                PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            trans.Commit();
                        }
                        catch (DbException ex)
                        {
                            trans.Rollback();
                            conn.Close();
                            conn.Dispose();
                            throw ex;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）,返回首行首列的值;
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString, DbParameter[] cmdParms)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (DbException e)
                    {
                        connection.Close();
                        connection.Dispose();
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public DbDataReader ExecuteReader(string SQLString, DbParameter[] cmdParms)
        {
            DbConnection connection = provider.CreateConnection();
            connection.ConnectionString = connectionString;
            DbCommand cmd = provider.CreateCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                DbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (DbException e)
            {
                connection.Close();
                connection.Dispose();
                throw new Exception(e.Message);
            }

        }


        /// <summary>
        /// 执行查询语句，返回查询结果,如果有多条,返回第一条
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>查询结果</returns>
        public string ExecuteString(string SQLString, DbParameter[] cmdParms)
        {

            DbDataReader myReader = ExecuteReader(SQLString, cmdParms);
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    string result = myReader[0].ToString();// myReader.GetString(0);
                    myReader.Close();
                    return result;
                }
            }
            myReader.Close();
            return "";
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string SQLString, DbParameter[] cmdParms)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    using (DbDataAdapter da = provider.CreateDataAdapter())
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds, "ds");
                            cmd.Parameters.Clear();
                            return ds;
                        }
                        catch (DbException ex)
                        {
                            connection.Close();
                            connection.Dispose();
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
        }

        private void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction trans, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (DbParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        #endregion

        #region 存储过程操作
        /// <summary>
        /// 执行存储过程;
        /// </summary>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">所需要的参数</param>
        /// <returns>返回受影响的行数</returns>
        public int RunProcedureExecuteSql(string storeProcName, DbParameter[] parameters)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                DbCommand cmd = BuildQueryCommand(connection, storeProcName, parameters);
                int rows = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connection.Close();
                return rows;
            }
        }

        /// <summary>
        /// 执行存储过程,返回首行首列的值
        /// </summary>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>返回首行首列的值</returns>
        public Object RunProcedureGetSingle(string storeProcName, DbParameter[] parameters)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                try
                {
                    DbCommand cmd = BuildQueryCommand(connection, storeProcName, parameters);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (DbException e)
                {
                    connection.Close();
                    connection.Dispose();
                    throw new Exception(e.Message);
                }
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public DbDataReader RunProcedureGetDataReader(string storedProcName, DbParameter[] parameters)
        {
            DbConnection connection = provider.CreateConnection();
            connection.ConnectionString = connectionString;
            DbDataReader returnReader;
            DbCommand cmd = BuildQueryCommand(connection, storedProcName, parameters);
            cmd.CommandType = CommandType.StoredProcedure;
            returnReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return returnReader;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedureGetDataSet(string storedProcName, DbParameter[] parameters)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                DataSet dataSet = new DataSet();
                DbDataAdapter sqlDA = provider.CreateDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet);
                sqlDA.SelectCommand.Parameters.Clear();
                sqlDA.Dispose();
                return dataSet;
            }
        }

        /// <summary>
        /// 执行多个存储过程，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">存储过程的哈希表（value为存储过程语句，key是该语句的DbParameter[]）</param>
        public bool RunProcedureTran(Hashtable SQLStringList)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (DbTransaction trans = connection.BeginTransaction())
                {
                    using (DbCommand cmd = provider.CreateCommand())
                    {
                        try
                        {
                            //循环
                            foreach (DictionaryEntry myDE in SQLStringList)
                            {
                                cmd.Connection = connection;
                                string storeName = myDE.Value.ToString();
                                DbParameter[] cmdParms = (DbParameter[])myDE.Key;

                                cmd.Transaction = trans;
                                cmd.CommandText = storeName;
                                cmd.CommandType = CommandType.StoredProcedure;
                                if (cmdParms != null)
                                {
                                    foreach (DbParameter parameter in cmdParms)
                                    {
                                        cmd.Parameters.Add(parameter);
                                    }
                                }
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            trans.Commit();
                            return true;
                        }
                        catch
                        {
                            trans.Rollback();
                            connection.Close();
                            connection.Dispose();
                            return false;
                        }
                    }
                }
            }
        }

        ///// <summary>
        ///// 执行多个存储过程，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">存储过程的哈希表（value为存储过程语句，key是该语句的DbParameter[]）</param>
        //public bool RunProcedureTran(Hashtable SQLStringList)
        //{
        //    using (DbConnection connection = provider.CreateConnection())
        //    {
        //        connection.ConnectionString = connectionString;
        //        connection.Open();
        //        using (DbTransaction trans = connection.BeginTransaction())
        //        {
        //            using (DbCommand cmd = provider.CreateCommand())
        //            {
        //                try
        //                {
        //                    //循环
        //                    foreach (DbParameter[] cmdParms in SQLStringList.Keys)
        //                    {
        //                        cmd.Connection = connection;
        //                        string storeName = SQLStringList[cmdParms].ToString();

        //                        cmd.Transaction = trans;
        //                        cmd.CommandText = storeName;
        //                        cmd.CommandType = CommandType.StoredProcedure;
        //                        if (cmdParms != null)
        //                        {
        //                            foreach (DbParameter parameter in cmdParms)
        //                            {
        //                                cmd.Parameters.Add(parameter);
        //                            }
        //                        }
        //                        int val = cmd.ExecuteNonQuery();
        //                        cmd.Parameters.Clear();
        //                    }
        //                    trans.Commit();
        //                    return true;
        //                }
        //                catch
        //                {
        //                    trans.Rollback();
        //                    connection.Close();
        //                    connection.Dispose();
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private DbCommand BuildQueryCommand(DbConnection connection, string storedProcName, DbParameter[] parameters)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = provider.CreateCommand();
            command.CommandText = storedProcName;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }
        #endregion
    }
}