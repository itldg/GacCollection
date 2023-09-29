using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gac;

namespace GAC_Collection
{
    public partial class FrmTest : Form
    {
        string _ModuleName = "";
        ModuleCommon mc = new ModuleCommon();
        ModuleConfigInfo mci = new ModuleConfigInfo();
        ModuleInfo mi = null;
        public FrmTest(ModuleConfigInfo mci,Dictionary<string,string> dic=null)
        {
            InitializeComponent();
            this.mci = mci;
            if (!string.IsNullOrEmpty(mci.ModuleName))
            {
                mi = mc.ReadModule("Module\\" + mci.ModuleName + ".gpm");
                PostList pl= mc.GetTestData(mci.ModuleName,mi, dic);
                lvPost.Items.Clear();
                foreach (var item in pl.PostData)
                {
                    lvPost.Items.Add(new ListViewItem(new string[] {
                        item.Key,item.Value
                    }));
                }
            }
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {

        }
        int EditId = -1;
        private void lvPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPost.SelectedItems != null&&lvPost.SelectedItems.Count>0)
            {
                EditId = lvPost.SelectedIndices[0];
                txtContent.Text = lvPost.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (EditId>=0)
            {
                lvPost.Items[EditId].SubItems[1].Text = txtContent.Text;
                txtContent.Text = "";
                EditId = -1;
            }
           

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtContent.Clear();
        }

        private void FrmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            PostList pl = new PostList();
            List<PostData> lp = new List<PostData>();
            foreach (ListViewItem item in lvPost.Items)
            {
                lp.Add(new PostData()
                {
                    Key = item.SubItems[0].Text,
                    Value =item.SubItems[1].Text
                });
            }
            pl.PostData = lp.ToArray();
            mc.SaveTestData(_ModuleName, pl);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            OutWeb ow = new OutWeb(mi, mci);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (ListViewItem item in lvPost.Items)
            {
                dic.Add(item.SubItems[0].Text, item.SubItems[1].Text);
            }
            ReturnResult rr = ow.Out(dic);
            if (rr.Success)
            {
                txtResult.Text = rr.Msg+"\r\n";
            }
            else
            {
                txtResult.Text = "发布失败，错误信息：\r\n" + rr.Msg + "\r\n";
            }
            txtResult.AppendText(rr.Obj.ToString());
            txtResult.Tag = rr.Tag;

        }

        private void btnBrowserView_Click(object sender, EventArgs e)
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
