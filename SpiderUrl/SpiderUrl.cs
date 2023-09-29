using System;
using System.Collections.Generic;
using System.Text;
using Gac;
using System.Text.RegularExpressions;
using System.Web;
using GacXml;
using HtmlAgilityPack;
using System.Web.UI.WebControls;
using System.Threading;

namespace GAC_Collection
{
    public class SpiderUrlResult
    {
        private string _Text = "";
        private string _Index = "";
        private string _Url = "";
        private Dictionary<string, string> _lable = new Dictionary<string, string>();
        public List<int> ListIndex { get {
                List<int> list = new List<int>();
                string[] strs = Index.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in strs)
                {
                    list.Add(Convert.ToInt32(item));
                }
                return list;
            } }
        public override string ToString()
        {
            return _Url;
        }

        public SpiderUrlResult(string Url, Dictionary<string, string> _lable=null)
        {
            this._Url = Url;
            if(_lable!=null)
            {
                this._lable = _lable;
            }
         
        }
        public SpiderUrlResult(string Url, string Index)
        {
            this._Url = Url;
            this._Index = Index;

        }

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

        public Dictionary<string, string> Lable
        {
            get
            {
                return _lable;
            }

            set
            {
                _lable = value;
            }
        }

        public string Index
        {
            get
            {
                return _Index;
            }

            set
            {
                _Index = value;
            }
        }

