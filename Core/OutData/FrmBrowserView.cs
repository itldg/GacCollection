using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAC_Collection
{
    public partial class FrmBrowserView : Form
    {
        public FrmBrowserView(string html)
        {
            InitializeComponent();
            if (webBrowser1.Document == null)
            {
              
                webBrowser1.Navigate("about:blank");
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                webBrowser1.Document.Write(html);
                webBrowser1.Refresh();
            }
            else
            {
                webBrowser1.Document.GetElementById("weibospiritBody").InnerHtml = html;
            }
        }

        private void FrmBrowserView_Load(object sender, EventArgs e)
        {

        }
    }
}
