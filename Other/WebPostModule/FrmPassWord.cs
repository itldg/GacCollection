using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gac;

namespace WebPostModule
{
    public partial class FrmPassWord : Form
    {
        ModuleInfo mi = new ModuleInfo();
        public FrmPassWord(ModuleInfo moduleInfo)
        {
            mi = moduleInfo;
            InitializeComponent();
        }
       
        private void FrmPassWord_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mi.CopyRightInfo))
            {
                llCopyLink.Text = mi.CopyRightInfo;
            }
            txtPassWord.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassWord.Text))
            {
                DialogResult = DialogResult.No;
            }
            if (mi.Password == txtPassWord.Text)
            {
                DialogResult = DialogResult.Yes;
            }
            else
            {
                MessageBox.Show("密码错误，如果您不是模块制作者请直接点击取消或置空密码以只读方式打开", "密码错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void llCopyLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(mi.CopyRightLink))
            {
                System.Diagnostics.Process.Start(mi.CopyRightLink);
            }

        }

        private void txtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                btnOk_Click(sender, e);
            }
        }
    }
}
