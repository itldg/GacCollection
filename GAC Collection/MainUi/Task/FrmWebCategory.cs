using Gac;
using GacDB.Class;
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
    public partial class FrmWebCategory : Form
    {
        ClassModule cm = null;
        ModuleInfo Mi = null;
        ModuleConfigInfo Mci = null;
        OutWeb ow = null;
        public FrmWebCategory(ClassModule classModule, string FName, string Fid)
        {
            ModuleConfigCommon mcc = new ModuleConfigCommon();
            ModuleCommon mc = new ModuleCommon();
            InitializeComponent();
            cm = classModule;
            Mci = mcc.GetModuleConfigInfo(cm.XmlData);
            Mi = mc.ReadModule(Mci.ModuleName);
            txtFid.Text = Fid;
            txtFName.Text = FName;
            ow=new OutWeb(Mi, Mci);
            if (string.IsNullOrEmpty(Mi.HaveSortId)&&string.IsNullOrEmpty(Mi.HaveSortName))
            {
                btnOk.Enabled = btnGetCategory.Enabled = cmbCategory.Enabled = groupBox1.Enabled = false;
                lbNoCategory.Visible = true;
            }
        }

        private void FrmWebCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnGetCategory_Click(object sender, EventArgs e)
        {
            ReturnResult rr= ow.GetList();
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

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryResult cr=(CategoryResult)cmbCategory.SelectedItem;
            txtFid.Text = cr.ID;
            txtFName.Text = cr.Name;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CategoryResult cr = new CategoryResult()
            {
                ID = txtFid.Text,
                Name = txtFName.Text
            };
            this.Tag = cr;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
