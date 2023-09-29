namespace WebPostManager
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llResultClose = new System.Windows.Forms.LinkLabel();
            this.txtResultHtml = new System.Windows.Forms.TextBox();
            this.lbConfig = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModuleMore = new System.Windows.Forms.Button();
            this.btnModuleAdd = new System.Windows.Forms.Button();
            this.btnModuleEdit = new System.Windows.Forms.Button();
            this.cmbModuleName = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.uhGlobalvar = new GacHelper.UCHelper();
            this.txtGlobalVar = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ucHelper4 = new GacHelper.UCHelper();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pnNoLogin = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nudTimeOut = new System.Windows.Forms.NumericUpDown();
            this.txtAcceptLanguage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnPost = new System.Windows.Forms.Panel();
            this.ucHelper3 = new GacHelper.UCHelper();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnGetRand = new System.Windows.Forms.Button();
            this.txtRandNumer = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnWeb = new System.Windows.Forms.Panel();
            this.ucHelper1 = new GacHelper.UCHelper();
            this.txtCookies = new System.Windows.Forms.TextBox();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartWebBrowser = new System.Windows.Forms.Button();
            this.rbLoginType3 = new System.Windows.Forms.RadioButton();
            this.rbLoginType2 = new System.Windows.Forms.RadioButton();
            this.rbLoginType1 = new System.Windows.Forms.RadioButton();
            this.txtSiteUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.ucHelper2 = new GacHelper.UCHelper();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnGetCategory = new System.Windows.Forms.Button();
            this.btnSetAdd = new System.Windows.Forms.Button();
            this.btnSetEdit = new System.Windows.Forms.Button();
            this.btnSetDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSetName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pnNoLogin.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).BeginInit();
            this.pnPost.SuspendLayout();
            this.pnWeb.SuspendLayout();
            this.gbCategory.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llResultClose);
            this.groupBox1.Controls.Add(this.txtResultHtml);
            this.groupBox1.Controls.Add(this.lbConfig);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 465);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置列表  [双击编辑]";
            // 
            // llResultClose
            // 
            this.llResultClose.AutoSize = true;
            this.llResultClose.Location = new System.Drawing.Point(176, 12);
            this.llResultClose.Name = "llResultClose";
            this.llResultClose.Size = new System.Drawing.Size(11, 12);
            this.llResultClose.TabIndex = 2;
            this.llResultClose.TabStop = true;
            this.llResultClose.Text = "X";
            this.llResultClose.Visible = false;
            this.llResultClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llResultClose_LinkClicked);
            // 
            // txtResultHtml
            // 
            this.txtResultHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultHtml.Location = new System.Drawing.Point(3, 17);
            this.txtResultHtml.Multiline = true;
            this.txtResultHtml.Name = "txtResultHtml";
            this.txtResultHtml.Size = new System.Drawing.Size(185, 445);
            this.txtResultHtml.TabIndex = 1;
            this.txtResultHtml.Visible = false;
            // 
            // lbConfig
            // 
            this.lbConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbConfig.FormattingEnabled = true;
            this.lbConfig.ItemHeight = 12;
            this.lbConfig.Location = new System.Drawing.Point(3, 17);
            this.lbConfig.Name = "lbConfig";
            this.lbConfig.Size = new System.Drawing.Size(185, 445);
            this.lbConfig.TabIndex = 0;
            this.lbConfig.SelectedIndexChanged += new System.EventHandler(this.lbConfig_SelectedIndexChanged);
            this.lbConfig.DoubleClick += new System.EventHandler(this.lbConfig_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnModuleMore);
            this.groupBox2.Controls.Add(this.btnModuleAdd);
            this.groupBox2.Controls.Add(this.btnModuleEdit);
            this.groupBox2.Controls.Add(this.cmbModuleName);
            this.groupBox2.Location = new System.Drawing.Point(212, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(445, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1、选择Web在线发布模块";
            // 
            // btnModuleMore
            // 
            this.btnModuleMore.Location = new System.Drawing.Point(387, 22);
            this.btnModuleMore.Name = "btnModuleMore";
            this.btnModuleMore.Size = new System.Drawing.Size(52, 24);
            this.btnModuleMore.TabIndex = 3;
            this.btnModuleMore.Text = "更多";
            this.btnModuleMore.UseVisualStyleBackColor = true;
            this.btnModuleMore.Click += new System.EventHandler(this.btnModuleMore_Click);
            // 
            // btnModuleAdd
            // 
            this.btnModuleAdd.Location = new System.Drawing.Point(332, 22);
            this.btnModuleAdd.Name = "btnModuleAdd";
            this.btnModuleAdd.Size = new System.Drawing.Size(52, 24);
            this.btnModuleAdd.TabIndex = 2;
            this.btnModuleAdd.Text = "新建";
            this.btnModuleAdd.UseVisualStyleBackColor = true;
            this.btnModuleAdd.Click += new System.EventHandler(this.btnModuleAdd_Click);
            // 
            // btnModuleEdit
            // 
            this.btnModuleEdit.Location = new System.Drawing.Point(277, 22);
            this.btnModuleEdit.Name = "btnModuleEdit";
            this.btnModuleEdit.Size = new System.Drawing.Size(52, 24);
            this.btnModuleEdit.TabIndex = 1;
            this.btnModuleEdit.Text = "编辑";
            this.btnModuleEdit.UseVisualStyleBackColor = true;
            this.btnModuleEdit.Click += new System.EventHandler(this.btnModuleEdit_Click);
            // 
            // cmbModuleName
            // 
            this.cmbModuleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModuleName.FormattingEnabled = true;
            this.cmbModuleName.Location = new System.Drawing.Point(13, 24);
            this.cmbModuleName.Name = "cmbModuleName";
            this.cmbModuleName.Size = new System.Drawing.Size(258, 20);
            this.cmbModuleName.TabIndex = 0;
            this.cmbModuleName.SelectedIndexChanged += new System.EventHandler(this.cmbModuleName_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.uhGlobalvar);
            this.groupBox3.Controls.Add(this.txtGlobalVar);
            this.groupBox3.Location = new System.Drawing.Point(212, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 51);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2、全局变量设置";
            // 
            // uhGlobalvar
            // 
            this.uhGlobalvar.HelperKey = "Globalvar";
            this.uhGlobalvar.Location = new System.Drawing.Point(190, 24);
            this.uhGlobalvar.Name = "uhGlobalvar";
            this.uhGlobalvar.Size = new System.Drawing.Size(16, 16);
            this.uhGlobalvar.TabIndex = 1;
            // 
            // txtGlobalVar
            // 
            this.txtGlobalVar.Location = new System.Drawing.Point(14, 22);
            this.txtGlobalVar.Name = "txtGlobalVar";
            this.txtGlobalVar.Size = new System.Drawing.Size(170, 21);
            this.txtGlobalVar.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ucHelper4);
            this.groupBox4.Controls.Add(this.cmbEncoding);
            this.groupBox4.Location = new System.Drawing.Point(441, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 51);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "3、编码设置";
            // 
            // ucHelper4
            // 
            this.ucHelper4.HelperKey = "Encoding";
            this.ucHelper4.Location = new System.Drawing.Point(190, 22);
            this.ucHelper4.Name = "ucHelper4";
            this.ucHelper4.Size = new System.Drawing.Size(16, 16);
            this.ucHelper4.TabIndex = 1;
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Items.AddRange(new object[] {
            "自动识别",
            "GBK",
            "GB2312",
            "UTF-8",
            "BIG5",
            "Shift_JIS",
            "iso-8859-1",
            "euc-kr",
            "euc-jp",
            "EUC-TW",
            "GB18030",
            "UTF-16",
            "UTF-32",
            "ASMO-708",
            "DOS-720",
            "windows-1256",
            "windows-1257",
            "hz-gb-2312",
            "euc-jp",
            "windows-874",
            "cp866",
            "koi8-r",
            "koi8-ru",
            "windows-1251",
            "DOS-862",
            "windows-1255",
            "windows-1253",
            "windows-1252",
            "windows-1258",
            "ibm852",
            "windows-1250",
            "windows-31j",
            "iso-8859-8-i",
            "GB2312-80",
            "utf-7",
            "iso-2202",
            "iso-022-kr",
            "iso-8859-2",
            "iso-8859-5",
            "iso-8859-7",
            "iso-8859-8",
            "TIS620",
            "ISO-2022-KR",
            "ISO-2022-CN",
            "ISO-2022-JP",
            "IBM855",
            "x-mac-cyrillic",
            "KSC5601"});
            this.cmbEncoding.Location = new System.Drawing.Point(6, 20);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(175, 20);
            this.cmbEncoding.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pnNoLogin);
            this.groupBox5.Controls.Add(this.pnPost);
            this.groupBox5.Controls.Add(this.pnWeb);
            this.groupBox5.Controls.Add(this.rbLoginType3);
            this.groupBox5.Controls.Add(this.rbLoginType2);
            this.groupBox5.Controls.Add(this.rbLoginType1);
            this.groupBox5.Controls.Add(this.txtSiteUrl);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(212, 145);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(445, 213);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "4、登录操作";
            // 
            // pnNoLogin
            // 
            this.pnNoLogin.Controls.Add(this.groupBox8);
            this.pnNoLogin.Location = new System.Drawing.Point(13, 66);
            this.pnNoLogin.Name = "pnNoLogin";
            this.pnNoLogin.Size = new System.Drawing.Size(419, 138);
            this.pnNoLogin.TabIndex = 7;
            this.pnNoLogin.Visible = false;
            this.pnNoLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.pnNoLogin_Paint);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Controls.Add(this.nudTimeOut);
            this.groupBox8.Controls.Add(this.txtAcceptLanguage);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Location = new System.Drawing.Point(21, 11);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(380, 106);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "以下设置与登录无关,仅影响Http请求";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(266, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "秒";
            // 
            // nudTimeOut
            // 
            this.nudTimeOut.Location = new System.Drawing.Point(116, 68);
            this.nudTimeOut.Name = "nudTimeOut";
            this.nudTimeOut.Size = new System.Drawing.Size(147, 21);
            this.nudTimeOut.TabIndex = 3;
            this.nudTimeOut.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txtAcceptLanguage
            // 
            this.txtAcceptLanguage.Location = new System.Drawing.Point(116, 33);
            this.txtAcceptLanguage.Name = "txtAcceptLanguage";
            this.txtAcceptLanguage.Size = new System.Drawing.Size(147, 21);
            this.txtAcceptLanguage.TabIndex = 2;
            this.txtAcceptLanguage.Text = "zh-cn,cn,en,en-us";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "http请求超时";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "Accept-Language";
            // 
            // pnPost
            // 
            this.pnPost.Controls.Add(this.ucHelper3);
            this.pnPost.Controls.Add(this.btnLogin);
            this.pnPost.Controls.Add(this.btnGetRand);
            this.pnPost.Controls.Add(this.txtRandNumer);
            this.pnPost.Controls.Add(this.txtPassword);
            this.pnPost.Controls.Add(this.txtUserName);
            this.pnPost.Controls.Add(this.label9);
            this.pnPost.Controls.Add(this.label8);
            this.pnPost.Controls.Add(this.label7);
            this.pnPost.Location = new System.Drawing.Point(13, 66);
            this.pnPost.Name = "pnPost";
            this.pnPost.Size = new System.Drawing.Size(419, 138);
            this.pnPost.TabIndex = 6;
            this.pnPost.Visible = false;
            // 
            // ucHelper3
            // 
            this.ucHelper3.HelperKey = "PostLogin";
            this.ucHelper3.Location = new System.Drawing.Point(381, 16);
            this.ucHelper3.Name = "ucHelper3";
            this.ucHelper3.Size = new System.Drawing.Size(16, 16);
            this.ucHelper3.TabIndex = 8;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(287, 13);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(84, 51);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnGetRand
            // 
            this.btnGetRand.Location = new System.Drawing.Point(287, 68);
            this.btnGetRand.Name = "btnGetRand";
            this.btnGetRand.Size = new System.Drawing.Size(84, 24);
            this.btnGetRand.TabIndex = 6;
            this.btnGetRand.Text = "获取验证码";
            this.btnGetRand.UseVisualStyleBackColor = true;
            // 
            // txtRandNumer
            // 
            this.txtRandNumer.Location = new System.Drawing.Point(108, 71);
            this.txtRandNumer.Name = "txtRandNumer";
            this.txtRandNumer.Size = new System.Drawing.Size(173, 21);
            this.txtRandNumer.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(108, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(173, 21);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(108, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(173, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(63, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "验证码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "密码：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "用户名：";
            // 
            // pnWeb
            // 
            this.pnWeb.Controls.Add(this.ucHelper1);
            this.pnWeb.Controls.Add(this.txtCookies);
            this.pnWeb.Controls.Add(this.txtUserAgent);
            this.pnWeb.Controls.Add(this.label4);
            this.pnWeb.Controls.Add(this.label3);
            this.pnWeb.Controls.Add(this.btnStartWebBrowser);
            this.pnWeb.Location = new System.Drawing.Point(13, 66);
            this.pnWeb.Name = "pnWeb";
            this.pnWeb.Size = new System.Drawing.Size(418, 138);
            this.pnWeb.TabIndex = 5;
            // 
            // ucHelper1
            // 
            this.ucHelper1.HelperKey = "Webbrowser";
            this.ucHelper1.Location = new System.Drawing.Point(340, 23);
            this.ucHelper1.Name = "ucHelper1";
            this.ucHelper1.Size = new System.Drawing.Size(16, 16);
            this.ucHelper1.TabIndex = 11;
            // 
            // txtCookies
            // 
            this.txtCookies.Location = new System.Drawing.Point(83, 81);
            this.txtCookies.Multiline = true;
            this.txtCookies.Name = "txtCookies";
            this.txtCookies.Size = new System.Drawing.Size(317, 46);
            this.txtCookies.TabIndex = 10;
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.Location = new System.Drawing.Point(83, 48);
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.Size = new System.Drawing.Size(317, 21);
            this.txtUserAgent.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 36);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cookie值：\r\n\r\n可手动填写";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "UserAgent";
            // 
            // btnStartWebBrowser
            // 
            this.btnStartWebBrowser.Location = new System.Drawing.Point(83, 17);
            this.btnStartWebBrowser.Name = "btnStartWebBrowser";
            this.btnStartWebBrowser.Size = new System.Drawing.Size(251, 25);
            this.btnStartWebBrowser.TabIndex = 5;
            this.btnStartWebBrowser.Text = "在内置浏览器中登录(点击启动微型浏览器)";
            this.btnStartWebBrowser.UseVisualStyleBackColor = true;
            this.btnStartWebBrowser.Click += new System.EventHandler(this.btnStartWebBrowser_Click);
            // 
            // rbLoginType3
            // 
            this.rbLoginType3.AutoSize = true;
            this.rbLoginType3.Location = new System.Drawing.Point(295, 47);
            this.rbLoginType3.Name = "rbLoginType3";
            this.rbLoginType3.Size = new System.Drawing.Size(137, 16);
            this.rbLoginType3.TabIndex = 4;
            this.rbLoginType3.Text = "不需要登录&&Http请求";
            this.rbLoginType3.UseVisualStyleBackColor = true;
            this.rbLoginType3.CheckedChanged += new System.EventHandler(this.rbLoginType_CheckedChanged);
            // 
            // rbLoginType2
            // 
            this.rbLoginType2.AutoSize = true;
            this.rbLoginType2.Location = new System.Drawing.Point(154, 47);
            this.rbLoginType2.Name = "rbLoginType2";
            this.rbLoginType2.Size = new System.Drawing.Size(131, 16);
            this.rbLoginType2.TabIndex = 3;
            this.rbLoginType2.Text = "使用数据包登录方式";
            this.rbLoginType2.UseVisualStyleBackColor = true;
            this.rbLoginType2.CheckedChanged += new System.EventHandler(this.rbLoginType_CheckedChanged);
            // 
            // rbLoginType1
            // 
            this.rbLoginType1.AutoSize = true;
            this.rbLoginType1.Checked = true;
            this.rbLoginType1.Location = new System.Drawing.Point(13, 47);
            this.rbLoginType1.Name = "rbLoginType1";
            this.rbLoginType1.Size = new System.Drawing.Size(131, 16);
            this.rbLoginType1.TabIndex = 2;
            this.rbLoginType1.TabStop = true;
            this.rbLoginType1.Text = "使用内置浏览器登录";
            this.rbLoginType1.UseVisualStyleBackColor = true;
            this.rbLoginType1.CheckedChanged += new System.EventHandler(this.rbLoginType_CheckedChanged);
            // 
            // txtSiteUrl
            // 
            this.txtSiteUrl.Location = new System.Drawing.Point(90, 20);
            this.txtSiteUrl.Name = "txtSiteUrl";
            this.txtSiteUrl.Size = new System.Drawing.Size(342, 21);
            this.txtSiteUrl.TabIndex = 1;
            this.txtSiteUrl.Text = "http://";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "网站根地址：";
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.ucHelper2);
            this.gbCategory.Controls.Add(this.groupBox7);
            this.gbCategory.Controls.Add(this.cmbCategory);
            this.gbCategory.Controls.Add(this.btnGetCategory);
            this.gbCategory.Location = new System.Drawing.Point(212, 363);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(445, 120);
            this.gbCategory.TabIndex = 5;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "5、获取分类/栏目列表";
            // 
            // ucHelper2
            // 
            this.ucHelper2.HelperKey = "GetFidList";
            this.ucHelper2.Location = new System.Drawing.Point(407, 34);
            this.ucHelper2.Name = "ucHelper2";
            this.ucHelper2.Size = new System.Drawing.Size(16, 16);
            this.ucHelper2.TabIndex = 3;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtCategoryName);
            this.groupBox7.Controls.Add(this.txtCategoryId);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Location = new System.Drawing.Point(17, 62);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(415, 52);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "分类信息，可以手动填写";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(274, 23);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(133, 21);
            this.txtCategoryName.TabIndex = 3;
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.Location = new System.Drawing.Point(68, 23);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(133, 21);
            this.txtCategoryId.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "分类名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "分类ID号：";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(98, 33);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(299, 20);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // btnGetCategory
            // 
            this.btnGetCategory.Location = new System.Drawing.Point(17, 31);
            this.btnGetCategory.Name = "btnGetCategory";
            this.btnGetCategory.Size = new System.Drawing.Size(75, 23);
            this.btnGetCategory.TabIndex = 0;
            this.btnGetCategory.Text = "获取列表";
            this.btnGetCategory.UseVisualStyleBackColor = true;
            this.btnGetCategory.Click += new System.EventHandler(this.btnGetCategory_Click);
            // 
            // btnSetAdd
            // 
            this.btnSetAdd.Location = new System.Drawing.Point(12, 495);
            this.btnSetAdd.Name = "btnSetAdd";
            this.btnSetAdd.Size = new System.Drawing.Size(61, 23);
            this.btnSetAdd.TabIndex = 6;
            this.btnSetAdd.Text = "新建";
            this.btnSetAdd.UseVisualStyleBackColor = true;
            this.btnSetAdd.Click += new System.EventHandler(this.btnSetAdd_Click);
            // 
            // btnSetEdit
            // 
            this.btnSetEdit.Enabled = false;
            this.btnSetEdit.Location = new System.Drawing.Point(77, 495);
            this.btnSetEdit.Name = "btnSetEdit";
            this.btnSetEdit.Size = new System.Drawing.Size(61, 23);
            this.btnSetEdit.TabIndex = 7;
            this.btnSetEdit.Text = "编辑";
            this.btnSetEdit.UseVisualStyleBackColor = true;
            this.btnSetEdit.Click += new System.EventHandler(this.btnSetEdit_Click);
            // 
            // btnSetDelete
            // 
            this.btnSetDelete.Enabled = false;
            this.btnSetDelete.Location = new System.Drawing.Point(142, 495);
            this.btnSetDelete.Name = "btnSetDelete";
            this.btnSetDelete.Size = new System.Drawing.Size(61, 23);
            this.btnSetDelete.TabIndex = 8;
            this.btnSetDelete.Text = "删除";
            this.btnSetDelete.UseVisualStyleBackColor = true;
            this.btnSetDelete.Click += new System.EventHandler(this.btnSetDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(411, 489);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 35);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存配置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(574, 489);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(83, 35);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "测试配置";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "配置名：";
            // 
            // txtSetName
            // 
            this.txtSetName.Location = new System.Drawing.Point(257, 497);
            this.txtSetName.Name = "txtSetName";
            this.txtSetName.Size = new System.Drawing.Size(148, 21);
            this.txtSetName.TabIndex = 12;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新列表ToolStripMenuItem,
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // 刷新列表ToolStripMenuItem
            // 
            this.刷新列表ToolStripMenuItem.Name = "刷新列表ToolStripMenuItem";
            this.刷新列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.刷新列表ToolStripMenuItem.Text = "刷新列表";
            this.刷新列表ToolStripMenuItem.Click += new System.EventHandler(this.刷新列表ToolStripMenuItem_Click);
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 537);
            this.Controls.Add(this.txtSetName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSetDelete);
            this.Controls.Add(this.btnSetEdit);
            this.Controls.Add(this.btnSetAdd);
            this.Controls.Add(this.gbCategory);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "WEB发布配置管理";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.pnNoLogin.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).EndInit();
            this.pnPost.ResumeLayout(false);
            this.pnPost.PerformLayout();
            this.pnWeb.ResumeLayout(false);
            this.pnWeb.PerformLayout();
            this.gbCategory.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbConfig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.Button btnSetAdd;
        private System.Windows.Forms.Button btnSetEdit;
        private System.Windows.Forms.Button btnSetDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSetName;
        private System.Windows.Forms.Button btnModuleMore;
        private System.Windows.Forms.Button btnModuleAdd;
        private System.Windows.Forms.Button btnModuleEdit;
        private System.Windows.Forms.ComboBox cmbModuleName;
        private System.Windows.Forms.TextBox txtGlobalVar;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.Button btnStartWebBrowser;
        private System.Windows.Forms.RadioButton rbLoginType3;
        private System.Windows.Forms.RadioButton rbLoginType2;
        private System.Windows.Forms.RadioButton rbLoginType1;
        private System.Windows.Forms.TextBox txtSiteUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnWeb;
        private System.Windows.Forms.TextBox txtCookies;
        private System.Windows.Forms.TextBox txtUserAgent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtCategoryId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnGetCategory;
        private System.Windows.Forms.Panel pnPost;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGetRand;
        private System.Windows.Forms.TextBox txtRandNumer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnNoLogin;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudTimeOut;
        private System.Windows.Forms.TextBox txtAcceptLanguage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private GacHelper.UCHelper uhGlobalvar;
        private GacHelper.UCHelper ucHelper2;
        private GacHelper.UCHelper ucHelper1;
        private GacHelper.UCHelper ucHelper3;
        private GacHelper.UCHelper ucHelper4;
        private System.Windows.Forms.LinkLabel llResultClose;
        private System.Windows.Forms.TextBox txtResultHtml;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}

