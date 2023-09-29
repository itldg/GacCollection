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
    public partial class FrmInput : Form
    {
        public delegate bool CheckDataEvent(string Data);
        public event CheckDataEvent CheckData;
        public string Result = "";
        bool isEmpty = false;
        string DataName = "";
        /// <summary>
        /// 输入窗口
        /// </summary>
        /// <param name="Title">窗口标题</param>
        /// <param name="Name">需要用户填写什么?</param>
        /// <param name="Empty">是否允许为空?</param>
        public FrmInput(string Title="请输入",string Name="数据名称",bool Empty=false)
        {
            InitializeComponent();
            this.Text = Title;
            this.lblName.Text = Name;
            isEmpty = Empty;
            DataName = Name;
        }

        private void FrmInput_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isEmpty&&string.IsNullOrEmpty(txtResult.Text))
            {
                GacCommon.ShowTip(DataName + "不可以为空,请填写正确的值",txtResult);
                //MessageBox.Show("请先获取数据库列表,获取成功后再使用此功能", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckData != null && !CheckData(txtResult.Text))
            {
                return;
            }
            Result = txtResult.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
