using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using HtmlAgilityPack;
using Gac;
using mshtml;

public struct OLECMDTEXT
{
    public uint cmdtextf;
    public uint cwActual;
    public uint cwBuf;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
    public char rgwz;
}

[StructLayout(LayoutKind.Sequential)]
public struct OLECMD
{
    public uint cmdID;
    public uint cmdf;
}

// Interop definition for IOleCommandTarget.
[ComImport,
Guid("b722bccb-4e68-101b-a2bc-00aa00404770"),
InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IOleCommandTarget
{
    //IMPORTANT: The order of the methods is critical here. You
    //perform early binding in most cases, so the order of the methods
    //here MUST match the order of their vtable layout (which is determined
    //by their layout in IDL). The interop calls key off the vtable ordering,
    //not the symbolic names. Therefore, if you switched these method declarations
    //and tried to call the Exec method on an IOleCommandTarget interface from your
    //application, it would translate into a call to the QueryStatus method instead.
    void QueryStatus(ref Guid pguidCmdGroup, UInt32 cCmds,
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] OLECMD[] prgCmds, ref OLECMDTEXT CmdText);
    void Exec(ref Guid pguidCmdGroup, uint nCmdId, uint nCmdExecOpt, ref object pvaIn, ref object pvaOut);
}



namespace GacBrowser
{
    public partial class FrmBrowser : Form
    {
        BrowserXpathHelper bxh = null;
        public delegate void ReturnCookie(string Cookie);
        public ReturnCookie rCookie;

        public delegate void ReturnExportCookie(string Cookie);
        public ReturnExportCookie rExportCookie;

        public delegate void ReturnPOST(string cookie, string pData);
        public ReturnPOST rPData;

        public delegate void ReturnExportPOST(string cookie, string pData);
        public ReturnExportPOST rExportPData;

       
        private int m_GetFlag =4;

        //private SHDocVw.WebBrowser wb;
        private Guid cmdGuid = new Guid("ED016940-BD5B-11CF-BA4E-00C04FD70816");
        private enum MiscCommandTarget
        { Find = 1, ViewSource, Options }

        /// <summary>
        ///如果为
        ///-1-正常的浏览器
        /// 0-返回采集数据的cookie（运行时采集和任务填写cookie时采集），
        ///1-返回采集数据post数据，
        ///2-返回导出数据的cookie，
        ///3-返回导出数据的post数据，
        ///4-返回网址xpath
        ///5-返回标签Xpath
        /// </summary>   
        public int getFlag
        {
            get { return m_GetFlag; }
            set { m_GetFlag = value; }
        }

        public FrmBrowser()
        {
            InitializeComponent();
        }

        public FrmBrowser(string Url)
        {
            InitializeComponent();

            this.txtUrl.Text = Url;



        }

