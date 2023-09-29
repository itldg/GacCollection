
using CsharpHttpHelper;
using CsharpHttpHelper.Enum;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Gac
{
    public class HttpInfo
    {
        private string _Name = "";
        private string _Url = "";
        private WebHeaderCollection _RequestHeader = new WebHeaderCollection();
        private WebHeaderCollection _ResponseHeader = new WebHeaderCollection();
        private string _Html="";
        private bool _IsSuccess = false;
        private string _StatusDescription = "";
        //private 
        /// <summary>
        /// 网址
        /// </summary>
        public string Url
        {
            get
            {
                return _Url;
            }

            set
            {
                _Url = value;
            }
        }

        /// <summary>
        /// 发起请求 Head
        /// </summary>
        public WebHeaderCollection RequestHeader
        {
            get
            {
                return _RequestHeader;
            }

            set
            {
                _RequestHeader = value;
            }
        }

        /// <summary>
        /// 请求结果 Head
        /// </summary>
        public WebHeaderCollection ResponseHeader
        {
            get
            {
                return _ResponseHeader;
            }

            set
            {
                _ResponseHeader = value;
            }
        }

        /// <summary>
        /// Html代码
        /// </summary>
        public string Html
        {
            get
            {
                return _Html;
            }

            set
            {
                _Html = value;
            }
        }

        public bool IsSuccess
        {
            get
            {
                return _IsSuccess;
            }

            set
            {
                _IsSuccess = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public string StatusDescription
        {
            get
            {
                return _StatusDescription;
            }

            set
            {
                _StatusDescription = value;
            }
        }
    }
    public class HttpCommon
    {
        HttpRequestInfo RequestInfo = null;
        HttpHelper http = new HttpHelper();
        public CookieCollection cookies = new CookieCollection();
        // public HttpWebRequest httprequest = null;
        //private string _UserAgent = "";
        //private string _Cookies = "";
        //private string _Encoding = "";
        //public HttpCommon(string UserAgent, string Cookies,string Encoding,int ProxyType=0,string ProxyServer="", int ProxyPort=0,string ProxyUsername="",string ProxyPassword="",)
        //{
        //    this._UserAgent = UserAgent;
        //    this._Cookies = Cookies;
        //    this._Encoding = Encoding;
        //}
        /// <summary>
        /// 请求发起之前处理事件,可修改请求参数
        /// </summary>
        /// <param name="httpItem">请求信息</param>
        public delegate void ChangeRequestBeforeEvent(HttpItem httpItem);
        /// <summary>
        /// 请求发起之前处理事件,可修改请求参数
        /// </summary>
        public event ChangeRequestBeforeEvent ChangeRequestBefore = null;
        /// <summary>
        /// 请求发起之后处理事件,处理请求后结果
        /// </summary>
        /// <param name="httpItem">请求信息</param>
        /// <param name="httpResult">请求结果</param>
        public delegate void ChangeRequestAfterEvent(HttpItem httpItem,HttpResult httpResult);
        /// <summary>
        /// 请求发起之后处理事件,处理请求后结果
        /// </summary>
        public event ChangeRequestAfterEvent ChangeRequestAfter = null;

        public HttpCommon(HttpRequestInfo requestInfo)
        {
            this.RequestInfo = requestInfo;
        }
        //public void GetHttp(string Url, string PostData = null)
        //{
        //    HttpItem item = GetItem(PostData);
        //    item.URL = Url;
        //    if (ChangeRequestBefore!=null)
        //    {
        //        ChangeRequestBefore(item);
        //    }
        //    HttpResult result = http.GetHtml(item);
        //    if (ChangeRequestAfter!=null)
        //    {
        //        ChangeRequestAfter(item,result);
        //    }
            

        //    //HttpResult result=http.GetHtml(httpItem)
        //    //try
        //    //{
        //    //    //准备参数
        //    //    http.SetRequest(item);
        //    //    HttpRequest = http.request;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}

        //}
        public HttpItem GetItem(string referer = null,string PostData = null)
        {
            HttpItem item = new HttpItem();
            //item.URL = Url;
            if (PostData != null)
            {
                item.Method = "Post";
                item.Postdata = PostData;
                item.ContentType = "application/x-www-form-urlencoded";

            }
            if (referer != null)
            {
                item.Referer = referer;
            }
            item.UserAgent = RequestInfo.UserAgent;
            

            //item.Cookie = RequestInfo.Cookies;

            item.Timeout = RequestInfo.TimeOut*1000;
            item.Accept = RequestInfo.AcceptLanguage;
            item.Allowautoredirect = RequestInfo.AutoDirect;
            item.IsGzip = RequestInfo.Gzip;
            item.KeepAlive = RequestInfo.KeepAlive;
            

            if (!string.IsNullOrEmpty(RequestInfo.Encoding) && RequestInfo.Encoding != "自动识别")
            {
                item.Encoding = Encoding.GetEncoding(RequestInfo.Encoding);
            }
            if (RequestInfo.ProxyType == 0)
            {
                item.ProxyIp = "ieproxy";

            } else if (RequestInfo.ProxyType == 2)
            {
                //item.ProxyIp = RequestInfo.ProxyServer;
                //item.pr
                //item.ProxyUserName = RequestInfo.ProxyUsername;
                //item.ProxyPwd = RequestInfo.ProxyPassword;
                WebProxy webproxy = new WebProxy(RequestInfo.ProxyServer, RequestInfo.ProxyPort);
                if (!string.IsNullOrEmpty(RequestInfo.ProxyUsername) || !string.IsNullOrEmpty(RequestInfo.ProxyPassword))
                {
                    webproxy.Credentials = new NetworkCredential(RequestInfo.ProxyUsername, RequestInfo.ProxyPassword);
                }
                item.WebProxy = webproxy;

            }
            if (RequestInfo.UseCredentials)
            {
                item.ICredentials = new NetworkCredential(RequestInfo.CredentialsUserName, RequestInfo.ProxyPassword, RequestInfo.CredentialsDomain);
            }


            return item;
        }
        //public void GetHead(string Url, ref HttpWebRequest HttpRequest)
        //{

        //    HttpItem item = new HttpItem();
        //    item.URL = Url;
        //    item.Method = "Head";
        //    item.UserAgent = _UserAgent;
        //    item.Cookie = _Cookies;
        //    try
        //    {
        //        //准备参数
        //        http.SetRequest(item);
        //        HttpRequest = http.request;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        public String FormAturl(String objurl, string urlX)
        {
            try
            {
                Uri baseUri = new Uri(objurl); // http://www.enet.com.cn/enews/inforcenter/designmore.jsp
                Uri absoluteUri = new Uri(baseUri, urlX);//相对绝对路径都在这里转 这里的urlx ="../test.html"
                return absoluteUri.ToString();//   http://www.enet.com.cn/enews/test.html   
            }
            catch (Exception)
            {
                return urlX;
            }

        }
        public void GetLastUrl(ref string url)
        {
            HttpItem item = GetItem(url);
            item.Method = "HEAD";
            HttpResult result = http.GetHtml(item);
            if (CheckResult(result))
            {
                if (string.IsNullOrEmpty(result.RedirectUrl))
                {
                    url = FormAturl(url, result.RedirectUrl);
                    GetLastUrl(ref url);
                }
                for (int i = 0; i < result.Header.AllKeys.Length; i++)
                {
                    string key = result.Header.AllKeys[i];
                    if (key == "Location")
                    {
                        url = FormAturl(url, result.Header[key]);
                        GetLastUrl(ref url);
                    }
                }
            }
            //HttpWebRequest Request = null;
            //GetHead(url,ref Request);
            //HttpInfo httpinfo= GetHtml(Request);
            //if (httpinfo.IsSuccess)
            //{
            //    for (int i = 0; i < httpinfo.ResponseHeader.AllKeys.Length; i++)
            //    {
            //        string key = httpinfo.ResponseHeader.AllKeys[i];
            //        if (key == "Location")
            //        {
            //            url = FormAturl(url, httpinfo.ResponseHeader[key]);
            //            GetLastUrl(ref url);
            //        }
            //    }
            //}
        }
        public void InitCookies(string setcookies, string url)
        {
            try
            {
                Uri uri = new Uri(url);
                string domain = uri.Host;
                cookies = new CookieCollection();
                string[] cookie = setcookies.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < cookie.Length; i++)
                {
                    string cookiestr = cookie[i].Trim();
                    if (!string.IsNullOrEmpty(cookiestr))
                    {
                        Cookie cookietemp = GetCookieFromString(cookiestr, domain);
                        cookies.Add(cookietemp);
                    }

                    //string[] c = cookie[i].Split(new string[] { "=" },StringSplitOptions.RemoveEmptyEntries);
                    //cookiesInit.Add(new Cookie() { Name = c[0], Value = c[1],Domain= domain });

                }
            }
            catch (Exception ex)
            {

            }
           
        }
        private Cookie GetCookieFromString(string cookieString, string defaultDomain)
        {
            if (cookieString == null || defaultDomain == null) return null;
            string[] ary = cookieString.Split(',');
            Hashtable hs = new Hashtable();
            for (int i = 0; i < ary.Length; i++)
            {
                string s = ary[i].Trim();
                int index = s.IndexOf("=", System.StringComparison.Ordinal);
                if (index > 0)
                {
                    hs.Add(s.Substring(0, index), s.Substring(index + 1));
                }
            }
            Cookie ck = new Cookie();
            foreach (object key in hs.Keys)
            {
                if (key.ToString() == "path") ck.Path = hs[key].ToString();

                else if (key.ToString() == "expires")
                {
                    //ck.Expires=DateTime.Parse(hs[Key].ToString();
                }
                else if (key.ToString() == "domain") ck.Domain = hs[key].ToString();
                else
                {
                    ck.Name = key.ToString();
                    ck.Value = hs[key].ToString();
                }
            }
            if (ck.Name == "") return null;
            if (ck.Domain == "") ck.Domain = defaultDomain;
            return ck;
        }
        public string GetCookies()
        {
            string strcookie = HttpHelper.CookieCollectionToStrCookie(cookies);
            return strcookie;
        }
        //public void ImageCheck(ref List<string> Links)
        //{
        //    for (int i = Links.Count - 1; i >= 0; i--)
        //    {
        //        bool isimage = CheckImgType(Links[i]);
        //        if (!isimage)
        //        {
        //            Uri uri = new Uri(Links[i]);
        //            if (!uri.PathAndQuery.Contains("."))
        //            {
        //                string imageurl = Links[i];
        //                isimage = CheckImageUrl(ref imageurl);
        //                if (isimage)
        //                {
        //                    Links[i] = imageurl;
        //                }
        //            }
        //        }
        //        if (!isimage)
        //        {
        //            Links.RemoveAt(i);
        //        }
        //    }

        //}
        //public void ImageCheck(ref List<DownInfo> Links)
        //{
        //    for (int i = Links.Count - 1; i >= 0; i--)
        //    {
        //        bool isimage = CheckImgType(Links[i].TrueUrl);
        //        if (!isimage)
        //        {
        //            Uri uri = new Uri(Links[i].TrueUrl);
        //            if (!uri.PathAndQuery.Contains("."))
        //            {
        //                string imageurl = Links[i].TrueUrl;
        //                isimage = CheckImageUrl(ref imageurl);
        //                if (isimage)
        //                {
        //                    Links[i].TrueUrl = imageurl;
        //                }
        //            }
        //        }
        //        if (!isimage)
        //        {
        //            Links.RemoveAt(i);
        //        }
        //    }

        //}
        public  bool CheckImgType(string strImg)
        {
            if (!string.IsNullOrEmpty(strImg))
            {
                int i = strImg.LastIndexOf(".");
                string StrType = strImg.Substring(i);
                if (StrType == ".jpg" || StrType == ".gif" || StrType == ".jpeg" || StrType == ".png")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //public bool CheckImageUrl(ref string url)
        //{
        //    HttpWebRequest Request = null;
        //    GetHead(url, ref Request);
        //    HttpInfo httpinfo = GetHtml(Request);
        //    if (httpinfo.IsSuccess)
        //    {
        //        for (int i = 0; i < httpinfo.ResponseHeader.AllKeys.Length; i++)
        //        {
        //            string key = httpinfo.ResponseHeader.AllKeys[i];
        //            if (key == "Location")
        //            {

        //                url = FormAturl(url, httpinfo.ResponseHeader[key]);
        //                return CheckImageUrl(ref url);
        //            }
        //        }
        //        for (int i = 0; i < httpinfo.ResponseHeader.AllKeys.Length; i++)
        //        {
        //            string key = httpinfo.ResponseHeader.AllKeys[i];
        //            if (key == "Content-Type")
        //            {
        //               string Content= httpinfo.ResponseHeader[key];
        //                return Content.StartsWith("image");
        //            }
        //        }
        //    }
        //    return false;
        //}
        public HttpResult GetHtml(string Url,string referer=null, string PostData = null)
        {
            HttpItem item = GetItem(referer,PostData);
            item.URL = Url;
            if (ChangeRequestBefore != null)
            {
                ChangeRequestBefore(item);
            }
            item.CookieCollection = cookies;
            item.ResultCookieType = ResultCookieType.CookieCollection; ;
            HttpResult result = http.GetHtml(item);
            cookies = UpdateCookie(cookies, result.CookieCollection);
            result.Html= result.Html.Replace("\r\n", "\n");
            if (ChangeRequestAfter != null)
            {
                ChangeRequestAfter(item, result);
            }
            return result;
        }
        public CookieCollection UpdateCookie(CookieCollection OldCookie, CookieCollection NewCookie)
        {
            if (NewCookie != null)
            {
                for (int i = 0; i < NewCookie.Count; i++)
                {
                    int index = CheckCookie(OldCookie, NewCookie[i].Name);
                    if (index >= 0)
                    {
                        OldCookie[index].Value = NewCookie[i].Value;
                    }
                    else
                    {
                        OldCookie.Add(NewCookie[i]);
                    }
                }
            }

            return OldCookie;
        }
        private int CheckCookie(CookieCollection Cookie, string Name)
        {
            for (int i = 0; i < Cookie.Count; i++)
            {
                if (Cookie[i].Name == Name)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool CheckResult(HttpResult result)
        {
            bool IsSuccess = ((int)result.StatusCode >= 200 && (int)result.StatusCode < 400);
            return IsSuccess;
        }

        //public string GetHtml(string Url)
        //{
        //    HttpHelper http = new HttpHelper();
        //    HttpItem item = new HttpItem();
        //    item.URL = Url;
        //    item.UserAgent = _UserAgent;
        //    item.Cookie = _Cookies;
        //    HttpResult result = http.GetHtml(item);

        //    return result.Html;
        //}


        //public string GetHtml(string Url, string PostData=null)
        //{
           
        //    HttpItem item = new HttpItem();
        //    item.URL = Url;
        //    if (PostData!=null)
        //    {
        //        item.Method = "Post";
        //        item.Postdata = PostData;
        //        item.ContentType = "application/x-www-form-urlencoded";
        //    }
        //    if (_Encoding != "自动识别")
        //    {
        //        item.Encoding = Encoding.GetEncoding(_Encoding);
        //    }
        //    item.UserAgent = _UserAgent;
        //    item.Cookie = _Cookies;
        //    HttpResult result = http.GetHtml(item);
        //    return result.Html;
        //}
    }

    public class HttpRequestInfo
    {
        private string _UserAgent = "";
        private string _Cookies = "";
        private string _Encoding = "";

        private int _ProxyType = 0;
        private string _ProxyServer = "";
        private int _ProxyPort = 0;
        private string _ProxyUsername = "";
        private string _ProxyPassword = "";

        private bool _UseCredentials = false;
        private string _CredentialsUserName = default(string);
        private string _CredentialsPassword = default(string);
        private string _CredentialsDomain = default(string);


        private Int32 _TimeOut = 30;
        private string _AcceptLanguage = default(string);
        private bool _AutoDirect = default(bool);
        private bool _Deflate = default(bool);
        private bool _Gzip = default(bool);
        private bool _KeepAlive = default(bool);

        /// <summary>
        /// 浏览器 UserAgent
        /// </summary>
        public string UserAgent
        {
            get
            {
                return _UserAgent;
            }

            set
            {
                _UserAgent = value;
            }
        }

        /// <summary>
        /// 请求时附带cookies
        /// </summary>
        public string Cookies
        {
            get
            {
                return _Cookies;
            }

            set
            {
                _Cookies = value;
            }
        }

        /// <summary>
        /// 返回页面编码
        /// </summary>
        public string Encoding
        {
            get
            {
                return _Encoding;
            }

            set
            {
                _Encoding = value;
            }
        }

        /// <summary>
        ///HTTP代理  代理类型
        ///0 使用IE浏览器代理
        ///1 不使用代理
        ///2 使用指定代理
        /// </summary>
        public int ProxyType
        {
            get
            {
                return _ProxyType;
            }

            set
            {
                _ProxyType = value;
            }
        }

        /// <summary>
        /// HTTP代理 IP 参考值：127.0.0.1 
        /// </summary>
        public string ProxyServer
        {
            get
            {
                return _ProxyServer;
            }

            set
            {
                _ProxyServer = value;
            }
        }

        /// <summary>
        /// HTTP代理 代理端口
        /// </summary>
        public int ProxyPort
        {
            get
            {
                return _ProxyPort;
            }

            set
            {
                _ProxyPort = value;
            }
        }
        /// <summary>
        /// HTTP代理 用户名 参考值：username 
        /// </summary>
        public string ProxyUsername
        {
            get
            {
                return _ProxyUsername;
            }

            set
            {
                _ProxyUsername = value;
            }
        }

        /// <summary>
        /// HTTP代理 密码 参考值：password 
        /// </summary>
        public string ProxyPassword
        {
            get
            {
                return _ProxyPassword;
            }

            set
            {
                _ProxyPassword = value;
            }
        }
        /// <summary>
        /// 基于windows身份验证  是否开启
        /// </summary>
        public bool UseCredentials
        {
            get
            {
                return _UseCredentials;
            }

            set
            {
                _UseCredentials = value;
            }
        }
        /// <summary>
        /// 基于windows身份验证 windows用户名 
        /// </summary>
        public string CredentialsUserName
        {
            get
            {
                return _CredentialsUserName;
            }

            set
            {
                _CredentialsUserName = value;
            }
        }
        /// <summary>
        /// 基于windows身份验证 windows密码 
        /// </summary>
        public string CredentialsPassword
        {
            get
            {
                return _CredentialsPassword;
            }

            set
            {
                _CredentialsPassword = value;
            }
        }
        /// <summary>
        /// 基于windows身份验证  windows域 
        /// </summary>
        public string CredentialsDomain
        {
            get
            {
                return _CredentialsDomain;
            }

            set
            {
                _CredentialsDomain = value;
            }
        }
        /// <summary>
        /// Http请求 超时时间 默认30 
        /// </summary>
        public int TimeOut
        {
            get
            {
                return _TimeOut;
            }

            set
            {
                _TimeOut = value;
            }
        }
        /// <summary>
        /// 参考值：zh-cn,zh; 
        /// </summary>
        public string AcceptLanguage
        {
            get
            {
                return _AcceptLanguage;
            }

            set
            {
                _AcceptLanguage = value;
            }
        }
        /// <summary>
        /// Http请求自动跳转
        /// </summary>
        public bool AutoDirect
        {
            get
            {
                return _AutoDirect;
            }

            set
            {
                _AutoDirect = value;
            }
        }

        /// <summary>
        /// Http请求 Deflate
        /// </summary>
        public bool Deflate
        {
            get
            {
                return _Deflate;
            }

            set
            {
                _Deflate = value;
            }
        }

        /// <summary>
        /// Http请求 Gzip压缩
        /// </summary>
        public bool Gzip
        {
            get
            {
                return _Gzip;
            }

            set
            {
                _Gzip = value;
            }
        }

        /// <summary>
        /// Http请求 KeepAlive
        /// </summary>
        public bool KeepAlive
        {
            get
            {
                return _KeepAlive;
            }

            set
            {
                _KeepAlive = value;
            }
        }
    }
}
