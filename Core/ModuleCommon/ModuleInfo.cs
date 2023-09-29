using System;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gac
{
    [XmlRootAttribute("root",  IsNullable = false)]
    public class ModuleInfo
    {
        private string _CmsVersion = "";
        /// <summary>
        /// 参考值：版本号 
        /// </summary>
        public string CmsVersion
        {
            get { return _CmsVersion; }
            set { _CmsVersion = value; }
        }

        private string _CmsName ="";
        /// <summary>
        /// 参考值：系统名称 
        /// </summary>
        public string CmsName
        {
            get { return _CmsName; }
            set { _CmsName = value; }
        }

        private string _LoginUrl = "";
        /// <summary>
        /// 参考值：登陆地址后缀 
        /// </summary>
        public string LoginUrl
        {
            get { return _LoginUrl; }
            set { _LoginUrl = value; }
        }

        private string _LoginRefer = "";
        /// <summary>
        /// 参考值：登陆来源后缀 
        /// </summary>
        public string LoginRefer
        {
            get { return _LoginRefer; }
            set { _LoginRefer = value; }
        }

        private string _LoginImgUrl = "";
        /// <summary>
        /// 参考值：登陆验证码地址 
        /// </summary>
        public string LoginImgUrl
        {
            get { return _LoginImgUrl; }
            set { _LoginImgUrl = value; }
        }

        private string[] _LoginErrInfo = new string[] { };
        /// <summary>
        /// 登陆失败标志 一行一个
        /// </summary>
        [XmlElementAttribute("LoginErrInfo", IsNullable = false)]
        public string[] LoginErrInfo
        {
            get { return _LoginErrInfo; }
            set {
                if (value != null)
                {
                    _LoginErrInfo = value;
                }
            }
        }
        
        private string[] _LoginSuccessInfo = new string[] { };
        /// <summary>
        /// 登录成功标志  一行一个
        /// </summary>
        [XmlElementAttribute("LoginSuccessInfo", IsNullable = false)]
        public string[] LoginSuccessInfo
        {
            get { return _LoginSuccessInfo; }
            set {
                if (value != null)
                {
                    _LoginSuccessInfo = value;
                }
                }
        }

        private string[] _LoginImgErrInfo = new string[] { };
        /// <summary>
        /// 验证码失败标志  一行一个
        /// </summary>
        [XmlElementAttribute("LoginImgErrInfo", IsNullable = false)]
        public string[] LoginImgErrInfo
        {
            get { return _LoginImgErrInfo; }
            set {
                if (value!=null)
                {
                    _LoginImgErrInfo = value;
                }
                
            }
        }

        private PostData[] _LoginPost = new PostData[] { };
        [XmlElementAttribute("LoginPost", IsNullable = false)]
        public PostData[] LoginPost
        {
            get { return _LoginPost; }
            set {
                    if (value!=null)
                    {
                        _LoginPost = value;
                    }
                }
        }

        private string _RefreshUrl = "";
        /// <summary>
        /// 刷新列表页面网址
        /// </summary>
        public string RefreshUrl
        {
            get { return _RefreshUrl; }
            set { _RefreshUrl = value; }
        }

        private string _RefreshRefer = "";
        /// <summary>
        /// 参考值：刷新列表页面后缀 
        /// </summary>
        public string RefreshRefer
        {
            get { return _RefreshRefer; }
            set { _RefreshRefer = value; }
        }

        private string _RefreshStart = "";
        /// <summary>
        /// 参考值：刷新列表页面区域开始 
        /// </summary>
        public string RefreshStart
        {
            get { return _RefreshStart; }
            set { _RefreshStart = value; }
        }

        private string _RefreshEnd = "";
        /// <summary>
        /// 参考值：刷新列表页面区域结束 
        /// </summary>
        public string RefreshEnd
        {
            get { return _RefreshEnd; }
            set { _RefreshEnd = value; }
        }

        private string _RefreshRegex = "";
        /// <summary>
        /// 参考值：刷新列表分类列表名称及格式 
        /// </summary>
        public string RefreshRegex
        {
            get { return _RefreshRegex; }
            set { _RefreshRegex = value; }
        }

        private List<HashDic> _HashDic = new List<HashDic>();
        [XmlElementAttribute("HashDic", IsNullable = false)]
        public List<HashDic> HashDic
        {
            get { return _HashDic; }
            set
            {
                if (value != null)
                {
                    _HashDic = value;
                }
            }
        }

        private string _ForceEncoding = "";
        public string ForceEncoding
        {
            get { return _ForceEncoding; }
            set { _ForceEncoding = value; }
        }

        private string _PostUrl = "";
        /// <summary>
        /// 参考值：发表地址后缀 
        /// </summary>
        public string PostUrl
        {
            get { return _PostUrl; }
            set { _PostUrl = value; }
        }

        private string _PostRefer = "";
        /// <summary>
        /// 参考值：发表页面后缀 
        /// </summary>
        public string PostRefer
        {
            get { return _PostRefer; }
            set { _PostRefer = value; }
        }

        private string _DataPostType = "";
        /// <summary>
        /// 参考值：application/x-www-form-urlencoded 
        /// </summary>
        public string DataPostType
        {
            get { return _DataPostType; }
            set { _DataPostType = value; }
        }

        private PostData[] _PostData = new PostData[] { };
        [XmlElement("PostData", IsNullable = false)]
        public PostData[] PostData
        {
            get { return _PostData; }
            set
            {
                if (value != null)
                {
                    _PostData = value;
                }
       }
        }


        private string[] _PostErrInfo = new string[] { };
        /// <summary>
        /// 发表错误标志   一行一个
        /// </summary>
        [XmlElementAttribute("PostErrInfo", IsNullable = false)]
        public string[] PostErrInfo
        {
            get { return _PostErrInfo; }
            set {
                if (value != null)
                {
                    _PostErrInfo = value;
                }
            }
        }

        private string[] _PostSuccessInfo = new string[] { };
        /// <summary>
        /// 发表成功标志   一行一个
        /// </summary>
        [XmlElementAttribute("PostSuccessInfo", IsNullable = false)]
        public string[] PostSuccessInfo
        {
            get { return _PostSuccessInfo; }
            set {
                if (value != null)
                {
                    _PostSuccessInfo = value;
                }
            }
        }

        private string _Memo = "";
        /// <summary>
        /// 参考值：模块说明
        /// </summary>
        [XmlElementAttribute("Memo", IsNullable = false)]
        public string Memo
        {
            get { return _Memo; }
            set { _Memo = value; }
        }

        private string _CopyRightInfo = "";
        /// <summary>
        /// 版权字符串 
        /// </summary>
        [XmlElementAttribute("CopyRightInfo", IsNullable = false)]
        public string CopyRightInfo
        {
            get { return _CopyRightInfo; }
            set { _CopyRightInfo = value; }
        }

        private string _CopyRightLink = "";
        /// <summary>
        /// 版权链接
        /// </summary>
        [XmlElementAttribute("CopyRightLink", IsNullable = false)]
        public string CopyRightLink
        {
            get {
                return _CopyRightLink;
            }
            set { _CopyRightLink = value; }
        }

        private string _Password = "";
        /// <summary>
        ///模块密码
        /// </summary>
        [XmlElementAttribute("Password", IsNullable = false)]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _PluginFile = "";
        public string  PluginFile
        {
            get { return _PluginFile; }
            set { _PluginFile = value; }
        }

        private string _HaveSortId = "";
        /// <summary>
        /// 该模块是否用到了分类ID
        /// </summary>
        public string HaveSortId
        {
            get { return _HaveSortId; }
            set { _HaveSortId = value; }
        }

        private string _HaveSortName = "";
        /// <summary>
        /// 该模块是否用到了分类名称
        /// </summary>
        public string HaveSortName
        {
            get { return _HaveSortName; }
            set { _HaveSortName = value; }
        }

        private string _HaveGlobalVar = "";
        /// <summary>
        /// 该模块是否用到了全局变量
        /// </summary>
        public string HaveGlobalVar
        {
            get { return _HaveGlobalVar; }
            set { _HaveGlobalVar = value; }
        }

    }




    [XmlRootAttribute("HashDic")]
    public class HashDic
    {
        private string _Name = default(string);
        /// <summary>
        /// 参考值：[Hash1] 
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _HashUrl = default(string);
        /// <summary>
        /// 参考值：网页随机值获取页面1 
        /// </summary>
        [XmlAttribute("HashUrl")]
        public string HashUrl
        {
            get { return _HashUrl; }
            set { _HashUrl = value; }
        }

        private string _HashRefer = default(string);
        /// <summary>
        /// 参考值：网页随机值来源页面1 
        /// </summary>
        [XmlAttribute("HashRefer")]
        public string HashRefer
        {
            get { return _HashRefer; }
            set { _HashRefer = value; }
        }

        private string _HashStart = default(string);
        /// <summary>
        /// 参考值：网页随机值随机值前 
        /// </summary>
        [XmlAttribute("HashStart")]
        public string HashStart
        {
            get { return _HashStart; }
            set { _HashStart = value; }
        }

        private string _HashEnd = default(string);
        /// <summary>
        /// 参考值：网页随机值随机值后 
        /// </summary>
        [XmlAttribute("HashEnd")]
        public string HashEnd
        {
            get { return _HashEnd; }
            set { _HashEnd = value; }
        }

        private string _OnlyOnce = default(string);
        /// <summary>
        /// 参考值：True 
        /// </summary>
        [XmlAttribute("OnlyOnce")]
        public string OnlyOnce
        {
            get { return _OnlyOnce; }
            set { _OnlyOnce = value; }
        }

    }

    /// <summary>
    /// Post信息列表
    /// </summary>
    [XmlRootAttribute("root", IsNullable = false)]
    public class PostList
    {

        private PostData[] _PostData = new PostData[] { };
        [XmlElement("PostData", IsNullable = false)]
        public PostData[] PostData
        {
            get
            {
                return _PostData;
            }

            set
            {
                if (value!=null)
                {
                    _PostData = value;
                }
              
            }
        }
    }
    
    public class PostData
    {
        private string _Key = default(string);
        /// <summary>
        /// 参考值：发表表单1 
        /// </summary>
        [XmlAttribute("Key")]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        private string _Value = default(string);
        /// <summary>
        /// 参考值：发表表单值1 
        /// </summary>
        [XmlAttribute("Value")]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }
}
