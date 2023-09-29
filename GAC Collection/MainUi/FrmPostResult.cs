using Gac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAC_Collection.MainUi
{
    public partial class FrmPostResult : Form
    {
        public FrmPostResult(ReturnResult rr)
        {
            InitializeComponent();
            if (rr.Success)
            {
                txtResult.Text = rr.Msg + "\r\n";
            }
            else
            {
                txtResult.Text = "发布失败，错误信息：\r\n" + rr.Msg + "\r\n";
            }
            txtResult.AppendText(rr.Obj.ToString());
            txtResult.Tag = rr.Tag;
            if (rr.Success)
            {
                lblResult.ForeColor =Color. Green;
                lblResult.Text = "成功";
            }
            else if (rr.Msg == "发布结果未知")
            {
                lblResult.ForeColor = Color.Coral;
                lblResult.Text = "未知";
            }
            else
            {
                lblResult.ForeColor = Color.DarkRed;
                lblResult.Text = "失败";
            }
        }

        private void FrmPostResult_Load(object sender, EventArgs e)
        {

        }

        private void btnWebView_Click(object sender, EventArgs e)
        {
            FrmBrowserView fbv = null;
            if (txtResult.Tag == null)
            {
                fbv = new FrmBrowserView("");
            }
            else
            {
                fbv = new FrmBrowserView(txtResult.Tag.ToString());
            }
            fbv.ShowDialog();
        }
    }
}
