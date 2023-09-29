using GAC_Collection.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GacDB.Class;

namespace GAC_Collection.MainUi.Task
{
    public partial class FrmWebModule : Form
    {
        ModuleDb md = null;
        public FrmWebModule(ModuleDb moduleDb)
        {
            InitializeComponent();
            md = moduleDb;
        }

        private void FrmWebModule_Load(object sender, EventArgs e)
        {
            List<ClassModule> list = md.GetList();
            lbMain.Items.Clear();
            foreach (var item in list)
            {
                lbMain.Items.Add(item);
            }
        }
        private void Save()
        {
            if (lbMain.SelectedItem!=null)
            {
                this.Tag = lbMain.SelectedItem;
                DialogResult = DialogResult.OK;
            }
          
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lbMain_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnOk.Enabled = lbMain.SelectedItem != null;
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void lbMain_DoubleClick(object sender, EventArgs e)
        {
            Save();
        }
    }
}
