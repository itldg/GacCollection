using System;
using System.Xml;
using System.Collections.Generic;
namespace Gac
{

    public class ModuleInfo
    {
        private string _CmsVersion =  "";
        /// <summary>
        /// 参考值：版本号 
        /// </summary>
        public string CmsVersion
        {
            get { return _CmsVersion; }
            set { _CmsVersion = value; }
        }

        private string _CmsName = "";
        /// <summary>
        /// 参考值：系统名称 
        /// </summary>
        public string CmsName
        {
            get { return _CmsName; }
            set { _CmsName = value; }
        }

        private string _LoginUrl =  "";
        /// <summary>
        /// 参考值：登陆地址后缀 
        /// </summary>
        public string LoginUrl
        {
            get { return _LoginUrl; }
            set { _LoginUrl = value; }
        }

        private string _LoginRefer =  "";
        /// <summary>
        /// 参考值：登陆来源后缀 
        /// </summary>
        public string LoginRefer
        {
            get { return _LoginRefer; }
            set { _LoginRefer = value; }
        }

        private string _LoginImgUrl =  "";
        /// <summary>
        /// 参考值：登陆验证码地址 
        /// </summary>
        public string LoginImgUrl
        {
            get { return _LoginImgUrl; }
            set { _LoginImgUrl = value; }
        }

        private List<string> _LoginErrInfo = new List<string>();
        /// <summary>
        /// 参考值：登陆失败标志1 
        /// </summary>
        public List<string> LoginErrInfo
        {
            get { return _LoginErrInfo; }
            set { _LoginErrInfo = value; }
        }

        private List<string> _LoginSuccessInfo =  new List<string>();
        /// <summary>
        /// 参考值：登录成功标志1 
        /// </summary>
        public List<string> LoginSuccessInfo
        {
            get { return _LoginSuccessInfo; }
            set { _LoginSuccessInfo = value; }
        }

        private List<string> _LoginImgErrInfo =  new List<string>();
        /// <summary>
        /// 参考值：验证码失败标志1 
        /// </summary>
        public List<string> LoginImgErrInfo
        {
            get { return _LoginImgErrInfo; }
            set { _LoginImgErrInfo = value; }
        }

        private List<LoginPost> _LoginPostCollection =new List<LoginPost>();
        public List<LoginPost> LoginPostCollection
        {
            get { return _LoginPostCollection; }
            set { _LoginPostCollection = value; }
        }

        private string _RefreshUrl = default(string);
        /// <summary>
        /// 参考值：刷新列表页面 
        /// </summary>
        public string RefreshUrl
        {
            get { return _RefreshUrl; }
            set { _RefreshUrl = value; }
        }

        private string _RefreshRefer = default(string);
        /// <summary>
        /// 参考值：刷新列表页面后缀 
        /// </summary>
        public string RefreshRefer
        {
            get { return _RefreshRefer; }
            set { _RefreshRefer = value; }
        }

        private string _RefreshStart = default(string);
        /// <summary>
        /// 参考值：刷新列表页面区域开始 
        /// </summary>
        public string RefreshStart
        {
            get { return _RefreshStart; }
            set { _RefreshStart = value; }
        }

        private string _RefreshEnd = default(string);
        /// <summary>
        /// 参考值：刷新列表页面区域结束 
        /// </summary>
        public string RefreshEnd
        {
            get { return _RefreshEnd; }
            set { _RefreshEnd = value; }
        }

        private string _RefreshRegex = default(string);
        /// <summary>
        /// 参考值：刷新列表分类列表名称及格式 
        /// </summary>
        public string RefreshRegex
        {
            get { return _RefreshRegex; }
            set { _RefreshRegex = value; }
        }

        private List<HashDic> _HashDicCollection = new List<HashDic>();
        public List<HashDic> HashDicCollection
        {
            get { return _HashDicCollection; }
            set { _HashDicCollection = value; }
        }

        private List<ForceEncoding> _ForceEncodingCollection = default(List<ForceEncoding>);
        public List<ForceEncoding> ForceEncodingCollection
        {
            get { return _ForceEncodingCollection; }
            set { _ForceEncodingCollection = value; }
        }

        private string _PostUrl = default(string);
        /// <summary>
        /// 参考值：发表地址后缀 
        /// </summary>
        public string PostUrl
        {
            get { return _PostUrl; }
            set { _PostUrl = value; }
        }

        private string _PostRefer =  default(string);
        /// <summary>
        /// 参考值：发表页面后缀 
        /// </summary>
        public string PostRefer
        {
            get { return _PostRefer; }
            set { _PostRefer = value; }
        }

        private string _DataPostType = default(string);
        /// <summary>
        /// 参考值：application/x-www-form-urlencoded 
        /// </summary>
        public string DataPostType
        {
            get { return _DataPostType; }
            set { _DataPostType = value; }
        }

        private List<PostData> _PostDataCollection = new List<PostData>();
        public List<PostData> PostDataCollection
        {
            get { return _PostDataCollection; }
            set { _PostDataCollection = value; }
        }

        private List<string> _PostErrInfo =  new List<string>();
        /// <summary>
        /// 参考值：发表错误
        /// </summary>
        public List<string> PostErrInfo
        {
            get { return _PostErrInfo; }
            set { _PostErrInfo = value; }
        }

