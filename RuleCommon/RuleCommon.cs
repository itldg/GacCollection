using System;
using System.Collections.Generic;
using System.Text;
using GacXml;
using Gac;
using StanSoft;
using CsharpHttpHelper;
using System.IO;
using GacApi;
using System.Text.RegularExpressions;
using GAC_Collection;
using System.Threading;
using System.Web;
using HtmlAgilityPack;

namespace Gac
{
    public class Result
    {
        private bool _Success = true;
        private object _ResultObj = null;
        private string _Error = "";
        private string _ErrorStackTrace = "";

        public Result(bool _Success, object _ResultObj, string _Error = "", string _ErrorStackTrace = "")
        {
            this.Success = _Success;
            this.ResultObj = _ResultObj;
            this.Error = _Error;
            this.ErrorStackTrace = _ErrorStackTrace;
        }

        public bool Success
        {
            get
            {
                return _Success;
            }

            set
            {
                _Success = value;
            }
        }

        public object ResultObj
        {
            get
            {
                return _ResultObj;
            }

            set
            {
                _ResultObj = value;
            }
        }

        public string Error
        {
            get
            {
                return _Error;
            }

            set
            {
                _Error = value;
            }
        }

        public string ErrorStackTrace
        {
            get
            {
                return _ErrorStackTrace;
            }

            set
            {
                _ErrorStackTrace = value;
            }
        }
    }
    public class RuleCommon
    {
        public delegate void StatusChangeEvent(string Status);
        public event StatusChangeEvent StatusChange = null;
        public delegate void LogAddEvent(string Log);
        public event LogAddEvent LogAdd = null;

        GacJob Job = null;
        VariableHelper vh = new VariableHelper();
        
        List<string> listLabelNotRepeat;
        Dictionary<string, bool> dicLabelNotNull;
        Dictionary<string, string> dicLabelContentForbid;
        Dictionary<string, string> dicLabelContentMust;
        Dictionary<string, int[]> dicLengthFiltOpertar;
        public HttpRequestInfo RequestInfo = new HttpRequestInfo();
        List<string> ListLables = new List<string>();
        HttpCommon http = null;
        ISpider spider = null;
        public RuleCommon(GacJob Job)
        {
            this.Job = Job;
            this.Job.LoopJoinCode = Job.LoopJoinCode.Replace("[换行]", "\r\n");

            RequestInfo = GetRequestInfo(Job);
            ListLables = GetListLable();


            listLabelNotRepeat = GetLabelNotRepeat();
            dicLabelNotNull = GetLabelNotNull();
            dicLabelContentForbid = GetLabelContentForbid();
            dicLabelContentMust = GetLabelContentMust();
            dicLengthFiltOpertar = GetLengthFiltOpertar();

            http = new HttpCommon(RequestInfo);

            if (!string.IsNullOrEmpty(Job.Plugin))
            {
                spider = AppFactory.CreateSpider(GAC_Collection.Path.PluginDIr+ Job.Plugin+".dll");
                if (spider!=null)
                {
                    if (spider.UseChangeWebRequest)
                    {
                        http.ChangeRequestBefore += Http_ChangeRequestBefore;
                    }

                    if (spider.UseChangeWebResutl)
                    {
                        http.ChangeRequestAfter += Http_ChangeRequestAfter;
                    }
                }
               
            }
        }

        private void Http_ChangeRequestBefore(HttpItem httpItem)
        {
            spider.ChangeWebRequest(httpItem);
        }

        private void Http_ChangeRequestAfter(HttpItem httpItem, HttpResult httpResult)
        {
            spider.ChangeWebResutl(httpResult, httpItem);
        }

        public HttpRequestInfo GetRequestInfo(GacJob Job)
        {
            SuperJob superjob = Job.SuperJobCollection[0];
            HttpRequestInfo requestInfo = new HttpRequestInfo()
            {
                UserAgent = Job.UserAgent,
                Cookies = Job.Cookie,
                Encoding = Job.Encdoing,


                ProxyType = Job.ProxyType,
                ProxyPort = Job.ProxyPort,
                ProxyServer = Job.ProxyServer,
                ProxyUsername = Job.ProxyUsername,
                ProxyPassword = Job.ProxyPassword,

                UseCredentials = Job.UseCredentials,
                CredentialsUserName = Job.CredentialsUserName,
                CredentialsPassword = Job.CredentialsPassword,
                CredentialsDomain = Job.CredentialsDomain,


                TimeOut = superjob.TimeOut,
                AcceptLanguage = superjob.AcceptLanguage,
                AutoDirect = superjob.AutoDirect,
                Deflate = superjob.Deflate,
                Gzip = superjob.Gzip,
                KeepAlive = superjob.KeepAlive
            };
            return requestInfo;
        }


        #region 采集网址
        public delegate void UrlStatusChangeEvent(int Level, string Url, int Page = 0);
        public event UrlStatusChangeEvent UrlStatusChange = null;
        public delegate void ShowUrlsEvent(List<KeyValuePair<string, Dictionary<string, string>>> list, bool IsParent = false);
        public event ShowUrlsEvent ShowUrls = null;
        public delegate void CountChangEvent(Dictionary<int, List<KeyValuePair<string, Dictionary<string, string>>>> Urls);
        public event CountChangEvent CountChang = null;
        public delegate void SpiderFinishEvent();
        public event SpiderFinishEvent SpiderFinish;
        public delegate void SpiderProgresshEvent(int Index, int Count);
        public event SpiderProgresshEvent SpiderProgress;
        public int UrlCountSuccess = 0;
        public int UrlCountRepeat = 0;
        public int UrlCountError = 0;







