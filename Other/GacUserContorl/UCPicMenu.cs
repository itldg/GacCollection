using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace GAC_Collection.Ex
{
    public partial class PicMenu : UserControl
    {
        Control text = null;
        public PicMenu()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            InitCmsUserAgent();
            base.OnLoad(e);
        }

        [Browsable(true)]
        [Description("设置菜单点击前图片"), Category("Pic")]
        public Image Pic
        {

            set { pictureBox1.Image = value; }
            get { return pictureBox1.Image; }
        }
        [Browsable(true)]
        [Description("设置点击菜单后操作的控件，只支持TextBox和RichTextBox"), Category("GAC_Collection")]
        public Control OperationControl
        {

            set { if (value is TextBox || value is RichTextBox || value is RichTextBoxEx) { text = value; } }
            get { return text; }
        }

        [Browsable(true)]
        [Description("是否追加显示文本"), Category("GAC_Collection"),DefaultValue(false)]
        public bool Append
        {

            set;
            get;
        }

        [Browsable(true)]
        [Description("弹出菜单设置"), Category("GAC_Collection")]

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {

                return pictureBox1.ContextMenuStrip;
            }

            set
            {
                pictureBox1.ContextMenuStrip = value;
                //base.ContextMenuStrip = value;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.ContextMenuStrip != null)
            {
                pictureBox1.ContextMenuStrip.Show(pictureBox1, pictureBox1.Left + (pictureBox1.Width / 2), pictureBox1.Top + (pictureBox1.Height / 2));
            }
        }
        
        private void InitCmsUserAgent()
        {
            if(pictureBox1.ContextMenuStrip != null)
            { 
            for (int i = 0; i < pictureBox1.ContextMenuStrip.Items.Count; i++)
            {
                //ClearAllEvents(pictureBox1.ContextMenuStrip.Items[i], "Click");
                pictureBox1.ContextMenuStrip.Items[i].Click += UserAgentSelect;
            }
            }
            //RegistryHelper rh = new RegistryHelper();
            //string Useragent = rh.GetRegistryData("Software\\Microsoft\\Windows\\Internet Strrings", "User Agent");
            //cmsUserAgent.Items[0].Tag = Useragent;
        }

        private void UserAgentSelect(object sender, EventArgs e)
        {
            if (text==null)
            {
                return;
            }
            ToolStripItem menu = (ToolStripItem)sender;

            string value = "";
            if (menu.Tag != null && menu.Tag is string)
            {
                value = menu.Tag.ToString();
                
            }
            else
            {
                value = menu.Text;
            }

            if (Append)
            {
                if (text is TextBox)
                {
                    TextBox textBox1 = (TextBox)text;
                    int start = textBox1.SelectionStart;
                    textBox1.Text = textBox1.Text.Insert(start, value);
                    textBox1.Focus();
                    textBox1.Select(value.Length, 0);
                }
                if (text is RichTextBoxEx)
                {
                    RichTextBox richTextBox = ((RichTextBoxEx)text).Rich;
                    richTextBox.SelectedText = richTextBox.SelectedText.Insert(0, value);
                    
                    
                }
                
                else
                {
                    RichTextBox richTextBox= (RichTextBox)text;
                    richTextBox.SelectedText = richTextBox.SelectedText.Insert(0, value);
                    
                }
            }
            else
            {
               
                    text.Text = value;
               
                
            }

        }
    }
}
