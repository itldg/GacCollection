using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GAC_Collection.Ex;

namespace GacContextMenuStrip
{
    public partial class GacContextMenuStrip : ContextMenuStrip
    {
        public GacContextMenuStrip()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        [Description("设置点击菜单后操作的控件，只支持RichTextBox"), Category("GAC_Collection")]
        public RichTextBoxEx OperationControl { get; set; }
        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            if (OperationControl==null)
            {
                return;
            }
            OperationControl.InsertText(e.ClickedItem.Text);
            //string Replacevalue = e.ClickedItem.Text;
            //if (OperationControl.Rich.SelectedText.Length > 0)
            //{
            //    OperationControl.Rich.SelectedText = Replacevalue;
            //}
            //else
            //{
            //    OperationControl.Rich.SelectedText = OperationControl.Rich.SelectedText.Insert(0, Replacevalue);
            //}
            this.Hide();
            //MessageBox.Show(e.ClickedItem.Text);
        }

    }
}
