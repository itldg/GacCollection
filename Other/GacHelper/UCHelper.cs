using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GacHelper
{
    public partial class UCHelper : UserControl
    {
        public UCHelper()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Description("弹出帮助内容的key"), Category("HelperKey"), DefaultValue("About")]
        public string HelperKey
        {
            set;
            get;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty( HelperKey))
            {
                FrmHelper frm = new FrmHelper(HelperKey);
                //Control c = this;
                //while (c.Parent!=null)
                //{
                //    c = c.Parent;
                //}
                frm.Show();
            }
            base.OnClick(e);
        }

    }
}
