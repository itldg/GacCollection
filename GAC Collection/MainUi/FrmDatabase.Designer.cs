namespace GAC_Collection.MainUi
{
    partial class FrmDatabase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatabase));
            this.label1 = new System.Windows.Forms.Label();
            this.lblDataType = new System.Windows.Forms.Label();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnResult = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pnSqlServer = new System.Windows.Forms.Panel();
            this.cmbSqlServerDatabase = new System.Windows.Forms.ComboBox();
            this.btnSqlServerCreat = new System.Windows.Forms.Button();
            this.btnSqlServerReload = new System.Windows.Forms.Button();
            this.btnSqlServerTest = new System.Windows.Forms.Button();
            this.chkSqlServerInput = new System.Windows.Forms.CheckBox();
            this.rbSqlServerConnetionType2 = new System.Windows.Forms.RadioButton();
            this.rbSqlServerConnetionType1 = new System.Windows.Forms.RadioButton();
            this.txtSqlServerDatabase = new System.Windows.Forms.TextBox();
            this.txtSqlServerPassword = new System.Windows.Forms.TextBox();
            this.txtSqlServerUser = new System.Windows.Forms.TextBox();
            this.txtSqlServerHost = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnMysql = new System.Windows.Forms.Panel();
            this.cmbMysqlDataName = new System.Windows.Forms.ComboBox();
            this.btnMysqlTest = new System.Windows.Forms.Button();
            this.btnMysqlReload = new System.Windows.Forms.Button();
            this.txtMysqlDataName = new System.Windows.Forms.TextBox();
            this.chkMysqlInputDataName = new System.Windows.Forms.CheckBox();
            this.btnMysqlCreat = new System.Windows.Forms.Button();
            this.cmbMysqlDataEncoding = new System.Windows.Forms.ComboBox();
            this.txtMysqlDataPwd = new System.Windows.Forms.TextBox();
            this.txtMysqlDataUser = new System.Windows.Forms.TextBox();
            this.txtMysqlDataPort = new System.Windows.Forms.TextBox();
            this.txtMysqlDataIp = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnTransformation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnResult.SuspendLayout();
            this.pnSqlServer.SuspendLayout();
            this.pnMysql.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择数据库：";
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(226, 14);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(113, 12);
            this.lblDataType.TabIndex = 1;
            this.lblDataType.Text = "当前数据库为Access";
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Items.AddRange(new object[] {
            "Access",
            "Sqlite",
            "MySql",
            "SqlServer"});
            this.cmbDatabase.Location = new System.Drawing.Point(83, 11);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(121, 20);
            this.cmbDatabase.TabIndex = 2;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnResult);
            this.groupBox1.Controls.Add(this.pnSqlServer);
            this.groupBox1.Controls.Add(this.pnMysql);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Location = new System.Drawing.Point(4, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 230);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // pnResult
            // 
            this.pnResult.Controls.Add(this.txtLog);
            this.pnResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnResult.Location = new System.Drawing.Point(3, 17);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(337, 210);
            this.pnResult.TabIndex = 20;
            this.pnResult.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(337, 210);
            this.txtLog.TabIndex = 0;
            // 
            // pnSqlServer
            // 
            this.pnSqlServer.Controls.Add(this.cmbSqlServerDatabase);
            this.pnSqlServer.Controls.Add(this.btnSqlServerCreat);
            this.pnSqlServer.Controls.Add(this.btnSqlServerReload);
            this.pnSqlServer.Controls.Add(this.btnSqlServerTest);
            this.pnSqlServer.Controls.Add(this.chkSqlServerInput);
            this.pnSqlServer.Controls.Add(this.rbSqlServerConnetionType2);
            this.pnSqlServer.Controls.Add(this.rbSqlServerConnetionType1);
            this.pnSqlServer.Controls.Add(this.txtSqlServerDatabase);
            this.pnSqlServer.Controls.Add(this.txtSqlServerPassword);
            this.pnSqlServer.Controls.Add(this.txtSqlServerUser);
            this.pnSqlServer.Controls.Add(this.txtSqlServerHost);
            this.pnSqlServer.Controls.Add(this.label16);
            this.pnSqlServer.Controls.Add(this.label15);
            this.pnSqlServer.Controls.Add(this.label14);
            this.pnSqlServer.Controls.Add(this.label13);
            this.pnSqlServer.Controls.Add(this.label12);
            this.pnSqlServer.Controls.Add(this.label11);
            this.pnSqlServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSqlServer.Location = new System.Drawing.Point(3, 17);
            this.pnSqlServer.Name = "pnSqlServer";
            this.pnSqlServer.Size = new System.Drawing.Size(337, 210);
            this.pnSqlServer.TabIndex = 4;
            this.pnSqlServer.Visible = false;
            // 
            // cmbSqlServerDatabase
            // 
            this.cmbSqlServerDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSqlServerDatabase.FormattingEnabled = true;
            this.cmbSqlServerDatabase.Location = new System.Drawing.Point(85, 141);
            this.cmbSqlServerDatabase.Name = "cmbSqlServerDatabase";
            this.cmbSqlServerDatabase.Size = new System.Drawing.Size(137, 20);
            this.cmbSqlServerDatabase.TabIndex = 19;
            this.cmbSqlServerDatabase.SelectedIndexChanged += new System.EventHandler(this.SqlDataName_SelectedIndexChanged);
            // 
            // btnSqlServerCreat
            // 
            this.btnSqlServerCreat.Location = new System.Drawing.Point(237, 113);
            this.btnSqlServerCreat.Name = "btnSqlServerCreat";
            this.btnSqlServerCreat.Size = new System.Drawing.Size(94, 25);
            this.btnSqlServerCreat.TabIndex = 18;
            this.btnSqlServerCreat.Text = "创建新数据库";
            this.btnSqlServerCreat.UseVisualStyleBackColor = true;
            this.btnSqlServerCreat.Click += new System.EventHandler(this.SqlCreat_Click);
            // 
            // btnSqlServerReload
            // 
            this.btnSqlServerReload.Location = new System.Drawing.Point(237, 139);
            this.btnSqlServerReload.Name = "btnSqlServerReload";
            this.btnSqlServerReload.Size = new System.Drawing.Size(94, 24);
            this.btnSqlServerReload.TabIndex = 17;
            this.btnSqlServerReload.Tag = "False";
            this.btnSqlServerReload.Text = "刷新数据库列表";
            this.btnSqlServerReload.UseVisualStyleBackColor = true;
            this.btnSqlServerReload.Click += new System.EventHandler(this.SqlReload_Click);
            // 
            // btnSqlServerTest
            // 
            this.btnSqlServerTest.Location = new System.Drawing.Point(111, 170);
            this.btnSqlServerTest.Name = "btnSqlServerTest";
            this.btnSqlServerTest.Size = new System.Drawing.Size(109, 27);
            this.btnSqlServerTest.TabIndex = 16;
            this.btnSqlServerTest.Text = "测试链接数据库";
            this.btnSqlServerTest.UseVisualStyleBackColor = true;
            this.btnSqlServerTest.Click += new System.EventHandler(this.SqlTest_Click);
            // 
            // chkSqlServerInput
            // 
            this.chkSqlServerInput.AutoSize = true;
            this.chkSqlServerInput.Checked = true;
            this.chkSqlServerInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSqlServerInput.Location = new System.Drawing.Point(85, 122);
            this.chkSqlServerInput.Name = "chkSqlServerInput";
            this.chkSqlServerInput.Size = new System.Drawing.Size(120, 16);
            this.chkSqlServerInput.TabIndex = 14;
            this.chkSqlServerInput.Text = "直接填写数据库名";
            this.chkSqlServerInput.UseVisualStyleBackColor = true;
            this.chkSqlServerInput.CheckedChanged += new System.EventHandler(this.chkInputDataName_CheckedChanged);
            // 
            // rbSqlServerConnetionType2
            // 
            this.rbSqlServerConnetionType2.AutoSize = true;
            this.rbSqlServerConnetionType2.Checked = true;
            this.rbSqlServerConnetionType2.Location = new System.Drawing.Point(85, 52);
            this.rbSqlServerConnetionType2.Name = "rbSqlServerConnetionType2";
            this.rbSqlServerConnetionType2.Size = new System.Drawing.Size(137, 16);
            this.rbSqlServerConnetionType2.TabIndex = 11;
            this.rbSqlServerConnetionType2.TabStop = true;
            this.rbSqlServerConnetionType2.Text = "SQL-SERVER 用户认证";
            this.rbSqlServerConnetionType2.UseVisualStyleBackColor = true;
            // 
            // rbSqlServerConnetionType1
            // 
            this.rbSqlServerConnetionType1.AutoSize = true;
            this.rbSqlServerConnetionType1.Location = new System.Drawing.Point(85, 32);
            this.rbSqlServerConnetionType1.Name = "rbSqlServerConnetionType1";
            this.rbSqlServerConnetionType1.Size = new System.Drawing.Size(119, 16);
            this.rbSqlServerConnetionType1.TabIndex = 10;
            this.rbSqlServerConnetionType1.TabStop = true;
            this.rbSqlServerConnetionType1.Text = "Windows 系统认证";
            this.rbSqlServerConnetionType1.UseVisualStyleBackColor = true;
            // 
            // txtSqlServerDatabase
            // 
            this.txtSqlServerDatabase.Location = new System.Drawing.Point(85, 141);
            this.txtSqlServerDatabase.Name = "txtSqlServerDatabase";
            this.txtSqlServerDatabase.Size = new System.Drawing.Size(137, 21);
            this.txtSqlServerDatabase.TabIndex = 9;
            this.txtSqlServerDatabase.TextChanged += new System.EventHandler(this.TxtDataInfo_TextChanged);
            // 
            // txtSqlServerPassword
            // 
            this.txtSqlServerPassword.Location = new System.Drawing.Point(85, 97);
            this.txtSqlServerPassword.Name = "txtSqlServerPassword";
            this.txtSqlServerPassword.PasswordChar = '*';
            this.txtSqlServerPassword.Size = new System.Drawing.Size(137, 21);
            this.txtSqlServerPassword.TabIndex = 8;
            this.txtSqlServerPassword.Text = "GAC Collection";
            this.txtSqlServerPassword.TextChanged += new System.EventHandler(this.TxtDataInfo_TextChanged);
            // 
            // txtSqlServerUser
            // 
            this.txtSqlServerUser.Location = new System.Drawing.Point(85, 73);
            this.txtSqlServerUser.Name = "txtSqlServerUser";
            this.txtSqlServerUser.Size = new System.Drawing.Size(137, 21);
            this.txtSqlServerUser.TabIndex = 7;
            this.txtSqlServerUser.Text = "sa";
            this.txtSqlServerUser.TextChanged += new System.EventHandler(this.TxtDataInfo_TextChanged);
            // 
            // txtSqlServerHost
            // 
            this.txtSqlServerHost.Location = new System.Drawing.Point(85, 4);
            this.txtSqlServerHost.Name = "txtSqlServerHost";
            this.txtSqlServerHost.Size = new System.Drawing.Size(137, 21);
            this.txtSqlServerHost.TabIndex = 6;
            this.txtSqlServerHost.Text = "(local)";
            this.txtSqlServerHost.TextChanged += new System.EventHandler(this.TxtDataInfo_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(223, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 12);
            this.label16.TabIndex = 5;
            this.label16.Text = "(如127.0.0.1,1433)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 146);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "选/填数据库：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(46, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 3;
            this.label14.Text = "密码：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(34, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "用户名：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "认证方式：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "服务器：";
            // 
            // pnMysql
            // 
            this.pnMysql.Controls.Add(this.cmbMysqlDataName);
            this.pnMysql.Controls.Add(this.btnMysqlTest);
            this.pnMysql.Controls.Add(this.btnMysqlReload);
            this.pnMysql.Controls.Add(this.txtMysqlDataName);
            this.pnMysql.Controls.Add(this.chkMysqlInputDataName);
            this.pnMysql.Controls.Add(this.btnMysqlCreat);
            this.pnMysql.Controls.Add(this.cmbMysqlDataEncoding);
            this.pnMysql.Controls.Add(this.txtMysqlDataPwd);
            this.pnMysql.Controls.Add(this.txtMysqlDataUser);
            this.pnMysql.Controls.Add(this.txtMysqlDataPort);
            this.pnMysql.Controls.Add(this.txtMysqlDataIp);
            this.pnMysql.Controls.Add(this.label10);
            this.pnMysql.Controls.Add(this.label9);
            this.pnMysql.Controls.Add(this.label8);
            this.pnMysql.Controls.Add(this.label7);
            this.pnMysql.Controls.Add(this.label6);
            this.pnMysql.Controls.Add(this.label5);
            this.pnMysql.Controls.Add(this.label2);
            this.pnMysql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMysql.Location = new System.Drawing.Point(3, 17);
            this.pnMysql.Name = "pnMysql";
            this.pnMysql.Size = new System.Drawing.Size(337, 210);
            this.pnMysql.TabIndex = 2;
            // 
            // cmbMysqlDataName
            // 
            this.cmbMysqlDataName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMysqlDataName.Enabled = false;
            this.cmbMysqlDataName.FormattingEnabled = true;
            this.cmbMysqlDataName.Location = new System.Drawing.Point(111, 142);
            this.cmbMysqlDataName.Name = "cmbMysqlDataName";
            this.cmbMysqlDataName.Size = new System.Drawing.Size(121, 20);
            this.cmbMysqlDataName.TabIndex = 16;
            this.cmbMysqlDataName.SelectedIndexChanged += new System.EventHandler(this.SqlDataName_SelectedIndexChanged);
            // 
            // btnMysqlTest
            // 
            this.btnMysqlTest.Location = new System.Drawing.Point(118, 171);
            this.btnMysqlTest.Name = "btnMysqlTest";
            this.btnMysqlTest.Size = new System.Drawing.Size(109, 27);
            this.btnMysqlTest.TabIndex = 15;
            this.btnMysqlTest.Text = "测试链接数据库";
            this.btnMysqlTest.UseVisualStyleBackColor = true;
            this.btnMysqlTest.Click += new System.EventHandler(this.SqlTest_Click);
            // 
            // btnMysqlReload
            // 
            this.btnMysqlReload.Location = new System.Drawing.Point(239, 141);
            this.btnMysqlReload.Name = "btnMysqlReload";
            this.btnMysqlReload.Size = new System.Drawing.Size(94, 24);
            this.btnMysqlReload.TabIndex = 15;
            this.btnMysqlReload.Tag = "False";
            this.btnMysqlReload.Text = "刷新数据库列表";
            this.btnMysqlReload.UseVisualStyleBackColor = true;
            this.btnMysqlReload.Click += new System.EventHandler(this.SqlReload_Click);
            // 
            // txtMysqlDataName
            // 
            this.txtMysqlDataName.Location = new System.Drawing.Point(111, 142);
            this.txtMysqlDataName.Name = "txtMysqlDataName";
            this.txtMysqlDataName.Size = new System.Drawing.Size(120, 21);
            this.txtMysqlDataName.TabIndex = 14;
            this.txtMysqlDataName.Text = "GACCollection";
            this.txtMysqlDataName.Visible = false;
            this.txtMysqlDataName.TextChanged += new System.EventHandler(this.TxtDataInfo_TextChanged);
            // 
            // chkMysqlInputDataName
            // 
            this.chkMysqlInputDataName.AutoSize = true;
            this.chkMysqlInputDataName.Checked = true;
            this.chkMysqlInputDataName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMysqlInputDataName.Location = new System.Drawing.Point(111, 124);
            this.chkMysqlInputDataName.Name = "chkMysqlInputDataName";
            this.chkMysqlInputDataName.Size = new System.Drawing.Size(120, 16);
            this.chkMysqlInputDataName.TabIndex = 13;
            this.chkMysqlInputDataName.Text = "直接填写数据库名";
            this.chkMysqlInputDataName.UseVisualStyleBackColor = true;
            this.chkMysqlInputDataName.CheckedChanged += new System.EventHandler(this.chkInputDataName_CheckedChanged);
            // 
            // btnMysqlCreat
            // 
            this.btnMysqlCreat.Location = new System.Drawing.Point(239, 95);
            this.btnMysqlCreat.Name = "btnMysqlCreat";
            this.btnMysqlCreat.Size = new System.Drawing.Size(94, 25);
            this.btnMysqlCreat.TabIndex = 12;
            this.btnMysqlCreat.Text = "创建新数据库";
            this.btnMysqlCreat.UseVisualStyleBackColor = true;
            this.btnMysqlCreat.Click += new System.EventHandler(this.SqlCreat_Click);
            // 
            // cmbMysqlDataEncoding
            // 
            this.cmbMysqlDataEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMysqlDataEncoding.Enabled = false;
            this.cmbMysqlDataEncoding.FormattingEnabled = true;
            this.cmbMysqlDataEncoding.Items.AddRange(new object[] {
            "utf8"});
            this.cmbMysqlDataEncoding.Location = new System.Drawing.Point(111, 98);
            this.cmbMysqlDataEncoding.Name = "cmbMysqlDataEncoding";
            this.cmbMysqlDataEncoding.Size = new System.Drawing.Size(122, 20);
            this.cmbMysqlDataEncoding.TabIndex = 11;
            // 
            // txtMysqlDataPwd
            // 
            this.txtMysqlDataPwd.Location = new System.Drawing.Point(111, 74);
            this.txtMysqlDataPwd.Name = "txtMysqlDataPwd";
            this.txtMysqlDataPwd.PasswordChar = '*';
            this.txtMysqlDataPwd.Size = new System.Drawing.Size(122, 21);
            this.txtMysqlDataPwd.TabIndex = 10;
            this.txtMysqlDataPwd.TextChanged += new System.EventHandler(this.TxtDataInfo_TextChanged);
            // 
            // txtMysqlDataUser
            // 
            this.txtMysqlDataUser.Location = new System.Drawing.Point(111, 50);
            this.txtMysqlDataUser.Name = "txtMysqlDataUser";
            this.txtMysqlDataUser.Size = new System.Drawing.Size(122, 21);
            this.txtMysqlDataUser.TabIndex = 9;
            this.txtMysqlDataUser.Text = "root";
            this.txtMysqlDataUser.TextChanged += new System.EventHandler(this.TxtDataInfo_TextChanged);
            // 
            // txtMysqlDataPort
            // 
            this.txtMysqlDataPort.Location = new System.Drawing.Point(111, 26);
            this.txtMysqlDataPort.Name = "txtMysqlDataPort";
            this.txtMysqlDataPort.Size = new System.Drawing.Size(47, 21);
            this.txtMysqlDataPort.TabIndex = 8;
            this.txtMysqlDataPort.Text = "3306";
            this.txtMysqlDataPort.TextChanged += new System.EventHandler(this.TxtDataInfo_TextChanged);
            this.txtMysqlDataPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMysqlDataPort_KeyPress);
            // 
            // txtMysqlDataIp
            // 
            this.txtMysqlDataIp.Location = new System.Drawing.Point(111, 2);
            this.txtMysqlDataIp.Name = "txtMysqlDataIp";
            this.txtMysqlDataIp.Size = new System.Drawing.Size(122, 21);
            this.txtMysqlDataIp.TabIndex = 7;
            this.txtMysqlDataIp.Text = "localhost";
            this.txtMysqlDataIp.TextChanged += new System.EventHandler(this.TxtDataInfo_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(162, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "(MySQL默认安装端口为3306)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "选择/填写数据库：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "数据库编码：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "用户名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "端口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "服务器：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(9, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "选择方便您使用的数据库:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 118);
            this.label3.TabIndex = 0;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(270, 192);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(58, 22);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnTransformation
            // 
            this.btnTransformation.Location = new System.Drawing.Point(125, 270);
            this.btnTransformation.Name = "btnTransformation";
            this.btnTransformation.Size = new System.Drawing.Size(105, 31);
            this.btnTransformation.TabIndex = 4;
            this.btnTransformation.Text = "开始转换";
            this.btnTransformation.UseVisualStyleBackColor = true;
            this.btnTransformation.Click += new System.EventHandler(this.btnTransformation_Click);
            // 
            // FrmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 306);
            this.Controls.Add(this.btnTransformation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.lblDataType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDatabase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择数据保存方式";
            this.Load += new System.EventHandler(this.FrmDatabase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnResult.ResumeLayout(false);
            this.pnResult.PerformLayout();
            this.pnSqlServer.ResumeLayout(false);
            this.pnSqlServer.PerformLayout();
            this.pnMysql.ResumeLayout(false);
            this.pnMysql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTransformation;
        private System.Windows.Forms.Panel pnMysql;
        private System.Windows.Forms.Button btnMysqlCreat;
        private System.Windows.Forms.ComboBox cmbMysqlDataEncoding;
        private System.Windows.Forms.TextBox txtMysqlDataPwd;
        private System.Windows.Forms.TextBox txtMysqlDataUser;
        private System.Windows.Forms.TextBox txtMysqlDataPort;
        private System.Windows.Forms.TextBox txtMysqlDataIp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMysqlDataName;
        private System.Windows.Forms.CheckBox chkMysqlInputDataName;
        private System.Windows.Forms.Button btnMysqlTest;
        private System.Windows.Forms.Button btnMysqlReload;
        private System.Windows.Forms.ComboBox cmbMysqlDataName;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Panel pnSqlServer;
        private System.Windows.Forms.TextBox txtSqlServerDatabase;
        private System.Windows.Forms.TextBox txtSqlServerPassword;
        private System.Windows.Forms.TextBox txtSqlServerUser;
        private System.Windows.Forms.TextBox txtSqlServerHost;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSqlServerCreat;
        private System.Windows.Forms.Button btnSqlServerReload;
        private System.Windows.Forms.Button btnSqlServerTest;
        private System.Windows.Forms.CheckBox chkSqlServerInput;
        private System.Windows.Forms.RadioButton rbSqlServerConnetionType2;
        private System.Windows.Forms.RadioButton rbSqlServerConnetionType1;
        private System.Windows.Forms.ComboBox cmbSqlServerDatabase;
        private System.Windows.Forms.Panel pnResult;
        private System.Windows.Forms.TextBox txtLog;
    }
}