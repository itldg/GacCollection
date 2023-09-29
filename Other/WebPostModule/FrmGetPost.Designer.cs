namespace WebPostModule
{
    partial class FrmGetPost
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPostData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbenUtf8 = new System.Windows.Forms.LinkLabel();
            this.llengbk = new System.Windows.Forms.LinkLabel();
            this.btnGetData = new System.Windows.Forms.Button();
            this.ucHelper1 = new GacHelper.UCHelper();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请将使用数据包抓取工具获取的POST数据粘贴到文本框中，然后点击提取按钮";
            // 
            // txtPostData
            // 
            this.txtPostData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostData.Location = new System.Drawing.Point(12, 29);
            this.txtPostData.Multiline = true;
            this.txtPostData.Name = "txtPostData";
            this.txtPostData.Size = new System.Drawing.Size(572, 512);
            this.txtPostData.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据解码：";
            // 
            // lbenUtf8
            // 
            this.lbenUtf8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbenUtf8.AutoSize = true;
            this.lbenUtf8.Location = new System.Drawing.Point(78, 552);
            this.lbenUtf8.Name = "lbenUtf8";
            this.lbenUtf8.Size = new System.Drawing.Size(35, 12);
            this.lbenUtf8.TabIndex = 3;
            this.lbenUtf8.TabStop = true;
            this.lbenUtf8.Text = "Utf-8";
            this.lbenUtf8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbenUtf8_LinkClicked);
            // 
            // llengbk
            // 
            this.llengbk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llengbk.AutoSize = true;
            this.llengbk.Location = new System.Drawing.Point(119, 552);
            this.llengbk.Name = "llengbk";
            this.llengbk.Size = new System.Drawing.Size(23, 12);
            this.llengbk.TabIndex = 4;
            this.llengbk.TabStop = true;
            this.llengbk.Text = "Gbk";
            this.llengbk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llengbk_LinkClicked);
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Location = new System.Drawing.Point(511, 544);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 29);
            this.btnGetData.TabIndex = 5;
            this.btnGetData.Text = "提取";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // ucHelper1
            // 
            this.ucHelper1.HelperKey = null;
            this.ucHelper1.Location = new System.Drawing.Point(431, 7);
            this.ucHelper1.Name = "ucHelper1";
            this.ucHelper1.Size = new System.Drawing.Size(16, 16);
            this.ucHelper1.TabIndex = 6;
            // 
            // FrmGetPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 577);
            this.Controls.Add(this.ucHelper1);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.llengbk);
            this.Controls.Add(this.lbenUtf8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPostData);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmGetPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "程序自动提取数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPostData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lbenUtf8;
        private System.Windows.Forms.LinkLabel llengbk;
        private System.Windows.Forms.Button btnGetData;
        private GacHelper.UCHelper ucHelper1;
    }
}