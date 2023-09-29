using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gac;
using System.IO;

namespace WebPostModule
{
    public partial class FrmM : Form
    {
        ModuleCommon mc = new ModuleCommon();
        const string Title = "WEB发布模块编辑器";
        public FrmM()
        {
            InitializeComponent();
        }
        public FrmM(string filename)
        {
            
            InitializeComponent();
            ReadModule(filename);
        }

        private void btnLoginPostClear_Click(object sender, EventArgs e)
        {
            lvLoginPost.Items.Clear();
        }

        private void txtCopyRightInfo_TextChanged(object sender, EventArgs e)
        {
            llDemo.Text = txtCopyRightInfo.Text;
        }

        private void llDemo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(txtCopyRightLink.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvLoginPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLoginPost.SelectedItems != null && lvLoginPost.SelectedItems.Count > 0)
            {
                btnLoginPostEdit.Enabled = btnLoginPostDelete.Enabled = true;
            }
            else
            {
                btnLoginPostEdit.Enabled = btnLoginPostDelete.Enabled = false;
            }
        }

        private void btnLoginPastePost_Click(object sender, EventArgs e)
        {
            GetPostData(lvLoginPost);
        }

        private void btnLoginExtract_Click(object sender, EventArgs e)
        {
            ExtractPostData(lvLoginPost);
        }

        private void ucbLoginPost_Click(object sender, EventArgs e)
        {
            pLogin.Visible = false;
        }

        private void LoginPostCancel_Click(object sender, EventArgs e)
        {
            pLogin.Visible = false;
        }

        private void btnLoginPostAdd_Click(object sender, EventArgs e)
        {
            pLogin.Tag = 0;
            pLogin.Visible = true;
            txtLoginPostKey.Text = "";
            rtbeLoginPostValue.TextValue = "";
        }

        private void btnLoginPostEdit_Click(object sender, EventArgs e)
        {
            EditLoginPost();
        }
        private void EditLoginPost()
        {
            if (lvLoginPost.SelectedItems != null && lvLoginPost.SelectedItems.Count > 0)
            { 
            int index = lvLoginPost.SelectedItems[0].Index;
            pLogin.Tag = index;
            string key = lvLoginPost.Items[index].SubItems[0].Text;
            string value = lvLoginPost.Items[index].SubItems[1].Text;
            txtLoginPostKey.Text = key;
            rtbeLoginPostValue.TextValue = value;
            pLogin.Visible = true;
            }
        }

        private void btnLoginPostSave_Click(object sender, EventArgs e)
        {
            int index = (int)pLogin.Tag;
            if (index == 0)
            {
                lvLoginPost.Items.Add(new ListViewItem(new string[] { txtLoginPostKey.Text, rtbeLoginPostValue.TextValue }));
            }
            else
            {
                lvLoginPost.Items[index].SubItems[0].Text = txtLoginPostKey.Text;
                lvLoginPost.Items[index].SubItems[1].Text = rtbeLoginPostValue.TextValue;
            }
            pLogin.Visible = false;
        }

        private void lvLoginPost_DoubleClick(object sender, EventArgs e)
        {
            EditLoginPost();
        }

        private void btnLoginPostDelete_Click(object sender, EventArgs e)
        {
           
            foreach (ListViewItem item in lvLoginPost.SelectedItems)
            {
                lvLoginPost.Items.RemoveAt(item.Index);
            }
        }

        private void FrmM_Load(object sender, EventArgs e)
        {
            cmbForceEncoding.SelectedIndex = 0;

            
        }

        private void btnHashDicAdd_Click(object sender, EventArgs e)
        {
            pHashDic.Tag = 0;
            rtbeHashStart.TextValue = rtbeHashEnd.TextValue = rtbeHashUrl.TextValue = rtbeHashRefer.TextValue = "";
            pHashDic.Visible = true;
        }

        private void btnHashDicEdit_Click(object sender, EventArgs e)
        {
            EditHashDic();
            
        }

