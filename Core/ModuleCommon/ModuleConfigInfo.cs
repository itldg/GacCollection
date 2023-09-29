using System;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gac
{
    [XmlRoot("root")]
    public class ModuleConfigInfo
    {
        private string _ModuleName = "";
        /// <summary>
        /// 选择的发布模块名称
        /// </summary>
        public string ModuleName
        {
            get { return _ModuleName; }
            set { _ModuleName = value; }
        }

        private string _GlobalVar = "";
        /// <summary>
        /// 全局变量信息
        /// </summary>
        public string GlobalVar
        {
            get { return _GlobalVar; }
            set { _GlobalVar = value; }
        }
      

        private string _Encoding = "UTF-8";
        /// <summary>
        /// 模块编码 默认值：UTF-8 
        /// </summary>
        public string Encoding
        {
            get { return _Encoding; }
            set { _Encoding = value; }
        }

        private string _SiteUrl = "";
        /// <summary>
        /// 参考值：网站根地址 
        /// </summary>
        public string SiteUrl
        {
            get { return _SiteUrl; }
            set { _SiteUrl = value; }
        }


        private int _LoginType = 0;
        /// <summary>
        /// 登陆类型 0是内置浏览器 1是数据包登陆 2是无需登陆&http请求设置
        /// </summary>
        public int LoginType
        {
            get { return _LoginType; }
            set { _LoginType = value; }
        }

        private string _UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36";
        /// <summary>
        /// 默认值：Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729) 
        /// </summary>
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }

        private string _Cookies = "";
        /// <summary>
        /// 登陆的Cookies
        /// </summary>
        public string Cookies
        {
            get { return _Cookies; }
            set { _Cookies = value; }
        }







        private string _UserName = "";
        /// <summary>
        /// 登陆用户名 
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _Password = "";
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }



        private string _AcceptLanguage = "zh-cn,cn,en,en-us";
        /// <summary>
        /// 参考值：zh-cn,cn,en,en-us 
        /// </summary>
        public string AcceptLanguage
        {
            get { return _AcceptLanguage; }
            set { _AcceptLanguage = value; }
        }

        private int _TimeOut = 30;
        /// <summary>
        /// 参考值：30 
        /// </summary>
        public int TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }

        private string _Fid ="";
        /// <summary>
        /// 分类ID
        /// </summary>
        public string Fid
        {
            get { return _Fid; }
            set { _Fid = value; }
        }

        private string _FName = "";
        /// <summary>
        /// 分类名称 
        /// </summary>
        public string FName
        {
            get { return _FName; }
            set { _FName = value; }
        }

    }
}
