using GacHelper;

namespace GAC_Collection.MainUi.Task
{
    partial class FrmMultiPage
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
            this.lbPages = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNewUrl = new System.Windows.Forms.TextBox();
            this.txtOldUrl = new System.Windows.Forms.TextBox();
            this.btnTestUrl = new System.Windows.Forms.Button();
            this.txtPageName = new System.Windows.Forms.TextBox();
            this.rbFromurl = new System.Windows.Forms.RadioButton();
            this.rbFromCode = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMatch = new System.Windows.Forms.TextBox();
            this.txtReg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pCode = new System.Windows.Forms.Panel();
            this.ucLableText4 = new GAC_Collection.Ex.UCLableText();
            this.rtbeMatch = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText3 = new GAC_Collection.Ex.UCLableText();
            this.ucLableText2 = new GAC_Collection.Ex.UCLableText();
            this.rtbeReg = new GAC_Collection.Ex.RichTextBoxEx();
            this.ucLableText1 = new GAC_Collection.Ex.UCLableText();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ucHelper1 = new UCHelper();
            this.panel1.SuspendLayout();
            this.pCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPages
            // 
            this.lbPages.FormattingEnabled = true;
            this.lbPages.ItemHeight = 12;
            this.lbPages.Location = new System.Drawing.Point(12, 5);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(124, 316);
            this.lbPages.TabIndex = 0;
            this.lbPages.SelectedIndexChanged += new System.EventHandler(this.lbPages_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(11, 328);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "新建";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(76, 328);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(61, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "页面名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "页面地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "注:使用第一种方法时该处使用正则替换";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "默认页地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "测试结果：";
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Location = new System.Drawing.Point(154, 192);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(123, 31);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "测试得到多页地址↓";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(282, 322);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(354, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtNewUrl
            // 
            this.txtNewUrl.Location = new System.Drawing.Point(155, 292);
            this.txtNewUrl.Name = "txtNewUrl";
            this.txtNewUrl.Size = new System.Drawing.Size(338, 21);
            this.txtNewUrl.TabIndex = 7;
            // 
            // txtOldUrl
            // 
            this.txtOldUrl.Location = new System.Drawing.Point(155, 249);
            this.txtOldUrl.Name = "txtOldUrl";
            this.txtOldUrl.Size = new System.Drawing.Size(292, 21);
            this.txtOldUrl.TabIndex = 7;
            // 
            // btnTestUrl
            // 
            this.btnTestUrl.Location = new System.Drawing.Point(452, 248);
            this.btnTestUrl.Name = "btnTestUrl";
            this.btnTestUrl.Size = new System.Drawing.Size(42, 23);
            this.btnTestUrl.TabIndex = 8;
            this.btnTestUrl.Text = "测试";
            this.btnTestUrl.UseVisualStyleBackColor = true;
            this.btnTestUrl.Click += new System.EventHandler(this.btnTestUrl_Click);
            // 
            // txtPageName
            // 
            this.txtPageName.Location = new System.Drawing.Point(213, 9);
            this.txtPageName.Name = "txtPageName";
            this.txtPageName.Size = new System.Drawing.Size(210, 21);
            this.txtPageName.TabIndex = 9;
            // 
            // rbFromurl
            // 
            this.rbFromurl.AutoSize = true;
            this.rbFromurl.Checked = true;
            this.rbFromurl.Location = new System.Drawing.Point(213, 45);
            this.rbFromurl.Name = "rbFromurl";
            this.rbFromurl.Size = new System.Drawing.Size(215, 16);
            this.rbFromurl.TabIndex = 11;
            this.rbFromurl.TabStop = true;
            this.rbFromurl.Text = "依据规则对默认页地址替换生成地址";
            this.rbFromurl.UseVisualStyleBackColor = true;
            this.rbFromurl.CheckedChanged += new System.EventHandler(this.rbFromurl_CheckedChanged);
            // 
            // rbFromCode
            // 
            this.rbFromCode.AutoSize = true;
            this.rbFromCode.Location = new System.Drawing.Point(213, 74);
            this.rbFromCode.Name = "rbFromCode";
            this.rbFromCode.Size = new System.Drawing.Size(191, 16);
            this.rbFromCode.TabIndex = 12;
            this.rbFromCode.Text = "在默认页源代码内采集得到地址";
            this.rbFromCode.UseVisualStyleBackColor = true;
            this.rbFromCode.CheckedChanged += new System.EventHandler(this.brFromCode_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMatch);
            this.panel1.Controls.Add(this.txtReg);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(155, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 76);
            this.panel1.TabIndex = 13;
            // 
            // txtMatch
            // 
            this.txtMatch.Location = new System.Drawing.Point(50, 43);
            this.txtMatch.Name = "txtMatch";
            this.txtMatch.Size = new System.Drawing.Size(287, 21);
            this.txtMatch.TabIndex = 1;
            // 
            // txtReg
            // 
            this.txtReg.Location = new System.Drawing.Point(50, 11);
            this.txtReg.Name = "txtReg";
            this.txtReg.Size = new System.Drawing.Size(287, 21);
            this.txtReg.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "替换为：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "将：";
            // 
            // pCode
            // 
            this.pCode.Controls.Add(this.ucLableText4);
            this.pCode.Controls.Add(this.ucLableText3);
            this.pCode.Controls.Add(this.ucLableText2);
            this.pCode.Controls.Add(this.ucLableText1);
            this.pCode.Controls.Add(this.rtbeMatch);
            this.pCode.Controls.Add(this.rtbeReg);
            this.pCode.Controls.Add(this.label9);
            this.pCode.Controls.Add(this.label8);
            this.pCode.Location = new System.Drawing.Point(155, 94);
            this.pCode.Name = "pCode";
            this.pCode.Size = new System.Drawing.Size(356, 90);
            this.pCode.TabIndex = 14;
            this.pCode.Visible = false;
            // 
            // ucLableText4
            // 
            this.ucLableText4.AutoSize = true;
            this.ucLableText4.Location = new System.Drawing.Point(284, 4);
            this.ucLableText4.Name = "ucLableText4";
            this.ucLableText4.OperationControl = this.rtbeMatch;
            this.ucLableText4.Size = new System.Drawing.Size(47, 12);
            this.ucLableText4.TabIndex = 2;
            this.ucLableText4.TabStop = true;
            this.ucLableText4.Text = "[参数N]";
            this.ucLableText4.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.ParameterN;
            // 
            // rtbeMatch
            // 
            this.rtbeMatch.Location = new System.Drawing.Point(181, 19);
            this.rtbeMatch.Name = "rtbeMatch";
            this.rtbeMatch.ParameterN = true;
            this.rtbeMatch.Size = new System.Drawing.Size(164, 68);
            this.rtbeMatch.TabIndex = 1;
            this.rtbeMatch.TextValue = "";
            this.rtbeMatch.WordWrap = true;
            // 
            // ucLableText3
            // 
            this.ucLableText3.AutoSize = true;
            this.ucLableText3.Location = new System.Drawing.Point(235, 4);
            this.ucLableText3.Name = "ucLableText3";
            this.ucLableText3.OperationControl = this.rtbeMatch;
            this.ucLableText3.Size = new System.Drawing.Size(47, 12);
            this.ucLableText3.TabIndex = 2;
            this.ucLableText3.TabStop = true;
            this.ucLableText3.Text = "[参数1]";
            this.ucLableText3.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Parameter1;
            // 
            // ucLableText2
            // 
            this.ucLableText2.AutoSize = true;
            this.ucLableText2.Location = new System.Drawing.Point(89, 4);
            this.ucLableText2.Name = "ucLableText2";
            this.ucLableText2.OperationControl = this.rtbeReg;
            this.ucLableText2.Size = new System.Drawing.Size(41, 12);
            this.ucLableText2.TabIndex = 2;
            this.ucLableText2.TabStop = true;
            this.ucLableText2.Text = "[参数]";
            this.ucLableText2.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Parameter;
            // 
            // rtbeReg
            // 
            this.rtbeReg.Asterisk = true;
            this.rtbeReg.Location = new System.Drawing.Point(4, 19);
            this.rtbeReg.Name = "rtbeReg";
            this.rtbeReg.Parameter = true;
            this.rtbeReg.Size = new System.Drawing.Size(164, 68);
            this.rtbeReg.TabIndex = 1;
            this.rtbeReg.TextValue = "";
            this.rtbeReg.WordWrap = true;
            // 
            // ucLableText1
            // 
            this.ucLableText1.AutoSize = true;
            this.ucLableText1.Location = new System.Drawing.Point(131, 4);
            this.ucLableText1.Name = "ucLableText1";
            this.ucLableText1.OperationControl = this.rtbeReg;
            this.ucLableText1.Size = new System.Drawing.Size(23, 12);
            this.ucLableText1.TabIndex = 2;
            this.ucLableText1.TabStop = true;
            this.ucLableText1.Text = "(*)";
            this.ucLableText1.ValueType = GAC_Collection.Ex.UCLableText.VauleSelect.Asterisk;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(179, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "组合结果：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "正则匹配内容：";
            // 
            // ucHelper1
            // 
            this.ucHelper1.HelperKey = "MultiPage";
            this.ucHelper1.Location = new System.Drawing.Point(429, 12);
            this.ucHelper1.Name = "ucHelper1";
            this.ucHelper1.Size = new System.Drawing.Size(16, 16);
            this.ucHelper1.TabIndex = 10;
            // 
            // FrmMultiPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 359);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbFromCode);
            this.Controls.Add(this.rbFromurl);
            this.Controls.Add(this.ucHelper1);
            this.Controls.Add(this.txtPageName);
            this.Controls.Add(this.btnTestUrl);
            this.Controls.Add(this.txtOldUrl);
            this.Controls.Add(this.txtNewUrl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbPages);
            this.Controls.Add(this.pCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMultiPage";
            this.Text = "多页管理";
            this.Load += new System.EventHandler(this.FrmMultiPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pCode.ResumeLayout(false);
            this.pCode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPages;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNewUrl;
        private System.Windows.Forms.TextBox txtOldUrl;
        private System.Windows.Forms.Button btnTestUrl;
        private System.Windows.Forms.TextBox txtPageName;
        private UCHelper ucHelper1;
        private System.Windows.Forms.RadioButton rbFromurl;
        private System.Windows.Forms.RadioButton rbFromCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMatch;
        private System.Windows.Forms.TextBox txtReg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pCode;
        private Ex.UCLableText ucLableText4;
        private Ex.RichTextBoxEx rtbeMatch;
        private Ex.UCLableText ucLableText3;
        private Ex.UCLableText ucLableText2;
        private Ex.RichTextBoxEx rtbeReg;
        private Ex.UCLableText ucLableText1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}