        private List<KeyValuePair<string, Dictionary<string, string>>> GetUrls(string Html)
        {
            List<KeyValuePair<string, Dictionary<string, string>>> list = new List<KeyValuePair<string, Dictionary<string, string>>>();
            Regex reg = new Regex("<a[\\s\\S]*?href=[\"'](.*?)[\"'][\\s\\S]*?>");
            MatchCollection mcs = reg.Matches(Html);
            for (int i = 0; i < mcs.Count; i++)
            {
                if (!mcs[i].Groups[1].Value.StartsWith("#") && !mcs[i].Groups[1].Value.ToLower().StartsWith("javascript:"))
                {
                    //list.Add(new SpiderUrlResult(mcs[i].Groups[1].Value));
                    list.Add(new KeyValuePair<string, Dictionary<string, string>>(mcs[i].Groups[1].Value, new Dictionary<string, string>()));
                }
            }
            return list;
        }
        private List<KeyValuePair<string, Dictionary<string, string>>> GetSpiderUrlResult(List<string> ListUrl, string Index = "")
        {
            List<KeyValuePair<string, Dictionary<string, string>>>  list = new List<KeyValuePair<string, Dictionary<string, string>>>();
            foreach (var item in ListUrl)
            {
                list.Add(new KeyValuePair<string, Dictionary<string, string>>(item, new Dictionary<string, string>()));
            }
            return list;
        }
        bool Spider = true;
        Thread thSpider;
        public void Start(bool TestOne = false)
        {
            Spider = true;
            thSpider = new Thread(delegate ()
            {

                Dictionary<int, List<KeyValuePair<string, Dictionary<string, string>>>> dicurl = new Dictionary<int, List<KeyValuePair<string, Dictionary<string, string>>>>();
                UrlCommon url = new UrlCommon();
                dicurl.Add(0, new List<KeyValuePair<string, Dictionary<string, string>>>());
                List<StepAddress> listStepAddress = Job.StepAddressCollection;
                //循环生成起始网址
                for (int i = 0; i < Job.StartAddress.Count; i++)
                {
                    List<string> listtemp = url.GetUrlList(Job.StartAddress[i].ToString());
                    List<KeyValuePair<string, Dictionary<string, string>>> list = GetSpiderUrlResult(listtemp);
                    ConsoleUrls(list, listStepAddress.Count > 0);
                    foreach (var item in list)
                    {
                        dicurl[0].Add(item);
                    }
                    //for (int i2 = 0; i2 < listtemp.Count; i2++)
                    //{
                    //    dicurl[0].Add(new Urlinfo(listtemp[i2],i2.ToString()));
                    //}
                }


                bool testone = TestOne;
                for (int i2 = 0; i2 < listStepAddress.Count; i2++)
                {
                    bool IsParent = listStepAddress.Count > i2 + 1;
                    if (!Spider)
                    {
                        return;
                    }
                    //List<TreeNode> listnode = new List<TreeNode>();

                    dicurl.Add(i2 + 1, new List<KeyValuePair<string, Dictionary<string, string>>>());
                    for (int i = 0; i < dicurl[i2].Count; i++)
                    {
                        if (SpiderProgress != null)
                        {
                            SpiderProgress(i + 1, dicurl[i2].Count);
                        }
                        if (!Spider)
                        {
                            return;
                        }
                        string currenturl = dicurl[i2][i].Key;

                        //当前层的第几个网址
                        string index = (dicurl[i2][i].Value.ContainsKey("GAC当前层级")?dicurl[i2][i].Value["GAC当前层级"] :"")+ "," + i;
                        Dictionary<string, string> Parameter = new Dictionary<string, string>();
                        SetUrlStatus(0, currenturl);
                        string nexturl = "";
                        StepAddress stepAddress = listStepAddress[i2];
                        Console.WriteLine(currenturl);
                        List<KeyValuePair<string, Dictionary<string, string>>> list = null;
                        if (stepAddress.HttpMethod == 1)
                        {
                            list = GetUrl(currenturl, stepAddress, ref Parameter, ref nexturl);
                        }
                        else
                        {
                            list = GetUrl(currenturl, stepAddress, ref Parameter, ref nexturl);
                        }
                        for (int l = 0; l < list.Count; l++)
                        {
                            if (list[l].Value.ContainsKey("GAC当前层级"))
                            {
                                 list[l].Value["GAC当前层级"] = index;
                            }
                            else
                            {
                                list[l].Value.Add("GAC当前层级", index);
                            }
                            foreach (var item in dicurl[i2][i].Value)
                            {
                                if (item.Key!= "GAC当前层级")
                                {
                                    list[l].Value[item.Key] = item.Value;
                                }
                            }
                            //dicurl[i2 + 1].Add(list[l]);
                        }
                        if (string.IsNullOrEmpty(nexturl))
                        {
                            if (spider != null && spider.UseChangeStepUrls)
                            {
                                spider.ChangeStepUrls(list);
                            }
                            AddUrl(dicurl[i2 + 1], list);
                            ConsoleUrls(list, IsParent);
                            SetStatus(dicurl);
                        }
                        else
                        {

                            string pageindex = "";
                            if (stepAddress.HttpMethod == 1)
                            {
                                pageindex = " [" + stepAddress.PostStart + "]";
                            }

                            List<KeyValuePair<string, Dictionary<string, string>>> listParent = new List<KeyValuePair<string, Dictionary<string, string>>>();

                            KeyValuePair<string, Dictionary<string, string>> sur = new KeyValuePair<string, Dictionary<string, string>>(currenturl, new Dictionary<string, string>());
                            sur.Value.Add("GAC当前层级", index);
                            sur.Value.Add("GAC提示文本", currenturl + pageindex);
                            //SpiderUrlResult sur = new SpiderUrlResult(currenturl, index);
                            listParent.Add(sur);
                            ConsoleUrls(listParent, true);
                            foreach (var item in list)
                            {
                                if (item.Value.ContainsKey("GAC当前层级"))
                                {
                                    item.Value["GAC当前层级"] = index + ",0";
                                }
                                else
                                {
                                    item.Value.Add("GAC当前层级", index + ",0");
                                }
                                //item.Value["GAC当前层级"] = index + ",0";
                            }
                            if (spider != null && spider.UseChangeStepUrls)
                            {
                                spider.ChangeStepUrls(list);
                            }
                            ConsoleUrls(list, IsParent);
                            AddUrl(dicurl[i2 + 1], list);
                            SetStatus(dicurl);

                        }
                        while (!string.IsNullOrEmpty(nexturl) && !testone)
                        {
                            if (!Spider)
                            {
                                return;
                            }
                            string pageindex = "";
                            int pagenum = 0;
                            string currenturlTemp = currenturl;
                            if (Parameter.ContainsKey("[分页]"))
                            {
                                pagenum = Convert.ToInt32(Parameter["[分页]"]);
                                pageindex = " [" + Parameter["[分页]"] + "]";
                            }
                            else if (Parameter.ContainsKey("上次页码"))
                            {
                                pagenum = Convert.ToInt32(Parameter["上次页码"]);
                                pageindex = " [" + Parameter["上次页码"] + "]";
                                currenturlTemp = nexturl;
                            }
                            SetUrlStatus(i2 + 1, currenturlTemp, pagenum);
                            Console.WriteLine(currenturlTemp + pageindex);
                            nexturl = "";
                            list = GetUrl(currenturlTemp, stepAddress, ref Parameter, ref nexturl);

                            List<KeyValuePair<string, Dictionary<string, string>>> listParent = new List<KeyValuePair<string, Dictionary<string, string>>>();
                            //SpiderUrlResult sur = new SpiderUrlResult(currenturlTemp, index);
                            //sur.Text = currenturlTemp + pageindex;

                            KeyValuePair<string, Dictionary<string, string>> sur = new KeyValuePair<string, Dictionary<string, string>>(currenturl, new Dictionary<string, string>());
                            sur.Value.Add("GAC当前层级", index);
                            sur.Value.Add("GAC提示文本", currenturl + pageindex);

                            listParent.Add(sur);
                            ConsoleUrls(listParent, true);
                            foreach (var item in list)
                            {
                                item.Value.Add("GAC当前层级", index + ","+ pagenum);
                                // item.Value["GAC当前层级"] = index + "," + pagenum;
                            }
                            if (spider!=null&&spider.UseChangeStepUrls)
                            {
                                spider.ChangeStepUrls(list);
                            }
                            ConsoleUrls(list, IsParent);
                            AddUrl(dicurl[i2 + 1], list);
                            SetStatus(dicurl);

                        }
                        if (testone)
                        {
                            break;
                        }
                    }
                }
                if (SpiderFinish != null)
                {
                    SpiderFinish();
                }

            });
            thSpider.Start();


            //if (listStepAddress.Count == 0)
            //{


            //    for (int i = 0; i < dicurl[0].Count; i++)
            //    {
            //        List<SpiderUrlResult> list = new List<SpiderUrlResult>();
            //        string currenturl = dicurl[0][i].Url;
            //        this.Invoke((MethodInvoker)delegate ()
            //        {
            //            TreeNode node = tvUrlRule.Nodes.Add(currenturl);
            //            node.Name = currenturl;
            //            dicurl[0][i].Node = node;
            //            node.ToolTipText = currenturl;
            //            //SetStatus(dicurl);
            //        });

            //        list.Add(new SpiderUrlResult(currenturl));
            //        ConsoleUrls(list, dicurl[0], dicurl[0][i].Node);
            //        SetStatus(dicurl);
            //    }

            //}

        }
        public void Stop()
        {
            Spider = false;
            if (thSpider != null)
            {
                thSpider.Abort();
            }



        }
        private void AddUrl(List<KeyValuePair<string, Dictionary<string, string>>> dic, List<KeyValuePair<string, Dictionary<string, string>>> list)
        {
            foreach (var item in list)
            {
                dic.Add(item);
            }
        }
        private void SetStatus(Dictionary<int, List<KeyValuePair<string, Dictionary<string, string>>>> Dic)
        {
            if (CountChang != null)
            {
                CountChang(Dic);
            }
        }
        private void SetUrlStatus(int Level, string Url, int Page = 0)
        {
            if (UrlStatusChange != null)
            {
                UrlStatusChange(Level, Url, Page);
            }
        }
        private void ConsoleUrls(List<KeyValuePair<string, Dictionary<string, string>>> list, bool IsParent = false)
        {
            if (ShowUrls != null && Spider)
            {
                ShowUrls(list, IsParent);
            }
        }
        public List<KeyValuePair<string, Dictionary<string, string>>> GetUrl(string url, StepAddress stepAddress, ref Dictionary<string, string> Parameter, ref string NextUrl)
        {
            string res = "";
            HttpCommon http = new HttpCommon(RequestInfo); ;
            List<KeyValuePair<string, Dictionary<string, string>>> list = new List<KeyValuePair<string, Dictionary<string, string>>>();
            if (stepAddress.HttpMethod == 0 || (stepAddress.HttpMethod == 1 && Parameter.Count == 0))
            {

                res = http.GetHtml(url).Html;

            }
            else if (stepAddress.HttpMethod == 1)
            {
                string postdata = stepAddress.PostData;
                foreach (var item in Parameter)
                {
                    postdata = postdata.Replace(item.Key, HttpUtility.UrlEncode(item.Value, RequestInfo.Encoding != "自动识别" ? Encoding.GetEncoding(RequestInfo.Encoding) : Encoding.Default));
                }
                res = http.GetHtml(url, postdata).Html;
            }
            if (!string.IsNullOrEmpty(res))
            {
                VariableHelper vh = new VariableHelper();
                if (!string.IsNullOrEmpty(stepAddress.UrlAreaStart) && !string.IsNullOrEmpty(stepAddress.UrlAreaEnd))
                {
                    res = RegGetStr(res, stepAddress.UrlAreaStart, stepAddress.UrlAreaEnd);
                }

                if (stepAddress.GetUrlType == 0)
                {
                    list = GetUrls(res);
                }
                else if (stepAddress.GetUrlType == 1)
                {
                    string ManualUrlStyle = vh.GetRegexStr(stepAddress.ManualUrlStyle, true, true);
                    string ManualUrlCompile = stepAddress.ManualUrlCompile;
                    list = MatchesValue(ManualUrlStyle, ManualUrlCompile, res, true);
                }
                else if (stepAddress.GetUrlType == 2)
                {

                    list = new List<KeyValuePair<string, Dictionary<string, string>>>();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(res);
                    HtmlNode node = doc.DocumentNode;
                    HtmlNodeCollection hnc = node.SelectNodes(stepAddress.XpathContent);
                    if (hnc != null && hnc.Count > 0)
                    {
                        for (int i = 0; i < hnc.Count; i++)
                        {
                            string value = hnc[i].GetAttributeValue("Href", "");
                            value = vh.FormAturl(url, value);
                            list.Add(new KeyValuePair<string, Dictionary<string, string>>(value, new Dictionary<string, string>()));
                        }
                    }
                }
                string[] UrlMust = stepAddress.UrlMust.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string[] UrlForbid = stepAddress.UrlForbid.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < list.Count; i++)
                {
                    if (!list[i].Key.StartsWith("http://") && !list[i].Key.StartsWith("https://"))
                    {
                        //list[i].Key = vh.FormAturl(url, list[i].Key);
                        string urltemp = vh.FormAturl(url, list[i].Key); 
                        list[i]=new KeyValuePair<string, Dictionary<string, string>>(urltemp, list[i].Value);
                    }
                }
                for (int i = 0; i < UrlMust.Length; i++)
                {
                    UrlMust[i] = vh.GetRegexStr(UrlMust[i], false);
                }
                for (int i = 0; i < UrlForbid.Length; i++)
                {
                    UrlForbid[i] = vh.GetRegexStr(UrlForbid[i], false);
                }
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    for (int i2 = 0; i2 < UrlMust.Length; i2++)
                    {

                        if (!RegTest(list[i].Key, UrlMust[i2]))
                        {
                            list.RemoveAt(i);

                            break;
                        }

                    }
                }
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    for (int i2 = 0; i2 < UrlForbid.Length; i2++)
                    {

                        if (RegTest(list[i].Key, UrlForbid[i2]))
                        {
                            list.RemoveAt(i);

                            break;
                        }
                    }
                }

