using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace GAC_Collection.Ex
{
    public partial class RichTextBoxEx : UserControl
    {

        public RichTextBoxEx()
        {
            InitializeComponent();

            //Rich.Text = Text;
        }
        public delegate void TextChangedHandle(object sender, EventArgs e);
        //定义事件
        [Browsable(true)]
        public event TextChangedHandle ValueChanged;
        [Browsable(true)]
        [Description("文本内容"), Category("GAC_Collection")]
        public string TextValue
        {
            get
            {
                return this.Rich.Text.Replace("\r\n","\n");
            }
            set
            {

                try
                {
                    this.Rich.Text = value;
                }
                catch (Exception)
                {

                    if (this.IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            this.Rich.Text = value;
                        });
                    }
                }
                if (RealTimeRendering && !string.IsNullOrEmpty(value))
                {
                    RichHighlight();
                }



                //
            }
        }
        [Browsable(true)]
        [Description("是否自动换行"), Category("GAC_Collection")]
        public bool WordWrap
        {
            get { return Rich.WordWrap; }
            set
            {
                Rich.WordWrap = value;
                if (value)
                {
                    Rich.ScrollBars = RichTextBoxScrollBars.Both;
                }
                else
                {
                    Rich.ScrollBars = RichTextBoxScrollBars.None;
                }
            }
        }

        [Browsable(true)]
        [Description("是否高亮标签"), Category("GAC_Collection"), DefaultValue(false)]
        public bool Label
        {
            get; set;
        }

        [Browsable(true)]
        [Description("是否高亮星号"), Category("GAC_Collection"), DefaultValue(false)]
        public bool Asterisk
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮参数"), Category("GAC_Collection"), DefaultValue(false)]
        public bool Parameter
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮参数N"), Category("GAC_Collection"), DefaultValue(false)]
        public bool ParameterN
        {
            get; set;
        }

        [Browsable(true)]
        [Description("是否高亮分割符"), Category("GAC_Collection"), DefaultValue(false)]
        public bool Split
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮全局变量"), Category("GAC_Collection"), DefaultValue(false)]
        public bool GlobalVar
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮网站地址"), Category("GAC_Collection"), DefaultValue(false)]
        public bool SiteUrl
        {
            get; set;
        }
        
        [Browsable(true)]
        [Description("是否高亮网页随机值"), Category("GAC_Collection"), DefaultValue(false)]
        public bool WebRandValueX
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮系统时间戳"), Category("GAC_Collection"), DefaultValue(false)]
        public bool SystemTimeUnix
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮分类ID和分类名称"), Category("GAC_Collection"), DefaultValue(false)]
        public bool Category
        {
            get; set;
        }
        
        [Browsable(true)]
        [Description("是否高亮POST随机值"), Category("GAC_Collection"), DefaultValue(false)]
        public bool PostRandValue
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮用户名"), Category("GAC_Collection"), DefaultValue(false)]
        public bool UserName
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮密码"), Category("GAC_Collection"), DefaultValue(false)]
        public bool PassWord
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮验证码"), Category("GAC_Collection"), DefaultValue(false)]
        public bool RandImg
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮分页"), Category("GAC_Collection"), DefaultValue(false)]
        public bool Pagination
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮日期"), Category("GAC_Collection"), DefaultValue(false)]
        public bool DateFormat
        {
            get; set;
        }
        [Browsable(true)]
        [Description("是否高亮文件名"), Category("GAC_Collection"), DefaultValue(false)]
        public bool FileName
        {
            get; set;
        }

        [Browsable(true)]
        [Description("是否高亮保存目录"), Category("GAC_Collection"), DefaultValue(false)]
        public bool SaveDir
        {
            get; set;
        }

        [Browsable(true)]
        [Description("是否高亮保存文件名"), Category("GAC_Collection"), DefaultValue(false)]
        public bool SaveFile
        {
            get; set;
        }

        [Browsable(true)]
        [Description("是否高亮上箭头(↑)"), Category("GAC_Collection"), DefaultValue(false)]
        public bool UpArrow
        {
            get; set;
        }



        [Browsable(true)]
        [Description("是否高亮正则匹配内容"), Category("GAC_Collection"), DefaultValue(false)]
        public bool RegContent
        {
            get; set;
        }

        [Browsable(true)]
        [Description("是否高亮测试结果中的标签"), Category("GAC_Collection"), DefaultValue(false)]
        public bool TestLable
        {
            get; set;
        }
        List<string> _LableList = new List<string>();
        [Browsable(true)]
        [Description("测试结果中的标签列表"), Category("GAC_Collection"), DefaultValue(default(List<string>))]
        public List<string> LableList
        {
            get { return _LableList; }
            set { _LableList = value; Rich_TextChanged(null, null); }
        }

        [Browsable(true)]
        [Description("是否高亮采集日志"), Category("GAC_Collection"), DefaultValue(false)]
        public bool IsLog
        {
            get; set;
        }

        [Browsable(true)]
        [Description("滚动条类型"), Category("GAC_Collection"), DefaultValue(RichTextBoxScrollBars.None)]
        public RichTextBoxScrollBars ScrollBars
        {
            get { return Rich.ScrollBars; }
            set { Rich.ScrollBars = value; }
        }
        private bool _RealTimeRendering = true;
        [Browsable(true)]
        [Description("实时渲染高亮代码"), Category("GAC_Collection"), DefaultValue(true)]
        public bool RealTimeRendering
        {
            get { return _RealTimeRendering; }
            set { _RealTimeRendering = value; }
        }
        //public DataType CodeDataType
        //{

        //    set { datatype = value;
        //        switch (datatype)
        //        {
        //            case DataType.DateFormat:
        //                InitDateFormat();
        //                break;
        //            case DataType.Asterisk:
        //                keywords.Add("(*)", "1");
        //                break;
        //            case DataType.Parameter_Asterisk:
        //                keywords.Add("(*)", "false");
        //                keywords.Add("[参数]", "false");
        //                break;
        //            case DataType.AsteriskAndSplit:
        //                keywords.Add("(*)",false);
        //                keywords.Add("|", false);
        //                break;
        //            case DataType.Label:
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    get { return datatype; }
        //}
        Hashtable keywords = new Hashtable();

        private void InitDateFormat()
        {

            keywords.Add("g", "1");
            keywords.Add("G", "1");
            keywords.Add("d", "1");
            keywords.Add("M", "1");
            keywords.Add("y", "1");
            keywords.Add("h", "1");
            keywords.Add("H", "1");
            keywords.Add("m", "1");
            keywords.Add("s", "1");
            keywords.Add("f", "1");
            keywords.Add("t", "1");
            keywords.Add("z", "1");
            keywords.Add("F", "1");
            keywords.Add("K", "1");

        }
        private int GetIndex(string Text, string SearchText, int Start)
        {
            return Text.IndexOf(SearchText, Start);
        }
        private void InitKeywords(string Text)
        {
            keywords.Clear();
            if (Label || SaveDir || SaveFile|| FileName)
            {
                InitParameter(Text, 0);
            }
            if (Parameter)
            {
                keywords.Add("[参数]", false);
            }
            if (Asterisk)
            {
                keywords.Add("(*)", false);
            }
            if (Pagination)
            {
                keywords.Add("[分页]", false);
            }
            if (Split)
            {
                keywords.Add("|", false);
            }
            if (UpArrow)
            {
                keywords.Add("↑", false);
            }
            if (ParameterN)
            {
                InitParameter(Text, 1);
            }
            if (GlobalVar)
            {
                keywords.Add("[全局变量]", false);
            }
            if (WebRandValueX)
            {
                InitParameter(Text,3);
            }
            if (SystemTimeUnix)
            {
                keywords.Add("[系统时间戳]", false);
            }
            if (Category)
            {
                keywords.Add("[分类ID]", false);
                keywords.Add("[分类名称]", false);
            }
            if (UserName)
            {
                keywords.Add("[用户名]", false);
            }
            if (PassWord)
            {
                keywords.Add("[密码]", false);
            }
            if (RandImg)
            {
                keywords.Add("[验证码]", false);
            }
            if (SiteUrl)
            {
                keywords.Add("[网站地址]", false);
            }
            if (DateFormat || FileName || SaveDir || SaveFile)
            {
                InitDateFormat();
            }
            if (PostRandValue)
            {
                InitParameter(Text, 2);
            }
            if (RegContent)
            {
                InitRegexContent();
            }
            if (TestLable)
            {
                for (int i = 0; i < LableList.Count; i++)
                {
                    keywords.Add("\n【" + LableList[i] + "】：", false);
                }

            }
            if (FileName)
            {
                //[任务名][随机文件名][任务Id]yyy-M-dd HH-mm-ss
                keywords.Add("[任务名]", false);
                keywords.Add("[随机文件名]", false);
                keywords.Add("[任务Id]", false);
                keywords.Add("[记录Id]", false);
            }
            if (SaveDir || SaveFile)
            {
                keywords.Add("[文件扩展名]", false);
                keywords.Add("[任务名]", false);
                keywords.Add("[自增ID]", false);
            }
            if (SaveFile)
            {
                keywords.Add("[原文件名]", false);
                keywords.Add("[随机文件名]", false);
            }
            if (IsLog)
            {
                keywords.Add("成功采集并更新数据到数据库：", false);
            }


        }
        private void InitRegexContent()
        {
            Regex reg = new Regex("\\(\\?<content>.*?\\)");
            Match match = reg.Match(TextValue);
            if (match.Success)
            {
                keywords.Add(match.Groups[0].Value, false);
            }
            //for (int i = 0; i < mcs.Count; i++)
            //{
            //    string key = mcs[i].Groups[1].Value;
            //    if (!keywords.ContainsKey(key))
            //    {
            //        keywords.Add(key, false);
            //    }
            //}
        }
        /// <summary>
        /// 返回需要替换的代码
        /// </summary>
        /// <param name="Text">需要匹配的文本</param>
        /// <param name="Model">0标签 1参数 2Post随机值 3网页随机值</param>
        private void InitParameter(string Text, int Model = 0)
        {
            string regvalue = "(\\[标签:.*?\\])";
            if (Model == 1)
            {
                regvalue = "(\\[参数\\d+\\])";
            }
            else if (Model == 2)
            {
                regvalue = "(\\[POST随机值\\d+\\])";
            }
            else if (Model == 3)
            {
                regvalue = "(\\[网页随机值\\d+\\])";
            }

            Regex reg = new Regex(regvalue);
            MatchCollection mcs = reg.Matches(Text);
            for (int i = 0; i < mcs.Count; i++)
            {
                string key = mcs[i].Groups[1].Value;
                if (!keywords.ContainsKey(key))
                {
                    keywords.Add(key, false);
                }
            }
        }
        bool change = false;
        /// <summary> 
        /// C#语法高亮着色器 
        /// </summary> 
        /// <param name="start">起始行号</param> 
        public void RichHighlight()
        {
            if (!change)
            {
                change = true;
                int row = this.Rich.SelectionStart;
                if (!WordWrap && this.Rich.Text.Contains("\n"))
                {
                    this.Rich.Text = this.Rich.Text.Replace("\n", "");
                }
                //string txt = this.Rich.Text;
                //this.Rich.Text = txt;
                this.Rich.Select(0, this.Rich.Text.Length);
                this.Rich.SelectionFont = this.Rich.Font;
                this.Rich.SelectionColor = this.Rich.ForeColor;


                InitKeywords(this.Rich.Text);


                foreach (DictionaryEntry item in keywords)
                {
                    int index = 0;
                    while (index != -1)
                    {
                        index = GetIndex(this.Rich.Text, item.Key.ToString(), index);
                        if (index >= 0)
                        {
                            int length = item.Key.ToString().Length;
                            this.Rich.Select(index, length);
                            this.Rich.SelectionColor = Color.DarkGreen;
                            this.Rich.SelectionFont = new Font(this.Rich.Font, FontStyle.Bold);
                            index += length;
                        }
                    }


                }


                //this.Rich.SelectionStart = row;
                this.Rich.Select(this.Rich.Text.Length, 0);
                //this.Rich.SelectionFont = this.Rich.Font;
                //this.Rich.SelectionColor = this.Rich.ForeColor;
                this.Rich.SelectionStart = row;
                change = false;
            }


            ////this.Text = textBox4.Text; 
            //string[] ln = this.richTextBox1.Text.Split(new string[] { "\n" },StringSplitOptions.RemoveEmptyEntries);
            //int pos = 0;
            //int lnum = 0;
            //foreach (string lv in ln)
            //{
            //    if (lnum >= start)
            //    {
            //        string ts = lv;


            //        ArrayList marks = new ArrayList();
            //        string smark = "";
            //        string last = "";
            //        bool inmark = false;
            //        for (int i = 0; i < ts.Length; i++)
            //        {
            //            if (ts.Substring(i, 1) == "\"" && last != "\\")
            //            {
            //                if (inmark)
            //                {
            //                    marks.Add(smark + "," + i);
            //                    smark = "";
            //                    inmark = false;
            //                }
            //                else
            //                {
            //                    smark += i;
            //                    inmark = true;
            //                }
            //            }
            //            last = ts.Substring(i, 1);
            //        }
            //        if (inmark)
            //        {
            //            marks.Add(smark + "," + ts.Length);
            //        }

            //        string[] ta = ts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            //        int x = 0;
            //        foreach (string tv in ta)
            //        {
            //            if (tv.Length < 2)
            //            {
            //                x += tv.Length + 1;
            //                continue;
            //            }
            //            else
            //            {
            //                bool find = false;
            //                foreach (string px in marks)
            //                {
            //                    string[] pa = px.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //                    if (x >= Int32.Parse(pa[0]) && x < Int32.Parse(pa[1]))
            //                    {
            //                        find = true;
            //                        break;
            //                    }
            //                }
            //                if (!find)
            //                {
            //                    if (keywords[tv] != null)
            //                    {
            //                        this.richTextBox1.Select(pos + x, tv.Length);
            //                        this.richTextBox1.SelectionColor = Color.DarkGreen;
            //                    }
            //                }
            //                x += tv.Length + 1;
            //            }
            //        }

            //        foreach (string px in marks)
            //        {
            //            string[] pa = px.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //            this.richTextBox1.Select(pos + Int32.Parse(pa[0]), Int32.Parse(pa[1]) - Int32.Parse(pa[0]) + 1);
            //            //this.SelectionFont = new Font("宋体", 9, (FontStyle.Regular));
            //            this.richTextBox1.SelectionColor = Color.DarkRed;
            //        }
            //    }
            //    pos += lv.Length + 1;
            //    lnum++;
            //}

            //// 设置一下，才能恢复；后续正确！ 
            //this.Select(this.Text.Length, 0);
            ////this.SelectionFont = new Font("宋体", 9, (FontStyle.Regular));
            //this.SelectionColor = Color.Black;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        private void Rich_TextChanged(object sender, EventArgs e)
        {
            if (RealTimeRendering)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        //Text = Rich.Text;
                        LockWindowUpdate(this.Handle);
                        RichHighlight();
                        LockWindowUpdate((System.IntPtr)0);
                        if (ValueChanged != null)
                        {
                            ValueChanged(sender, e);
                        }
                    });
                }
            }
        }
        public void AppendText(string Text,bool addNewLine = true)
        {

            if (addNewLine)
            {
                Text += Environment.NewLine;
            }
            int AllLength = Rich.TextLength;
            Rich.AppendText(Text);

            LockWindowUpdate(this.Handle);
            InitKeywords(Text);
            foreach (DictionaryEntry item in keywords)
            {
                int index = 0;
                while (index != -1)
                {
                    index = GetIndex(Text, item.Key.ToString(), index);
                    if (index >= 0)
                    {
                        int length = item.Key.ToString().Length;
                        Rich.Select(AllLength+index, length);
                        Rich.SelectionColor = Color.DarkGreen;
                        //Rich.SelectionFont = new Font(this.Rich.Font, FontStyle.Bold);
                        index += length;
                    }
                }
            }
            this.Rich.Select(Rich.Text.Length, 0);
            LockWindowUpdate((System.IntPtr)0);

        }
        Regex regError = new Regex("^(发布到\\[.*?\\]失败|保存到本地文件失败|【.*?】标签不符合需求)");
        public void AppendLog(string Text, bool addNewLine = true)
        {

            if (addNewLine)
            {
                Text += Environment.NewLine;
            }
            LockWindowUpdate(this.Handle);
            int AllLength = Rich.TextLength;
            Rich.AppendText(Text);

            int selectIndex = Rich.SelectionStart;
            

            bool ShowColor = false;
            Color color= Color.DarkGreen;
            if (Text.StartsWith("成功"))
            {
                ShowColor = true;
            }
            else if (Text.StartsWith("数据发布失败") || Text.StartsWith("网址录入数据库时出错"))
            {
                ShowColor = true;
                color = Color.OrangeRed;
            }
            else if (regError.IsMatch(Text))//各种失败的正则
            {
                ShowColor = true;
                color = Color.OrangeRed;
            }
           
            if (ShowColor)
            {
                int length = Text.Length;
                Rich.Select(AllLength, length);
                Rich.SelectionColor = color;   
            }
            this.Rich.Select(Rich.Text.Length, 0);
            LockWindowUpdate((System.IntPtr)0);
        }
        public void InsertText(string Value, bool Append=true)
        {
            string Replacevalue = this.TextValue;
            if (ParameterN && Value == "[参数N]")
            {
                Replacevalue = GetParameterN(Replacevalue);
            }
            else if (PostRandValue && Value == "[POST随机值X]")
            {
                Replacevalue = GetParameterN(Replacevalue, "POST随机值");
            }

            else if (WebRandValueX && Value == "[网页随机值X]")
            {
                Replacevalue = GetParameterN(Replacevalue, "网页随机值");
            } else
            {
                Replacevalue = Value;
            }
            if (Append)
            {

                if (Rich.SelectedText.Length > 0)
                {
                    Rich.SelectedText = Replacevalue;
                }
                else
                {
                    Rich.SelectedText = Rich.SelectedText.Insert(0, Replacevalue);
                }

            }
            else
            {

                Rich.Text = Replacevalue;
            }
            
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Rich.SelectedText))
            {

                Rich.Focus();
                SendKeys.Send("^x");

            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Rich.SelectedText))
            {

                Rich.Focus();
                SendKeys.Send("^c");//复制
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rich.Focus();
            SendKeys.Send("^v");
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Rich.SelectedText))
            {
                Rich.Focus();
                SendKeys.Send("^{DEL}");
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Rich.Focus();
            SendKeys.Send("^a");
        }

        private void Rich_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        #region GetInsert
        private string GetParameterN(string CurrentText, string ParameterName = "参数")
        {
            int index = 1;
            while (true)
            {

                // System.Text.RegularExpressions.Regex reg=new System.Text.RegularExpressions.Regex("\\[参数\\]")
                if (!CurrentText.Contains("[" + ParameterName + index + "]"))
                {
                    return "[" + ParameterName + index + "]";
                }
                index++;
            }

        }
        #endregion
    }
}
