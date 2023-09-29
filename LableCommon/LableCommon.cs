using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Gac
{
    public class LableMergeInfo
    {
        private Dictionary<string, string> dic = new Dictionary<string, string>();
        private Dictionary<string, Dictionary<string, KeyValuePair<string, string>>> downfile = new Dictionary<string, Dictionary<string, KeyValuePair<string, string>>>();
        /// <summary>
        /// 返回标签结果
        /// </summary>
        public Dictionary<string, string> Dic
        {
            get
            {
                return dic;
            }

            set
            {
                dic = value;
            }
        }
        /// <summary>
        /// 下载文件列表 标签名，所有文件，下载地址，文件保存地址和替换地址
        /// </summary>
        public Dictionary<string, Dictionary<string, KeyValuePair<string, string>>> Downfile
        {
            get
            {
                return downfile;
            }

            set
            {
                downfile = value;
            }
        }
    }
    public class LableMerge
    {
        private string _Name = "";
        private string _Result = "";

        private string _DownUrl="";
        private List<string> _ResultList = new List<string>();
        private List<DownInfo> _DownFileAll = new List<DownInfo>();
        List<List<DownInfo>> _DownFileList = new List<List<DownInfo>>();
        List<Dictionary<string, KeyValuePair<string, string>>> _ListDown = new List<Dictionary<string, KeyValuePair<string, string>>>();
        /// <summary>
        /// 标签的名字
        /// </summary>
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
        /// <summary>
        /// 标签的结果 单条或者循环用连接符的
        /// </summary>
        public string Result
        {
            get
            {
                return _Result;
            }

            set
            {
                _Result = value;
            }
        }

        /// <summary>
        /// 标签的集合
        /// </summary>
        public List<string> ResultList
        {
            get
            {
                return _ResultList;
            }

            set
            {
                _ResultList = value;
            }
        }

        /// <summary>
        /// 下载的集合 循环标签每个标签一个结果
        /// </summary>
        public List<List<DownInfo>>  DownFileList
        {
            get
            {
                return _DownFileList;
            }

            set
            {
                _DownFileList = value;
            }
        }

        /// <summary>
        /// 下载网址
        /// </summary>
        public string DownUrl
        {
            get
            {
                return _DownUrl;
            }

            set
            {
                _DownUrl = value;
            }
        }

        /// <summary>
        /// 循环标签全部标签一个结果
        /// </summary>
        public List<DownInfo> DownFileAll
        {
            get
            {
                return _DownFileAll;
            }

            set
            {
                _DownFileAll = value;
            }
        }

        public List<Dictionary<string, KeyValuePair<string, string>>> ListDown
        {
            get
            {
                return _ListDown;
            }

            set
            {
                _ListDown = value;
            }
        }
    }
    public class LableCommon
    {
        #region 采集得到数据
        /// <summary>
        /// 前后截取
        /// </summary>
        /// <param name="html">需要截取的文本</param>
        /// <param name="StartStr">开始文本</param>
        /// <param name="EndStr">结束文本</param>
        /// <param name="Loop">是否循环匹配，默认是否</param>
        /// <returns></returns>
        public List<string> GetStr(string html, string StartStr, string EndStr,bool Loop=false)
        {
            List<string> list = new List<string>();
            VariableHelper vh = new VariableHelper();
            string reg1= vh.GetRegexStr(StartStr);
            string reg2 = vh.GetRegexStr(EndStr);
            reg1 = reg1 + "([\\s\\S]*?)" + reg2;
            Regex reg = new Regex(reg1);
            MatchCollection mcs = reg.Matches(html);
            for (int i = 0; i < mcs.Count; i++)
            {
                list.Add(mcs[i].Groups[1].Value);
                if (!Loop)
                {
                    break;
                }
            }

            return list;
        }

        public List<string> GetRegex(string html, string RegexContent, string RegexCombine, bool Loop = false)
        {
            List<string> list = new List<string>();
            VariableHelper vh = new VariableHelper();
            if (vh.IsContent(RegexContent))
            {
                Regex reg = new Regex(RegexContent);
                MatchCollection mcs = reg.Matches(html);
                if (mcs.Count>0)
                {
                    for (int i = 0; i < mcs.Count; i++)
                    {
                        list.Add(mcs[i].Groups["content"].Value);
                        if (!Loop)
                        {
                            break;
                        }
                    }
                    
                }
            }
            else
            {
                string reg1 = vh.GetRegexStr(RegexContent, true);
                list = vh.MatchesValue(reg1, RegexCombine, html);
                if (!Loop)
                { 
                    for (int i = list.Count-1; i >=1 ; i--)
                    {
                        list.RemoveAt(i);
      
                    }
                }
             
            }
            return list;
           

        }
        /// <summary>
        /// 标签组合
        /// </summary>
        /// <param name="MergeContent">组合内容</param>
        /// <param name="diclable">历史标签结果</param>
        /// <param name="Loop">是否循环获取</param>
        /// <returns></returns>
        public List<string> GetMergeContent(string MergeContent, Dictionary<string, LableMerge> diclable, bool Loop = false)
        {
            List<string> list = new List<string>();
            VariableHelper vh = new VariableHelper();
            //string regstr= vh.GetRegexStr(MergeContent);
            if (Loop)
            {

            }
            else
            {
                string result = MergeContent;
                List<string> listlablename= vh.GetLables(MergeContent);
                for (int i = 0; i < listlablename.Count; i++)
                {
                    string name = listlablename[i];
                    result = result.Replace("[标签:"+name+"]", diclable[name].Result);
                }
                list.Add(result);
            }
            return list;


        }

        public List<string> GetXpath(string html, string XpathContent, int XPathAttribue, bool Loop = false)
        {
            List<string> list = new List<string>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode node = doc.DocumentNode;
            HtmlNodeCollection hnc = node.SelectNodes(XpathContent);
            if (hnc.Count > 0)
            {
                string name = "InnerHtml";
                if (XPathAttribue == 1)
                {
                    name = "InnerText";
                } else if (XPathAttribue == 2)
                {
                    name = "OuterHtml";
                } else if (XPathAttribue == 2)
                {
                    name = "Href";
                }
                for (int i = 0; i < hnc.Count; i++)
                {
                    string value = hnc[i].GetAttributeValue(name, "");
                    
                    list.Add(value);
                    if (!Loop)
                    {
                        break;
                    }
                }
            }
            return list;
        }
        #endregion

        #region 固定获取
        public string GetManualFromDate(string fromat)
        {
            return DateTime.Now.ToString(fromat);
        }
        public string GetManualRadomString(string Lib,int Num)
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                int index = rand.Next(0, Lib.Length - 1);
                sb.Append(Lib.Substring(index, 1));
            }
            return sb.ToString(); ;
        }
        public string GetManualRadomNum(int start, int end)
        {
            Random rand = new Random();
            int index = rand.Next(start, end);
            return index.ToString();
        }
        public string GetManualUnixTime()
        {
            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            return epoch.ToString();
        }
        public string GetManualRadomString(string RadomString)
        {
            Random rand = new Random();
            string[] lines = RadomString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length==0)
            {
                return "";
            }
            int index = rand.Next(0, lines.Length-1);
            return lines[index];
        }
        #endregion

        #region 保存文件夹和保存文件名获取
        /// <summary>
        /// 获取保存目录
        /// </summary>
        /// <param name="Url">下载网址</param>
        /// <param name="Format">目录格式</param>
        /// <param name="ID">下载ID</param>
        /// <param name="TaskName">任务名</param>
        /// <param name="ListLable">标签列表</param>
        /// <returns>返回最终结果</returns>
        public string GetDirName(string Url,string Format,int ID,string TaskName, LableMergeInfo lbi)
        {

            string result = Format;

            //时间处理
            if (!string.IsNullOrEmpty(result))
            {
                result = DateTime.Now.ToString(result);
            }
            //[自增ID]
            result = result.Replace("[自增ID]", ID.ToString());
            //[任务名]
            result = result.Replace("[任务名]", TaskName);
            //[标签: xxx]
            VariableHelper vh = new VariableHelper();
            List<string> list= vh.GetLables(result);
            foreach (var item in list)
            {
                string value = GetValue(lbi, item);
                result = result.Replace("[标签:"+item+"]", value);
            }

            //[文件扩展名]
            string Extension = Path.GetExtension(Url);
            result = result.Replace("[文件扩展名]", Extension);

            result = CheckFileName(result);

            return result;
                
        }
        /// <summary>
        /// 获取保存文件名
        /// </summary>
        /// <param name="Url">下载网址</param>
        /// <param name="Format">目录格式</param>
        /// <param name="ID">下载ID</param>
        /// <param name="TaskName">任务名</param>
        /// <param name="ListLable">标签列表</param>
        /// <returns>返回最终结果</returns>
        public string GetFileName(string Url, string Format, int ID, string TaskName, LableMergeInfo lmi)
        {
            string result = GetDirName(Url, Format, ID, TaskName, lmi);

            //[随机文件名]
            string Extension = Path.GetExtension(Url);
            string randfilename = Path.GetRandomFileName().Replace(".","");
            result = result.Replace("[随机文件名]", randfilename + Extension);

            //[原文件名]
            string filename = Path.GetFileName(Url);
            result = result.Replace("[原文件名]", filename);

            result = CheckFileName(result);
            if (string.IsNullOrEmpty(result))
            {
                return filename;
            }
            return result;
        }
        private string CheckFileName(string FileName)
        {
            //bool isValid = true;
            string errChar = "\\/:*?\"<>|";  //
            for (int i = 0; i < errChar.Length; i++)
            {
                FileName=FileName.Replace(errChar[0].ToString(), "");
                //if (fileName.Contains(errChar[i].ToString()))
                //{
                //    isValid = false;
                //    break;
                //}
            }
            
            return FileName;
        }
        private string GetValue(LableMergeInfo lbi, string Name)
        {
            foreach (var item in lbi.Dic)
            {
                if (item.Key==Name)
                {
                    return item.Value;
                }
            }
            return "";
        }

        #endregion
    }

    public class DownInfo
    {
        private string _PreUrl = "";
        private string _TrueUrl = "";
        private string _SaveUrl = "";
        private string _ReplaceUrl = "";
        private bool _Status = false;
        private bool _Upload = false;
        private string _Type = "";
        private string _PageUrl = "";
        private int _ContentId = 0;

        /// <summary>
        /// 原始网址
        /// </summary>
        public string PreUrl
        {
            get
            {
                return _PreUrl;
            }

            set
            {
                _PreUrl = value;
            }
        }
        /// <summary>
        /// 探测后的最终网址
        /// </summary>
        public string TrueUrl
        {
            get
            {
                return _TrueUrl;
            }

            set
            {
                _TrueUrl = value;
            }
        }

        /// <summary>
        /// 保存路径
        /// </summary>
        public string SaveUrl
        {
            get
            {
                return _SaveUrl;
            }

            set
            {
                _SaveUrl = value;
            }
        }
        /// <summary>
        /// 替换文件名
        /// </summary>
        public string ReplaceUrl
        {
            get
            {
                return _ReplaceUrl;
            }

            set
            {
                _ReplaceUrl = value;
            }
        }
        /// <summary>
        /// 是否下载完成
        /// </summary>
        public bool Status
        {
            get
            {
                return _Status;
            }

            set
            {
                _Status = value;
            }
        }
        /// <summary>
        /// 是否上传成功
        /// </summary>
        public bool Upload
        {
            get
            {
                return _Upload;
            }

            set
            {
                _Upload = value;
            }
        }
        /// <summary>
        /// 文件类型  图片
        /// </summary>
        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }
        /// <summary>
        /// 对应来路页面的网址
        /// </summary>
        public string PageUrl
        {
            get
            {
                return _PageUrl;
            }

            set
            {
                _PageUrl = value;
            }
        }
        /// <summary>
        /// 对应内容的ID
        /// </summary>
        public int ContentId
        {
            get
            {
                return _ContentId;
            }

            set
            {
                _ContentId = value;
            }
        }
    }
}