        private void wb_NavigateComplete2(object pDisp, ref object URL)
        {

            Cursor.Current = Cursors.Default;
            toolStripProgressBar1.Value = 0;
            try
            {
                this.txtUrl.Text = ((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).Url.ToString();
                this.txtCookieResult.Text = ((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).Document.Cookie.ToString();
            }
            catch (Exception)
            {

            }
            
        }

        private void frmWeblink_Resize(object sender, EventArgs e)
        {
            //this.txtUrl.Width = this.Width - this.txtUrl.Left - this.butUrl.Width - 50;
            //this.butUrl.Left = this.txtUrl.Left + this.txtUrl.Width;
           
            if (getFlag!=-1)
            {
                txtUrl.Width = toolStrip1.Width - 326;
            } else
            {
                txtUrl.Width = toolStrip1.Width - 250;
            }
        }

        private void frmWeblink_Load(object sender, EventArgs e)
        {

            this.splitContainer2.SplitterDistance = this.splitContainer2.Height-100;

            switch (this.getFlag)
            {
                case -1:
                    //this.toolOkExit.Enabled = false;
                    //this.toolOkExit.Visible = false;
                    //this.Controls.RemoveByKey("toolOkExit");
                    toolStrip1.Items.Remove(toolOkExit);
                    toolStrip1.Items.Remove(toolStripButton1);
                    txtUrl.Width += 76;
                  
                    splitContainer2.Panel2MinSize = 0;
                    splitContainer2.SplitterDistance = splitContainer2.Height;


                    break;
                case 0:
                case 2:
                    tabControl1.TabPages.RemoveAt(1);
                    tabControl1.TabPages.RemoveAt(1);
                    break;
                case 1:
                case 3:
                    tabControl1.TabPages.RemoveAt(2);
                    tabControl1.TabPages.RemoveAt(0);
                    break;
                
               
                case 4:
                case 5:
                    if (this.getFlag == 4)
                    {
                        rbHref.Checked = true;
                        rbMuit.Checked = true;
                        rbInnerHtml.Enabled = rbInnerText.Enabled = rbOuterHtml.Enabled = rbOne.Enabled = false;
                    }
                    else
                    {

                    }
                    tabControl1.TabPages.RemoveAt(0);
                    tabControl1.TabPages.RemoveAt(0);
                    
                    break;
                default :
                    break;
            }

            if (this.txtUrl.Text.Trim() != "" || this.txtUrl.Text != null)
            {
                GoUrl();
            }
           
        }

        private void wb_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            SHDocVw.WebBrowser _axWebBrowser = CreateNewWebBrowser();
            ppDisp = _axWebBrowser.Application;
            _axWebBrowser.RegisterAsBrowser = true;
        }

        private void wb_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            try
            {
                if (PostData != null) this.textBox2.Text = System.Text.Encoding.ASCII.GetString(PostData as byte[]);
                this.txtCookieResult.Text = ((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).Document.Cookie.ToString();

            }
            catch (Exception)
            {
                
            }




        }

        private void toolSource_Click(object sender, EventArgs e)
        {
            IOleCommandTarget cmdt;
            Object o = new object();
            try
            {
                cmdt = (IOleCommandTarget)GetDocument();
                cmdt.Exec(ref cmdGuid, (uint)MiscCommandTarget.ViewSource,
                    (uint)SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref o, ref o);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GAC数据采集浏览器 错误信息", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
            
        }

        private HTMLDocument GetDocument()
        {
            try
            {
                SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).ActiveXInstance;

                HTMLDocument htm = (HTMLDocument)wb.Document;
                return htm;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }

        }
      

        private void GoUrl()
        {
            string url = this.txtUrl.Text;

           SHDocVw.WebBrowser wb = CreateNewWebBrowser();


            // Return if nowhere to go
            if (url == "") 
                return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Object o = null;
                if (wb != null) { 
                wb.Navigate(url, ref o, ref o, ref o, ref o);
                }else
                { ((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).Navigate(url); }
            }
            finally
            {
                int i = this.txtUrl.Items.IndexOf(url);
                if (i == -1)
                    this.txtUrl.Items.Add(url);

                Cursor.Current = Cursors.Default;
            }			
        }

        private void wb_DocumentComplete(object pDisp, ref object URL)
        {
            SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).ActiveXInstance;
            
            if (wb.ReadyState == SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
            {

                this.txtUrl.Text = wb.LocationURL;


                this.toolStripProgressBar1.Value = 0;
                this.toolStripProgressBar1.Visible = false;

            }
            try
            {
                this.txtCookieResult.Text = ((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).Document.Cookie.ToString();
            }
            catch (Exception)
            {
                
            }
           

        }

        private void wb_ProgressChange(int Progress, int ProgressMax)
        {
            this.toolStripProgressBar1.Visible = true;

            SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).ActiveXInstance;

            if ((Progress > 0) && (ProgressMax > 0))
            {
                this.toolStripProgressBar1.Maximum = ProgressMax;
                this.toolStripProgressBar1.Step = Progress;
                this.toolStripProgressBar1.PerformStep();
            }
            else if (wb.ReadyState == SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
            {
                this.toolStripProgressBar1.Value = 0;
                this.toolStripProgressBar1.Visible = false;
            }
        }

        private void wb_StatusTextChange(string Text)
        {
            this.toolStripStatusLabel1.Text = Text;
            //Application.DoEvents();
          
        }

        private SHDocVw.WebBrowser CreateNewWebBrowser()
        {
            //此版本不支持多Tab页，如果支持多Tab页需要对webbrowser重新进行封装，第一期暂不做了

            this.toolSource.Enabled = true;

            System.Windows.Forms.WebBrowser TmpWebBrowser = new System.Windows.Forms.WebBrowser();
            TmpWebBrowser.ScriptErrorsSuppressed = true;

            if (this.splitContainer2.Panel1.Controls.Count ==0)
            {
                //表示第一次启动打开网页，则在默认的分页中增加webbrowser，不需要增加tab页

                tsmiPrint.Enabled = tsmiPrintPreview.Enabled = true;
                this.splitContainer2.Panel1.Controls.Add(TmpWebBrowser);

                

            }
            else
            {
                //TabPage newTabPage = new TabPage();
                //((WebBrowserTag)TmpWebBrowser.Tag).TabIndex = this.WebBrowserTab.TabPages.Count + 1;
                //newTabPage.Controls.Add(TmpWebBrowser);

                //this.WebBrowserTab.TabPages.Add(newTabPage);
                //this.WebBrowserTab.SelectedTab = newTabPage;


                this.splitContainer2.Panel1.Controls.Clear();

                this.splitContainer2.Panel1.Controls.Add(TmpWebBrowser);

            }
            TmpWebBrowser.Dock = DockStyle.Fill;
         
            if (this.getFlag!=4&&this.getFlag!=5)
            {

                SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)TmpWebBrowser.ActiveXInstance;
                wb.CommandStateChange += new SHDocVw.DWebBrowserEvents2_CommandStateChangeEventHandler(this.wb_CommandStateChange);
                wb.BeforeNavigate2 += new SHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.wb_BeforeNavigate2);
                wb.ProgressChange += new SHDocVw.DWebBrowserEvents2_ProgressChangeEventHandler(this.wb_ProgressChange);
                wb.StatusTextChange += new SHDocVw.DWebBrowserEvents2_StatusTextChangeEventHandler(this.wb_StatusTextChange);
                wb.NavigateError += new SHDocVw.DWebBrowserEvents2_NavigateErrorEventHandler(this.wb_NavigateError);
                wb.NavigateComplete2 += new SHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(this.wb_NavigateComplete2);
                wb.TitleChange += new SHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(this.wb_TitleChange);
                wb.DocumentComplete += new SHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.wb_DocumentComplete);
                wb.NewWindow2 += new SHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(this.wb_NewWindow2);
                return wb;

            }
            else
            { 

            bxh = new BrowserXpathHelper(TmpWebBrowser);
            bxh.XpathChange += Bxh_XpathChange;
            bxh.XpatheStatusChange += Bxh_XpatheStatusChange;
                return null;
            }
           

        }

