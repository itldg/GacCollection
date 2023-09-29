using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GAC_Collection.Helper;
using System.Xml;
using Gac;
using System.Text.RegularExpressions;

namespace GAC_Collection.MainUi.Task
{
    public partial class FrmUrlAdd : Form
    {
       
        public FrmUrlAdd()
        {
            InitializeComponent();
        }
        public FrmUrlAdd(string UrlRule)
        {
            InitializeComponent();
            if (UrlRule.StartsWith("#FILE#"))
            {
                string url = UrlRule.Substring(6, UrlRule.Length - 6);
                tabControl1.SelectedIndex = 2;
                txtTxtFilePath.Text = url;
                PreviewFileUrl();
            }
            else if (UrlRule.StartsWith("#RSS#"))
            {
                string url = UrlRule.Substring(5, UrlRule.Length - 5);
                tabControl1.SelectedIndex = 3;
                txtRssUrl.Text = url;
            }
            else
            {
                Regex reg = new Regex("<(.*?)>");
                Match match = reg.Match(UrlRule);
                if (match.Success)
                {
                    string url = UrlRule.Replace(match.Value, "(*)");
                    string parameter = match.Groups[1].Value;
                    string[] pars = parameter.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (pars.Length == 3)
                    {
                        if (pars[0] == "0")
                        {
                            rtbDateFormat.TextValue = pars[1];
                            numericUpDown7.Value = Convert.ToInt32(pars[2]);
                            tabControl1.SelectedIndex = 4;
                            rtbAdressStyle.Text = url;
                            PreviewDateUrl();
                        }
                        else
                        {
                            txtLetterStart.Text = pars[1];
                            txtLetterEnd.Text = pars[2];
                            rbLetterChange.Checked = true;
                            tabControl1.SelectedIndex = 1;
                            rtbUrlFormat.TextValue = url;
                            PreviewMultUrl();
                        }
                    }
                    else if (pars.Length == 6)
                    {
                        if (pars[0] == "0")
                        {
                            rbArithmetic.Checked = true;
                            numericUpDown1.Value = Convert.ToInt32(pars[1]);
                            numericUpDown2.Value = Convert.ToInt32(pars[2]);
                            numericUpDown3.Value = Convert.ToInt32(pars[3]);
                            checkBox1.Checked = Convert.ToBoolean(pars[4]);
                            checkBox2.Checked = Convert.ToBoolean(pars[5]);
                        }
                        else
                        {
                            rbEqualProportion.Checked = true;
                            rbArithmetic.Checked = true;
                            numericUpDown4.Value = Convert.ToInt32(pars[1]);
                            numericUpDown5.Value = Convert.ToInt32(pars[2]);
                            numericUpDown6.Value = Convert.ToInt32(pars[3]);
                            checkBox4.Checked = Convert.ToBoolean(pars[4]);
                            checkBox3.Checked = Convert.ToBoolean(pars[5]);
                        }
                        tabControl1.SelectedIndex = 1;
                        rtbUrlFormat.TextValue = url;
                        PreviewMultUrl();
                    }
                    else
                    {
                        txtUrls.Text = UrlRule;
                    }

                    //for (int i = 0; i < listtemp.Count; i++)
                    //{
                    //    listtemp[i] = UrlRule.Replace(match.Groups[0].Value, listtemp[i]);
                    //}
                    //tabControl1.SelectedIndex = 2;
                }
                else//否则为常规单条网址
                {
                    txtUrls.Text = UrlRule;
                }
            }
        }
        
