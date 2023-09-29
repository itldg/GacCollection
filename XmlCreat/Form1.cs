
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using GacXml;

namespace XmlCreat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml文件|*.xml;*.txt";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(ofd.FileName);

                XmlElement root = doc.DocumentElement;



                treeView1.Nodes.Clear();
                XmlHelper xmlhelper = new XmlHelper();
                //ShowXml(dic, treeView1.Nodes);
                xmlhelper. ShowXml(root, treeView1.Nodes);

                //diclist.Clear();
                
                xmlhelper. GetXml(root);
                string result = xmlhelper.ShowClass();
                Myediter.Text = result;
            }
        }

        public Scintilla Myediter;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Myediter = new Scintilla();
            this.Myediter.Margins.Margin1.Width = 1;
            this.Myediter.Margins.Margin0.Type = MarginType.Number;
            this.Myediter.Margins.Margin0.Width = 0x23;
            this.Myediter.ConfigurationManager.Language = "cs";
            if ("cs".Equals(Myediter.ConfigurationManager.Language, StringComparison.OrdinalIgnoreCase))
                this.Myediter.Indentation.SmartIndentType = SmartIndent.CPP;
            else
                this.Myediter.Indentation.SmartIndentType = SmartIndent.None;
            this.Myediter.Dock = DockStyle.Fill;
            this.Myediter.Scrolling.ScrollBars = ScrollBars.Both;
            this.Myediter.ConfigurationManager.IsBuiltInEnabled = true;

            splitContainer1.Panel2.Controls.Add(this.Myediter);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            XmlHelper xh = new XmlHelper();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml文件|*.xml;*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string xmlcontent = System.IO.File.ReadAllText(ofd.FileName);
                GacJob gj =  xh.XmlToEntity<GacJob>(xmlcontent);
            }
        }
    }
}
