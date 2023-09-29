using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gac;
using CsharpHttpHelper;
using System.Web;
using System.Text.RegularExpressions;
using GAC_Collection.Common;
using GacDB.Class;

namespace GAC_Collection
{
    public class OutWeb : OutHelper
    {

        ModuleInfo Mi = null;
        ModuleConfigInfo Mci = null;
        ClassModule Cm = null;
        HttpCommon http = new HttpCommon(new HttpRequestInfo());
        public OutWeb(ModuleInfo mi, ModuleConfigInfo mci,ClassModule cm=null)
        {
            this.Mi = mi;
            this.Mci = mci;
            this.Cm = cm;
            http = new HttpCommon(new HttpRequestInfo()
            {
                AcceptLanguage = mci.AcceptLanguage,
                TimeOut = mci.TimeOut,
                UserAgent = mci.UserAgent,
                
            });
            http.InitCookies(mci.Cookies, mci.SiteUrl);
        }


        //public ReturnResult GetRand()
        //{
        //    string imgurl = Mci.SiteUrl + Mi.LoginImgUrl[0];
        //    string referer = "";
        //    if (Mi.LoginRefer.Count>0)
        //    {
        //        referer = Mci.SiteUrl + Mi.LoginRefer[0];
        //    }
        //   HttpResult result=  http.GetHtml(imgurl, referer);
        //}

        /// <summary>
        /// 登陆模块中的网站
        /// </summary>
        /// <param name="Rand">验证码</param>
        /// <returns>登陆成功返回cookies,登陆失败返回源码</returns>
        public ReturnResult Login(string Rand="")
        {
            http.InitCookies(Mci.Cookies, Mci.SiteUrl);

            string loginUrl = Mci.SiteUrl + Mi.LoginUrl;
            string referer = "";
            if (!string.IsNullOrEmpty(Mi.LoginRefer))
            {
                referer = Mci.SiteUrl + Mi.LoginRefer;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in Mi.LoginPost)
            {
                if (sb.Length!=0)
                {
                    sb.Append("&");
                }
                string value = item.Value;
                value = value.Replace("[用户名]", Mci.UserName);
                value = value.Replace("[密码]", Mci.Password);
                value = value.Replace("[验证码]", Rand);
                sb.Append(item.Key + "=" + HttpUtility.UrlEncode(value));
            }
            HttpResult httpresult = http.GetHtml(loginUrl, referer,sb.ToString());

            foreach (var item in Mi.LoginSuccessInfo)
            {
                if (httpresult.Html.Contains(item))
                {
                    return new ReturnResult() {
                        Success = true,
                        Msg = "登陆成功",
                        Obj = http.GetCookies()
                    };
                }

            }

            foreach (var item in Mi.LoginErrInfo)
            {
                if (httpresult.Html.Contains(item))
                {
                    return new ReturnResult()
                    {
                        Success = false,
                        Msg = item,
                        Obj = httpresult.Html
                    };
                }

            }

            foreach (var item in Mi.LoginImgErrInfo)
            {
                if (httpresult.Html.Contains(item))
                {
                    return new ReturnResult()
                    {
                        Success = false,
                        Msg = "验证码错误:"+item,
                        Obj = httpresult.Html
                    };
                }

            }
            return new ReturnResult()
            {
                Success = false,
                Msg = "登陆结果未知",
                Obj = httpresult.Html
            };
        }
        public ReturnResult GetList()
        {
            string RefreshUrl = Mci.SiteUrl + Mi.RefreshUrl;
            string referer = "";
            if (!string.IsNullOrEmpty(Mi.RefreshRefer))
            {
                referer = Mci.SiteUrl + Mi.RefreshRefer;
            }
            HttpResult httpresult = http.GetHtml(RefreshUrl, referer);
            VariableHelper vh = new VariableHelper();

            string result = vh.GetMidStr(Mi.RefreshStart, Mi.RefreshEnd, httpresult.Html);
            if (string.IsNullOrEmpty(result))
            {
                return new ReturnResult()
                {
                    Success = false,
                    Msg = "没有在范围内找到代码",
                    Obj = httpresult.Html
                };
            }
            else
            {
                string regstr =vh.GetRegexStr(  Mi.RefreshRegex).Replace("\\[分类名称\\]", "(?<fname>.*?)").Replace("\\[分类ID\\]", "(?<fid>.*?)");
                Regex reg = new Regex(regstr);
                MatchCollection mcs = reg.Matches(result);
                List<CategoryResult> list = new List<CategoryResult>();
                for (int i = 0; i < mcs.Count; i++)
                {
                    CategoryResult cr = new CategoryResult();
                    if (Mi.RefreshRegex.Contains("[分类名称]"))
                    {
                        cr.Name = mcs[i].Groups["fname"].Value;
                    }
                    if (Mi.RefreshRegex.Contains("[分类ID]"))
                    {
                        cr.ID = mcs[i].Groups["fid"].Value;
                    }
                    list.Add(cr);
                }
                if (list.Count > 0)
                {
                    return new ReturnResult()
                    {
                        Success = true,
                        Msg = "匹配到" + list.Count + "个分类",
                        Obj = list
                    };
                }
                else
                {
                    return new ReturnResult()
                    {
                        Success = false,
                        Msg = "没有匹配到分类",
                        Obj = httpresult.Html
                    };
                }
                
            }
            
        }

