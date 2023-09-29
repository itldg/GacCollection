using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GAC_Collection
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmInfo frm = new FrmInfo();
            //frm.StartPosition = FormStartPosition.CenterScreen;
            Thread t = new Thread(new ParameterizedThreadStart(TestLogin));
            t.Start(frm);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                FrmMain frmMain = new FrmMain();
                this.Hide();
                frmMain.ShowDialog();
                //this.Close();

                ////MainUi.Task.FrmUrlAdd frmadd = new MainUi.Task.FrmUrlAdd();
                ////frmadd.ShowDialog();
                ////this.Close();

                //MainUi.Task.FrmJob frmtemp = new MainUi.Task.FrmJob();
                //frmtemp.ShowDialog();

                //MainUi.Task.FrmMultiPage frmtemp = new MainUi.Task.FrmMultiPage();
                //frmtemp.ShowDialog();

                this.Close();
            }
        }

        private static void TestLogin(Object frm)
        {
            FrmInfo newfrm = (FrmInfo)frm;
            //newfrm.SetMessage("正在登陆，请稍后");
            //Thread.Sleep(1000);
            //newfrm.SetMessage("登陆成功！");
            //Thread.Sleep(500);
            newfrm.DialogResult = DialogResult.OK;

        }
    }
}
