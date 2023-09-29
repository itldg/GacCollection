namespace GAC_Collection.MainUi.Task
{
    partial class FrmRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRun));
            this.lblStauts = new System.Windows.Forms.Label();
            this.rtbeLog = new GAC_Collection.Ex.RichTextBoxEx();
            this.lblSpiderType = new System.Windows.Forms.Label();
            this.pgSpider = new System.Windows.Forms.ProgressBar();
            this.lblSpiderProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStauts
            // 
            this.lblStauts.AutoSize = true;
            this.lblStauts.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblStauts.Location = new System.Drawing.Point(7, 7);
            this.lblStauts.Name = "lblStauts";
            this.lblStauts.Size = new System.Drawing.Size(77, 12);
            this.lblStauts.TabIndex = 0;
            this.lblStauts.Text = "正在初始化中";
            // 
            // rtbeLog
            // 
            this.rtbeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbeLog.IsLog = true;
            this.rtbeLog.LableList = ((System.Collections.Generic.List<string>)(resources.GetObject("rtbeLog.LableList")));
            this.rtbeLog.Location = new System.Drawing.Point(9, 31);
            this.rtbeLog.Name = "rtbeLog";
            this.rtbeLog.RealTimeRendering = false;
            this.rtbeLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbeLog.Size = new System.Drawing.Size(687, 242);
            this.rtbeLog.TabIndex = 1;
            this.rtbeLog.TextValue = "";
            this.rtbeLog.WordWrap = true;
            // 
            // lblSpiderType
            // 
            this.lblSpiderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpiderType.AutoSize = true;
            this.lblSpiderType.Location = new System.Drawing.Point(10, 284);
            this.lblSpiderType.Name = "lblSpiderType";
            this.lblSpiderType.Size = new System.Drawing.Size(53, 12);
            this.lblSpiderType.TabIndex = 2;
            this.lblSpiderType.Text = "采网址：";
            // 
            // pgSpider
            // 
            this.pgSpider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgSpider.Location = new System.Drawing.Point(57, 283);
            this.pgSpider.Name = "pgSpider";
            this.pgSpider.Size = new System.Drawing.Size(530, 16);
            this.pgSpider.TabIndex = 3;
            // 
            // lblSpiderProgress
            // 
            this.lblSpiderProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpiderProgress.Location = new System.Drawing.Point(593, 284);
            this.lblSpiderProgress.Name = "lblSpiderProgress";
            this.lblSpiderProgress.Size = new System.Drawing.Size(103, 12);
            this.lblSpiderProgress.TabIndex = 5;
            this.lblSpiderProgress.Text = "(0/0)";
            this.lblSpiderProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 415);
            this.Controls.Add(this.lblSpiderProgress);
            this.Controls.Add(this.pgSpider);
            this.Controls.Add(this.lblSpiderType);
            this.Controls.Add(this.rtbeLog);
            this.Controls.Add(this.lblStauts);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmRun";
            this.Text = "某某任务[正在运行]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRun_FormClosing);
            this.Load += new System.EventHandler(this.FrmRun_Load);
            this.Shown += new System.EventHandler(this.FrmRun_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStauts;
        private Ex.RichTextBoxEx rtbeLog;
        private System.Windows.Forms.Label lblSpiderType;
        private System.Windows.Forms.ProgressBar pgSpider;
        private System.Windows.Forms.Label lblSpiderProgress;
    }
}