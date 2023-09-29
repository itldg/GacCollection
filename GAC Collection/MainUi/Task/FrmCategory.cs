using AdvancedDataGridView;
using Gac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAC_Collection.MainUi.Task
{
    public partial class FrmCategory : Form
    {
        int action = 0;//1 currentadd,2 edit
        Class.RuleCategory RuleCategory = null;
        //public FrmCategory()
        //{
        //    InitializeComponent();
            
        //}
        public FrmCategory(int Action=0,Class.RuleCategory Value=null)
        {
            InitializeComponent();
            action = Action;
            RuleCategory = Value;

        }


        private void FrmAddCategory_Load(object sender, EventArgs e)
        {
            CmbItem cmbitemtemp = new CmbItem("根节点 [ID=0]", 0);
            cmbParent.Items.Add(cmbitemtemp);
            FrmTaskList frm = (FrmTaskList)((FrmMain)this.Owner).frmtask;
            for (int i = 1; i < frm.tvTask.Nodes.Count; i++)
            {
                AddCategoryItems(frm.tvTask.Nodes[i]);
            }
            if (action != 0)
            {
                if (action == 2)
                {
                    txtName.Text = RuleCategory.Name;
                    txtRemarks.Text = RuleCategory.Remarks;
                    for (int i = 0; i < cmbParent.Items.Count; i++)
                    {
                        if ((int)((CmbItem)cmbParent.Items[i]).Value == RuleCategory.Id)
                        {
                            cmbParent.Items.RemoveAt(i);
                            break;
                        }
                    }
                }

                for (int i = 0; i < cmbParent.Items.Count; i++)
                {
                    if ((int)((CmbItem)cmbParent.Items[i]).Value == (action==1?RuleCategory.Id: RuleCategory.ParentId))
                    {
                        cmbParent.SelectedIndex = i;
                    }
                }
                

            }
            else { 
            cmbParent.SelectedIndex = 0;
            }
        }
        private void AddCategoryItems(TreeGridNode Node,string Prefix="")
        {
            if(Node.Tag is Class.RuleCategory)
            { 
                Class.RuleCategory category = (Class.RuleCategory)Node.Tag;
                CmbItem cmbitem = new CmbItem(Prefix+Node.Cells[0].Value + " [ID=" + category.Id + "]", category.Id);
                cmbParent.Items.Add(cmbitem);
                for (int i = 0; i < Node.Nodes.Count; i++)
                {
                    AddCategoryItems(Node.Nodes[i], Prefix+"--");
                }
            }

        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = (int)((CmbItem)cmbParent.SelectedItem).Value;
            if (action != 2)
            {
                
                Class.RuleCategory category = new Class.RuleCategory(txtName.Text, 0, id, txtRemarks.Text, false, false, false, null);
                this.Tag = category;
            }
            else
            {
                RuleCategory.ParentId = id;
                RuleCategory.Name = txtName.Text;
                RuleCategory.Remarks = txtRemarks.Text;
                this.Tag = RuleCategory;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
