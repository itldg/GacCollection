using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gac;
using GacXml;
using CsharpHttpHelper;

namespace GAC_Collection.MainUi.Task
{
    public partial class FrmMultiPage : Form
    {
        HttpRequestInfo RequestInfo = null;
        public FrmMultiPage(HttpRequestInfo requestInfo)
        {
            InitializeComponent();
            RequestInfo = requestInfo;
        }

        private void brFromCode_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !rbFromCode.Checked;
            pCode.Visible = rbFromCode.Checked;

        }
        private class MultPagesItem
        {
            public MultPagesItem(MultPages MultPages)
            {
                this.multPages = MultPages;
            }
            public MultPages multPages { get; set; }
            public override string ToString()
            {
                return multPages.MultPageCollection[0].PageName.ToString();
            }
        }
        private void FrmMultiPage_Load(object sender, EventArgs e)
        {
            if (Tag!=null)
            {
                List<MultPages> list=(List<MultPages>)Tag;
                for (int i = 0; i < list.Count; i++)
                {
                    int index=lbPages.Items.Add(new MultPagesItem(list[i]));
                }
            }
        }

        private void rbFromurl_CheckedChanged(object sender, EventArgs e)
        {
            pCode.Visible = !rbFromurl.Checked;
            panel1.Visible = rbFromurl.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string reg, match = "";
            if (rbFromurl.Checked)
            {
                reg = txtReg.Text;
                match = txtMatch.Text;
            }
            else
            {
                reg = rtbeReg.TextValue;
                match = rtbeMatch.TextValue;
            }
            if (string.IsNullOrEmpty(txtPageName.Text) )
            {
                MessageBox.Show("页面名称不得为空","请填写名称",MessageBoxButtons.OK,MessageBoxIcon.Error); return;
            }
            if (string.IsNullOrEmpty(reg)||string.IsNullOrEmpty(match))
            {
                MessageBox.Show("请填写网址替换规则", "请填写规则", MessageBoxButtons.OK, MessageBoxIcon.Warning);return;
            }

            MultPage multpage = new MultPage();
            multpage.PageName=txtPageName.Text  ;
            multpage.PageReplaceUrl= txtReg.Text;
            multpage.PageReplaceNew=txtMatch.Text ;

            multpage.PageUrlStyle=rtbeReg.TextValue ;
            multpage.PageUrlCombine=rtbeMatch.TextValue;
            if (index != 0)
            {
                ((MultPagesItem)lbPages.Items[index]).multPages.MultPageCollection[0] = multpage;
                lbPages.Items[index] = ((MultPagesItem)lbPages.Items[index]);
            }
            else
            {
                SuperJob sj = new SuperJob() { Level=1,PageName= multpage.PageName, PageEncoding="",PagesUrlListAll=true, GetPagesUrlAuto=true, AcceptLanguage= "zh-cn,zh;",  UserAgent= "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729)", AutoDirect=true, TimeOut=30, MaxPages=0 };
                MultPages multPages = new MultPages() { MultPageCollection = new List<MultPage>() { multpage }, SuperJobCollection = new List<SuperJob>() { sj} };
                List<MultPages> list = null;
                if (Tag != null)
                {
                     list = (List<MultPages>)Tag;
                }
                else
                {
                    list = new List<MultPages>();
                    Tag = list;
                }
                list.Add(multPages);
                MultPagesItem mpi = new MultPagesItem(multPages);
                lbPages.Items.Add(mpi);
            }
            MessageBox.Show(txtPageName.Text+ " 保存成功！");
            Clear();
        }

        private void btnTestUrl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldUrl.Text))
            {
                MessageBox.Show("请填写要替换的网址示例", "请填写网址", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            if (rbFromurl.Checked)
            {
                txtNewUrl.Text = System.Text.RegularExpressions.Regex.Replace(txtOldUrl.Text, txtReg.Text, txtMatch.Text);
            }
            else
            {
                VariableHelper vh = new VariableHelper();


                try
                {

                    HttpCommon http = new HttpCommon(RequestInfo);
                    HttpResult result = http.GetHtml(txtOldUrl.Text);


                    //System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex();
                    //System.Text.RegularExpressions.Match match = reg.Match(result.Html); 

                    string regstr = vh.GetRegexStr(rtbeReg.TextValue, true);
                    //MessageBox.Show(regstr);
                    string matchstr = rtbeMatch.TextValue;
                    string resultstr= vh.MatchValue(regstr, matchstr, result.Html);


                    txtNewUrl.Text = vh.FormAturl(txtOldUrl.Text, resultstr);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("匹配出错,错误细节如下：\r\n" + ex.Message);
                }

            }

        }
        private int index = 0;
        private void lbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = lbPages.SelectedIndex;
            if (index>=0)
            {
                MultPage multpage = ((MultPagesItem)lbPages.Items[index]).multPages.MultPageCollection[0];
                txtPageName.Text = multpage.PageName;
                txtReg.Text = multpage.PageReplaceUrl;
                txtMatch.Text = multpage.PageReplaceNew;

                rtbeReg.TextValue = multpage.PageUrlStyle;
                rtbeMatch.TextValue = multpage.PageUrlCombine;
                rbFromCode.Checked = multpage.MultPageUrlFromHtml;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            index = 0;
            txtPageName.Text = txtReg.Text = txtMatch.Text = rtbeReg.TextValue = rtbeMatch.TextValue = "";
            rbFromCode.Checked = false;
        }
    }
}
