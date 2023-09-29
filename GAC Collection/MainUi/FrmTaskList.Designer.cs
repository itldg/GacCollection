namespace GAC_Collection.MainUi
{
    partial class FrmTaskList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskList));
            this.ilTask = new System.Windows.Forms.ImageList(this.components);
            this.tvTask = new AdvancedDataGridView.TreeGridView();
            this.taskname = new AdvancedDataGridView.TreeGridColumn();
            this.taskurl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.taskcontent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tasksend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tasknew = new System.Windows.Forms.ToolStripMenuItem();
            this.runall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.CategoryAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.CategoryEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.CategoryDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CategoryImport = new System.Windows.Forms.ToolStripMenuItem();
            this.CategoryExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ImportTaskToCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteTaskToCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.BatchEditiCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsJob = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开始运行任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停任务运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止任务运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.编辑任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除任务支持多选DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.重新下载未成功下载的文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新上传未成功FTP上传的文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标记内容发布状态为未发ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标记内容发布状态为已发ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.本地编辑任务采集数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空任务所有采集数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开Data下任务文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.导出任务支持多选OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tvTask)).BeginInit();
            this.cmsCategory.SuspendLayout();
            this.cmsJob.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilTask
            // 
            this.ilTask.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTask.ImageStream")));
            this.ilTask.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTask.Images.SetKeyName(0, "tasklist");
            this.ilTask.Images.SetKeyName(1, "taskrun");
            this.ilTask.Images.SetKeyName(2, "taskready");
            this.ilTask.Images.SetKeyName(3, "tasksuspend");
            this.ilTask.Images.SetKeyName(4, "taskstop");
            this.ilTask.Images.SetKeyName(5, "folder.gif");
            this.ilTask.Images.SetKeyName(6, "folderopen.gif");
            this.ilTask.Images.SetKeyName(7, "Collection");
            // 
            // tvTask
            // 
            this.tvTask.AllowUserToAddRows = false;
            this.tvTask.AllowUserToDeleteRows = false;
            this.tvTask.AllowUserToResizeColumns = false;
            this.tvTask.AllowUserToResizeRows = false;
            this.tvTask.BackgroundColor = System.Drawing.Color.White;
            this.tvTask.ColumnHeadersHeight = 20;
            this.tvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tvTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskname,
            this.taskurl,
            this.taskcontent,
            this.tasksend});
            this.tvTask.ContextMenuStrip = this.cmsCategory;
            this.tvTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTask.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tvTask.ImageList = this.ilTask;
            this.tvTask.Location = new System.Drawing.Point(0, 0);
            this.tvTask.Name = "tvTask";
            this.tvTask.RowHeadersVisible = false;
            this.tvTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tvTask.Size = new System.Drawing.Size(297, 469);
            this.tvTask.TabIndex = 1;
            this.tvTask.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tvTask_CellClick);
            this.tvTask.DoubleClick += new System.EventHandler(this.tvTask_DoubleClick);
            this.tvTask.Enter += new System.EventHandler(this.TvTaskEnter);
            this.tvTask.Leave += new System.EventHandler(this.TvTaskLeave);
            // 
            // taskname
            // 
            this.taskname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.taskname.DefaultNodeImage = null;
            this.taskname.HeaderText = "分组&任务列表";
            this.taskname.Name = "taskname";
            this.taskname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // taskurl
            // 
            this.taskurl.FillWeight = 30F;
            this.taskurl.HeaderText = "采网址";
            this.taskurl.Name = "taskurl";
            this.taskurl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.taskurl.Width = 50;
            // 
            // taskcontent
            // 
            this.taskcontent.HeaderText = "采内容";
            this.taskcontent.Name = "taskcontent";
            this.taskcontent.Width = 50;
            // 
            // tasksend
            // 
            this.tasksend.HeaderText = "发布";
            this.tasksend.Name = "tasksend";
            this.tasksend.Width = 40;
            // 
            // cmsCategory
            // 
            this.cmsCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tasknew,
            this.runall,
            this.toolStripMenuItem1,
            this.CategoryAdd,
            this.CategoryEdit,
            this.CategoryDelete,
            this.toolStripSeparator3,
            this.CategoryImport,
            this.CategoryExport,
            this.toolStripMenuItem2,
            this.ImportTaskToCurrent,
            this.PasteTaskToCurrent,
            this.toolStripMenuItem3,
            this.BatchEditiCurrent});
            this.cmsCategory.Name = "cmsCategory";
            this.cmsCategory.Size = new System.Drawing.Size(197, 248);
            // 
            // tasknew
            // 
            this.tasknew.Name = "tasknew";
            this.tasknew.Size = new System.Drawing.Size(196, 22);
            this.tasknew.Text = "新建任务";
            this.tasknew.Click += new System.EventHandler(this.tasknew_Click);
            // 
            // runall
            // 
            this.runall.Name = "runall";
            this.runall.Size = new System.Drawing.Size(196, 22);
            this.runall.Text = "运行该分组下所有任务";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // CategoryAdd
            // 
            this.CategoryAdd.Name = "CategoryAdd";
            this.CategoryAdd.Size = new System.Drawing.Size(196, 22);
            this.CategoryAdd.Text = "新建分组";
            this.CategoryAdd.Click += new System.EventHandler(this.CategoryAdd_Click);
            // 
            // CategoryEdit
            // 
            this.CategoryEdit.Name = "CategoryEdit";
            this.CategoryEdit.Size = new System.Drawing.Size(196, 22);
            this.CategoryEdit.Text = "编辑分组";
            this.CategoryEdit.Click += new System.EventHandler(this.CategoryEdit_Click);
            // 
            // CategoryDelete
            // 
            this.CategoryDelete.Name = "CategoryDelete";
            this.CategoryDelete.Size = new System.Drawing.Size(196, 22);
            this.CategoryDelete.Text = "删除分组";
            this.CategoryDelete.Click += new System.EventHandler(this.CategoryDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(193, 6);
            // 
            // CategoryImport
            // 
            this.CategoryImport.Name = "CategoryImport";
            this.CategoryImport.Size = new System.Drawing.Size(196, 22);
            this.CategoryImport.Text = "导入分组规则";
            // 
            // CategoryExport
            // 
            this.CategoryExport.Name = "CategoryExport";
            this.CategoryExport.Size = new System.Drawing.Size(196, 22);
            this.CategoryExport.Text = "导出分组规则";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // ImportTaskToCurrent
            // 
            this.ImportTaskToCurrent.Name = "ImportTaskToCurrent";
            this.ImportTaskToCurrent.Size = new System.Drawing.Size(196, 22);
            this.ImportTaskToCurrent.Text = "导入任务至该分组";
            // 
            // PasteTaskToCurrent
            // 
            this.PasteTaskToCurrent.Name = "PasteTaskToCurrent";
            this.PasteTaskToCurrent.Size = new System.Drawing.Size(196, 22);
            this.PasteTaskToCurrent.Text = "粘贴任务至该分组";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 6);
            // 
            // BatchEditiCurrent
            // 
            this.BatchEditiCurrent.Enabled = false;
            this.BatchEditiCurrent.Name = "BatchEditiCurrent";
            this.BatchEditiCurrent.Size = new System.Drawing.Size(196, 22);
            this.BatchEditiCurrent.Text = "批量编辑分组下任务";
            // 
            // cmsJob
            // 
            this.cmsJob.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始运行任务ToolStripMenuItem,
            this.暂停任务运行ToolStripMenuItem,
            this.停止任务运行ToolStripMenuItem,
            this.toolStripSeparator1,
            this.编辑任务ToolStripMenuItem,
            this.复制任务ToolStripMenuItem,
            this.删除任务支持多选DToolStripMenuItem,
            this.toolStripSeparator2,
            this.重新下载未成功下载的文件ToolStripMenuItem,
            this.重新上传未成功FTP上传的文件ToolStripMenuItem,
            this.标记内容发布状态为未发ToolStripMenuItem,
            this.标记内容发布状态为已发ToolStripMenuItem,
            this.toolStripSeparator4,
            this.本地编辑任务采集数据ToolStripMenuItem,
            this.清空任务所有采集数据ToolStripMenuItem,
            this.打开Data下任务文件夹ToolStripMenuItem,
            this.toolStripSeparator5,
            this.导出任务支持多选OToolStripMenuItem});
            this.cmsJob.Name = "cmsCategory";
            this.cmsJob.Size = new System.Drawing.Size(241, 358);
            // 
            // 开始运行任务ToolStripMenuItem
            // 
            this.开始运行任务ToolStripMenuItem.Name = "开始运行任务ToolStripMenuItem";
            this.开始运行任务ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.开始运行任务ToolStripMenuItem.Text = "开始运行任务(T)";
            this.开始运行任务ToolStripMenuItem.Click += new System.EventHandler(this.开始运行任务ToolStripMenuItem_Click);
            // 
            // 暂停任务运行ToolStripMenuItem
            // 
            this.暂停任务运行ToolStripMenuItem.Name = "暂停任务运行ToolStripMenuItem";
            this.暂停任务运行ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.暂停任务运行ToolStripMenuItem.Text = "暂停任务运行(P)";
            // 
            // 停止任务运行ToolStripMenuItem
            // 
            this.停止任务运行ToolStripMenuItem.Name = "停止任务运行ToolStripMenuItem";
            this.停止任务运行ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.停止任务运行ToolStripMenuItem.Text = "停止任务运行(O)";
            this.停止任务运行ToolStripMenuItem.Click += new System.EventHandler(this.停止任务运行ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(237, 6);
            // 
            // 编辑任务ToolStripMenuItem
            // 
            this.编辑任务ToolStripMenuItem.Name = "编辑任务ToolStripMenuItem";
            this.编辑任务ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.编辑任务ToolStripMenuItem.Text = "编辑任务(E)";
            this.编辑任务ToolStripMenuItem.Click += new System.EventHandler(this.编辑任务ToolStripMenuItem_Click);
            // 
            // 复制任务ToolStripMenuItem
            // 
            this.复制任务ToolStripMenuItem.Name = "复制任务ToolStripMenuItem";
            this.复制任务ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.复制任务ToolStripMenuItem.Text = "复制任务(C)";
            // 
            // 删除任务支持多选DToolStripMenuItem
            // 
            this.删除任务支持多选DToolStripMenuItem.Name = "删除任务支持多选DToolStripMenuItem";
            this.删除任务支持多选DToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.删除任务支持多选DToolStripMenuItem.Text = "删除任务（支持多选）(D)";
            this.删除任务支持多选DToolStripMenuItem.Click += new System.EventHandler(this.删除任务支持多选DToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(237, 6);
            // 
            // 重新下载未成功下载的文件ToolStripMenuItem
            // 
            this.重新下载未成功下载的文件ToolStripMenuItem.Name = "重新下载未成功下载的文件ToolStripMenuItem";
            this.重新下载未成功下载的文件ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.重新下载未成功下载的文件ToolStripMenuItem.Text = "重新下载未成功下载的文件";
            // 
            // 重新上传未成功FTP上传的文件ToolStripMenuItem
            // 
            this.重新上传未成功FTP上传的文件ToolStripMenuItem.Name = "重新上传未成功FTP上传的文件ToolStripMenuItem";
            this.重新上传未成功FTP上传的文件ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.重新上传未成功FTP上传的文件ToolStripMenuItem.Text = "重新上传未成功FTP上传的文件";
            // 
            // 标记内容发布状态为未发ToolStripMenuItem
            // 
            this.标记内容发布状态为未发ToolStripMenuItem.Name = "标记内容发布状态为未发ToolStripMenuItem";
            this.标记内容发布状态为未发ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.标记内容发布状态为未发ToolStripMenuItem.Text = "标记内容发布状态为未发";
            this.标记内容发布状态为未发ToolStripMenuItem.Click += new System.EventHandler(this.标记内容发布状态为未发ToolStripMenuItem_Click);
            // 
            // 标记内容发布状态为已发ToolStripMenuItem
            // 
            this.标记内容发布状态为已发ToolStripMenuItem.Name = "标记内容发布状态为已发ToolStripMenuItem";
            this.标记内容发布状态为已发ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.标记内容发布状态为已发ToolStripMenuItem.Text = "标记内容发布状态为已发";
            this.标记内容发布状态为已发ToolStripMenuItem.Click += new System.EventHandler(this.标记内容发布状态为已发ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(237, 6);
            // 
            // 本地编辑任务采集数据ToolStripMenuItem
            // 
            this.本地编辑任务采集数据ToolStripMenuItem.Name = "本地编辑任务采集数据ToolStripMenuItem";
            this.本地编辑任务采集数据ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.本地编辑任务采集数据ToolStripMenuItem.Text = "本地编辑任务采集数据";
            // 
            // 清空任务所有采集数据ToolStripMenuItem
            // 
            this.清空任务所有采集数据ToolStripMenuItem.Name = "清空任务所有采集数据ToolStripMenuItem";
            this.清空任务所有采集数据ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.清空任务所有采集数据ToolStripMenuItem.Text = "清空任务所有采集数据";
            this.清空任务所有采集数据ToolStripMenuItem.Click += new System.EventHandler(this.清空任务所有采集数据ToolStripMenuItem_Click);
            // 
            // 打开Data下任务文件夹ToolStripMenuItem
            // 
            this.打开Data下任务文件夹ToolStripMenuItem.Name = "打开Data下任务文件夹ToolStripMenuItem";
            this.打开Data下任务文件夹ToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.打开Data下任务文件夹ToolStripMenuItem.Text = "打开Data下任务文件夹";
            this.打开Data下任务文件夹ToolStripMenuItem.Click += new System.EventHandler(this.打开Data下任务文件夹ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(237, 6);
            // 
            // 导出任务支持多选OToolStripMenuItem
            // 
            this.导出任务支持多选OToolStripMenuItem.Name = "导出任务支持多选OToolStripMenuItem";
            this.导出任务支持多选OToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.导出任务支持多选OToolStripMenuItem.Text = "导出任务（支持多选）(O)";
            // 
            // FrmTaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 469);
            this.Controls.Add(this.tvTask);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTaskList";
            this.Text = "任务列表树";
            this.Load += new System.EventHandler(this.FrmTaskList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tvTask)).EndInit();
            this.cmsCategory.ResumeLayout(false);
            this.cmsJob.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList ilTask;
        private AdvancedDataGridView.TreeGridColumn taskname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn taskurl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn taskcontent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tasksend;
        public AdvancedDataGridView.TreeGridView tvTask;
        private System.Windows.Forms.ContextMenuStrip cmsCategory;
        private System.Windows.Forms.ToolStripMenuItem tasknew;
        private System.Windows.Forms.ToolStripMenuItem runall;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CategoryAdd;
        private System.Windows.Forms.ToolStripMenuItem CategoryEdit;
        private System.Windows.Forms.ToolStripMenuItem CategoryDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CategoryImport;
        private System.Windows.Forms.ToolStripMenuItem CategoryExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ImportTaskToCurrent;
        private System.Windows.Forms.ToolStripMenuItem PasteTaskToCurrent;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem BatchEditiCurrent;
        private System.Windows.Forms.ContextMenuStrip cmsJob;
        private System.Windows.Forms.ToolStripMenuItem 开始运行任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停任务运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止任务运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 编辑任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除任务支持多选DToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 重新下载未成功下载的文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重新上传未成功FTP上传的文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标记内容发布状态为未发ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标记内容发布状态为已发ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 本地编辑任务采集数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空任务所有采集数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开Data下任务文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 导出任务支持多选OToolStripMenuItem;
    }
}