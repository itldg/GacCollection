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
     [Description("点选内容增加到编辑框")]
    public partial class UCLableText : LinkLabel
    {

        RichTextBoxEx text = null;
        TextBox textBox = null;
        VauleSelect _VauleType = VauleSelect.Custom;
        bool _Append = true;
        public UCLableText()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        [Description("设置点击菜单后操作的控件，只支持RichTextBox"), Category("GAC_Collection")]
        public RichTextBoxEx OperationControl
        {

            set {  text = value;  }
            get { return text; }
        }

        [Browsable(true)]
        [Description("[弃用,不能加粗绿色显示]设置点击菜单后操作的控件，只支持TextBox"), Category("GAC_Collection")]
        public TextBox OperationTextBox
        {

            set { textBox = value; }
            get { return textBox; }
        }
        [Browsable(true)]
        [Description("是否追以追加的形式改变文本"), Category("GAC_Collection"),DefaultValue(true)]
        public bool Append
        {

            get { return _Append;}
            set { _Append =value; }
        }
        
        [Browsable(true)]
        [Description("显示文本"), Category("GAC_Collection")]
        public VauleSelect ValueType
        {

            set
            {
                Text= GetValue(value, Text);
                _VauleType = value;

            }
            get { return _VauleType; }
        }
        public string GetValue(VauleSelect value,string text)
        {
            switch (value)
            {


                case VauleSelect.Asterisk:
                   return "(*)";
                case VauleSelect.Split:
                    return "|";
                case VauleSelect.Lable:
                    return "[标签:XXX]";
                case VauleSelect.Parameter:
                    return "[参数]";
                case VauleSelect.Pagination:
                    return "[分页]";
                case VauleSelect.PostRandValue:
                    return "[POST随机值X]";
                case VauleSelect.Parameter1:
                    return "[参数1]";
                case VauleSelect.ParameterN:
                    return "[参数N]";
                case VauleSelect.GlobalVar:
                    return "[全局变量]";
                case VauleSelect.WebRandValueX:
                    return "[网页随机值X]";
                case VauleSelect.RegContent:
                    return "(?<content>?)";
                case VauleSelect.Custom:
                default:
                    return text;
            }
        }
        
        public enum VauleSelect
        {
            Custom,
            Asterisk,
            Split,
            Lable,
            Parameter,
            Parameter1,
            ParameterN,
            Pagination,
            PostRandValue,
            RegContent,
            GlobalVar,
            WebRandValueX,


        }
        private string GetParameterN(string CurrentText,string ParameterName= "参数")
        {
            int index = 1;
            while (true)
            {

                // System.Text.RegularExpressions.Regex reg=new System.Text.RegularExpressions.Regex("\\[参数\\]")
                if (!CurrentText.Contains("["+ ParameterName + index+"]"))
                {
                    return "["+ ParameterName + index + "]";
                }
                index++;
            }

        }

        private void UCLableText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (text == null&&textBox==null)
            {
                return;
            }
            string Replacevalue = "";
            if (text != null)
            {
                Replacevalue = text.TextValue;
            }
            else
            {
                Replacevalue = textBox.Text;
            }
            if (ValueType == VauleSelect.ParameterN)
            {
                Replacevalue = GetParameterN(Replacevalue);
            }
            else if (ValueType == VauleSelect.PostRandValue)
            {
                Replacevalue = GetParameterN(Replacevalue, "POST随机值");
            }
            else if (ValueType == VauleSelect.RegContent)
            {
                Replacevalue = "(?<content>[\\s\\S]*?)";
            }
            else if (ValueType == VauleSelect.WebRandValueX)
            {
                Replacevalue = GetParameterN(Replacevalue, "网页随机值");
            }
            else if (ValueType == VauleSelect.GlobalVar)
            {
                Replacevalue = "[全局变量]";
            }
            else if (ValueType == VauleSelect.Custom)
            {
                Replacevalue = Text;
            }
            else
            {
                Replacevalue = GetValue(ValueType, Replacevalue);
            }
            if (text != null)
            {
                RichTextBox richTextBox = ((RichTextBoxEx)text).Rich;
                if (Append)
                {

                    if (richTextBox.SelectedText.Length > 0)
                    {
                        richTextBox.SelectedText = Replacevalue;
                    }
                    else
                    {
                        richTextBox.SelectedText = richTextBox.SelectedText.Insert(0, Replacevalue);
                    }

                }
                else
                {

                    richTextBox.Text = Replacevalue;
                }
            }
            else
            {
                if (Append)
                {
                    int start = textBox.SelectionStart;
                    textBox.Text = this.textBox.Text.Insert(start, Replacevalue);
                    textBox.Focus();
                    textBox.SelectionStart = start;
                    textBox.SelectionLength = Replacevalue.Length;
                }
                else
                {
                    textBox.Text = Replacevalue;
                }
            }
            
        }
    }
}