        private List<string> _PostSuccessInfo = new List<string>();
        /// <summary>
        /// 参考值：发表成功
        /// </summary>
        public List<string> PostSuccessInfo
        {
            get { return _PostSuccessInfo; }
            set { _PostSuccessInfo = value; }
        }

        private string _Memo = default(string);
        /// <summary>
        /// 参考值：模块说明
        /// </summary>
        public string Memo
        {
            get { return _Memo; }
            set { _Memo = value; }
        }

        private string _CopyRightInfo = default(string);
        /// <summary>
        /// 模块版权字符串
        /// 参考值：Gac
        /// </summary>
        public string CopyRightInfo
        {
            get { return _CopyRightInfo; }
            set { _CopyRightInfo = value; }
        }

        private string _CopyRightLink = default(string);
        /// <summary>
        /// 模块版权链接
        /// 参考值：http://www.gac.cc/ 
        /// </summary>
        public string CopyRightLink
        {
            get { return _CopyRightLink; }
            set { _CopyRightLink = value; }
        }

        private string _Password = default(string);
        /// <summary>
        /// 参考值：模块密码 
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private List<PluginFile> _PluginFileCollection = default(List<PluginFile>);
        public List<PluginFile> PluginFileCollection
        {
            get { return _PluginFileCollection; }
            set { _PluginFileCollection = value; }
        }

        private bool _HaveSortId =  false;
        /// <summary>
        /// 参考值：False 
        /// </summary>
        public bool HaveSortId
        {
            get { return _HaveSortId; }
            set { _HaveSortId = value; }
        }

        private bool _HaveSortName =  false;
        /// <summary>
        /// 参考值：False 
        /// </summary>
        public bool HaveSortName
        {
            get { return _HaveSortName; }
            set { _HaveSortName = value; }
        }

        private bool _HaveGlobalVar =  false;
        /// <summary>
        /// 参考值：False 
        /// </summary>
        public bool HaveGlobalVar
        {
            get { return _HaveGlobalVar; }
            set { _HaveGlobalVar = value; }
        }

    }


    public class CmsVersion
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：版本号 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class CmsName
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：系统名称 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class LoginUrl
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：登陆地址后缀 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class LoginRefer
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：登陆来源后缀 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class LoginImgUrl
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：登陆验证码地址 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class LoginErrInfo
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：登陆失败标志1 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class LoginSuccessInfo
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：登录成功标志1 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class LoginImgErrInfo
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：验证码失败标志1 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class LoginPost
    {
        private string _Key = default(string);
        /// <summary>
        /// 参考值：登陆表单名1 
        /// </summary>
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        private string _Value = default(string);
        /// <summary>
        /// 参考值：登陆表单值1 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class RefreshUrl
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：刷新列表页面 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class RefreshRefer
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：刷新列表页面后缀 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class RefreshStart
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：刷新列表页面区域开始 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class RefreshEnd
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：刷新列表页面区域结束 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class RefreshRegex
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：刷新列表分类列表名称及格式 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class HashDic
    {
        private string _Name = default(string);
        /// <summary>
        /// 参考值：[Hash1] 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _HashUrl = default(string);
        /// <summary>
        /// 参考值：网页随机值获取页面1 
        /// </summary>
        public string HashUrl
        {
            get { return _HashUrl; }
            set { _HashUrl = value; }
        }

        private string _HashRefer = default(string);
        /// <summary>
        /// 参考值：网页随机值来源页面1 
        /// </summary>
        public string HashRefer
        {
            get { return _HashRefer; }
            set { _HashRefer = value; }
        }

        private string _HashStart = default(string);
        /// <summary>
        /// 参考值：网页随机值随机值前 
        /// </summary>
        public string HashStart
        {
            get { return _HashStart; }
            set { _HashStart = value; }
        }

        private string _HashEnd = default(string);
        /// <summary>
        /// 参考值：网页随机值随机值后 
        /// </summary>
        public string HashEnd
        {
            get { return _HashEnd; }
            set { _HashEnd = value; }
        }

        private string _OnlyOnce = default(string);
        /// <summary>
        /// 参考值：True 
        /// </summary>
        public string OnlyOnce
        {
            get { return _OnlyOnce; }
            set { _OnlyOnce = value; }
        }

    }


    public class ForceEncoding
    {
    }


    public class PostUrl
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：发表地址后缀 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class PostRefer
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：发表页面后缀 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class DataPostType
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：application/x-www-form-urlencoded 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class PostData
    {
        private string _Key = default(string);
        /// <summary>
        /// 参考值：发表表单1 
        /// </summary>
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        private string _Value = default(string);
        /// <summary>
        /// 参考值：发表表单值1 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class PostErrInfo
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：发表错误1 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class PostSuccessInfo
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：发表成功1 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class Memo
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：模块说明
    /// </summary>
    public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class CopyRightInfo
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：版权字符串 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class CopyRightLink
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：http://www.qq.com/ 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class Password
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：我是密码 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class PluginFile
    {
    }


    public class HaveSortId
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：False 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class HaveSortName
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：False 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


    public class HaveGlobalVar
    {
        private string _Value = default(string);
        /// <summary>
        /// 参考值：False 
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }


}