        private void wb_CommandStateChange(int Command, bool Enable)
        {
            switch (Command)
            {
                case ((int)SHDocVw.CommandStateChangeConstants.CSC_NAVIGATEFORWARD):
                    this.toolNext.Enabled = Enable;
                    this.menuNext.Enabled = Enable;
                    break;

                case ((int)SHDocVw.CommandStateChangeConstants.CSC_NAVIGATEBACK):
                    this.toolBack.Enabled = Enable;
                    this.menuBack.Enabled = Enable;
                    break;

                default:
                    break;
            }
        }

        private void wb_NavigateError(object pDisp, ref object URL, ref object Frame, ref object StatusCode, ref bool Cancel)
        {
        }

        private void butUrl_Click(object sender, EventArgs e)
        {
     
        }

        private void wb_TitleChange(string Text)
        {
            this.splitContainer2.Panel1.Text = Text;
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GoUrl();
            }
        }

        private void OkExit()
        {
            switch (this.getFlag)
            {
                case 0:
                    this.Tag = this.txtCookieResult.Text;
                    if (rCookie != null)
                    {
                        rCookie(this.txtCookieResult.Text);
                        
                    }
                    break;
                case 1:
                    if (rPData != null)
                    {
                        rPData(this.txtCookieResult.Text, this.textBox2.Text);
                    }
                    break;
                case 2:
                    if (rExportCookie != null)
                    {
                        rExportCookie(this.txtCookieResult.Text);
                    }
                    break;
                case 3:
                    if (rExportPData != null)
                    {
                        rExportPData(this.txtCookieResult.Text, this.textBox2.Text);
                    }
                    break;
                case 4:
                    this.Tag = txtXpath.Text;
                    break;
                default :
                    break;
            }
           

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GAC数据采集配套控件\r\n用于采集网站的登陆或浏览Cookies\r\n如碰到无法正确获取的请手动使用第三方浏览器获取");
            //frmAbourMyWebbrowser fw = new frmAbourMyWebbrowser();
            //fw.ShowDialog();
            //fw.Dispose();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



        private void toolHome_Click(object sender, EventArgs e)
        {

            this.txtUrl.Text = Properties.Resources.SiteUrl;
            GoUrl();
        }

        private void toolOkExit_Click(object sender, EventArgs e)
        {
            OkExit();
        }

        private void toolBack_Click(object sender, EventArgs e)
        {
            ((SHDocVw.WebBrowser)((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).ActiveXInstance).GoBack();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            try
            {
                ((SHDocVw.WebBrowser)((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).ActiveXInstance).GoBack();
            }
            catch (Exception)
            {

               
            }
            
        }

        private void menuNext_Click(object sender, EventArgs e)
        {
            ((SHDocVw.WebBrowser)((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).ActiveXInstance).GoForward();
        }

        private void toolNext_Click(object sender, EventArgs e)
        {
            ((SHDocVw.WebBrowser)((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).ActiveXInstance).GoForward();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GoUrl();
        }

        private void txtUrl_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GoUrl();
            }
        }

        private void FrmBrowser_SizeChanged(object sender, EventArgs e)
        {
            frmWeblink_Resize(sender, e);
        }



        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            ((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).ShowPrintDialog();
        }

        private void tsmiPrintPreview_Click(object sender, EventArgs e)
        {
            ((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).ShowPrintPreviewDialog();
        }

        private void menuSource_Click(object sender, EventArgs e)
        {
            toolSource_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text != "停止获取")
            {
                bxh.Start();
                button2.Text = "停止获取";
            }
            else
            {
                bxh.Stop();
                if (IsTwo&&rbMuit.Checked)
                {
                    button2.Text = "点此选取下一个元素";
                }
                else
                { 
                    button2.Text = "点此后选取元素";
                }

            }
        }

        private void Bxh_XpathChange(string NexXpath)
        {
            txtXpath.Text = NexXpath;
        }
        bool IsTwo = false;
        string oldpath = "", newpath = "";

        private void btnTestXpath_Click(object sender, EventArgs e)
        {
            //HtmlDocument doc= ((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).Document,o
            string html= ((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).DocumentText;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode node = doc.DocumentNode;
            HtmlNodeCollection hnc = node.SelectNodes(txtXpath.Text);
            if (hnc.Count > 0)
            {
              
                rtbTestXpath.Clear();
                StringBuilder sb = new StringBuilder();
                VariableHelper vh = new VariableHelper();
                for (int i = 0; i < hnc.Count; i++)
                {
                    string value = "";
                    //string attr = "Href";
                    if (rbHref.Checked)
                    {
                        value = hnc[i].GetAttributeValue("Href", "");
                        value = vh.FormAturl(((System.Windows.Forms.WebBrowser)this.splitContainer2.Panel1.Controls[0]).Url.ToString(), value);
                    }
                    else if (rbOuterHtml.Checked)
                    {
                        //attr = "OuterHtml";
                        value = hnc[i].OuterHtml;
                    }
                    else if (rbInnerHtml.Checked)
                    {
                        //attr = "InnerHtml";
                        value = hnc[i].InnerHtml;
                    }
                    else if (rbInnerText.Checked)
                    {
                        //attr = "InnerText";
                        value = hnc[i].InnerText;
                    }

                    sb.AppendLine("【第" +( i+1) + "条】：" + value);
                  
                }
                rtbTestXpath.Text = sb.ToString();
            }
            else
            {
                MessageBox.Show("原因可能如下：\r\n(1)网页有标签没有闭合所导致，此页面不能用XPath解析来提取信息","解析出错",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
            }
          



        }

        private void Bxh_XpatheStatusChange(XpatheStatus Status)
        {
            if (Status==XpatheStatus.Stop)
            {
                if (!IsTwo && rbMuit.Checked)
                {
                    button2.Text = "点此选取下一个元素";
                }
                else
                {
                    button2.Text = "点此后选取元素";
                }
                if (rbMuit.Checked)
                {
                    if (IsTwo)
                    {
                        newpath = txtXpath.Text;
                        string result = bxh.CheckXpath(oldpath, newpath);
                        if (result != "err")
                        {
                            txtXpath.Text = result;
                        }
                        else
                        {
                            MessageBox.Show("XPath表达式格式化错误！请在网页的同一区域的列表内重新取值");
                        }
                    }
                    else
                    {
                        oldpath = txtXpath.Text;

                    }
                    IsTwo = !IsTwo;
                }
                

            }
          
        }
    }

}