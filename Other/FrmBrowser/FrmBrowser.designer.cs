namespace GacBrowser
{
    partial class FrmBrowser
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowser));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCookie = new System.Windows.Forms.TabPage();
            this.txtCookieResult = new System.Windows.Forms.TextBox();
            this.tpPost = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tpXpath = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbTestXpath = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbMuit = new System.Windows.Forms.RadioButton();
            this.rbOne = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbHref = new System.Windows.Forms.RadioButton();
            this.rbOuterHtml = new System.Windows.Forms.RadioButton();
            this.rbInnerText = new System.Windows.Forms.RadioButton();
            this.rbInnerHtml = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTestXpath = new System.Windows.Forms.Button();
            this.txtXpath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBack = new System.Windows.Forms.ToolStripButton();
            this.toolNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolHome = new System.Windows.Forms.ToolStripButton();
            this.toolSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtUrl = new System.Windows.Forms.ToolStripComboBox();
            this.toolOkExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBack = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNext = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSource = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpCookie.SuspendLayout();
            this.tpPost.SuspendLayout();
            this.tpXpath.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCookie);
            this.tabControl1.Controls.Add(this.tpPost);
            this.tabControl1.Controls.Add(this.tpXpath);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tpCookie
            // 
            this.tpCookie.Controls.Add(this.txtCookieResult);
            resources.ApplyResources(this.tpCookie, "tpCookie");
            this.tpCookie.Name = "tpCookie";
            this.tpCookie.UseVisualStyleBackColor = true;
            // 
            // txtCookieResult
            // 
            this.txtCookieResult.BackColor = System.Drawing.Color.White;
            this.txtCookieResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtCookieResult, "txtCookieResult");
            this.txtCookieResult.Name = "txtCookieResult";
            this.txtCookieResult.ReadOnly = true;
            // 
            // tpPost
            // 
            this.tpPost.Controls.Add(this.textBox2);
            resources.ApplyResources(this.tpPost, "tpPost");
            this.tpPost.Name = "tpPost";
            this.tpPost.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            // 
            // tpXpath
            // 
            this.tpXpath.Controls.Add(this.groupBox3);
            this.tpXpath.Controls.Add(this.groupBox2);
            this.tpXpath.Controls.Add(this.groupBox1);
            this.tpXpath.Controls.Add(this.panel1);
            resources.ApplyResources(this.tpXpath, "tpXpath");
            this.tpXpath.Name = "tpXpath";
            this.tpXpath.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.rtbTestXpath);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // rtbTestXpath
            // 
            this.rtbTestXpath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.rtbTestXpath, "rtbTestXpath");
            this.rtbTestXpath.Name = "rtbTestXpath";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rbMuit);
            this.groupBox2.Controls.Add(this.rbOne);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // rbMuit
            // 
            resources.ApplyResources(this.rbMuit, "rbMuit");
            this.rbMuit.Checked = true;
            this.rbMuit.Name = "rbMuit";
            this.rbMuit.TabStop = true;
            this.rbMuit.UseVisualStyleBackColor = true;
            // 
            // rbOne
            // 
            resources.ApplyResources(this.rbOne, "rbOne");
            this.rbOne.Name = "rbOne";
            this.rbOne.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbHref);
            this.groupBox1.Controls.Add(this.rbOuterHtml);
            this.groupBox1.Controls.Add(this.rbInnerText);
            this.groupBox1.Controls.Add(this.rbInnerHtml);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rbHref
            // 
            resources.ApplyResources(this.rbHref, "rbHref");
            this.rbHref.Checked = true;
            this.rbHref.Name = "rbHref";
            this.rbHref.TabStop = true;
            this.rbHref.UseVisualStyleBackColor = true;
            // 
            // rbOuterHtml
            // 
            resources.ApplyResources(this.rbOuterHtml, "rbOuterHtml");
            this.rbOuterHtml.Name = "rbOuterHtml";
            this.rbOuterHtml.UseVisualStyleBackColor = true;
            // 
            // rbInnerText
            // 
            resources.ApplyResources(this.rbInnerText, "rbInnerText");
            this.rbInnerText.Name = "rbInnerText";
            this.rbInnerText.UseVisualStyleBackColor = true;
            // 
            // rbInnerHtml
            // 
            resources.ApplyResources(this.rbInnerHtml, "rbInnerHtml");
            this.rbInnerHtml.Name = "rbInnerHtml";
            this.rbInnerHtml.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtXpath);
            this.panel1.Controls.Add(this.label2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTestXpath);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnTestXpath
            // 
            resources.ApplyResources(this.btnTestXpath, "btnTestXpath");
            this.btnTestXpath.Name = "btnTestXpath";
            this.btnTestXpath.UseVisualStyleBackColor = true;
            this.btnTestXpath.Click += new System.EventHandler(this.btnTestXpath_Click);
            // 
            // txtXpath
            // 
            resources.ApplyResources(this.txtXpath, "txtXpath");
            this.txtXpath.Name = "txtXpath";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBack,
            this.toolNext,
            this.toolStripSeparator1,
            this.toolHome,
            this.toolSource,
            this.toolStripSeparator2,
            this.txtUrl,
            this.toolOkExit,
            this.toolStripButton1,
            this.toolStripButton2});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Stretch = true;
            // 
            // toolBack
            // 
            resources.ApplyResources(this.toolBack, "toolBack");
            this.toolBack.Name = "toolBack";
            this.toolBack.Click += new System.EventHandler(this.toolBack_Click);
            // 
            // toolNext
            // 
            resources.ApplyResources(this.toolNext, "toolNext");
            this.toolNext.Name = "toolNext";
            this.toolNext.Click += new System.EventHandler(this.toolNext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolHome
            // 
            resources.ApplyResources(this.toolHome, "toolHome");
            this.toolHome.Name = "toolHome";
            this.toolHome.Click += new System.EventHandler(this.toolHome_Click);
            // 
            // toolSource
            // 
            resources.ApplyResources(this.toolSource, "toolSource");
            this.toolSource.Name = "toolSource";
            this.toolSource.Click += new System.EventHandler(this.toolSource_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // txtUrl
            // 
            this.txtUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            resources.ApplyResources(this.txtUrl, "txtUrl");
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrl_KeyDown_1);
            // 
            // toolOkExit
            // 
            this.toolOkExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolOkExit, "toolOkExit");
            this.toolOkExit.Name = "toolOkExit";
            this.toolOkExit.Click += new System.EventHandler(this.toolOkExit_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Name = "toolStripButton1";
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBack,
            this.menuNext,
            this.toolStripSeparator3,
            this.menuSource,
            this.tsmiPrint,
            this.tsmiPrintPreview,
            this.toolStripSeparator4,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            resources.ApplyResources(this.menuFile, "menuFile");
            // 
            // menuBack
            // 
            resources.ApplyResources(this.menuBack, "menuBack");
            this.menuBack.Name = "menuBack";
            this.menuBack.Click += new System.EventHandler(this.menuBack_Click);
            // 
            // menuNext
            // 
            resources.ApplyResources(this.menuNext, "menuNext");
            this.menuNext.Name = "menuNext";
            this.menuNext.Click += new System.EventHandler(this.menuNext_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // menuSource
            // 
            this.menuSource.Name = "menuSource";
            resources.ApplyResources(this.menuSource, "menuSource");
            this.menuSource.Click += new System.EventHandler(this.menuSource_Click);
            // 
            // tsmiPrint
            // 
            resources.ApplyResources(this.tsmiPrint, "tsmiPrint");
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiPrintPreview
            // 
            resources.ApplyResources(this.tsmiPrintPreview, "tsmiPrintPreview");
            this.tsmiPrintPreview.Name = "tsmiPrintPreview";
            this.tsmiPrintPreview.Click += new System.EventHandler(this.tsmiPrintPreview_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            resources.ApplyResources(this.menuExit, "menuExit");
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            resources.ApplyResources(this.menuHelp, "menuHelp");
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            resources.ApplyResources(this.menuAbout, "menuAbout");
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // FrmBrowser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FrmBrowser";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmWeblink_Load);
            this.SizeChanged += new System.EventHandler(this.FrmBrowser_SizeChanged);
            this.Resize += new System.EventHandler(this.frmWeblink_Resize);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpCookie.ResumeLayout(false);
            this.tpCookie.PerformLayout();
            this.tpPost.ResumeLayout(false);
            this.tpPost.PerformLayout();
            this.tpXpath.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripButton toolBack;
        private System.Windows.Forms.ToolStripButton toolNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolHome;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolOkExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCookie;
        public System.Windows.Forms.TextBox txtCookieResult;
        private System.Windows.Forms.TabPage tpPost;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuBack;
        private System.Windows.Forms.ToolStripMenuItem menuNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintPreview;
        private System.Windows.Forms.TabPage tpXpath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTestXpath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbMuit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtbTestXpath;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ToolStripComboBox txtUrl;
        public System.Windows.Forms.RadioButton rbOuterHtml;
        public System.Windows.Forms.RadioButton rbInnerText;
        public System.Windows.Forms.RadioButton rbInnerHtml;
        public System.Windows.Forms.RadioButton rbHref;
        public System.Windows.Forms.RadioButton rbOne;
        public System.Windows.Forms.TextBox txtXpath;
    }
}