                if (stepAddress.HttpMethod == 1)
                {
                    int pageindex = 0;
                    if (Parameter.ContainsKey("[分页]"))
                    {
                        pageindex = Convert.ToInt32(Parameter["[分页]"]);
                    }
                    else
                    {
                        pageindex = Convert.ToInt32(stepAddress.PostStart);
                    }
                    pageindex++;
                    Parameter.Clear();

                    for (int i = 0; i < stepAddress.PostHashDicCollection.Count; i++)
                    {
                        string tempvalue = RegGetStr(res, stepAddress.PostHashDicCollection[i].Key, stepAddress.PostHashDicCollection[i].Value);
                        Parameter.Add(stepAddress.PostHashDicCollection[i].Name, tempvalue);
                    }
                    Parameter.Add("[分页]", pageindex.ToString());
                    if (pageindex <= stepAddress.PostEnd)
                    {
                        NextUrl = url;
                    }
                }

                if (!string.IsNullOrEmpty(stepAddress.AddLabel))
                {
                    string reg = vh.GetRegexStr(stepAddress.AddLabel, false, true);
                    Dictionary<string, string> dic = vh.MatchLableValue(reg, res);
                    foreach (var item in dic)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (!list[i].Value.ContainsKey(item.Key))
                            {
                                list[i].Value.Add(item.Key, item.Value);
                            }
                        }
                    }



                }



                if (!string.IsNullOrEmpty(stepAddress.PagesAreaStart) && !string.IsNullOrEmpty(stepAddress.PagesAreaEnd))
                {
                    int beforepagenum = 0;
                    if (Parameter.ContainsKey("上次页码"))
                    {
                        beforepagenum = Convert.ToInt32(Parameter["上次页码"]);
                    }
                    beforepagenum++;
                    if (stepAddress.PagesMax == 0 || stepAddress.PagesMax >= beforepagenum)
                    {
                        string PagesAreaStart = vh.GetRegexStr(stepAddress.PagesAreaStart);
                        string PagesAreaEnd = vh.GetRegexStr(stepAddress.PagesAreaEnd);
                        string pagearea = RegGetStr(res, PagesAreaStart, PagesAreaEnd);
                        if (!string.IsNullOrEmpty(pagearea))
                        {

                            List<KeyValuePair<string, Dictionary<string, string>>> pageurl = new List<KeyValuePair<string, Dictionary<string, string>>>();
                            if (!string.IsNullOrEmpty(stepAddress.PagesUrlStyle) || !string.IsNullOrEmpty(stepAddress.PagesUrlCompile))
                            {
                                string PagesUrlStyle = vh.GetRegexStr(stepAddress.PagesUrlStyle, true, false);
                                string PagesUrlCompile = stepAddress.PagesUrlCompile;
                                pageurl = MatchesValue(PagesUrlStyle, PagesUrlCompile, res);

                            }
                            if (stepAddress.AutoPages && pageurl.Count <= 0)
                            {
                                pageurl = GetUrls(pagearea);

                            }
                            if (pagearea.Length > 0)
                            {
                                if (Parameter.ContainsKey("上次页码"))
                                {
                                    Parameter["上次页码"] = beforepagenum.ToString();
                                }
                                else
                                {
                                    Parameter.Add("上次页码", beforepagenum.ToString());
                                }
                                NextUrl = pageurl[0].Key;
                            }
                        }
                    }

                }
            }






            return list;



        }
        //private List<SpiderUrlResult> MatchesValue(string RegStr, string MatchStr, string Input, ref List<Dictionary<string, string>> Lables)
        //{
        //    List<SpiderUrlResult> list = new List<SpiderUrlResult>();
        //    VariableHelper vh = new VariableHelper();
        //    List<string> listurl= vh.MatchesValue(RegStr, MatchStr, Input, ref Lables);
        //    for (int i = 0; i < listurl.Count; i++)
        //    {
        //        list.Add(new SpiderUrlResult(listurl[i], Lables[i]));
        //    }
        //    return list;
        //}
        private List<KeyValuePair<string, Dictionary<string, string>>> MatchesValue(string RegStr, string MatchStr, string Input, bool ContainsLables = false)
        {
            List<KeyValuePair<string, Dictionary<string, string>>> list = new List<KeyValuePair<string, Dictionary<string, string>>>();
            VariableHelper vh = new VariableHelper();
            if (ContainsLables)
            {
                List<Dictionary<string, string>> Lables = new List<Dictionary<string, string>>();
                List<string> listurl = vh.MatchesValue(RegStr, MatchStr, Input, ref Lables);
                for (int i = 0; i < listurl.Count; i++)
                {
                    if (Lables.Count > i)
                    {
                        
                        list.Add(new KeyValuePair<string, Dictionary<string, string>>(listurl[i], Lables[i]));
                    }
                    else
                    {
                        list.Add(new KeyValuePair<string, Dictionary<string, string>>(listurl[i], new Dictionary<string, string>()));
                    }

                }
                return list;
            }
            else
            {
                List<string> listurl = vh.MatchesValue(RegStr, MatchStr, Input);
                for (int i = 0; i < listurl.Count; i++)
                {
                    
                    list.Add(new KeyValuePair<string, Dictionary<string, string>>(listurl[i], new Dictionary<string, string>()));
                }
                return list;
            }
        }
        public bool RegTest(string str, string reg)
        {
            Regex regex = new Regex(reg);
            Match match = regex.Match(str);
            return match.Success;
        }
        public string RegGetStr(string str, string reg = "([\\s\\S]*?)")
        {
            Regex regex = new Regex(reg);
            Match match = regex.Match(str);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return "";
        }
        public string RegGetStr(string str, string strLeft, string strRight)
        {
            strLeft = strLeft.Replace("(*)", ".*?");
            strRight = strRight.Replace("(*)", ".*?");
            return RegGetStr(str, strLeft + "([\\s\\S]*?)" + strRight);
        }//取文本中间
        public string GetStr(string str, string strLeft, string strRight)
        {
            int i = -1, i2 = -1;
            i = str.IndexOf(strLeft, 0);
            if (i != -1)
            {
                i += strLeft.Length;
                i2 = str.IndexOf(strRight, i);
                if (i2 != -1)
                {
                    return str.Substring(i, i2 - i);
                }
                else
                {
                    return str.Substring(i);
                }
            }
            else
            {
                return "";
            }
        }//取文本中间
        public string GetRight(string str, string s)
        {
            try
            {
                string temp = str.Substring(str.IndexOf(s) + s.Length, str.Length - str.Substring(0, str.IndexOf(s) + s.Length).Length);
                return temp;
            }
            catch (Exception)
            {

                return "";
            }

        }//取文本右边
        public string GetLeft(string str, string s)
        {
            try
            {
                string temp = str.Substring(0, str.IndexOf(s));
                return temp;
            }
            catch (Exception)
            {

                return "";
            }

        }//取文本左边
        #endregion





























        #region 分析内容
        public Result GetResult(HttpResult http, Dictionary<string, LableMerge> dic, Rule rule)
        {
            try
            {
                List<string> list = new List<string>();
                string result = "";
                LableCommon lc = new LableCommon();
                if (rule.DataSpider)
                {
                    string code = "";
                    if (rule.DataFromUrl)
                    {
                        code = http.item.URL;
                    }
                    else
                    {
                        code = http.Html;
                    }
                    List<string> templist = new List<string>();
                    switch (rule.GetDataType)
                    {

                        case 0: templist = lc.GetStr(code, rule.StartStr, rule.EndStr, rule.LabelInCircle); break;//前后截取
                        case 1: templist = lc.GetRegex(code, rule.RegexContent, rule.RegexCombine, rule.LabelInCircle); break;//正则提取
                        case 2: templist = lc.GetXpath(code, rule.XpathContent, rule.XPathAttribue); break;//可视化提取
                        case 3: templist = lc.GetMergeContent(rule.MergeContent, dic); break;//标签组合
                        case 4:

                            Html2Article html2article = new Html2Article();
                            //Html2Article.LimitCount = 100;
                            //Html2Article.Depth = 8;

                            // 设置是否使用正文追加模式
                            html2article.AppendMode = !rule.TextRecognitionNewsTrueBBsFalse;
                            // 将Html解析为Article结构化数据
                            Article article = html2article.GetArticle(http.Html);


                            if (rule.TextRecognitionType == 0)
                            {
                                templist.Add(article.Title);
                            }
                            else if (rule.TextRecognitionType == 1)
                            {
                                //this.contentTextBox.Text = article.Content; 不带标签的

                                string articleHtml = UrlUtility.FixUrl(http.item.URL, article.ContentWithTags);
                                templist.Add(articleHtml);
                            }
                            else if (rule.TextRecognitionType == 2)
                            {
                                templist.Add(article.PublishDate.ToString());
                            }
                            break;//正文提取
                        default:
                            //  type = "未知类型" + rule.GetDataType;
                            break;
                    }
                    if (templist.Count == 0)
                    {
                        templist.Add("");
                    }
                    foreach (var item in templist)
                    {
                        list.Add(item);
                    }
                }
                else
                {


                    switch (rule.ManualType)
                    {
                        case 1: result = lc.GetManualFromDate(rule.ManualTimeStr); break;//系统时间
                        case 2:; result = lc.GetManualRadomString(rule.ManualRadomStringLib, rule.ManualRadomStringNum); break;//随机字符
                        case 3: result = lc.GetManualRadomNum(rule.ManualRadomNumStart, rule.ManualRadomNumEnd); break;//随机数字
                        case 5: result = lc.GetManualUnixTime(); break;//时间戳
                        case 4: result = lc.GetManualRadomString(rule.ManualRadomString); break;//随机抽取
                        default:
                            result = rule.ManualString;//固定字符
                            break;
                    }
                    list.Add(result);


                }
                return new Result(true, list);
            }
            catch (Exception ex)
            {

                return new Result(false, null, ex.Message, ex.StackTrace);
            }



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentUrl">采集当前网址</param>
        /// <param name="CurrentUrl">当前网址附带的列表标签</param>
        public List<LableMergeInfo> GetResult(string CurrentUrl, Dictionary<string, string> dicListLable)
        {
            Dictionary<string, HttpResult> dichtml = new Dictionary<string, HttpResult>();
            string plugin = "";
            if (spider!=null&&spider.UseChangeWebRequest)
            {
                plugin = "插件";
            }
          

            string pagenamedefulat = "默认页";
            SetStaus(pagenamedefulat, CurrentUrl);
            AddLog(plugin+"请求页面 " + pagenamedefulat + " " + CurrentUrl + "\r\n");
            List<MultPages> listMultPages = Job.SuperJobCollection[0].MultPagesCollection;
            HttpResult httpresult = http.GetHtml(CurrentUrl);
            if (!http.CheckResult(httpresult))
            {
                AddLog("获取网页内容失败，重试中请求页面 " + pagenamedefulat + " " + CurrentUrl + " " + httpresult.StatusDescription + "\r\n原因：" + httpresult.Html + "\r\n");
                SetStaus(pagenamedefulat, CurrentUrl, "获取网页内容失败，重试中请求页面");
                httpresult = http.GetHtml(CurrentUrl);
            }
            if (http.CheckResult(httpresult))
            {
                dichtml.Add(pagenamedefulat, httpresult);
            }
            else
            {
                AddLog(plugin + "请求失败 " + pagenamedefulat + " " + CurrentUrl + "\r\n原因：" + httpresult.Html + "\r\n");
                dichtml.Add("默认页", httpresult);
            }


            if (listMultPages != null)
            {
                

                for (int i = 0; i < listMultPages.Count; i++)
                {
                    try
                    {
                        string MultPageUrl = vh.GetMultUrl(CurrentUrl, listMultPages[i].MultPageCollection[0], RequestInfo);
                        string pagename = listMultPages[i].SuperJobCollection[0].PageName;
                        SetStaus(pagename, MultPageUrl);
                        AddLog(plugin + "请求页面 " + pagename + " " + MultPageUrl + "\r\n");

                        http = new HttpCommon(RequestInfo);
                        httpresult = http.GetHtml(MultPageUrl);
                        if (!http.CheckResult(httpresult))
                        {
                            AddLog("获取网页内容失败，重试中请求页面 " + pagename + " " + MultPageUrl + " " + httpresult.StatusDescription + "\r\n原因：" + httpresult.Html + "\r\n");
                            SetStaus(pagename, MultPageUrl, "获取网页内容失败，重试中请求页面");
                            httpresult = http.GetHtml(MultPageUrl);
                        }
                        dichtml.Add(pagename, httpresult);
                        if (!http.CheckResult(httpresult))
                        {
                            AddLog(plugin + "请求失败 " + pagename + " " + MultPageUrl + " " + httpresult.StatusDescription + "\r\n");
                        }


                    }
                    catch (Exception ex)
                    {
                        AddLog("获取多页出错 " + listMultPages[i].SuperJobCollection[0].PageName + " " + ex.Message + "\r\n");
                    }
                }
            }



            LableCommon lc = new LableCommon();
            SetStatus("正在处理标签，请稍后");
            AddLog("\r\n\r\n");
            List<string> listlable = new List<string>();
            Dictionary<string, LableMerge> diclable = new Dictionary<string, LableMerge>();
            FilterCommon fc = new FilterCommon();
            List<Rule> listrule = GetRules(Job);
            Dictionary<string, string> dicDownUrl = new Dictionary<string, string>();
            Dictionary<string, Rule> dicNeedDown = new Dictionary<string, Rule>();
            bool HaveLabelInCircle = false;
            int InCircleMaxCount = 0;
            for (int i = 0; i < listrule.Count; i++)
            {
                GacXml.Rule rule = listrule[i];
                listlable.Add(rule.LabelName);
                StringBuilder sbresult = new StringBuilder();
                List<string> listLable = new List<string>();
                ////循环标签 每个标签一个列表
                //List<List<DownInfo>> listLableDown = new List<List<DownInfo>>();
                ////循环标签全部标签一个列表
                //List<DownInfo> listLableDownAll = new List<DownInfo>();
                
                

                string pagename = GetPageName(rule.LabelName);
                HttpResult hi = dichtml[pagename];
                Result result = null;
                if (ListLables.Contains(rule.LabelName) && dicListLable.ContainsKey(rule.LabelName))
                {
                    List<string> listListLable = new List<string>();
                    listListLable.Add(dicListLable[rule.LabelName]);
                    result = new Result(true, listListLable);
                }
                else
                {
                    result = GetResult(hi, diclable, rule);
                }


                List<Dictionary<string, KeyValuePair<string, string>>> listdown = new List<Dictionary<string, KeyValuePair<string, string>>>();
                if (result.Success == true)
                {
                    //标签分析到的结果
                    listLable = (List<string>)result.ResultObj;
                    for (int i2 = 0; i2 < listLable.Count; i2++)
                    {
                        //List<DownInfo> listDown = new List<DownInfo>();
                        //下载地址  <保存地址,替换地址>
                        Dictionary<string, KeyValuePair<string, string>> dicdown = new Dictionary<string, KeyValuePair<string, string>>();
                        string lable = "";
                        try
                        {
                            lable = fc.GetFilterResult(rule.FiltersCollection, listLable[i2], hi);
                        }
                        catch (Exception ex)
                        {

                            lable = "[发生错误]:" + ex.Message;
#if DEBUG
                            lable += "\r\n[错误细节]:" + ex.StackTrace;
#endif
                        }
                        //补全绝对网址
                        if (rule.FillRelativeUrl)
                        {
                            lable = vh.FixUrl(dichtml[pagename].item.URL, lable);
                        }

                        //探测真实地址 勾选探测并下载或者探测地址时启用
                        if (rule.DownloadOtherFile || rule.OnlyFetchValidUrl)
                        {
                            List<string> ListDownUrl = vh.GetLinks(lable);
                            for (int filei = ListDownUrl.Count - 1; filei >= 0; filei--)
                            {
                                string oldurl = ListDownUrl[filei];
                                string newurl = oldurl;
                                if (!dicDownUrl.ContainsKey(newurl))
                                {

                                    http.GetLastUrl(ref newurl);
                                    ListDownUrl[filei] = newurl;
                                    dicDownUrl.Add(oldurl, newurl);
                                    lable = lable.Replace(oldurl, newurl);
                                }
                                else
                                {
                                    ListDownUrl.RemoveAt(filei);
                                }

                            }
                        }
                        //下载文件 勾选探测并下载或者下载图片时启用
                        if (rule.DownloadOtherFile || rule.DownloadImage)
                        {
                            if (!dicNeedDown.ContainsKey(rule.LabelName))
                            {
                                dicNeedDown.Add(rule.LabelName, rule);
                            }
                            List<string> listNewUrl = vh.GetLinks(lable, !rule.DownloadOtherFile);
                            
                            foreach (var newurl in listNewUrl)
                            {
                                //string oldurl = GetOldUrl(dicDownUrl, newurl);

                                //DownInfo downinfo = new DownInfo() { ContentId = 0, PageUrl = dichtml[pagename].item.URL, PreUrl = oldurl, TrueUrl = newurl, Type = rule.LabelName };
                                //listDown.Add(downinfo);
                                //循环标签 全部使用一个下载列表
                                //listLableDownAll.Add(downinfo);
                                dicdown.Add(newurl,new KeyValuePair<string, string>());
                            }
                            
                        }
                        //每个标签都添加两份下载列表
                        //循环标签 每个标签额外一个下载列表
                        //listLableDown.Add(listDown);
                        listdown.Add(dicdown);




                        //循环获取
                        if (rule.LabelInCircle)
                        {
                            HaveLabelInCircle = true;
                            sbresult.Append(lable + Job.LoopJoinCode);
                        }

                        else
                        {
                            sbresult.Append(lable);
                            break;
                        }

                    }

                }
                if (listLable.Count > InCircleMaxCount)
                {
                    InCircleMaxCount = listLable.Count;
                }
                diclable.Add(rule.LabelName, new LableMerge() { Name = rule.LabelName, Result = sbresult.ToString(), ResultList = listLable,ListDown= listdown});//, DownFileList = listLableDown, DownFileAll = listLableDownAll



            }

            List<LableMergeInfo> listLmi = new List<LableMergeInfo>();
             //List<List<LableMerge>> listResult = new List<List<LableMerge>>();

             
            if ((Job.LoopAddNewRecord && HaveLabelInCircle))
            {

                for (int i = 0; i < InCircleMaxCount; i++)
                {
                    LableMergeInfo lmi = new LableMergeInfo();
                    List<LableMerge> list = new List<LableMerge>();
                    foreach (var item in diclable)
                    {
                        string value = "";
                        if (item.Value.ResultList.Count > i)
                        {
                            value = item.Value.ResultList[i];
                        }
                        else
                        {
                            if (Job.FillLoopWithFirst && item.Value.ResultList.Count > 0)
                            {
                                value = item.Value.ResultList[0];
                            }
                        }
                        lmi.Dic.Add(item.Key, value);
                        if (item.Value.ListDown.Count >=i)
                        {
                            lmi.Downfile.Add(item.Key, item.Value.ListDown[i]);
                        }
                        //list.Add(new LableMerge() { Name = item.Key, Result = value, DownFileList = item.Value.DownFileList, DownFileAll = item.Value.DownFileList[i] });
                        //AddLog(System.Environment.NewLine + "【" + item.Key + "】：" + value);
                        //ShowDown(item.Value.DownFileList);
                    }
                    if (spider != null)
                    {
                        spider.ChangeResultDic(lmi.Dic);
                        if (lmi.Downfile.Count > 0 & spider.UseChangeSaveFiles)
                        {
                            spider.ChangeSaveFiles(lmi.Downfile, lmi.Dic);
                        }
                    }
                    //listResult.Add(list);
                    listLmi.Add(lmi);
                    //AddLog(System.Environment.NewLine + string.Format("███████████████第{0}条记录████████████████", i + 1));

                }
            }
            else
            {
                LableMergeInfo lmi = new LableMergeInfo();
                List<LableMerge> list = new List<LableMerge>();
                foreach (var item in diclable)
                {
                    string value = item.Value.Result;
                    //AddLog(System.Environment.NewLine + "【" + item.Key + "】：" + value);
                    //list.Add(new LableMerge() { Name = item.Key, Result = value, DownFileList = item.Value.DownFileList, DownFileAll = item.Value.DownFileAll });
                    lmi.Dic.Add(item.Key, value);
                    if (item.Value.ListDown.Count>0)
                    {
                        lmi.Downfile.Add(item.Key, item.Value.ListDown[0]);
                    }
                }
                if (spider != null)
                {
                    spider.ChangeResultDic(lmi.Dic);
                    if (lmi.Downfile.Count > 0 & spider.UseChangeSaveFiles)
                    {
                        spider.ChangeSaveFiles(lmi.Downfile, lmi.Dic);
                    }
                }
                //listResult.Add(list);
                listLmi.Add(lmi);
            }

            //foreach (var list in listResult)
            //{
            //    foreach (var lable in list)
            //    {
            //        for (int i = 0; i < lable.DownFileAll.Count; i++)
            //        {
            //            string saveDirFormat = dicNeedDown[lable.Name].FileSaveDir;
            //            string saveFileFormat = dicNeedDown[lable.Name].FileSaveFormat;
            //            lable.DownFileAll[i].SaveUrl = lc.GetDirName(lable.DownFileAll[i].TrueUrl, saveDirFormat, 0, Job.JobName, list);
            //            lable.DownFileAll[i].ReplaceUrl = lc.GetFileName(lable.DownFileAll[i].TrueUrl, saveFileFormat, 0, Job.JobName, list);
            //        }
            //    }
            //    list.Add(new LableMerge() { Name = "PageUrl", Result = CurrentUrl });
            //}
            //return listResult;
            //foreach (var list in listLmi)
            //{
            //    foreach (var lable in list.Downfile)
            //    {
            //        if (lable.Value.Count > 0)
            //        {
            //            string saveDirFormat = dicNeedDown[lable.Key].FileSaveDir;
            //            string saveFileFormat = dicNeedDown[lable.Key].FileSaveFormat;

            //            Dictionary<string, KeyValuePair<string, string>> dictemp = new Dictionary<string, KeyValuePair<string, string>>();
            //            foreach (var down in lable.Value)
            //            {
            //                string SaveUrl = lc.GetDirName(down.Key, saveDirFormat, 0, Job.JobName, list);
            //                string ReplaceUrl = lc.GetFileName(down.Key, saveFileFormat, 0, Job.JobName, list); ;
            //                //lable.Value[down.Key] = new KeyValuePair<string, string>(SaveUrl, ReplaceUrl);
            //                dictemp.Add(down.Key, new KeyValuePair<string, string>(SaveUrl, ReplaceUrl));
            //            }
            //            list[lable.Key] = dictemp;
            //        }

            //    }
            //}
            for (int i = 0; i < listLmi.Count; i++)
            {
                var lmi = listLmi[i];
                foreach (var lablename in lmi.Downfile.Keys)
                {
                    var lable = lmi.Downfile[lablename];
                    if (lable.Count>0)
                    {
                        string saveDirFormat = dicNeedDown[lablename].FileSaveDir;
                        string saveFileFormat = dicNeedDown[lablename].FileSaveFormat;

                        List<string> listdownurl= new List<string>(lable.Keys);
                        foreach (var downurl in listdownurl)
                        {
                            string SaveUrl = lc.GetDirName(downurl, saveDirFormat, 0, Job.JobName, lmi);
                            string ReplaceUrl = lc.GetFileName(downurl, saveFileFormat, 0, Job.JobName, lmi); ;
                            listLmi[i].Downfile[lablename][downurl] = new KeyValuePair<string, string>(SaveUrl, ReplaceUrl);
                        }
                    }
                }
                if (spider!=null&&spider.UseChangeSaveFiles)
                {
                    spider.ChangeSaveFiles(lmi.Downfile, lmi.Dic);
                }

            }
            return listLmi;
        }
        #endregion

        #region 内容过滤

        public List<string> GetListLable()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < Job.ListLabelCollection.Count; i++)
            {
                if (Job.ListLabelCollection[i].RuleCollection == null)
                {
                    break;
                }
                for (int i2 = 0; i2 < Job.ListLabelCollection[i].RuleCollection.Count; i2++)
                {
                    GacXml.Rule rule = Job.ListLabelCollection[i].RuleCollection[i2];
                    list.Add(rule.LabelName);
                }
            }
            return list;
        }
        /// <summary>
        /// 检测是否包含指定关键字
        /// </summary>
        /// <param name="value">要检测的内容</param>
        /// <param name="key">检测规则</param>
        /// <param name="Must">是否检测必须包含</param>
        /// <returns>返回关键字</returns>
        private string CheckContains(string value, string key, bool Must)
        {
            string[] result;
            if (key.Contains("↑"))//必须全部包含
            {
                result = key.Split('↑');
                string contains = "";
                foreach (var item in result)
                {
                    if (!value.Contains(item))
                    {
                        contains = item;
                        break;
                    }
                }
                if (Must)
                {
                    return contains;
                }
                else
                {
                    return "";
                }

            }
            else
            {
                result = key.Split('|');
                foreach (var item in result)
                {
                    if (value.Contains(item))
                    {
                        if (Must)
                        {
                            return "";
                        }
                        else
                        {
                            return item;
                        }

                    }
                }
            }
            //按说不会有这个情况
            return "";
        }
        public string CheckResult(LableMergeInfo lmi)
        {
            foreach (var item in lmi.Dic)
            {
                if (dicLabelNotNull.ContainsKey(item.Key) && string.IsNullOrEmpty(item.Value))
                {
                    return "【" + item.Key + "】标签不符合需求，内容不得为空";
                }
                if (dicLabelContentMust.ContainsKey(item.Key))
                {
                    string result = CheckContains(item.Value, dicLabelContentMust[item.Key], true);
                    if (!string.IsNullOrEmpty(result))
                    {
                        return "【" + item.Key + "】标签不符合需求，必须包含【" + result + "】";
                    }
                }

                if (dicLabelContentForbid.ContainsKey(item.Key))
                {
                    string result = CheckContains(item.Value, dicLabelContentForbid[item.Key], false);
                    if (!string.IsNullOrEmpty(result))
                    {
                        return "【" + item.Key + "】标签不符合需求，不得包含【" + result + "】";
                    }
                }

                if (dicLengthFiltOpertar.ContainsKey(item.Key))
                {
                    ///// 1 大于 
                    ///// 2 小于
                    ///// 3 等于
                    ///// 4 不等于
                    int[] LengthFiltOpertar = dicLengthFiltOpertar[item.Key];
                    int length = LengthFiltOpertar[1];
                    //item.Result
                    switch (LengthFiltOpertar[0])
                    {
                        case 1:
                            if (item.Value.Length > length)
                            {
                                return "【" + item.Key + "】标签不符合需求，长度大于" + length;
                            }
                            break;
                        case 2:
                            if (item.Value.Length < length)
                            {
                                return "【" + item.Key + "】标签长度不符合需求，小于" + length;
                            }
                            break;
                        case 3:
                            if (item.Value.Length == length)
                            {
                                return "【" + item.Key + "】标签不符合需求，长度等于" + length;
                            }
                            break;
                        case 4:
                            if (item.Value.Length != length)
                            {
                                return "【" + item.Key + "】标签不符合需求，长度不等于" + length;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            return "ok";
        }
        /// <summary>
        /// 获取标签不得重复
        /// </summary>
        /// <returns></returns>
        public List<string> GetLabelNotRepeat()
        {
            List<Rule> listRule = GetRules(Job);
            List<string> list = new List<string>();
            foreach (var item in listRule)
            {
                if (item.LabelNotRepeat)
                {
                    list.Add(item.LabelName);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取标签不得为空
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> GetLabelNotNull()
        {
            List<Rule> listRule = GetRules(Job);
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            foreach (var item in listRule)
            {
                if (item.LabelNotNull)
                {
                    dic.Add(item.LabelName, false);
                }
            }
            return dic;
        }
        /// <summary>
        /// 获取不得包含
        /// </summary>
        /// <returns>标签名和不得包含</returns>
        public Dictionary<string, string> GetLabelContentForbid()
        {
            List<Rule> listRule = GetRules(Job);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in listRule)
            {
                if (!string.IsNullOrEmpty(item.LabelContentForbid))
                {
                    dic.Add(item.LabelName, item.LabelContentForbid);
                }
            }
            return dic;
        }
        /// <summary>
        ///获取必须包含
        /// </summary>
        /// <returns>标签名和必须包含内容</returns>
        public Dictionary<string, string> GetLabelContentMust()
        {
            List<Rule> listRule = GetRules(Job);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in listRule)
            {
                if (!string.IsNullOrEmpty(item.LabelContentMust))
                {
                    dic.Add(item.LabelName, item.LabelContentMust);
                }
            }
            return dic;
        }

        /// <summary>
        ///获取长度判断
        /// </summary>
        /// <returns>返回标签名 和判断条件数组 0是判断类型 1是长度</returns>
        public Dictionary<string, int[]> GetLengthFiltOpertar()
        {
            List<Rule> listRule = GetRules(Job);
            Dictionary<string, int[]> dic = new Dictionary<string, int[]>();
            foreach (var item in listRule)
            {
                if (item.LengthFiltOpertar > 0)
                {
                    dic.Add(item.LabelName, new int[] { item.LengthFiltOpertar, item.LengthFiltValue });
                }
            }
            return dic;
        }
#endregion

        private List<Rule> GetRules(GacJob Job)
        {
            List<Rule> list = new List<Rule>();
            foreach (var item in Job.SortLabel)
            {
                for (int i = 0; i < Job.SuperJobCollection[0].RuleCollection.Count; i++)
                {
                    Rule rule = Job.SuperJobCollection[0].RuleCollection[i];
                    if (rule.LabelName == item)
                    {
                        list.Add(rule);
                    }
                }
                if (Job.ListLabelCollection.Count > 0)
                {
                    for (int i = 0; i < Job.ListLabelCollection[0].RuleCollection.Count; i++)
                    {
                        Rule rule = Job.ListLabelCollection[0].RuleCollection[i];
                        if (rule.LabelName == item)
                        {
                            list.Add(rule);
                        }
                    }
                }

            }
            return list;
        }

        private string GetOldUrl(Dictionary<string, string> Dic, string NewUrl)
        {
            foreach (var item in Dic)
            {
                if (item.Value == NewUrl)
                {
                    return item.Key;
                }
            }
            return "旧地址丢失";
        }
        private string GetPageName(string LableName)
        {
            foreach (var item in Job.SuperJobCollection[0].RuleCollection)
            {
                if (LableName == item.LabelName)
                {
                    return Job.SuperJobCollection[0].PageName;
                }
            }

            if (Job.SuperJobCollection[0].MultPagesCollection.Count > 0)
            {
                foreach (var page in Job.SuperJobCollection[0].MultPagesCollection)
                {
                    foreach (var item in page.SuperJobCollection[0].RuleCollection)
                    {
                        if (LableName == item.LabelName)
                        {
                            return page.MultPageCollection[0].PageName;
                        }
                    }

                }
            }

            return "默认页";
        }
        private void SetStatus(string Status)
        {
            if (StatusChange != null)
            {
                StatusChange(Status);
            }
            else
            {
                Console.WriteLine("[RULE] 状态改变：" + Status);
            }
        }
        private void AddLog(string Log)
        {
            if (LogAdd != null)
            {
                LogAdd(Log);
            }
            else
            {
                //Console.WriteLine("[RULE] 新增日志：" + Log);
            }
        }
        private void SetStaus(string PageName, string PageUrl, string MessageType = "请求页面")
        {
            SetStatus(MessageType + "\t  " + PageName + "\r\n" + PageUrl);
        }

    }
}
