namespace GAC_Collection
{
    partial class FrmTest
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.spOption = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvPost = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnBrowserView = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spOption)).BeginInit();
            this.spOption.Panel1.SuspendLayout();
            this.spOption.Panel2.SuspendLayout();
            this.spOption.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.BackColor = System.Drawing.SystemColors.Control;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.spOption);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.txtResult);
            this.scMain.Panel2.Controls.Add(this.btnBrowserView);
            this.scMain.Panel2.Controls.Add(this.btnTest);
            this.scMain.Panel2.Controls.Add(this.label1);
            this.scMain.Size = new System.Drawing.Size(699, 501);
            this.scMain.SplitterDistance = 234;
            this.scMain.TabIndex = 0;
            // 
            // spOption
            // 
            this.spOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spOption.Location = new System.Drawing.Point(0, 0);
            this.spOption.Name = "spOption";
            // 
            // spOption.Panel1
            // 
            this.spOption.Panel1.Controls.Add(this.groupBox1);
            // 
            // spOption.Panel2
            // 
            this.spOption.Panel2.Controls.Add(this.btnClear);
            this.spOption.Panel2.Controls.Add(this.btnSave);
            this.spOption.Panel2.Controls.Add(this.txtContent);
            this.spOption.Size = new System.Drawing.Size(699, 234);
            this.spOption.SplitterDistance = 524;
            this.spOption.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvPost);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可用标签-单击标签可修改对应标签值";
            // 
            // lvPost
            // 
            this.lvPost.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPost.FullRowSelect = true;
            this.lvPost.GridLines = true;
            this.lvPost.Location = new System.Drawing.Point(3, 17);
            this.lvPost.Name = "lvPost";
            this.lvPost.Size = new System.Drawing.Size(518, 214);
            this.lvPost.TabIndex = 0;
            this.lvPost.UseCompatibleStateImageBehavior = false;
            this.lvPost.View = System.Windows.Forms.View.Details;
            this.lvPost.SelectedIndexChanged += new System.EventHandler(this.lvPost_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "标签";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "值";
            this.columnHeader2.Width = 250;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(90, 204);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(17, 204);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "修改";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(3, 3);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(162, 198);
            this.txtContent.TabIndex = 0;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(7, 39);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(684, 212);
            this.txtResult.TabIndex = 2;
            // 
            // btnBrowserView
            // 
            this.btnBrowserView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowserView.Location = new System.Drawing.Point(577, 9);
            this.btnBrowserView.Name = "btnBrowserView";
            this.btnBrowserView.Size = new System.Drawing.Size(114, 27);
            this.btnBrowserView.TabIndex = 1;
            this.btnBrowserView.Text = "在浏览器查看结果";
            this.btnBrowserView.UseVisualStyleBackColor = true;
            this.btnBrowserView.Click += new System.EventHandler(this.btnBrowserView_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(487, 9);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(79, 27);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "测试发布";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "以下为提交后返回的结果↓";
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 501);
            this.Controls.Add(this.scMain);
            this.Name = "FrmTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "发布配置测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTest_FormClosing);
            this.Load += new System.EventHandler(this.FrmTest_Load);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.spOption.Panel1.ResumeLayout(false);
            this.spOption.Panel2.ResumeLayout(false);
            this.spOption.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spOption)).EndInit();
            this.spOption.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer spOption;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvPost;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnBrowserView;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label1;
    }
}