using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GacXml;
using System.Text.RegularExpressions;
using System.IO;
using Gac;
using GacBrowser;

namespace GAC_Collection.MainUi.Task
{
    public partial class FrmLable : Form
    {
        public FrmLable()
        {
            InitializeComponent();
            AddBefore();


        }
        private void AddBefore()
        {
            cmsFilterAdd.ItemClicked += cmsFilterAdd_ItemClicked;
            for (int i = 0; i < cmsFilterAdd.Items.Count; i++)
            {
                if (cmsFilterAdd.Items[i] is ToolStripMenuItem)
                {
                    ToolStripMenuItem ti = (ToolStripMenuItem)cmsFilterAdd.Items[i] ;
                    if (ti.DropDownItems.Count>0)
                    {
                        ti.DropDownItemClicked += cmsFilterAdd_ItemClicked;
                    }
                }
               
            }
        }
        Gac.FilterCommon filtercommon = new Gac.FilterCommon();
        Dictionary<string, bool> diclable = new Dictionary<string, bool>();
        private void ReadMultPages(string lablename="")
        {
            #region 多页
            if (this.Owner != null)
            {
                foreach (ListViewItem item in (((FrmJob)this.Owner).lvLable.Items))
                {
                    LVRuleItem lv = (LVRuleItem)item.Tag;
                    if (lv!=null)
                    {
                        if (lablename != lv.RuleName)
                        {
                            diclable.Add(lv.RuleName, false);
                            lbLableSelect.Items.Add("[标签:" + lv.RuleName + "]");
                        }
                    }

                }
                cmbInMu.SelectedIndex = 0;
                if(((FrmJob)this.Owner).btnMultPageChange.Tag!=null)
                { 
                    foreach (MultPages item in (List<MultPages>)(((FrmJob)this.Owner).btnMultPageChange.Tag))
                    {

                        cmbInMu.Items.Add(item.MultPageCollection[0].PageName);
                    }
                }


            }
            #endregion
        }
        private void FrmLable_Load(object sender, EventArgs e)
        {
            
            cmbTextEncodeEncoding.SelectedIndex = 0;
            ReadSynonymReplaceList();

            if (Tag != null)
            {
                LVRuleItem  lv= (LVRuleItem)Tag;
                GacXml.Rule rule = lv.Rule;
                txtLableName.Text = rule.LabelName;
                ReadMultPages(rule.LabelName);
                cmbInMu.Text = lv.PageName;
                chkDataFromUrl.Checked = rule.DataFromUrl;
                //rbDataSpider.Checked = 
                rbManual.Checked = !rule.DataSpider;

                if (string.IsNullOrEmpty( lv.PageName))
                {
                    txtLableName.Enabled = false;
                    chkLabelInPage.Enabled = chkDataFromUrl.Enabled = false;
                    groupBox2.Enabled = false;
                    cmbInMu.Visible = false;
                    rbManual.Visible = false;
                    rbDataSpider.Checked = true;
                }
                
                chkLabelInCircle.Checked = rule.LabelInCircle;
                chkLabelInPage.Checked = rule.LabelInPage;
                switch (rule.GetDataType)
                {
                    case 1: rbRegex.Checked = true; break;
                    case 2: rbXpath.Checked = true; break;
                    case 3: rbLableCombination.Checked = true; break;
                    case 4: rbAuto.Checked = true; break;
                    case 0:
                    default:
                        rbSubstr.Checked = true;
                        break;
                }

                rtbeStartStr.TextValue = rule.StartStr;
                rtbeEndStr.TextValue = rule.EndStr;

                rtbeRegexContent.TextValue = rule.RegexContent;
                rtbeRegexCombine.TextValue = rule.RegexCombine;

                txtXpath.Text = rule.XpathContent;

                switch (rule.XPathAttribue)
                {
                    case 1: rbInnerText.Checked = true; break;
                    case 2: rbOuterHtml.Checked = true; break;
                    case 3: rbHref.Checked = true; break;
                    default: rbInnerText.Checked = true; break;
                }


                

                switch (rule.TextRecognitionType)
                {
                    case 1:
                        rbGetContent.Checked = true;break;
                    case 2:rbGetPostDate.Checked = true;break;
                    default:rbGetTitle.Checked = true;break;
                }
                rbNormalPattern.Checked = rule.TextRecognitionCodeReturnType == 1;
                chkNews.Checked = rule.TextRecognitionNewsTrueBBsFalse;



                rtbeLableCombination.TextValue = rule.MergeContent;



                #region 数据过滤

                for (int i = 0; i < rule.FiltersCollection.Count; i++)
                {
                    string title = filtercommon.GetFilterTitle(rule.FiltersCollection[i]);
                    lbFilters.Items.Add(new FilterItem() { Title = title, Filter = rule.FiltersCollection[i] });
                }
                #endregion

                #region 内容过滤和文件下载
                rtbeLabelContentMust.TextValue = rule.LabelContentMust;
                rtbeLabelContentForbid.TextValue = rule.LabelContentForbid;
                chkLabelNotRepeat.Checked = rule.LabelNotRepeat;
                chkLabelNotNull.Checked = rule.LabelNotNull;
                if (rule.LengthFiltOpertar > 0)
                {
                    cmbLengthFiltOpertar.SelectedIndex = rule.LengthFiltOpertar - 1;
                    checkBox3.Checked = true;
                }
                else
                {
                    cmbLengthFiltOpertar.SelectedIndex = 0;
                }
                
                
                
                nudLengthFiltValue.Value = rule.LengthFiltValue;



                chkFillRelativeUrl.Checked = rule.FillRelativeUrl;
                chkOnlyFetchValidUrl.Checked = rule.OnlyFetchValidUrl;
                chkDownloadImage.Checked = rule.DownloadImage;
                chkDownloadOtherFile.Checked = rule.DownloadOtherFile;
                rtbeFileUrlMust.TextValue = rule.FileUrlMust;
                rtbeFileSaveDir.TextValue = rule.FileSaveDir;
                rtbeFileSaveFormat.TextValue = rule.FileSaveFormat;
                #endregion

                #region 固定格式数据
                switch (rule.ManualType)
                {
                    case 1: rbManualType1.Checked = true; break;
                    case 2: rbManualType2.Checked = true; break;
                    case 3: rbManualType3.Checked = true; break;
                    case 4: rbManualType4.Checked = true; break;
                    case 5: rbManualType5.Checked = true; break;
                    default: rbManualType0.Checked = true; break;
                }
                txtManualString.Text = rule.ManualString;
                if (!string.IsNullOrEmpty(rule.ManualTimeStr))
                {
                    rtbeManualTimeStr.TextValue = rule.ManualTimeStr;
                }
                if (!string.IsNullOrEmpty(rule.ManualRadomStringLib))
                {
                    txtManualRadomStringLib.Text = rule.ManualRadomStringLib;
                }
                if (rule.ManualRadomStringNum > 0)
                {
                    nudManualRadomStringNum.Value = rule.ManualRadomStringNum;
                }
                if (rule.ManualRadomNumStart > 0)
                {
                    nudManualRadomNumStart.Value = rule.ManualRadomNumStart;
                }
                if (rule.ManualRadomNumEnd > 0)
                {
                    nudManualRadomNumEnd.Value = rule.ManualRadomNumEnd;
                }
                txtManualRadomString.Text = rule.ManualRadomString;
                ToolTip ttpSettings = new ToolTip();
                ttpSettings.InitialDelay = 200;
                ttpSettings.AutoPopDelay = 10 * 1000;
                ttpSettings.ReshowDelay = 500;
                ttpSettings.ShowAlways = true;
                ttpSettings.IsBalloon = true;
                ttpSettings.ToolTipIcon = ToolTipIcon.Info;
                ttpSettings.ToolTipTitle = "动态提示/帮助";
                string tipOverwrite = "填写的标签可以通过[标签:这里填写的标签名]的方式调用";
                ttpSettings.SetToolTip(txtLableName, tipOverwrite);
                #endregion

            }
            else
            {
                ReadMultPages();
            }
        }
        private class FilterItem
        {
            public string Title { get; set; }
            public object Filter { get; set; }
            public override string ToString()
            {
                return Title;
            }

        }