        public string Text
        {
            get
            {
                if (string.IsNullOrEmpty(_Text))
                {
                    return _Url;
                }
                return _Text;
            }

            set
            {
                _Text = value;
            }
        }
    }
    public class SpiderUrl
    {
        public delegate void StatusChangeEvent(int Level, string Url, int Page = 0);
        public event StatusChangeEvent StatusChange = null;
        public delegate void ShowUrlsEvent(List<SpiderUrlResult> list,bool IsParent=false);
        public event ShowUrlsEvent ShowUrls = null;
        public delegate void CountChangEvent(Dictionary<int, List<SpiderUrlResult>> Dic);
        public event CountChangEvent CountChang = null;
        public delegate void SpiderFinishEvent();
        public event SpiderFinishEvent SpiderFinish;
        public delegate void SpiderProgresshEvent(int Index,int Count);
        public event SpiderProgresshEvent SpiderProgress;
        public int UrlCountSuccess = 0;
        public int UrlCountRepeat = 0;
        public int UrlCountError = 0;






        GacJob Job = null;
        HttpRequestInfo RequestInfo = null;
        public SpiderUrl(GacJob Job)
        {
            this.Job = Job;
            RuleCommon rm = new RuleCommon(Job);
            RequestInfo = rm.RequestInfo;
        }
        private List<SpiderUrlResult> GetUrls(string Html)
        {
            List<SpiderUrlResult> list = new List<SpiderUrlResult>();
            Regex reg = new Regex("<a[\\s\\S]*?href=[\"'](.*?)[\"'][\\s\\S]*?>");
            MatchCollection mcs = reg.Matches(Html);
            for (int i = 0; i < mcs.Count; i++)
            {
                if (!mcs[i].Groups[1].Value.StartsWith("#") && !mcs[i].Groups[1].Value.ToLower().StartsWith("javascript:"))
                {
                    list.Add(new SpiderUrlResult(mcs[i].Groups[1].Value));
                }
            }
            return list;
        }
        private List<SpiderUrlResult> GetSpiderUrlResult(List<string> ListUrl,string Index="")
        {
            List<SpiderUrlResult> list = new List<SpiderUrlResult>();
            foreach (var item in ListUrl)
            {
                SpiderUrlResult sur = new SpiderUrlResult(item);
                    list.Add(sur);
            }
            return list;
        }
        bool Spider = true;
        Thread thSpider;
        public void Start(bool TestOne=false)
        {
            Spider = true;
            thSpider = new Thread(delegate ()
            {

                Dictionary<int, List<SpiderUrlResult>> dicurl = new Dictionary<int, List<SpiderUrlResult>>();
                UrlCommon url = new UrlCommon();
                dicurl.Add(0, new List<SpiderUrlResult>());
                List<StepAddress> listStepAddress = Job.StepAddressCollection;
                //循环生成起始网址
                for (int i = 0; i < Job.StartAddress.Count; i++)
                {
                    List<string> listtemp = url.GetUrlList(Job.StartAddress[i].ToString());
                    List<SpiderUrlResult> list = GetSpiderUrlResult(listtemp);
                    ConsoleUrls(list, listStepAddress.Count>0);
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
                    if (!Spider)
                    {
                        return;
                    }
                    //List<TreeNode> listnode = new List<TreeNode>();

                    dicurl.Add(i2 + 1, new List<SpiderUrlResult>());
                    for (int i = 0; i < dicurl[i2].Count; i++)
                    {
                        if (SpiderProgress!=null)
                        {
                            SpiderProgress(i + 1, dicurl[i2].Count);
                        }
                        if (!Spider)
                        {
                            return;
                        }
                        string currenturl = dicurl[i2][i].Url;

                        //当前层的第几个网址
                        string index = dicurl[i2][i].Index + "," + i;
                        Dictionary<string, string> Parameter = new Dictionary<string, string>();
                        SetUrlStatus(0, currenturl);
                        string nexturl = "";
                        StepAddress stepAddress = listStepAddress[i2];
                        Console.WriteLine(currenturl);
                        List<SpiderUrlResult> list = null;
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
                            list[l].Index = index;
                            foreach (var item in dicurl[i2][i].Lable)
                            {
                                list[l].Lable.Add(item.Key, item.Value);
                            }
                            //dicurl[i2 + 1].Add(list[l]);
                        }
                        if (string.IsNullOrEmpty(nexturl))
                        {
                            AddUrl(dicurl[i2 + 1], list);
                            ConsoleUrls(list);
                            SetStatus(dicurl);
                        }
                        else
                        {

                            string pageindex = "";
                            if (stepAddress.HttpMethod == 1)
                            {
                                pageindex = " [" + stepAddress.PostStart + "]";
                            }

                            List<SpiderUrlResult> listParent = new List<SpiderUrlResult>();
                            SpiderUrlResult sur = new SpiderUrlResult(currenturl, index);
                            sur.Text = currenturl + pageindex;
                            listParent.Add(sur);
                            ConsoleUrls(listParent,true);
                            foreach (var item in list)
                            {
                                item.Index = index + ",0";
                            }
                            ConsoleUrls(list);
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
                            SetUrlStatus(i2+1, currenturlTemp, pagenum);
                            Console.WriteLine(currenturlTemp + pageindex);
                            nexturl = "";
                            list = GetUrl(currenturlTemp, stepAddress, ref Parameter, ref nexturl);

                            List<SpiderUrlResult> listParent = new List<SpiderUrlResult>();
                            SpiderUrlResult sur = new SpiderUrlResult(currenturlTemp, index);
                            sur.Text = currenturlTemp + pageindex;
                            listParent.Add(sur);
                            ConsoleUrls(listParent,true);
                            foreach (var item in list)
                            {
                                item.Index = index + "," + pagenum;
                            }
                            ConsoleUrls(list);
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
            if (thSpider!=null)
            {
                thSpider.Abort();
            }
            


        }
        private void AddUrl(List<SpiderUrlResult> dic, List<SpiderUrlResult> list)
        {
            foreach (var item in list)
            {
                dic.Add(item);
            }
        }
        private void SetStatus(Dictionary<int, List<SpiderUrlResult>> Dic)
        {
            if (CountChang!=null)
            {
                CountChang(Dic);
            }
        }
        private void SetUrlStatus(int Level, string Url, int Page = 0)
        {
            if (StatusChange!=null)
            {
                StatusChange(Level, Url, Page);
            }
        }
        private void ConsoleUrls(List<SpiderUrlResult> list, bool IsParent = false)
        {
            if (ShowUrls!= null&& Spider)
            {
                ShowUrls(list, IsParent);
            }
        }
        public List<SpiderUrlResult> GetUrl(string url, StepAddress stepAddress,ref Dictionary<string,string> Parameter,ref string NextUrl)
        {
            string res = "";
            HttpCommon http = new HttpCommon(RequestInfo); ;
            List<SpiderUrlResult> list = new List<SpiderUrlResult>();
            if (stepAddress.HttpMethod == 0|| (stepAddress.HttpMethod==1&& Parameter.Count==0))
            {
                
                res = http.GetHtml(url).Html;

            }
            else if (stepAddress.HttpMethod == 1)
            {
                string postdata = stepAddress.PostData;
                foreach (var item in Parameter)
                {
                    postdata = postdata.Replace(item.Key,  HttpUtility.UrlEncode( item.Value, RequestInfo.Encoding!= "自动识别" ? Encoding.GetEncoding(RequestInfo.Encoding) :Encoding.Default));
                }
                res = http.GetHtml(url,postdata).Html;
            }
            if (!string.IsNullOrEmpty(res))
            {
                VariableHelper vh = new VariableHelper();
                if (!string.IsNullOrEmpty(stepAddress.UrlAreaStart)&& !string.IsNullOrEmpty(stepAddress.UrlAreaEnd))
                {
                    res = RegGetStr(res, stepAddress.UrlAreaStart, stepAddress.UrlAreaEnd);
                }

                if (stepAddress.GetUrlType == 0)
                {
                    list = GetUrls(res);
                }
                else if (stepAddress.GetUrlType == 1)
                {
                    string ManualUrlStyle = vh.GetRegexStr(stepAddress.ManualUrlStyle, true,true);
                    string ManualUrlCompile = stepAddress.ManualUrlCompile;
                    list= MatchesValue(ManualUrlStyle, ManualUrlCompile, res,true);
                }
                else if (stepAddress.GetUrlType == 2)
                {

                    list = new List<SpiderUrlResult>();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(res);
                    HtmlNode node = doc.DocumentNode;
                    HtmlNodeCollection hnc = node.SelectNodes(stepAddress.XpathContent);
                    if (hnc!=null&&hnc.Count > 0)
                    {
                        for (int i = 0; i < hnc.Count; i++)
                        {
                            string value = hnc[i].GetAttributeValue("Href", "");
                            value = vh.FormAturl(url, value);
                            list.Add(new SpiderUrlResult(value));
                        }
                    }
                }
                string[] UrlMust = stepAddress.UrlMust.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string[] UrlForbid = stepAddress.UrlForbid.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < list.Count; i++)
                {
                    if (!list[i].Url.StartsWith("http://")&& !list[i].Url.StartsWith("https://"))
                    {
                        list[i].Url = vh.FormAturl(url, list[i].Url);
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

                            if (!RegTest(list[i].Url,UrlMust[i2]))
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
                       
                            if (RegTest(list[i].Url, UrlForbid[i2]))
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
                    if (pageindex<=stepAddress.PostEnd)
                    {
                        NextUrl = url;
                    }
                }

                if (!string.IsNullOrEmpty(stepAddress.AddLabel))
                {
                    string reg = vh.GetRegexStr(stepAddress.AddLabel,false,true);
                    Dictionary<string,string> dic=vh.MatchLableValue(reg,res);
                    foreach (var item in dic)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (!list[i].Lable.ContainsKey(item.Key))
                            {
                                list[i].Lable.Add(item.Key, item.Value);
                            }
                        }
                    }



                }



                if (!string.IsNullOrEmpty(stepAddress.PagesAreaStart) && !string.IsNullOrEmpty(stepAddress.PagesAreaEnd))
                {
                    int beforepagenum = 0;
                    if (Parameter.ContainsKey("上次页码"))
                    {
                        beforepagenum = Convert.ToInt32( Parameter["上次页码"]);
                    }
                    beforepagenum++;
                    if (stepAddress.PagesMax==0|| stepAddress.PagesMax>= beforepagenum)
                    {
                        string PagesAreaStart = vh.GetRegexStr(stepAddress.PagesAreaStart);
                        string PagesAreaEnd = vh.GetRegexStr(stepAddress.PagesAreaEnd);
                        string pagearea = RegGetStr(res, PagesAreaStart, PagesAreaEnd);
                        if (!string.IsNullOrEmpty(pagearea))
                        {

                            List<SpiderUrlResult> pageurl = new List<SpiderUrlResult>();
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
                                NextUrl = pageurl[0].Url;
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
        private List<SpiderUrlResult> MatchesValue(string RegStr, string MatchStr, string Input,bool ContainsLables = false)
        {
            List<SpiderUrlResult> list = new List<SpiderUrlResult>();
            VariableHelper vh = new VariableHelper();
            if (ContainsLables)
            {
                List<Dictionary<string, string>> Lables = new List<Dictionary<string, string>>();
                List<string> listurl = vh.MatchesValue(RegStr, MatchStr, Input, ref Lables);
                for (int i = 0; i < listurl.Count; i++)
                {
                    if (Lables.Count > i)
                    {
                        list.Add(new SpiderUrlResult(listurl[i], Lables[i]));
                    }
                    else
                    {
                        list.Add(new SpiderUrlResult(listurl[i]));
                    }
                   
                }
                return list;
            }
            else
            { 
                List<string> listurl = vh.MatchesValue(RegStr, MatchStr, Input);
                for (int i = 0; i < listurl.Count; i++)
                {
                    list.Add(new SpiderUrlResult(listurl[i]));
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
        public string RegGetStr(string str, string reg="([\\s\\S]*?)")
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
    }
    public class Urlinfo
    {
        private string _Url = "";
        private string _Index = "";
        private TreeNode _node = null;
        private Dictionary<string, string> _lable = new Dictionary<string, string>();

        //public Urlinfo(string _url, TreeNode _node = null)
        //{
        //    this._url = _url;
        //    if (_node != null)
        //    {
        //        this._node = _node;
        //    }

        //}

        public Urlinfo(string _url, TreeNode _node = null, Dictionary<string, string> _lable = null)
        {
            this.Url = _url;
            if (_node != null)
            {
                this._node = _node;
            }
            if (_lable != null)
            {
                this._lable = _lable;
            }
        }
        public Urlinfo(string URL, string Index)
        {
            this._Url = URL;
            this.Index = Index;
        }
        public override string ToString()
        {
            return Url;
        }
        public Dictionary<string, string> Lable
        {
            get
            {
                return _lable;
            }

            set
            {
                _lable = value;
            }
        }
      
        public TreeNode Node
        {
            get
            {
                return _node;
            }

            set
            {
                _node = value;
            }
        }

        public string Index
        {
            get
            {
                return _Index;
            }

            set
            {
                _Index = value;
            }
        }

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
    }
}
