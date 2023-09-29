using System;
using System.Xml;
using System.Collections.Generic;
namespace Gac
{

    public class ModuleInfo
    {
        private List<string> _CmsVersion = new List<string>();
        /// <summary>
        /// 参考值：版本号 
        /// </summary>
        public List<string> CmsVersion
        {
            get { return _CmsVersion; }
            set { _CmsVersion = value; }
        }

        private List<string> _CmsName = new List<string>();
        /// <summary>
        /// 参考值：系统名称 
        /// </summary>
        public List<string> CmsName
        {
            get { return _CmsName; }
            set { _CmsName = value; }
        }

        private List<string> _LoginUrl = new List<string>();
        /// <summary>
        /// 参考值：登陆地址后缀 
        /// </summary>
        public List<string> LoginUrl
        {
            get { return _LoginUrl; }
            set { _LoginUrl = value; }
        }

        private List<string> _LoginRefer = new List<string>();
        /// <summary>
        /// 参考值：登陆来源后缀 
        /// </summary>
        public List<string> LoginRefer
        {
            get { return _LoginRefer; }
            set { _LoginRefer = value; }
        }

        private List<string> _LoginImgUrl = new List<string>();
        /// <summary>
        /// 参考值：登陆验证码地址 
        /// </summary>
        public List<string> LoginImgUrl
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

        private List<string> _LoginSuccessInfo = new List<string>();
        /// <summary>
        /// 参考值：登录成功标志1 
        /// </summary>
        public List<string> LoginSuccessInfo
        {
            get { return _LoginSuccessInfo; }
            set { _LoginSuccessInfo = value; }
        }

        private List<string> _LoginImgErrInfo = new List<string>();
        /// <summary>
        /// 参考值：验证码失败标志1 
        /// </summary>
        public List<string> LoginImgErrInfo
        {
            get { return _LoginImgErrInfo; }
            set { _LoginImgErrInfo = value; }
        }

        private List<LoginPost> _LoginPostCollection = new List<LoginPost>();
        public List<LoginPost> LoginPostCollection
        {
            get { return _LoginPostCollection; }
            set { _LoginPostCollection = value; }
        }

        private List<string> _RefreshUrl = new List<string>();
        /// <summary>
        /// 参考值：刷新列表页面 
        /// </summary>
        public List<string> RefreshUrl
        {
            get { return _RefreshUrl; }
            set { _RefreshUrl = value; }
        }

        private List<string> _RefreshRefer = new List<string>();
        /// <summary>
        /// 参考值：刷新列表页面后缀 
        /// </summary>
        public List<string> RefreshRefer
        {
            get { return _RefreshRefer; }
            set { _RefreshRefer = value; }
        }

        private List<string> _RefreshStart = new List<string>();
        /// <summary>
        /// 参考值：刷新列表页面区域开始 
        /// </summary>
        public List<string> RefreshStart
        {
            get { return _RefreshStart; }
            set { _RefreshStart = value; }
        }

        private List<string> _RefreshEnd = new List<string>();
        /// <summary>
        /// 参考值：刷新列表页面区域结束 
        /// </summary>
        public List<string> RefreshEnd
        {
            get { return _RefreshEnd; }
            set { _RefreshEnd = value; }
        }

        private List<string> _RefreshRegex = new List<string>();
        /// <summary>
        /// 参考值：刷新列表分类列表名称及格式 
        /// </summary>
        public List<string> RefreshRegex
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

        private List<string> _PostUrl = new List<string>();
        /// <summary>
        /// 参考值：发表地址后缀 
        /// </summary>
        public List<string> PostUrl
        {
            get { return _PostUrl; }
            set { _PostUrl = value; }
        }

        private List<string> _PostRefer = new List<string>();
        /// <summary>
        /// 参考值：发表页面后缀 
        /// </summary>
        public List<string> PostRefer
        {
            get { return _PostRefer; }
            set { _PostRefer = value; }
        }

        private List<string> _DataPostType = new List<string>();
        /// <summary>
        /// 参考值：application/x-www-form-urlencoded 
        /// </summary>
        public List<string> DataPostType
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

        private List<string> _PostErrInfo = new List<string>();
        /// <summary>
        /// 参考值：发表错误1 
        /// </summary>
        public List<string> PostErrInfo
        {
            get { return _PostErrInfo; }
            set { _PostErrInfo = value; }
        }

        private List<string> _PostSuccessInfo = new List<string>();
        /// <summary>
        /// 参考值：发表成功1 
        /// </summary>
        public List<string> PostSuccessInfo
        {
            get { return _PostSuccessInfo; }
            set { _PostSuccessInfo = value; }
        }

        private List<string> _Memo = new List<string>();
        /// <summary>
        /// 参考值：模块说明
    /// </summary>
    public List<string> Memo
        {
            get { return _Memo; }
            set { _Memo = value; }
        }

        private List<string> _CopyRightInfo = new List<string>();
        /// <summary>
        /// 参考值：版权字符串 
        /// </summary>
        public List<string> CopyRightInfo
        {
            get { return _CopyRightInfo; }
            set { _CopyRightInfo = value; }
        }

        private List<string> _CopyRightLink = new List<string>();
        /// <summary>
        /// 参考值：http://www.qq.com/ 
        /// </summary>
        public List<string> CopyRightLink
        {
            get {
                return _CopyRightLink;
            }
            set { _CopyRightLink = value; }
        }

        private List<string> _Password = new List<string>();
        /// <summary>
        /// 参考值：我是密码 
        /// </summary>
        public List<string> Password
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

        private List<string> _HaveSortId = new List<string>();
        /// <summary>
        /// 参考值：False 
        /// </summary>
        public List<string> HaveSortId
        {
            get { return _HaveSortId; }
            set { _HaveSortId = value; }
        }

        private List<string> _HaveSortName = new List<string>();
        /// <summary>
        /// 参考值：False 
        /// </summary>
        public List<string> HaveSortName
        {
            get { return _HaveSortName; }
            set { _HaveSortName = value; }
        }

        private List<string> _HaveGlobalVar = new List<string>();
        /// <summary>
        /// 参考值：False 
        /// </summary>
        public List<string> HaveGlobalVar
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
