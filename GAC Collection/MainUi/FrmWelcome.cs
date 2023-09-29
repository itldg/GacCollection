using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using WeifenLuo.WinFormsUI.Docking;
using GAC_Collection.Ex;

namespace GAC_Collection.MainUi
{
    public partial class FrmWelcome : DockContentEx
    {
        public FrmWelcome()
        {
            InitializeComponent();
        }

        private void FrmWelcome_Load(object sender, EventArgs e)
        {
            web.Navigate( Application.StartupPath + "\\网站部分\\wlcome\\index.html");
        }

        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() != web.Url.ToString())
            {
                return;
            }
            if (web.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }


            var CurrentVersion=web.Document.GetElementById("CurrentVersion");
            if (CurrentVersion!=null)
            {
                CurrentVersion.InnerText = GacInfo.Name+" " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); ;
            }

            var CurrentDatabase = web.Document.GetElementById("CurrentDatabase");
            if (CurrentDatabase != null)
            {
                GacDB gacdb = new GacDB();
                
                CurrentDatabase.InnerText = "本地保存数据："+ gacdb.dbConfig.DatabaseType[0];
            }

            var modifydatabaseid = web.Document.GetElementById("modifydatabaseid");
            if (modifydatabaseid != null)
            {
                modifydatabaseid.Click += Modifydatabaseid_Click;
            }
            
        }

        private void Modifydatabaseid_Click(object sender, HtmlElementEventArgs e)
        {
            FrmDatabase frm = new FrmDatabase();
            frm.ShowDialog();
            var CurrentDatabase = web.Document.GetElementById("CurrentDatabase");
            if (CurrentDatabase != null)
            {
                CurrentDatabase.InnerText = "本地保存数据："+frm.DataType;
            }

        }

        private void web_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString().EndsWith("#"))
            {
                e.Cancel = true;
            }
            
        }

        private void FrmWelcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void FrmWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason!=CloseReason.MdiFormClosing)
            {
                e.Cancel = true;
            }
            
        }
    }
}