        private void rtbDateFormat_TextChanged(object sender, EventArgs e)
        {
            PreviewDateUrl();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            AddUrl(txtUrls.Text);
        }
        private void AddUrl(string[] Url)
        {
            int count = 0;
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            for (int i = 0; i < Url.Length; i++)
            {
                if (lbAll.Items.Contains(Url[i]))
                {
                    if(!dic.ContainsKey(Url[i]))
                    {
                        dic.Add(Url[i],false);
                    count++;
                    }
                }
                else
                {
                    lbAll.Items.Add(Url[i]);
                }
            }
            if (count>0)
            {
                MessageBox.Show("系统检测到" + count + "条重复网址，已经自动过滤","网址重复",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }
        private void AddUrl(string Urls)
        {
            if (string.IsNullOrEmpty(Urls))
            {
                MessageBox.Show("网址不得为空", "网址错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            string[] Url = Urls.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Url.Length; i++)
            {
                if (lbAll.Items.Contains(Url[i]))
                {
                    if (!dic.ContainsKey(Url[i]))
                    {
                        dic.Add(Url[i], false);
                        count++;
                    }
                }
                else
                {
                    if (Url[i].StartsWith("http://") || Url[i].StartsWith("https://") || Url[i].StartsWith("#"))
                    {
                        lbAll.Items.Add(Url[i]);
                    }
                    else
                    {
                        sb.Append("第" + (i + 1) + "行,");
                    }
                   
                }
            }
            string error = sb.Length > 0 ?"检测到以下网址有错误：\r\n"+ sb.ToString().Substring(0, sb.Length - 1):"";
            if (count > 0)
            {
                MessageBox.Show("系统检测到" + count + "条重复网址，已经自动过滤"+(error.Length > 0?"\r\n额外"+error:""), "网址重复", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (error.Length > 0)
            {
                MessageBox.Show(error, "网址错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void rbEqualProportion_CheckedChanged(object sender, EventArgs e)
        {
            pEqualProportion.Enabled = rbEqualProportion.Checked;
            PreviewMultUrl();
        }

        private void rbLetterChange_CheckedChanged(object sender, EventArgs e)
        {
            pLetterChange.Enabled = rbLetterChange.Checked;
            PreviewMultUrl();
        }

        private void rbArithmetic_CheckedChanged(object sender, EventArgs e)
        {
            pArithmetic.Enabled = rbArithmetic.Checked;
            PreviewMultUrl();
        }

        private void FrmUrlAdd_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = numericUpDown2.Maximum = numericUpDown3.Maximum = numericUpDown4.Maximum = numericUpDown5.Maximum = numericUpDown6.Maximum = numericUpDown7.Maximum = int.MaxValue;
        }
        #region 批量多页操作
        private void PreviewMultUrl()
        {
            string temp = rtbUrlFormat.Rich.Text;
            if(CheckUrl(temp))
            {
                UrlCommon url = new UrlCommon();
                List<string> list = new List<string>();
                if (rbArithmetic.Checked)
                {
                    list = url.GetUrlsTest(1, (int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, checkBox1.Checked, checkBox2.Checked);
                    PreviewMultUrl(lbUrlPreview1, list, 7, temp);

                }
                else if (rbEqualProportion.Checked)
                {

                        list = url.GetUrlsTest(2, (int)numericUpDown4.Value, (int)numericUpDown5.Value, (int)numericUpDown6.Value, checkBox4.Checked, checkBox3.Checked);
                        PreviewMultUrl(lbUrlPreview1, list, 7, temp);
                  
                    
                }
                else if (rbLetterChange.Checked)
                {
                   
                    int start = txtLetterStart.Text.ToArray()[0];
                    int end = txtLetterEnd.Text.ToArray()[0];
                    if (start < end && end - start < 26)
                    {
                        list = url.GetUrlsTest(3, start,end,0,false,checkBox5.Checked);
                        PreviewMultUrl(lbUrlPreview1, list, 7, temp);
                    }
                    else
                    {
                        lbUrlPreview1.Items.Clear();
                    }
                }

            }
            else
            {

                lbUrlPreview1.Items.Clear();
            }
            
         
            //for (int i = 0; i < list.Count; i++)
            //{

            //    lbUrlPreview1.Items.Add(urltemp.Replace("(*)", list[i]));
            //}
        }
        private void PreviewMultUrl(ListBox lb, List<string> list, int Count,string Text)
        {
            string urltemp = Text;//rtbUrlFormat.Rich.Text;
            lb.Items.Clear();
            if (list.Count > Count)
            {
                for (int i = 0; i < Count - 2; i++)
                {
                    lb.Items.Add(urltemp.Replace("(*)",list[i]));
                }
                lb.Items.Add("········");
                lb.Items.Add(urltemp.Replace("(*)", list[list.Count - 1]));
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    lb.Items.Add(urltemp.Replace("(*)", list[i]));
                }
            }
        }
        private void PreviewMultUrlFile(ListBox lb, List<string> list, int Count)
        {
            lb.Items.Clear();
            if (list.Count > Count)
            {
                for (int i = 0; i < Count - 2; i++)
                {
                    lb.Items.Add( list[i]);
                }
                lb.Items.Add("········");
                lb.Items.Add( list[list.Count - 1]);
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    lb.Items.Add(list[i]);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PreviewMultUrl();
        }

        private void rtbUrlFormat_TextChanged(object sender, EventArgs e)
        {
                PreviewMultUrl();
        }
        private void numericUpDown2_Validating(object sender, CancelEventArgs e)
        {
            PreviewMultUrl();
        }
        private void UpDownValidated(object sender, EventArgs e)
        {
            PreviewMultUrl();
        }
        private void ChkCheckedChanged(object sender, EventArgs e)
        {
            PreviewMultUrl();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            PreviewMultUrl();
        }


        private void txtLetterStart_Validating(object sender, CancelEventArgs e)
        {
            lengthValidat(txtLetterStart, "a");
            PreviewMultUrl();

        }
        private void lengthValidat(TextBox text,string Normal)
        {
            if (text.Text.Length > 1)
            {
                text.Text=text.Text.Substring(0, 1);
                text.SelectionStart = 1;
            }

            //else if (text.Text.Length < 1)
            //{
            //    text.Text = Normal;
            //}

            if (!Validat(text.Text.ToCharArray()[0]))
            {
                text.Text = Normal;
            }
        }

        private bool Validat(Char charvalue)
        {
            int charint = Convert.ToInt32(charvalue);
            if ((charint >= 65 && charint <= 90) || (charint >= 97 && charint <= 122))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtLetterStart_Leave(object sender, EventArgs e)
        {
            if (txtLetterStart.Text.Length < 1)
            {
                txtLetterStart.Text = "a";
            }
            PreviewMultUrl();
        }

        private void txtLetterEnd_Leave(object sender, EventArgs e)
        {
            if (txtLetterEnd.Text.Length < 1)
            {
                txtLetterEnd.Text = "z";
            }
            PreviewMultUrl();
        }

        private void txtLetterEnd_Validating(object sender, CancelEventArgs e)
        {
            lengthValidat(txtLetterEnd, "z");
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            PreviewMultUrl();
        }
        #endregion

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog  ofd = new OpenFileDialog();
            ofd.Title= "请选择网址文件,一行一个";
            ofd.Filter = "文本文件(网址一行一个)|*.txt";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                txtTxtFilePath.Text = ofd.FileName;
                PreviewFileUrl();
            }
        }
        private void PreviewFileUrl()
        {
            if (!string.IsNullOrEmpty(txtTxtFilePath.Text) && System.IO.File.Exists(txtTxtFilePath.Text))
            {
                UrlCommon url = new UrlCommon();
                List<string> list = url.GetUrlsTest(txtTxtFilePath.Text);
                PreviewMultUrlFile(lbUrlPreview2, list, 7);

            }
            else
            {
                lbUrlPreview2.Items.Clear();
            }
        }
        private bool CheckUrl(string temp,bool xing=true)
        {
            return ((temp.StartsWith("http://") || temp.StartsWith("https://")) && (xing?temp.Contains("(*)"):true));
        }
        private void PreviewDateUrl()
        {
            if (CheckUrl(rtbAdressStyle.Text))
            {
                UrlCommon url = new UrlCommon();
                List<string> list = url.GetDateList(rtbDateFormat.Text, (int)numericUpDown7.Value);
                PreviewMultUrl(lbUrlPreview4, list, 12, rtbAdressStyle.Text);
            }
            else
            {
                lbUrlPreview4.Items.Clear();
            }
            
        }
        private void rtbAdressStyle_TextChanged(object sender, EventArgs e)
        {
            PreviewDateUrl();
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            string tempurl = rtbUrlFormat.Rich.Text;
            if (CheckUrl(tempurl))
            {
                if (rbArithmetic.Checked)
            {
                tempurl = tempurl.Replace("(*)", "<0," + (int)numericUpDown1.Value + "," + (int)numericUpDown2.Value + "," + (int)numericUpDown3.Value + "," + checkBox1.Checked + "," + checkBox2.Checked + ">");

            }
            else if (rbEqualProportion.Checked)
            {
                tempurl = tempurl.Replace("(*)", "<1," + (int)numericUpDown4.Value + "," + (int)numericUpDown5.Value + "," + (int)numericUpDown6.Value + "," + checkBox4.Checked + "," + checkBox3.Checked + ">");
            }
            else if (rbLetterChange.Checked)
            {
                tempurl = tempurl.Replace("(*)", "<" + txtLetterStart.Text + "," + txtLetterEnd.Text + "," + checkBox5.Checked + ">");
            }
                AddUrl(tempurl);
            }
            else
            {
                ShowEmpty();
            }
            
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            if (lbUrlPreview2.Items.Count > 0)
            {
                AddUrl("#FILE#" + txtTxtFilePath.Text);
            }
            else
            {
                ShowEmpty();
            }
      
        }

        private void txtRssUrl_TextChanged(object sender, EventArgs e)
        {
            lbUrlPreview3.Items.Clear();
        }
        private void ShowEmpty()
        {
            MessageBox.Show("请检查或者测试您的地址,请排查\r\n1.网址并不是http://或者https://开头\r\n2.没有使用(*)符号\r\n3.RSS地址未测试", "网址错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnAdd4_Click(object sender, EventArgs e)
        {
            if (lbUrlPreview3.Items.Count > 0)
            {
                AddUrl("#RSS#" + txtRssUrl.Text);
            }
            else
            {
                ShowEmpty();
            }
            
        }

        private void btnAdd5_Click(object sender, EventArgs e)
        {
            if (lbUrlPreview4.Items.Count > 0)
            {
                AddUrl(rtbAdressStyle.Text.Replace("(*)", "<" + rtbDateFormat.Text + "," + (int)numericUpDown7.Value + ">"));
            }
            else
            {
                ShowEmpty();
            }


        }

        private void btnRssTest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRssUrl.Text) )
            {
                UrlCommon url = new UrlCommon();
                List<string> list = url.GetRssUrlList(txtRssUrl.Text);
                PreviewMultUrlFile(lbUrlPreview3, list, 12);

            }
            else
            {
                lbUrlPreview3.Items.Clear();
            }
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            PreviewDateUrl();
        }

        private void numericUpDown7_Validating(object sender, CancelEventArgs e)
        {
            PreviewDateUrl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbAll.Items.Count==0)
            {
                MessageBox.Show("全部地址列表中没有任何地址内容，请先确认添加", "尚未添加网址", MessageBoxButtons.OK, MessageBoxIcon.Error);return;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < lbAll.Items.Count; i++)
            {
                list.Add(lbAll.Items[i].ToString());
            }
            this.Tag = list;
            this.DialogResult = DialogResult.OK;
        }
    }
}
