using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Text.RegularExpressions;

namespace WebPostModule
{
    public partial class FrmGetPost : Form
    {
        public FrmGetPost()
        {
            InitializeComponent();
        }

        private void lbenUtf8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtPostData.Text=HttpUtility.UrlDecode(txtPostData.Text, Encoding.UTF8);
        }

        private void llengbk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtPostData.Text = HttpUtility.UrlDecode(txtPostData.Text, Encoding.GetEncoding("GBK"));
        }

        Regex reg = new Regex("([^&]*?)=(.*?)($|&)");
        private void btnGetData_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtPostData.Text.StartsWith("-"))
            {
                MessageBox.Show("暂不支持multipart/form-data类型数据获取", "获取失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MatchCollection mcs = reg.Matches(txtPostData.Text);
                foreach (Match item in mcs)
                {
                    dic.Add(item.Groups[1].Value, item.Groups[2].Value);
                }
            }
            if (dic.Count > 0)
            {
                Tag = dic;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("没有获取到任何的POST数据，请检查数据格式", "获取失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
