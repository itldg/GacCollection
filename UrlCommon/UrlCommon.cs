using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace Gac
{
    public class UrlCommon
    {
        public List<string> GetUrlsTest(int Model,int Start,int Count,int Change=0, bool Zerofill=false, bool Reverse=false)
        {
            List<string> list = null;
            if (Model == 2)
            {
                list= GetUrlNumber(Start, Count, Change, Zerofill,true);
            }
            else if (Model == 3)
            {
                list = GetLetterList(Start, Count);
            }
            else
            {
                list = GetUrlNumber(Start, Count, Change, Zerofill);
            }
            if (Reverse)
            {
                return ListReverse(list);
            }
            return list;
           
           
        }
        public List<string> GetUrlsTest(int Start, int Count, bool Reverse = false)
        {
            List<string> list = GetLetterList(Start, Count);
            if (Reverse)
            {
                return ListReverse(list);
            }
            return list;
        }
        public List<string> GetUrlsTest(string FilePath)
        {
            List<string> list = new List<string>();
            if (System.IO.File.Exists(FilePath))
            {
                string[] lines = System.IO.File.ReadAllLines(FilePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    list.Add(lines[i]);
                }
            }
            return list;
        }
        private List<string> ListReverse(List<string> list)
        {
            List<string> listtemp = new List<string>();
            for (int i =(list.Count-1); i >=0; i--)
            {
                listtemp.Add(list[i]);
            }
            return listtemp;
        }
        public List<string> GetUrlNumber(int Start, int Count, int Change, bool Zerofill, bool EqualProportion = false)
        {
            List<string> list = new List<string>();
            if (Zerofill)
            {
                List<long> listNumber = new List<long>();
                long temp = Start;
                for (int i = 0; i < Count; i++)
                {
                    listNumber.Add(temp);
                    if(i!=Count-1)
                    { 
                        if (EqualProportion)
                        {
                            temp *= Change;
                        }
                        else
                        {
                            temp += Change;
                        }
                    }
                }
                int numlength =temp.ToString().Length;
                for (int i = 0; i < listNumber.Count; i++)
                {
                    list.Add(String.Format("{0:D"+numlength+"}", listNumber[i]));
                }
            }
            else
            {
                long temp = Start;
                for (int i = 0; i < Count; i++)
                {
                    list.Add(temp.ToString());
                    if (EqualProportion)
                    {
                        temp *= Change;
                    }
                    else
                    {
                        temp += Change;
                    }
                }

            }
            //if (Reverse)
            //{
            //    return ListReverse(list);
            //}
            return list;
        }
        public List<string> GetLetterList(int Start, int Count)
        {
            List<string> list = new List<string>();
            int tempcount = Count - Start + 1;
            for (int i = 0; i < tempcount; i++)
            {
                char charinfo = Convert.ToChar(Start + i);
                list.Add(charinfo.ToString());
            }
            //if (Reverse)
            //{
            //    return ListReverse(list);
            //}
            return list;
        }
        public List<string> GetDateList(string Format, int DateCount)
        {
            List<string> list = new List<string>();
            
            for (int i = 0; i < DateCount; i++)
            {
                list.Add(DateTime.Now.AddDays(0 - i).ToString(Format));
            }
            return list;
        }

        public List<string> GetRssUrlList(string RssUrl)
        {
            List<string> list = new List<string>();
            try
            {
                XmlDocument objXMLDoc = new XmlDocument();
                objXMLDoc.Load(RssUrl);
                XmlNodeList objItems = objXMLDoc.GetElementsByTagName("item");
                if (objXMLDoc.HasChildNodes == true)
                {
                    foreach (XmlNode objNode in objItems)
                    {
                        if (objNode.HasChildNodes == true)
                        {
                            XmlNodeList objItemsChild = objNode.ChildNodes;
                            foreach (XmlNode objNodeChild in objItemsChild)
                            {
                                switch (objNodeChild.Name)
                                {
                                    case "link":
                                        list.Add(objNodeChild.InnerText);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }

            return list;
        }

        public List<string> GetUrlList(string UrlRule)
        {
            if (UrlRule.StartsWith("#FILE#"))
            {
                string url = UrlRule.Substring(6, UrlRule.Length - 6);
                return GetUrlsTest(UrlRule);
            }
            else if (UrlRule.StartsWith("#RSS#"))
            {
                string url = UrlRule.Substring(5, UrlRule.Length - 5);
                return GetRssUrlList(UrlRule);
            }
            else
            {
                Regex reg = new Regex("<(.*?)>");
                Match match = reg.Match(UrlRule);
                if (match.Success)
                {
                    string parameter = match.Groups[1].Value;
                    string[] pars = parameter.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> listtemp = null;
                    if (pars.Length == 3)
                    {
                        if (pars[0] == "0")
                        {
                            listtemp = GetDateList(pars[1], Convert.ToInt32(pars[2]));
                        }
                        else
                        {
                            int start = pars[1].ToCharArray()[0];
                            int end = pars[2].ToCharArray()[0];
                            listtemp = GetLetterList(start, end);
                        }
                    }
                    else if (pars.Length == 6)
                    {
                        if (pars[0] == "0")
                        {
                            listtemp = GetUrlsTest(1, Convert.ToInt32(pars[1]), Convert.ToInt32(pars[2]), Convert.ToInt32(pars[3]), Convert.ToBoolean(pars[4]), Convert.ToBoolean(pars[5]));
                        }
                        else
                        {
                            listtemp = GetUrlsTest(2, Convert.ToInt32(pars[1]), Convert.ToInt32(pars[2]), Convert.ToInt32(pars[3]), Convert.ToBoolean(pars[4]), Convert.ToBoolean(pars[5]));
                        }
                    }
                    //else
                    //{
                    //    listtemp = new List<string>();
                    //    listtemp.Add(UrlRule);

                    //}
                    
                    for (int i = 0; i < listtemp.Count; i++)
                    {
                        listtemp[i] = UrlRule.Replace(match.Groups[0].Value, listtemp[i]);
                    }
                    return listtemp;
                }
            }
            List<string> list = new List<string>();
            list.Add(UrlRule);
            return list;
        }


    }
}