        public override ReturnResult Out(Dictionary<string, string> Dic)
        {
            StringBuilder sb = new StringBuilder();
            VariableHelper vh = new VariableHelper();
            foreach (var item in Mi.PostData)
            {
                if (sb.Length>0)
                {
                    sb.Append("&");
                }
                string value = item.Value;
                List<string> listlables = vh.GetLables(value);
                foreach (var item1 in listlables)
                {
                    if (Dic.ContainsKey(item1))
                    {
                        value = value.Replace("[标签:" + item1 + "]", Dic[item1]);
                    }
                    
                }
                //foreach (var item1 in dic)
                //{
                //    List<string> listlables = vh.GetLables(item.Value);
                //}
                sb.Append(item.Key + "=" + HttpHelper.URLEncode(value, Encoding.GetEncoding(Mci.Encoding)));
            }
            string postUrl = Mci.SiteUrl + Mi.PostUrl;
            string referer = "";
            if (!string.IsNullOrEmpty(Mi.PostRefer))
            {
                referer = Mci.SiteUrl + Mi.PostRefer;
            }
            HttpResult httpresult = http.GetHtml(postUrl, referer, sb.ToString());
            StringBuilder sbhead = new StringBuilder();
            if (httpresult.Header.AllKeys!=null)
            {
                foreach (var item in httpresult.Header.AllKeys)
                {
                    sbhead.AppendLine(item + ":" + httpresult.Header[item]);
                }
            }
           
            string result = "网页源代码：\r\n"+httpresult.Html+ "\r\n返回的Header：\r\n"+ sbhead.ToString();
            foreach (var item in Mi.PostSuccessInfo)
            {
                if (httpresult.Html.Contains(item))
                {
                    return new ReturnResult()
                    {
                        Success = true,
                        Msg = "发布成功，成功标识码：" + item,
                        Title =Cm==null?"": "成功发布到站点["+Cm.PostName+"]",
                        Obj = result,
                        Tag= httpresult.Html
                    };
                }

            }

            foreach (var item in Mi.PostErrInfo)
            {
                if (httpresult.Html.Contains(item))
                {
                    return new ReturnResult()
                    {
                        Success = false,
                        Title = Cm == null ? "" : "发布到[" +Cm.PostName+"]失败 - "+item,
                        Msg = item,
                        Obj = result,
                        Tag = httpresult.Html
                    };
                }

            }
            return new ReturnResult()
            {
                Success = false,
                Msg = "发布结果未知",
                Title = Cm == null ? "" : "发布到[" + Cm.PostName + "]结果未知",
                Obj = result,
                Tag = httpresult.Html
            };

        }

    }

}
