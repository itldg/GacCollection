using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Gac;
using GacDB;
using GacDB.Class;
using GAC_Collection.Common;
using GacBrowser;
using GAC_Collection;

namespace WebPostManager
{
    public partial class FrmMain : Form
    {
        string ModuleDir = Application.StartupPath + "\\Module\\";
        bool IsLogin = false;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void pnNoLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbLoginType_CheckedChanged(object sender, EventArgs e)
        {
            pnWeb.Visible = pnPost.Visible = pnNoLogin.Visible = false;
            if (rbLoginType1.Checked)
            {
                pnWeb.Visible = true;
            }
            else if (rbLoginType2.Checked)
            {
                pnPost.Visible = true;
            }
            else
            {
                pnNoLogin.Visible = true;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cmbEncoding.SelectedIndex = 0;
            ReadModules();
        }

        private void btnGetCategory_Click(object sender, EventArgs e)
        {
            if (!IsLogin&&string.IsNullOrEmpty(txtCookies.Text))
            {
                MessageBox.Show("您选择了网站登陆，但没有获得任何登陆信息！", "登陆信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            
            ReturnResult rr = wp.GetList();
            ShowHtml(rr.Success, rr.Obj);
            if (rr.Success)
            {
                List<CategoryResult> list = (List<CategoryResult>)rr.Obj;
                cmbCategory.Items.Clear();
                foreach (var item in list)
                {
                    cmbCategory.Items.Add(item);
                }
                if (cmbCategory.Items.Count>0)
                {
                    cmbCategory.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show(rr.Msg, "获取失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void llResultClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtResultHtml.Visible = llResultClose.Visible = false;
        }
        private void ReadModules()
        {
            
            if (!Directory.Exists(ModuleDir))
            {
                Directory.CreateDirectory(ModuleDir);
            }
            cmbModuleName.Items.Clear();
          
            string[] files = Directory.GetFiles(ModuleDir, "*.gpm");
            foreach (var item in files)
            {
                string name= Path.GetFileNameWithoutExtension(item);
                cmbModuleName.Items.Add(name);
            }
        }
        ModuleCommon mc = new ModuleCommon();
        ModuleInfo mi = new ModuleInfo();
        private void cmbModuleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsLogin = false;
            string name = cmbModuleName.Text;
            string filename = ModuleDir + name + ".gpm";
            mi= mc.ReadModule(filename);

            txtGlobalVar.Enabled = !string.IsNullOrEmpty(mi.HaveGlobalVar);
            txtCategoryId.Enabled = !string.IsNullOrEmpty(mi.HaveSortId);
            txtCategoryName.Enabled = !string.IsNullOrEmpty(mi.HaveSortName);

            btnGetCategory.Enabled = cmbCategory.Enabled = !string.IsNullOrEmpty(mi.RefreshUrl);

            btnGetRand.Enabled = txtRandNumer.Enabled = !string.IsNullOrEmpty(mi.LoginImgUrl);


        }

        private void btnModuleEdit_Click(object sender, EventArgs e)
        {
            string name = cmbModuleName.Text;

            System.Diagnostics.Process.Start("WebPostModule.exe", name);
        }
        
        private void btnModuleAdd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WebPostModule.exe");
        }
        ModuleDb md = new ModuleDb();
        ModuleConfigCommon mcc = new ModuleConfigCommon();
        private void ReadConfigList()
        {
            btnSave.Tag = null;
            ShowModuleConfig(new ModuleConfigInfo());
            List<ClassModule> listcm= md.GetList();
            lbConfig.Items.Clear();
            foreach (var item in listcm)
            {
                lbConfig.Items.Add(item);
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            ReadConfigList();
        }

        private void EditModule()
        {
            if (lbConfig.SelectedItem != null)
            {
                ClassModule cm = ((ClassModule)lbConfig.SelectedItem);
                btnSave.Tag = cm;
                ModuleConfigInfo mci = mcc.GetModuleConfigInfo(cm.XmlData);
                ShowModuleConfig(mci);
                //ModuleConfigInfo mci = GetModuleConfig();
                wp = new OutWeb(mi, mci);
                Text = cm.PostName+"-WEB发布配置管理";
            }
        }
        private void lbConfig_DoubleClick(object sender, EventArgs e)
        {
            EditModule();

        }
        private void ShowModuleConfig(ModuleConfigInfo mci)
        {
            cmbModuleName.Text = mci.ModuleName;
            txtGlobalVar.Text = mci.GlobalVar;
            cmbEncoding.Text = mci.Encoding;

            txtSiteUrl.Text = mci.SiteUrl;
            if (mci.LoginType == 0)
            {
                rbLoginType1.Checked = true;
            }
            else if (mci.LoginType == 1)
            {
                rbLoginType2.Checked = true;
            }
            else {
                rbLoginType3.Checked = true;
            }

            txtUserAgent.Text = mci.UserAgent;
            txtCookies.Text = mci.Cookies;

            txtUserName.Text = mci.UserName;
            txtPassword.Text = mci.Password;

            txtAcceptLanguage.Text = mci.AcceptLanguage;
            nudTimeOut.Value= mci.TimeOut;

            txtCategoryId.Text = mci.Fid;
            txtCategoryName.Text = mci.FName;

            if (btnSave.Tag!=null)
            {
                txtSetName.Text= ((ClassModule)btnSave.Tag).PostName;
            }
        }
        private ModuleConfigInfo GetModuleConfig()
        {
            ModuleConfigInfo mci = new ModuleConfigInfo();
            mci.ModuleName = cmbModuleName.Text;
            mci.GlobalVar=txtGlobalVar.Text;
            mci.Encoding = cmbEncoding.Text;

            mci.SiteUrl=txtSiteUrl.Text;
            if (rbLoginType1.Checked== true)
            {
                mci.LoginType = 0;
            }
            else if (rbLoginType2.Checked == true)
            {
                mci.LoginType = 1;
            }
            else
            {
                mci.LoginType = 2;
            }

            mci.UserAgent=txtUserAgent.Text;
            mci.Cookies=txtCookies.Text ;

            mci.UserName=txtUserName.Text;
            mci.Password=txtPassword.Text;

            mci.AcceptLanguage=txtAcceptLanguage.Text;
            mci.TimeOut=(int)nudTimeOut.Value;

            mci.Fid=txtCategoryId.Text;
            mci.FName=txtCategoryName.Text;
            return mci;
        }

        private void btnStartWebBrowser_Click(object sender, EventArgs e)
        {
            FrmBrowser wftm = new FrmBrowser();
            wftm.getFlag = 0;
            wftm.txtUrl.Text = txtSiteUrl.Text;
            if (wftm.ShowDialog() == DialogResult.OK)
            {
                txtCookies.Text = wftm.Tag.ToString();
            }
            wftm.Dispose();
        }

        private void btnSetEdit_Click(object sender, EventArgs e)
        {
            EditModule();
        }

        private void btnSetDelete_Click(object sender, EventArgs e)
        {
            if (lbConfig.SelectedItem != null)
            {
                ClassModule cm = ((ClassModule)lbConfig.SelectedItem);
                if (md.ModuleDelete(cm.ID))
                {

                    MessageBox.Show("成功删除配置信息", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (btnSave.Tag== lbConfig.SelectedItem)
                    {
                        btnSave.Tag = null;
                    }
                    lbConfig.Items.Remove(lbConfig.SelectedItem);
                }
                else
                {
                    MessageBox.Show("删除失败了", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }


            }
        }

        private void btnSetAdd_Click(object sender, EventArgs e)
        {
            btnSave.Tag = null;
            ShowModuleConfig(new ModuleConfigInfo());
            Text = "新建-WEB发布配置管理";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ModuleConfigInfo mci = GetModuleConfig();
            string xmldata= mcc.GetXmlData(mci);

            ClassModule cm = new ClassModule() {
                ModifyOn = DateTime.Now,
                PostName = txtSetName.Text,
                XmlData = xmldata
            };
            if (btnSave.Tag != null)
            {
                cm.ID = ((ClassModule)btnSave.Tag).ID;
            }
            if (md.ModuleUpdate(cm)>0)
            {

                MessageBox.Show("保存配置成功", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ReadConfigList();
            }
            else
            {
                MessageBox.Show("保存失败了", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
           
           
        }
        //WebPost wp = new WebPost(new ModuleInfo(), new ModuleConfigInfo());
        OutWeb wp = new OutWeb(new ModuleInfo(), new ModuleConfigInfo());
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            ReturnResult rr = wp.Login(txtRandNumer.Text);
            ShowHtml(rr.Success, rr.Obj);
            if (rr.Success)
            {
                MessageBox.Show(rr.Msg, "登陆成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                IsLogin = true;
                txtCookies.Text = rr.Obj.ToString();
            }
            else
            {
                MessageBox.Show(rr.Msg, "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                
            }
        }
        private void ShowHtml(bool Hide,object html=null)
        {

            llResultClose.Visible = !Hide;
            txtResultHtml.Visible = !Hide;
            
           

            if (!Hide)
            {
                txtResultHtml.Text = html.ToString();
            }
        }



        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem is CategoryResult)
            {
                CategoryResult cr = ((CategoryResult)cmbCategory.SelectedItem);
                txtCategoryId.Text = cr.ID;
                txtCategoryName.Text = cr.Name;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            FrmTest frm = new FrmTest(GetModuleConfig());
            frm.ShowDialog();

        }

        private void lbConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSetEdit.Enabled = btnSetDelete.Enabled = (lbConfig.SelectedItem != null);
        }

        private void 刷新列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadModules();
        }

        private void btnModuleMore_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnModuleMore, btnModuleMore.Width, 0);
        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Web发布模块文件(*.gpm;*.wpm)|*.gpm;*.wpm";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ModuleInfo mi= mc.ReadModule(ofd.FileName);
                    string filename = Path.GetFileNameWithoutExtension(ofd.FileName);
                    string savename = ModuleDir + filename + ".gpm";
                    if (File.Exists(savename))
                    {
                        int index = 1;
                        while (true)
                        {
                            savename = ModuleDir + filename + "_" + index + ".gpm";
                            if (!File.Exists(savename))
                            {
                                break;
                            }
                            index++;
                        }
                        
                    }
                    if (mc.SaveModule(savename, mi))
                    {
                        MessageBox.Show("成功导入发布模块", "导入成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ReadModules();
                    }
                    else
                    {
                        MessageBox.Show("导入文件格式错误", "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Web发布模块文件(*.gpm)|*.gpm";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".gpm";
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    string filename = ModuleDir + cmbModuleName.Text + ".gpm";
                    File.Copy(filename, saveFileDialog.FileName);
                    MessageBox.Show("成功导出发布模块", "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导出失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
           
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = ModuleDir + cmbModuleName.Text + ".gpm";
                File.Delete(filename);
                MessageBox.Show("成功删除发布模块", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ReadModules();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
        }
    }

}
