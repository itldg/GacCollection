using System;
using System.Windows.Forms;

namespace Gac
{
    public enum XpatheStatus
    {
        Start,
        Stop
    }
    public class BrowserXpathHelper
    {
        #region 属性和接口
        private WebBrowser web = null;
        public BrowserXpathHelper(WebBrowser webBrowser)
        {
            this.web = webBrowser;
        }
        private XpatheStatus status = XpatheStatus.Stop;
        public delegate void XpathChangeHandle(string NexXpath);
        public event XpathChangeHandle XpathChange;
        public delegate void XpatheStatusChangeHandle(XpatheStatus Status);
        public event XpatheStatusChangeHandle XpatheStatusChange;

        #endregion

        #region 扩展方法
        public void Start()
        {
            try
            {
                exit = false;
                web.Document.MouseOver += Document_MouseOver;
                web.Document.MouseLeave += Document_MouseLeave;
                web.Document.MouseUp += Document_MouseUp;
                web.Navigating += Web_Navigating;
            }
            catch (Exception ex)
            {

                Console.WriteLine("启动BrowserXpathHelper发生错误" + ex.Message);
            }
            if (XpatheStatusChange != null) XpatheStatusChange(XpatheStatus.Start);
        }

        public void Stop()
        {
            if (lastHtmlElement != null)
            { lastHtmlElement.Style = LastStyle; }
            try
            {

                web.Document.MouseLeave -= Document_MouseLeave;
                web.Document.MouseUp -= Document_MouseUp;
                exit = true;

            }
            catch (Exception ex)
            {

                Console.WriteLine("关闭BrowserXpathHelper发生错误" + ex.Message);
            }
        }

        public string CheckXpath(string oldXpath, string NewXpath)
        {
            string[] olds = oldXpath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            string[] news = NewXpath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            if (olds.Length == news.Length)
            {
                int count = 0;
                string tempresult = "";
                for (int i = 0; i < olds.Length; i++)
                {
                    if (olds[i] != news[i])
                    {
                        tempresult = NewXpath.Replace(news[i], "/" + news[i].Substring(0, news[i].IndexOf("[")));
                        count++;
                    }
                }
                if (count == 1 && !string.IsNullOrEmpty(tempresult))
                {
                    return tempresult;
                }
            }
            return "err";
        }
        #endregion

        #region 系统核心
        string LastStyle = "";
        HtmlElement lastHtmlElement = null;
        bool exit = false;
        private void Web_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;

        }

        private void Document_MouseUp(object sender, HtmlElementEventArgs e)
        {

            if (XpatheStatusChange != null) XpatheStatusChange(XpatheStatus.Stop);
            Stop();
        }

        private void Document_MouseLeave(object sender, HtmlElementEventArgs e)
        {
            e.FromElement.Style = LastStyle;
        }

        private void Document_MouseOver(object sender, HtmlElementEventArgs e)
        {
            if (exit)
            {
                web.Navigating -= Web_Navigating;
                web.Document.MouseOver -= Document_MouseOver;
                return;
            }
            LastStyle = e.ToElement.Style;
            e.ToElement.Style = "border:1px solid #6ce26c!important";
            //this.textBox2.Text = e.toElement.parentElement.innerHTML;
            string path = "";
            HtmlElement element = e.ToElement;
            lastHtmlElement = element;
            while (element.Parent != null)
            {
                HtmlElementCollection elementCollection = element.Parent.Children;
                int ps = 0;
                foreach (HtmlElement e2 in elementCollection)
                {
                    if (e2.TagName == element.TagName)
                    {
                        ps++;

                        if (e2 == element)
                        {
                            path = "/" + element.TagName + "[" + ps + "]" + path;
                            break;
                        }
                    }
                }
                element = element.Parent;
            }
            path = "/html[1]" + path.ToLower();
            if (XpathChange != null)
            { XpathChange(path); }
        }



        #endregion
    }
}
