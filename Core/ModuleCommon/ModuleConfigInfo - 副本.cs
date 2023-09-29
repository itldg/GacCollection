using System;
using System.Xml;
using System.Collections.Generic;
namespace Gac
{

    public class ModuleConfigInfo
    {
        private List<Cookies> _CookiesCollection = new List<Cookies>();
        public List<Cookies> CookiesCollection
        {
            get { return _CookiesCollection; }
            set { _CookiesCollection = value; }
        }

        private List<string> _Encoding = new List<string>();
        /// <summary>
        /// 参考值：UTF-8 
        /// </summary>
        public List<string> Encoding
        {
            get { return _Encoding; }
            set { _Encoding = value; }
        }

        private List<GlobalVar> _GlobalVarCollection = new List<GlobalVar>();
        public List<GlobalVar> GlobalVarCollection
        {
            get { return _GlobalVarCollection; }
            set { _GlobalVarCollection = value; }
        }

        private List<string> _LoginType = new List<string>();
        /// <summary>
        /// 参考值：2 
        /// </summary>
        public List<string> LoginType
        {
            get { return _LoginType; }
            set { _LoginType = value; }
        }

        private List<string> _Fid = new List<string>();
        /// <summary>
        /// 参考值：9999 
        /// </summary>
        public List<string> Fid
        {
            get { return _Fid; }
            set { _Fid = value; }
        }

        private List<string> _FName = new List<string>();
        /// <summary>
        /// 参考值：分类名称 
        /// </summary>
        public List<string> FName
        {
            get { return _FName; }
            set { _FName = value; }
        }

        private List<string> _ModuleName = new List<string>();
        /// <summary>
        /// 参考值：2016最新苹果8X文章发布模块 
        /// </summary>
        public List<string> ModuleName
        {
            get { return _ModuleName; }
            set { _ModuleName = value; }
        }

        private List<string> _Password = new List<string>();
        /// <summary>
        /// 参考值：mima 
        /// </summary>
        public List<string> Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private List<string> _SiteUrl = new List<string>();
        /// <summary>
        /// 参考值：网站根地址 
        /// </summary>
        public List<string> SiteUrl
        {
            get { return _SiteUrl; }
            set { _SiteUrl = value; }
        }

        private List<string> _UserAgent = new List<string>();
        /// <summary>
        /// 参考值：Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729) 
        /// </summary>
        public List<string> UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }

        private List<string> _UserName = new List<string>();
        /// <summary>
        /// 参考值：用户名 
        /// </summary>
        public List<string> UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private List<string> _AcceptLanguage = new List<string>();
        /// <summary>
        /// 参考值：zh-cn,cn,en,en-us 
        /// </summary>
        public List<string> AcceptLanguage
        {
            get { return _AcceptLanguage; }
            set { _AcceptLanguage = value; }
        }

        private List<string> _TimeOut = new List<string>();
        /// <summary>
        /// 参考值：30 
        /// </summary>
        public List<string> TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }

    }


    public class Cookies
    {
    }


    public class Encoding
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：UTF-8 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class GlobalVar
    {
    }


    public class LoginType
    {
        private Int32 _Value = default(Int32);
        /// <summary>
        /// 参考值：2 
        /// </summary>
        public Int32 Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class Fid
    {
        private Int32 _Value = default(Int32);
        /// <summary>
        /// 参考值：9999 
        /// </summary>
        public Int32 Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class FName
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：分类名称 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class ModuleName
    {
        private string _Value = default(string);
        /// <summary>
        /// 发布模块名称
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }

    public class SiteUrl
    {
        private string _Value = default(string);
        /// <summary>
        /// 网站根地址 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class UserAgent
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729) 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class UserName
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：用户名 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class AcceptLanguage
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：zh-cn,cn,en,en-us 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class TimeOut
    {
        private Int32 _Value = default(Int32);
        /// <summary>
        /// 参考值：30 
        /// </summary>
        public Int32 Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


}
