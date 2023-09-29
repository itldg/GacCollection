using GacHelper;
using System.Drawing;

namespace GAC_Collection.MainUi.Task
{
    partial class FrmJob
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJob));
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbUrlTest = new System.Windows.Forms.GroupBox();
            this.gbUrlStatus = new System.Windows.Forms.GroupBox();
            this.btnUrlStop = new System.Windows.Forms.Button();
            this.lblStaus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbUrlShow = new System.Windows.Forms.GroupBox();
            this.ucCloseButton3 = new GAC_Collection.UserContorl.UCCloseButton();
            this.rtbeUrlShow = new GAC_Collection.Ex.RichTextBoxEx();
            this.label27 = new System.Windows.Forms.Label();
            this.btnCancelOption = new System.Windows.Forms.Button();
            this.btnUrlClaer = new System.Windows.Forms.Button();
            this.btnUrlDelete = new System.Windows.Forms.Button();
            this.btnUrlTest = new System.Windows.Forms.Button();
            this.btnSeeSourceCode = new System.Windows.Forms.Button();
            this.btnUrlBrowse = new System.Windows.Forms.Button();
            this.btnUrlCopyUrl = new System.Windows.Forms.Button();
            this.btnUrlExportCurrentNode = new System.Windows.Forms.Button();
            this.btnUrlExportFirst = new System.Windows.Forms.Button();
            this.btnUrlExportRootNode = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.tvUrlRule = new System.Windows.Forms.TreeView();
            this.pStep1 = new System.Windows.Forms.Panel();
            this.pStep1Remarks = new System.Windows.Forms.Panel();
            this.gbStep1url5 = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnTestGetUrls = new System.Windows.Forms.Button();
            this.gbStep1url4 = new System.Windows.Forms.GroupBox();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.txtLoginCookies = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.picMenu1 = new GAC_Collection.Ex.PicMenu();
            this.cmsUserAgent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.chromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.安卓UCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.塞班ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iphoneSafriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucHelper2 = new GacHelper.UCHelper();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbStep1url3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudUrlRepeatCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMultilevelURLTestOne = new System.Windows.Forms.CheckBox();
            this.chkCheckUrl = new System.Windows.Forms.CheckBox();
            this.ucHelper1 = new GacHelper.UCHelper();
            this.gbMultipleURLRule = new System.Windows.Forms.GroupBox();
            this.ucCloseButton1 = new GAC_Collection.UserContorl.UCCloseButton();
            this.tbMultipleURL = new System.Windows.Forms.TabControl();
            this.tpUrlGetOption = new System.Windows.Forms.TabPage();
            this.ucHelper4 = new GacHelper.UCHelper();
            this.ucHelper3 = new GacHelper.UCHelper();
            this.gbResultFilter = new System.Windows.Forms.GroupBox();
            this.ucLableText6 = new GAC_Collection.Ex.UCLableText();
            this.rtbeUrlNotContain = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText5 = new GAC_Collection.Ex.UCLableText();
            this.ucLableText4 = new GAC_Collection.Ex.UCLableText();
            this.rtbeUrlContain = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText3 = new GAC_Collection.Ex.UCLableText();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbMultipleURLRegion = new System.Windows.Forms.GroupBox();
            this.ucLableText2 = new GAC_Collection.Ex.UCLableText();
            this.rtbeUrlEnd = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText1 = new GAC_Collection.Ex.UCLableText();
            this.rtbeUrlStart = new GAC_Collection.Ex.RichTextBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbGetUrlForXpath = new System.Windows.Forms.RadioButton();
            this.rbGetUrlManualFillRule = new System.Windows.Forms.RadioButton();
            this.rbGetUrlAtuo = new System.Windows.Forms.RadioButton();
            this.pUrlManual = new System.Windows.Forms.Panel();
            this.rtbxUrlResult = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText9 = new GAC_Collection.Ex.UCLableText();
            this.rtbeUrlScriptRule = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText11 = new GAC_Collection.Ex.UCLableText();
            this.ucLableText8 = new GAC_Collection.Ex.UCLableText();
            this.ucLableText10 = new GAC_Collection.Ex.UCLableText();
            this.ucLableText7 = new GAC_Collection.Ex.UCLableText();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pUrlXpath = new System.Windows.Forms.Panel();
            this.btnGetXpath = new System.Windows.Forms.Button();
            this.txtUrlXpath = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.gbPostOption = new System.Windows.Forms.GroupBox();
            this.pRandValue = new System.Windows.Forms.Panel();
            this.btnCancelRandValue = new System.Windows.Forms.Button();
            this.btnSaveRandValue = new System.Windows.Forms.Button();
            this.ucLableText21 = new GAC_Collection.Ex.UCLableText();
            this.rtbeRandValueEnd = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText20 = new GAC_Collection.Ex.UCLableText();
            this.rtbeRandValueStart = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucCloseButton2 = new GAC_Collection.UserContorl.UCCloseButton();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btnPostValueDelete = new System.Windows.Forms.Button();
            this.btnPostValueEdit = new System.Windows.Forms.Button();
            this.btnPostValueAdd = new System.Windows.Forms.Button();
            this.lvPost = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ultPagination = new GAC_Collection.Ex.UCLableText();
            this.rtbePostData = new GAC_Collection.Ex.RichTextBoxEx();
            this.ultPostRandValue = new GAC_Collection.Ex.UCLableText();
            this.label17 = new System.Windows.Forms.Label();
            this.nudPostEnd = new System.Windows.Forms.NumericUpDown();
            this.nudPostStart = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rbAspXPost = new System.Windows.Forms.RadioButton();
            this.rbPost = new System.Windows.Forms.RadioButton();
            this.rbGet = new System.Windows.Forms.RadioButton();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.gbCombination = new System.Windows.Forms.GroupBox();
            this.ucHelper5 = new GacHelper.UCHelper();
            this.rtbeListPageStyle = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText14 = new GAC_Collection.Ex.UCLableText();
            this.rtbeListPageUrlStyle = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText15 = new GAC_Collection.Ex.UCLableText();
            this.ucLableText17 = new GAC_Collection.Ex.UCLableText();
            this.ucLableText18 = new GAC_Collection.Ex.UCLableText();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.chkAutoGetPage = new System.Windows.Forms.CheckBox();
            this.nudPagesMax = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.gbPageGet = new System.Windows.Forms.GroupBox();
            this.ucLableText12 = new GAC_Collection.Ex.UCLableText();
            this.rtbeListPageEnd = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText13 = new GAC_Collection.Ex.UCLableText();
            this.rtbeListPageStart = new GAC_Collection.Ex.RichTextBoxEx();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.ucLableText19 = new GAC_Collection.Ex.UCLableText();
            this.rtbeAdditionalparameter = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText16 = new GAC_Collection.Ex.UCLableText();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnCancelUrlRule = new System.Windows.Forms.Button();
            this.btnSaveUrlRule = new System.Windows.Forms.Button();
            this.gbStep1url1 = new System.Windows.Forms.GroupBox();
            this.lbUrl1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStep1UrlClear = new System.Windows.Forms.Button();
            this.btnStep1UrlDelete = new System.Windows.Forms.Button();
            this.btnStep1UrlEdit = new System.Windows.Forms.Button();
            this.btnStep1UrlAdd = new System.Windows.Forms.Button();
            this.gbStep1url2 = new System.Windows.Forms.GroupBox();
            this.lvMultilevelURL = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnStep1MultilevelUrlClear = new System.Windows.Forms.Button();
            this.btnStep1MultilevelUrlDelete = new System.Windows.Forms.Button();
            this.btnStep1MultilevelEdit = new System.Windows.Forms.Button();
            this.btnStep1MultilevelUrlAdd = new System.Windows.Forms.Button();
            this.tpLable = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gbPagesCombine = new System.Windows.Forms.GroupBox();
            this.ucLableText27 = new GAC_Collection.Ex.UCLableText();
            this.rtbePagesCombine = new GAC_Collection.Ex.RichTextBoxEx();
            this.gbPagesStyle = new System.Windows.Forms.GroupBox();
            this.ucLableText25 = new GAC_Collection.Ex.UCLableText();
            this.rtbePagesStyle = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText24 = new GAC_Collection.Ex.UCLableText();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rbManualPaging = new System.Windows.Forms.RadioButton();
            this.rbGetPagesUrlAuto = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbePagesAreaEnd = new GAC_Collection.Ex.RichTextBoxEx();
            this.rtbePagesAreaStart = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText23 = new GAC_Collection.Ex.UCLableText();
            this.label29 = new System.Windows.Forms.Label();
            this.ucLableText22 = new GAC_Collection.Ex.UCLableText();
            this.label28 = new System.Windows.Forms.Label();
            this.rbUpDownPage = new System.Windows.Forms.RadioButton();
            this.rbPagesUrlListAll = new System.Windows.Forms.RadioButton();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.ucHelper6 = new GacHelper.UCHelper();
            this.txtPagesJoinCode = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkFillLoopWithFirst = new System.Windows.Forms.CheckBox();
            this.ucHelper7 = new GacHelper.UCHelper();
            this.rtbeLoopJoinCode = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText26 = new GAC_Collection.Ex.UCLableText();
            this.label31 = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.rbLoopAddNewRecord = new System.Windows.Forms.RadioButton();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.nudMaxSpiderPerNum = new System.Windows.Forms.NumericUpDown();
            this.nudMaxPages = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvLable = new System.Windows.Forms.ListView();
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSortUp = new System.Windows.Forms.Button();
            this.btnSortDown = new System.Windows.Forms.Button();
            this.btnMultPageChange = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnLabelImport = new System.Windows.Forms.Button();
            this.btnLabelDelete = new System.Windows.Forms.Button();
            this.btnLabelCopy = new System.Windows.Forms.Button();
            this.btnLabelEdit = new System.Windows.Forms.Button();
            this.btnLabelAdd = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbTestJob = new System.Windows.Forms.GroupBox();
            this.lblTsetJobStatus = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rtbeTestResult = new GAC_Collection.Ex.RichTextBoxEx();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cmbTestPageUrls = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.cmsTest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTestSend = new System.Windows.Forms.ToolStripMenuItem();
            this.在浏览器中查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取页面源代码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label30 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lvDown = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsDown = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拷贝地址ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListFile = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbDownLog = new System.Windows.Forms.RichTextBox();
            this.chkWeb = new System.Windows.Forms.TabPage();
            this.txtVisitUrlAfterEnd = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.chkSignSucessIfAllPost = new System.Windows.Forms.CheckBox();
            this.chkNotWebOutIfFileNoDownLoad = new System.Windows.Forms.CheckBox();
            this.nudMaxOutPerNum = new System.Windows.Forms.NumericUpDown();
            this.label40 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkFinishDeleteUrl = new System.Windows.Forms.CheckBox();
            this.chkFinishDeleteOutFaild = new System.Windows.Forms.CheckBox();
            this.chkFinishSignOutSucess = new System.Windows.Forms.CheckBox();
            this.chkFinishDeleteOutSucess = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.lvDatabase = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ucHelper8 = new GacHelper.UCHelper();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.cmbFileEncoding = new System.Windows.Forms.ComboBox();
            this.picMenu2 = new GAC_Collection.Ex.PicMenu();
            this.cmsNameStyle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.任务名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.随机文件名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.任务IdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yyyyMMddHHmmssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.记录IDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbeFilenNameType = new GAC_Collection.Ex.RichTextBoxEx();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.txtFileTemplate = new System.Windows.Forms.TextBox();
            this.txtFileSavePath = new System.Windows.Forms.TextBox();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.chkFileOut = new System.Windows.Forms.CheckBox();
            this.gbWebPost = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ucHelper10 = new GacHelper.UCHelper();
            this.rbWebOutType3 = new System.Windows.Forms.RadioButton();
            this.rbWebOutType2 = new System.Windows.Forms.RadioButton();
            this.rbWebOutType1 = new System.Windows.Forms.RadioButton();
            this.rbWebOutType0 = new System.Windows.Forms.RadioButton();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.btnModuleDelete = new System.Windows.Forms.Button();
            this.btnModuleEdit = new System.Windows.Forms.Button();
            this.btnModuleAdd = new System.Windows.Forms.Button();
            this.lvWebPost = new System.Windows.Forms.ListView();
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkWebOutput = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cmbPlugins = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.gbFileDownSetting = new System.Windows.Forms.GroupBox();
            this.ucHelper11 = new GacHelper.UCHelper();
            this.btnBaseFileDirSelect = new System.Windows.Forms.Button();
            this.nudDownloadSegments = new System.Windows.Forms.NumericUpDown();
            this.nudMaxDownload = new System.Windows.Forms.NumericUpDown();
            this.chkDownFileWithTools = new System.Windows.Forms.CheckBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.rbDownFile = new System.Windows.Forms.RadioButton();
            this.rbDownFileAsy = new System.Windows.Forms.RadioButton();
            this.txtFileUploadDomain = new System.Windows.Forms.TextBox();
            this.txtBaseFileDir = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.gbHtpp = new System.Windows.Forms.GroupBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nudProxyPort = new System.Windows.Forms.NumericUpDown();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.txtProxyUsername = new System.Windows.Forms.TextBox();
            this.txtProxyServer = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.rbProxyType2 = new System.Windows.Forms.RadioButton();
            this.rbProxyType1 = new System.Windows.Forms.RadioButton();
            this.rbProxyType0 = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtCredentialsPassword = new System.Windows.Forms.TextBox();
            this.txtCredentialsDomain = new System.Windows.Forms.TextBox();
            this.txtCredentialsUserName = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.chkUseCredentials = new System.Windows.Forms.CheckBox();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAcceptLanguage = new System.Windows.Forms.TextBox();
            this.chkKeepAlive = new System.Windows.Forms.CheckBox();
            this.chkGzip = new System.Windows.Forms.CheckBox();
            this.chkDeflate = new System.Windows.Forms.CheckBox();
            this.chkAutoDirect = new System.Windows.Forms.CheckBox();
            this.label55 = new System.Windows.Forms.Label();
            this.nudTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label54 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ucHelper9 = new GacHelper.UCHelper();
            this.label46 = new System.Windows.Forms.Label();
            this.nudOutTimeEnd = new System.Windows.Forms.NumericUpDown();
            this.nudOutTimeStart = new System.Windows.Forms.NumericUpDown();
            this.nudOutThreadNum = new System.Windows.Forms.NumericUpDown();
            this.nudSpiderTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.nudSpiderThreadNum = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbUrlTest.SuspendLayout();
            this.gbUrlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbUrlShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucCloseButton3)).BeginInit();
            this.pStep1.SuspendLayout();
            this.pStep1Remarks.SuspendLayout();
            this.gbStep1url5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbStep1url4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.cmsUserAgent.SuspendLayout();
            this.panel5.SuspendLayout();
            this.gbStep1url3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUrlRepeatCount)).BeginInit();
            this.gbMultipleURLRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucCloseButton1)).BeginInit();
            this.tbMultipleURL.SuspendLayout();
            this.tpUrlGetOption.SuspendLayout();
            this.gbResultFilter.SuspendLayout();
            this.gbMultipleURLRegion.SuspendLayout();
            this.pUrlManual.SuspendLayout();
            this.pUrlXpath.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.gbPostOption.SuspendLayout();
            this.pRandValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucCloseButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostStart)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.gbCombination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPagesMax)).BeginInit();
            this.gbPageGet.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.gbStep1url1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbStep1url2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tpLable.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.gbPagesCombine.SuspendLayout();
            this.gbPagesStyle.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpiderPerNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPages)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbTestJob.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel10.SuspendLayout();
            this.cmsTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cmsDown.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.chkWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxOutPerNum)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.cmsNameStyle.SuspendLayout();
            this.gbWebPost.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gbFileDownSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownloadSegments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDownload)).BeginInit();
            this.gbHtpp.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutTimeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutTimeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutThreadNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpiderTimeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpiderThreadNum)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务名称：";
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(71, 7);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(299, 21);
            this.txtJobName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "网页编码：";
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
            this.cmbEncoding.Location = new System.Drawing.Point(436, 8);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(141, 20);
            this.cmbEncoding.TabIndex = 3;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tpLable);
            this.tcMain.Controls.Add(this.chkWeb);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(5, 32);
            this.tcMain.Margin = new System.Windows.Forms.Padding(10);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(774, 555);
            this.tcMain.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.gbUrlTest);
            this.tabPage1.Controls.Add(this.pStep1);
            this.tabPage1.Controls.Add(this.gbMultipleURLRule);
            this.tabPage1.Controls.Add(this.gbStep1url1);
            this.tabPage1.Controls.Add(this.gbStep1url2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(766, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "第一步：采集网址规则";
            // 
            // gbUrlTest
            // 
            this.gbUrlTest.Controls.Add(this.gbUrlStatus);
            this.gbUrlTest.Controls.Add(this.gbUrlShow);
            this.gbUrlTest.Controls.Add(this.btnCancelOption);
            this.gbUrlTest.Controls.Add(this.btnUrlClaer);
            this.gbUrlTest.Controls.Add(this.btnUrlDelete);
            this.gbUrlTest.Controls.Add(this.btnUrlTest);
            this.gbUrlTest.Controls.Add(this.btnSeeSourceCode);
            this.gbUrlTest.Controls.Add(this.btnUrlBrowse);
            this.gbUrlTest.Controls.Add(this.btnUrlCopyUrl);
            this.gbUrlTest.Controls.Add(this.btnUrlExportCurrentNode);
            this.gbUrlTest.Controls.Add(this.btnUrlExportFirst);
            this.gbUrlTest.Controls.Add(this.btnUrlExportRootNode);
            this.gbUrlTest.Controls.Add(this.lblCurrent);
            this.gbUrlTest.Controls.Add(this.tvUrlRule);
            this.gbUrlTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUrlTest.Location = new System.Drawing.Point(3, 3);
            this.gbUrlTest.Name = "gbUrlTest";
            this.gbUrlTest.Size = new System.Drawing.Size(760, 523);
            this.gbUrlTest.TabIndex = 4;
            this.gbUrlTest.TabStop = false;
            this.gbUrlTest.Text = "测试地址采集";
            this.gbUrlTest.Visible = false;
            // 
            // gbUrlStatus
            // 
            this.gbUrlStatus.Controls.Add(this.btnUrlStop);
            this.gbUrlStatus.Controls.Add(this.lblStaus);
            this.gbUrlStatus.Controls.Add(this.pictureBox1);
            this.gbUrlStatus.Location = new System.Drawing.Point(91, 194);
            this.gbUrlStatus.Name = "gbUrlStatus";
            this.gbUrlStatus.Size = new System.Drawing.Size(495, 90);
            this.gbUrlStatus.TabIndex = 12;
            this.gbUrlStatus.TabStop = false;
            this.gbUrlStatus.Text = "正在采集网址，请稍后";
            this.gbUrlStatus.Visible = false;
            // 
            // btnUrlStop
            // 
            this.btnUrlStop.Location = new System.Drawing.Point(435, 31);
            this.btnUrlStop.Name = "btnUrlStop";
            this.btnUrlStop.Size = new System.Drawing.Size(54, 36);
            this.btnUrlStop.TabIndex = 2;
            this.btnUrlStop.Text = "停止";
            this.btnUrlStop.UseVisualStyleBackColor = true;
            this.btnUrlStop.Click += new System.EventHandler(this.btnUrlStop_Click);
            // 
            // lblStaus
            // 
            this.lblStaus.Location = new System.Drawing.Point(43, 29);
            this.lblStaus.Name = "lblStaus";
            this.lblStaus.Size = new System.Drawing.Size(386, 46);
            this.lblStaus.TabIndex = 1;
            this.lblStaus.Text = "正在下载并分析网址\r\n请稍后呦~";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gbUrlShow
            // 
            this.gbUrlShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUrlShow.Controls.Add(this.ucCloseButton3);
            this.gbUrlShow.Controls.Add(this.rtbeUrlShow);
            this.gbUrlShow.Controls.Add(this.label27);
            this.gbUrlShow.Location = new System.Drawing.Point(172, 19);
            this.gbUrlShow.Name = "gbUrlShow";
            this.gbUrlShow.Size = new System.Drawing.Size(481, 374);
            this.gbUrlShow.TabIndex = 13;
            this.gbUrlShow.TabStop = false;
            this.gbUrlShow.Visible = false;
            // 
            // ucCloseButton3
            // 
            this.ucCloseButton3.ClickImage = ((System.Drawing.Image)(resources.GetObject("ucCloseButton3.ClickImage")));
            this.ucCloseButton3.Enter = ((System.Drawing.Image)(resources.GetObject("ucCloseButton3.Enter")));
            this.ucCloseButton3.Image = ((System.Drawing.Image)(resources.GetObject("ucCloseButton3.Image")));
            this.ucCloseButton3.Location = new System.Drawing.Point(465, 14);
            this.ucCloseButton3.Name = "ucCloseButton3";
            this.ucCloseButton3.Normal = ((System.Drawing.Image)(resources.GetObject("ucCloseButton3.Normal")));
            this.ucCloseButton3.Size = new System.Drawing.Size(12, 12);
            this.ucCloseButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ucCloseButton3.TabIndex = 2;
            this.ucCloseButton3.TabStop = false;
            this.ucCloseButton3.Click += new System.EventHandler(this.ucCloseButton3_Click);
            // 
            // rtbeUrlShow
            // 
            this.rtbeUrlShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbeUrlShow.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeUrlShow.LableList")));
            this.rtbeUrlShow.Location = new System.Drawing.Point(3, 34);
            this.rtbeUrlShow.Name = "rtbeUrlShow";
            this.rtbeUrlShow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeUrlShow.Size = new System.Drawing.Size(475, 337);
            this.rtbeUrlShow.TabIndex = 1;
            this.rtbeUrlShow.TextValue = "";
            this.rtbeUrlShow.WordWrap = true;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label27.Location = new System.Drawing.Point(159, 15);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(173, 12);
            this.label27.TabIndex = 0;
            this.label27.Text = "列表页自定义标签采集测试预览";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelOption
            // 
            this.btnCancelOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelOption.Location = new System.Drawing.Point(662, 457);
            this.btnCancelOption.Name = "btnCancelOption";
            this.btnCancelOption.Size = new System.Drawing.Size(94, 37);
            this.btnCancelOption.TabIndex = 11;
            this.btnCancelOption.Text = "返回修改设置";
            this.btnCancelOption.UseVisualStyleBackColor = true;
            this.btnCancelOption.Click += new System.EventHandler(this.btnCancelOption_Click);
            // 
            // btnUrlClaer
            // 
            this.btnUrlClaer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrlClaer.Location = new System.Drawing.Point(660, 346);
            this.btnUrlClaer.Name = "btnUrlClaer";
            this.btnUrlClaer.Size = new System.Drawing.Size(94, 31);
            this.btnUrlClaer.TabIndex = 10;
            this.btnUrlClaer.Text = "清空";
            this.btnUrlClaer.UseVisualStyleBackColor = true;
            this.btnUrlClaer.Click += new System.EventHandler(this.btnUrlClaer_Click);
            // 
            // btnUrlDelete
            // 
            this.btnUrlDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrlDelete.Location = new System.Drawing.Point(660, 305);
            this.btnUrlDelete.Name = "btnUrlDelete";
            this.btnUrlDelete.Size = new System.Drawing.Size(94, 31);
            this.btnUrlDelete.TabIndex = 9;
            this.btnUrlDelete.Text = "删除";
            this.btnUrlDelete.UseVisualStyleBackColor = true;
            this.btnUrlDelete.Click += new System.EventHandler(this.btnUrlDelete_Click);
            // 
            // btnUrlTest
            // 
            this.btnUrlTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrlTest.Location = new System.Drawing.Point(660, 264);
            this.btnUrlTest.Name = "btnUrlTest";
            this.btnUrlTest.Size = new System.Drawing.Size(94, 31);
            this.btnUrlTest.TabIndex = 8;
            this.btnUrlTest.Text = "测试该页";
            this.btnUrlTest.UseVisualStyleBackColor = true;
            this.btnUrlTest.Click += new System.EventHandler(this.btnUrlTest_Click);
            // 
            // btnSeeSourceCode
            // 
            this.btnSeeSourceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeeSourceCode.Location = new System.Drawing.Point(660, 223);
            this.btnSeeSourceCode.Name = "btnSeeSourceCode";
            this.btnSeeSourceCode.Size = new System.Drawing.Size(94, 31);
            this.btnSeeSourceCode.TabIndex = 7;
            this.btnSeeSourceCode.Text = "查看源代码";
            this.btnSeeSourceCode.UseVisualStyleBackColor = true;
            // 
            // btnUrlBrowse
            // 
            this.btnUrlBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrlBrowse.Location = new System.Drawing.Point(660, 182);
            this.btnUrlBrowse.Name = "btnUrlBrowse";
            this.btnUrlBrowse.Size = new System.Drawing.Size(94, 31);
            this.btnUrlBrowse.TabIndex = 6;
            this.btnUrlBrowse.Text = "浏览页面";
            this.btnUrlBrowse.UseVisualStyleBackColor = true;
            this.btnUrlBrowse.Click += new System.EventHandler(this.btnUrlBrowse_Click);
            // 
            // btnUrlCopyUrl
            // 
            this.btnUrlCopyUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrlCopyUrl.Location = new System.Drawing.Point(660, 141);
            this.btnUrlCopyUrl.Name = "btnUrlCopyUrl";
            this.btnUrlCopyUrl.Size = new System.Drawing.Size(94, 31);
            this.btnUrlCopyUrl.TabIndex = 5;
            this.btnUrlCopyUrl.Text = "复制网址";
            this.btnUrlCopyUrl.UseVisualStyleBackColor = true;
            this.btnUrlCopyUrl.Click += new System.EventHandler(this.btnUrlCopyUrl_Click);
            // 
            // btnUrlExportCurrentNode
            // 
            this.btnUrlExportCurrentNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrlExportCurrentNode.Location = new System.Drawing.Point(660, 100);
            this.btnUrlExportCurrentNode.Name = "btnUrlExportCurrentNode";
            this.btnUrlExportCurrentNode.Size = new System.Drawing.Size(94, 31);
            this.btnUrlExportCurrentNode.TabIndex = 4;
            this.btnUrlExportCurrentNode.Text = "导出同级节点";
            this.btnUrlExportCurrentNode.UseVisualStyleBackColor = true;
            this.btnUrlExportCurrentNode.Click += new System.EventHandler(this.btnUrlExportCurrentNode_Click);
            // 
            // btnUrlExportFirst
            // 
            this.btnUrlExportFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrlExportFirst.Location = new System.Drawing.Point(660, 59);
            this.btnUrlExportFirst.Name = "btnUrlExportFirst";
            this.btnUrlExportFirst.Size = new System.Drawing.Size(94, 31);
            this.btnUrlExportFirst.TabIndex = 3;
            this.btnUrlExportFirst.Text = "导出一级节点";
            this.btnUrlExportFirst.UseVisualStyleBackColor = true;
            this.btnUrlExportFirst.Click += new System.EventHandler(this.btnUrlExportFirst_Click);
            // 
            // btnUrlExportRootNode
            // 
            this.btnUrlExportRootNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrlExportRootNode.Location = new System.Drawing.Point(660, 18);
            this.btnUrlExportRootNode.Name = "btnUrlExportRootNode";
            this.btnUrlExportRootNode.Size = new System.Drawing.Size(94, 31);
            this.btnUrlExportRootNode.TabIndex = 2;
            this.btnUrlExportRootNode.Text = "导出根节点";
            this.btnUrlExportRootNode.UseVisualStyleBackColor = true;
            this.btnUrlExportRootNode.Click += new System.EventHandler(this.btnUrlExportRootNode_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCurrent.Location = new System.Drawing.Point(3, 494);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(754, 26);
            this.lblCurrent.TabIndex = 1;
            this.lblCurrent.Text = "正在获取网址列表\r\n请稍后";
            // 
            // tvUrlRule
            // 
            this.tvUrlRule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvUrlRule.Location = new System.Drawing.Point(8, 19);
            this.tvUrlRule.Name = "tvUrlRule";
            this.tvUrlRule.Size = new System.Drawing.Size(645, 473);
            this.tvUrlRule.TabIndex = 0;
            this.tvUrlRule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvUrlRule_AfterSelect);
            this.tvUrlRule.DoubleClick += new System.EventHandler(this.tvUrlRule_DoubleClick);
            // 
            // pStep1
            // 
            this.pStep1.Controls.Add(this.pStep1Remarks);
            this.pStep1.Controls.Add(this.gbStep1url4);
            this.pStep1.Controls.Add(this.gbStep1url3);
            this.pStep1.Location = new System.Drawing.Point(6, 322);
            this.pStep1.Name = "pStep1";
            this.pStep1.Size = new System.Drawing.Size(762, 211);
            this.pStep1.TabIndex = 3;
            // 
            // pStep1Remarks
            // 
            this.pStep1Remarks.Controls.Add(this.gbStep1url5);
            this.pStep1Remarks.Controls.Add(this.panel4);
            this.pStep1Remarks.Location = new System.Drawing.Point(3, 130);
            this.pStep1Remarks.Name = "pStep1Remarks";
            this.pStep1Remarks.Size = new System.Drawing.Size(756, 75);
            this.pStep1Remarks.TabIndex = 3;
            // 
            // gbStep1url5
            // 
            this.gbStep1url5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gbStep1url5.Controls.Add(this.txtRemarks);
            this.gbStep1url5.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbStep1url5.Location = new System.Drawing.Point(0, 0);
            this.gbStep1url5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.gbStep1url5.Name = "gbStep1url5";
            this.gbStep1url5.Size = new System.Drawing.Size(600, 68);
            this.gbStep1url5.TabIndex = 2;
            this.gbStep1url5.TabStop = false;
            this.gbStep1url5.Text = "任务备注";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(3, 17);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(594, 48);
            this.txtRemarks.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.linkLabel1);
            this.panel4.Controls.Add(this.btnTestGetUrls);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(600, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(156, 75);
            this.panel4.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(133, 35);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(17, 12);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "=>";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnTestGetUrls
            // 
            this.btnTestGetUrls.Location = new System.Drawing.Point(8, 18);
            this.btnTestGetUrls.Name = "btnTestGetUrls";
            this.btnTestGetUrls.Size = new System.Drawing.Size(114, 46);
            this.btnTestGetUrls.TabIndex = 0;
            this.btnTestGetUrls.Text = "测试网址采集";
            this.btnTestGetUrls.UseVisualStyleBackColor = true;
            this.btnTestGetUrls.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbStep1url4
            // 
            this.gbStep1url4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStep1url4.Controls.Add(this.txtUserAgent);
            this.gbStep1url4.Controls.Add(this.txtLoginCookies);
            this.gbStep1url4.Controls.Add(this.panel6);
            this.gbStep1url4.Controls.Add(this.panel5);
            this.gbStep1url4.Location = new System.Drawing.Point(2, 50);
            this.gbStep1url4.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.gbStep1url4.Name = "gbStep1url4";
            this.gbStep1url4.Size = new System.Drawing.Size(755, 70);
            this.gbStep1url4.TabIndex = 0;
            this.gbStep1url4.TabStop = false;
            this.gbStep1url4.Text = "网页登陆信息";
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserAgent.Location = new System.Drawing.Point(86, 44);
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.Size = new System.Drawing.Size(562, 21);
            this.txtUserAgent.TabIndex = 2;
            this.txtUserAgent.Text = "Mozilla/5.0+(compatible;+Baiduspider/2.0;++http://www.baidu.com/search/spider.htm" +
    "l)";
            // 
            // txtLoginCookies
            // 
            this.txtLoginCookies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoginCookies.Location = new System.Drawing.Point(86, 19);
            this.txtLoginCookies.Name = "txtLoginCookies";
            this.txtLoginCookies.Size = new System.Drawing.Size(562, 21);
            this.txtLoginCookies.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.picMenu1);
            this.panel6.Controls.Add(this.ucHelper2);
            this.panel6.Controls.Add(this.linkLabel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(649, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(103, 50);
            this.panel6.TabIndex = 1;
            // 
            // picMenu1
            // 
            this.picMenu1.ContextMenuStrip = this.cmsUserAgent;
            this.picMenu1.Location = new System.Drawing.Point(5, 26);
            this.picMenu1.Name = "picMenu1";
            this.picMenu1.OperationControl = this.txtUserAgent;
            this.picMenu1.Pic = ((System.Drawing.Image)(resources.GetObject("picMenu1.Pic")));
            this.picMenu1.Size = new System.Drawing.Size(18, 18);
            this.picMenu1.TabIndex = 3;
            // 
            // cmsUserAgent
            // 
            this.cmsUserAgent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem5,
            this.chromeToolStripMenuItem,
            this.安卓UCToolStripMenuItem,
            this.塞班ToolStripMenuItem,
            this.iphoneSafriaToolStripMenuItem});
            this.cmsUserAgent.Name = "cmsUserAgent";
            this.cmsUserAgent.Size = new System.Drawing.Size(158, 158);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem2.Tag = "Mozilla/5.0+(compatible;+Baiduspider/2.0;++http://www.baidu.com/search/spider.htm" +
    "l)";
            this.toolStripMenuItem2.Text = "百度蜘蛛";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem3.Tag = "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)";
            this.toolStripMenuItem3.Text = "Google蜘蛛";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem5.Tag = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/534.55.3 (KHTML, like Gecko) Version/5.1" +
    ".5 Safari/534.55.3";
            this.toolStripMenuItem5.Text = "Safari";
            // 
            // chromeToolStripMenuItem
            // 
            this.chromeToolStripMenuItem.Name = "chromeToolStripMenuItem";
            this.chromeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.chromeToolStripMenuItem.Tag = "Mozilla/5.0 (Windows; U; Windows NT 5.2) AppleWebKit/525.13 (KHTML, like Gecko) C" +
    "hrome/0.2.149.27 Safari/525.13 ";
            this.chromeToolStripMenuItem.Text = "Chrome";
            // 
            // 安卓UCToolStripMenuItem
            // 
            this.安卓UCToolStripMenuItem.Name = "安卓UCToolStripMenuItem";
            this.安卓UCToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.安卓UCToolStripMenuItem.Tag = "Mozilla/5.0 (Linux; U; Android 4.0.3; zh-cn; M032 Build/IML74K) UC AppleWebKit/53" +
    "4.31 (KHTML, like Gecko) Mobile Safari/534.31";
            this.安卓UCToolStripMenuItem.Text = "Android UC";
            // 
            // 塞班ToolStripMenuItem
            // 
            this.塞班ToolStripMenuItem.Name = "塞班ToolStripMenuItem";
            this.塞班ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.塞班ToolStripMenuItem.Tag = "Nokia5320/04.13 (SymbianOS/9.3; U; Series60/3.2 Mozilla/5.0; Profile/MIDP-2.1 Con" +
    "figuration/CLDC-1.1 ) AppleWebKit/413 (KHTML, like Gecko) Safari/413";
            this.塞班ToolStripMenuItem.Text = "塞班(Symbian)";
            // 
            // iphoneSafriaToolStripMenuItem
            // 
            this.iphoneSafriaToolStripMenuItem.Name = "iphoneSafriaToolStripMenuItem";
            this.iphoneSafriaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.iphoneSafriaToolStripMenuItem.Tag = "Mozilla/5.0 (iPhone; CPU iPhone OS 5_1_1 like Mac OS X) AppleWebKit/534.46 (KHTML" +
    ", like Gecko) Version/5.1 Mobile/9B206 Safari/7534.48.3";
            this.iphoneSafriaToolStripMenuItem.Text = "iphone Safria";
            // 
            // ucHelper2
            // 
            this.ucHelper2.HelperKey = "UserAgent";
            this.ucHelper2.Location = new System.Drawing.Point(56, 28);
            this.ucHelper2.Name = "ucHelper2";
            this.ucHelper2.Size = new System.Drawing.Size(16, 16);
            this.ucHelper2.TabIndex = 1;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(6, 7);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(89, 12);
            this.linkLabel2.TabIndex = 0;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "浏览器登陆获取";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(3, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(81, 50);
            this.panel5.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "User-Agent：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cookies：";
            // 
            // gbStep1url3
            // 
            this.gbStep1url3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStep1url3.Controls.Add(this.label4);
            this.gbStep1url3.Controls.Add(this.nudUrlRepeatCount);
            this.gbStep1url3.Controls.Add(this.label3);
            this.gbStep1url3.Controls.Add(this.chkMultilevelURLTestOne);
            this.gbStep1url3.Controls.Add(this.chkCheckUrl);
            this.gbStep1url3.Controls.Add(this.ucHelper1);
            this.gbStep1url3.Location = new System.Drawing.Point(4, 3);
            this.gbStep1url3.Name = "gbStep1url3";
            this.gbStep1url3.Size = new System.Drawing.Size(755, 45);
            this.gbStep1url3.TabIndex = 1;
            this.gbStep1url3.TabStop = false;
            this.gbStep1url3.Text = "网址附加选项";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "（0为不上限）";
            // 
            // nudUrlRepeatCount
            // 
            this.nudUrlRepeatCount.Location = new System.Drawing.Point(248, 17);
            this.nudUrlRepeatCount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudUrlRepeatCount.Name = "nudUrlRepeatCount";
            this.nudUrlRepeatCount.Size = new System.Drawing.Size(58, 21);
            this.nudUrlRepeatCount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "允许网址重复次数：";
            // 
            // chkMultilevelURLTestOne
            // 
            this.chkMultilevelURLTestOne.AutoSize = true;
            this.chkMultilevelURLTestOne.Location = new System.Drawing.Point(400, 19);
            this.chkMultilevelURLTestOne.Name = "chkMultilevelURLTestOne";
            this.chkMultilevelURLTestOne.Size = new System.Drawing.Size(216, 16);
            this.chkMultilevelURLTestOne.TabIndex = 1;
            this.chkMultilevelURLTestOne.Text = "多级网址只测试第一条记录下级网址";
            this.chkMultilevelURLTestOne.UseVisualStyleBackColor = true;
            // 
            // chkCheckUrl
            // 
            this.chkCheckUrl.AutoSize = true;
            this.chkCheckUrl.Checked = true;
            this.chkCheckUrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckUrl.Location = new System.Drawing.Point(6, 20);
            this.chkCheckUrl.Name = "chkCheckUrl";
            this.chkCheckUrl.Size = new System.Drawing.Size(96, 16);
            this.chkCheckUrl.TabIndex = 1;
            this.chkCheckUrl.Text = "检测重复网址";
            this.chkCheckUrl.UseVisualStyleBackColor = true;
            // 
            // ucHelper1
            // 
            this.ucHelper1.HelperKey = "CheckUrl";
            this.ucHelper1.Location = new System.Drawing.Point(104, 16);
            this.ucHelper1.Name = "ucHelper1";
            this.ucHelper1.Size = new System.Drawing.Size(20, 22);
            this.ucHelper1.TabIndex = 0;
            // 
            // gbMultipleURLRule
            // 
            this.gbMultipleURLRule.Controls.Add(this.ucCloseButton1);
            this.gbMultipleURLRule.Controls.Add(this.tbMultipleURL);
            this.gbMultipleURLRule.Controls.Add(this.panel7);
            this.gbMultipleURLRule.Location = new System.Drawing.Point(6, 5);
            this.gbMultipleURLRule.Name = "gbMultipleURLRule";
            this.gbMultipleURLRule.Size = new System.Drawing.Size(759, 313);
            this.gbMultipleURLRule.TabIndex = 2;
            this.gbMultipleURLRule.TabStop = false;
            this.gbMultipleURLRule.Text = "多级网址采集规则";
            this.gbMultipleURLRule.Visible = false;
            // 
            // ucCloseButton1
            // 
            this.ucCloseButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCloseButton1.ClickImage = ((System.Drawing.Image)(resources.GetObject("ucCloseButton1.ClickImage")));
            this.ucCloseButton1.Enter = ((System.Drawing.Image)(resources.GetObject("ucCloseButton1.Enter")));
            this.ucCloseButton1.Image = ((System.Drawing.Image)(resources.GetObject("ucCloseButton1.Image")));
            this.ucCloseButton1.Location = new System.Drawing.Point(741, 13);
            this.ucCloseButton1.Name = "ucCloseButton1";
            this.ucCloseButton1.Normal = ((System.Drawing.Image)(resources.GetObject("ucCloseButton1.Normal")));
            this.ucCloseButton1.Size = new System.Drawing.Size(12, 12);
            this.ucCloseButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ucCloseButton1.TabIndex = 6;
            this.ucCloseButton1.TabStop = false;
            this.ucCloseButton1.Click += new System.EventHandler(this.ucCloseButton1_Click);
            // 
            // tbMultipleURL
            // 
            this.tbMultipleURL.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbMultipleURL.Controls.Add(this.tpUrlGetOption);
            this.tbMultipleURL.Controls.Add(this.tabPage6);
            this.tbMultipleURL.Controls.Add(this.tabPage7);
            this.tbMultipleURL.Controls.Add(this.tabPage8);
            this.tbMultipleURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMultipleURL.Location = new System.Drawing.Point(3, 17);
            this.tbMultipleURL.Name = "tbMultipleURL";
            this.tbMultipleURL.SelectedIndex = 0;
            this.tbMultipleURL.Size = new System.Drawing.Size(753, 261);
            this.tbMultipleURL.TabIndex = 0;
            // 
            // tpUrlGetOption
            // 
            this.tpUrlGetOption.Controls.Add(this.ucHelper4);
            this.tpUrlGetOption.Controls.Add(this.ucHelper3);
            this.tpUrlGetOption.Controls.Add(this.gbResultFilter);
            this.tpUrlGetOption.Controls.Add(this.gbMultipleURLRegion);
            this.tpUrlGetOption.Controls.Add(this.rbGetUrlForXpath);
            this.tpUrlGetOption.Controls.Add(this.rbGetUrlManualFillRule);
            this.tpUrlGetOption.Controls.Add(this.rbGetUrlAtuo);
            this.tpUrlGetOption.Controls.Add(this.pUrlManual);
            this.tpUrlGetOption.Controls.Add(this.pUrlXpath);
            this.tpUrlGetOption.Location = new System.Drawing.Point(4, 25);
            this.tpUrlGetOption.Name = "tpUrlGetOption";
            this.tpUrlGetOption.Padding = new System.Windows.Forms.Padding(3);
            this.tpUrlGetOption.Size = new System.Drawing.Size(745, 232);
            this.tpUrlGetOption.TabIndex = 0;
            this.tpUrlGetOption.Text = "网址获取选项";
            this.tpUrlGetOption.UseVisualStyleBackColor = true;
            // 
            // ucHelper4
            // 
            this.ucHelper4.HelperKey = "XpathUrl";
            this.ucHelper4.Location = new System.Drawing.Point(162, 77);
            this.ucHelper4.Name = "ucHelper4";
            this.ucHelper4.Size = new System.Drawing.Size(16, 16);
            this.ucHelper4.TabIndex = 4;
            // 
            // ucHelper3
            // 
            this.ucHelper3.HelperKey = "HandUrl";
            this.ucHelper3.Location = new System.Drawing.Point(157, 47);
            this.ucHelper3.Name = "ucHelper3";
            this.ucHelper3.Size = new System.Drawing.Size(16, 16);
            this.ucHelper3.TabIndex = 4;
            // 
            // gbResultFilter
            // 
            this.gbResultFilter.Controls.Add(this.ucLableText6);
            this.gbResultFilter.Controls.Add(this.ucLableText5);
            this.gbResultFilter.Controls.Add(this.ucLableText4);
            this.gbResultFilter.Controls.Add(this.ucLableText3);
            this.gbResultFilter.Controls.Add(this.rtbeUrlNotContain);
            this.gbResultFilter.Controls.Add(this.rtbeUrlContain);
            this.gbResultFilter.Controls.Add(this.label10);
            this.gbResultFilter.Controls.Add(this.label9);
            this.gbResultFilter.Location = new System.Drawing.Point(282, 114);
            this.gbResultFilter.Name = "gbResultFilter";
            this.gbResultFilter.Size = new System.Drawing.Size(457, 110);
            this.gbResultFilter.TabIndex = 2;
            this.gbResultFilter.TabStop = false;
            this.gbResultFilter.Text = "结果网址过滤";
            // 
            // ucLableText6
            // 
            this.ucLableText6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText6.AutoEllipsis = true;
            this.ucLableText6.AutoSize = true;
            this.ucLableText6.Location = new System.Drawing.Point(430, 75);
            this.ucLableText6.Name = "ucLableText6";
            this.ucLableText6.OperationControl = this.rtbeUrlNotContain;
            this.ucLableText6.OperationTextBox = null;
            this.ucLableText6.Size = new System.Drawing.Size(23, 12);
            this.ucLableText6.TabIndex = 2;
            this.ucLableText6.TabStop = true;
            this.ucLableText6.Text = "(*)";
            this.ucLableText6.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeUrlNotContain
            // 
            this.rtbeUrlNotContain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeUrlNotContain.Asterisk = true;
            this.rtbeUrlNotContain.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeUrlNotContain.LableList")));
            this.rtbeUrlNotContain.Location = new System.Drawing.Point(67, 68);
            this.rtbeUrlNotContain.Name = "rtbeUrlNotContain";
            this.rtbeUrlNotContain.Size = new System.Drawing.Size(348, 24);
            this.rtbeUrlNotContain.Split = true;
            this.rtbeUrlNotContain.TabIndex = 1;
            this.rtbeUrlNotContain.TextValue = "";
            this.rtbeUrlNotContain.WordWrap = false;
            // 
            // ucLableText5
            // 
            this.ucLableText5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText5.AutoEllipsis = true;
            this.ucLableText5.AutoSize = true;
            this.ucLableText5.Location = new System.Drawing.Point(417, 75);
            this.ucLableText5.Name = "ucLableText5";
            this.ucLableText5.OperationControl = this.rtbeUrlNotContain;
            this.ucLableText5.OperationTextBox = null;
            this.ucLableText5.Size = new System.Drawing.Size(11, 12);
            this.ucLableText5.TabIndex = 2;
            this.ucLableText5.TabStop = true;
            this.ucLableText5.Text = "|";
            this.ucLableText5.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Split;
            // 
            // ucLableText4
            // 
            this.ucLableText4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText4.AutoEllipsis = true;
            this.ucLableText4.AutoSize = true;
            this.ucLableText4.Location = new System.Drawing.Point(431, 33);
            this.ucLableText4.Name = "ucLableText4";
            this.ucLableText4.OperationControl = this.rtbeUrlContain;
            this.ucLableText4.OperationTextBox = null;
            this.ucLableText4.Size = new System.Drawing.Size(23, 12);
            this.ucLableText4.TabIndex = 2;
            this.ucLableText4.TabStop = true;
            this.ucLableText4.Text = "(*)";
            this.ucLableText4.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeUrlContain
            // 
            this.rtbeUrlContain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeUrlContain.Asterisk = true;
            this.rtbeUrlContain.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeUrlContain.LableList")));
            this.rtbeUrlContain.Location = new System.Drawing.Point(67, 28);
            this.rtbeUrlContain.Name = "rtbeUrlContain";
            this.rtbeUrlContain.Size = new System.Drawing.Size(348, 24);
            this.rtbeUrlContain.Split = true;
            this.rtbeUrlContain.TabIndex = 1;
            this.rtbeUrlContain.TextValue = "";
            this.rtbeUrlContain.WordWrap = false;
            // 
            // ucLableText3
            // 
            this.ucLableText3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText3.AutoEllipsis = true;
            this.ucLableText3.AutoSize = true;
            this.ucLableText3.Location = new System.Drawing.Point(418, 33);
            this.ucLableText3.Name = "ucLableText3";
            this.ucLableText3.OperationControl = this.rtbeUrlContain;
            this.ucLableText3.OperationTextBox = null;
            this.ucLableText3.Size = new System.Drawing.Size(11, 12);
            this.ucLableText3.TabIndex = 2;
            this.ucLableText3.TabStop = true;
            this.ucLableText3.Text = "|";
            this.ucLableText3.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Split;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "不得包含：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "必须包含：";
            // 
            // gbMultipleURLRegion
            // 
            this.gbMultipleURLRegion.Controls.Add(this.ucLableText2);
            this.gbMultipleURLRegion.Controls.Add(this.ucLableText1);
            this.gbMultipleURLRegion.Controls.Add(this.rtbeUrlEnd);
            this.gbMultipleURLRegion.Controls.Add(this.rtbeUrlStart);
            this.gbMultipleURLRegion.Controls.Add(this.label8);
            this.gbMultipleURLRegion.Controls.Add(this.label7);
            this.gbMultipleURLRegion.Location = new System.Drawing.Point(14, 113);
            this.gbMultipleURLRegion.Name = "gbMultipleURLRegion";
            this.gbMultipleURLRegion.Size = new System.Drawing.Size(262, 111);
            this.gbMultipleURLRegion.TabIndex = 1;
            this.gbMultipleURLRegion.TabStop = false;
            this.gbMultipleURLRegion.Text = "从该选定区域中提取网址";
            // 
            // ucLableText2
            // 
            this.ucLableText2.AutoSize = true;
            this.ucLableText2.Location = new System.Drawing.Point(2, 80);
            this.ucLableText2.Name = "ucLableText2";
            this.ucLableText2.OperationControl = this.rtbeUrlEnd;
            this.ucLableText2.OperationTextBox = null;
            this.ucLableText2.Size = new System.Drawing.Size(23, 12);
            this.ucLableText2.TabIndex = 3;
            this.ucLableText2.TabStop = true;
            this.ucLableText2.Text = "(*)";
            this.ucLableText2.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeUrlEnd
            // 
            this.rtbeUrlEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeUrlEnd.Asterisk = true;
            this.rtbeUrlEnd.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeUrlEnd.LableList")));
            this.rtbeUrlEnd.Location = new System.Drawing.Point(29, 63);
            this.rtbeUrlEnd.Name = "rtbeUrlEnd";
            this.rtbeUrlEnd.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeUrlEnd.Size = new System.Drawing.Size(227, 40);
            this.rtbeUrlEnd.TabIndex = 2;
            this.rtbeUrlEnd.TextValue = "";
            this.rtbeUrlEnd.WordWrap = true;
            // 
            // ucLableText1
            // 
            this.ucLableText1.AutoSize = true;
            this.ucLableText1.Location = new System.Drawing.Point(3, 37);
            this.ucLableText1.Name = "ucLableText1";
            this.ucLableText1.OperationControl = this.rtbeUrlStart;
            this.ucLableText1.OperationTextBox = null;
            this.ucLableText1.Size = new System.Drawing.Size(23, 12);
            this.ucLableText1.TabIndex = 3;
            this.ucLableText1.TabStop = true;
            this.ucLableText1.Text = "(*)";
            this.ucLableText1.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeUrlStart
            // 
            this.rtbeUrlStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeUrlStart.Asterisk = true;
            this.rtbeUrlStart.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeUrlStart.LableList")));
            this.rtbeUrlStart.Location = new System.Drawing.Point(29, 17);
            this.rtbeUrlStart.Name = "rtbeUrlStart";
            this.rtbeUrlStart.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeUrlStart.Size = new System.Drawing.Size(227, 40);
            this.rtbeUrlStart.TabIndex = 2;
            this.rtbeUrlStart.TextValue = "";
            this.rtbeUrlStart.WordWrap = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "到";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "从";
            // 
            // rbGetUrlForXpath
            // 
            this.rbGetUrlForXpath.AutoSize = true;
            this.rbGetUrlForXpath.Location = new System.Drawing.Point(14, 76);
            this.rbGetUrlForXpath.Name = "rbGetUrlForXpath";
            this.rbGetUrlForXpath.Size = new System.Drawing.Size(149, 16);
            this.rbGetUrlForXpath.TabIndex = 0;
            this.rbGetUrlForXpath.Text = "使用Xpath方式获取地址";
            this.rbGetUrlForXpath.UseVisualStyleBackColor = true;
            this.rbGetUrlForXpath.CheckedChanged += new System.EventHandler(this.rbGetUrlAtuo_CheckedChanged);
            // 
            // rbGetUrlManualFillRule
            // 
            this.rbGetUrlManualFillRule.AutoSize = true;
            this.rbGetUrlManualFillRule.Location = new System.Drawing.Point(14, 47);
            this.rbGetUrlManualFillRule.Name = "rbGetUrlManualFillRule";
            this.rbGetUrlManualFillRule.Size = new System.Drawing.Size(143, 16);
            this.rbGetUrlManualFillRule.TabIndex = 0;
            this.rbGetUrlManualFillRule.Text = "手动填写链接地址规则";
            this.rbGetUrlManualFillRule.UseVisualStyleBackColor = true;
            this.rbGetUrlManualFillRule.CheckedChanged += new System.EventHandler(this.rbGetUrlAtuo_CheckedChanged);
            // 
            // rbGetUrlAtuo
            // 
            this.rbGetUrlAtuo.AutoSize = true;
            this.rbGetUrlAtuo.Checked = true;
            this.rbGetUrlAtuo.Location = new System.Drawing.Point(14, 18);
            this.rbGetUrlAtuo.Name = "rbGetUrlAtuo";
            this.rbGetUrlAtuo.Size = new System.Drawing.Size(179, 16);
            this.rbGetUrlAtuo.TabIndex = 0;
            this.rbGetUrlAtuo.TabStop = true;
            this.rbGetUrlAtuo.Text = "从页面自动分析得到地址链接";
            this.rbGetUrlAtuo.UseVisualStyleBackColor = true;
            this.rbGetUrlAtuo.CheckedChanged += new System.EventHandler(this.rbGetUrlAtuo_CheckedChanged);
            // 
            // pUrlManual
            // 
            this.pUrlManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pUrlManual.Controls.Add(this.rtbxUrlResult);
            this.pUrlManual.Controls.Add(this.ucLableText9);
            this.pUrlManual.Controls.Add(this.ucLableText11);
            this.pUrlManual.Controls.Add(this.ucLableText8);
            this.pUrlManual.Controls.Add(this.ucLableText10);
            this.pUrlManual.Controls.Add(this.ucLableText7);
            this.pUrlManual.Controls.Add(this.rtbeUrlScriptRule);
            this.pUrlManual.Controls.Add(this.label12);
            this.pUrlManual.Controls.Add(this.label11);
            this.pUrlManual.Location = new System.Drawing.Point(199, 10);
            this.pUrlManual.Name = "pUrlManual";
            this.pUrlManual.Size = new System.Drawing.Size(543, 100);
            this.pUrlManual.TabIndex = 5;
            this.pUrlManual.Visible = false;
            // 
            // rtbxUrlResult
            // 
            this.rtbxUrlResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbxUrlResult.Label = true;
            this.rtbxUrlResult.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbxUrlResult.LableList")));
            this.rtbxUrlResult.Location = new System.Drawing.Point(63, 73);
            this.rtbxUrlResult.Name = "rtbxUrlResult";
            this.rtbxUrlResult.ParameterN = true;
            this.rtbxUrlResult.Size = new System.Drawing.Size(369, 23);
            this.rtbxUrlResult.TabIndex = 3;
            this.rtbxUrlResult.TextValue = "";
            this.rtbxUrlResult.WordWrap = false;
            // 
            // ucLableText9
            // 
            this.ucLableText9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText9.AutoSize = true;
            this.ucLableText9.Location = new System.Drawing.Point(479, 16);
            this.ucLableText9.Name = "ucLableText9";
            this.ucLableText9.OperationControl = this.rtbeUrlScriptRule;
            this.ucLableText9.OperationTextBox = null;
            this.ucLableText9.Size = new System.Drawing.Size(23, 12);
            this.ucLableText9.TabIndex = 2;
            this.ucLableText9.TabStop = true;
            this.ucLableText9.Text = "(*)";
            this.ucLableText9.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeUrlScriptRule
            // 
            this.rtbeUrlScriptRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeUrlScriptRule.Asterisk = true;
            this.rtbeUrlScriptRule.Label = true;
            this.rtbeUrlScriptRule.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeUrlScriptRule.LableList")));
            this.rtbeUrlScriptRule.Location = new System.Drawing.Point(63, 5);
            this.rtbeUrlScriptRule.Name = "rtbeUrlScriptRule";
            this.rtbeUrlScriptRule.Parameter = true;
            this.rtbeUrlScriptRule.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeUrlScriptRule.Size = new System.Drawing.Size(369, 61);
            this.rtbeUrlScriptRule.TabIndex = 1;
            this.rtbeUrlScriptRule.TextValue = "";
            this.rtbeUrlScriptRule.WordWrap = true;
            // 
            // ucLableText11
            // 
            this.ucLableText11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText11.AutoSize = true;
            this.ucLableText11.Location = new System.Drawing.Point(476, 79);
            this.ucLableText11.Name = "ucLableText11";
            this.ucLableText11.OperationControl = this.rtbxUrlResult;
            this.ucLableText11.OperationTextBox = null;
            this.ucLableText11.Size = new System.Drawing.Size(65, 12);
            this.ucLableText11.TabIndex = 2;
            this.ucLableText11.TabStop = true;
            this.ucLableText11.Text = "[标签:XXX]";
            this.ucLableText11.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Lable;
            // 
            // ucLableText8
            // 
            this.ucLableText8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText8.AutoSize = true;
            this.ucLableText8.Location = new System.Drawing.Point(438, 41);
            this.ucLableText8.Name = "ucLableText8";
            this.ucLableText8.OperationControl = this.rtbeUrlScriptRule;
            this.ucLableText8.OperationTextBox = null;
            this.ucLableText8.Size = new System.Drawing.Size(65, 12);
            this.ucLableText8.TabIndex = 2;
            this.ucLableText8.TabStop = true;
            this.ucLableText8.Text = "[标签:XXX]";
            this.ucLableText8.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Lable;
            // 
            // ucLableText10
            // 
            this.ucLableText10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText10.AutoSize = true;
            this.ucLableText10.Location = new System.Drawing.Point(432, 79);
            this.ucLableText10.Name = "ucLableText10";
            this.ucLableText10.OperationControl = this.rtbxUrlResult;
            this.ucLableText10.OperationTextBox = null;
            this.ucLableText10.Size = new System.Drawing.Size(47, 12);
            this.ucLableText10.TabIndex = 2;
            this.ucLableText10.TabStop = true;
            this.ucLableText10.Text = "[参数N]";
            this.ucLableText10.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.ParameterN;
            // 
            // ucLableText7
            // 
            this.ucLableText7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText7.AutoSize = true;
            this.ucLableText7.Location = new System.Drawing.Point(438, 16);
            this.ucLableText7.Name = "ucLableText7";
            this.ucLableText7.OperationControl = this.rtbeUrlScriptRule;
            this.ucLableText7.OperationTextBox = null;
            this.ucLableText7.Size = new System.Drawing.Size(41, 12);
            this.ucLableText7.TabIndex = 2;
            this.ucLableText7.TabStop = true;
            this.ucLableText7.Text = "[参数]";
            this.ucLableText7.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Parameter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "实际链接：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "脚本规则：";
            // 
            // pUrlXpath
            // 
            this.pUrlXpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pUrlXpath.Controls.Add(this.btnGetXpath);
            this.pUrlXpath.Controls.Add(this.txtUrlXpath);
            this.pUrlXpath.Controls.Add(this.label13);
            this.pUrlXpath.Location = new System.Drawing.Point(198, 10);
            this.pUrlXpath.Name = "pUrlXpath";
            this.pUrlXpath.Size = new System.Drawing.Size(536, 100);
            this.pUrlXpath.TabIndex = 4;
            this.pUrlXpath.Visible = false;
            // 
            // btnGetXpath
            // 
            this.btnGetXpath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetXpath.Location = new System.Drawing.Point(391, 7);
            this.btnGetXpath.Name = "btnGetXpath";
            this.btnGetXpath.Size = new System.Drawing.Size(128, 31);
            this.btnGetXpath.TabIndex = 2;
            this.btnGetXpath.Text = "使用Xpath浏览器获取";
            this.btnGetXpath.UseVisualStyleBackColor = true;
            this.btnGetXpath.Click += new System.EventHandler(this.btnGetXpath_Click);
            // 
            // txtUrlXpath
            // 
            this.txtUrlXpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrlXpath.Location = new System.Drawing.Point(16, 41);
            this.txtUrlXpath.Multiline = true;
            this.txtUrlXpath.Name = "txtUrlXpath";
            this.txtUrlXpath.Size = new System.Drawing.Size(503, 49);
            this.txtUrlXpath.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "Xpath表达式：";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.gbPostOption);
            this.tabPage6.Controls.Add(this.label14);
            this.tabPage6.Controls.Add(this.rbAspXPost);
            this.tabPage6.Controls.Add(this.rbPost);
            this.tabPage6.Controls.Add(this.rbGet);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(745, 232);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "HTTP请求方式";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // gbPostOption
            // 
            this.gbPostOption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPostOption.Controls.Add(this.pRandValue);
            this.gbPostOption.Controls.Add(this.btnPostValueDelete);
            this.gbPostOption.Controls.Add(this.btnPostValueEdit);
            this.gbPostOption.Controls.Add(this.btnPostValueAdd);
            this.gbPostOption.Controls.Add(this.lvPost);
            this.gbPostOption.Controls.Add(this.ultPagination);
            this.gbPostOption.Controls.Add(this.ultPostRandValue);
            this.gbPostOption.Controls.Add(this.rtbePostData);
            this.gbPostOption.Controls.Add(this.label17);
            this.gbPostOption.Controls.Add(this.nudPostEnd);
            this.gbPostOption.Controls.Add(this.nudPostStart);
            this.gbPostOption.Controls.Add(this.label16);
            this.gbPostOption.Controls.Add(this.label15);
            this.gbPostOption.Location = new System.Drawing.Point(61, 15);
            this.gbPostOption.Name = "gbPostOption";
            this.gbPostOption.Size = new System.Drawing.Size(678, 215);
            this.gbPostOption.TabIndex = 2;
            this.gbPostOption.TabStop = false;
            this.gbPostOption.Text = "POST方式配置";
            this.gbPostOption.Visible = false;
            // 
            // pRandValue
            // 
            this.pRandValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pRandValue.Controls.Add(this.btnCancelRandValue);
            this.pRandValue.Controls.Add(this.btnSaveRandValue);
            this.pRandValue.Controls.Add(this.ucLableText21);
            this.pRandValue.Controls.Add(this.ucLableText20);
            this.pRandValue.Controls.Add(this.ucCloseButton2);
            this.pRandValue.Controls.Add(this.rtbeRandValueEnd);
            this.pRandValue.Controls.Add(this.label26);
            this.pRandValue.Controls.Add(this.rtbeRandValueStart);
            this.pRandValue.Controls.Add(this.label25);
            this.pRandValue.Location = new System.Drawing.Point(389, 15);
            this.pRandValue.Name = "pRandValue";
            this.pRandValue.Size = new System.Drawing.Size(283, 194);
            this.pRandValue.TabIndex = 12;
            this.pRandValue.Visible = false;
            // 
            // btnCancelRandValue
            // 
            this.btnCancelRandValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelRandValue.Location = new System.Drawing.Point(219, 169);
            this.btnCancelRandValue.Name = "btnCancelRandValue";
            this.btnCancelRandValue.Size = new System.Drawing.Size(54, 21);
            this.btnCancelRandValue.TabIndex = 4;
            this.btnCancelRandValue.Text = "返回";
            this.btnCancelRandValue.UseVisualStyleBackColor = true;
            this.btnCancelRandValue.Click += new System.EventHandler(this.btnCancelRandValue_Click);
            // 
            // btnSaveRandValue
            // 
            this.btnSaveRandValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRandValue.Location = new System.Drawing.Point(158, 169);
            this.btnSaveRandValue.Name = "btnSaveRandValue";
            this.btnSaveRandValue.Size = new System.Drawing.Size(54, 21);
            this.btnSaveRandValue.TabIndex = 4;
            this.btnSaveRandValue.Text = "保存";
            this.btnSaveRandValue.UseVisualStyleBackColor = true;
            this.btnSaveRandValue.Click += new System.EventHandler(this.btnSaveRandValue_Click);
            // 
            // ucLableText21
            // 
            this.ucLableText21.AutoSize = true;
            this.ucLableText21.Location = new System.Drawing.Point(24, 138);
            this.ucLableText21.Name = "ucLableText21";
            this.ucLableText21.OperationControl = this.rtbeRandValueEnd;
            this.ucLableText21.OperationTextBox = null;
            this.ucLableText21.Size = new System.Drawing.Size(23, 12);
            this.ucLableText21.TabIndex = 3;
            this.ucLableText21.TabStop = true;
            this.ucLableText21.Text = "(*)";
            this.ucLableText21.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeRandValueEnd
            // 
            this.rtbeRandValueEnd.Asterisk = true;
            this.rtbeRandValueEnd.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeRandValueEnd.LableList")));
            this.rtbeRandValueEnd.Location = new System.Drawing.Point(63, 94);
            this.rtbeRandValueEnd.Name = "rtbeRandValueEnd";
            this.rtbeRandValueEnd.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeRandValueEnd.Size = new System.Drawing.Size(210, 71);
            this.rtbeRandValueEnd.TabIndex = 1;
            this.rtbeRandValueEnd.TextValue = "";
            this.rtbeRandValueEnd.WordWrap = true;
            // 
            // ucLableText20
            // 
            this.ucLableText20.AutoSize = true;
            this.ucLableText20.Location = new System.Drawing.Point(24, 66);
            this.ucLableText20.Name = "ucLableText20";
            this.ucLableText20.OperationControl = this.rtbeRandValueStart;
            this.ucLableText20.OperationTextBox = null;
            this.ucLableText20.Size = new System.Drawing.Size(23, 12);
            this.ucLableText20.TabIndex = 3;
            this.ucLableText20.TabStop = true;
            this.ucLableText20.Text = "(*)";
            this.ucLableText20.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeRandValueStart
            // 
            this.rtbeRandValueStart.Asterisk = true;
            this.rtbeRandValueStart.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeRandValueStart.LableList")));
            this.rtbeRandValueStart.Location = new System.Drawing.Point(63, 18);
            this.rtbeRandValueStart.Name = "rtbeRandValueStart";
            this.rtbeRandValueStart.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeRandValueStart.Size = new System.Drawing.Size(210, 71);
            this.rtbeRandValueStart.TabIndex = 1;
            this.rtbeRandValueStart.TextValue = "";
            this.rtbeRandValueStart.WordWrap = true;
            // 
            // ucCloseButton2
            // 
            this.ucCloseButton2.ClickImage = ((System.Drawing.Image)(resources.GetObject("ucCloseButton2.ClickImage")));
            this.ucCloseButton2.Enter = ((System.Drawing.Image)(resources.GetObject("ucCloseButton2.Enter")));
            this.ucCloseButton2.Image = ((System.Drawing.Image)(resources.GetObject("ucCloseButton2.Image")));
            this.ucCloseButton2.Location = new System.Drawing.Point(268, 4);
            this.ucCloseButton2.Name = "ucCloseButton2";
            this.ucCloseButton2.Normal = ((System.Drawing.Image)(resources.GetObject("ucCloseButton2.Normal")));
            this.ucCloseButton2.Size = new System.Drawing.Size(12, 12);
            this.ucCloseButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ucCloseButton2.TabIndex = 2;
            this.ucCloseButton2.TabStop = false;
            this.ucCloseButton2.Click += new System.EventHandler(this.ucCloseButton2_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 98);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 24);
            this.label26.TabIndex = 0;
            this.label26.Text = "随机值后\r\n 字符串";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 24);
            this.label25.TabIndex = 0;
            this.label25.Text = "随机值前\r\n 字符串";
            // 
            // btnPostValueDelete
            // 
            this.btnPostValueDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPostValueDelete.Enabled = false;
            this.btnPostValueDelete.Location = new System.Drawing.Point(625, 73);
            this.btnPostValueDelete.Name = "btnPostValueDelete";
            this.btnPostValueDelete.Size = new System.Drawing.Size(48, 23);
            this.btnPostValueDelete.TabIndex = 11;
            this.btnPostValueDelete.Text = "删除";
            this.btnPostValueDelete.UseVisualStyleBackColor = true;
            this.btnPostValueDelete.Click += new System.EventHandler(this.btnPostValueDelete_Click);
            // 
            // btnPostValueEdit
            // 
            this.btnPostValueEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPostValueEdit.Enabled = false;
            this.btnPostValueEdit.Location = new System.Drawing.Point(625, 44);
            this.btnPostValueEdit.Name = "btnPostValueEdit";
            this.btnPostValueEdit.Size = new System.Drawing.Size(48, 23);
            this.btnPostValueEdit.TabIndex = 10;
            this.btnPostValueEdit.Text = "编辑";
            this.btnPostValueEdit.UseVisualStyleBackColor = true;
            this.btnPostValueEdit.Click += new System.EventHandler(this.btnPostValueEdit_Click);
            // 
            // btnPostValueAdd
            // 
            this.btnPostValueAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPostValueAdd.Location = new System.Drawing.Point(625, 16);
            this.btnPostValueAdd.Name = "btnPostValueAdd";
            this.btnPostValueAdd.Size = new System.Drawing.Size(48, 23);
            this.btnPostValueAdd.TabIndex = 9;
            this.btnPostValueAdd.Text = "添加";
            this.btnPostValueAdd.UseVisualStyleBackColor = true;
            this.btnPostValueAdd.Click += new System.EventHandler(this.btnPostValueAdd_Click);
            // 
            // lvPost
            // 
            this.lvPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPost.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvPost.FullRowSelect = true;
            this.lvPost.GridLines = true;
            this.lvPost.Location = new System.Drawing.Point(389, 17);
            this.lvPost.Name = "lvPost";
            this.lvPost.Size = new System.Drawing.Size(231, 185);
            this.lvPost.TabIndex = 8;
            this.lvPost.UseCompatibleStateImageBehavior = false;
            this.lvPost.View = System.Windows.Forms.View.Details;
            this.lvPost.SelectedIndexChanged += new System.EventHandler(this.lvPost_SelectedIndexChanged);
            this.lvPost.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPost_MouseDoubleClick);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "调用标签名";
            this.columnHeader8.Width = 85;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "前字符串";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "后字符串";
            this.columnHeader10.Width = 70;
            // 
            // ultPagination
            // 
            this.ultPagination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ultPagination.AutoSize = true;
            this.ultPagination.Location = new System.Drawing.Point(344, 190);
            this.ultPagination.Name = "ultPagination";
            this.ultPagination.OperationControl = this.rtbePostData;
            this.ultPagination.OperationTextBox = null;
            this.ultPagination.Size = new System.Drawing.Size(41, 12);
            this.ultPagination.TabIndex = 7;
            this.ultPagination.TabStop = true;
            this.ultPagination.Text = "[分页]";
            this.ultPagination.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Pagination;
            // 
            // rtbePostData
            // 
            this.rtbePostData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbePostData.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbePostData.LableList")));
            this.rtbePostData.Location = new System.Drawing.Point(6, 32);
            this.rtbePostData.Name = "rtbePostData";
            this.rtbePostData.Pagination = true;
            this.rtbePostData.PostRandValue = true;
            this.rtbePostData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbePostData.Size = new System.Drawing.Size(379, 147);
            this.rtbePostData.TabIndex = 5;
            this.rtbePostData.TextValue = "";
            this.rtbePostData.WordWrap = true;
            // 
            // ultPostRandValue
            // 
            this.ultPostRandValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ultPostRandValue.AutoSize = true;
            this.ultPostRandValue.Location = new System.Drawing.Point(255, 190);
            this.ultPostRandValue.Name = "ultPostRandValue";
            this.ultPostRandValue.OperationControl = this.rtbePostData;
            this.ultPostRandValue.OperationTextBox = null;
            this.ultPostRandValue.Size = new System.Drawing.Size(83, 12);
            this.ultPostRandValue.TabIndex = 6;
            this.ultPostRandValue.TabStop = true;
            this.ultPostRandValue.Text = "[POST随机值X]";
            this.ultPostRandValue.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.PostRandValue;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(152, 190);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 4;
            this.label17.Text = "到";
            // 
            // nudPostEnd
            // 
            this.nudPostEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPostEnd.Location = new System.Drawing.Point(175, 185);
            this.nudPostEnd.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudPostEnd.Name = "nudPostEnd";
            this.nudPostEnd.Size = new System.Drawing.Size(64, 21);
            this.nudPostEnd.TabIndex = 3;
            this.nudPostEnd.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudPostStart
            // 
            this.nudPostStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPostStart.Location = new System.Drawing.Point(77, 185);
            this.nudPostStart.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudPostStart.Name = "nudPostStart";
            this.nudPostStart.Size = new System.Drawing.Size(69, 21);
            this.nudPostStart.TabIndex = 3;
            this.nudPostStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1, 188);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "[分页]标签从";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "发送的数据：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(81, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "使用Get请求方式无需其他设置";
            // 
            // rbAspXPost
            // 
            this.rbAspXPost.AutoSize = true;
            this.rbAspXPost.Location = new System.Drawing.Point(14, 163);
            this.rbAspXPost.Name = "rbAspXPost";
            this.rbAspXPost.Size = new System.Drawing.Size(47, 28);
            this.rbAspXPost.TabIndex = 0;
            this.rbAspXPost.Text = "AspX\r\nPost";
            this.rbAspXPost.UseVisualStyleBackColor = true;
            // 
            // rbPost
            // 
            this.rbPost.AutoSize = true;
            this.rbPost.Location = new System.Drawing.Point(14, 100);
            this.rbPost.Name = "rbPost";
            this.rbPost.Size = new System.Drawing.Size(47, 16);
            this.rbPost.TabIndex = 0;
            this.rbPost.Text = "Post";
            this.rbPost.UseVisualStyleBackColor = true;
            this.rbPost.CheckedChanged += new System.EventHandler(this.rbPost_CheckedChanged);
            // 
            // rbGet
            // 
            this.rbGet.AutoSize = true;
            this.rbGet.Checked = true;
            this.rbGet.Location = new System.Drawing.Point(14, 40);
            this.rbGet.Name = "rbGet";
            this.rbGet.Size = new System.Drawing.Size(41, 16);
            this.rbGet.TabIndex = 0;
            this.rbGet.TabStop = true;
            this.rbGet.Text = "Get";
            this.rbGet.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.gbCombination);
            this.tabPage7.Controls.Add(this.chkAutoGetPage);
            this.tabPage7.Controls.Add(this.nudPagesMax);
            this.tabPage7.Controls.Add(this.label20);
            this.tabPage7.Controls.Add(this.gbPageGet);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(745, 232);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "列表分页获取";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // gbCombination
            // 
            this.gbCombination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCombination.Controls.Add(this.ucHelper5);
            this.gbCombination.Controls.Add(this.rtbeListPageStyle);
            this.gbCombination.Controls.Add(this.ucLableText14);
            this.gbCombination.Controls.Add(this.ucLableText15);
            this.gbCombination.Controls.Add(this.ucLableText17);
            this.gbCombination.Controls.Add(this.ucLableText18);
            this.gbCombination.Controls.Add(this.rtbeListPageUrlStyle);
            this.gbCombination.Controls.Add(this.label22);
            this.gbCombination.Controls.Add(this.label21);
            this.gbCombination.Location = new System.Drawing.Point(381, 18);
            this.gbCombination.Name = "gbCombination";
            this.gbCombination.Size = new System.Drawing.Size(359, 210);
            this.gbCombination.TabIndex = 6;
            this.gbCombination.TabStop = false;
            this.gbCombination.Text = "组合生成列表页分页";
            // 
            // ucHelper5
            // 
            this.ucHelper5.HelperKey = "ListPages";
            this.ucHelper5.Location = new System.Drawing.Point(16, 90);
            this.ucHelper5.Name = "ucHelper5";
            this.ucHelper5.Size = new System.Drawing.Size(16, 16);
            this.ucHelper5.TabIndex = 11;
            // 
            // rtbeListPageStyle
            // 
            this.rtbeListPageStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeListPageStyle.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeListPageStyle.LableList")));
            this.rtbeListPageStyle.Location = new System.Drawing.Point(61, 181);
            this.rtbeListPageStyle.Name = "rtbeListPageStyle";
            this.rtbeListPageStyle.ParameterN = true;
            this.rtbeListPageStyle.Size = new System.Drawing.Size(204, 23);
            this.rtbeListPageStyle.TabIndex = 10;
            this.rtbeListPageStyle.TextValue = "";
            this.rtbeListPageStyle.WordWrap = false;
            // 
            // ucLableText14
            // 
            this.ucLableText14.AutoSize = true;
            this.ucLableText14.Location = new System.Drawing.Point(14, 40);
            this.ucLableText14.Name = "ucLableText14";
            this.ucLableText14.OperationControl = this.rtbeListPageUrlStyle;
            this.ucLableText14.OperationTextBox = null;
            this.ucLableText14.Size = new System.Drawing.Size(23, 12);
            this.ucLableText14.TabIndex = 5;
            this.ucLableText14.TabStop = true;
            this.ucLableText14.Text = "(*)";
            this.ucLableText14.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeListPageUrlStyle
            // 
            this.rtbeListPageUrlStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeListPageUrlStyle.Asterisk = true;
            this.rtbeListPageUrlStyle.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeListPageUrlStyle.LableList")));
            this.rtbeListPageUrlStyle.Location = new System.Drawing.Point(61, 17);
            this.rtbeListPageUrlStyle.Name = "rtbeListPageUrlStyle";
            this.rtbeListPageUrlStyle.Parameter = true;
            this.rtbeListPageUrlStyle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeListPageUrlStyle.Size = new System.Drawing.Size(292, 158);
            this.rtbeListPageUrlStyle.TabIndex = 4;
            this.rtbeListPageUrlStyle.TextValue = "";
            this.rtbeListPageUrlStyle.WordWrap = true;
            // 
            // ucLableText15
            // 
            this.ucLableText15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText15.AutoSize = true;
            this.ucLableText15.Location = new System.Drawing.Point(268, 187);
            this.ucLableText15.Name = "ucLableText15";
            this.ucLableText15.OperationControl = this.rtbeListPageStyle;
            this.ucLableText15.OperationTextBox = null;
            this.ucLableText15.Size = new System.Drawing.Size(47, 12);
            this.ucLableText15.TabIndex = 6;
            this.ucLableText15.TabStop = true;
            this.ucLableText15.Text = "[参数1]";
            this.ucLableText15.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Parameter1;
            // 
            // ucLableText17
            // 
            this.ucLableText17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLableText17.AutoSize = true;
            this.ucLableText17.Location = new System.Drawing.Point(312, 187);
            this.ucLableText17.Name = "ucLableText17";
            this.ucLableText17.OperationControl = this.rtbeListPageStyle;
            this.ucLableText17.OperationTextBox = null;
            this.ucLableText17.Size = new System.Drawing.Size(47, 12);
            this.ucLableText17.TabIndex = 8;
            this.ucLableText17.TabStop = true;
            this.ucLableText17.Text = "[参数N]";
            this.ucLableText17.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.ParameterN;
            // 
            // ucLableText18
            // 
            this.ucLableText18.AutoSize = true;
            this.ucLableText18.Location = new System.Drawing.Point(8, 64);
            this.ucLableText18.Name = "ucLableText18";
            this.ucLableText18.OperationControl = this.rtbeListPageUrlStyle;
            this.ucLableText18.OperationTextBox = null;
            this.ucLableText18.Size = new System.Drawing.Size(41, 12);
            this.ucLableText18.TabIndex = 9;
            this.ucLableText18.TabStop = true;
            this.ucLableText18.Text = "[参数]";
            this.ucLableText18.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Parameter;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 187);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 0;
            this.label22.Text = "分页样式：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "地址样式：";
            // 
            // chkAutoGetPage
            // 
            this.chkAutoGetPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAutoGetPage.AutoSize = true;
            this.chkAutoGetPage.Checked = true;
            this.chkAutoGetPage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoGetPage.Location = new System.Drawing.Point(282, 210);
            this.chkAutoGetPage.Name = "chkAutoGetPage";
            this.chkAutoGetPage.Size = new System.Drawing.Size(96, 16);
            this.chkAutoGetPage.TabIndex = 5;
            this.chkAutoGetPage.Text = "自动识别分页";
            this.chkAutoGetPage.UseVisualStyleBackColor = true;
            // 
            // nudPagesMax
            // 
            this.nudPagesMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudPagesMax.Location = new System.Drawing.Point(160, 208);
            this.nudPagesMax.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudPagesMax.Name = "nudPagesMax";
            this.nudPagesMax.Size = new System.Drawing.Size(68, 21);
            this.nudPagesMax.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 212);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(143, 12);
            this.label20.TabIndex = 3;
            this.label20.Text = "最多获取分页数，0为不限";
            // 
            // gbPageGet
            // 
            this.gbPageGet.Controls.Add(this.ucLableText12);
            this.gbPageGet.Controls.Add(this.ucLableText13);
            this.gbPageGet.Controls.Add(this.rtbeListPageEnd);
            this.gbPageGet.Controls.Add(this.rtbeListPageStart);
            this.gbPageGet.Controls.Add(this.label18);
            this.gbPageGet.Controls.Add(this.label19);
            this.gbPageGet.Location = new System.Drawing.Point(14, 18);
            this.gbPageGet.Name = "gbPageGet";
            this.gbPageGet.Size = new System.Drawing.Size(361, 186);
            this.gbPageGet.TabIndex = 2;
            this.gbPageGet.TabStop = false;
            this.gbPageGet.Text = "从该区域中提取列表分页网址(不指定不获取分页)";
            // 
            // ucLableText12
            // 
            this.ucLableText12.AutoSize = true;
            this.ucLableText12.Location = new System.Drawing.Point(3, 114);
            this.ucLableText12.Name = "ucLableText12";
            this.ucLableText12.OperationControl = this.rtbeListPageEnd;
            this.ucLableText12.OperationTextBox = null;
            this.ucLableText12.Size = new System.Drawing.Size(23, 12);
            this.ucLableText12.TabIndex = 3;
            this.ucLableText12.TabStop = true;
            this.ucLableText12.Text = "(*)";
            this.ucLableText12.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeListPageEnd
            // 
            this.rtbeListPageEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeListPageEnd.Asterisk = true;
            this.rtbeListPageEnd.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeListPageEnd.LableList")));
            this.rtbeListPageEnd.Location = new System.Drawing.Point(29, 96);
            this.rtbeListPageEnd.Name = "rtbeListPageEnd";
            this.rtbeListPageEnd.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeListPageEnd.Size = new System.Drawing.Size(323, 85);
            this.rtbeListPageEnd.TabIndex = 2;
            this.rtbeListPageEnd.TextValue = "";
            this.rtbeListPageEnd.WordWrap = true;
            // 
            // ucLableText13
            // 
            this.ucLableText13.AutoSize = true;
            this.ucLableText13.Location = new System.Drawing.Point(3, 37);
            this.ucLableText13.Name = "ucLableText13";
            this.ucLableText13.OperationControl = this.rtbeListPageStart;
            this.ucLableText13.OperationTextBox = null;
            this.ucLableText13.Size = new System.Drawing.Size(23, 12);
            this.ucLableText13.TabIndex = 3;
            this.ucLableText13.TabStop = true;
            this.ucLableText13.Text = "(*)";
            this.ucLableText13.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeListPageStart
            // 
            this.rtbeListPageStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeListPageStart.Asterisk = true;
            this.rtbeListPageStart.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeListPageStart.LableList")));
            this.rtbeListPageStart.Location = new System.Drawing.Point(29, 17);
            this.rtbeListPageStart.Name = "rtbeListPageStart";
            this.rtbeListPageStart.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeListPageStart.Size = new System.Drawing.Size(323, 73);
            this.rtbeListPageStart.TabIndex = 2;
            this.rtbeListPageStart.TextValue = "";
            this.rtbeListPageStart.WordWrap = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 1;
            this.label18.Text = "到";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "从";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.ucLableText19);
            this.tabPage8.Controls.Add(this.ucLableText16);
            this.tabPage8.Controls.Add(this.label24);
            this.tabPage8.Controls.Add(this.label23);
            this.tabPage8.Controls.Add(this.rtbeAdditionalparameter);
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(745, 232);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "附加参数";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // ucLableText19
            // 
            this.ucLableText19.AutoSize = true;
            this.ucLableText19.Location = new System.Drawing.Point(115, 24);
            this.ucLableText19.Name = "ucLableText19";
            this.ucLableText19.OperationControl = this.rtbeAdditionalparameter;
            this.ucLableText19.OperationTextBox = null;
            this.ucLableText19.Size = new System.Drawing.Size(23, 12);
            this.ucLableText19.TabIndex = 4;
            this.ucLableText19.TabStop = true;
            this.ucLableText19.Text = "(*)";
            this.ucLableText19.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // rtbeAdditionalparameter
            // 
            this.rtbeAdditionalparameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeAdditionalparameter.Asterisk = true;
            this.rtbeAdditionalparameter.Label = true;
            this.rtbeAdditionalparameter.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeAdditionalparameter.LableList")));
            this.rtbeAdditionalparameter.Location = new System.Drawing.Point(22, 44);
            this.rtbeAdditionalparameter.Name = "rtbeAdditionalparameter";
            this.rtbeAdditionalparameter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeAdditionalparameter.Size = new System.Drawing.Size(712, 180);
            this.rtbeAdditionalparameter.TabIndex = 1;
            this.rtbeAdditionalparameter.TextValue = "";
            this.rtbeAdditionalparameter.WordWrap = true;
            // 
            // ucLableText16
            // 
            this.ucLableText16.AutoSize = true;
            this.ucLableText16.Location = new System.Drawing.Point(144, 24);
            this.ucLableText16.Name = "ucLableText16";
            this.ucLableText16.OperationControl = this.rtbeAdditionalparameter;
            this.ucLableText16.OperationTextBox = null;
            this.ucLableText16.Size = new System.Drawing.Size(65, 12);
            this.ucLableText16.TabIndex = 3;
            this.ucLableText16.TabStop = true;
            this.ucLableText16.Text = "[标签:XXX]";
            this.ucLableText16.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Lable;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(351, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(383, 12);
            this.label24.TabIndex = 2;
            this.label24.Text = "*该页面可以获取单一数值，该值将循环的添加到符合条件的每条记录上";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "参数提取方式：";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnCancelUrlRule);
            this.panel7.Controls.Add(this.btnSaveUrlRule);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(3, 278);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(753, 32);
            this.panel7.TabIndex = 7;
            // 
            // btnCancelUrlRule
            // 
            this.btnCancelUrlRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelUrlRule.Location = new System.Drawing.Point(678, 5);
            this.btnCancelUrlRule.Name = "btnCancelUrlRule";
            this.btnCancelUrlRule.Size = new System.Drawing.Size(65, 25);
            this.btnCancelUrlRule.TabIndex = 3;
            this.btnCancelUrlRule.Text = "返回";
            this.btnCancelUrlRule.UseVisualStyleBackColor = true;
            this.btnCancelUrlRule.Click += new System.EventHandler(this.btnCancelUrlRule_Click);
            // 
            // btnSaveUrlRule
            // 
            this.btnSaveUrlRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveUrlRule.Location = new System.Drawing.Point(581, 5);
            this.btnSaveUrlRule.Name = "btnSaveUrlRule";
            this.btnSaveUrlRule.Size = new System.Drawing.Size(83, 25);
            this.btnSaveUrlRule.TabIndex = 3;
            this.btnSaveUrlRule.Text = "保存规则";
            this.btnSaveUrlRule.UseVisualStyleBackColor = true;
            this.btnSaveUrlRule.Click += new System.EventHandler(this.btnSaveUrlRule_Click);
            // 
            // gbStep1url1
            // 
            this.gbStep1url1.Controls.Add(this.lbUrl1);
            this.gbStep1url1.Controls.Add(this.panel2);
            this.gbStep1url1.Location = new System.Drawing.Point(7, 7);
            this.gbStep1url1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.gbStep1url1.Name = "gbStep1url1";
            this.gbStep1url1.Size = new System.Drawing.Size(758, 148);
            this.gbStep1url1.TabIndex = 0;
            this.gbStep1url1.TabStop = false;
            this.gbStep1url1.Text = "起始网址设置";
            // 
            // lbUrl1
            // 
            this.lbUrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUrl1.FormattingEnabled = true;
            this.lbUrl1.ItemHeight = 12;
            this.lbUrl1.Location = new System.Drawing.Point(3, 17);
            this.lbUrl1.Name = "lbUrl1";
            this.lbUrl1.Size = new System.Drawing.Size(658, 128);
            this.lbUrl1.TabIndex = 1;
            this.lbUrl1.SelectedIndexChanged += new System.EventHandler(this.lbUrl1_SelectedIndexChanged);
            this.lbUrl1.DoubleClick += new System.EventHandler(this.lbUrl1_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnStep1UrlClear);
            this.panel2.Controls.Add(this.btnStep1UrlDelete);
            this.panel2.Controls.Add(this.btnStep1UrlEdit);
            this.panel2.Controls.Add(this.btnStep1UrlAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(661, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(94, 128);
            this.panel2.TabIndex = 0;
            // 
            // btnStep1UrlClear
            // 
            this.btnStep1UrlClear.Location = new System.Drawing.Point(10, 98);
            this.btnStep1UrlClear.Name = "btnStep1UrlClear";
            this.btnStep1UrlClear.Size = new System.Drawing.Size(75, 23);
            this.btnStep1UrlClear.TabIndex = 3;
            this.btnStep1UrlClear.Text = "清空";
            this.btnStep1UrlClear.UseVisualStyleBackColor = true;
            this.btnStep1UrlClear.Click += new System.EventHandler(this.btnStep1UrlClear_Click);
            // 
            // btnStep1UrlDelete
            // 
            this.btnStep1UrlDelete.Enabled = false;
            this.btnStep1UrlDelete.Location = new System.Drawing.Point(10, 67);
            this.btnStep1UrlDelete.Name = "btnStep1UrlDelete";
            this.btnStep1UrlDelete.Size = new System.Drawing.Size(75, 23);
            this.btnStep1UrlDelete.TabIndex = 2;
            this.btnStep1UrlDelete.Text = "删除";
            this.btnStep1UrlDelete.UseVisualStyleBackColor = true;
            this.btnStep1UrlDelete.Click += new System.EventHandler(this.btnStep1UrlDelete_Click);
            // 
            // btnStep1UrlEdit
            // 
            this.btnStep1UrlEdit.Enabled = false;
            this.btnStep1UrlEdit.Location = new System.Drawing.Point(10, 36);
            this.btnStep1UrlEdit.Name = "btnStep1UrlEdit";
            this.btnStep1UrlEdit.Size = new System.Drawing.Size(75, 23);
            this.btnStep1UrlEdit.TabIndex = 1;
            this.btnStep1UrlEdit.Text = "修改";
            this.btnStep1UrlEdit.UseVisualStyleBackColor = true;
            this.btnStep1UrlEdit.Click += new System.EventHandler(this.btnStep1UrlEdit_Click);
            // 
            // btnStep1UrlAdd
            // 
            this.btnStep1UrlAdd.Location = new System.Drawing.Point(10, 5);
            this.btnStep1UrlAdd.Name = "btnStep1UrlAdd";
            this.btnStep1UrlAdd.Size = new System.Drawing.Size(75, 23);
            this.btnStep1UrlAdd.TabIndex = 0;
            this.btnStep1UrlAdd.Text = "添加";
            this.btnStep1UrlAdd.UseVisualStyleBackColor = true;
            this.btnStep1UrlAdd.Click += new System.EventHandler(this.btnStep1UrlAdd_Click);
            // 
            // gbStep1url2
            // 
            this.gbStep1url2.Controls.Add(this.lvMultilevelURL);
            this.gbStep1url2.Controls.Add(this.panel3);
            this.gbStep1url2.Location = new System.Drawing.Point(7, 162);
            this.gbStep1url2.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.gbStep1url2.Name = "gbStep1url2";
            this.gbStep1url2.Size = new System.Drawing.Size(758, 148);
            this.gbStep1url2.TabIndex = 0;
            this.gbStep1url2.TabStop = false;
            this.gbStep1url2.Text = "多级网址获取";
            // 
            // lvMultilevelURL
            // 
            this.lvMultilevelURL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvMultilevelURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMultilevelURL.FullRowSelect = true;
            this.lvMultilevelURL.Location = new System.Drawing.Point(3, 17);
            this.lvMultilevelURL.Name = "lvMultilevelURL";
            this.lvMultilevelURL.Size = new System.Drawing.Size(658, 128);
            this.lvMultilevelURL.TabIndex = 2;
            this.lvMultilevelURL.UseCompatibleStateImageBehavior = false;
            this.lvMultilevelURL.View = System.Windows.Forms.View.Details;
            this.lvMultilevelURL.SelectedIndexChanged += new System.EventHandler(this.lvMultilevelURL_SelectedIndexChanged);
            this.lvMultilevelURL.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvMultilevelURL_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "网址提取方式";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "请求方式";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "开始区域";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "结束区域";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "必须包含";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "不得包含";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "分页地址样式";
            this.columnHeader7.Width = 100;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnStep1MultilevelUrlClear);
            this.panel3.Controls.Add(this.btnStep1MultilevelUrlDelete);
            this.panel3.Controls.Add(this.btnStep1MultilevelEdit);
            this.panel3.Controls.Add(this.btnStep1MultilevelUrlAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(661, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(94, 128);
            this.panel3.TabIndex = 1;
            // 
            // btnStep1MultilevelUrlClear
            // 
            this.btnStep1MultilevelUrlClear.Location = new System.Drawing.Point(10, 98);
            this.btnStep1MultilevelUrlClear.Name = "btnStep1MultilevelUrlClear";
            this.btnStep1MultilevelUrlClear.Size = new System.Drawing.Size(75, 23);
            this.btnStep1MultilevelUrlClear.TabIndex = 3;
            this.btnStep1MultilevelUrlClear.Text = "清空";
            this.btnStep1MultilevelUrlClear.UseVisualStyleBackColor = true;
            this.btnStep1MultilevelUrlClear.Click += new System.EventHandler(this.btnStep1MultilevelUrlClear_Click);
            // 
            // btnStep1MultilevelUrlDelete
            // 
            this.btnStep1MultilevelUrlDelete.Enabled = false;
            this.btnStep1MultilevelUrlDelete.Location = new System.Drawing.Point(10, 67);
            this.btnStep1MultilevelUrlDelete.Name = "btnStep1MultilevelUrlDelete";
            this.btnStep1MultilevelUrlDelete.Size = new System.Drawing.Size(75, 23);
            this.btnStep1MultilevelUrlDelete.TabIndex = 2;
            this.btnStep1MultilevelUrlDelete.Text = "删除";
            this.btnStep1MultilevelUrlDelete.UseVisualStyleBackColor = true;
            this.btnStep1MultilevelUrlDelete.Click += new System.EventHandler(this.btnStep1MultilevelUrlDelete_Click);
            // 
            // btnStep1MultilevelEdit
            // 
            this.btnStep1MultilevelEdit.Enabled = false;
            this.btnStep1MultilevelEdit.Location = new System.Drawing.Point(10, 36);
            this.btnStep1MultilevelEdit.Name = "btnStep1MultilevelEdit";
            this.btnStep1MultilevelEdit.Size = new System.Drawing.Size(75, 23);
            this.btnStep1MultilevelEdit.TabIndex = 1;
            this.btnStep1MultilevelEdit.Text = "修改";
            this.btnStep1MultilevelEdit.UseVisualStyleBackColor = true;
            this.btnStep1MultilevelEdit.Click += new System.EventHandler(this.btnStep1MultilevelEdit_Click);
            // 
            // btnStep1MultilevelUrlAdd
            // 
            this.btnStep1MultilevelUrlAdd.Location = new System.Drawing.Point(10, 5);
            this.btnStep1MultilevelUrlAdd.Name = "btnStep1MultilevelUrlAdd";
            this.btnStep1MultilevelUrlAdd.Size = new System.Drawing.Size(75, 23);
            this.btnStep1MultilevelUrlAdd.TabIndex = 0;
            this.btnStep1MultilevelUrlAdd.Text = "添加";
            this.btnStep1MultilevelUrlAdd.UseVisualStyleBackColor = true;
            this.btnStep1MultilevelUrlAdd.Click += new System.EventHandler(this.btnStep1MultilevelUrlAdd_Click);
            // 
            // tpLable
            // 
            this.tpLable.Controls.Add(this.tabControl1);
            this.tpLable.Controls.Add(this.groupBox1);
            this.tpLable.Controls.Add(this.splitContainer1);
            this.tpLable.Location = new System.Drawing.Point(4, 22);
            this.tpLable.Name = "tpLable";
            this.tpLable.Padding = new System.Windows.Forms.Padding(3);
            this.tpLable.Size = new System.Drawing.Size(766, 529);
            this.tpLable.TabIndex = 1;
            this.tpLable.Text = "第二步：采集内容规则";
            this.tpLable.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Location = new System.Drawing.Point(6, 254);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 2);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(262, 273);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gbPagesCombine);
            this.tabPage5.Controls.Add(this.gbPagesStyle);
            this.tabPage5.Controls.Add(this.panel9);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Controls.Add(this.rbUpDownPage);
            this.tabPage5.Controls.Add(this.rbPagesUrlListAll);
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(254, 246);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "分页获取规则";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // gbPagesCombine
            // 
            this.gbPagesCombine.Controls.Add(this.ucLableText27);
            this.gbPagesCombine.Controls.Add(this.rtbePagesCombine);
            this.gbPagesCombine.Enabled = false;
            this.gbPagesCombine.Location = new System.Drawing.Point(3, 200);
            this.gbPagesCombine.Name = "gbPagesCombine";
            this.gbPagesCombine.Size = new System.Drawing.Size(245, 46);
            this.gbPagesCombine.TabIndex = 5;
            this.gbPagesCombine.TabStop = false;
            this.gbPagesCombine.Text = "分页网址";
            // 
            // ucLableText27
            // 
            this.ucLableText27.AutoSize = true;
            this.ucLableText27.Location = new System.Drawing.Point(203, 24);
            this.ucLableText27.Name = "ucLableText27";
            this.ucLableText27.OperationControl = this.rtbePagesCombine;
            this.ucLableText27.OperationTextBox = null;
            this.ucLableText27.Size = new System.Drawing.Size(47, 12);
            this.ucLableText27.TabIndex = 1;
            this.ucLableText27.TabStop = true;
            this.ucLableText27.Text = "[参数N]";
            this.ucLableText27.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.ParameterN;
            // 
            // rtbePagesCombine
            // 
            this.rtbePagesCombine.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtbePagesCombine.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbePagesCombine.LableList")));
            this.rtbePagesCombine.Location = new System.Drawing.Point(3, 17);
            this.rtbePagesCombine.Name = "rtbePagesCombine";
            this.rtbePagesCombine.ParameterN = true;
            this.rtbePagesCombine.Size = new System.Drawing.Size(197, 26);
            this.rtbePagesCombine.TabIndex = 0;
            this.rtbePagesCombine.TextValue = "";
            this.rtbePagesCombine.WordWrap = false;
            // 
            // gbPagesStyle
            // 
            this.gbPagesStyle.Controls.Add(this.ucLableText25);
            this.gbPagesStyle.Controls.Add(this.ucLableText24);
            this.gbPagesStyle.Controls.Add(this.rtbePagesStyle);
            this.gbPagesStyle.Enabled = false;
            this.gbPagesStyle.Location = new System.Drawing.Point(3, 132);
            this.gbPagesStyle.Name = "gbPagesStyle";
            this.gbPagesStyle.Size = new System.Drawing.Size(245, 68);
            this.gbPagesStyle.TabIndex = 5;
            this.gbPagesStyle.TabStop = false;
            this.gbPagesStyle.Text = "分页链接地址样式";
            // 
            // ucLableText25
            // 
            this.ucLableText25.AutoSize = true;
            this.ucLableText25.Location = new System.Drawing.Point(203, 42);
            this.ucLableText25.Name = "ucLableText25";
            this.ucLableText25.OperationControl = this.rtbePagesStyle;
            this.ucLableText25.OperationTextBox = null;
            this.ucLableText25.Size = new System.Drawing.Size(41, 12);
            this.ucLableText25.TabIndex = 2;
            this.ucLableText25.TabStop = true;
            this.ucLableText25.Text = "[参数]";
            this.ucLableText25.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Parameter;
            // 
            // rtbePagesStyle
            // 
            this.rtbePagesStyle.Asterisk = true;
            this.rtbePagesStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtbePagesStyle.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbePagesStyle.LableList")));
            this.rtbePagesStyle.Location = new System.Drawing.Point(3, 17);
            this.rtbePagesStyle.Name = "rtbePagesStyle";
            this.rtbePagesStyle.Parameter = true;
            this.rtbePagesStyle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbePagesStyle.Size = new System.Drawing.Size(197, 48);
            this.rtbePagesStyle.TabIndex = 0;
            this.rtbePagesStyle.TextValue = "";
            this.rtbePagesStyle.WordWrap = true;
            // 
            // ucLableText24
            // 
            this.ucLableText24.AutoSize = true;
            this.ucLableText24.Location = new System.Drawing.Point(203, 17);
            this.ucLableText24.Name = "ucLableText24";
            this.ucLableText24.OperationControl = this.rtbePagesStyle;
            this.ucLableText24.OperationTextBox = null;
            this.ucLableText24.Size = new System.Drawing.Size(23, 12);
            this.ucLableText24.TabIndex = 1;
            this.ucLableText24.TabStop = true;
            this.ucLableText24.Text = "(*)";
            this.ucLableText24.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.rbManualPaging);
            this.panel9.Controls.Add(this.rbGetPagesUrlAuto);
            this.panel9.Location = new System.Drawing.Point(3, 106);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(250, 24);
            this.panel9.TabIndex = 4;
            // 
            // rbManualPaging
            // 
            this.rbManualPaging.AutoSize = true;
            this.rbManualPaging.Checked = true;
            this.rbManualPaging.Location = new System.Drawing.Point(97, 5);
            this.rbManualPaging.Name = "rbManualPaging";
            this.rbManualPaging.Size = new System.Drawing.Size(143, 16);
            this.rbManualPaging.TabIndex = 3;
            this.rbManualPaging.TabStop = true;
            this.rbManualPaging.Text = "手动填写分页地址规则";
            this.rbManualPaging.UseVisualStyleBackColor = true;
            // 
            // rbGetPagesUrlAuto
            // 
            this.rbGetPagesUrlAuto.AutoSize = true;
            this.rbGetPagesUrlAuto.Checked = true;
            this.rbGetPagesUrlAuto.Location = new System.Drawing.Point(9, 5);
            this.rbGetPagesUrlAuto.Name = "rbGetPagesUrlAuto";
            this.rbGetPagesUrlAuto.Size = new System.Drawing.Size(71, 16);
            this.rbGetPagesUrlAuto.TabIndex = 3;
            this.rbGetPagesUrlAuto.TabStop = true;
            this.rbGetPagesUrlAuto.Text = "自动识别";
            this.rbGetPagesUrlAuto.UseVisualStyleBackColor = true;
            this.rbGetPagesUrlAuto.CheckedChanged += new System.EventHandler(this.rbGetPagesUrlAuto_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbePagesAreaEnd);
            this.groupBox2.Controls.Add(this.rtbePagesAreaStart);
            this.groupBox2.Controls.Add(this.ucLableText23);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.ucLableText22);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Location = new System.Drawing.Point(5, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 84);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分页网址提取区域(不指定不提取分页)";
            // 
            // rtbePagesAreaEnd
            // 
            this.rtbePagesAreaEnd.Asterisk = true;
            this.rtbePagesAreaEnd.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbePagesAreaEnd.LableList")));
            this.rtbePagesAreaEnd.Location = new System.Drawing.Point(147, 17);
            this.rtbePagesAreaEnd.Name = "rtbePagesAreaEnd";
            this.rtbePagesAreaEnd.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbePagesAreaEnd.Size = new System.Drawing.Size(88, 67);
            this.rtbePagesAreaEnd.TabIndex = 2;
            this.rtbePagesAreaEnd.TextValue = "";
            this.rtbePagesAreaEnd.WordWrap = true;
            // 
            // rtbePagesAreaStart
            // 
            this.rtbePagesAreaStart.Asterisk = true;
            this.rtbePagesAreaStart.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbePagesAreaStart.LableList")));
            this.rtbePagesAreaStart.Location = new System.Drawing.Point(30, 17);
            this.rtbePagesAreaStart.Name = "rtbePagesAreaStart";
            this.rtbePagesAreaStart.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbePagesAreaStart.Size = new System.Drawing.Size(88, 67);
            this.rtbePagesAreaStart.TabIndex = 2;
            this.rtbePagesAreaStart.TextValue = "";
            this.rtbePagesAreaStart.WordWrap = true;
            // 
            // ucLableText23
            // 
            this.ucLableText23.AutoSize = true;
            this.ucLableText23.Location = new System.Drawing.Point(123, 36);
            this.ucLableText23.Name = "ucLableText23";
            this.ucLableText23.OperationControl = this.rtbePagesAreaEnd;
            this.ucLableText23.OperationTextBox = null;
            this.ucLableText23.Size = new System.Drawing.Size(23, 12);
            this.ucLableText23.TabIndex = 1;
            this.ucLableText23.TabStop = true;
            this.ucLableText23.Text = "(*)";
            this.ucLableText23.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(127, 17);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 12);
            this.label29.TabIndex = 0;
            this.label29.Text = "到";
            // 
            // ucLableText22
            // 
            this.ucLableText22.AutoSize = true;
            this.ucLableText22.Location = new System.Drawing.Point(6, 36);
            this.ucLableText22.Name = "ucLableText22";
            this.ucLableText22.OperationControl = this.rtbePagesAreaStart;
            this.ucLableText22.OperationTextBox = null;
            this.ucLableText22.Size = new System.Drawing.Size(23, 12);
            this.ucLableText22.TabIndex = 1;
            this.ucLableText22.TabStop = true;
            this.ucLableText22.Text = "(*)";
            this.ucLableText22.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(10, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 12);
            this.label28.TabIndex = 0;
            this.label28.Text = "从";
            // 
            // rbUpDownPage
            // 
            this.rbUpDownPage.AutoSize = true;
            this.rbUpDownPage.Location = new System.Drawing.Point(124, 3);
            this.rbUpDownPage.Name = "rbUpDownPage";
            this.rbUpDownPage.Size = new System.Drawing.Size(125, 16);
            this.rbUpDownPage.TabIndex = 2;
            this.rbUpDownPage.Text = "上下页/上n页下n页";
            this.rbUpDownPage.UseVisualStyleBackColor = true;
            // 
            // rbPagesUrlListAll
            // 
            this.rbPagesUrlListAll.AutoSize = true;
            this.rbPagesUrlListAll.Checked = true;
            this.rbPagesUrlListAll.Location = new System.Drawing.Point(7, 3);
            this.rbPagesUrlListAll.Name = "rbPagesUrlListAll";
            this.rbPagesUrlListAll.Size = new System.Drawing.Size(95, 16);
            this.rbPagesUrlListAll.TabIndex = 2;
            this.rbPagesUrlListAll.TabStop = true;
            this.rbPagesUrlListAll.Text = "全部列出模式";
            this.rbPagesUrlListAll.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.ucHelper6);
            this.tabPage9.Controls.Add(this.txtPagesJoinCode);
            this.tabPage9.Controls.Add(this.label32);
            this.tabPage9.Controls.Add(this.groupBox5);
            this.tabPage9.Location = new System.Drawing.Point(4, 23);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(254, 246);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "标签循环处理";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // ucHelper6
            // 
            this.ucHelper6.HelperKey = "PagesJonCode";
            this.ucHelper6.Location = new System.Drawing.Point(228, 144);
            this.ucHelper6.Name = "ucHelper6";
            this.ucHelper6.Size = new System.Drawing.Size(16, 16);
            this.ucHelper6.TabIndex = 3;
            // 
            // txtPagesJoinCode
            // 
            this.txtPagesJoinCode.Location = new System.Drawing.Point(119, 141);
            this.txtPagesJoinCode.Name = "txtPagesJoinCode";
            this.txtPagesJoinCode.Size = new System.Drawing.Size(103, 21);
            this.txtPagesJoinCode.TabIndex = 2;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 144);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(113, 12);
            this.label32.TabIndex = 1;
            this.label32.Text = "分页内容连接代码：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkFillLoopWithFirst);
            this.groupBox5.Controls.Add(this.ucHelper7);
            this.groupBox5.Controls.Add(this.rtbeLoopJoinCode);
            this.groupBox5.Controls.Add(this.ucLableText26);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.radioButton6);
            this.groupBox5.Controls.Add(this.rbLoopAddNewRecord);
            this.groupBox5.Location = new System.Drawing.Point(7, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(241, 117);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "每一个标签循环匹配项";
            // 
            // chkFillLoopWithFirst
            // 
            this.chkFillLoopWithFirst.AutoSize = true;
            this.chkFillLoopWithFirst.Location = new System.Drawing.Point(6, 65);
            this.chkFillLoopWithFirst.Name = "chkFillLoopWithFirst";
            this.chkFillLoopWithFirst.Size = new System.Drawing.Size(204, 16);
            this.chkFillLoopWithFirst.TabIndex = 6;
            this.chkFillLoopWithFirst.Text = "循环不足的记录以第一条记录补全";
            this.chkFillLoopWithFirst.UseVisualStyleBackColor = true;
            // 
            // ucHelper7
            // 
            this.ucHelper7.HelperKey = "LoopRecord";
            this.ucHelper7.Location = new System.Drawing.Point(220, 11);
            this.ucHelper7.Name = "ucHelper7";
            this.ucHelper7.Size = new System.Drawing.Size(16, 16);
            this.ucHelper7.TabIndex = 5;
            // 
            // rtbeLoopJoinCode
            // 
            this.rtbeLoopJoinCode.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeLoopJoinCode.LableList")));
            this.rtbeLoopJoinCode.Location = new System.Drawing.Point(51, 88);
            this.rtbeLoopJoinCode.Name = "rtbeLoopJoinCode";
            this.rtbeLoopJoinCode.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeLoopJoinCode.Size = new System.Drawing.Size(141, 22);
            this.rtbeLoopJoinCode.TabIndex = 4;
            this.rtbeLoopJoinCode.TextValue = "";
            this.rtbeLoopJoinCode.WordWrap = true;
            // 
            // ucLableText26
            // 
            this.ucLableText26.AutoSize = true;
            this.ucLableText26.Location = new System.Drawing.Point(197, 94);
            this.ucLableText26.Name = "ucLableText26";
            this.ucLableText26.OperationControl = this.rtbeLoopJoinCode;
            this.ucLableText26.OperationTextBox = null;
            this.ucLableText26.Size = new System.Drawing.Size(41, 12);
            this.ucLableText26.TabIndex = 3;
            this.ucLableText26.TabStop = true;
            this.ucLableText26.Text = "[换行]";
            this.ucLableText26.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Custom;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 92);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 12);
            this.label31.TabIndex = 2;
            this.label31.Text = "分隔符：";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(7, 43);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(167, 16);
            this.radioButton6.TabIndex = 1;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "用分隔符连接在上条记录后";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // rbLoopAddNewRecord
            // 
            this.rbLoopAddNewRecord.AutoSize = true;
            this.rbLoopAddNewRecord.Location = new System.Drawing.Point(6, 20);
            this.rbLoopAddNewRecord.Name = "rbLoopAddNewRecord";
            this.rbLoopAddNewRecord.Size = new System.Drawing.Size(95, 16);
            this.rbLoopAddNewRecord.TabIndex = 0;
            this.rbLoopAddNewRecord.Text = "添加为新记录";
            this.rbLoopAddNewRecord.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.checkBox1);
            this.tabPage10.Controls.Add(this.nudMaxSpiderPerNum);
            this.tabPage10.Controls.Add(this.nudMaxPages);
            this.tabPage10.Controls.Add(this.label34);
            this.tabPage10.Controls.Add(this.label33);
            this.tabPage10.Location = new System.Drawing.Point(4, 23);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(254, 246);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "其他设置";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "提取标签数据时忽略大小写";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // nudMaxSpiderPerNum
            // 
            this.nudMaxSpiderPerNum.Location = new System.Drawing.Point(183, 32);
            this.nudMaxSpiderPerNum.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMaxSpiderPerNum.Name = "nudMaxSpiderPerNum";
            this.nudMaxSpiderPerNum.Size = new System.Drawing.Size(67, 21);
            this.nudMaxSpiderPerNum.TabIndex = 1;
            // 
            // nudMaxPages
            // 
            this.nudMaxPages.Location = new System.Drawing.Point(183, 5);
            this.nudMaxPages.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMaxPages.Name = "nudMaxPages";
            this.nudMaxPages.Size = new System.Drawing.Size(67, 21);
            this.nudMaxPages.TabIndex = 1;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(7, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(179, 12);
            this.label34.TabIndex = 2;
            this.label34.Text = "每次任务最大采集数(0为全部)：";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(5, 9);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(155, 12);
            this.label33.TabIndex = 0;
            this.label33.Text = "最大采集分页数，0为不限：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lvLable);
            this.groupBox1.Controls.Add(this.btnSortUp);
            this.groupBox1.Controls.Add(this.btnSortDown);
            this.groupBox1.Controls.Add(this.btnMultPageChange);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnLabelImport);
            this.groupBox1.Controls.Add(this.btnLabelDelete);
            this.groupBox1.Controls.Add(this.btnLabelCopy);
            this.groupBox1.Controls.Add(this.btnLabelEdit);
            this.groupBox1.Controls.Add(this.btnLabelAdd);
            this.groupBox1.Location = new System.Drawing.Point(2, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 248);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "页面内容标签定义  (规则普通编辑模式)";
            // 
            // lvLable
            // 
            this.lvLable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvLable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader25,
            this.columnHeader26});
            this.lvLable.FullRowSelect = true;
            this.lvLable.GridLines = true;
            this.lvLable.Location = new System.Drawing.Point(69, 15);
            this.lvLable.Name = "lvLable";
            this.lvLable.Size = new System.Drawing.Size(193, 227);
            this.lvLable.TabIndex = 8;
            this.lvLable.UseCompatibleStateImageBehavior = false;
            this.lvLable.View = System.Windows.Forms.View.Details;
            this.lvLable.SelectedIndexChanged += new System.EventHandler(this.lvLable_SelectedIndexChanged);
            this.lvLable.Click += new System.EventHandler(this.lvLable_Click);
            this.lvLable.DoubleClick += new System.EventHandler(this.lvLable_DoubleClick);
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "标签名";
            this.columnHeader25.Width = 90;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "获取方式";
            this.columnHeader26.Width = 90;
            // 
            // btnSortUp
            // 
            this.btnSortUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSortUp.Location = new System.Drawing.Point(50, 197);
            this.btnSortUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnSortUp.Name = "btnSortUp";
            this.btnSortUp.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnSortUp.Size = new System.Drawing.Size(14, 19);
            this.btnSortUp.TabIndex = 7;
            this.btnSortUp.Text = "↑";
            this.btnSortUp.UseVisualStyleBackColor = true;
            this.btnSortUp.Click += new System.EventHandler(this.btnSortUp_Click);
            // 
            // btnSortDown
            // 
            this.btnSortDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSortDown.Location = new System.Drawing.Point(50, 222);
            this.btnSortDown.Name = "btnSortDown";
            this.btnSortDown.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnSortDown.Size = new System.Drawing.Size(14, 19);
            this.btnSortDown.TabIndex = 6;
            this.btnSortDown.Text = "↓";
            this.btnSortDown.UseVisualStyleBackColor = true;
            this.btnSortDown.Click += new System.EventHandler(this.btnSortDown_Click);
            // 
            // btnMultPageChange
            // 
            this.btnMultPageChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMultPageChange.Location = new System.Drawing.Point(4, 197);
            this.btnMultPageChange.Name = "btnMultPageChange";
            this.btnMultPageChange.Size = new System.Drawing.Size(45, 45);
            this.btnMultPageChange.TabIndex = 5;
            this.btnMultPageChange.Text = "多页管理";
            this.btnMultPageChange.UseVisualStyleBackColor = true;
            this.btnMultPageChange.Click += new System.EventHandler(this.btnMultPageChange_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(4, 169);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(59, 25);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLabelImport
            // 
            this.btnLabelImport.Location = new System.Drawing.Point(4, 140);
            this.btnLabelImport.Name = "btnLabelImport";
            this.btnLabelImport.Size = new System.Drawing.Size(59, 25);
            this.btnLabelImport.TabIndex = 4;
            this.btnLabelImport.Text = "导入";
            this.btnLabelImport.UseVisualStyleBackColor = true;
            this.btnLabelImport.Click += new System.EventHandler(this.btnLabelImport_Click);
            // 
            // btnLabelDelete
            // 
            this.btnLabelDelete.Location = new System.Drawing.Point(4, 109);
            this.btnLabelDelete.Name = "btnLabelDelete";
            this.btnLabelDelete.Size = new System.Drawing.Size(59, 25);
            this.btnLabelDelete.TabIndex = 3;
            this.btnLabelDelete.Text = "删除";
            this.btnLabelDelete.UseVisualStyleBackColor = true;
            this.btnLabelDelete.Click += new System.EventHandler(this.btnLabelDelete_Click);
            // 
            // btnLabelCopy
            // 
            this.btnLabelCopy.Location = new System.Drawing.Point(4, 78);
            this.btnLabelCopy.Name = "btnLabelCopy";
            this.btnLabelCopy.Size = new System.Drawing.Size(59, 25);
            this.btnLabelCopy.TabIndex = 2;
            this.btnLabelCopy.Text = "拷贝";
            this.btnLabelCopy.UseVisualStyleBackColor = true;
            this.btnLabelCopy.Click += new System.EventHandler(this.btnLabelCopy_Click);
            // 
            // btnLabelEdit
            // 
            this.btnLabelEdit.Location = new System.Drawing.Point(4, 47);
            this.btnLabelEdit.Name = "btnLabelEdit";
            this.btnLabelEdit.Size = new System.Drawing.Size(59, 25);
            this.btnLabelEdit.TabIndex = 1;
            this.btnLabelEdit.Text = "修改";
            this.btnLabelEdit.UseVisualStyleBackColor = true;
            this.btnLabelEdit.Click += new System.EventHandler(this.btnLabelEdit_Click);
            // 
            // btnLabelAdd
            // 
            this.btnLabelAdd.Location = new System.Drawing.Point(4, 16);
            this.btnLabelAdd.Name = "btnLabelAdd";
            this.btnLabelAdd.Size = new System.Drawing.Size(59, 25);
            this.btnLabelAdd.TabIndex = 0;
            this.btnLabelAdd.Text = "添加";
            this.btnLabelAdd.UseVisualStyleBackColor = true;
            this.btnLabelAdd.Click += new System.EventHandler(this.btnLabelAdd_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(276, 6);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbTestJob);
            this.splitContainer1.Panel1.Controls.Add(this.rtbeTestResult);
            this.splitContainer1.Panel1.Controls.Add(this.panel10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(484, 519);
            this.splitContainer1.SplitterDistance = 388;
            this.splitContainer1.TabIndex = 6;
            // 
            // gbTestJob
            // 
            this.gbTestJob.Controls.Add(this.lblTsetJobStatus);
            this.gbTestJob.Controls.Add(this.pictureBox2);
            this.gbTestJob.Location = new System.Drawing.Point(26, 152);
            this.gbTestJob.Name = "gbTestJob";
            this.gbTestJob.Size = new System.Drawing.Size(437, 71);
            this.gbTestJob.TabIndex = 13;
            this.gbTestJob.TabStop = false;
            this.gbTestJob.Visible = false;
            // 
            // lblTsetJobStatus
            // 
            this.lblTsetJobStatus.Location = new System.Drawing.Point(43, 17);
            this.lblTsetJobStatus.Name = "lblTsetJobStatus";
            this.lblTsetJobStatus.Size = new System.Drawing.Size(386, 46);
            this.lblTsetJobStatus.TabIndex = 1;
            this.lblTsetJobStatus.Text = "正在下载并分析网址\r\n请稍后呦~";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(9, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // rtbeTestResult
            // 
            this.rtbeTestResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbeTestResult.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeTestResult.LableList")));
            this.rtbeTestResult.Location = new System.Drawing.Point(0, 29);
            this.rtbeTestResult.Margin = new System.Windows.Forms.Padding(10);
            this.rtbeTestResult.Name = "rtbeTestResult";
            this.rtbeTestResult.Padding = new System.Windows.Forms.Padding(1);
            this.rtbeTestResult.RealTimeRendering = false;
            this.rtbeTestResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeTestResult.Size = new System.Drawing.Size(484, 359);
            this.rtbeTestResult.TabIndex = 5;
            this.rtbeTestResult.TestLable = true;
            this.rtbeTestResult.TextValue = "使用提示：\n1.在测试按钮上右键，可以弹出 获取网页源代码，测试Web发布数据，清空测试页网址，在浏览器中查看 几个菜单\n2.如果不设置分布网址提取区域，则采集器" +
    "不会采集分页内容\n3.规则普通编辑模式中的分页获取规则和无限级多页规则编辑模式中的0级的分页网址获取规则是完全一致的。";
            this.rtbeTestResult.WordWrap = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.cmbTestPageUrls);
            this.panel10.Controls.Add(this.btnTest);
            this.panel10.Controls.Add(this.label30);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(484, 29);
            this.panel10.TabIndex = 6;
            // 
            // cmbTestPageUrls
            // 
            this.cmbTestPageUrls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTestPageUrls.FormattingEnabled = true;
            this.cmbTestPageUrls.Location = new System.Drawing.Point(60, 5);
            this.cmbTestPageUrls.Name = "cmbTestPageUrls";
            this.cmbTestPageUrls.Size = new System.Drawing.Size(370, 20);
            this.cmbTestPageUrls.TabIndex = 3;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.ContextMenuStrip = this.cmsTest;
            this.btnTest.Location = new System.Drawing.Point(433, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(50, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // cmsTest
            // 
            this.cmsTest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTestSend,
            this.在浏览器中查看ToolStripMenuItem,
            this.清空测试ToolStripMenuItem,
            this.获取页面源代码ToolStripMenuItem});
            this.cmsTest.Name = "cmsTest";
            this.cmsTest.Size = new System.Drawing.Size(176, 92);
            // 
            // tsmiTestSend
            // 
            this.tsmiTestSend.Name = "tsmiTestSend";
            this.tsmiTestSend.Size = new System.Drawing.Size(175, 22);
            this.tsmiTestSend.Text = "测试Web发布数据";
            this.tsmiTestSend.Click += new System.EventHandler(this.测试Web发布数据ToolStripMenuItem_Click);
            // 
            // 在浏览器中查看ToolStripMenuItem
            // 
            this.在浏览器中查看ToolStripMenuItem.Name = "在浏览器中查看ToolStripMenuItem";
            this.在浏览器中查看ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.在浏览器中查看ToolStripMenuItem.Text = "在浏览器中查看";
            this.在浏览器中查看ToolStripMenuItem.Click += new System.EventHandler(this.在浏览器中查看ToolStripMenuItem_Click);
            // 
            // 清空测试ToolStripMenuItem
            // 
            this.清空测试ToolStripMenuItem.Name = "清空测试ToolStripMenuItem";
            this.清空测试ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.清空测试ToolStripMenuItem.Text = "清空测试页网址";
            this.清空测试ToolStripMenuItem.Click += new System.EventHandler(this.清空测试ToolStripMenuItem_Click);
            // 
            // 获取页面源代码ToolStripMenuItem
            // 
            this.获取页面源代码ToolStripMenuItem.Name = "获取页面源代码ToolStripMenuItem";
            this.获取页面源代码ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.获取页面源代码ToolStripMenuItem.Text = "获取页面源代码";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(0, 8);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 12);
            this.label30.TabIndex = 2;
            this.label30.Text = "典型页面：";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvDown);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(484, 127);
            this.splitContainer2.SplitterDistance = 63;
            this.splitContainer2.TabIndex = 0;
            // 
            // lvDown
            // 
            this.lvDown.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21});
            this.lvDown.ContextMenuStrip = this.cmsDown;
            this.lvDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDown.FullRowSelect = true;
            this.lvDown.GridLines = true;
            this.lvDown.Location = new System.Drawing.Point(0, 0);
            this.lvDown.Name = "lvDown";
            this.lvDown.Size = new System.Drawing.Size(484, 63);
            this.lvDown.SmallImageList = this.imageListFile;
            this.lvDown.TabIndex = 0;
            this.lvDown.UseCompatibleStateImageBehavior = false;
            this.lvDown.View = System.Windows.Forms.View.Details;
            this.lvDown.DoubleClick += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "文件";
            this.columnHeader11.Width = 142;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "大小";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "完成";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "进度";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "剩余";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "速度";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "时间";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "状态";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "续传";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "地址";
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "序号";
            // 
            // cmsDown
            // 
            this.cmsDown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.拷贝地址ToolStripMenuItem,
            this.打开目录ToolStripMenuItem});
            this.cmsDown.Name = "cmsDown";
            this.cmsDown.Size = new System.Drawing.Size(125, 70);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 拷贝地址ToolStripMenuItem
            // 
            this.拷贝地址ToolStripMenuItem.Name = "拷贝地址ToolStripMenuItem";
            this.拷贝地址ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.拷贝地址ToolStripMenuItem.Text = "拷贝地址";
            this.拷贝地址ToolStripMenuItem.Click += new System.EventHandler(this.拷贝地址ToolStripMenuItem_Click);
            // 
            // 打开目录ToolStripMenuItem
            // 
            this.打开目录ToolStripMenuItem.Name = "打开目录ToolStripMenuItem";
            this.打开目录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开目录ToolStripMenuItem.Text = "打开目录";
            this.打开目录ToolStripMenuItem.Click += new System.EventHandler(this.打开目录ToolStripMenuItem_Click);
            // 
            // imageListFile
            // 
            this.imageListFile.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListFile.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListFile.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rtbDownLog);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(481, 59);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "下载日志";
            // 
            // rtbDownLog
            // 
            this.rtbDownLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDownLog.Location = new System.Drawing.Point(3, 17);
            this.rtbDownLog.Name = "rtbDownLog";
            this.rtbDownLog.Size = new System.Drawing.Size(475, 39);
            this.rtbDownLog.TabIndex = 10;
            this.rtbDownLog.Text = "";
            this.rtbDownLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDownLog_LinkClicked);
            // 
            // chkWeb
            // 
            this.chkWeb.Controls.Add(this.txtVisitUrlAfterEnd);
            this.chkWeb.Controls.Add(this.label41);
            this.chkWeb.Controls.Add(this.chkSignSucessIfAllPost);
            this.chkWeb.Controls.Add(this.chkNotWebOutIfFileNoDownLoad);
            this.chkWeb.Controls.Add(this.nudMaxOutPerNum);
            this.chkWeb.Controls.Add(this.label40);
            this.chkWeb.Controls.Add(this.groupBox9);
            this.chkWeb.Controls.Add(this.groupBox8);
            this.chkWeb.Controls.Add(this.groupBox7);
            this.chkWeb.Controls.Add(this.gbWebPost);
            this.chkWeb.Location = new System.Drawing.Point(4, 22);
            this.chkWeb.Name = "chkWeb";
            this.chkWeb.Size = new System.Drawing.Size(766, 529);
            this.chkWeb.TabIndex = 2;
            this.chkWeb.Text = "第三步：发布内容设置";
            this.chkWeb.UseVisualStyleBackColor = true;
            // 
            // txtVisitUrlAfterEnd
            // 
            this.txtVisitUrlAfterEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVisitUrlAfterEnd.Location = new System.Drawing.Point(572, 500);
            this.txtVisitUrlAfterEnd.Name = "txtVisitUrlAfterEnd";
            this.txtVisitUrlAfterEnd.Size = new System.Drawing.Size(183, 21);
            this.txtVisitUrlAfterEnd.TabIndex = 9;
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(417, 503);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(149, 12);
            this.label41.TabIndex = 8;
            this.label41.Text = "发布完访问网页或执行程序";
            // 
            // chkSignSucessIfAllPost
            // 
            this.chkSignSucessIfAllPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSignSucessIfAllPost.AutoSize = true;
            this.chkSignSucessIfAllPost.Location = new System.Drawing.Point(419, 473);
            this.chkSignSucessIfAllPost.Name = "chkSignSucessIfAllPost";
            this.chkSignSucessIfAllPost.Size = new System.Drawing.Size(336, 16);
            this.chkSignSucessIfAllPost.TabIndex = 7;
            this.chkSignSucessIfAllPost.Text = "当所有的发布方式中所有配置都发布成功才标记数据为已发";
            this.chkSignSucessIfAllPost.UseVisualStyleBackColor = true;
            // 
            // chkNotWebOutIfFileNoDownLoad
            // 
            this.chkNotWebOutIfFileNoDownLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNotWebOutIfFileNoDownLoad.AutoSize = true;
            this.chkNotWebOutIfFileNoDownLoad.Location = new System.Drawing.Point(419, 448);
            this.chkNotWebOutIfFileNoDownLoad.Name = "chkNotWebOutIfFileNoDownLoad";
            this.chkNotWebOutIfFileNoDownLoad.Size = new System.Drawing.Size(168, 16);
            this.chkNotWebOutIfFileNoDownLoad.TabIndex = 6;
            this.chkNotWebOutIfFileNoDownLoad.Text = "文件未下载成功不发布内容";
            this.chkNotWebOutIfFileNoDownLoad.UseVisualStyleBackColor = true;
            // 
            // nudMaxOutPerNum
            // 
            this.nudMaxOutPerNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudMaxOutPerNum.Location = new System.Drawing.Point(624, 420);
            this.nudMaxOutPerNum.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.nudMaxOutPerNum.Name = "nudMaxOutPerNum";
            this.nudMaxOutPerNum.Size = new System.Drawing.Size(104, 21);
            this.nudMaxOutPerNum.TabIndex = 5;
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(417, 424);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(215, 12);
            this.label40.TabIndex = 4;
            this.label40.Text = "每次最大发布记录条数(0为全部发布)：";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox9.Controls.Add(this.chkFinishDeleteUrl);
            this.groupBox9.Controls.Add(this.chkFinishDeleteOutFaild);
            this.groupBox9.Controls.Add(this.chkFinishSignOutSucess);
            this.groupBox9.Controls.Add(this.chkFinishDeleteOutSucess);
            this.groupBox9.Location = new System.Drawing.Point(419, 353);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(310, 65);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "发布结束后(全部发布完成，暂停不算)";
            // 
            // chkFinishDeleteUrl
            // 
            this.chkFinishDeleteUrl.AutoSize = true;
            this.chkFinishDeleteUrl.Location = new System.Drawing.Point(158, 42);
            this.chkFinishDeleteUrl.Name = "chkFinishDeleteUrl";
            this.chkFinishDeleteUrl.Size = new System.Drawing.Size(120, 16);
            this.chkFinishDeleteUrl.TabIndex = 0;
            this.chkFinishDeleteUrl.Text = "清空该任务网址库";
            this.chkFinishDeleteUrl.UseVisualStyleBackColor = true;
            // 
            // chkFinishDeleteOutFaild
            // 
            this.chkFinishDeleteOutFaild.AutoSize = true;
            this.chkFinishDeleteOutFaild.Location = new System.Drawing.Point(158, 20);
            this.chkFinishDeleteOutFaild.Name = "chkFinishDeleteOutFaild";
            this.chkFinishDeleteOutFaild.Size = new System.Drawing.Size(144, 16);
            this.chkFinishDeleteOutFaild.TabIndex = 0;
            this.chkFinishDeleteOutFaild.Text = "删除所有未发成功数据";
            this.chkFinishDeleteOutFaild.UseVisualStyleBackColor = true;
            // 
            // chkFinishSignOutSucess
            // 
            this.chkFinishSignOutSucess.AutoSize = true;
            this.chkFinishSignOutSucess.Location = new System.Drawing.Point(6, 42);
            this.chkFinishSignOutSucess.Name = "chkFinishSignOutSucess";
            this.chkFinishSignOutSucess.Size = new System.Drawing.Size(132, 16);
            this.chkFinishSignOutSucess.TabIndex = 0;
            this.chkFinishSignOutSucess.Text = "标记所有记录为已发";
            this.chkFinishSignOutSucess.UseVisualStyleBackColor = true;
            // 
            // chkFinishDeleteOutSucess
            // 
            this.chkFinishDeleteOutSucess.AutoSize = true;
            this.chkFinishDeleteOutSucess.Location = new System.Drawing.Point(6, 20);
            this.chkFinishDeleteOutSucess.Name = "chkFinishDeleteOutSucess";
            this.chkFinishDeleteOutSucess.Size = new System.Drawing.Size(144, 16);
            this.chkFinishDeleteOutSucess.TabIndex = 0;
            this.chkFinishDeleteOutSucess.Text = "删除所有已发成功数据";
            this.chkFinishDeleteOutSucess.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.linkLabel5);
            this.groupBox8.Controls.Add(this.lvDatabase);
            this.groupBox8.Location = new System.Drawing.Point(418, 16);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(337, 307);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "方式三:导入到自定义数据库";
            // 
            // linkLabel5
            // 
            this.linkLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(128, 289);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(113, 12);
            this.linkLabel5.TabIndex = 1;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "数据库发布配置管理";
            // 
            // lvDatabase
            // 
            this.lvDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvDatabase.FormattingEnabled = true;
            this.lvDatabase.ItemHeight = 12;
            this.lvDatabase.Location = new System.Drawing.Point(6, 20);
            this.lvDatabase.Name = "lvDatabase";
            this.lvDatabase.Size = new System.Drawing.Size(325, 268);
            this.lvDatabase.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.ucHelper8);
            this.groupBox7.Controls.Add(this.linkLabel4);
            this.groupBox7.Controls.Add(this.cmbFileEncoding);
            this.groupBox7.Controls.Add(this.picMenu2);
            this.groupBox7.Controls.Add(this.rtbeFilenNameType);
            this.groupBox7.Controls.Add(this.button15);
            this.groupBox7.Controls.Add(this.button14);
            this.groupBox7.Controls.Add(this.txtFileTemplate);
            this.groupBox7.Controls.Add(this.txtFileSavePath);
            this.groupBox7.Controls.Add(this.cmbFileType);
            this.groupBox7.Controls.Add(this.label39);
            this.groupBox7.Controls.Add(this.label38);
            this.groupBox7.Controls.Add(this.label37);
            this.groupBox7.Controls.Add(this.label36);
            this.groupBox7.Controls.Add(this.label35);
            this.groupBox7.Controls.Add(this.chkFileOut);
            this.groupBox7.Location = new System.Drawing.Point(10, 329);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(367, 197);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "        方式二:保存为本地Word,Excel,Html,Txt等文件";
            // 
            // ucHelper8
            // 
            this.ucHelper8.HelperKey = "SaveFile";
            this.ucHelper8.Location = new System.Drawing.Point(340, 30);
            this.ucHelper8.Name = "ucHelper8";
            this.ucHelper8.Size = new System.Drawing.Size(16, 16);
            this.ucHelper8.TabIndex = 15;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(262, 169);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(77, 12);
            this.linkLabel4.TabIndex = 14;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "查看默认模板";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // cmbFileEncoding
            // 
            this.cmbFileEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileEncoding.Enabled = false;
            this.cmbFileEncoding.FormattingEnabled = true;
            this.cmbFileEncoding.Items.AddRange(new object[] {
            "UTF-8",
            "GB2312"});
            this.cmbFileEncoding.Location = new System.Drawing.Point(66, 161);
            this.cmbFileEncoding.Name = "cmbFileEncoding";
            this.cmbFileEncoding.Size = new System.Drawing.Size(155, 20);
            this.cmbFileEncoding.TabIndex = 13;
            // 
            // picMenu2
            // 
            this.picMenu2.Append = true;
            this.picMenu2.ContextMenuStrip = this.cmsNameStyle;
            this.picMenu2.Enabled = false;
            this.picMenu2.Location = new System.Drawing.Point(338, 125);
            this.picMenu2.Name = "picMenu2";
            this.picMenu2.OperationControl = this.rtbeFilenNameType;
            this.picMenu2.Pic = ((System.Drawing.Image)(resources.GetObject("picMenu2.Pic")));
            this.picMenu2.Size = new System.Drawing.Size(18, 18);
            this.picMenu2.TabIndex = 12;
            // 
            // cmsNameStyle
            // 
            this.cmsNameStyle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.任务名ToolStripMenuItem,
            this.随机文件名ToolStripMenuItem,
            this.任务IdToolStripMenuItem,
            this.yyyyMMddHHmmssToolStripMenuItem,
            this.记录IDToolStripMenuItem});
            this.cmsNameStyle.Name = "cmsNameStyle";
            this.cmsNameStyle.Size = new System.Drawing.Size(217, 114);
            // 
            // 任务名ToolStripMenuItem
            // 
            this.任务名ToolStripMenuItem.Name = "任务名ToolStripMenuItem";
            this.任务名ToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.任务名ToolStripMenuItem.Text = "[任务名]";
            // 
            // 随机文件名ToolStripMenuItem
            // 
            this.随机文件名ToolStripMenuItem.Name = "随机文件名ToolStripMenuItem";
            this.随机文件名ToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.随机文件名ToolStripMenuItem.Text = "[随机文件名]";
            // 
            // 任务IdToolStripMenuItem
            // 
            this.任务IdToolStripMenuItem.Name = "任务IdToolStripMenuItem";
            this.任务IdToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.任务IdToolStripMenuItem.Text = "[任务Id]";
            // 
            // yyyyMMddHHmmssToolStripMenuItem
            // 
            this.yyyyMMddHHmmssToolStripMenuItem.Name = "yyyyMMddHHmmssToolStripMenuItem";
            this.yyyyMMddHHmmssToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.yyyyMMddHHmmssToolStripMenuItem.Text = "yyyy-MM-dd HH-mm-ss";
            // 
            // 记录IDToolStripMenuItem
            // 
            this.记录IDToolStripMenuItem.Name = "记录IDToolStripMenuItem";
            this.记录IDToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.记录IDToolStripMenuItem.Text = "[记录Id]";
            // 
            // rtbeFilenNameType
            // 
            this.rtbeFilenNameType.Enabled = false;
            this.rtbeFilenNameType.FileName = true;
            this.rtbeFilenNameType.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeFilenNameType.LableList")));
            this.rtbeFilenNameType.Location = new System.Drawing.Point(66, 127);
            this.rtbeFilenNameType.Name = "rtbeFilenNameType";
            this.rtbeFilenNameType.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeFilenNameType.Size = new System.Drawing.Size(266, 22);
            this.rtbeFilenNameType.TabIndex = 11;
            this.rtbeFilenNameType.TextValue = "";
            this.rtbeFilenNameType.WordWrap = true;
            // 
            // button15
            // 
            this.button15.Enabled = false;
            this.button15.Location = new System.Drawing.Point(338, 92);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(25, 23);
            this.button15.TabIndex = 10;
            this.button15.Text = "选";
            this.button15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.Enabled = false;
            this.button14.Location = new System.Drawing.Point(337, 60);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(25, 23);
            this.button14.TabIndex = 9;
            this.button14.Text = "选";
            this.button14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // txtFileTemplate
            // 
            this.txtFileTemplate.Enabled = false;
            this.txtFileTemplate.Location = new System.Drawing.Point(66, 95);
            this.txtFileTemplate.Name = "txtFileTemplate";
            this.txtFileTemplate.Size = new System.Drawing.Size(266, 21);
            this.txtFileTemplate.TabIndex = 8;
            // 
            // txtFileSavePath
            // 
            this.txtFileSavePath.Location = new System.Drawing.Point(66, 62);
            this.txtFileSavePath.Name = "txtFileSavePath";
            this.txtFileSavePath.Size = new System.Drawing.Size(266, 21);
            this.txtFileSavePath.TabIndex = 7;
            // 
            // cmbFileType
            // 
            this.cmbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileType.Enabled = false;
            this.cmbFileType.FormattingEnabled = true;
            this.cmbFileType.Items.AddRange(new object[] {
            "一条记录保存为一个txt文件",
            "一条记录保存为一个html文件",
            "一条记录保存为一个Word文档",
            "所有记录保存在一个Csv文件",
            "所有记录保存在一个Excel文件",
            "所有记录保存为一个txt文件",
            "所有记录保存为一个html文件"});
            this.cmbFileType.Location = new System.Drawing.Point(66, 29);
            this.cmbFileType.Name = "cmbFileType";
            this.cmbFileType.Size = new System.Drawing.Size(266, 20);
            this.cmbFileType.TabIndex = 6;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 164);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(65, 12);
            this.label39.TabIndex = 5;
            this.label39.Text = "文件编码：";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 131);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 12);
            this.label38.TabIndex = 4;
            this.label38.Text = "名字格式：";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 98);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(65, 12);
            this.label37.TabIndex = 3;
            this.label37.Text = "文件模板：";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 65);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 12);
            this.label36.TabIndex = 2;
            this.label36.Text = "文件位置：";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 32);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 12);
            this.label35.TabIndex = 1;
            this.label35.Text = "文件格式：";
            // 
            // chkFileOut
            // 
            this.chkFileOut.AutoSize = true;
            this.chkFileOut.Location = new System.Drawing.Point(12, -1);
            this.chkFileOut.Name = "chkFileOut";
            this.chkFileOut.Size = new System.Drawing.Size(48, 16);
            this.chkFileOut.TabIndex = 0;
            this.chkFileOut.Text = "启用";
            this.chkFileOut.UseVisualStyleBackColor = true;
            this.chkFileOut.CheckedChanged += new System.EventHandler(this.chkFileOut_CheckedChanged);
            // 
            // gbWebPost
            // 
            this.gbWebPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbWebPost.Controls.Add(this.groupBox6);
            this.gbWebPost.Controls.Add(this.linkLabel3);
            this.gbWebPost.Controls.Add(this.btnModuleDelete);
            this.gbWebPost.Controls.Add(this.btnModuleEdit);
            this.gbWebPost.Controls.Add(this.btnModuleAdd);
            this.gbWebPost.Controls.Add(this.lvWebPost);
            this.gbWebPost.Controls.Add(this.chkWebOutput);
            this.gbWebPost.Location = new System.Drawing.Point(10, 16);
            this.gbWebPost.Name = "gbWebPost";
            this.gbWebPost.Size = new System.Drawing.Size(367, 307);
            this.gbWebPost.TabIndex = 0;
            this.gbWebPost.TabStop = false;
            this.gbWebPost.Text = "        方式一:Web在线发布到网站";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.ucHelper10);
            this.groupBox6.Controls.Add(this.rbWebOutType3);
            this.groupBox6.Controls.Add(this.rbWebOutType2);
            this.groupBox6.Controls.Add(this.rbWebOutType1);
            this.groupBox6.Controls.Add(this.rbWebOutType0);
            this.groupBox6.Location = new System.Drawing.Point(7, 255);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(350, 46);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "发布配置";
            // 
            // ucHelper10
            // 
            this.ucHelper10.HelperKey = "MultiPost";
            this.ucHelper10.Location = new System.Drawing.Point(327, 20);
            this.ucHelper10.Name = "ucHelper10";
            this.ucHelper10.Size = new System.Drawing.Size(16, 16);
            this.ucHelper10.TabIndex = 15;
            // 
            // rbWebOutType3
            // 
            this.rbWebOutType3.AutoSize = true;
            this.rbWebOutType3.Location = new System.Drawing.Point(218, 20);
            this.rbWebOutType3.Name = "rbWebOutType3";
            this.rbWebOutType3.Size = new System.Drawing.Size(107, 16);
            this.rbWebOutType3.TabIndex = 3;
            this.rbWebOutType3.Text = "多网站乱序发布";
            this.rbWebOutType3.UseVisualStyleBackColor = true;
            // 
            // rbWebOutType2
            // 
            this.rbWebOutType2.AutoSize = true;
            this.rbWebOutType2.Location = new System.Drawing.Point(147, 20);
            this.rbWebOutType2.Name = "rbWebOutType2";
            this.rbWebOutType2.Size = new System.Drawing.Size(71, 16);
            this.rbWebOutType2.TabIndex = 2;
            this.rbWebOutType2.Text = "乱序发布";
            this.rbWebOutType2.UseVisualStyleBackColor = true;
            // 
            // rbWebOutType1
            // 
            this.rbWebOutType1.AutoSize = true;
            this.rbWebOutType1.Location = new System.Drawing.Point(76, 20);
            this.rbWebOutType1.Name = "rbWebOutType1";
            this.rbWebOutType1.Size = new System.Drawing.Size(71, 16);
            this.rbWebOutType1.TabIndex = 1;
            this.rbWebOutType1.Text = "倒叙发布";
            this.rbWebOutType1.UseVisualStyleBackColor = true;
            // 
            // rbWebOutType0
            // 
            this.rbWebOutType0.AutoSize = true;
            this.rbWebOutType0.Checked = true;
            this.rbWebOutType0.Location = new System.Drawing.Point(5, 20);
            this.rbWebOutType0.Name = "rbWebOutType0";
            this.rbWebOutType0.Size = new System.Drawing.Size(71, 16);
            this.rbWebOutType0.TabIndex = 0;
            this.rbWebOutType0.TabStop = true;
            this.rbWebOutType0.Text = "正序发布";
            this.rbWebOutType0.UseVisualStyleBackColor = true;
            // 
            // linkLabel3
            // 
            this.linkLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(263, 232);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(95, 12);
            this.linkLabel3.TabIndex = 4;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Web发布配置管理";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // btnModuleDelete
            // 
            this.btnModuleDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModuleDelete.Enabled = false;
            this.btnModuleDelete.Location = new System.Drawing.Point(161, 226);
            this.btnModuleDelete.Name = "btnModuleDelete";
            this.btnModuleDelete.Size = new System.Drawing.Size(96, 23);
            this.btnModuleDelete.TabIndex = 3;
            this.btnModuleDelete.Text = "删除发布配置";
            this.btnModuleDelete.UseVisualStyleBackColor = true;
            this.btnModuleDelete.Click += new System.EventHandler(this.btnModuleDelete_Click);
            // 
            // btnModuleEdit
            // 
            this.btnModuleEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModuleEdit.Enabled = false;
            this.btnModuleEdit.Location = new System.Drawing.Point(87, 226);
            this.btnModuleEdit.Name = "btnModuleEdit";
            this.btnModuleEdit.Size = new System.Drawing.Size(71, 23);
            this.btnModuleEdit.TabIndex = 3;
            this.btnModuleEdit.Text = "修改分类";
            this.btnModuleEdit.UseVisualStyleBackColor = true;
            this.btnModuleEdit.Click += new System.EventHandler(this.btnModuleEdit_Click);
            // 
            // btnModuleAdd
            // 
            this.btnModuleAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModuleAdd.Location = new System.Drawing.Point(7, 226);
            this.btnModuleAdd.Name = "btnModuleAdd";
            this.btnModuleAdd.Size = new System.Drawing.Size(75, 23);
            this.btnModuleAdd.TabIndex = 2;
            this.btnModuleAdd.Text = "添加发布配置";
            this.btnModuleAdd.UseVisualStyleBackColor = true;
            this.btnModuleAdd.Click += new System.EventHandler(this.btnModuleAdd_Click);
            // 
            // lvWebPost
            // 
            this.lvWebPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvWebPost.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.lvWebPost.FullRowSelect = true;
            this.lvWebPost.GridLines = true;
            this.lvWebPost.Location = new System.Drawing.Point(6, 20);
            this.lvWebPost.Name = "lvWebPost";
            this.lvWebPost.ShowGroups = false;
            this.lvWebPost.Size = new System.Drawing.Size(351, 201);
            this.lvWebPost.TabIndex = 1;
            this.lvWebPost.UseCompatibleStateImageBehavior = false;
            this.lvWebPost.View = System.Windows.Forms.View.Details;
            this.lvWebPost.SelectedIndexChanged += new System.EventHandler(this.lvWebPost_SelectedIndexChanged);
            this.lvWebPost.DoubleClick += new System.EventHandler(this.lvWebPost_DoubleClick);
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "网站发布配置";
            this.columnHeader22.Width = 150;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "分类名称";
            this.columnHeader23.Width = 101;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "板块/分类ID";
            this.columnHeader24.Width = 79;
            // 
            // chkWebOutput
            // 
            this.chkWebOutput.AutoSize = true;
            this.chkWebOutput.Location = new System.Drawing.Point(10, -1);
            this.chkWebOutput.Name = "chkWebOutput";
            this.chkWebOutput.Size = new System.Drawing.Size(48, 16);
            this.chkWebOutput.TabIndex = 0;
            this.chkWebOutput.Text = "启用";
            this.chkWebOutput.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cmbPlugins);
            this.tabPage4.Controls.Add(this.label63);
            this.tabPage4.Controls.Add(this.gbFileDownSetting);
            this.tabPage4.Controls.Add(this.gbHtpp);
            this.tabPage4.Controls.Add(this.groupBox10);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(766, 529);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "文件保存及部分高级设置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cmbPlugins
            // 
            this.cmbPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlugins.FormattingEnabled = true;
            this.cmbPlugins.Location = new System.Drawing.Point(399, 17);
            this.cmbPlugins.Name = "cmbPlugins";
            this.cmbPlugins.Size = new System.Drawing.Size(247, 20);
            this.cmbPlugins.TabIndex = 4;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(340, 22);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(65, 12);
            this.label63.TabIndex = 3;
            this.label63.Text = "插件选择：";
            // 
            // gbFileDownSetting
            // 
            this.gbFileDownSetting.Controls.Add(this.ucHelper11);
            this.gbFileDownSetting.Controls.Add(this.btnBaseFileDirSelect);
            this.gbFileDownSetting.Controls.Add(this.nudDownloadSegments);
            this.gbFileDownSetting.Controls.Add(this.nudMaxDownload);
            this.gbFileDownSetting.Controls.Add(this.chkDownFileWithTools);
            this.gbFileDownSetting.Controls.Add(this.label62);
            this.gbFileDownSetting.Controls.Add(this.label61);
            this.gbFileDownSetting.Controls.Add(this.rbDownFile);
            this.gbFileDownSetting.Controls.Add(this.rbDownFileAsy);
            this.gbFileDownSetting.Controls.Add(this.txtFileUploadDomain);
            this.gbFileDownSetting.Controls.Add(this.txtBaseFileDir);
            this.gbFileDownSetting.Controls.Add(this.label60);
            this.gbFileDownSetting.Controls.Add(this.label59);
            this.gbFileDownSetting.Controls.Add(this.label58);
            this.gbFileDownSetting.Controls.Add(this.label57);
            this.gbFileDownSetting.Controls.Add(this.label56);
            this.gbFileDownSetting.Location = new System.Drawing.Point(10, 332);
            this.gbFileDownSetting.Name = "gbFileDownSetting";
            this.gbFileDownSetting.Size = new System.Drawing.Size(324, 191);
            this.gbFileDownSetting.TabIndex = 2;
            this.gbFileDownSetting.TabStop = false;
            this.gbFileDownSetting.Text = "文件下载设置";
            // 
            // ucHelper11
            // 
            this.ucHelper11.HelperKey = "DownMode";
            this.ucHelper11.Location = new System.Drawing.Point(272, 92);
            this.ucHelper11.Name = "ucHelper11";
            this.ucHelper11.Size = new System.Drawing.Size(16, 16);
            this.ucHelper11.TabIndex = 14;
            // 
            // btnBaseFileDirSelect
            // 
            this.btnBaseFileDirSelect.Location = new System.Drawing.Point(293, 24);
            this.btnBaseFileDirSelect.Name = "btnBaseFileDirSelect";
            this.btnBaseFileDirSelect.Size = new System.Drawing.Size(25, 23);
            this.btnBaseFileDirSelect.TabIndex = 13;
            this.btnBaseFileDirSelect.Text = "选";
            this.btnBaseFileDirSelect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBaseFileDirSelect.UseVisualStyleBackColor = true;
            this.btnBaseFileDirSelect.Click += new System.EventHandler(this.btnBaseFileDirSelect_Click);
            // 
            // nudDownloadSegments
            // 
            this.nudDownloadSegments.Location = new System.Drawing.Point(274, 123);
            this.nudDownloadSegments.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudDownloadSegments.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDownloadSegments.Name = "nudDownloadSegments";
            this.nudDownloadSegments.Size = new System.Drawing.Size(45, 21);
            this.nudDownloadSegments.TabIndex = 12;
            this.nudDownloadSegments.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudMaxDownload
            // 
            this.nudMaxDownload.Location = new System.Drawing.Point(120, 123);
            this.nudMaxDownload.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudMaxDownload.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxDownload.Name = "nudMaxDownload";
            this.nudMaxDownload.Size = new System.Drawing.Size(50, 21);
            this.nudMaxDownload.TabIndex = 11;
            this.nudMaxDownload.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkDownFileWithTools
            // 
            this.chkDownFileWithTools.AutoSize = true;
            this.chkDownFileWithTools.Location = new System.Drawing.Point(120, 158);
            this.chkDownFileWithTools.Name = "chkDownFileWithTools";
            this.chkDownFileWithTools.Size = new System.Drawing.Size(36, 16);
            this.chkDownFileWithTools.TabIndex = 10;
            this.chkDownFileWithTools.Text = "是";
            this.chkDownFileWithTools.UseVisualStyleBackColor = true;
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(170, 155);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(154, 33);
            this.label62.TabIndex = 9;
            this.label62.Text = "将在\"所有文件保存文件夹\"中生成 \"任务id.htm\"文件";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(173, 126);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(101, 12);
            this.label61.TabIndex = 9;
            this.label61.Text = "单文件下载分块数";
            // 
            // rbDownFile
            // 
            this.rbDownFile.AutoSize = true;
            this.rbDownFile.Checked = true;
            this.rbDownFile.Location = new System.Drawing.Point(181, 92);
            this.rbDownFile.Name = "rbDownFile";
            this.rbDownFile.Size = new System.Drawing.Size(47, 16);
            this.rbDownFile.TabIndex = 8;
            this.rbDownFile.TabStop = true;
            this.rbDownFile.Text = "同步";
            this.rbDownFile.UseVisualStyleBackColor = true;
            // 
            // rbDownFileAsy
            // 
            this.rbDownFileAsy.AutoSize = true;
            this.rbDownFileAsy.Location = new System.Drawing.Point(123, 92);
            this.rbDownFileAsy.Name = "rbDownFileAsy";
            this.rbDownFileAsy.Size = new System.Drawing.Size(47, 16);
            this.rbDownFileAsy.TabIndex = 7;
            this.rbDownFileAsy.Text = "异步";
            this.rbDownFileAsy.UseVisualStyleBackColor = true;
            // 
            // txtFileUploadDomain
            // 
            this.txtFileUploadDomain.Location = new System.Drawing.Point(120, 57);
            this.txtFileUploadDomain.Name = "txtFileUploadDomain";
            this.txtFileUploadDomain.Size = new System.Drawing.Size(168, 21);
            this.txtFileUploadDomain.TabIndex = 6;
            // 
            // txtBaseFileDir
            // 
            this.txtBaseFileDir.Location = new System.Drawing.Point(120, 24);
            this.txtBaseFileDir.Name = "txtBaseFileDir";
            this.txtBaseFileDir.Size = new System.Drawing.Size(168, 21);
            this.txtBaseFileDir.TabIndex = 5;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(6, 159);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(113, 12);
            this.label60.TabIndex = 4;
            this.label60.Text = "下载地址保存为文件";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(6, 126);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(113, 12);
            this.label59.TabIndex = 3;
            this.label59.Text = "同时最多文件下载数";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(42, 93);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(77, 12);
            this.label58.TabIndex = 2;
            this.label58.Text = "文件下载模式";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(18, 60);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(101, 12);
            this.label57.TabIndex = 1;
            this.label57.Text = "文件链接地址前缀";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(6, 27);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(113, 12);
            this.label56.TabIndex = 0;
            this.label56.Text = "所有文件保存文件夹";
            // 
            // gbHtpp
            // 
            this.gbHtpp.Controls.Add(this.tabControl3);
            this.gbHtpp.Location = new System.Drawing.Point(10, 171);
            this.gbHtpp.Name = "gbHtpp";
            this.gbHtpp.Size = new System.Drawing.Size(324, 155);
            this.gbHtpp.TabIndex = 1;
            this.gbHtpp.TabStop = false;
            this.gbHtpp.Text = "Http请求配置";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Controls.Add(this.tabPage13);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(3, 17);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(318, 135);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.nudProxyPort);
            this.tabPage2.Controls.Add(this.txtProxyPassword);
            this.tabPage2.Controls.Add(this.txtProxyUsername);
            this.tabPage2.Controls.Add(this.txtProxyServer);
            this.tabPage2.Controls.Add(this.label50);
            this.tabPage2.Controls.Add(this.label49);
            this.tabPage2.Controls.Add(this.label48);
            this.tabPage2.Controls.Add(this.label47);
            this.tabPage2.Controls.Add(this.rbProxyType2);
            this.tabPage2.Controls.Add(this.rbProxyType1);
            this.tabPage2.Controls.Add(this.rbProxyType0);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(310, 109);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Http代理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // nudProxyPort
            // 
            this.nudProxyPort.Enabled = false;
            this.nudProxyPort.Location = new System.Drawing.Point(204, 44);
            this.nudProxyPort.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.nudProxyPort.Name = "nudProxyPort";
            this.nudProxyPort.Size = new System.Drawing.Size(100, 21);
            this.nudProxyPort.TabIndex = 10;
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Enabled = false;
            this.txtProxyPassword.Location = new System.Drawing.Point(204, 71);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.Size = new System.Drawing.Size(100, 21);
            this.txtProxyPassword.TabIndex = 9;
            // 
            // txtProxyUsername
            // 
            this.txtProxyUsername.Enabled = false;
            this.txtProxyUsername.Location = new System.Drawing.Point(55, 71);
            this.txtProxyUsername.Name = "txtProxyUsername";
            this.txtProxyUsername.Size = new System.Drawing.Size(100, 21);
            this.txtProxyUsername.TabIndex = 8;
            // 
            // txtProxyServer
            // 
            this.txtProxyServer.Enabled = false;
            this.txtProxyServer.Location = new System.Drawing.Point(55, 43);
            this.txtProxyServer.Name = "txtProxyServer";
            this.txtProxyServer.Size = new System.Drawing.Size(100, 21);
            this.txtProxyServer.TabIndex = 7;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(165, 76);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(41, 12);
            this.label50.TabIndex = 6;
            this.label50.Text = "密码：";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(163, 47);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(41, 12);
            this.label49.TabIndex = 5;
            this.label49.Text = "端口：";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(7, 76);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(53, 12);
            this.label48.TabIndex = 4;
            this.label48.Text = "用户名：";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(7, 47);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(53, 12);
            this.label47.TabIndex = 3;
            this.label47.Text = "服务器：";
            // 
            // rbProxyType2
            // 
            this.rbProxyType2.AutoSize = true;
            this.rbProxyType2.Location = new System.Drawing.Point(214, 10);
            this.rbProxyType2.Name = "rbProxyType2";
            this.rbProxyType2.Size = new System.Drawing.Size(95, 16);
            this.rbProxyType2.TabIndex = 2;
            this.rbProxyType2.Text = "使用指定代理";
            this.rbProxyType2.UseVisualStyleBackColor = true;
            this.rbProxyType2.CheckedChanged += new System.EventHandler(this.rbProxyType2_CheckedChanged);
            // 
            // rbProxyType1
            // 
            this.rbProxyType1.AutoSize = true;
            this.rbProxyType1.Location = new System.Drawing.Point(130, 10);
            this.rbProxyType1.Name = "rbProxyType1";
            this.rbProxyType1.Size = new System.Drawing.Size(83, 16);
            this.rbProxyType1.TabIndex = 1;
            this.rbProxyType1.Text = "不使用代理";
            this.rbProxyType1.UseVisualStyleBackColor = true;
            // 
            // rbProxyType0
            // 
            this.rbProxyType0.AutoSize = true;
            this.rbProxyType0.Checked = true;
            this.rbProxyType0.Location = new System.Drawing.Point(9, 10);
            this.rbProxyType0.Name = "rbProxyType0";
            this.rbProxyType0.Size = new System.Drawing.Size(119, 16);
            this.rbProxyType0.TabIndex = 0;
            this.rbProxyType0.TabStop = true;
            this.rbProxyType0.Text = "使用IE浏览器代理";
            this.rbProxyType0.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtCredentialsPassword);
            this.tabPage3.Controls.Add(this.txtCredentialsDomain);
            this.tabPage3.Controls.Add(this.txtCredentialsUserName);
            this.tabPage3.Controls.Add(this.label53);
            this.tabPage3.Controls.Add(this.label52);
            this.tabPage3.Controls.Add(this.label51);
            this.tabPage3.Controls.Add(this.chkUseCredentials);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(310, 109);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "基于Windows身份验证";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtCredentialsPassword
            // 
            this.txtCredentialsPassword.Location = new System.Drawing.Point(211, 46);
            this.txtCredentialsPassword.Name = "txtCredentialsPassword";
            this.txtCredentialsPassword.Size = new System.Drawing.Size(93, 21);
            this.txtCredentialsPassword.TabIndex = 2;
            // 
            // txtCredentialsDomain
            // 
            this.txtCredentialsDomain.Location = new System.Drawing.Point(70, 70);
            this.txtCredentialsDomain.Name = "txtCredentialsDomain";
            this.txtCredentialsDomain.Size = new System.Drawing.Size(103, 21);
            this.txtCredentialsDomain.TabIndex = 2;
            // 
            // txtCredentialsUserName
            // 
            this.txtCredentialsUserName.Location = new System.Drawing.Point(70, 46);
            this.txtCredentialsUserName.Name = "txtCredentialsUserName";
            this.txtCredentialsUserName.Size = new System.Drawing.Size(103, 21);
            this.txtCredentialsUserName.TabIndex = 2;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(44, 73);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(29, 12);
            this.label53.TabIndex = 1;
            this.label53.Text = "域：";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(179, 49);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(41, 12);
            this.label52.TabIndex = 1;
            this.label52.Text = "密码：";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(21, 49);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(53, 12);
            this.label51.TabIndex = 1;
            this.label51.Text = "用户名：";
            // 
            // chkUseCredentials
            // 
            this.chkUseCredentials.AutoSize = true;
            this.chkUseCredentials.Location = new System.Drawing.Point(21, 16);
            this.chkUseCredentials.Name = "chkUseCredentials";
            this.chkUseCredentials.Size = new System.Drawing.Size(222, 16);
            this.chkUseCredentials.TabIndex = 0;
            this.chkUseCredentials.Text = "使用基于Windows身份验证类型的表单";
            this.chkUseCredentials.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.groupBox4);
            this.tabPage13.Controls.Add(this.chkKeepAlive);
            this.tabPage13.Controls.Add(this.chkGzip);
            this.tabPage13.Controls.Add(this.chkDeflate);
            this.tabPage13.Controls.Add(this.chkAutoDirect);
            this.tabPage13.Controls.Add(this.label55);
            this.tabPage13.Controls.Add(this.nudTimeOut);
            this.tabPage13.Controls.Add(this.label54);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(310, 109);
            this.tabPage13.TabIndex = 2;
            this.tabPage13.Text = "Http请求";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtAcceptLanguage);
            this.groupBox4.Location = new System.Drawing.Point(15, 50);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(155, 47);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Accept-Language";
            // 
            // txtAcceptLanguage
            // 
            this.txtAcceptLanguage.Location = new System.Drawing.Point(6, 18);
            this.txtAcceptLanguage.Name = "txtAcceptLanguage";
            this.txtAcceptLanguage.Size = new System.Drawing.Size(143, 21);
            this.txtAcceptLanguage.TabIndex = 0;
            this.txtAcceptLanguage.Text = "zh-cn,zh;";
            // 
            // chkKeepAlive
            // 
            this.chkKeepAlive.AutoSize = true;
            this.chkKeepAlive.Checked = true;
            this.chkKeepAlive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepAlive.Location = new System.Drawing.Point(189, 78);
            this.chkKeepAlive.Name = "chkKeepAlive";
            this.chkKeepAlive.Size = new System.Drawing.Size(84, 16);
            this.chkKeepAlive.TabIndex = 3;
            this.chkKeepAlive.Text = "Keep-Alive";
            this.chkKeepAlive.UseVisualStyleBackColor = true;
            // 
            // chkGzip
            // 
            this.chkGzip.AutoSize = true;
            this.chkGzip.Location = new System.Drawing.Point(261, 47);
            this.chkGzip.Name = "chkGzip";
            this.chkGzip.Size = new System.Drawing.Size(48, 16);
            this.chkGzip.TabIndex = 3;
            this.chkGzip.Text = "gzip";
            this.chkGzip.UseVisualStyleBackColor = true;
            // 
            // chkDeflate
            // 
            this.chkDeflate.AutoSize = true;
            this.chkDeflate.Location = new System.Drawing.Point(189, 47);
            this.chkDeflate.Name = "chkDeflate";
            this.chkDeflate.Size = new System.Drawing.Size(66, 16);
            this.chkDeflate.TabIndex = 3;
            this.chkDeflate.Text = "deflate";
            this.chkDeflate.UseVisualStyleBackColor = true;
            // 
            // chkAutoDirect
            // 
            this.chkAutoDirect.AutoSize = true;
            this.chkAutoDirect.Checked = true;
            this.chkAutoDirect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoDirect.Location = new System.Drawing.Point(189, 16);
            this.chkAutoDirect.Name = "chkAutoDirect";
            this.chkAutoDirect.Size = new System.Drawing.Size(72, 16);
            this.chkAutoDirect.TabIndex = 3;
            this.chkAutoDirect.Text = "自动跳转";
            this.chkAutoDirect.UseVisualStyleBackColor = true;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(153, 20);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(17, 12);
            this.label55.TabIndex = 2;
            this.label55.Text = "秒";
            // 
            // nudTimeOut
            // 
            this.nudTimeOut.Location = new System.Drawing.Point(91, 16);
            this.nudTimeOut.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTimeOut.Name = "nudTimeOut";
            this.nudTimeOut.Size = new System.Drawing.Size(57, 21);
            this.nudTimeOut.TabIndex = 1;
            this.nudTimeOut.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(13, 19);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(77, 12);
            this.label54.TabIndex = 0;
            this.label54.Text = "HTTP请求超时";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ucHelper9);
            this.groupBox10.Controls.Add(this.label46);
            this.groupBox10.Controls.Add(this.nudOutTimeEnd);
            this.groupBox10.Controls.Add(this.nudOutTimeStart);
            this.groupBox10.Controls.Add(this.nudOutThreadNum);
            this.groupBox10.Controls.Add(this.nudSpiderTimeInterval);
            this.groupBox10.Controls.Add(this.nudSpiderThreadNum);
            this.groupBox10.Controls.Add(this.label45);
            this.groupBox10.Controls.Add(this.label44);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Location = new System.Drawing.Point(10, 13);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(324, 152);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "任务运行时线程设置";
            // 
            // ucHelper9
            // 
            this.ucHelper9.HelperKey = "Thread";
            this.ucHelper9.Location = new System.Drawing.Point(283, 24);
            this.ucHelper9.Name = "ucHelper9";
            this.ucHelper9.Size = new System.Drawing.Size(16, 16);
            this.ucHelper9.TabIndex = 10;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(220, 120);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(17, 12);
            this.label46.TabIndex = 9;
            this.label46.Text = "到";
            // 
            // nudOutTimeEnd
            // 
            this.nudOutTimeEnd.Location = new System.Drawing.Point(240, 116);
            this.nudOutTimeEnd.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudOutTimeEnd.Name = "nudOutTimeEnd";
            this.nudOutTimeEnd.Size = new System.Drawing.Size(59, 21);
            this.nudOutTimeEnd.TabIndex = 8;
            this.nudOutTimeEnd.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // nudOutTimeStart
            // 
            this.nudOutTimeStart.Location = new System.Drawing.Point(151, 116);
            this.nudOutTimeStart.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudOutTimeStart.Name = "nudOutTimeStart";
            this.nudOutTimeStart.Size = new System.Drawing.Size(63, 21);
            this.nudOutTimeStart.TabIndex = 7;
            this.nudOutTimeStart.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // nudOutThreadNum
            // 
            this.nudOutThreadNum.Location = new System.Drawing.Point(151, 86);
            this.nudOutThreadNum.Name = "nudOutThreadNum";
            this.nudOutThreadNum.Size = new System.Drawing.Size(63, 21);
            this.nudOutThreadNum.TabIndex = 6;
            this.nudOutThreadNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudSpiderTimeInterval
            // 
            this.nudSpiderTimeInterval.Location = new System.Drawing.Point(151, 56);
            this.nudSpiderTimeInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudSpiderTimeInterval.Name = "nudSpiderTimeInterval";
            this.nudSpiderTimeInterval.Size = new System.Drawing.Size(63, 21);
            this.nudSpiderTimeInterval.TabIndex = 5;
            this.nudSpiderTimeInterval.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // nudSpiderThreadNum
            // 
            this.nudSpiderThreadNum.Location = new System.Drawing.Point(151, 26);
            this.nudSpiderThreadNum.Name = "nudSpiderThreadNum";
            this.nudSpiderThreadNum.Size = new System.Drawing.Size(63, 21);
            this.nudSpiderThreadNum.TabIndex = 4;
            this.nudSpiderThreadNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 118);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(149, 12);
            this.label45.TabIndex = 3;
            this.label45.Text = "发布内容间隔时间毫秒数：";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 87);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(149, 12);
            this.label44.TabIndex = 2;
            this.label44.Text = "单任务发布内容线程个数：";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 57);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(149, 12);
            this.label43.TabIndex = 1;
            this.label43.Text = "采集内容间隔时间毫秒数：";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 28);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(149, 12);
            this.label42.TabIndex = 0;
            this.label42.Text = "单任务采集内容线程个数：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbEncoding);
            this.panel1.Controls.Add(this.txtJobName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 32);
            this.panel1.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnSave);
            this.panel8.Controls.Add(this.btnCancel);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(5, 587);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(774, 34);
            this.panel8.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(623, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 22);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(700, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 22);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 621);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinimumSize = new System.Drawing.Size(800, 660);
            this.Name = "FrmJob";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建任务";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJob_FormClosing);
            this.Load += new System.EventHandler(this.FrmJob_Load);
            this.Resize += new System.EventHandler(this.FrmJob_Resize);
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbUrlTest.ResumeLayout(false);
            this.gbUrlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbUrlShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucCloseButton3)).EndInit();
            this.pStep1.ResumeLayout(false);
            this.pStep1Remarks.ResumeLayout(false);
            this.gbStep1url5.ResumeLayout(false);
            this.gbStep1url5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gbStep1url4.ResumeLayout(false);
            this.gbStep1url4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.cmsUserAgent.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.gbStep1url3.ResumeLayout(false);
            this.gbStep1url3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUrlRepeatCount)).EndInit();
            this.gbMultipleURLRule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucCloseButton1)).EndInit();
            this.tbMultipleURL.ResumeLayout(false);
            this.tpUrlGetOption.ResumeLayout(false);
            this.tpUrlGetOption.PerformLayout();
            this.gbResultFilter.ResumeLayout(false);
            this.gbResultFilter.PerformLayout();
            this.gbMultipleURLRegion.ResumeLayout(false);
            this.gbMultipleURLRegion.PerformLayout();
            this.pUrlManual.ResumeLayout(false);
            this.pUrlManual.PerformLayout();
            this.pUrlXpath.ResumeLayout(false);
            this.pUrlXpath.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.gbPostOption.ResumeLayout(false);
            this.gbPostOption.PerformLayout();
            this.pRandValue.ResumeLayout(false);
            this.pRandValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucCloseButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostStart)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.gbCombination.ResumeLayout(false);
            this.gbCombination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPagesMax)).EndInit();
            this.gbPageGet.ResumeLayout(false);
            this.gbPageGet.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.gbStep1url1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbStep1url2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tpLable.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.gbPagesCombine.ResumeLayout(false);
            this.gbPagesCombine.PerformLayout();
            this.gbPagesStyle.ResumeLayout(false);
            this.gbPagesStyle.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpiderPerNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPages)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbTestJob.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.cmsTest.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cmsDown.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.chkWeb.ResumeLayout(false);
            this.chkWeb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxOutPerNum)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.cmsNameStyle.ResumeLayout(false);
            this.gbWebPost.ResumeLayout(false);
            this.gbWebPost.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.gbFileDownSetting.ResumeLayout(false);
            this.gbFileDownSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownloadSegments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDownload)).EndInit();
            this.gbHtpp.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutTimeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutTimeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutThreadNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpiderTimeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpiderThreadNum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tpLable;
        private System.Windows.Forms.TabPage chkWeb;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbStep1url1;
        private System.Windows.Forms.GroupBox gbStep1url4;
        private System.Windows.Forms.GroupBox gbStep1url3;
        private System.Windows.Forms.GroupBox gbStep1url2;
        private System.Windows.Forms.Panel pStep1;
        private System.Windows.Forms.GroupBox gbStep1url5;
        private System.Windows.Forms.Panel pStep1Remarks;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnTestGetUrls;
        private System.Windows.Forms.ListBox lbUrl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStep1UrlClear;
        private System.Windows.Forms.Button btnStep1UrlDelete;
        private System.Windows.Forms.Button btnStep1UrlEdit;
        private System.Windows.Forms.Button btnStep1UrlAdd;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ListView lvMultilevelURL;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnStep1MultilevelUrlClear;
        private System.Windows.Forms.Button btnStep1MultilevelUrlDelete;
        private System.Windows.Forms.Button btnStep1MultilevelEdit;
        private System.Windows.Forms.Button btnStep1MultilevelUrlAdd;
        private UCHelper ucHelper1;
        private System.Windows.Forms.TextBox txtUserAgent;
        private System.Windows.Forms.TextBox txtLoginCookies;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudUrlRepeatCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkMultilevelURLTestOne;
        private System.Windows.Forms.CheckBox chkCheckUrl;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private UCHelper ucHelper2;
        private System.Windows.Forms.ContextMenuStrip cmsUserAgent;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem chromeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 安卓UCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 塞班ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iphoneSafriaToolStripMenuItem;
        private Ex.PicMenu picMenu1;
        private System.Windows.Forms.GroupBox gbMultipleURLRule;
        private System.Windows.Forms.TabControl tbMultipleURL;
        private System.Windows.Forms.TabPage tpUrlGetOption;
        private System.Windows.Forms.RadioButton rbGetUrlForXpath;
        private System.Windows.Forms.RadioButton rbGetUrlManualFillRule;
        private System.Windows.Forms.RadioButton rbGetUrlAtuo;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox gbMultipleURLRegion;
        private Ex.RichTextBoxEx rtbeUrlStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Ex.RichTextBoxEx rtbeUrlEnd;
        private Ex.UCLableText ucLableText2;
        private Ex.UCLableText ucLableText1;
        private System.Windows.Forms.GroupBox gbResultFilter;
        private Ex.UCLableText ucLableText3;
        private Ex.RichTextBoxEx rtbeUrlNotContain;
        private Ex.RichTextBoxEx rtbeUrlContain;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private Ex.UCLableText ucLableText6;
        private Ex.UCLableText ucLableText5;
        private Ex.UCLableText ucLableText4;
        private System.Windows.Forms.Button btnCancelUrlRule;
        private System.Windows.Forms.Button btnSaveUrlRule;
        private UCHelper ucHelper4;
        private UCHelper ucHelper3;
        private System.Windows.Forms.Panel pUrlManual;
        private Ex.UCLableText ucLableText7;
        private Ex.RichTextBoxEx rtbeUrlScriptRule;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Ex.UCLableText ucLableText9;
        private Ex.UCLableText ucLableText8;
        private Ex.RichTextBoxEx rtbxUrlResult;
        private Ex.UCLableText ucLableText11;
        private Ex.UCLableText ucLableText10;
        private System.Windows.Forms.Panel pUrlXpath;
        private System.Windows.Forms.Button btnGetXpath;
        private System.Windows.Forms.TextBox txtUrlXpath;
        private System.Windows.Forms.Label label13;
        private UserContorl.UCCloseButton ucCloseButton1;
        private System.Windows.Forms.GroupBox gbPostOption;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown nudPostEnd;
        private System.Windows.Forms.NumericUpDown nudPostStart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rbAspXPost;
        private System.Windows.Forms.RadioButton rbPost;
        private System.Windows.Forms.RadioButton rbGet;
        private Ex.RichTextBoxEx rtbePostData;
        private Ex.UCLableText ultPostRandValue;
        private Ex.UCLableText ultPagination;
        private System.Windows.Forms.Button btnPostValueDelete;
        private System.Windows.Forms.Button btnPostValueEdit;
        private System.Windows.Forms.Button btnPostValueAdd;
        private System.Windows.Forms.ListView lvPost;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.GroupBox gbCombination;
        private System.Windows.Forms.CheckBox chkAutoGetPage;
        private System.Windows.Forms.NumericUpDown nudPagesMax;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox gbPageGet;
        private Ex.UCLableText ucLableText12;
        private Ex.RichTextBoxEx rtbeListPageEnd;
        private Ex.UCLableText ucLableText13;
        private Ex.RichTextBoxEx rtbeListPageStart;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel7;
        private UCHelper ucHelper5;
        private Ex.RichTextBoxEx rtbeListPageStyle;
        private Ex.UCLableText ucLableText14;
        private Ex.RichTextBoxEx rtbeListPageUrlStyle;
        private Ex.UCLableText ucLableText15;
        private Ex.UCLableText ucLableText17;
        private Ex.UCLableText ucLableText18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private Ex.UCLableText ucLableText19;
        private Ex.RichTextBoxEx rtbeAdditionalparameter;
        private Ex.UCLableText ucLableText16;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pRandValue;
        private System.Windows.Forms.Button btnCancelRandValue;
        private System.Windows.Forms.Button btnSaveRandValue;
        private Ex.UCLableText ucLableText21;
        private Ex.RichTextBoxEx rtbeRandValueEnd;
        private Ex.UCLableText ucLableText20;
        private Ex.RichTextBoxEx rtbeRandValueStart;
        private UserContorl.UCCloseButton ucCloseButton2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox gbUrlTest;
        private System.Windows.Forms.Button btnCancelOption;
        private System.Windows.Forms.Button btnUrlClaer;
        private System.Windows.Forms.Button btnUrlDelete;
        private System.Windows.Forms.Button btnUrlTest;
        private System.Windows.Forms.Button btnSeeSourceCode;
        private System.Windows.Forms.Button btnUrlBrowse;
        private System.Windows.Forms.Button btnUrlCopyUrl;
        private System.Windows.Forms.Button btnUrlExportCurrentNode;
        private System.Windows.Forms.Button btnUrlExportFirst;
        private System.Windows.Forms.Button btnUrlExportRootNode;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TreeView tvUrlRule;
        private System.Windows.Forms.GroupBox gbUrlStatus;
        private System.Windows.Forms.Button btnUrlStop;
        private System.Windows.Forms.Label lblStaus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbUrlShow;
        private UserContorl.UCCloseButton ucCloseButton3;
        private Ex.RichTextBoxEx rtbeUrlShow;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox2;
        private Ex.RichTextBoxEx rtbePagesAreaEnd;
        private Ex.RichTextBoxEx rtbePagesAreaStart;
        private Ex.UCLableText ucLableText23;
        private System.Windows.Forms.Label label29;
        private Ex.UCLableText ucLableText22;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.RadioButton rbUpDownPage;
        private System.Windows.Forms.RadioButton rbPagesUrlListAll;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbPagesCombine;
        private Ex.UCLableText ucLableText27;
        private Ex.RichTextBoxEx rtbePagesCombine;
        private System.Windows.Forms.GroupBox gbPagesStyle;
        private Ex.UCLableText ucLableText25;
        private Ex.RichTextBoxEx rtbePagesStyle;
        private Ex.UCLableText ucLableText24;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.RadioButton rbManualPaging;
        private System.Windows.Forms.RadioButton rbGetPagesUrlAuto;
        private System.Windows.Forms.Button btnSortUp;
        private System.Windows.Forms.Button btnSortDown;
        private System.Windows.Forms.Button btnLabelImport;
        private System.Windows.Forms.Button btnLabelDelete;
        private System.Windows.Forms.Button btnLabelCopy;
        private System.Windows.Forms.Button btnLabelEdit;
        private System.Windows.Forms.Button btnLabelAdd;
        private Ex.RichTextBoxEx rtbeTestResult;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ComboBox cmbTestPageUrls;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ContextMenuStrip cmsTest;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView lvDown;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton rbLoopAddNewRecord;
        private UCHelper ucHelper6;
        private System.Windows.Forms.TextBox txtPagesJoinCode;
        private System.Windows.Forms.Label label32;
        private UCHelper ucHelper7;
        private Ex.RichTextBoxEx rtbeLoopJoinCode;
        private Ex.UCLableText ucLableText26;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown nudMaxSpiderPerNum;
        private System.Windows.Forms.NumericUpDown nudMaxPages;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestSend;
        private System.Windows.Forms.ToolStripMenuItem 在浏览器中查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取页面源代码ToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbWebPost;
        private System.Windows.Forms.CheckBox chkWebOutput;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbWebOutType3;
        private System.Windows.Forms.RadioButton rbWebOutType2;
        private System.Windows.Forms.RadioButton rbWebOutType1;
        private System.Windows.Forms.RadioButton rbWebOutType0;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Button btnModuleDelete;
        private System.Windows.Forms.Button btnModuleEdit;
        private System.Windows.Forms.Button btnModuleAdd;
        private System.Windows.Forms.ListView lvWebPost;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cmbFileType;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox chkFileOut;
        private Ex.PicMenu picMenu2;
        private Ex.RichTextBoxEx rtbeFilenNameType;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.TextBox txtFileTemplate;
        private System.Windows.Forms.TextBox txtFileSavePath;
        private UCHelper ucHelper8;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.ComboBox cmbFileEncoding;
        private System.Windows.Forms.ContextMenuStrip cmsNameStyle;
        private System.Windows.Forms.ToolStripMenuItem 任务名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 随机文件名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 任务IdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yyyyMMddHHmmssToolStripMenuItem;
        private System.Windows.Forms.TextBox txtVisitUrlAfterEnd;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.CheckBox chkSignSucessIfAllPost;
        private System.Windows.Forms.CheckBox chkNotWebOutIfFileNoDownLoad;
        private System.Windows.Forms.NumericUpDown nudMaxOutPerNum;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox chkFinishDeleteUrl;
        private System.Windows.Forms.CheckBox chkFinishDeleteOutFaild;
        private System.Windows.Forms.CheckBox chkFinishSignOutSucess;
        private System.Windows.Forms.CheckBox chkFinishDeleteOutSucess;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.ListBox lvDatabase;
        private System.Windows.Forms.GroupBox groupBox10;
        private UCHelper ucHelper9;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.NumericUpDown nudOutTimeEnd;
        private System.Windows.Forms.NumericUpDown nudOutTimeStart;
        private System.Windows.Forms.NumericUpDown nudOutThreadNum;
        private System.Windows.Forms.NumericUpDown nudSpiderTimeInterval;
        private System.Windows.Forms.NumericUpDown nudSpiderThreadNum;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.CheckBox chkFillLoopWithFirst;
        public System.Windows.Forms.ListView lvLable;
        private System.Windows.Forms.GroupBox gbHtpp;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown nudProxyPort;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.TextBox txtProxyUsername;
        private System.Windows.Forms.TextBox txtProxyServer;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.RadioButton rbProxyType2;
        private System.Windows.Forms.RadioButton rbProxyType1;
        private System.Windows.Forms.RadioButton rbProxyType0;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.TextBox txtCredentialsPassword;
        private System.Windows.Forms.TextBox txtCredentialsDomain;
        private System.Windows.Forms.TextBox txtCredentialsUserName;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.CheckBox chkUseCredentials;
        private System.Windows.Forms.ImageList imageListFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtbDownLog;
        private System.Windows.Forms.GroupBox gbTestJob;
        private System.Windows.Forms.Label lblTsetJobStatus;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Button btnMultPageChange;
        private UCHelper ucHelper10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtAcceptLanguage;
        private System.Windows.Forms.CheckBox chkKeepAlive;
        private System.Windows.Forms.CheckBox chkGzip;
        private System.Windows.Forms.CheckBox chkDeflate;
        private System.Windows.Forms.CheckBox chkAutoDirect;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.NumericUpDown nudTimeOut;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.ContextMenuStrip cmsDown;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拷贝地址ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开目录ToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbFileDownSetting;
        private UCHelper ucHelper11;
        private System.Windows.Forms.Button btnBaseFileDirSelect;
        private System.Windows.Forms.NumericUpDown nudDownloadSegments;
        private System.Windows.Forms.NumericUpDown nudMaxDownload;
        private System.Windows.Forms.CheckBox chkDownFileWithTools;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.RadioButton rbDownFile;
        private System.Windows.Forms.RadioButton rbDownFileAsy;
        private System.Windows.Forms.TextBox txtFileUploadDomain;
        private System.Windows.Forms.TextBox txtBaseFileDir;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ToolStripMenuItem 记录IDToolStripMenuItem;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cmbPlugins;
        private System.Windows.Forms.Label label63;
    }
}