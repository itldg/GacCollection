
using System;
using System.Xml;
using System.Collections.Generic;

namespace GacXml
{

    public class DbConfig
    {
        private List<Conn> _ConnCollection = new List<Conn>();
        public List<Conn> ConnCollection
        {
            get { return _ConnCollection; }
            set { _ConnCollection = value; }
        }

        private List<MySql> _MySqlCollection = new List<MySql>();
        public List<MySql> MySqlCollection
        {
            get { return _MySqlCollection; }
            set { _MySqlCollection = value; }
        }

        private List<SqlServer> _SqlServerCollection = new List<SqlServer>();
        public List<SqlServer> SqlServerCollection
        {
            get { return _SqlServerCollection; }
            set { _SqlServerCollection = value; }
        }

        private List<MongoDb> _MongoDbCollection = new List<MongoDb>();
        public List<MongoDb> MongoDbCollection
        {
            get { return _MongoDbCollection; }
            set { _MongoDbCollection = value; }
        }

        private List<string> _DatabaseType = new List<string>();
        /// <summary>
        /// 参考值：Sqlite 
        /// </summary>
        public List<string> DatabaseType
        {
            get { return _DatabaseType; }
            set { _DatabaseType = value; }
        }

    }


    public class Conn
    {
        private string _MySql = default(string);
        /// <summary>
        /// 参考值：server=localhost;user id=root; password=; database=; pooling=true;charset=utf8;Port=3306; 
        /// </summary>
        public string MySql
        {
            get { return _MySql; }
            set { _MySql = value; }
        }

        private string _SqlServer = default(string);
        /// <summary>
        /// 参考值：Provider=SQLOLEDB;Data Source=(local);User ID=sa;Password=zwl1988;Initial Catalog=huochetou;Connect Timeout=15 
        /// </summary>
        public string SqlServer
        {
            get { return _SqlServer; }
            set { _SqlServer = value; }
        }

        private string _MongoDb = default(string);
        /// <summary>
        /// 参考值：mongodb://localhost
        /// </summary>
        public string MongoDb
        {
            get { return _MongoDb; }
            set { _MongoDb = value; }
        }

    }


    public class MySql
    {
        private string _Host = default(string);
        /// <summary>
        /// 参考值：localhost 
        /// </summary>
        public string Host
        {
            get { return _Host; }
            set { _Host = value; }
        }

        private Int32 _Port = default(Int32);
        /// <summary>
        /// 参考值：3306 
        /// </summary>
        public Int32 Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        private string _User = default(string);
        /// <summary>
        /// 参考值：root 
        /// </summary>
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        private string _Password = default(string);
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Encoding = default(string);
        /// <summary>
        /// 参考值：utf8 
        /// </summary>
        public string Encoding
        {
            get { return _Encoding; }
            set { _Encoding = value; }
        }

        private string _Database = default(string);
        public string Database
        {
            get { return _Database; }
            set { _Database = value; }
        }

    }


    public class SqlServer
    {
        private string _Host = default(string);
        /// <summary>
        /// 参考值：(local) 
        /// </summary>
        public string Host
        {
            get { return _Host; }
            set { _Host = value; }
        }

        private Int32 _ConnetionType = default(Int32);
        /// <summary>
        /// 验证类型
        /// 1 系统验证
        /// 2 sql验证
        /// </summary>
        public Int32 ConnetionType
        {
            get { return _ConnetionType; }
            set { _ConnetionType = value; }
        }

        private string _User = default(string);
        /// <summary>
        /// 参考值：sa 
        /// </summary>
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        private string _Password = default(string);
        /// <summary>
        /// 参考值：GACCollection 
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Database = default(string);
        /// <summary>
        /// 参考值：GACCollection 
        /// </summary>
        public string Database
        {
            get { return _Database; }
            set { _Database = value; }
        }

    }


    public class MongoDb
    {
        private string _Host = default(string);
        /// <summary>
        /// 参考值：mongodb://localhost 
        /// </summary>
        public string Host
        {
            get { return _Host; }
            set { _Host = value; }
        }

        private string _Data = default(string);
        public string Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        private string _mongodPath = default(string);
        /// <summary>
        /// 参考值：路径不可包含中文字符 
        /// </summary>
        public string mongodPath
        {
            get { return _mongodPath; }
            set { _mongodPath = value; }
        }

    }


    public class DatabaseType
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：Sqlite 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


}