        private void rbDataSpider_CheckedChanged(object sender, EventArgs e)
        {
            pDataSpider.Visible = rbDataSpider.Checked;
        }

        private void chkDataFromUrl_CheckedChanged(object sender, EventArgs e)
        {
            rbAuto.Enabled = rbXpath.Enabled = !chkDataFromUrl.Checked;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbRegex_CheckedChanged(object sender, EventArgs e)
        {
            pRegex.Visible = rbRegex.Checked;
        }

        private void rbXpath_CheckedChanged(object sender, EventArgs e)
        {
            pXpath.Visible = rbXpath.Checked;
        }

        private void rbSubstr_CheckedChanged(object sender, EventArgs e)
        {
            pSubStr.Visible = rbSubstr.Checked;
        }

        private void rbGetContent_CheckedChanged(object sender, EventArgs e)
        {
            pAutoGetContent.Visible = rbGetContent.Checked;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmBrowser wftm = new FrmBrowser();
            wftm.rbInnerHtml.Checked = rbInnerHtml.Checked;
            wftm.rbInnerText.Checked = rbInnerText.Checked;
            wftm.rbOuterHtml.Checked = rbOuterHtml.Checked;
            wftm.rbHref.Checked = rbHref.Checked;
            wftm.rbOne.Checked = chkLabelInCircle.Checked;
            wftm.getFlag = 5;
            wftm.txtXpath.Text = txtXpath.Text;
            //wftm.rCookie = new frmBrowser.ReturnCookie(GetCookie);
            if (wftm.ShowDialog() == DialogResult.OK)
            {
                txtXpath.Text = wftm.Tag.ToString();
            }
            wftm.Dispose();
        }

        private void rbAuto_CheckedChanged(object sender, EventArgs e)
        {
            pAuto.Visible = rbAuto.Checked;
        }

        private void rbLableCombination_CheckedChanged(object sender, EventArgs e)
        {
            pLableCombination.Visible = rbLableCombination.Checked;
        }

        private void lbLableSelect_Click(object sender, EventArgs e)
        {
            if (lbLableSelect.SelectedItem!=null)
            {
                rtbeLableCombination.Rich.AppendText(lbLableSelect.SelectedItem.ToString()); 
            }
            
        }

        private void rtbeRegexContent_ValueChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("\\(\\?<content>");
            Match match = reg.Match(rtbeRegexContent.TextValue);
            if (match.Success)
            {
                //rtbeRegexContent.Dock = DockStyle.Fill;
                rtbeRegexContent.Width = 586;
            }
            else
            {
                rtbeRegexContent.Width = 287;
                //rtbeRegexContent.Dock = DockStyle.None;
            }
        }