        private void btnHashDicDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvHashDic.SelectedItems)
            {
                lvHashDic.Items.RemoveAt(item.Index);
            }
        }

        private void btnHashDicSave_Click(object sender, EventArgs e)
        {

            int index = (int)pHashDic.Tag;
            if (index == 0)
            {
                string name = GetHashName();
                lvHashDic.Items.Add(new ListViewItem(new string[] { name,rtbeHashUrl.TextValue, rtbeHashRefer.TextValue, rtbeHashStart.TextValue, rtbeHashEnd.TextValue, chkOnlyOnce.Checked.ToString() }));
            }
            else
            {
                lvHashDic.Items[index].SubItems[1].Text= rtbeHashUrl.TextValue;
                lvHashDic.Items[index].SubItems[2].Text = rtbeHashRefer.TextValue;
                lvHashDic.Items[index].SubItems[3].Text = rtbeHashStart.TextValue;
                lvHashDic.Items[index].SubItems[4].Text = rtbeHashEnd.TextValue;
                lvHashDic.Items[index].SubItems[5].Text = chkOnlyOnce.Checked.ToString();
            }
            pHashDic.Visible = false;
        }

        private void btnHashDicCancel_Click(object sender, EventArgs e)
        {
            pHashDic.Visible = false;
        }
        private void EditHashDic()
        {
            if (lvHashDic.SelectedItems != null && lvHashDic.SelectedItems.Count > 0)
            {
                int index = lvHashDic.SelectedItems[0].Index;
                pHashDic.Tag = index;
                rtbeHashUrl.TextValue= lvHashDic.Items[index].SubItems[1].Text;
                rtbeHashRefer.TextValue = lvHashDic.Items[index].SubItems[2].Text;
                rtbeHashStart.TextValue = lvHashDic.Items[index].SubItems[3].Text;
                rtbeHashEnd.TextValue = lvHashDic.Items[index].SubItems[4].Text;
                chkOnlyOnce.Checked = Convert.ToBoolean( lvHashDic.Items[index].SubItems[5].Text);
                pHashDic.Visible = true;
            }
        }
        private string GetHashName()
        {
            int index = 0;
            string name = "";
            while (true)
            {
                index++;
                name = "[网页随机值" + index + "]";
                foreach (ListViewItem item in lvHashDic.Items)
                {
                    if (item.Text== name)
                    {
                        continue;
                    }
                }
                break;
            }
            return name;
        }
        private void lvHashDic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHashDic.SelectedItems != null && lvHashDic.SelectedItems.Count > 0)
            {
                btnHashDicEdit.Enabled = btnHashDicDelete.Enabled = true;
            }
            else
            {
                btnHashDicEdit.Enabled = btnHashDicDelete.Enabled = false;
            }
        }

        private void lvHashDic_DoubleClick(object sender, EventArgs e)
        {
            EditHashDic();
        }

        private void btnLoadModule_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Web发布模块文件(*.gpm;*.wpm)|*.gpm;*.wpm";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
              
                ReadModule(ofd.FileName);
            }
        }
        private void ReadModule(string filename)
        {
            btnSave.Tag = filename;
            lvLoginPost.Items.Clear();
            lvHashDic.Items.Clear();
            lvPostData.Items.Clear();
            ModuleInfo mi = mc.ReadModule(filename);
            EditModule(filename);
            //string name = Path.GetFileName(filename);
            //string name1 = Path.GetFileNameWithoutExtension(filename);
            //SetStatus("编辑模块" + name);
            //this.Text = name1 + " - " + Title;
            ShowModuleInfo(mi);
        }
        private void ShowModuleInfo(ModuleInfo mi)
        {
            bool IsAuth = false;
            if (mi.Password.Count > 0&& !string.IsNullOrEmpty(mi.Password[0]))
            {
                FrmPassWord frm = new FrmPassWord(mi);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    IsAuth = true;
                }
            }
            else
            {
                IsAuth = true;
            }
            txtCmsName.Text = mi.CmsName;
            txtCmsVersion.Text = mi.CmsVersion;
            if (IsAuth)
            {


                #region 登陆部分
                rtbeLoginUrl.TextValue = ListToTextOne(mi.LoginUrl);
                rtbeLoginRefer.TextValue = ListToTextOne(mi.LoginRefer);
                rtbeLoginImgUrl.TextValue = ListToTextOne(mi.LoginImgUrl);
                foreach (var item in mi.LoginPostCollection)
                {
                    ListViewItem li = new ListViewItem(new string[] { item.Key, item.Value });
                    lvLoginPost.Items.Add(li);
                }
                txtLoginSuccessInfo.Text = "";//ListToText(mi.LoginSuccessInfo)
                txtLoginErrInfo.Text = ListToText(mi.LoginErrInfo);
                txtLoginImgErrInfo.Text = ListToText(mi.LoginImgErrInfo);
                #endregion


                #region 获取栏目列表
                rtbeRefreshUrl.TextValue = ListToTextOne(mi.RefreshUrl);
                rtbeRefreshRefer.TextValue = ListToTextOne(mi.RefreshRefer);
                rtbeRefreshStart.TextValue = ListToTextOne(mi.RefreshStart);
                rtbeRefreshEnd.TextValue = ListToTextOne(mi.RefreshEnd);
                rtbeRefreshRegex.TextValue = ListToTextOne(mi.RefreshRegex);
                #endregion

                #region 网页随机值获取
                foreach (var item in mi.HashDicCollection)
                {
                    ListViewItem li = new ListViewItem(new string[] { item.Name, item.HashUrl, item.HashRefer, item.HashStart, item.HashEnd, item.OnlyOnce });
                    lvHashDic.Items.Add(li);
                }
                #endregion

                #region 内容发布参数
                rtbePostUrl.TextValue = ListToTextOne(mi.PostUrl);
                rtbePostRefer.TextValue = ListToTextOne(mi.PostRefer);
                foreach (var item in mi.PostDataCollection)
                {
                    ListViewItem li = new ListViewItem(new string[] { item.Key, item.Value });
                    lvPostData.Items.Add(li);
                }
                txtPostSuccessInfo.Text = ListToText(mi.PostSuccessInfo);
                txtPostErrInfo.Text = ListToText(mi.PostErrInfo);
                #endregion
            }
            else
            {
                tabControl1.SelectTab( 4);
            }
            tabControl1.Enabled = IsAuth;
            #region 模块说明
            txtMemo.Text = ListToTextOne(mi.Memo);
            txtCopyRightInfo.Text = ListToTextOne(mi.CopyRightInfo);
            txtCopyRightLink.Text = ListToTextOne(mi.CopyRightLink);
            if (IsAuth)
            {
                txtPassword.Text = ListToTextOne(mi.Password);
            }
            #endregion

        }
        private ModuleInfo GetModuleInfo()
        {
            ModuleInfo mi = new ModuleInfo();
            mi.CmsName= txtCmsName.Text;
            mi.CmsVersion = txtCmsVersion.Text;

            #region 登陆部分
            mi.LoginUrl= OneListToText(rtbeLoginUrl.TextValue);
            mi.LoginRefer= OneListToText(rtbeLoginRefer.TextValue);
            mi.LoginImgUrl= OneListToText(rtbeLoginImgUrl.TextValue);
            foreach (ListViewItem item in lvLoginPost.Items)
            {
                mi.LoginPostCollection.Add(new LoginPost() {  Key=item.SubItems[0].Text,Value=item.SubItems[1].Text});
            }

            mi.LoginSuccessInfo=txtLoginSuccessInfo.Text.Split(new string[] {"\r\n" },StringSplitOptions.RemoveEmptyEntries);
            mi.LoginErrInfo = TextToList(txtLoginErrInfo.Text);
            mi.LoginImgErrInfo = TextToList(txtLoginImgErrInfo.Text);
            #endregion


            #region 获取栏目列表
            mi.RefreshUrl= OneListToText(rtbeRefreshUrl.TextValue);
            mi.RefreshRefer= OneListToText(rtbeRefreshRefer.TextValue);
            mi.RefreshStart= OneListToText(rtbeRefreshStart.TextValue);
            mi.RefreshEnd= OneListToText(rtbeRefreshEnd.TextValue);
            mi.RefreshRegex= OneListToText(rtbeRefreshRegex.TextValue);
            #endregion

            #region 网页随机值获取
            foreach (ListViewItem item in lvHashDic.Items)
            {
                HashDic hd = new HashDic()
                {
                    Name = item.SubItems[0].Text,
                    HashUrl= item.SubItems[1].Text,
                    HashRefer= item.SubItems[2].Text,
                    HashStart=item.SubItems[3] .Text,
                    HashEnd= item.SubItems[4].Text,
                     OnlyOnce=item.SubItems[5].Text
                };
                mi.HashDicCollection.Add(hd);
            }
            #endregion

            #region 内容发布参数
            mi.PostUrl= OneListToText(rtbePostUrl.TextValue);
            mi.PostRefer= OneListToText(rtbePostRefer.TextValue);
            foreach (ListViewItem item in lvPostData.Items)
            {
                PostData pd = new PostData() {
                    Key = item.SubItems[0].Text,
                    Value = item.SubItems[1].Text
                };
                mi.PostDataCollection.Add(pd);
            }
            mi.PostSuccessInfo =TextToList( txtPostSuccessInfo.Text);
            mi.PostErrInfo = TextToList(txtPostErrInfo.Text);
            #endregion

            #region 模块说明
            mi.Memo= OneListToText(txtMemo.Text);
            mi.CopyRightInfo= OneListToText(txtCopyRightInfo.Text);
            mi.CopyRightLink= OneListToText(txtCopyRightLink.Text);
            mi.Password= OneListToText(txtPassword.Text);
            #endregion

            return mi;
        }
        public string ListToText(List<string> list)
        {
            if (list==null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    sb.AppendLine(item);
                }
                
            }
            return sb.ToString();
        }
        public string ListToTextOne(List<string> list)
        {
            if (list.Count>0)
            {
                return list[0];
            }
            return "";
        }
        public List<string> OneListToText(string Text)
        {
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(Text))
            {
                list.Add(Text);
            }
            return list;
        }
        public List<string> TextToList(string Text)
        {
            List<string> list = new List<string>();
            string[] strs = Text.Split(new string[] {"\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in strs)
            {
                list.Add(item);
            }
            return list;
        }
        private void SetStatus(string msg)
        {
            tsslStatus.Text = msg;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            gacContextMenuStrip1.OperationControl = rtbePostUrl;
            gacContextMenuStrip1.Show(button17, button17.Width,0);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            gacContextMenuStrip1.OperationControl = rtbePostRefer;
            gacContextMenuStrip1.Show(button16, button16.Width, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            rtbePostValue.InsertText(button7.Text);
        }

        private void ucCloseButton1_Click(object sender, EventArgs e)
        {
            pnPostEdit.Visible = false;
        }

        private void btnPostCancel_Click(object sender, EventArgs e)
        {
            pnPostEdit.Visible = false;
        }

        private void btnPostSave_Click(object sender, EventArgs e)
        {
            int index = (int)pnPostEdit.Tag;
            if (index == 0)
            {
                lvPostData.Items.Add(new ListViewItem(new string[] { txtPostKey.Text, rtbePostValue.TextValue }));
            }
            else
            {
                lvPostData.Items[index].SubItems[0].Text = txtPostKey.Text;
                lvPostData.Items[index].SubItems[1].Text = rtbePostValue.TextValue;
            }
            pnPostEdit.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gacContextMenuStrip2.Show(button4, button4.Width, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gacContextMenuStrip3.Show(button5, button5.Width, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gacContextMenuStrip4.Show(button6, button6.Width, 0);
        }

        private void lvPostData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPostData.SelectedItems != null && lvPostData.SelectedItems.Count > 0)
            {
                btnPostDataEdit.Enabled = btnPostDataDelete.Enabled = true;
            }
            else
            {
                btnPostDataEdit.Enabled = btnPostDataDelete.Enabled = false;
            }
        }

        private void btnPostDataAdd_Click(object sender, EventArgs e)
        {
            pnPostEdit.Tag = 0;
            txtPostKey.Text = "";
            rtbePostValue.TextValue = "";
            pnPostEdit.Visible = true;
        }

        private void btnPostDataEdit_Click(object sender, EventArgs e)
        {
            PostDataEdit();
        }
        private void PostDataEdit()
        {
            if (lvPostData.SelectedItems != null && lvPostData.SelectedItems.Count > 0)
            {
                int index = lvPostData.SelectedItems[0].Index;
                pnPostEdit.Tag = index;
                string key = lvPostData.Items[index].SubItems[0].Text;
                string value = lvPostData.Items[index].SubItems[1].Text;

                txtPostKey.Text = key;
                rtbePostValue.TextValue = value;

                pnPostEdit.Visible = true;
            }
        }

        private void lvPostData_DoubleClick(object sender, EventArgs e)
        {
            PostDataEdit();
        }

        private void btnPostDataClear_Click(object sender, EventArgs e)
        {
            lvPostData.Items.Clear();
        }

        private void btnPostDataDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvPostData.SelectedItems)
            {
                lvPostData.Items.RemoveAt(item.Index);
            }
        }

        private void btnNewOrReset_Click(object sender, EventArgs e)
        {
            btnSave.Tag = null;
            tabControl1.Enabled = true;
            Text =  "新建模块 - " + Title;
            SetStatus("新建模块");
            ShowModuleInfo(new ModuleInfo());
            txtCopyRightInfo.Text = "GAC Collection";
            txtCopyRightLink.Text = "http://www.gac.cc/";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ExtractPostData(lvPostData);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            GetPostData(lvPostData);
        }
        private void GetPostData(ListView lv)
        {
            FrmGetPost frm = new FrmGetPost();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> dic = (Dictionary<string, string>)frm.Tag;
                foreach (var item in dic)
                {
                    ListViewItem li = new ListViewItem(new string[] { item.Key, item.Value });
                    lv.Items.Add(li);
                }
            }
        }
        private void ExtractPostData(ListView lv)
        {
            if (lv.Items.Count==0)
            {
                return;
            }
            string temp = "-----------------------------6ldggaccollection";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(temp);
            foreach (ListViewItem item in lv.Items)
            {
                sb.AppendLine(item.SubItems[0].Text);
                sb.AppendLine(item.SubItems[1].Text);
                sb.AppendLine(temp);
            }
            try
            {
                Clipboard.SetText(sb.ToString());
                MessageBox.Show("POST代码已复制到剪贴板", "复制成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "复制失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rtbePostUrl.TextValue == "")
            {
                MessageBox.Show("模块中内容发布设置里 Post地址为必填项，请返回填写", "请填写完整", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                tabControl1.SelectedIndex = 3;
                this.rtbePostUrl.Rich.Focus();
                return;
            }
            if (!tabControl1 .Enabled)
            {
                MessageBox.Show("该模块设置了密码保护，请联系模块开发者");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Web发布模块文件(*.gpm;*.wpm)|*.gpm;*.wpm;";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".gpm";
            string ModuleDir = Application.StartupPath + "\\Module";
            saveFileDialog.InitialDirectory = ModuleDir;
            if (btnSave.Tag != null)
            {
                FileInfo fileInfo = new FileInfo(this.btnSave.Tag.ToString());
                saveFileDialog.InitialDirectory = fileInfo.Directory.FullName;
                saveFileDialog.FileName = System.IO.Path.GetFileName(fileInfo.FullName);
            }
            else if (txtCmsName. Text != "")
            {
                saveFileDialog.FileName = txtCmsName.Text + txtCmsVersion .Text;
            }
            if (!Directory.Exists(ModuleDir))
            {
                Directory.CreateDirectory(ModuleDir);
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ModuleInfo mi = GetModuleInfo();
                if (mc.SaveModule(saveFileDialog.FileName, mi))
                {
                    btnSave.Tag = saveFileDialog.FileName;
                    MessageBox.Show("成功保存/修改模块文件", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    EditModule(saveFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show("保存失败", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
           
        }
        private void EditModule(string filename)
        {
            string name = Path.GetFileName(filename);
            string name1 = Path.GetFileNameWithoutExtension(filename);
            SetStatus("编辑模块" + name);
            this.Text = name1 + " - " + Title;
        }


    }
}
