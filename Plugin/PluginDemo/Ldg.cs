using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using GacApi;
using CsharpHttpHelper;
using System.Text.RegularExpressions;

namespace PluginDemo
{
    public class Ldg : ISpider
    {
        public bool UseChangeSaveFiles
        {
            get { return true; }
        }

        public bool UseChangeStepUrls
        {
            get { return true; }
        }

        public bool UseChangeWebRequest
        {
            get { return true; }
        }

        public bool UseChangeWebResutl
        {
            get { return true; }
        }

        public bool UseGetStepUrls
        {
            get { return true; }
        }

        public bool UseMakeStartAddress
        {
            get { return true; }
        }

        public void ChangeResultDic(Dictionary<string, string> dic)
        {
            if (dic.ContainsKey("标题"))
            {
                dic["标题"] += "插件启用成功";
            }
        }

        public void ChangeSaveFiles(Dictionary<string, Dictionary<string, KeyValuePair<string, string>>> fieldandfiles, Dictionary<string, string> dic)
        {
           
        }

        public void ChangeStepUrls(List<KeyValuePair<string, Dictionary<string, string>>> StepUrls)
        {
            int LastNum = 0;
            bool Check = false;
            for (int i = StepUrls.Count - 1; i >=0 ; i--)
            {
                if (LastNum==0&& Check==false)
                {
                    LastNum = 480;
                    Check = true;
                }
                if (StepUrls[i].Value.ContainsKey("章节名"))
                {
                    string ChapterName = StepUrls[i].Value["章节名"];
                    int number = GetBookNum(ChapterName);
                    if (LastNum>= number)
                    {
                        StepUrls.RemoveAt(i);
                    }
                }
                
            }
        }

        public void ChangeWebRequest(HttpItem httpItem)
        {
            
        }

        public void ChangeWebResutl(HttpResult result, HttpItem httpItem)
        {
            
        }

        public object Clone()
        {
            return this;
        }

        public void Dispose()
        {
            
        }

        public string EndJob(bool handstop, string jobname, string jobid, int url, int content, int post, object job)
        {
            return "老大哥插件提醒您,采集结束";
        }

        public List<KeyValuePair<string, Dictionary<string, string>>> GetStepUrls(string html, string areaStart, string areaEnd, string urlStyle, string urlCombine, string allow, string forbidden)
        {
            return null;
        }

        public List<string> MakeStartAddress(string urlData, string refer, CookieCollection cookie)
        {
            throw new NotImplementedException();
        }

        public List<string> MakeStartAddress(string urlData, string useragent, string refer, CookieCollection cookie)
        {
            return new List<string>();
        }

        public string StartJob()
        {
            return "老大哥插件提醒您,采集开始";
        }


        public int GetBookNum(string ChapterName)
        {
            Regex reg = new Regex("第(.*?)章");
            Match match = reg.Match(ChapterName);
            if (!match.Success)
            {
                reg = new Regex("^(\\d+)[\\. ]");
                match = reg.Match(ChapterName);
            }
            if (match.Success)
            {
                int result = 0;
                if (!int.TryParse(match.Groups[1].Value, out result))
                {
                    result = ParseCnToInt(match.Groups[1].Value);
                }

                return result;
            }
            return -1;
        }
        #region  辅助函数 数字转换
        /// <summary>
        /// 转换数字
        /// </summary>
        private int CharToNumber(char c)
        {
            switch (c)
            {
                case '一': return 1;
                case '二': return 2;
                case '三': return 3;
                case '四': return 4;
                case '五': return 5;
                case '六': return 6;
                case '七': return 7;
                case '八': return 8;
                case '九': return 9;
                case '零': return 0;
                default: return -1;
            }
        }

        /// <summary>
        /// 转换单位
        /// </summary>
        private int CharToUnit(char c)
        {
            switch (c)
            {
                case '十': return 10;
                case '百': return 100;
                case '千': return 1000;
                case '万': return 10000;
                case '亿': return 100000000;
                default: return 1;
            }
        }
        /// <summary>
        /// 将中文数字转换阿拉伯数字
        /// </summary>
        /// <param name="cnum">汉字数字</param>
        /// <returns>长整型阿拉伯数字</returns>
        private int ParseCnToInt(string cnum)
        {
            cnum = Regex.Replace(cnum, "\\s+", "");
            int firstUnit = 1;//一级单位                
            int secondUnit = 1;//二级单位 
            int tmpUnit = 1;//临时单位变量
            int result = 0;//结果
            for (int i = cnum.Length - 1; i > -1; --i)//从低到高位依次处理
            {
                tmpUnit = CharToUnit(cnum[i]);//取出此位对应的单位
                if (tmpUnit > firstUnit)//判断此位是数字还是单位
                {
                    firstUnit = tmpUnit;//是的话就赋值,以备下次循环使用
                    secondUnit = 1;
                    if (i == 0)//处理如果是"十","十一"这样的开头的
                    {
                        result += firstUnit * secondUnit;
                    }
                    continue;//结束本次循环
                }
                else if (tmpUnit > secondUnit)
                {
                    secondUnit = tmpUnit;
                    continue;
                }
                int num = 0;
                if (int.TryParse(cnum[i].ToString(), out num))
                {
                    result += firstUnit * secondUnit * num;//如果是数字,则和单位想乘然后存到结果里
                }
                else
                {
                    result += firstUnit * secondUnit * CharToNumber(cnum[i]);//如果是数字,则和单位想乘然后存到结果里
                }
            }
            return result;
        }
        #endregion
    }
}