        private void pSubStr_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowControl(Control control,bool IsRead=false)
        {
            if (!IsRead)
            {
                itemindex = -1;
            }
            gbTip.Visible = false;
            gbContentFiltering.Visible = false;
            gbFileDown.Visible = false;
            gbReplaceFilter.Visible = false;
            gbRemoveHtmlFilter.Visible = false;
            gbSubstringFilter.Visible = false;
            gbPureRegexFilter.Visible = false;
            gbToEngFilter.Visible = false;
            gbGbkToBig5Filter.Visible = false;
            gbBig5ToGbkFilter.Visible = false;
            gbToPinyinFilter.Visible = false;
            gbToMarsFilter.Visible = false;
            gbToSummaryFilter.Visible = false;
            gbToWordSegFilter.Visible = false;
            gbHttpHeader.Visible = false;
            gbHttpRequest.Visible = false;
            gbTextEncode.Visible = false;
            gbSynonymReplace.Visible = false;
            gbGetThumPic.Visible = false;
            gbFillEmpty.Visible = false;
            gbFillBothEnd.Visible = false;
            gbRandomInsert.Visible = false;
            gbForceFillUrl.Visible = false;

            control.Visible = true;
        }

        private void lbFilterFixed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFilterFixed.SelectedIndex == 0)
            {

                ShowControl(gbFileDown);
            }
            else if (lbFilterFixed.SelectedIndex == 1)
            {
                ShowControl(gbContentFiltering);
            }
        }

        private void gbContentFiltering_Enter(object sender, EventArgs e)
        {

        }


        private void ucHelper3_Click(object sender, EventArgs e)
        {
            ShowControl(gbTip);
        }
        int itemindex = -1;
        private void lbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool score = lbFilters.SelectedIndices.Count == 1;
            btnWentDown.Enabled = btnWentUp.Enabled = score;

            itemindex = lbFilters.SelectedIndex;
            if (itemindex>=0)
            {
                object filter = ((FilterItem)lbFilters.Items[itemindex]).Filter;
                if (filter is ReplaceFilter)
                {
                    //内容替换
                    ShowControl(gbReplaceFilter,true);
                    ReplaceFilter tempFilter = (ReplaceFilter)filter;
                    rtbeReplaceFilterOld.TextValue = tempFilter.old;
                    rtbeReplaceFilterNew.TextValue = tempFilter.New;

                }
                else if (filter is RemoveHtmlFilter) {
                    //HTML标签排除
                    ShowControl(gbRemoveHtmlFilter, true);
                    RemoveHtmlFilter tempFilter = (RemoveHtmlFilter)filter;
                    string[] ids = tempFilter.Indexs.Split(new string[]{ "," },StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < ids.Length; i++)
                    {
                        int id = Convert.ToInt32( ids[i]);
                        chklbRemoveHtmlFilter.SetItemChecked(id, true);
                    }
                }
                else if (filter is SubstringFilter) {
                    //内容截取
                    ShowControl(gbSubstringFilter, true);
                    SubstringFilter tempFilter = (SubstringFilter)filter;

                    rtbeSubstringFilterStart.TextValue = tempFilter.start;
                    rtbeSubstringFilterEnd.TextValue = tempFilter.end;

                }
                else if (filter is PureRegexFilter) {
                    //纯正则替换
                    ShowControl(gbPureRegexFilter, true);
                    PureRegexFilter tempFilter = (PureRegexFilter)filter;
                    txtPureRegexFilterOld.Text = tempFilter.old;
                    txtPureRegexFilterNew.Text = tempFilter.New;
                }
                else if (filter is ToEngFilter) {
                    //结果汉译英
                    ShowControl(gbToEngFilter, true);
                }
                else if (filter is GbkToBig5Filter) {
                    //结果简体转繁体
                    ShowControl(gbGbkToBig5Filter, true);
                }
                else if (filter is Big5ToGbkFilter) {
                    //结果繁体转简体
                    ShowControl(gbBig5ToGbkFilter, true);
                }
                else if (filter is ToPinyinFilter) {
                    //自动转换为拼音
                    ShowControl(gbToPinyinFilter, true);
                    ToPinyinFilter tempFilter = (ToPinyinFilter)filter;
                    txtToPinyinFilterSep.Text = tempFilter.sep;
                    nudToPinyinFilterMaxLengh.Value = tempFilter.maxLengh;
                    chkToPinyinFilterOnlyFirst.Checked= tempFilter.onlyFirst==0;
                    switch (tempFilter.upperLowerType)
                    {
                        case 0:rbToPinyinFilterAllUp.Checked = true;break;
                        case 2:rbToPinyinFilterAllLower.Checked = true; break;
                        default:
                            rbToPinyinFilterAllUp.Checked = true;break;
                    }
                }
                else if (filter is ToMarsFilter) {
                    //转换为火星文
                    ShowControl(gbToMarsFilter, true);
                }
                else if (filter is ToSummaryFilter) {
                    //自动摘要
                    ToSummaryFilter tempFilter = (ToSummaryFilter)filter;
                    nudToSummaryFilterlength.Value = tempFilter.length;
                    ShowControl(gbToSummaryFilter, true);
                }
                else if (filter is ToWordSegFilter) {
                    //自动分词
                    ToWordSegFilter tempFilter = (ToWordSegFilter)filter;
                    txtToWordSegFilterSeq.Text = tempFilter.seq;
                    nudToWordSegFilterMaxsword.Value = tempFilter.maxsword;
                    ShowControl(gbToWordSegFilter, true);
                }
                else if (filter is HttpHeader) {
                    //HTTP头信息提取
                    HttpHeader tempFilter = (HttpHeader)filter;
                    switch (tempFilter.value)
                    {
                        case 1:rbHttpHeader1.Checked = true;break;
                        case 2: rbHttpHeader2.Checked = true; break;
                        case 3: rbHttpHeader3.Checked = true; break;
                        case 4: rbHttpHeader4.Checked = true; break;
                        default: rbHttpHeader0.Checked = true; break;
                    }
                    ShowControl(gbHttpHeader, true);
                }
                else if (filter is HttpRequest) {
                    //HTTP请求
                    ShowControl(gbHttpRequest, true);

                }
                else if (filter is TextEncode) {
                    //字符编 /解码
                    TextEncode tempFilter = (TextEncode)filter;
                    switch (tempFilter.codeType)
                    {
                        case 1:rbTextEncodeCodeType1.Checked = true;break;
                        case 2: rbTextEncodeCodeType2.Checked = true; break;
                        case 3: rbTextEncodeCodeType3.Checked = true; break;
                        case 4: rbTextEncodeCodeType4.Checked = true; break;
                        case 5: rbTextEncodeCodeType5.Checked = true; break;
                        case 6: rbTextEncodeCodeType6.Checked = true; break;
                        case 7: rbTextEncodeCodeType7.Checked = true; break;
                        default: rbTextEncodeCodeType0.Checked = true; break;
                    }
                    cmbTextEncodeEncoding.Text = tempFilter.encoding;
                    ShowControl(gbTextEncode, true);
                }
                else if (filter is SynonymReplace) {
                    //同义词替换
                  
                    SynonymReplace tempFilter = (SynonymReplace)filter;
                    chkSynonymReplaceIsOnlyReplaceFirstOne.Checked = (tempFilter.IsOnlyReplaceFirstOne == 0);
                    for (int i = 0; i < cmbSynonymReplaceValue.Items.Count; i++)
                    {
                        if (cmbSynonymReplaceValue.Items[i].ToString()==tempFilter.value)
                        {
                            cmbSynonymReplaceValue.SelectedIndex = i;
                        }
                    }
                    ShowControl(gbSynonymReplace, true);
                }
                else if (filter is GetThumPic) {
                    //提取第一张图片
                    ShowControl(gbGetThumPic, true);
                }
                else if (filter is FillEmpty) {
                    //内容空缺省
                    FillEmpty tempFilter = (FillEmpty)filter;
                    txtFillEmptyFixdata.Text = tempFilter.fixdata;
                    ShowControl(gbFillEmpty, true);
                }
                else if (filter is FillBothEnd) {
                    //内容添加前后缀
                    FillBothEnd tempFilter = (FillBothEnd)filter;
                    txtFillBothEndStart.Text = tempFilter.Start;
                    txtFillBothEndEnd.Text = tempFilter.End;
                    chkFillBothEndEmptyNotFill.Checked = tempFilter.EmptyNotFill;
                    ShowControl(gbFillBothEnd, true);
                }
                else if (filter is RandomInsert) {
                    //随机插入
                    RandomInsert tempFilter = (RandomInsert)filter;
                    txtRandomInsertSrcFile.Text = tempFilter.SrcFile;
                    nudRandomInsertSelectRowNum.Value = tempFilter.SelectRowNum;
                    chkRandomInsertNotInHtmlTag.Checked = tempFilter.NotInHtmlTag;
                    ShowControl(gbRandomInsert, true);
                }
                else if (filter is ForceFillUrl) {
                    //补全当前网址
                    ShowControl(gbForceFillUrl,true);
                }
            }


        }
        private void ReadSynonymReplaceList()
        {
            cmbSynonymReplaceValue.Items.Clear();

            string[] files = Directory.GetFiles((System.Environment.CurrentDirectory + Properties.Resources.Configuration + "\\Synonym\\"), "*.txt");
            for (int i = 0; i < files.Length; i++)
            {
                string filename= System.IO.Path.GetFileNameWithoutExtension(files[i]);
                cmbSynonymReplaceValue.Items.Add(filename);
            }
            if (cmbSynonymReplaceValue.Items.Count>0)
            {
                cmbSynonymReplaceValue.SelectedIndex = 0;
            }
            


        }
        private void button9_Click(object sender, EventArgs e)
        {
            rtbeReplaceFilterOld.TextValue = "";
            rtbeReplaceFilterNew.TextValue = "";
        }

        private void btnReplaceFilterSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbeReplaceFilterOld.TextValue))
            {
                ShowTip("目标字符不能为空！", rtbeReplaceFilterOld);
                return;
            }
            ReplaceFilter filter = new ReplaceFilter() { old = rtbeReplaceFilterOld.TextValue, New = rtbeReplaceFilterNew.TextValue };
            SaveFilter(filter);
            gbReplaceFilter.Visible = false;
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            //this.Close();
        }
        private void SaveFilter(object filter)
        {
            FilterItem filterItem = GetFilterItem(filter);
            if (itemindex >= 0 && lbFilters.Items.Count>itemindex)
            {
                lbFilters.Items[itemindex] = filterItem;
            }
            else
            {
                lbFilters.Items.Add(filterItem);
            }
            itemindex = -1;
        }
        private void ShowTip(string message, Control contror)
        {
            ttMessage.Show(message, contror, 0, contror.Height + 5,3000);
            contror.Focus();
        }
        string[] lableBlackList = new string[] { "Id", "已采", "已发", "PageUrl" };
        Regex regLableCheck = new Regex("(^_|[^a-zA-Z0-9\\u4e00-\\u9fa5_-])");
        private void btnSave_Click(object sender, EventArgs e)
        {

            //标题名称只能使用字母，数字及各种字符组成且不能以_开头
            Match matchlable= regLableCheck.Match(txtLableName.Text);
            if (matchlable.Success)
            {
                ShowTip("标签名包含特殊字符：" + matchlable.Groups[1].Value + "\r\n标签名称只能使用字母，数字及各种字符组成且不能以_开头", txtLableName);
                return;
            }

            foreach (var item in lableBlackList)
            {
                if (item==txtLableName.Text)
                {
                    ShowTip("标签名 "+item+" 为采集器内置字段,请更换其他名称", txtLableName);
                    return;
                }
            }
            if (diclable.ContainsKey(txtLableName.Text))
            {
                ShowTip("发现已存在这个标签名，请修改！", txtLableName);
                return;
            }
            GacXml.Rule rule = new GacXml.Rule();

            rule.LabelName = txtLableName.Text;
            rule.DataFromUrl = chkDataFromUrl.Checked;
            rule.DataSpider = !rbManual.Checked;
            rule.LabelInCircle = chkLabelInCircle.Checked;
            rule.LabelInPage = chkLabelInPage.Checked;
            if (rbRegex.Checked)
            {
                rule.GetDataType = 1;
            }
            else if (rbXpath.Checked)
            {
                rule.GetDataType = 2;
            }
            else if (rbLableCombination.Checked)
            {
                rule.GetDataType = 3;
            }
            else if (rbAuto.Checked)
            {
                rule.GetDataType = 4;
            }
            else 
            {
                rule.GetDataType = 0;
            }

            rule.StartStr=rtbeStartStr.TextValue ;
             rule.EndStr=rtbeEndStr.TextValue ;

             rule.RegexContent=rtbeRegexContent.TextValue ;
             rule.RegexCombine=rtbeRegexCombine.TextValue ;

             rule.XpathContent=txtXpath.Text ;

            if (rbInnerText.Checked)
            {
                rule.XPathAttribue = 1;
            }
            else if (rbOuterHtml.Checked)
            {
                rule.XPathAttribue = 2;
            }
            else if (rbHref.Checked)
            {
                rule.XPathAttribue = 3;
            }
            else
            {
                rule.XPathAttribue = 0;
            }
            if (rbGetTitle.Checked)
            {
                rule.TextRecognitionType = 0;
            } else if (rbGetContent.Checked)
            {
                rule.TextRecognitionType = 1;
            }
            else if (rbGetPostDate.Checked)
            {
                rule.TextRecognitionType = 2;
            }

            rule.TextRecognitionCodeReturnType= rbNormalPattern.Checked? 1:0;
            rule.TextRecognitionNewsTrueBBsFalse=chkNews.Checked  ;

            rule.MergeContent=rtbeLableCombination.TextValue ;



            //        #region 多页
            //        if (this.Owner != null)
            //        {
            //    (GacXml.GacJob)this.Owner.Tag = GacXml.GacJob taskxml;
            //    if (taskxml.ListLabelCollection != null)
            //    {
            //        0 =for (int i; i < taskxml.SortLabel.Count; i++)
            //        {
            //            if (rule.LabelName != taskxml.SortLabel[i])
            //            {
            //                lbLableSelect.Items.Add("[标签:" + taskxml.SortLabel[i] + "]");
            //            }

            //        }
            //    }

            //    0 =for (int i; i < taskxml.SuperJobCollection.Count; i++)
            //    {
            //        cmbInMu.Items.Add(taskxml.SuperJobCollection[i].PageName);
            //        0 =for (int i2; i2 < taskxml.SuperJobCollection[i].RuleCollection.Count; i2++)
            //        {
            //            taskxml.SuperJobCollection[i].RuleCollection[i2] = GacXml.Rule ruletemp;
            //            if (ruletemp.LabelName == rule.LabelName)
            //            {
            //                taskxml.SuperJobCollection[i].PageName = cmbInMu.Text;
            //            }
            //        }
            //        if (taskxml.SuperJobCollection[i].MultPagesCollection != null)
            //        {
            //            0 =for (int i2; i2 < taskxml.SuperJobCollection[i].MultPagesCollection.Count; i2++)
            //            {
            //                cmbInMu.Items.Add(taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].PageName);
            //                if (taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].RuleCollection != null)
            //                {
            //                    0 =for (int i3; i3 < taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].RuleCollection.Count; i3++)
            //                    {
            //                        taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].RuleCollection[i3] = GacXml.Rule ruletemp;
            //                        if (ruletemp.LabelName == rule.LabelName)
            //                        {
            //                            taskxml.SuperJobCollection[i].MultPagesCollection[i2].SuperJobCollection[0].PageName = cmbInMu.Text;
            //                        }

            //                    }
            //                }


            //            }
            //        }

            //    }
            //}
            //        #endregion

            #region 数据过滤

            for (int i = 0; i < lbFilters.Items.Count; i++)
            {
                FilterItem filterItem=(FilterItem)lbFilters.Items[i];
                rule.FiltersCollection.Add(filterItem.Filter);
            }
            #endregion

            #region 内容过滤和文件下载
            rule.LabelContentMust=rtbeLabelContentMust.TextValue ;
             rule.LabelContentForbid=rtbeLabelContentForbid.TextValue ;
             rule.LabelNotRepeat=chkLabelNotRepeat.Checked ;
             rule.LabelNotNull=chkLabelNotNull.Checked ;
            if (checkBox3.Checked)
            {
                rule.LengthFiltOpertar = cmbLengthFiltOpertar.SelectedIndex+1 ;
            }
            else
            {
                rule.LengthFiltOpertar = 0;
            }
             rule.LengthFiltValue=(int)nudLengthFiltValue.Value ;



             rule.FillRelativeUrl=chkFillRelativeUrl.Checked ;
             rule.OnlyFetchValidUrl=chkOnlyFetchValidUrl.Checked ;
             rule.DownloadImage=chkDownloadImage.Checked ;
             rule.DownloadOtherFile=chkDownloadOtherFile.Checked ;
             rule.FileUrlMust=rtbeFileUrlMust.TextValue ;
             rule.FileSaveDir=rtbeFileSaveDir.TextValue ;
             rule.FileSaveFormat=rtbeFileSaveFormat.TextValue ;
            #endregion

            #region 固定格式数据
            if (rbManualType1.Checked)
            {
                rule.ManualType = 1;
            }
            else if (rbManualType2.Checked)
            {
                rule.ManualType = 2;
            }
            else if (rbManualType3.Checked)
            {
                rule.ManualType = 3;
            }
            else if (rbManualType4.Checked)
            {
                rule.ManualType = 4;
            }
            else if (rbManualType5.Checked)
            {
                rule.ManualType = 5;
            }
            else 
            {
                rule.ManualType = 0;
            }
            rule.ManualString=txtManualString.Text ;

            rule.ManualTimeStr=rtbeManualTimeStr.TextValue ;

            rule.ManualRadomStringLib=txtManualRadomStringLib.Text ;
           
            rule.ManualRadomStringNum=(int)nudManualRadomStringNum.Value ;
           
            rule.ManualRadomNumStart= (int)nudManualRadomNumStart.Value ;
           
            rule.ManualRadomNumEnd= (int)nudManualRadomNumEnd.Value ;
           
            rule.ManualRadomString=txtManualRadomString.Text ;
            #endregion

            LVRuleItem lv = new LVRuleItem() { Rule = rule, RuleName = rule.LabelName, PageName = cmbInMu.Text };

            this.Tag = lv;
            DialogResult = DialogResult.OK;
        }

        private void 内容替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbeReplaceFilterOld.TextValue = "";
            rtbeReplaceFilterNew.TextValue = "";
            ShowControl(gbReplaceFilter);
        }

        private void btnRemoveHtmlFilterSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklbRemoveHtmlFilter.Items.Count; i++)
            {
                chklbRemoveHtmlFilter.SetItemChecked(i, true);
            }
             
        }

        private void btnRemoveHtmlFilterSelectReverse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklbRemoveHtmlFilter.Items.Count; i++)
            {
                chklbRemoveHtmlFilter.SetItemChecked(i, !chklbRemoveHtmlFilter.GetItemChecked(i));
            }
        }
        private FilterItem GetFilterItem(object Filter)
        {
            string title = filtercommon.GetFilterTitle(Filter);
            FilterItem fi = new FilterItem() { Title = title, Filter = Filter };
            return fi;
        }
        private void btnRemoveHtmlFilterSave_Click(object sender, EventArgs e)
        {
            if (chklbRemoveHtmlFilter.CheckedItems.Count != 0)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < chklbRemoveHtmlFilter.CheckedItems.Count; i++)
                {
                    if (chklbRemoveHtmlFilter.GetItemChecked(i))
                    {
                        sb.Append(i);
                    }
                    if (i != chklbRemoveHtmlFilter.CheckedItems.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                //string indexs = sb.ToString();
                //if(indexs.Length>0)
                //{
                //    indexs=indexs.Substring(0, indexs.Length - 1);
                //}
                RemoveHtmlFilter filter = new RemoveHtmlFilter() { Indexs = sb.ToString() };
                SaveFilter(filter);


                gbRemoveHtmlFilter.Visible = false;

            }
            else {
                ttMessage.Show("请至少选择一项！",chklbRemoveHtmlFilter,0,chklbRemoveHtmlFilter.Height+5);
            }
            
        }

        private void hTML标签排除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklbRemoveHtmlFilter.Items.Count; i++)
            {
                chklbRemoveHtmlFilter.SetItemChecked(i, false);
            }
            ShowControl(gbRemoveHtmlFilter);
        }

        private void btnAddFiftr_Click(object sender, EventArgs e)
        {
            cmsFilterAdd.Show(MousePosition.X, MousePosition.Y);
        }



        private void btnSubstringFilterSave_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(rtbeSubstringFilterStart.TextValue))
            {
                ShowTip("请输入开始文本！", rtbeSubstringFilterStart);
                return;
            }
            if (string.IsNullOrEmpty(rtbeSubstringFilterEnd.TextValue))
            {
                ShowTip("请输入结束文本！", rtbeSubstringFilterEnd);
                return;
            }
            SubstringFilter filter = new SubstringFilter() { start = rtbeSubstringFilterStart.TextValue, end = rtbeSubstringFilterEnd.TextValue };
            SaveFilter(filter);
            gbSubstringFilter.Visible = false;
            
           
        }

        private void 字符截取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbeSubstringFilterStart.TextValue= rtbeSubstringFilterEnd.TextValue = "";
            ShowControl(gbSubstringFilter);
        }

        private void btnPureRegexFilterSave_Click(object sender, EventArgs e)
        {
            PureRegexFilter filter = new PureRegexFilter() {  old=txtPureRegexFilterOld.Text, New=txtPureRegexFilterNew.Text};
            if (string.IsNullOrEmpty(txtPureRegexFilterOld.Text))
            {
                ShowTip("请输入正确的正则语句！", txtPureRegexFilterOld);
                return;
            }
            SaveFilter(filter);
            gbPureRegexFilter.Visible = false;

        }

        private void 纯正则替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPureRegexFilterOld.Text = txtPureRegexFilterNew.Text = "";
            ShowControl(gbPureRegexFilter);

        }

        private void 将结果汉译英ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFilter(new ToEngFilter());
            ShowControl(gbToEngFilter);
        }

        private void 将结果简转繁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFilter(new GbkToBig5Filter());
            ShowControl(gbGbkToBig5Filter);
        }

        private void 将结果繁转简ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFilter(new Big5ToGbkFilter());
            ShowControl(gbBig5ToGbkFilter);
        }

        private void btnToPinyinFilterSave_Click(object sender, EventArgs e)
        {
            int upperLowerType = 1;
            if (rbToPinyinFilterFirst.Checked)
            {
                upperLowerType = 0;
            }
            else if (rbToPinyinFilterAllLower.Checked)
            {
                upperLowerType = 2;
            }
            ToPinyinFilter filter = new ToPinyinFilter() {  upperLowerType=upperLowerType, maxLengh=(int)nudToPinyinFilterMaxLengh.Value, onlyFirst=chkToPinyinFilterOnlyFirst.Checked?0:1, sep=txtToPinyinFilterSep.Text };
            SaveFilter(filter);
            gbToPinyinFilter.Visible = false;

        }

        private void 自动转化为拼音ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            rbToPinyinFilterAllUp.Checked = true;
            txtToPinyinFilterSep.Text = "-";
            nudToPinyinFilterMaxLengh.Value = 10;
            chkToPinyinFilterOnlyFirst.Checked = false;
            ShowControl(gbToPinyinFilter);

        }

        private void 将结果转为火星文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFilter(new ToMarsFilter());
            ShowControl(gbToMarsFilter);
        }

        private void 自动摘要ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nudToSummaryFilterlength.Value = 1000;
            ShowControl(gbToSummaryFilter);
            
        }

        private void btnToSummaryFilterSave_Click(object sender, EventArgs e)
        {
            if ((int)nudToSummaryFilterlength.Value<=0)
            {
                ShowTip("请设定一个有意义的数字！", nudToSummaryFilterlength);
                return;
            }
            ToSummaryFilter filter = new ToSummaryFilter() {  length=(int)nudToSummaryFilterlength.Value };
            SaveFilter(filter);
            gbToSummaryFilter.Visible = false;
        }

        private void 自动分词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtToWordSegFilterSeq.Text = "-";
            nudToWordSegFilterMaxsword.Value = 5;
            ShowControl(gbToWordSegFilter);
        }

        private void btnToWordSegFilter_Click(object sender, EventArgs e)
        {
            ToWordSegFilter filter = new ToWordSegFilter() { seq = txtToWordSegFilterSeq.Text , maxsword= (int)nudToWordSegFilterMaxsword.Value };
            SaveFilter(filter);
            gbToWordSegFilter.Visible = false;
        }

        private void btnHttpHeaderSave_Click(object sender, EventArgs e)
        {
            int value = 0;
            if (rbHttpHeader0.Checked)
            {
                value = 0;
            }
            else if (rbHttpHeader1.Checked)
            {
                value = 1;
            }
            else if (rbHttpHeader2.Checked)
            {
                value =2;
            }
            else if (rbHttpHeader3.Checked)
            {
                value =3;
            }
            else if (rbHttpHeader4.Checked)
            {
                value = 4;
            }
            HttpHeader filter = new HttpHeader() {  value=value};
            SaveFilter(filter);
            gbHttpHeader.Visible = false;
        }

        private void http头信息提取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbHttpHeader0.Checked = true;
            ShowControl(gbHttpHeader);
        }

        private void hTTP请求ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(gbHttpRequest);
        }

        private void btnTextEncodeSave_Click(object sender, EventArgs e)
        {
            int codeType = 0;
            if (rbTextEncodeCodeType0.Checked)
            {
                codeType = 0;
            }else if (rbTextEncodeCodeType1.Checked)
            {
                codeType =1;
            }
            else if (rbTextEncodeCodeType2.Checked)
            {
                codeType =2;
            }
            else if (rbTextEncodeCodeType3.Checked)
            {
                codeType =3;
            }
            else if (rbTextEncodeCodeType4.Checked)
            {
                codeType =4;
            }
            else if (rbTextEncodeCodeType5.Checked)
            {
                codeType =5;
            }
            else if (rbTextEncodeCodeType6.Checked)
            {
                codeType = 6;
            }
            else if (rbTextEncodeCodeType7.Checked)
            {
                codeType = 7;
            }
            TextEncode filter = new TextEncode() { codeType = codeType, encoding = cmbTextEncodeEncoding.Text };
            SaveFilter(filter);
            gbTextEncode.Visible = false;
        }

        private void 字符编码转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbTextEncodeCodeType0.Checked = true;
            ShowControl(gbTextEncode);
        }

        private void btnSynonymReplaceSave_Click(object sender, EventArgs e)
        {
            SynonymReplace filter = new SynonymReplace() {   value=cmbSynonymReplaceValue.SelectedText, IsOnlyReplaceFirstOne=chkSynonymReplaceIsOnlyReplaceFirstOne.Checked?0:1 };
            SaveFilter(filter);
            gbSynonymReplace.Visible = false;
        }

        private void 同义词替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbSynonymReplaceValue.Items.Count>0)
            {
                cmbSynonymReplaceValue.SelectedIndex = 0;
            }
            chkSynonymReplaceIsOnlyReplaceFirstOne.Checked = true;
            ShowControl(gbSynonymReplace);
        }

        private void btnFillEmptySave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFillEmptyFixdata.Text))
            {
                ShowTip("缺省值不能为空！", txtFillEmptyFixdata);
                return;
            }
            FillEmpty filter = new FillEmpty() { fixdata=txtFillEmptyFixdata.Text};
            SaveFilter(filter);
            gbFillEmpty.Visible = false;
        }

        private void 提取第一张图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(gbGetThumPic);
        }

        private void 空内容缺省值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFillEmptyFixdata.Text = "";
            ShowControl(gbFillEmpty);
        }

        private void btnFillBothEndSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFillBothEndStart.Text)&& string.IsNullOrEmpty(txtFillBothEndEnd.Text))
            {
                ShowTip("前后字符串不能同时为空！", txtFillBothEndStart);
                return;
            }
            FillBothEnd filter = new FillBothEnd() { Start = txtFillBothEndStart.Text, End = txtFillBothEndEnd.Text, EmptyNotFill = chkFillBothEndEmptyNotFill.Checked };
            SaveFilter(filter);
            gbFillBothEnd.Visible = false;
        }

        private void 内容加前后缀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkFillBothEndEmptyNotFill.Checked = true;
            txtFillBothEndStart.Text = "";
            txtFillBothEndEnd.Text = ""; 
            ShowControl(gbFillBothEnd);
        }

        private void btnRandomInsertSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRandomInsertSrcFile.Text))
            {
                ShowTip("文件路径为空！", txtRandomInsertSrcFile);
                return;
            }
            if (!File.Exists(txtRandomInsertSrcFile.Text))
            {
                ShowTip("文件不存在！", txtRandomInsertSrcFile);
                return;
            }
            RandomInsert filter = new RandomInsert() { SrcFile=txtRandomInsertSrcFile.Text, SelectRowNum=(int)nudRandomInsertSelectRowNum.Value, NotInHtmlTag=chkRandomInsertNotInHtmlTag.Checked  };
            SaveFilter(filter);
            gbRandomInsert.Visible = false;
        }

        private void 随机插入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtRandomInsertSrcFile.Text = "";
            nudRandomInsertSelectRowNum.Value = 1;
            chkRandomInsertNotInHtmlTag.Checked = false;
            ShowControl(gbRandomInsert);
        }

        private void btnRandomInsertSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt|所有文件|*.*";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtRandomInsertSrcFile.Text = ofd.FileName;
            }
        }

        private void 补全网址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(gbForceFillUrl);
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            pManual.Visible = rbManual.Checked;
        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void btnManualTest_Click(object sender, EventArgs e)
        {
            LableCommon lc = new LableCommon();
            lblManualTestResult.Text = "测试结果：";
            if (rbManualType0.Checked)
            {
                lblManualTestResult.Text += txtManualString.Text;
            }
            else if (rbManualType1.Checked)
            {
                lblManualTestResult.Text += lc.GetManualFromDate(rtbeManualTimeStr.TextValue);
            }
            else if (rbManualType2.Checked)
            {
                lblManualTestResult.Text += lc.GetManualRadomString(txtManualRadomStringLib.Text, (int)nudManualRadomStringNum.Value);
            }
            else if (rbManualType3.Checked)
            {
                lblManualTestResult.Text += lc.GetManualRadomNum((int)nudManualRadomNumStart.Value, (int)nudManualRadomNumEnd.Value);
            }
            else if (rbManualType5.Checked)
            {
                lblManualTestResult.Text += lc.GetManualUnixTime();
            }
            else if (rbManualType4.Checked)
            {
                lblManualTestResult.Text += lc.GetManualRadomString(txtManualRadomString.Text);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbFilters.SelectedItems!=null)
            {
                int count = lbFilters.SelectedItems.Count;
                for (int i = 0; i < count; i++)
                {
                    lbFilters.Items.RemoveAt(lbFilters.SelectedIndex);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbFilters.Items.Clear();
        }

        private void btnWentUp_Click(object sender, EventArgs e)
        {

            if (lbFilters.SelectedIndex>0)
            {
                int tempid = lbFilters.SelectedIndex - 1;
                object temp = lbFilters.Items[tempid];
                lbFilters.Items[tempid] = lbFilters.Items[lbFilters.SelectedIndex];
                lbFilters.Items[lbFilters.SelectedIndex] = temp;
                lbFilters.ClearSelected();
                lbFilters.SelectedIndex= tempid;

            }
        }

        private void btnWentDown_Click(object sender, EventArgs e)
        {
            if (lbFilters.SelectedIndex >= 0&& lbFilters.SelectedIndex< lbFilters.Items.Count-1)
            {
                int tempid = lbFilters.SelectedIndex + 1;
                object temp = lbFilters.Items[tempid];
                lbFilters.Items[tempid] = lbFilters.Items[lbFilters.SelectedIndex];
                lbFilters.Items[lbFilters.SelectedIndex] = temp;
                lbFilters.ClearSelected();
                lbFilters.SelectedIndex = tempid;

            }
        }



        private void cmsFilterAdd_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            itemindex = -1;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            cmbLengthFiltOpertar.Enabled =nudLengthFiltValue.Enabled= checkBox3.Checked;
        }
    }
}
