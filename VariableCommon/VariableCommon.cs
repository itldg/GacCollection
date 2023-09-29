using CsharpHttpHelper;
using Gac;
using GacXml;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Gac
{
    public class VariableHelper
    {
        /// <summary>
        /// 转义字符串中所有正则特殊字符
        /// </summary>
        /// <param name="input">传入字符串</param>
        /// <returns></returns>
        string FilterString(string input)
        {
            input = input.Replace("\\", "\\\\");//先替换“\”，不然后面会因为替换出现其他的“\”
            Regex r = new Regex("[\\*\\.\\?\\+\\$\\^\\[\\]\\(\\)\\{\\}\\|\\/]");
            MatchCollection ms = r.Matches(input);
            List<string> list = new List<string>();
            foreach (Match item in ms)
            {
                if (list.Contains(item.Value))
                    continue;
                input = input.Replace(item.Value, "\\" + item.Value);
                list.Add(item.Value);
            }
            return input;
        }
        public bool IsContent(string regstr)
        {
            string regexCode = "\\(\\?<content>"; //正则代码    
            Regex reg = new Regex(regexCode);
            return reg.IsMatch(regstr);

        }
        public string GetMultUrl(string url,MultPage multPage,HttpRequestInfo RequestInfo)
        {
            if (multPage.MultPageUrlFromHtml)
            {
                //HttpHelper http = new HttpHelper();
                //HttpItem item = new HttpItem() { URL = url };
                //HttpResult result = http.GetHtml(item);
                HttpCommon http = new HttpCommon(RequestInfo);
                HttpResult result = http.GetHtml(url);
                string regstr = GetRegexStr(multPage.PageUrlStyle, true);
                //MessageBox.Show(regstr);
                string matchstr = multPage.PageUrlCombine;
                string resultstr = MatchValue(regstr, matchstr, result.Html);


              return FormAturl(url, resultstr);
            } else
            {
                return  System.Text.RegularExpressions.Regex.Replace(url, multPage.PageReplaceUrl, multPage.PageReplaceNew);
            }
            //txtPageName.Text = multpage.PageName;
            //txtReg.Text = multpage.PageReplaceUrl;
            //txtMatch.Text = multpage.PageReplaceNew;

            //rtbeReg.TextValue = multpage.PageUrlStyle;
            //rtbeMatch.TextValue = multpage.PageUrlCombine;
            //rbFromCode.Checked = multpage.MultPageUrlFromHtml;
            
        }
        public string GetRegexStr(string Text, bool Parameter = false, bool Lable = false)
        {
            string str = FilterString(Text);
            str= str.Replace("\\(\\*\\)", "[\\s\\S]*?");
            if (Parameter)
            {
                int i = 0;
                while (str.Contains("\\[参数\\]"))
                {
                    i++;
                    str = Strings.Replace(str,"\\[参数\\]", "(?<GacParameter" + i + ">.*?)", 1,1);
                }
            }
            if (Lable)
            {
                Regex reg = new Regex("\\\\\\[标签:(.*?)\\\\\\]");
                Match match = reg.Match(str);
                if (match.Success)
                {
                    //   str = Strings.Replace(str, "\\\\\\[标签:(.*?)\\\\\\]", "(?<GacLable" + match.Groups[1].Value + ">.*?)");
                    str = Regex.Replace(str, "\\\\\\[标签:(.*?)\\\\\\]", "(?<GacLable$1>.*?)");
                }
                //while (match.Success)
                //{
                //  //  i++;
                //    str = Strings.Replace(str, "\\[参数\\]", "(?<GacParameter" + i + ">.*?)", 1, 1);
                //    match = reg.Match(str);
                //}
            }
            return str.Replace("\r\n", "\n");
        }
        public string GetMatch(string Text)
        {
            Regex reg = new Regex("(\\[参数(\\d+)\\])");
            MatchCollection mcs = reg.Matches(Text);
            Dictionary<string, string> keywords = new Dictionary<string, string>();
            for (int i = 0; i < mcs.Count; i++)
            {
                string key = mcs[i].Groups[1].Value;
                if (!keywords.ContainsKey(key))
                {
                    keywords.Add(key, mcs[i].Groups[2].Value);
                }
            }
            string str = Text;
            foreach (var item in keywords)
            {
                str = str.Replace(item.Key, "<GacParameter" + item.Value + ">");
            }
            return str;
        }
        public string MatchValue(string RegStr, string MatchStr, string Input)
        {
            Regex reg = new Regex(RegStr);
            MatchCollection mcs =reg.Matches(Input);
            if (mcs.Count>0)
            {
                string temp = MatchStr;
                Dictionary<string, string> dic = GetMatchList(MatchStr);
                foreach (var item in dic)
                {
                    temp = temp.Replace(item.Key, mcs[0].Groups[item.Value].Value);
                }
                return temp;
            }
            return "";
        }
        public string ReplaceValue(string RegStr, string MatchStr, string Input)
        {
            string result= Regex.Replace(Input, RegStr, MatchStr);
            return result;
        }
        public List<string> MatchesValue(string RegStr, string MatchStr, string Input)
        {
            Input = Input.Replace("\r\n", "\n");
            Regex reg = new Regex(RegStr);
            MatchCollection mcs = reg.Matches(Input);
            List<string> list = new List<string>();
            if (mcs.Count > 0)
            {
                for (int i = 0; i < mcs.Count; i++)
                {
                    string temp = MatchStr;
                    Dictionary<string, string> dic = GetMatchList(MatchStr);
                    foreach (var item in dic)
                    {
                        temp = temp.Replace(item.Key, mcs[i].Groups[item.Value].Value);
                    }
                    list.Add(temp);
                }
               
            }
            return list;
        }
        public Dictionary<string, string> MatchLableValue(string RegStr, string Input)
        {
            Regex reg = new Regex(RegStr);
            Match match = reg.Match(Input);
            List<string> list = new List<string>();

            Dictionary<string, string> Lables = new Dictionary<string, string>();
            if (match .Success)
            {
                Dictionary<string, string>  dic = GetLableRegList(RegStr);
                foreach (var item in dic)
                {
                    Lables.Add(item.Key, match.Groups[item.Value].Value);
                }
            }
            return Lables;
        }
        public List<string> MatchesValue(string RegStr, string MatchStr, string Input, ref List<Dictionary<string, string>> Lables )
        {
            RegStr = RegStr.Replace("\r\n", "\n");
            Input = Input.Replace("\r\n", "\n");
            Regex reg = new Regex(RegStr);
            MatchCollection mcs = reg.Matches(Input);
            List<string> list = new List<string>();

            Lables = new List<Dictionary<string, string>>();
            if (mcs.Count > 0)
            {
                for (int i = 0; i < mcs.Count; i++)
                {
                   
                    string temp = MatchStr;
                    Dictionary<string, string> dic = GetMatchList(MatchStr);
                    
                    foreach (var item in dic)
                    {
                        temp = temp.Replace(item.Key, mcs[i].Groups[item.Value].Value);
                    }

                    Dictionary<string, string> lable = new Dictionary<string, string>();
                     dic = GetLableRegList(RegStr);
                    foreach (var item in dic)
                    {
                        lable.Add(item.Key, mcs[i].Groups[item.Value].Value);
                        Lables.Add(lable);
                    }
                    list.Add(temp);
                   
                }

            }
            return list;
        }
        public string GetLableName(string Text)
        {
          Regex  reg = new Regex("\\\\\\[标签:(.*?)\\\\\\]");
            Match match= reg.Match(Text);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return Text;
        }
        public string GetMidStr(string start,string end,string str)
        {
            string reg1 = GetRegexStr(start);
            string reg2 = GetRegexStr(end);
            reg1 = reg1 + "([\\s\\S]*?)" + reg2;
            Regex reg = new Regex(reg1);
            Match match = reg.Match(str);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 从正则转义后的结果中获取标签列表
        /// </summary>
        /// <param name="Text">正则转义后的文本</param>
        /// <returns></returns>
        public List<string> GetLableNames(string Text)
        {
            Regex reg = new Regex("\\\\\\[标签:(.*?)\\\\\\]");
            MatchCollection mcs = reg.Matches(Text);
            List<string> list = new List<string>();
            for (int i = 0; i < mcs.Count; i++)
            {
                list.Add(mcs[i].Groups[1].Value);
            }
            return list;
        }

        /// <summary>
        /// 从原始文本中获取标签列表
        /// </summary>
        /// <param name="Text">原始文本</param>
        /// <returns></returns>
        public List<string> GetLables(string Text)
        {
            Regex reg = new Regex("\\[标签:(.*?)\\]");
            MatchCollection mcs = reg.Matches(Text);
            List<string> list = new List<string>();
            for (int i = 0; i < mcs.Count; i++)
            {
                list.Add(mcs[i].Groups[1].Value);
            }
            return list;
        }
        /// <summary>
        /// 从原始文本中获取标签列表(包含'[标签:])
        /// </summary>
        /// <param name="Text">原始文本</param>
        /// <returns></returns>
        public List<string> GetLablesHaveSurround(string Text)
        {
            Regex reg = new Regex("\\[标签:(.*?)\\]");
            MatchCollection mcs = reg.Matches(Text);
            List<string> list = new List<string>();
            for (int i = 0; i < mcs.Count; i++)
            {
                list.Add(mcs[i].Value);
            }
            return list;
        }
        public List<string> GetLablesName(string Text)
        {
            Regex reg = new Regex("(\\[标签:.*?\\])");
            MatchCollection mcs = reg.Matches(Text);
            List<string> list = new List<string>();
            for (int i = 0; i < mcs.Count; i++)
            {
                list.Add(mcs[i].Groups[1].Value);
            }
            return list;
        }
        public Dictionary<string, string> GetMatchList(string Text,bool ContainsLable=false)
        {
            Dictionary<string, string> keywords = new Dictionary<string, string>();

            Regex reg = new Regex("(\\[参数(\\d+)\\])");
            MatchCollection mcs = reg.Matches(Text);
            
            for (int i = 0; i < mcs.Count; i++)
            {
                string key = mcs[i].Groups[1].Value;
                if (!keywords.ContainsKey(key))
                {
                    keywords.Add(key, "GacParameter" + mcs[i].Groups[2].Value);
                    
                }
            }
            if(ContainsLable)
            { 
                reg = new Regex("(\\\\\\[标签:(.*?)\\\\\\])");
                mcs = reg.Matches(Text);
                for (int i = 0; i < mcs.Count; i++)
                {
                    string key = mcs[i].Groups[1].Value;
                    if (!keywords.ContainsKey(key))
                    {
                        keywords.Add(key, "GacLable" + mcs[i].Groups[2].Value);

                    }
                }
            }
            //
            return keywords;
        }
        public Dictionary<string, string> GetParameterMatchList(string Text)
        {
            Regex reg = new Regex("(\\[参数(\\d+)\\])");
            MatchCollection mcs = reg.Matches(Text);
            Dictionary<string, string> keywords = new Dictionary<string, string>();
            for (int i = 0; i < mcs.Count; i++)
            {
                string key = mcs[i].Groups[1].Value;
                if (!keywords.ContainsKey(key))
                {
                    keywords.Add(key, "GacParameter" + mcs[i].Groups[2].Value);

                }
            }
            return keywords;
        }
        public Dictionary<string, string> GetLableMatchList(string Text)
        {
            Regex reg = new Regex("(\\\\\\[标签:(.*?)\\\\\\])");
            MatchCollection mcs = reg.Matches(Text);
            Dictionary<string, string> keywords = new Dictionary<string, string>();
            for (int i = 0; i < mcs.Count; i++)
            {
                string key = mcs[i].Groups[1].Value;
                if (!keywords.ContainsKey(key))
                {
                    keywords.Add(key, "GacParameter" + mcs[i].Groups[2].Value);

                }
            }
            return keywords;
        }
        public Dictionary<string, string> GetLableRegList(string Text)
        {
            string regexCode = "\\(\\?<(GacLable(.*?))>"; //正则代码  
            Regex reg = new Regex(regexCode);
            MatchCollection mcs = reg.Matches(Text);
            Dictionary<string, string> keywords = new Dictionary<string, string>();
            for (int i = 0; i < mcs.Count; i++)
            {
                string key = mcs[i].Groups[1].Value;
                if (!keywords.ContainsKey(key))
                {
                    keywords.Add(mcs[i].Groups[2].Value, mcs[i].Groups[1].Value);

                }
            }
            return keywords;
        }
        /// <summary>
        /// 格式化URL函数  urlX 传入相对URL objurl 传入绝对基URL  基URL 一定要带HTTP://
        /// </summary>
        /// <param name="urlX">传入单个的URL</param>
        /// <param name="objurl">
        /// 传入得到值的页面URL
        /// </param>
        /// <returns></returns>
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
        /// <summary>
        /// 获取全部href和src的链接地址
        /// </summary>
        /// <param name="html">提取链接的html</param>
        /// <param name="OnlyImg">是否只提取图片</param>
        /// <returns></returns>
        public List<string> GetLinks(string html,bool OnlyImg=false)
        {
            int index = 3;
            Regex reg = new Regex("(?is)(href|src)=(\"|\')([^(\"|\')]+)(\"|\')");
            if (OnlyImg)
            {
                reg=new Regex( "<img.*?src*=*['\"]*(\\S+)[\"'].*?>");
                index = 1;
            }
            MatchCollection mcs = reg.Matches(html);

            //string regexCode = "(http|https):\\/\\/[\\w\\-_]+(\\.[\\w\\-_]+)+([\\w\\-\\.,@?^=%&:/~\\+#]*[\\w\\-\\@?^=%&/~\\+#])?"; //正则代码   
            //Regex reg = new Regex(regexCode);
            //MatchCollection mcs = reg.Matches(html);

            List<string> list = new List<string>();
            for (int i = 0; i < mcs.Count; i++)
            {
                list.Add(mcs[i].Groups[index].Value);
            }

            if (mcs.Count==0)
            {
                try
                {
                    Uri uri = new Uri(html);
                    list.Add(html);
                }
                catch (Exception)
                {

                }
              
            }
            return list;
        }

        /// <summary>
        ///补全网页中href和src的网址
        /// </summary>
        /// <param name="baseUrl">原始网址</param>
        /// <param name="html">网页代码</param>
        /// <returns></returns>
        public string FixUrl(string baseUrl, string html)
        {
            html = Regex.Replace(html, "(?is)(href|src)=(\"|\')([^(\"|\')]+)(\"|\')", (match) =>
            {
                string org = match.Value;
                string link = match.Groups[3].Value;
                if (link.StartsWith("http"))
                {
                    return org;
                }

                try
                {
                    Uri uri = new Uri(baseUrl);
                    Uri thisUri = new Uri(uri, link);
                    string fullUrl = String.Format("{0}=\"{1}\"", match.Groups[1].Value, thisUri.AbsoluteUri);
                    return fullUrl;
                }
                catch (Exception)
                {
                    return org;
                }
            });
            return html;
        }
    }
}
