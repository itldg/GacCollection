using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using Hweny.TabSlider;
using Hweny.TabSlider.TabSlideControl;
using System.Runtime.InteropServices;
using Gac;
using GacXml;
using GAC_Collection;
using System.IO;
using GAC_Collection.Ex;
using GAC_Collection.Class;
using System.Net;
using GacBrowser;
using GAC_Collection.Common;
using GacDB.Class;

namespace GAC_Collection.MainUi.Task
{
    public partial class FrmJob : DockContent
    {
        private int ParentId = 0;
        private Class.ClassJob Job = null;
        string GacTEMPDir = System.Environment.GetEnvironmentVariable("TEMP") + "\\Gac\\DownLoad\\";
        private ModuleDb md = new ModuleDb();
        ModuleConfigCommon mcc = new ModuleConfigCommon();
        ModuleCommon mc = new ModuleCommon();
        #region 鼠标滑轮选中
        void tc_MouseWheel(object sender, MouseEventArgs e)
        {
            TabControl tc = sender as TabControl;
            int tabpage_cnt = tc.TabPages.Count;
            int new_i = (tc.SelectedIndex + Math.Sign(e.Delta)) % tabpage_cnt;
            if (new_i < 0)
            {
                new_i = new_i + tabpage_cnt;
            }
            tc.SelectedIndex = new_i;
        }
        #endregion
        #region 鼠标悬停选中
        private void tabControl_MouseMove(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(e.Location))
                {
                    //this.Text = tabControl1.TabPages[i].Name;
                    tc.SelectedIndex = i;
                    Console.WriteLine("选中TAB" + tc.SelectedIndex.ToString());
                    break;
                }
            }
        }
        #endregion
        public FrmJob()
        {
            InitializeComponent();


        }
        public FrmJob(int ParentId)
        {
            InitializeComponent();
            this.ParentId = ParentId;
            //新建的任务初始化几个标签
            InitLable();
            InitPluginList();

        }
        public FrmJob(ClassJob Job, int ParentId)
        {
            InitializeComponent();
            InitPluginList();
            this.ParentId = ParentId;
            this.Job = Job;
            ShowJob(Job.XmlData);

        }
        private string GetRuleType(GacXml.Rule rule)
        {
            string type = "";
            if (rule.DataSpider)
            {
                switch (rule.GetDataType)
                {
                    case 0: type = "前后截取"; break;
                    case 1: type = "正则提取"; break;
                    case 2: type = "可视化提取"; break;
                    case 3: type = "标签组合"; break;
                    case 4:
                        type = "正文提取";
                        if (rule.TextRecognitionType == 0)
                        {
                            type = "提取标题";
                        }
                        else if (rule.TextRecognitionType == 1)
                        {
                            type = "提取内容";
                        }
                        else if (rule.TextRecognitionType == 2)
                        {
                            type = "提取时间";
                        }
                        break;
                    default:
                        type = "未知类型" + rule.GetDataType;
                        break;
                }
            }
            else
            {
                string ManualType = "固定字符";
                switch (rule.ManualType)
                {
                    case 1: ManualType = "系统时间"; break;
                    case 2: ManualType = "随机字符"; break;
                    case 3: ManualType = "随机数字"; break;
                    case 5: ManualType = "时间戳"; break;
                    case 4: ManualType = "随机抽取"; break;
                    default:
                        break;
                }
                type = "固定-" + ManualType;
            }
            return type;
        }
        /// <summary>
        /// 存放标签列表
        /// </summary>
        Dictionary<string, LVRuleItem> dicLable = new Dictionary<string, LVRuleItem>();
        private void ShowJob(string Xml)
        {
            //QueryXml qx = new QueryXml();
            //ClassTaskXml taskxml = qx.queryConfig(Xml);

            XmlHelper xh = new XmlHelper();

            GacXml.GacJob taskxml = xh.XmlToEntity<GacXml.GacJob>(Xml);
            btnSave.Tag = taskxml;
            this.Text = "编辑任务　　" + taskxml.JobName;
            txtJobName.Text = taskxml.JobName; ;
            cmbEncoding.Text = taskxml.Encdoing;


            #region 第一步配置读取
            txtRemarks.Text = taskxml.Bak;
            txtLoginCookies.Text = taskxml.Cookie;
            txtUserAgent.Text = taskxml.UserAgent;


            chkCheckUrl.Checked = taskxml.CheckUrlRepeat;
            //chkMultilevelURLTestOne.Checked = taskxml.MultipleURLTestFirst;
            nudUrlRepeatCount.Value = Convert.ToInt32(taskxml.UrlRepeat);
            //读取起始网址
            foreach (string item in taskxml.StartAddress)
            {
                lbUrl1.Items.Add(item);
            }
            foreach (var item in taskxml.StepAddressCollection)
            {
                ShowStepAddress(item);
            }
            #endregion

            #region 第二步配置读取
            if (taskxml.SuperJobCollection != null)
            {
                SuperJob supjob = taskxml.SuperJobCollection[0];
                rbPagesUrlListAll.Checked = supjob.PagesUrlListAll;
                rtbePagesAreaStart.TextValue = supjob.PagesAreaStart;
                rtbePagesAreaEnd.TextValue = supjob.PagesAreaEnd;
                rbGetPagesUrlAuto.Checked = supjob.GetPagesUrlAuto;
                txtPagesJoinCode.Text = supjob.PagesJoinCode;
                rtbePagesStyle.TextValue = supjob.PagesStyle;
                rtbePagesCombine.TextValue = supjob.PagesCombine;
                nudMaxPages.Value = supjob.MaxPages;

                if (taskxml.SuperJobCollection[0].TestPageUrls != null)
                {
                    for (int i = 0; i < taskxml.SuperJobCollection[0].TestPageUrls.Count; i++)
                    {
                        cmbTestPageUrls.Items.Add(taskxml.SuperJobCollection[0].TestPageUrls[i]);
                    }
                    if (cmbTestPageUrls.Items.Count > 0)
                    {
                        cmbTestPageUrls.SelectedIndex = 0;
                    }
                }
            }


            for (int i = 0; i < taskxml.SortLabel.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(new string[] { taskxml.SortLabel[i], "" });
                lvi.Name = taskxml.SortLabel[i];
                lvLable.Items.Add(lvi);
            }
            for (int i = 0; i < taskxml.SuperJobCollection.Count; i++)
            {
                for (int i2 = 0; i2 < taskxml.SuperJobCollection[i].RuleCollection.Count; i2++)
                {
                    GacXml.Rule rule = taskxml.SuperJobCollection[i].RuleCollection[i2];
                    LVRuleItem lvri = new LVRuleItem() { RuleName = rule.LabelName, PageName = taskxml.SuperJobCollection[i].PageName, Rule = rule };
                    if (lvLable.Items.ContainsKey(rule.LabelName))
                    {
                        lvLable.Items[rule.LabelName].Tag = lvri;
                        dicLable.Add(rule.LabelName, lvri);

                        string type = GetRuleType(rule);
                        lvLable.Items[rule.LabelName].SubItems[1].Text = type;
                    }




                }
                if (taskxml.SuperJobCollection[i].MultPagesCollection != null)
                {
                    for (int i2 = 0; i2 < taskxml.SuperJobCollection[i].MultPagesCollection.Count; i2++)
                    {
                        if (taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].RuleCollection != null)
                        {
                            for (int i3 = 0; i3 < taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].RuleCollection.Count; i3++)
                            {
                                GacXml.Rule rule = taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].RuleCollection[i3];
                                LVRuleItem lvri = new LVRuleItem() { RuleName = rule.LabelName, PageName = taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].PageName, Rule = rule };
                                lvLable.Items[rule.LabelName].Tag = lvri;
                                dicLable.Add(rule.LabelName, lvri);

                                string type = GetRuleType(rule);
                                lvLable.Items[rule.LabelName].SubItems[1].Text = type;

                            }
                        }


                    }
                }

            }

            for (int i = 0; i < taskxml.ListLabelCollection.Count; i++)
            {
                if (taskxml.ListLabelCollection[i].RuleCollection == null)
                {
                    break;
                }
                for (int i2 = 0; i2 < taskxml.ListLabelCollection[i].RuleCollection.Count; i2++)
                {
                    GacXml.Rule rule = taskxml.ListLabelCollection[i].RuleCollection[i2];
                    LVRuleItem lvri = new LVRuleItem() { RuleName = rule.LabelName, Rule = rule };
                    lvLable.Items[rule.LabelName].Tag = lvri;
                    string type = "列表获取";
                    dicLableList.Add(rule.LabelName, "");
                    lvLable.Items[rule.LabelName].BackColor = Color.LightGray;
                    lvLable.Items[rule.LabelName].SubItems[1].Text = type;
                }
            }



            rtbePagesAreaStart.TextValue = taskxml.SuperJobCollection[0].PagesAreaStart;
            rtbePagesAreaEnd.TextValue = taskxml.SuperJobCollection[0].PagesAreaEnd;
            rbGetPagesUrlAuto.Checked = taskxml.SuperJobCollection[0].PagesUrlListAll;
            rtbePagesCombine.TextValue = taskxml.SuperJobCollection[0].PagesCombine;
            rtbePagesStyle.TextValue = taskxml.SuperJobCollection[0].PagesStyle;

            if (!taskxml.SuperJobCollection[0].GetPagesUrlAuto)
            {
                rbManualPaging.Checked = true;
                gbPagesCombine.Enabled = true;
                gbPagesStyle.Enabled = true;

            }
            nudMaxPages.Value = taskxml.SuperJobCollection[0].MaxPages;
            nudMaxSpiderPerNum.Value = taskxml.MaxSpiderPerNum;
            chkFillLoopWithFirst.Checked = taskxml.FillLoopWithFirst;
            rtbeLoopJoinCode.TextValue = taskxml.LoopJoinCode;
            rbLoopAddNewRecord.Checked = taskxml.LoopAddNewRecord;
            txtPagesJoinCode.Text = taskxml.SuperJobCollection[0].PagesJoinCode;
            btnMultPageChange.Tag = taskxml.SuperJobCollection[0].MultPagesCollection;


            //taskxml.SuperJobCollection[0].
            #endregion

            #region 第三步配置读取
            //发布到网站
            chkWebOutput.Checked = taskxml.UseWebOutput;
            foreach (var item in taskxml.JobWebPostCollection)
            {
                ClassModule cm= md.GetClassModule(item.WebPostId);
                if (cm != null)
                { 
                    ListViewItem lvitem = new ListViewItem(new string[] { cm.PostName, item.FName, item.Fid.ToString() });
                    lvitem.Tag = cm;
                    lvWebPost.Items.Add(lvitem);
                }
            }

            //发布方式
            switch (taskxml.WebOutType)
            {
                case 1: rbWebOutType1.Checked = true; break;
                case 2: rbWebOutType2.Checked = true; break;
                case 3: rbWebOutType3.Checked = true; break;
                default:
                    rbWebOutType0.Checked = true;
                    break;
            }

            //保存到文件
            chkFileOut.Checked = taskxml.UseFileOut; ;
            cmbFileType.SelectedIndex = taskxml.FileType;
            txtFileSavePath.Text = taskxml.FileSavePath;
            txtFileTemplate.Text = taskxml.FileTemplate;
            rtbeFilenNameType.TextValue = taskxml.FilenNameType;
            if (string.IsNullOrEmpty(taskxml.FileEncoding))
            {
                cmbFileEncoding.SelectedIndex = 0;
            }
            else
            {
                cmbFileEncoding.Text = taskxml.FileEncoding;
            }
            


            //发布到数据库
            foreach (var item in taskxml.JobDatabase)
            {
                //ListViewItem lvitem = new ListViewItem(new string[] { "未开发" });
                lvDatabase.Items.Add("数据库发布ID" + item);
            }


            //发布结束后
            chkFinishDeleteOutSucess.Checked = taskxml.FinishDeleteOutSucess;
            chkFinishDeleteOutFaild.Checked = taskxml.FinishDeleteOutFaild;
            chkFinishDeleteUrl.Checked = taskxml.FinishDeleteUrl;
            chkFinishSignOutSucess.Checked = taskxml.FinishSignOutSucess;

            //其他设置
            nudMaxOutPerNum.Value = taskxml.MaxOutPerNum;
            chkNotWebOutIfFileNoDownLoad.Checked = taskxml.NotWebOutIfFileNoDownLoad;
            chkSignSucessIfAllPost.Checked = taskxml.SignSucessIfAllPost;
            txtVisitUrlAfterEnd.Text = taskxml.VisitUrlAfterEnd;
            #endregion

            #region 文件保存及高级设置

            //任务运行时线程设置
            nudSpiderThreadNum.Value = taskxml.SpiderThreadNum;
            nudSpiderTimeInterval.Value = taskxml.SpiderTimeInterval;
            nudOutThreadNum.Value = taskxml.OutThreadNum;
            nudOutTimeStart.Value = taskxml.OutTimeStart;
            nudOutTimeEnd.Value = taskxml.OutTimeEnd;

            //http请求设置
            //HTTP请求--http代理
            switch (taskxml.ProxyType)
            {
                case 1: rbProxyType1.Checked = true; break;
                case 2: rbProxyType2.Checked = true; break;
                default:
                    rbProxyType0.Checked = true;
                    break;
            }
            txtProxyServer.Text = taskxml.ProxyServer;
            nudProxyPort.Value = taskxml.ProxyPort;
            txtProxyUsername.Text = taskxml.ProxyUsername;
            txtProxyPassword.Text = taskxml.ProxyPassword;
            //HTTP请求-windows身份验证
            chkUseCredentials.Checked = taskxml.UseCredentials;
            txtCredentialsUserName.Text = taskxml.CredentialsUserName;
            txtCredentialsPassword.Text = taskxml.CredentialsPassword;
            txtCredentialsDomain.Text = taskxml.CredentialsDomain;
            //HTTP请求-http请求
            if (taskxml.SuperJobCollection != null)
            {
                SuperJob supjob = taskxml.SuperJobCollection[0];
                txtAcceptLanguage.Text = supjob.AcceptLanguage;
                chkAutoDirect.Checked = supjob.AutoDirect;
                chkKeepAlive.Checked = supjob.KeepAlive;
                chkDeflate.Checked = supjob.Deflate;
                chkGzip.Checked = supjob.Gzip;
                nudTimeOut.Value = supjob.TimeOut;
            }

            //文件下载设置
            txtBaseFileDir.Text = taskxml.BaseFileDir;
            txtFileUploadDomain.Text = taskxml.FileUploadDomain;
            rbDownFileAsy.Checked = taskxml.DownFileAsy;
            nudMaxDownload.Value = taskxml.MaxDownload == 0 ? 3 : taskxml.MaxDownload;
            //nudMaxDownload.Value = taskxml.MaxDownload;
            nudDownloadSegments.Value = taskxml.DownloadSegments;
            taskxml.DownFileWithTools = chkDownFileWithTools.Checked;

            //插件
            if (!string.IsNullOrEmpty(taskxml.Plugin))
            {
                cmbPlugins.Text = taskxml.Plugin;
            }
            
            #endregion


        }

        //如果没有标签,初始化几个标签
        private void InitLable()
        {
            GacXml.Rule rule = new GacXml.Rule();
            rule.StartStr = "<title>";
            rule.EndStr = "</title>";
            rule.GetDataType = 0;
            rule.DataSpider = true;

            rule.LabelName = "标题";

            ListViewItem lvi = new ListViewItem(new string[] { rule.LabelName, "" });
            LVRuleItem lvri = new LVRuleItem() { RuleName = rule.LabelName, Rule = rule, PageName = "默认页" };
            lvi.SubItems[1].Text = GetRuleType(rule);
            lvi.Tag = lvri;
            lvLable.Items.Add(lvi);
            lvLable.Items[lvLable.Items.Count - 1].Name = lvri.RuleName;

            dicLable.Add(rule.LabelName, lvri);


            GacXml.Rule ruleContent = new GacXml.Rule();
            ruleContent.DataSpider = true;
            ruleContent.StartStr = "<(*)>";
            ruleContent.EndStr = "</html>";
            ruleContent.GetDataType = 0;
            ruleContent.LabelName = "内容";

            ListViewItem lviContent = new ListViewItem(new string[] { ruleContent.LabelName, "" });
            LVRuleItem lvriContent = new LVRuleItem() { RuleName = ruleContent.LabelName, Rule = ruleContent, PageName = "默认页" };
            lviContent.SubItems[1].Text = GetRuleType(ruleContent);
            lviContent.Tag = lvriContent;
            lvLable.Items.Add(lviContent);
            lvLable.Items[lvLable.Items.Count - 1].Name = lvriContent.RuleName;
            dicLable.Add(ruleContent.LabelName, lvriContent);


        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);
        private void FrmJob_Resize(object sender, EventArgs e)
        {
            LockWindowUpdate(this.Handle);
            #region 第一步大小重写
            gbMultipleURLRule.Width = tcMain.Width - 20; ;
            gbMultipleURLRule.Height = tcMain.Height - pStep1.Height - 20;
            gbStep1url1.Height = (tcMain.Height - pStep1.Height - 30) / 2;
            gbStep1url1.Width = tcMain.Width - 20;
            gbStep1url2.Height = (tcMain.Height - pStep1.Height - 30) / 2;
            gbStep1url2.Width = tcMain.Width - 20;
            gbStep1url2.Top = gbStep1url1.Location.X + gbStep1url1.Height + 10;
            //gbStep1url3.Width = tcMain.Width - 20;
            //gbStep1url4.Width= tcMain.Width - 20;
            pStep1.Width = tcMain.Width - 20;
            pStep1Remarks.Width = tcMain.Width - 20;
            pStep1.Top = gbStep1url2.Top + gbStep1url2.Height;
            #region 多级网址获取大小
            int tempheight = tbMultipleURL.SelectedTab.Height, tempwidth = tbMultipleURL.SelectedTab.Width;
            if (Height <= 753)
            {
                gbMultipleURLRegion.Height = tempheight - gbMultipleURLRegion.Top - 10;
                gbResultFilter.Width = 457;
                gbMultipleURLRegion.Width = gbMultipleURLRule.Width - 34 - gbResultFilter.Width;
                gbResultFilter.Top = gbMultipleURLRegion.Top;
                gbResultFilter.Left = gbMultipleURLRegion.Left + gbMultipleURLRegion.Width + 7;

                // gbResultFilter.Height = gbMultipleURLRegion.Height;
            }
            else
            {
                gbMultipleURLRegion.Height = tempheight - gbMultipleURLRegion.Top - 125;
                gbMultipleURLRegion.Width = tempwidth - gbMultipleURLRegion.Left - 10;
                gbResultFilter.Top = gbMultipleURLRegion.Top + gbMultipleURLRegion.Height + 10;
                gbResultFilter.Left = gbMultipleURLRegion.Left;
                gbResultFilter.Width = tempwidth - gbResultFilter.Left - 10;
            }
            gbPageGet.Width = (tempwidth - 30) / 2;
            gbPageGet.Height = tempheight - 47;
            gbCombination.Width = gbPageGet.Width;
            gbCombination.Left = gbPageGet.Left + gbPageGet.Width + 10;
            rtbeListPageStart.Height = (gbPageGet.Height - 35) / 2;
            rtbeListPageEnd.Height = rtbeListPageStart.Height;
            rtbeListPageEnd.Top = rtbeListPageStart.Height + rtbeListPageStart.Top + 5;
            label18.Top = rtbeListPageEnd.Top;
            ucLableText12.Top = label18.Top + label18.Height + 8;

            rtbeUrlStart.Height = rtbeUrlEnd.Height = (gbMultipleURLRegion.Height - 30) / 2;
            rtbeUrlEnd.Top = rtbeUrlStart.Top + rtbeUrlStart.Height + 8;
            label8.Top = rtbeUrlEnd.Top;
            ucLableText2.Top = label8.Top + label8.Height + 7;

            rtbeRandValueStart.Height = (pRandValue.Height - 50) / 2;
            rtbeRandValueEnd.Height = rtbeRandValueStart.Height;
            rtbeRandValueEnd.Top = rtbeRandValueStart.Height + rtbeRandValueStart.Top + 6;

            label26.Top = rtbeRandValueEnd.Top;
            ucLableText21.Top = label26.Top + label26.Height + 15;

            #endregion

            gbUrlStatus.Left = (tvUrlRule.Width - gbUrlStatus.Width) / 2;
            gbUrlStatus.Top = (tvUrlRule.Height - gbUrlStatus.Height) / 2;
            #endregion
            LockWindowUpdate((System.IntPtr)0);
        }

        private void FrmJob_Load(object sender, EventArgs e)
        {
            cmbEncoding.SelectedIndex = 0;
            cmbFileType.SelectedIndex = 0;
            tbMultipleURL.MouseMove += tabControl_MouseMove;

            dlf.ThreadNum = 3;//线程数，不设置默认为3
            dlf.doSendMsg += SendMsgHander;//下载过程处理事件
            LableEnabledInit();
            InitMenu();


        }
        private void InitPluginList()
        {
            cmbPlugins.Items.Clear();
            cmbPlugins.Items.Add("不使用");
            string[] files = Directory.GetFiles (Path.PluginDIr, "*.dll");
            foreach (var item in files)
            {
                string filename = System.IO.Path.GetFileNameWithoutExtension(item);
                cmbPlugins.Items.Add(filename);
            }
            cmbPlugins.SelectedIndex = 0;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBrowser wftm = new FrmBrowser();
            wftm.getFlag = 0;
            wftm.txtUrl.Text = GetStartAddress();
            //wftm.rCookie = new frmBrowser.ReturnCookie(GetCookie);
            if (wftm.ShowDialog() == DialogResult.OK)
            {
                txtLoginCookies.Text = wftm.Tag.ToString();
            }
            wftm.Dispose();
        }
        #region 多级网址处理
        private void btnStep1UrlAdd_Click(object sender, EventArgs e)
        {
            FrmUrlAdd frmurladd = new FrmUrlAdd();
            if (frmurladd.ShowDialog() == DialogResult.OK)
            {
                List<string> list = (List<string>)frmurladd.Tag;
                for (int i = 0; i < list.Count; i++)
                {
                    lbUrl1.Items.Add(list[i]);
                }
            }
        }

        private void rbGetUrlAtuo_CheckedChanged(object sender, EventArgs e)
        {
            pUrlManual.Visible = pUrlXpath.Visible = false;
            if (rbGetUrlManualFillRule.Checked)
            {
                pUrlManual.Visible = true;
            }
            else if (rbGetUrlForXpath.Checked)
            {
                pUrlXpath.Visible = true;
            }
        }

        private void btnGetXpath_Click(object sender, EventArgs e)
        {
            FrmBrowser wftm = new FrmBrowser();

            wftm.txtUrl.Text = GetStartAddress();
            wftm.getFlag = 4;
            wftm.txtXpath.Text = txtUrlXpath.Text;
            //wftm.rCookie = new frmBrowser.ReturnCookie(GetCookie);
            if (wftm.ShowDialog() == DialogResult.OK)
            {
                txtUrlXpath.Text = wftm.Tag.ToString();
            }
            wftm.Dispose();
        }
        private string GetStartAddress()
        {
            if (lbUrl1.Items.Count > 0)
            {
                UrlCommon urlcommon = new UrlCommon();
                List<string> list = urlcommon.GetUrlList(lbUrl1.Items[0].ToString());
                if (list.Count > 0)
                {
                    return list[0];
                }
            }
            return "";

        }

        private void rbPost_CheckedChanged(object sender, EventArgs e)
        {
            gbPostOption.Visible = rbPost.Checked;
        }
        private void ClearMultipleURLRule()
        {
            rbGetUrlAtuo.Checked = true;
            chkAutoGetPage.Checked = true;
            rbGet.Checked = true;
            txtUrlXpath.Text = rtbeUrlScriptRule.TextValue = rtbxUrlResult.TextValue = rtbeUrlStart.TextValue = rtbeUrlEnd.TextValue = rtbeUrlContain.TextValue = rtbeUrlNotContain.TextValue = rtbePostData.TextValue = rtbeListPageStart.TextValue = rtbeListPageEnd.TextValue = rtbeListPageUrlStyle.TextValue = rtbeListPageStyle.TextValue = rtbeAdditionalparameter.TextValue;
            nudPostStart.Value = 1;

            nudPostEnd.Value = 5;
            nudPagesMax.Value = 0;


            lvPost.Items.Clear();
            tbMultipleURL.SelectedIndex = 0;
            gbMultipleURLRule.Visible = false;
        }
        //当前正在编辑的规则,如果等于-1则为新增
        int MultipleURLRule = -1;

        /// <summary>
        /// 保存规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveUrlRule_Click(object sender, EventArgs e)
        {
            string repeat = "";

            //全部附加参数
            string Additionalparameter = "";
            //脚本规则
            string ScriptRule = "";
            for (int i = 0; i < lvMultilevelURL.Items.Count; i++)
            {
                if (i!=MultipleURLRule)
                {
                    StepAddress stepaddress = (StepAddress)lvMultilevelURL.Items[i].Tag;
                    Additionalparameter += stepaddress.AddLabel;
                    ScriptRule += stepaddress.ManualUrlStyle;
                }
               
            }


            List<string> listResult = new List<string>();
            //附加参数-参数提取方式 标签重复校验
            List<string> listlables = vh.GetLables(rtbeAdditionalparameter.TextValue+ Additionalparameter);
            foreach (var item in listlables)
            {
                if (dicLable.ContainsKey(item))
                {
                    if (!string.IsNullOrEmpty(repeat))
                    {
                        repeat += ",";
                    }
                    repeat += item;
                }
            }
            ListAddList(ref listResult, listlables);
            if (!string.IsNullOrEmpty(repeat))
            {
                GacCommon.ShowTip("标签已存在：" + repeat, rtbeAdditionalparameter);
                return;
            }


            //手动填写链接地址规则-脚本规则 标签重复校验
            listlables = vh.GetLables(rtbeUrlScriptRule.TextValue+ ScriptRule);
            ListAddList(ref listResult, listlables);
            foreach (var item in listlables)
            {
                if (dicLable.ContainsKey(item))
                {
                    if (!string.IsNullOrEmpty(repeat))
                    {
                        repeat += ",";
                    }
                    repeat += item;
                }
            }
            if (!string.IsNullOrEmpty(repeat))
            {
                GacCommon.ShowTip("标签已存在：" + repeat, rtbeUrlScriptRule);
                return;
            }





            //手动填写链接地址规则-实际链接 不存在标签检测
            List<string> listlablesReuslt = vh.GetLables(rtbxUrlResult.TextValue);
            ListAddList(ref listResult, listlablesReuslt);
            foreach (var item in listlablesReuslt)
            {
                if (!listlables.Contains(item))
                {
                    if (!string.IsNullOrEmpty(repeat))
                    {
                        repeat += ",";
                    }
                    repeat += item;
                }
            }
            if (!string.IsNullOrEmpty(repeat))
            {
                GacCommon.ShowTip("您调用了标签不存在的标签：" + repeat, rtbxUrlResult);
                return;
            }

            ListLableChange(listResult);

            SaveStepAddress();
            ClearMultipleURLRule();


        }
        private void ListLableChange(List<string> listlables)
        {
            foreach (var item in listlables)
            {
                if (!dicLableList.ContainsKey(item))
                {
                    LVRuleItem lvri = new LVRuleItem() { RuleName = item, Rule=new GacXml.Rule() {  LabelName=item} };
                    //dicLable.Add(item, lvri);

                    ListViewItem lvi = new ListViewItem(new string[] { item, "" });
                    lvi.Name = item;
                    lvLable.Items.Add(lvi);

                    lvLable.Items[item].Tag = lvri;
                    string type = "列表获取";
                    dicLableList.Add(item, "");
                    lvLable.Items[item].BackColor = Color.LightGray;
                    lvLable.Items[item].SubItems[1].Text = type;

                }
            }
            String[] keyArr = dicLableList.Keys.ToArray<String>();
            foreach (var item in keyArr)
            {
               
               
                    bool isok = false;
                    foreach (var item1 in listlables)
                    {
                        if (item1 == item)
                        {
                            isok = true; break;
                        }
                    }
                    if (!isok)
                    {
                        lvLable.Items.RemoveByKey(item);
                        dicLableList.Remove(item);

                    }
                
               
            }
        }
        private void ListAddList(ref List<string> OldList, List<string> NewList)
        {
            foreach (var item in NewList)
            {
                OldList.Add(item);
            }
        }
        private void ShowStepAddress(StepAddress stepaddress)
        {
            string gettype = "自动提取";
            string httpmethod = "Get";
            if (stepaddress.GetUrlType == 1)
            {
                gettype = "手动获取";
            }
            else if (stepaddress.GetUrlType == 2)
            {
                gettype = "Xpath";
            }
            if (stepaddress.HttpMethod == 1)
            {
                httpmethod = "Post";
            }
            else if (stepaddress.HttpMethod == 2)
            {
                httpmethod = "AspXPost";
            }

            if (MultipleURLRule >= 0 && MultipleURLRule < lvMultilevelURL.Items.Count)
            {
                //编辑已存在的多级网址获取
                lvMultilevelURL.Items[MultipleURLRule] = new ListViewItem(new string[] { gettype, httpmethod, stepaddress.UrlAreaStart, stepaddress.UrlAreaEnd, stepaddress.UrlMust, stepaddress.UrlForbid, stepaddress.PagesUrlStyle });
                lvMultilevelURL.Items[MultipleURLRule].Tag = stepaddress;
            }
            else
            {


                //新增多级网址获取
                ListViewItem lvi = lvMultilevelURL.Items.Add(new ListViewItem(new string[] { gettype, httpmethod, stepaddress.UrlAreaStart, stepaddress.UrlAreaEnd, stepaddress.UrlMust, stepaddress.UrlForbid, stepaddress.PagesUrlStyle }));
                lvi.Tag = stepaddress;
            }
            MultipleURLRule = -1;
        }
        private void SaveStepAddress()
        {
            StepAddress stepaddress = new StepAddress();
            stepaddress.UrlAreaStart = rtbeUrlStart.TextValue;
            stepaddress.UrlAreaEnd = rtbeUrlEnd.TextValue;
            stepaddress.UrlMust = rtbeUrlContain.TextValue;
            stepaddress.UrlForbid = rtbeUrlNotContain.TextValue;
            stepaddress.PostData = rtbePostData.TextValue;
            stepaddress.PostStart = (int)nudPostStart.Value;
            stepaddress.PostEnd = (int)nudPostEnd.Value;
            stepaddress.HttpMethod = (rbGet.Checked ? 0 : (rbPost.Checked ? 1 : 2));
            stepaddress.AutoPages = chkAutoGetPage.Checked;
            stepaddress.ManualUrlStyle = rtbeUrlScriptRule.TextValue;
            stepaddress.ManualUrlCompile = rtbxUrlResult.TextValue;
            stepaddress.XpathContent = txtUrlXpath.Text;
            stepaddress.PagesAreaStart = rtbeListPageStart.TextValue;
            stepaddress.PagesAreaEnd = rtbeListPageEnd.TextValue;
            stepaddress.PagesUrlStyle = rtbeListPageUrlStyle.TextValue;
            stepaddress.PagesUrlCompile = rtbeListPageStyle.TextValue;
            stepaddress.PagesMax = (int)nudPagesMax.Value;
            stepaddress.AddLabel = rtbeAdditionalparameter.TextValue;
            stepaddress.GetUrlType = (rbGetUrlAtuo.Checked ? 0 : rbGetUrlManualFillRule.Checked ? 1 : 2);

            stepaddress.PostHashDicCollection = new List<PostHashDic>();




            for (int i = 0; i < lvPost.Items.Count; i++)
            {
                stepaddress.PostHashDicCollection.Add((PostHashDic)lvPost.Items[i].Tag);
            }

            ShowStepAddress(stepaddress);
        }
        /// <summary>
        /// 多级网址编辑
        /// </summary>
        private void InitStepAddress()
        {

            if (lvMultilevelURL.SelectedItems.Count == 1)
            {
                MultipleURLRule = lvMultilevelURL.SelectedIndices[0];
                StepAddress stepaddress = (StepAddress)lvMultilevelURL.SelectedItems[0].Tag;
                rtbeUrlStart.TextValue = stepaddress.UrlAreaStart;
                rtbeUrlEnd.TextValue = stepaddress.UrlAreaEnd;
                rtbeUrlContain.TextValue = stepaddress.UrlMust;
                rtbeUrlNotContain.TextValue = stepaddress.UrlForbid;
                rtbePostData.TextValue = stepaddress.PostData;
                nudPostStart.Value = Convert.ToInt32(stepaddress.PostStart);
                nudPostEnd.Value = Convert.ToInt32(stepaddress.PostEnd);
                rbGet.Checked = stepaddress.HttpMethod == 0;
                rbPost.Checked = stepaddress.HttpMethod == 1;
                rbAspXPost.Checked = stepaddress.HttpMethod == 2;
                chkAutoGetPage.Checked = stepaddress.AutoPages;
                rtbeUrlScriptRule.TextValue = stepaddress.ManualUrlStyle;
                rtbxUrlResult.TextValue = stepaddress.ManualUrlCompile;
                txtUrlXpath.Text = stepaddress.XpathContent;
                rtbeListPageStart.TextValue = stepaddress.PagesAreaStart;
                rtbeListPageEnd.TextValue = stepaddress.PagesAreaEnd;
                rtbeListPageUrlStyle.TextValue = stepaddress.PagesUrlStyle;
                rtbeListPageStyle.TextValue = stepaddress.PagesUrlCompile;
                nudPagesMax.Value = Convert.ToInt32(stepaddress.PagesMax);
                rtbeAdditionalparameter.TextValue = stepaddress.AddLabel;
                rbGetUrlAtuo.Checked = stepaddress.GetUrlType == 0;
                rbGetUrlManualFillRule.Checked = stepaddress.GetUrlType == 1;
                rbGetUrlForXpath.Checked = stepaddress.GetUrlType == 2;

                if (stepaddress.PostHashDicCollection != null && stepaddress.PostHashDicCollection.Count > 0)
                {
                    for (int i = 0; i < stepaddress.PostHashDicCollection.Count; i++)
                    {
                        ListViewItem lvi = lvPost.Items.Add(new ListViewItem(new string[] { stepaddress.PostHashDicCollection[i].Name, stepaddress.PostHashDicCollection[i].Key, stepaddress.PostHashDicCollection[i].Value }));
                        lvi.Name = stepaddress.PostHashDicCollection[i].Name;
                        lvi.Tag = stepaddress.PostHashDicCollection[i];
                    }

                }



                gbMultipleURLRule.Visible = true;

            }


        }


        private void btnCancelUrlRule_Click(object sender, EventArgs e)
        {
            ClearMultipleURLRule();
        }

        private void btnStep1MultilevelUrlClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清空所有多级网址？", "是否确认清空", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                lvMultilevelURL.Items.Clear();
            }

        }

        private void btnStep1MultilevelUrlDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除当前多级网址？", "是否确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                lvMultilevelURL.Items.Remove(lvMultilevelURL.SelectedItems[0]);
            }
        }

        private void lvMultilevelURL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMultilevelURL.SelectedItems.Count == 1)
            {
                btnStep1MultilevelEdit.Enabled = btnStep1MultilevelUrlDelete.Enabled = true;
            }
            else
            {
                btnStep1MultilevelEdit.Enabled = btnStep1MultilevelUrlDelete.Enabled = false;
            }
        }

        #region 起始网址操作
        private void lbUrl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUrl1.SelectedItems.Count == 1)
            {
                btnStep1UrlEdit.Enabled = btnStep1UrlDelete.Enabled = true;
            }
            else
            {
                btnStep1UrlEdit.Enabled = btnStep1UrlDelete.Enabled = false;
            }
        }

        private void btnStep1UrlClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清空所有起始网址？", "是否确认清空", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                lbUrl1.Items.Clear();
            }
        }

        private void btnStep1UrlDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除当前起始网址？", "是否确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                lbUrl1.Items.Remove(lbUrl1.SelectedItems[0]);
            }
        }
        private void lbUrl1_DoubleClick(object sender, EventArgs e)
        {
            InitStartAddress();
        }
        private void btnStep1UrlEdit_Click(object sender, EventArgs e)
        {
            InitStartAddress();
        }
        private void InitStartAddress()
        {
            if (lbUrl1.SelectedItems.Count == 1)
            {
                int selectIndex = lbUrl1.SelectedIndex;
                string url = lbUrl1.SelectedItem.ToString();
                FrmUrlAdd frm = new FrmUrlAdd(url);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    List<string> list = ((List<string>)frm.Tag);
                    if (list.Count == 1)
                    {
                        lbUrl1.Items[selectIndex] = list[0];
                    }
                    else
                    {
                        lbUrl1.Items.RemoveAt(selectIndex);
                        foreach (var item in list)
                        {
                            lbUrl1.Items.Insert(selectIndex, item);
                        }
                    }

                }


            }

        }
        #endregion

        private void btnStep1MultilevelUrlAdd_Click(object sender, EventArgs e)
        {
            gbMultipleURLRule.Visible = true;
        }

        private void lvMultilevelURL_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            InitStepAddress();
        }

        private void btnStep1MultilevelEdit_Click(object sender, EventArgs e)
        {
            InitStepAddress();
        }
        #endregion
        private void ClearRandValue()
        {
            rtbeRandValueStart.TextValue = "";
            rtbeRandValueEnd.TextValue = "";
            pRandValue.Visible = false;


        }
        private void InitPostData()
        {
            PostHashDic p = (PostHashDic)lvPost.SelectedItems[0].Tag;
            rtbeRandValueStart.TextValue = p.Key;
            rtbeRandValueEnd.TextValue = p.Value;
            pRandValue.Visible = true;
        }
        private void ucCloseButton2_Click(object sender, EventArgs e)
        {
            ClearRandValue();
        }

        private void ucCloseButton1_Click(object sender, EventArgs e)
        {
            ClearMultipleURLRule();
        }
        bool AddPost = false;
        private void btnPostValueAdd_Click(object sender, EventArgs e)
        {
            AddPost = true;
            pRandValue.Visible = true;
        }

        private void lvPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPost.SelectedItems.Count == 1)
            {
                btnPostValueEdit.Enabled = btnPostValueDelete.Enabled = true;
            }
            else
            {
                btnPostValueEdit.Enabled = btnPostValueDelete.Enabled = false;
            }
        }

        private void lvPost_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (lvPost.SelectedItems.Count == 1)
            {
                InitPostData();
            }
        }

        private void btnPostValueEdit_Click(object sender, EventArgs e)
        {
            if (lvPost.SelectedItems.Count == 1)
            {
                InitPostData();
            }
        }

        private void btnSaveRandValue_Click(object sender, EventArgs e)
        {
            PostHashDic phd = new PostHashDic();
            phd.Key = rtbeRandValueStart.TextValue; ;
            phd.Value = rtbeRandValueEnd.TextValue; ;
            ListViewItem lvi = null;
            if (lvPost.SelectedItems.Count == 1 && !AddPost)
            {
                phd.Name = ((PostHashDic)lvPost.SelectedItems[0].Tag).Name;
                lvi = lvPost.SelectedItems[0];
                lvi.SubItems[1].Text = phd.Key;
                lvi.SubItems[2].Text = phd.Key;
            }
            else
            {
                string name = "";
                int tempid = 1;
                do
                {
                    if (lvPost.Items.ContainsKey("[POST随机值" + tempid + "]"))
                    {
                        tempid++;
                        continue;
                    }
                    name = "[POST随机值" + tempid + "]"; break;

                } while (true);
                phd.Name = name;

                lvi = lvPost.Items.Add(new ListViewItem(new string[] { phd.Name, phd.Key, phd.Value }));
            }
            lvi.Tag = phd;
            AddPost = false;
            ClearRandValue();

        }

        private void btnCancelRandValue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbeRandValueStart.TextValue) || string.IsNullOrEmpty(rtbeRandValueEnd.TextValue))
            {
                MessageBox.Show("请完成填写开头和结尾！");
                return;
            }
            ClearRandValue();
        }

        private void btnPostValueDelete_Click(object sender, EventArgs e)
        {
            if (lvPost.SelectedItems.Count == 1 && MessageBox.Show("确认删除当前Post参数？", "是否确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                lvPost.Items.Remove(lvPost.SelectedItems[0]);
            }
        }
        public List<int> GetListIndex(string Index)
        {
            
                List<int> list = new List<int>();
                string[] strs = Index.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in strs)
                {
                    list.Add(Convert.ToInt32(item));
                }
                return list;
            
        }
        private void ConsoleUrls(List<KeyValuePair<string, Dictionary<string, string>>> list, bool IsParent)
        {
            Console.WriteLine("本列表共有网址" + list.Count + "条");
            for (int i = 0; i < list.Count; i++)
            {
                TreeNodeCollection nodes = tvUrlRule.Nodes;
                if (list[i].Value.ContainsKey("GAC当前层级"))
                {
                    List<int> ListIndex = GetListIndex(list[i].Value["GAC当前层级"]);
                    foreach (var item in ListIndex)
                    {
                        nodes = nodes[item].Nodes;
                    }

                }
               
                if (!this.IsDisposed)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        //if (chkCheckUrl.Checked ? !tvUrlRule.Nodes.ContainsKey(list[i].Url) : true)
                        //{
                        TreeNode nodetemp = nodes.Add(list[i].Value.ContainsKey("GAC提示文本")? list[i].Value["GAC提示文本"]: list[i].Key);
                        nodetemp.Tag = list[i].Value;
                        nodetemp.Name = list[i].Key;
                        nodetemp.ToolTipText = list[i].Key;
                        // listUrlinfo.Add(new Urlinfo(list[i].Url, nodetemp, list[i].Lable));
                        //}

                    });
                }
                


                Console.WriteLine(list[i]);
                if (list[i].Value.Count > 2)
                {
                    foreach (var item in list[i].Value)
                    {
                        if (item.Key!= "GAC当前层级"&&item.Key!= "GAC提示文本")
                        {
                            Console.WriteLine(item.Key + "：" + item.Value);
                        }
                       
                    }
                }
            }


        }
        //private void ConsoleUrls(List<SpiderUrlResult> list, List<Urlinfo> listUrlinfo, TreeNode node = null)
        //{
        //    Console.WriteLine("本列表共有网址" + list.Count + "条");
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (node != null)
        //        {
        //            this.Invoke((MethodInvoker)delegate ()
        //            {
        //                if (chkCheckUrl.Checked ? !tvUrlRule.Nodes.ContainsKey(list[i].Url) : true)
        //                {
        //                    TreeNode nodetemp = node.Nodes.Add(list[i].Url);
        //                    nodetemp.Tag = list[i].Lable;
        //                    nodetemp.Name = list[i].Url;
        //                    nodetemp.ToolTipText = list[i].Url;
        //                    listUrlinfo.Add(new Urlinfo(list[i].Url, nodetemp, list[i].Lable));
        //                }

        //            });

        //        }
        //        Console.WriteLine(list[i]);
        //        if (list[i].Lable.Count > 0)
        //        {
        //            foreach (var item in list[i].Lable)
        //            {
        //                Console.WriteLine(item.Key + "：" + item.Value);
        //            }
        //        }
        //    }


        //}
        private void SetUrlStatus(int Level, string Url, int Page = 0)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                lblStaus.Text = "正在下载并分析" + Level + "级网址" + (Page > 0 ? "第" + Page + "分页" : "") + "\r\n" + Url;
                Application.DoEvents();
            });

        }
        Thread thSpiderUrl = null;
        private void SetStatus(Dictionary<int, List<KeyValuePair<string, Dictionary<string, string>>>> dic)
        {
            //if (Number == 0)
            //{
            //    if (dic.ContainsKey(Level))
            //    {
            //        dic[Level]++;
            //    }
            //    else
            //    {
            //        dic.Add(Level, 1);
            //    }
            //}
            //else
            //{
            //    if (dic.ContainsKey(Level))
            //    {
            //        dic[Level]+=Number;
            //    }
            //    else
            //    {
            //        dic.Add(Level, Number);
            //    }
            //}
            StringBuilder sb = new StringBuilder();
            foreach (var item in dic)
            {
                //((List<SpiderUrlResult>)item.Value).Count
                sb.Append("获取到" + item.Key + "级网址" + item.Value.Count + "个 ");
            }
            if (!this.IsDisposed)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    lblCurrent.Text = sb.ToString();
                });
            }

        }

        RuleCommon spiderUrl = null;
        public void SpiderUrl()
        {
            bool testone = false;
            this.Invoke((MethodInvoker)delegate ()
            {
                testone = chkMultilevelURLTestOne.Checked;
            });
            GacJob job = GetGacJob();
            spiderUrl = new RuleCommon(job);
            spiderUrl.CountChang += SetStatus;
            spiderUrl.ShowUrls += ConsoleUrls;
            spiderUrl.UrlStatusChange += SetUrlStatus;
            spiderUrl.SpiderFinish += SpiderUrl_SpiderFinish;
            spiderUrl.Start(testone);

            /*
           
            RuleCommon rm = new RuleCommon(job);
            HttpRequestInfo requestInfo = rm.RequestInfo;
            // Dictionary<int, int> diccount = new Dictionary<int, int>();
            Dictionary<int, List<Urlinfo>> dicurl = new Dictionary<int, List<Urlinfo>>();
            UrlCommon url = new UrlCommon();
            // List<string> listUrl = new List<string>();
            dicurl.Add(0, new List<Urlinfo>());
            for (int i = 0; i < lbUrl1.Items.Count; i++)
            {
                List<string> listtemp = url.GetUrlList(lbUrl1.Items[i].ToString());
                for (int i2 = 0; i2 < listtemp.Count; i2++)
                {
                    dicurl[0].Add(new Urlinfo(listtemp[i2]));
                    //   listUrl.Add(listtemp[i2]);
                }
            }
            SpiderUrl su = null;
            List<StepAddress> listStepAddress = new List<StepAddress>();
            bool testone = false;
            this.Invoke((MethodInvoker)delegate ()
            {
                testone = chkMultilevelURLTestOne.Checked;
                su = new SpiderUrl(requestInfo);
               
                    for (int i2 = 0; i2 < lvMultilevelURL.Items.Count; i2++)
                    {
                        StepAddress stepAddress = (StepAddress)lvMultilevelURL.Items[i2].Tag;
                        listStepAddress.Add(stepAddress);
                    }
                
                
            });

            for (int i2 = 0; i2 < listStepAddress.Count; i2++)
            {
                List<TreeNode> listnode = new List<TreeNode>();
                dicurl.Add(i2 + 1, new List<Urlinfo>());

                for (int i = 0; i < dicurl[i2].Count; i++)
                {

                    string currenturl = dicurl[i2][i].Url;
                    Dictionary<string, string> Parameter = new Dictionary<string, string>();
                    SetUrlStatus(0, currenturl);
                    string nexturl = "";
                    TreeNode node = null;
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        if (i2 == 0)
                        {
                            node = tvUrlRule.Nodes.Add(currenturl);
                            node.Name = currenturl;
                            dicurl[i2][i].Node = node;
                        }
                        else
                        {
                            node = dicurl[i2][i].Node;
                        }

                        node.ToolTipText = currenturl;
                        //SetStatus(dicurl);
                    });
                    StepAddress stepAddress = listStepAddress[i2];
                    Console.WriteLine(currenturl);
                    List<SpiderUrlResult> list = null;
                    if (stepAddress.HttpMethod == 1)
                    {
                        list = su.GetUrl(currenturl, stepAddress, ref Parameter, ref nexturl);
                    }
                    else
                    {
                        list = su.GetUrl(currenturl, stepAddress, ref Parameter, ref nexturl);
                    }
                    for (int l = 0; l < list.Count; l++)
                    {
                        foreach (var item in dicurl[i2][i].Lable)
                        {
                            list[l].Lable.Add(item.Key, item.Value);
                        }

                    }
                    if (string.IsNullOrEmpty(nexturl))
                    {
                        ConsoleUrls(list, dicurl[i2 + 1], dicurl[i2][i].Node);
                        SetStatus(dicurl);
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            string pageindex = "";
                            if (stepAddress.HttpMethod == 1)
                            {
                                pageindex = " [" + stepAddress.PostStart + "]";
                            }
                            TreeNode onenode = onenode = node.Nodes.Add(currenturl + pageindex);
                            onenode.ToolTipText = currenturl;
                            onenode.Name = currenturl;
                            ConsoleUrls(list, dicurl[i2 + 1], onenode);
                            SetStatus(dicurl);
                        });
                    }
                    while (!string.IsNullOrEmpty(nexturl) && !testone)
                    {

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
                        SetUrlStatus(i2, currenturlTemp, pagenum);
                        Console.WriteLine(currenturlTemp + pageindex);
                        nexturl = "";
                        list = su.GetUrl(currenturlTemp, stepAddress, ref Parameter, ref nexturl);
                        TreeNode onenode = null;
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            onenode = node.Nodes.Add(currenturlTemp + pageindex);
                            onenode.ToolTipText = currenturl;
                            onenode.Name = currenturl;

                        });
                        ConsoleUrls(list, dicurl[i2 + 1], onenode);
                        SetStatus(dicurl);

                    }
                    if (testone)
                    {
                        break;
                    }
                }
            }
            if (listStepAddress.Count == 0)
            {

               
                for (int i = 0; i < dicurl[0].Count; i++)
                {
                    List<SpiderUrlResult> list = new List<SpiderUrlResult>();
                    string currenturl = dicurl[0][i].Url;
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        TreeNode node  = tvUrlRule.Nodes.Add(currenturl);
                        node.Name = currenturl;
                        dicurl[0][i].Node = node;
                        node.ToolTipText = currenturl;
                        //SetStatus(dicurl);
                    });
                  
                    list.Add(new SpiderUrlResult(currenturl));
                    ConsoleUrls(list, dicurl[0], dicurl[0][i].Node);
                    SetStatus(dicurl);
                }
                
            }
            {

            }
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                gbUrlStatus.Visible = false;

            });
            */
        }

        private void SpiderUrl_SpiderFinish()
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                gbUrlStatus.Visible = false;

            });
        }
        // 测试网址采集
        private void button1_Click(object sender, EventArgs e)
        {

            thSpiderUrl = new Thread(new ThreadStart(SpiderUrl));
            gbUrlStatus.Visible = true;
            gbUrlTest.Visible = true;
            tvUrlRule.Nodes.Clear();
            thSpiderUrl.Start();
        }

        private void btnUrlStop_Click(object sender, EventArgs e)
        {
            //if (thSpiderUrl != null)
            //{
            //    thSpiderUrl.Abort();
            //}
            spiderUrl.Stop();
            gbUrlStatus.Visible = false;

        }

        private void btnCancelOption_Click(object sender, EventArgs e)
        {
            gbUrlTest.Visible = false;
        }

        private void btnUrlExportCurrentNode_Click(object sender, EventArgs e)
        {
            if (tvUrlRule.SelectedNode != null)
            {
                ExportNode(tvUrlRule.SelectedNode.Level);
            }
        }
        private void ExportNode(int Level)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> result = GetTreeViewNode(tvUrlRule.Nodes, Level);
                try
                {
                    System.IO.File.WriteAllLines(sfd.FileName, result.ToArray());
                    MessageBox.Show("成功保存" + Level + "级网址" + result.Count + "条", "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败！\r\n" + ex.Message, "保存失败了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        public List<string> GetTreeViewNode(TreeNodeCollection node, int Level)
        {
            List<string> list = new List<string>();
            foreach (TreeNode n in node)
            {
                if (n.Level == Level)
                {
                    //if (n.Tag is string)
                    //{
                    //    sb.AppendLine(n.Tag.ToString());
                    //}
                    //else
                    //{

                    //}
                    list.Add(n.ToolTipText.ToString());
                    continue;
                }
                List<string> listtemp = GetTreeViewNode(n.Nodes, Level);
                for (int i = 0; i < listtemp.Count; i++)
                {
                    list.Add(listtemp[i].ToString());
                }
            }
            return list;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gbUrlTest.Visible = true;
        }

        private void btnUrlExportRootNode_Click(object sender, EventArgs e)
        {
            ExportNode(0);
        }

        private void btnUrlExportFirst_Click(object sender, EventArgs e)
        {
            ExportNode(1);
        }

        private void btnUrlCopyUrl_Click(object sender, EventArgs e)
        {
            try
            {
                if (tvUrlRule.SelectedNode != null)
                {
                    Clipboard.SetText(tvUrlRule.SelectedNode.ToolTipText);
                    MessageBox.Show("网址已复制到剪辑版", "复制成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("复制失败\r\n" + EX.Message, "复制失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrlBrowse_Click(object sender, EventArgs e)
        {
            if (tvUrlRule.SelectedNode != null)
            {
                System.Diagnostics.Process.Start(tvUrlRule.SelectedNode.ToolTipText);
            }
        }

        private void btnUrlDelete_Click(object sender, EventArgs e)
        {
            if (tvUrlRule.SelectedNode != null)
            {
                tvUrlRule.Nodes.Remove(tvUrlRule.SelectedNode);
            }

        }

        private void btnUrlClaer_Click(object sender, EventArgs e)
        {
            tvUrlRule.Nodes.Clear();
        }

        private void ucCloseButton3_Click(object sender, EventArgs e)
        {
            gbUrlShow.Visible = false;
        }

        /// <summary>
        /// 列表标签的结果
        /// </summary>
        Dictionary<string, string> dicLableListTemp = new Dictionary<string, string>();
        private void tvUrlRule_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvUrlRule.SelectedNode != null && tvUrlRule.SelectedNode.Tag is Dictionary<string, string>)
            {

                dicLableListTemp = (Dictionary<string, string>)tvUrlRule.SelectedNode.Tag;
                if (dicLableListTemp.Count <= 0)
                {
                    return;
                }
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("【网 址】" + tvUrlRule.SelectedNode.ToolTipText);
                sb.AppendLine(" ------------------------------↓列表页标签↓--------------------------------");
                foreach (var item in dicLableListTemp)
                {
                    if (item.Key != "GAC当前层级" && item.Key != "GAC提示文本")
                    {
                        sb.AppendLine("【" + item.Key + "】" + item.Value);
                    }
                    
                }

                rtbeUrlShow.TextValue = sb.ToString();
                gbUrlShow.Visible = true;


            }
        }
        Dictionary<string, string> dicLableList = new Dictionary<string, string>();
        private void btnUrlTest_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> lables = (Dictionary<string, string>)tvUrlRule.SelectedNode.Tag;
            String[] keyStr = dicLableList.Keys.ToArray<String>();
            for (int i = 0; i < keyStr.Length; i++)
            {
                if (lables.ContainsKey(keyStr[i]))
                {
                    dicLableList[keyStr[i]] = lables[keyStr[i]];
                }
                else
                {
                    dicLableList[keyStr[i]] = "";
                }
            }
            tcMain.SelectedTab = tpLable;
            cmbTestPageUrls.Text = tvUrlRule.SelectedNode.ToolTipText;

        }

        private void tvUrlRule_DoubleClick(object sender, EventArgs e)
        {
            cmbTestPageUrls.Text = tvUrlRule.SelectedNode.ToolTipText;
            tcMain.SelectedTab = tpLable;
        }

        private void 清空测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmbTestPageUrls.Items.Clear();
        }

        private void rbGetPagesUrlAuto_CheckedChanged(object sender, EventArgs e)
        {
            gbPagesCombine.Enabled = gbPagesStyle.Enabled = !rbGetPagesUrlAuto.Checked;
        }

        private void btnMultPageChange_Click(object sender, EventArgs e)
        {
            GacJob job = GetGacJob();
            RuleCommon rulecommon = new RuleCommon(job);

            FrmMultiPage fmp = new FrmMultiPage(rulecommon.RequestInfo);
            fmp.Tag = btnMultPageChange.Tag;
            fmp.ShowDialog();
            btnMultPageChange.Tag = fmp.Tag;
        }

        private void FrmJob_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("关闭类型:" + e.CloseReason);
            if (e.CloseReason != CloseReason.None)
            {
                if (MessageBox.Show("您对任务进行了修改，确认放弃当前的修改?", "退出确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvLable_Click(object sender, EventArgs e)
        {
            Console.WriteLine("被点击了");
        }

        private void lvLable_DoubleClick(object sender, EventArgs e)
        {
            EditLable();
        }
        private void EditLable()
        {
            if (lvLable.SelectedItems.Count > 0)
            {
                LVRuleItem Rule = ((LVRuleItem)lvLable.SelectedItems[0].Tag);
                FrmLable fl = new FrmLable();
                fl.Tag = Rule;
                if (fl.ShowDialog(this) == DialogResult.OK)
                {
                    LVRuleItem RuleNew = (LVRuleItem)fl.Tag;
                    lvLable.Items[Rule.RuleName].Tag = RuleNew;
                    if (dicLable.ContainsKey(Rule.RuleName))
                    {
                        lvLable.Items[Rule.RuleName].Text = RuleNew.RuleName;
                        lvLable.Items[Rule.RuleName].SubItems[1].Text = GetRuleType(RuleNew.Rule);
                        lvLable.Items[Rule.RuleName].Name = RuleNew.RuleName;
                        if (Rule.RuleName == RuleNew.RuleName)
                        {
                            dicLable[RuleNew.RuleName] = RuleNew;
                        }
                        else
                        {
                            dicLable.Remove(Rule.RuleName);
                            dicLable.Add(RuleNew.RuleName, RuleNew);
                        }
                    }
                    else
                    {
                        
                    }
                    
                    InitMenu();
                }
            }
        }

        private void btnLabelEdit_Click(object sender, EventArgs e)
        {
            EditLable();
        }

        private void btnLabelAdd_Click(object sender, EventArgs e)
        {

            FrmLable fl = new FrmLable();
            if (fl.ShowDialog(this) == DialogResult.OK)
            {
                LVRuleItem Rule = (LVRuleItem)fl.Tag;


                ListViewItem lvi = new ListViewItem(new string[] { Rule.RuleName, "" });
                lvi.Name = Rule.RuleName;
                lvi.Tag = Rule;
                lvi.Text = Rule.RuleName;
                lvi.SubItems[1].Text = GetRuleType(Rule.Rule);
                lvi.Name = Rule.RuleName;
                lvLable.Items.Add(lvi);
                dicLable.Add(Rule.RuleName, Rule);
                InitMenu();
            }
        }

        private void btnLabelCopy_Click(object sender, EventArgs e)
        {

        }
        private void AddDownLog(string option, string url, string log)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                string msg = DateTime.Now.ToString() + " - " + option + "：" + url + "\t" + log + "\r\n";
                rtbDownLog.AppendText(msg);
            });
        }
        private void SetImageIndex(int index, string filename)
        {
            string suf = System.IO.Path.GetExtension(filename);
            if (!imageListFile.Images.ContainsKey(suf))
            {
                SystemIcon si = new SystemIcon();
                Icon ico = si.GetIcon(filename, true);
                imageListFile.Images.Add(suf, ico);
            }
            lvDown.Items[index].ImageKey = suf;
        }

        private void SendMsgHander(DownMsg msg)
        {
            if (!this.IsDisposed)
            {


                switch (msg.Tag)
                {
                    case DownStatus.Start:
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            string start = DateTime.Now.ToString();
                            lvDown.Items[msg.Id].SubItems[7].Text = "正在获取文件信息";
                            lvDown.Items[msg.Id].SubItems[6].Text = start;
                            AddDownLog("开始下载文件", msg.Url, "ID：" + msg.Id + " 开始时间：" + start);


                        });
                        break;
                    case DownStatus.GetLength:
                        this.Invoke((MethodInvoker)delegate ()
                        {

                            SetImageIndex(msg.Id, msg.Name);
                            //string suf=Path.GetExtension(msg.Name);
                            //if (!imageListFile.Images.ContainsKey(suf))
                            //{
                            //    SystemIcon si = new SystemIcon();
                            //    Icon ico = si.GetIcon(msg.Name);
                            //    imageListFile.Images.Add(suf, ico);
                            //}
                            //listView1.Items[msg.Id].ImageKey = suf;
                            string ResumeBrokenTransfer = msg.ResumeBrokenTransfer ? "支持" : "不支持";
                            dicdownfilse[msg.Id].SaveUrl += msg.Name;
                            dicdownfilse[msg.Id].ReplaceUrl = msg.Name;
                            lvDown.Items[msg.Id].SubItems[0].Text = msg.Name;
                            lvDown.Items[msg.Id].SubItems[1].Text = msg.LengthInfo;
                            lvDown.Items[msg.Id].SubItems[7].Text = "连接成功";
                            lvDown.Items[msg.Id].SubItems[8].Text = ResumeBrokenTransfer;
                            AddDownLog("连接地址成功", msg.Url, "文件大小 = " + msg.LengthInfo + ", 支持断点续传 = " + ResumeBrokenTransfer);
                        });
                        break;
                    case DownStatus.End:
                    case DownStatus.DownLoad:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                lvDown.Items[msg.Id].SubItems[2].Text = msg.SizeInfo;
                                lvDown.Items[msg.Id].SubItems[3].Text = msg.Progress.ToString() + "%";
                                lvDown.Items[msg.Id].SubItems[4].Text = msg.SurplusInfo;
                                lvDown.Items[msg.Id].SubItems[5].Text = msg.SpeedInfo;
                                if (msg.Tag == DownStatus.DownLoad)
                                {
                                    lvDown.Items[msg.Id].SubItems[7].Text = "下载中";
                                }
                                else
                                {
                                    lvDown.Items[msg.Id].SubItems[7].Text = "下载完成";
                                    AddDownLog("文件下载完成", msg.Url, "完成时间：" + DateTime.Now);
                                }
                                Application.DoEvents();
                            });
                        }));
                        break;
                    case DownStatus.Error:
                        if (this.IsHandleCreated)
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                lvDown.Items[msg.Id].SubItems[4].Text = "失败";
                                lvDown.Items[msg.Id].SubItems[7].Text = msg.ErrMessage;
                                AddDownLog("文件下载失败", msg.Url, msg.ErrMessage);
                                Application.DoEvents();
                            });
                        }
                        break;
                }
            }

        }
        Dictionary<int, DownInfo> dicdownfilse = new Dictionary<int, DownInfo>();
        Dictionary<int, KeyValuePair<string,string>> dicdownfile = new Dictionary<int, KeyValuePair<string, string>>();
        private void SetStaus(string PageName, string PageUrl, string MessageType = "请求页面")
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {

                    lblTsetJobStatus.Text = MessageType + "\t  " + PageName + "\r\n" + PageUrl;
                    Application.DoEvents();

                });
            }
        }
        private void SetStaus(string PageName, Control control, string MessageType = "请求页面")
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {

                    lblTsetJobStatus.Text = MessageType + "\t  " + PageName + "\r\n" + control.Text;
                    Application.DoEvents();

                });
            }
        }
        private void SetStaus(string Msg)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {

                    lblTsetJobStatus.Text = Msg;
                    Application.DoEvents();

                });
            }
        }
        DownLoadFile dlf = new DownLoadFile();
        VariableHelper vh = new VariableHelper();
        private void TestJob()
        {
            dlf.Clear();
            GacJob Job = GetGacJob();

            string url = "";
            this.Invoke((MethodInvoker)delegate () {
                url = cmbTestPageUrls.Text;
                rtbeTestResult.LableList = Job.SortLabel;

                lvDown.Items.Clear();
                dicdownfilse.Clear();
                
            });

            RuleCommon rule = new RuleCommon(Job);
            rule.LogAdd += AddTest;
            rule.StatusChange += SetStaus;

            //获取结果
            List<LableMergeInfo> list = rule.GetResult(url, dicLableListTemp);
            if (list.Count>0)
            {
                LableMergeInfo lmi = list[0];
                //Dictionary<string, string> dictemp = new Dictionary<string, string>();
                //foreach (var item in lmi.Dic)
                //{
                //    dictemp.Add(item.Name, item.Result);
                //}
                tsmiTestSend.Tag = lmi.Dic;
                for (int i = 0; i < list.Count; i++)
                {
                    foreach (var item in list[i].Dic)
                    {
                        AddTest(System.Environment.NewLine + "【" + item.Key + "】：" + item.Value);
                    }
                    if (list.Count > 1)
                    {
                        AddTest(System.Environment.NewLine + string.Format("███████████████第{0}条记录████████████████", i + 1));
                    }
                }



            }

            //处理下载
            //foreach (var item in list)
            //{
            //    foreach (var lable in item)
            //    {
            //        showdown(lable.downfileall);
            //    }
            //}
            //dlf.startdown(job.maxdownload == 0 ? 3 : job.maxdownload);

            foreach (var item in list)
            {

                ShowDown(item.Downfile);

                //foreach (var lable in item.)
                //{
                //    showdown(lable.downfileall);
                //}
            }
            dlf.StartDown(Job.MaxDownload == 0 ? 3 : Job.MaxDownload);


            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    rtbeTestResult.RichHighlight();
                    LockWindowUpdate((System.IntPtr)0);
                    gbTestJob.Visible = false;
                    btnTest.Enabled = true;
                    Application.DoEvents();
                });
            }

            /*
            string testurlfirst = "";
            dicdownfilse.Clear();
            bool LoopAddNewRecord = false;
            bool FillLoopWithFirst = false;
            System.Net.HttpWebRequest httprequest = null;
            rtbeTestResult.TextValue = "";
            Dictionary<string, HttpInfo> dichtml = new Dictionary<string, HttpInfo>();
            HttpCommon http = null;
            string LoopJoinCode = "";
            List<MultPages> listMultPages = null;
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {

                    gbTestJob.Visible = true;
                    btnTest.Enabled = false;
                    http = new HttpCommon(txtUserAgent.Text, txtLoginCookies.Text, cmbEncoding.Text);
                    testurlfirst = cmbTestPageUrls.Text;
                    LoopAddNewRecord = rbLoopAddNewRecord.Checked;
                    FillLoopWithFirst=chkFillLoopWithFirst.Checked;
                    LoopJoinCode = rtbeLoopJoinCode.TextValue.Replace("[换行]", "\r\n");
                    SetStaus("默认页", cmbTestPageUrls.Text);
                    rtbeTestResult.Rich.AppendText("请求页面 默认页 " + testurlfirst + "\r\n");
                    if (((GacXml.GacJob)Tag) != null)
                    {
                        listMultPages = ((GacXml.GacJob)Tag).SuperJobCollection[0].MultPagesCollection;
                    }
                    Application.DoEvents();

                });
            }
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                });
            }
            http.GetHttp(testurlfirst, ref httprequest);
            HttpInfo httpresult = http.GetHtml(httprequest);
            httpresult.Name = "默认页";
            if (httpresult.IsSuccess)
            {
                dichtml.Add(httpresult.Name, httpresult);
            }
            else
            {
                SetStaus("默认页", cmbTestPageUrls);
                AddTest("请求失败 默认页 " + testurlfirst + "\r\n");
                dichtml.Add(httpresult.Name, httpresult);
            }


            if (listMultPages != null)
            {

                for (int i = 0; i < listMultPages.Count; i++)
                {
                    try
                    {
                        string testurl = vh.GetMultUrl(testurlfirst, listMultPages[i].MultPageCollection[0]);
                        SetStaus(listMultPages[i].SuperJobCollection[0].PageName, testurl);
                        AddTest("请求页面 " + listMultPages[i].SuperJobCollection[0].PageName + " " + testurl + "\r\n");
                        http = new HttpCommon(listMultPages[i].SuperJobCollection[0].UserAgent, txtLoginCookies.Text, listMultPages[i].SuperJobCollection[0].PageEncoding);
                        http.GetHttp(testurl, ref httprequest);
                        httpresult = http.GetHtml(httprequest);
                        if (!httpresult.IsSuccess)
                        {
                            AddTest("获取网页内容失败，重试中请求页面 " + httpresult.Name + " " + httpresult.Url + " " + httpresult.StatusDescription + "\r\n");
                            SetStaus(listMultPages[i].SuperJobCollection[0].PageName, testurl, "获取网页内容失败，重试中请求页面");
                            http.GetHttp(testurl, ref httprequest);
                            httpresult = http.GetHtml(httprequest);
                        }
                        httpresult.Name = listMultPages[i].SuperJobCollection[0].PageName;
                        //html = http.GetHtml(testurl);
                        dichtml.Add(httpresult.Name, httpresult);
                        if (!httpresult.IsSuccess)
                        {
                            AddTest("请求失败 " + httpresult.Name + " " + httpresult.Url + " " + httpresult.StatusDescription + "\r\n");
                        }


                    }
                    catch (Exception ex)
                    {
                        AddTest("获取多页出错 " + listMultPages[i].SuperJobCollection[0].PageName + " " + ex.Message + "\r\n");
                    }
                }
            }




            SetStaus("正在处理标签，请稍后");
            AddTest("\r\n\r\n");
            List<string> listlable = new List<string>();
            Dictionary<string, LableMerge> diclable = new Dictionary<string, LableMerge>();
            FilterCommon fc = new FilterCommon();
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    RichTextBoxEx.LockWindowUpdate(rtbeTestResult.Handle);
                });
            }

            List<GacXml.Rule> listrule = new List<GacXml.Rule>();
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    for (int i = 0; i < lvLable.Items.Count; i++)
                    {
                        LVRuleItem rule = (LVRuleItem)lvLable.Items[i].Tag;
                        if (rule!=null)
                        {
                            listrule.Add(rule.Rule);
                        }
                       
                    }
                });
            }
            bool HaveLabelInCircle = false;
            int InCircleMaxCount = 0;
            for (int i = 0; i < listrule.Count; i++)
            {
                GacXml.Rule rule = listrule[i];
                RuleCommon rc = new RuleCommon(rule);
                listlable.Add(rule.LabelName);
                StringBuilder sbresult = new StringBuilder();
                List<string> listLable = new List<string>();
              
                if (lablelist.ContainsKey(rule.LabelName))
                {
                    sbresult.Append(lablelist[rule.LabelName]);
                    listLable.Add(lablelist[rule.LabelName]);
                }
                else
                {
                    string pagename = dicLable[rule.LabelName].PageName;
                    HttpInfo hi = dichtml[pagename];
                    Result result = rc.GetResult(hi, diclable);
                    List<DownInfo> listDown = new List<DownInfo>();
                    if (result.Success == true)
                    {
                        List<string> listfiles = new List<string>();
                        listLable = (List<string>)result.ResultObj;
                        for (int i2 = 0; i2 < listLable.Count; i2++)
                        {
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
                                lable = vh.FixUrl(dichtml[pagename].Url, lable);
                            }

                            if (rule.DownloadOtherFile || rule.OnlyFetchValidUrl || rule.DownloadImage)
                            {
                                listfiles = vh.GetLinks(lable);
                            }
                            Dictionary<string, DownInfo> dicfilestemp = new Dictionary<string, DownInfo>();
                            if (rule.DownloadOtherFile || rule.OnlyFetchValidUrl)
                            {
                                for (int filei = 0; filei < listfiles.Count; filei++)
                                {
                                    string oldurl = listfiles[filei];
                                    string newurl = oldurl;
                                    if (!dicfilestemp.ContainsKey(newurl))
                                    {

                                        http.GetLastUrl(ref newurl);
                                        listfiles[filei] = newurl;
                                        lable = lable.Replace(oldurl, newurl);
                                        DownInfo downinfo = new DownInfo() { ContentId = 0, PageUrl = dichtml[pagename].Url, PreUrl = oldurl, TrueUrl = newurl, Type = rule.LabelName };
                                        dicfilestemp.Add(newurl, downinfo);
                                        listDown.Add(downinfo);
                                    }

                                }
                            }
                            if (!rule.DownloadOtherFile && rule.DownloadImage)
                            {
                                http.ImageCheck(ref listDown);
                            }
                            if (!rule.DownloadOtherFile &&!rule.DownloadImage)
                            {
                                listfiles.Clear();
                                listDown.Clear();
                            }

                            //循环获取
                            if (rule.LabelInCircle)
                            {
                                HaveLabelInCircle = true;
                                sbresult.Append(lable + LoopJoinCode);
                            }

                            else
                            {
                                sbresult.Append(lable);
                                break;
                            }

                        }

                    }
                    if (listLable.Count>InCircleMaxCount)
                    {
                        InCircleMaxCount = listLable.Count;
                    }
                    diclable.Add(rule.LabelName, new LableMerge() { Name = rule.LabelName, Result = sbresult.ToString(), ResultList = listLable,DownFileList= listDown });
                    //if (!(LoopAddNewRecord && HaveLabelInCircle))
                    //{
                    //    AddTest(System.Environment.NewLine + "【" + rule.LabelName + "】：" + sbresult.ToString());
                    //}
                }


            }
            if ((LoopAddNewRecord && HaveLabelInCircle))
            {
                for (int i = 0; i < InCircleMaxCount; i++)
                {
                    foreach (var item in diclable)
                    {
                        string value = "";
                        if (item.Value.ResultList.Count > i)
                        {
                            value = item.Value.ResultList[i];
                        }
                        else
                        {
                            if (FillLoopWithFirst && item.Value.ResultList.Count > 0)
                            {
                                value = item.Value.ResultList[0];
                            }
                        }
                        AddTest(System.Environment.NewLine + "【" + item.Key + "】：" + value);
                        ShowDown(item.Value.DownFileList);
                    }
                    AddTest(System.Environment.NewLine + string.Format("███████████████第{0}条记录████████████████", i + 1));

                }
            }
            else
            {
                foreach (var item in diclable)
                {
                    
                    string value = item.Value.Result;
                    AddTest(System.Environment.NewLine + "【" + item.Key + "】：" + value);
                    ShowDown(item.Value.DownFileList);
                }
            }
            rtbeTestResult.LableList = listlable;
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    rtbeTestResult.RichHighlight();
                    LockWindowUpdate((System.IntPtr)0);
                    gbTestJob.Visible = false;
                    btnTest.Enabled = true;
                    Application.DoEvents();
                });
            }



            dlf.StartDown();
            */

        }

        private void ShowDown(List<DownInfo> DownFileList)
        {
            //string dir = System.Environment.GetEnvironmentVariable("TEMP") + "\\Gac\\DownLoad\\";
            if (!Directory.Exists(GacTEMPDir))
            {
                Directory.CreateDirectory(GacTEMPDir);
            }
            for (int filei = 0; filei < DownFileList.Count; filei++)
            {

                string newurl = DownFileList[filei].TrueUrl;
                string filedir = GacTEMPDir + DownFileList[filei].SaveUrl;
                filedir = filedir.Replace("/", "\\");
                if (!filedir.EndsWith("\\"))
                {
                    filedir += "\\";
                }
                if (!Directory.Exists(filedir))
                {
                    Directory.CreateDirectory(filedir);
                }

                if (dlf.Check(newurl))
                {
                    string filename = DownFileList[filei].ReplaceUrl;
                    //string filename = Path.GetFileName(newurl);
                    int id = 0;
                    if (this.IsHandleCreated)
                    {

                        this.Invoke((MethodInvoker)delegate ()
                        {

                            ListViewItem item = lvDown.Items.Add(new ListViewItem(new string[] { filename, "0", "0", "0%", "0", "0", DateTime.Now.ToString(), "等待中", "未获取", newurl, (lvDown.Items.Count + 1).ToString() }));
                            item.Tag = filedir + filename;
                            id = item.Index;
                            SetImageIndex(id, filename);
                        });
                    }

                    //dicfilestemp[oldurl].SaveUrl = GacTEMPDir;
                    dicdownfilse.Add(id, DownFileList[filei]);
                    //dicdownfilse.Add(id, dicfilestemp[oldurl]);
                    dlf.AddDown(newurl, filedir, id, filename);
                }

            }
        }
        /// <summary>
        /// 展示下载
        /// </summary>
        /// <param name="fieldandfiles">标签名[下载地址[保存路径,替换地址]]</param>
        private void ShowDown(Dictionary<string, Dictionary<string, KeyValuePair<string, string>>> dicDownFile)
        {
            //string dir = System.Environment.GetEnvironmentVariable("TEMP") + "\\Gac\\DownLoad\\";
            if (!Directory.Exists(GacTEMPDir))
            {
                Directory.CreateDirectory(GacTEMPDir);
            }
            //标签循环
            foreach (var itemlable in dicDownFile)
            {
                //所有下载地址循环
                foreach (var itemdown in itemlable.Value)
                {
                    string newurl = itemdown.Key;
                    string filedir = GacTEMPDir + itemdown.Value.Key;
                    filedir = filedir.Replace("/", "\\");
                    if (!filedir.EndsWith("\\"))
                    {
                        filedir += "\\";
                    }
                    if (!Directory.Exists(filedir))
                    {
                        Directory.CreateDirectory(filedir);
                    }

                    if (dlf.Check(newurl))
                    {
                        string filename = itemdown.Value.Value;
                        //string filename = Path.GetFileName(newurl);
                        int id = 0;
                        if (this.IsHandleCreated)
                        {

                            this.Invoke((MethodInvoker)delegate ()
                            {

                                ListViewItem item = lvDown.Items.Add(new ListViewItem(new string[] { filename, "0", "0", "0%", "0", "0", DateTime.Now.ToString(), "等待中", "未获取", newurl, (lvDown.Items.Count + 1).ToString() }));
                                item.Tag = filedir + filename;
                                id = item.Index;
                                SetImageIndex(id, filename);
                            });
                        }

                        //dicfilestemp[oldurl].SaveUrl = GacTEMPDir;
                        dicdownfilse.Add(id, new DownInfo() { SaveUrl=itemdown.Value.Key, ReplaceUrl=itemdown.Value.Value, PreUrl=itemdown.Key });
                        //dicdownfilse.Add(id, dicfilestemp[oldurl]);
                        dlf.AddDown(newurl, filedir, id, filename);
                    }
                }
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbTestPageUrls.Text))
            {
                MessageBox.Show("请填写测试网址！");
                return;
            }
            if (!cmbTestPageUrls.Items.Contains(cmbTestPageUrls.Text))
            {
                cmbTestPageUrls.Items.Insert(0, cmbTestPageUrls.Text);
            }

            rtbeTestResult.TextValue = "";
            gbTestJob.Visible = true;
            btnTest.Enabled = false;

            Thread th = new Thread(TestJob);
            th.Start();
            //TestJob();


        }
        private void AddTest(string msg)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    rtbeTestResult.Rich.AppendText(msg);
                });
            }
        }

        private void rtbDownLog_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFileSavePath.Text = fbd.SelectedPath;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择模板文件";
            ofd.Filter = "所有模板文件|*.txt;*.html;*.doc;*.csv;*.xls|文本文件|*.txt|Html文件|*.html|Word文件|*.doc|Csv文件|*.csv|Excel文件|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileTemplate.Text = ofd.FileName;
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\Extensions\\FileTemplate");
        }

        private void btnLabelDelete_Click(object sender, EventArgs e)
        {

            foreach (ListViewItem item in lvLable.SelectedItems)
            {
                if (dicLable.ContainsKey(item.Name))
                {
                    dicLable.Remove(item.Name);
                }
                lvLable.Items.Remove(item);
            }

        }
        private void LableEnabledInit()
        {
            if (lvLable.SelectedItems.Count > 0)
            {
                if (lvLable.SelectedItems.Count > 1)
                {
                    btnLabelEdit.Enabled = btnLabelCopy.Enabled = false;
                }
                else
                {
                    btnLabelEdit.Enabled = btnLabelCopy.Enabled = true;
                }
                btnLabelDelete.Enabled = true;
            }
            else
            {
                btnLabelEdit.Enabled = btnLabelCopy.Enabled = btnLabelDelete.Enabled = false;
            }
        }

        private void lvLable_SelectedIndexChanged(object sender, EventArgs e)
        {
            LableEnabledInit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJobName.Text))
            {
                tcMain.TabIndex = 0;
                GacCommon.ShowTip("任务名成不得为空", txtJobName); return;
            }
            if (lbUrl1.Items.Count <= 0)
            {
                tcMain.TabIndex = 0;
                GacCommon.ShowTip("起始网址不得为空", lbUrl1); return;
            }
            if(chkDownFileWithTools.Checked)
            {
               
                if (!string.IsNullOrEmpty(txtBaseFileDir.Text) &&!Directory.Exists(txtBaseFileDir.Text))
                {
                    tcMain.TabIndex = 3;
                    GacCommon.ShowTip("您选择了保存下载地址为html文件，您必须指定本地文件保存文件夹", txtBaseFileDir); return;
                }
                //
            }

            //文件发布各种判断
            if (chkFileOut.Checked)
            {
                string error = "您选择了发布到文件,";
                if (string.IsNullOrEmpty(txtFileSavePath.Text))
                {
                    tcMain.TabIndex = 3;
                    GacCommon.ShowTip(error+"文件模板不得为空", txtFileSavePath); return;
                }
                if (string.IsNullOrEmpty(txtFileSavePath.Text) || !Directory.Exists(txtFileSavePath.Text))
                {
                    tcMain.TabIndex = 3;
                    GacCommon.ShowTip(error + "保存位置为空或路径不存在", txtFileSavePath); return;
                }

            }

            if (rbProxyType2.Checked)
            {
                try
                {
                    WebProxy webproxy = new WebProxy(txtProxyServer.Text, (int)nudProxyPort.Value);
                }
                catch (Exception)
                {
                    tcMain.TabIndex = 3;
                    GacCommon.ShowTip("您选择了使用代理服务器，请填写代理服务器的详细情况", txtProxyServer); return;
                }
            }


            GacJob taskxml = GetGacJob();

            XmlHelper xml = new XmlHelper();
            string xmlCode = xml.EntityToXml<GacJob>(taskxml);
            if (this.Job != null)
            {
                ClassJob job = new ClassJob(taskxml.JobId, ParentId, taskxml.JobName, xmlCode, Job.SpiderUrl, Job.SpiderContent, Job.OutContent, true);
                this.Tag = job;
            }
            else
            {
                ClassJob job = new ClassJob(taskxml.JobId, ParentId, taskxml.JobName, xmlCode, false, false, false, true);
                this.Tag = job;
            }
            
            DialogResult = DialogResult.OK;

        }
        private GacJob GetGacJob()
        {

            GacJob taskxml = new GacJob();
            if (btnSave.Tag != null)
            {
                taskxml = (GacJob)btnSave.Tag;
                taskxml.JobId = Job.JobId;
            }

            this.Invoke((MethodInvoker)delegate ()
            {



                taskxml.JobName = txtJobName.Text;
                taskxml.Encdoing = cmbEncoding.Text;


                #region 第一步配置读取
                taskxml.Bak = txtRemarks.Text;
                taskxml.Cookie = txtLoginCookies.Text;
                taskxml.UserAgent = txtUserAgent.Text;
                taskxml.CheckUrlRepeat = chkCheckUrl.Checked;

                taskxml.UrlRepeat = Convert.ToInt32(nudUrlRepeatCount.Value);
                taskxml.StartAddress = GacCommon.ItemsToTList(lbUrl1.Items);
                taskxml.StepAddressCollection = GacCommon.ItemsToTList<StepAddress>(lvMultilevelURL.Items);
                #endregion

                #region 第二步配置读取

                if (taskxml.SuperJobCollection == null)
                {
                    taskxml.SuperJobCollection = new List<SuperJob>();
                    taskxml.SuperJobCollection.Add(new SuperJob() { PageName = "默认页", Level = 0, PageEncoding = "", PagesUrlListAll = rbPagesUrlListAll.Checked, PagesAreaStart = rtbePagesAreaStart.TextValue, PagesAreaEnd = rtbePagesAreaEnd.TextValue, GetPagesUrlAuto = rbGetPagesUrlAuto.Checked, PagesJoinCode = txtPagesJoinCode.Text, PagesStyle = rtbePagesStyle.TextValue, PagesCombine = rtbePagesCombine.TextValue, AcceptLanguage = txtAcceptLanguage.Text, UserAgent = txtUserAgent.Text });

                    //这些代码已经移动到第四步
                    //, AutoDirect = chkAutoDirect.Checked, KeepAlive = chkKeepAlive.Checked, TimeOut = (int)nudTimeOut.Value, MaxPages = (int)nudMaxPages.Value, Gzip = chkGzip.Checked, Deflate = chkDeflate.Checked
                }
                if (cmbTestPageUrls.Items.Count > 20)
                {
                    for (int i = cmbTestPageUrls.Items.Count - 1; i >= 20; i--)
                    {
                        cmbTestPageUrls.Items.RemoveAt(i);
                    }
                }
                taskxml.SuperJobCollection[0].TestPageUrls = GacCommon.ItemsToTList(cmbTestPageUrls.Items);

                taskxml.SortLabel = GacCommon.ItemsToTList(lvLable.Items);



                for (int i = 0; i < taskxml.SuperJobCollection.Count; i++)
                {
                    taskxml.SuperJobCollection[i].RuleCollection = (from u in dicLable
                                                                    let temp = u.Value.PageName == taskxml.SuperJobCollection[i].PageName
                                                                    select u.Value.Rule).ToList<GacXml.Rule>();


                    if (taskxml.SuperJobCollection[i].MultPagesCollection != null)
                    {

                        for (int i2 = 0; i2 < taskxml.SuperJobCollection[i].MultPagesCollection.Count; i2++)
                        {
                            taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].RuleCollection = (from u in dicLable
                                                                                                                          let temp = u.Value.PageName == taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].PageName
                                                                                                                          select u.Value.Rule).ToList<GacXml.Rule>();
                        }
                    }

                }

                taskxml.ListLabelCollection = new List<ListLabel>();
                List<GacXml.Rule> ListLabelCollection = new List<GacXml.Rule>();
                foreach (ListViewItem item in lvMultilevelURL.Items)
                {
                    StepAddress stepAddress = (StepAddress)item.Tag;
                    List<string> addLabel = vh.GetLables(stepAddress.AddLabel);
                    if (stepAddress.GetUrlType == 1)
                    {
                        List<string> addLabel2 = vh.GetLables(stepAddress.ManualUrlStyle);
                        foreach (var lable in addLabel2)
                        {
                            //ListLabelCollection.Add(new GacXml.Rule() { LabelName = lable });
                            addLabel.Add(lable);
                        }
                    }
                    foreach (var LableName in addLabel)
                    {
                        foreach (ListViewItem itemLable in lvLable.Items)
                        {
                            if (itemLable.SubItems[1].Text == "列表获取" && itemLable.Text == LableName)
                            {
                                ListLabelCollection.Add(((LVRuleItem)itemLable.Tag).Rule);
                            }
                        }
                    }
                }
                if (ListLabelCollection.Count > 0)
                {
                    taskxml.ListLabelCollection.Add(new ListLabel());
                    taskxml.ListLabelCollection[0].RuleCollection = ListLabelCollection;
                }
                taskxml.SuperJobCollection[0].PagesAreaStart = rtbePagesAreaStart.TextValue;
                taskxml.SuperJobCollection[0].PagesAreaEnd = rtbePagesAreaEnd.TextValue;
                taskxml.SuperJobCollection[0].PagesUrlListAll = rbGetPagesUrlAuto.Checked;
                taskxml.SuperJobCollection[0].PagesCombine = rtbePagesCombine.TextValue;
                taskxml.SuperJobCollection[0].PagesStyle = rtbePagesStyle.TextValue;

                if (!taskxml.SuperJobCollection[0].GetPagesUrlAuto)
                {
                    rbManualPaging.Checked = true;
                    gbPagesCombine.Enabled = true;
                    gbPagesStyle.Enabled = true;

                }
                taskxml.SuperJobCollection[0].MaxPages = (int)nudMaxPages.Value;
                taskxml.MaxSpiderPerNum = (int)nudMaxSpiderPerNum.Value;
                taskxml.FillLoopWithFirst = chkFillLoopWithFirst.Checked;
                taskxml.LoopAddNewRecord = rbLoopAddNewRecord.Checked;
                taskxml.LoopJoinCode = rtbeLoopJoinCode.TextValue;
                taskxml.SuperJobCollection[0].PagesJoinCode = txtPagesJoinCode.Text;
                taskxml.SuperJobCollection[0].MultPagesCollection = (List<MultPages>)btnMultPageChange.Tag;
                #endregion

                #region 第三步配置读取
                //发布到网站
                taskxml.UseWebOutput=chkWebOutput.Checked  ;
                taskxml.JobWebPostCollection.Clear();
                foreach (ListViewItem item in lvWebPost.Items)
                {
                    ClassModule cm =(ClassModule) item.Tag;
                    JobWebPost jwp = new JobWebPost()
                    {
                        WebPostId = cm.ID,
                        FName = item.SubItems[1].Text,
                        Fid = item.SubItems[2].Text

                    };
                    taskxml.JobWebPostCollection.Add(jwp);
                }

                //发布方式
                if (rbWebOutType1.Checked)
                {
                    taskxml.WebOutType = 1;
                }
                else if (rbWebOutType2.Checked)
                {
                    taskxml.WebOutType = 2;
                }
                else if (rbWebOutType3.Checked)
                {
                    taskxml.WebOutType = 3;
                }
                else
                {
                    taskxml.WebOutType = 0;
                }

                //保存到文件
                taskxml.UseFileOut = chkFileOut.Checked;
                taskxml.FileType = cmbFileType.SelectedIndex;
                taskxml.FileSavePath = txtFileSavePath.Text;
                taskxml.FileTemplate = txtFileTemplate.Text;
                taskxml.FilenNameType = rtbeFilenNameType.TextValue;
                taskxml.FileEncoding = cmbFileEncoding.Text;


                //发布到数据库
                foreach (var item in taskxml.JobDatabase)
                {
                    //ListViewItem lvitem = new ListViewItem(new string[] { "未开发" });
                    lvDatabase.Items.Add("数据库发布ID" + item);
                }


                //发布结束后
                taskxml.FinishDeleteOutSucess = chkFinishDeleteOutSucess.Checked;
                taskxml.FinishDeleteOutFaild = chkFinishDeleteOutFaild.Checked;
                taskxml.FinishDeleteUrl = chkFinishDeleteUrl.Checked;
                taskxml.FinishSignOutSucess = chkFinishSignOutSucess.Checked;
                //其他设置
                taskxml.NotWebOutIfFileNoDownLoad = chkNotWebOutIfFileNoDownLoad.Checked;
                taskxml.SignSucessIfAllPost = chkSignSucessIfAllPost.Checked;
                taskxml.MaxOutPerNum = (int)nudMaxOutPerNum.Value;
                taskxml.VisitUrlAfterEnd = txtVisitUrlAfterEnd.Text;
                #endregion


                #region 文件保存及高级设置

                //任务运行时线程设置
                taskxml.SpiderThreadNum = (int)nudSpiderThreadNum.Value;
                taskxml.SpiderTimeInterval = (int)nudSpiderTimeInterval.Value;
                taskxml.OutThreadNum = (int)nudOutThreadNum.Value;
                taskxml.OutTimeStart = (int)nudOutTimeStart.Value;
                taskxml.OutTimeEnd = (int)nudOutTimeEnd.Value;

                //http请求设置
                //HTTP请求--http代理
                if (rbProxyType1.Checked)
                {
                    taskxml.ProxyType = 1;
                }
                else if (rbProxyType2.Checked)
                {
                    taskxml.ProxyType = 2;
                }
                else
                {
                    taskxml.ProxyType = 0;
                }
                taskxml.ProxyServer = txtProxyServer.Text;
                taskxml.ProxyPort = (int)nudProxyPort.Value;
                taskxml.ProxyUsername = txtProxyUsername.Text;
                taskxml.ProxyPassword = txtProxyPassword.Text;
                //HTTP请求-windows身份验证
                taskxml.UseCredentials = chkUseCredentials.Checked;
                taskxml.CredentialsUserName = txtCredentialsUserName.Text;
                taskxml.CredentialsPassword = txtCredentialsPassword.Text;
                taskxml.CredentialsDomain = txtCredentialsDomain.Text;
                //HTTP请求-http请求

                taskxml.SuperJobCollection[0].AcceptLanguage = txtAcceptLanguage.Text;
                taskxml.SuperJobCollection[0].AutoDirect = chkAutoDirect.Checked;
                taskxml.SuperJobCollection[0].KeepAlive = chkKeepAlive.Checked;
                taskxml.SuperJobCollection[0].Deflate = chkDeflate.Checked;
                taskxml.SuperJobCollection[0].Gzip = chkGzip.Checked;
                taskxml.SuperJobCollection[0].TimeOut = (int)nudTimeOut.Value;


                //文件下载设置
                taskxml.BaseFileDir = txtBaseFileDir.Text;
                taskxml.FileUploadDomain = txtFileUploadDomain.Text;
                taskxml.DownFileAsy = rbDownFileAsy.Checked;
                taskxml.MaxDownload = (int)nudMaxDownload.Value;
                taskxml.DownloadSegments = (int)nudDownloadSegments.Value;
                chkDownFileWithTools.Checked = taskxml.DownFileWithTools;

                if (cmbPlugins.Text !="不使用")
                {
                    taskxml.Plugin = cmbPlugins.Text;
                }else
                {
                    taskxml.Plugin = "";
                }
                #endregion
            });

            return taskxml;


        }
        private void 在浏览器中查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(cmbTestPageUrls.Text);
        }
        ModuleConfigInfo mci = null;
        private void 测试Web发布数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvWebPost.Items.Count > 0)
            {
                if (tsmiTestSend.Tag==null|| !(tsmiTestSend.Tag is Dictionary<string,string>))
                {
                    MessageBox.Show("请先点击测试,获取标签结果后再点击发布", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (mci==null)
                {
                    ClassModule cm = (ClassModule)lvWebPost.Items[0].Tag;
                    mci = mcc.GetModuleConfigInfo(cm.XmlData);
                }
                ModuleInfo mi= mc.ReadModule(mci.ModuleName);

                OutWeb ow = new OutWeb(mi,mci);

                ReturnResult rr= ow.Out((Dictionary<string, string>)tsmiTestSend.Tag);
                FrmPostResult frp = new FrmPostResult(rr);
                frp.ShowDialog();
            } else
            {
                MessageBox.Show("您还没有添加web发布配置","操作失败",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
            


            
            
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDown.SelectedItems.Count > 0)
            {
                //string filename = Path.GetFileName(lvDown.SelectedItems[0].SubItems[9].Text);
                string filename = lvDown.SelectedItems[0].Tag.ToString();
                System.Diagnostics.Process.Start(filename);
            }
        }

        private void 拷贝地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDown.SelectedItems.Count > 0)
            {
                try
                {
                    string fileurl = lvDown.SelectedItems[0].SubItems[9].Text;
                    Clipboard.SetText(fileurl);
                }
                catch (Exception)
                {
                    MessageBox.Show("复制失败");
                }
            }


        }

        private void 打开目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(GacTEMPDir);
        }

        private void rbProxyType2_CheckedChanged(object sender, EventArgs e)
        {
            txtProxyServer.Enabled = txtProxyUsername.Enabled = txtProxyPassword.Enabled = nudProxyPort.Enabled = rbProxyType2.Checked;
        }

        private void btnBaseFileDirSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtBaseFileDir.Text = fbd.SelectedPath;
            }
        }

        private void chkFileOut_CheckedChanged(object sender, EventArgs e)
        {
            cmbFileType.Enabled = button14.Enabled = txtFileTemplate.Enabled = button15.Enabled = rtbeFilenNameType.Enabled = cmbFileEncoding.Enabled = picMenu2.Enabled = txtFileSavePath.Enabled= chkFileOut.Checked;
        }

        private void btnSortUp_Click(object sender, EventArgs e)
        {
            MovieItem(lvLable);
        }

        private void btnSortDown_Click(object sender, EventArgs e)
        {
            MovieItem(lvLable, false);
        }
        private void MovieItem(ListView lv, bool Up = true)
        {
            if (lv.SelectedItems!= null && lv.SelectedItems.Count == 1)
            {
                int index = lv.SelectedItems[0].Index;
                if ((Up && index != 0))
                {
                    index -= 1;
                } else if ((!Up && index != lv.Items.Count - 1))
                {
                    index += 1;
                } else
                {
                    return;
                }
                ListViewItem lvi = lv.SelectedItems[0];
                lv.SelectedItems[0].Remove(); 
                lv.Items.Insert(index, lvi);
            }
        }
        private void InitMenu()
        {
            if (lvLable.Items.Count>0)
            {
                if (cmsNameStyle.Items.Count>5)
                {
                    for (int i = cmsNameStyle.Items.Count-1; i >=5 ; i--)
                    {
                        cmsNameStyle.Items.RemoveAt(i);
                    }
                }

                foreach (ListViewItem item in lvLable.Items)
                {
                   ToolStripItem tsi= cmsNameStyle.Items.Add("[标签:" + item.SubItems[0].Text + "]");
                }


            }
        }

        private void btnLabelImport_Click(object sender, EventArgs e)
        {
            ModuleCommon mc = new ModuleCommon();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Web发布模块文件(*.gpm;*.wpm)|*.gpm;*.wpm";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ModuleInfo mi = mc.ReadModule(ofd.FileName);
                    List<string> listLable = mc.GetLables(mi);

                    foreach (var item in listLable)
                    {
                        if (!dicLable.ContainsKey(item)&&!dicLableList.ContainsKey(item))
                        {
                            GacXml.Rule ruleContent = new GacXml.Rule();
                            ruleContent.DataSpider = true;
                            ruleContent.StartStr = "";
                            ruleContent.EndStr = "";
                            ruleContent.GetDataType = 0;
                            ruleContent.LabelName = item;

                            ListViewItem lviContent = new ListViewItem(new string[] { ruleContent.LabelName, "" });
                            LVRuleItem lvriContent = new LVRuleItem() { RuleName = ruleContent.LabelName, Rule = ruleContent, PageName = "默认页" };
                            lviContent.SubItems[1].Text = GetRuleType(ruleContent);
                            lviContent.Tag = lvriContent;
                            lvLable.Items.Add(lviContent);
                            lvLable.Items[lvLable.Items.Count - 1].Name = lvriContent.RuleName;
                            dicLable.Add(ruleContent.LabelName, lvriContent);

                        }

                    }
                    MessageBox.Show("成功导入发布模块所用字段", "导入成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存标签名到一个txt";
            sfd.Filter = "文本文件|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (ListViewItem item in lvLable.Items)
                    {
                        sb.AppendLine("[标签:" + item.Text + "]");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("导出成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导出失败");
                }


            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("WebPostManager.exe");
        }

        private void btnModuleAdd_Click(object sender, EventArgs e)
        {
            FrmWebModule fwd = new FrmWebModule(md);
            if (fwd.ShowDialog()==DialogResult.OK)
            {
                ClassModule cm = (ClassModule)fwd.Tag;
                ListViewItem lvi = new ListViewItem(new string[] { cm.PostName,"",""});
                lvi.Tag = cm;
                lvWebPost.Items.Add(lvi);
            }
        }

        private void lvWebPost_SelectedIndexChanged(object sender, EventArgs e)
        {
             btnModuleEdit.Enabled = btnModuleDelete.Enabled = lvWebPost.SelectedItems != null && lvWebPost.SelectedItems.Count > 0;
        }

        private void btnModuleDelete_Click(object sender, EventArgs e)
        {
            if (lvWebPost.SelectedItems != null && lvWebPost.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvWebPost.SelectedItems)
                {
                    lvWebPost.Items.Remove(item);
                }
                
            }
            
        }
        private void EditWebCategory()
        {
            if (lvWebPost.SelectedItems != null && lvWebPost.SelectedItems.Count > 0)
            {
                FrmWebCategory fwc = new FrmWebCategory((ClassModule)lvWebPost.SelectedItems[0].Tag, lvWebPost.SelectedItems[0].SubItems[1].Text, lvWebPost.SelectedItems[0].SubItems[2].Text);
                if (fwc.ShowDialog()==DialogResult.OK)
                {
                    CategoryResult cr = (CategoryResult) fwc.Tag;
                    lvWebPost.SelectedItems[0].SubItems[1].Text = cr.Name;
                    lvWebPost.SelectedItems[0].SubItems[2].Text = cr.ID;

                }
            }

        }
        private void btnModuleEdit_Click(object sender, EventArgs e)
        {
            EditWebCategory();
        }

        private void lvWebPost_DoubleClick(object sender, EventArgs e)
        {
            EditWebCategory();
        }
    }
}
