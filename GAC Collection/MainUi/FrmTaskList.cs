using AdvancedDataGridView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using GAC_Collection.Common;
using GAC_Collection.Class;

namespace GAC_Collection.MainUi
{

    public partial class FrmTaskList : DockContent
    {
        SystemCommon Common;
        JobDB jobdb = new JobDB();
        public FrmTaskList(SystemCommon Common)
        {
            CheckCategory += CheckCategoryConsole;
            this.Common = Common;
            InitializeComponent();
        }
     
        private void FrmTaskList_Load(object sender, EventArgs e)
        {
            TreeGridNode node = tvTask.Nodes.Add("任务队列管理", false, false, false);
            node.ImageIndex = 0;
            node.Height = 20;
            node.DefaultCellStyle.BackColor = Color.LightBlue;
            node.Nodes.Add("运行中的任务", false, false, false).ImageIndex=1;
            node.Nodes.Add("就绪中的任务", false, false, false).ImageIndex = 2;
            node.Nodes.Add("暂停的任务", false, false, false).ImageIndex = 3;
            node.Nodes.Add("停止的任务", false, false, false).ImageIndex = 4;
            //node = tvTask.Nodes.Add("测试分类1", false, false, false);
            //node.ImageIndex = 5;
            // node.Nodes.Add("测试子分类1", true, false, false).ImageIndex = 5;
            //node.Nodes.Add("测试子分类2", true, false, false).ImageIndex = 5;
            //tvTask.Nodes.Add("测试分类2", false, false, false).ImageIndex = 5;
            //AddCategory();
            ShowNode();
        }
        
        #region 分组增改删
        public void AddCategory()
        {

            int action = (tvTask.SelectedRows.Count==1 & tvTask.SelectedRows[0].Tag != null & tvTask.SelectedRows[0].Tag is RuleCategory) ? 1 : 0;
            RuleCategory RuleCategory = null;
            MainUi.Task.FrmCategory frmadd = null;
            if (action == 0)
            {
                frmadd = new Task.FrmCategory();
            }
            else
            {
                RuleCategory = (RuleCategory)tvTask.SelectedRows[0].Tag;
                frmadd = new Task.FrmCategory(1, RuleCategory);
            }
           
            if (frmadd.ShowDialog(this) == DialogResult.OK)
            {
                RuleCategory Category = (RuleCategory)frmadd.Tag;
                //TreeGridNodeCollection tnc = null;
                //if (Category.ParentId == 0)
                //{
                //    tnc = tvTask.Nodes;
                //}
                //else
                //{
                //    tnc = GetNode(tvTask.Nodes, Category.ParentId);
                //}

                //int id = 0;
                //if (tnc.Count > 0)
                //{
                //    id = ((RuleCategory)tnc[tnc.Count - 1].Tag).Id + 1;
                //}
                //else
                //{
                //    id = Convert.ToInt32( Category.ParentId + "00" + 1);
                //}
                CategoryDB rules = new CategoryDB();
                bool result=rules.CategoryAdd(Category);
                if (result)
                {
                    ShowNode();
                }
                MessageBox.Show(result ? "添加成功！" : "添加失败！");
                //TreeGridNode node = tnc.Add(Category.Name, false, false, false);
                //Category.Id = id;
                //node.Tag = Category;
                //node.ImageIndex = 5;

            }
        }
        public void EditCategory()
        {
            if (tvTask.SelectedRows!=null&&tvTask.SelectedRows.Count==1&& tvTask.SelectedRows[0].Tag is RuleCategory)
            {
                RuleCategory category = (RuleCategory)tvTask.SelectedRows[0].Tag;
                int parentid = category.ParentId;
                MainUi.Task.FrmCategory frmadd = new Task.FrmCategory(2, category);
                if (frmadd.ShowDialog(this) == DialogResult.OK)
                {
                    
                    
                    RuleCategory categorytemp= (RuleCategory)frmadd.Tag;
                    CategoryDB rules = new CategoryDB();
                    bool result = rules.CategoryUpdate(categorytemp);
                    if(result)
                    { 
                        tvTask.SelectedRows[0].Cells[0].Value = categorytemp.Name;
                        if (parentid != categorytemp.ParentId)
                        {
                            //TreeGridNodeCollection tnc = GetNodes(parentid);
                            //TreeGridNode node = GetNode(categorytemp.Id);
                            //tnc.Remove(node);
                            DeleteCategory(parentid, categorytemp.Id);
                            ShowNode();
                            //TreeGridNode node = tnc.Add(categorytemp.Name, categorytemp.GetUrl, categorytemp.GetContent, categorytemp.Send);
                            //node.Tag = categorytemp;
                            //node.ImageIndex = 5;
                            //tvTask.Nodes.RemoveAt(tvTask.SelectedRows[0].Index);
                            //tvTask.rows[tvTask.SelectedRows[0].Index].
                        }
                    }
                    MessageBox.Show(result ? "修该成功！" : "修该失败！");
                }
            }
        }
        private void DeleteCategory(int ParentId, int Id)
        {
            TreeGridNodeCollection tgnc = tvTask.Nodes;
            if (ParentId > 0)
            {
                tgnc = GetNodes(ParentId);
            }
            TreeGridNode tgn = GetNode(Id);
            tgnc.Remove(tgn);
        }

        public void DeleteCategory()
        {
            if (MessageBox.Show("您是否确认要删除选择的分类么？？？", "谨慎操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CategoryDB rules = new CategoryDB();
                int count = 0;
                for (int i = tvTask.SelectedRows.Count - 1; i >= 0; i--)
                {
                    if (tvTask.SelectedRows[i].Tag == null) continue;
                    RuleCategory ruleCategory = (RuleCategory)tvTask.SelectedRows[i].Tag;
                    TreeGridNodeCollection tgnc = GetNodes(ruleCategory.Id);
                    if (tgnc.Count > 0)
                    {
                        continue;
                    }
                    bool result = rules.CategoryDelete(ruleCategory.Id);
                    if (result)
                    {
                        count++;
                        //tgnc = GetNodes(ruleCategory.ParentId);
                        //TreeGridNode tgn = GetNode( ruleCategory.Id);
                        //tgnc.Remove(tgn);
                        DeleteCategory(ruleCategory.ParentId, ruleCategory.Id);
                    }
                }
                if (count < tvTask.SelectedRows.Count)
                {
                    MessageBox.Show("未能全部删除成功，请检查：\r\n1.分类中是否有子分类或者规则没有清除");
                }
                else
                {
                    MessageBox.Show("删除成功！");
                }

            }

        }
        #endregion

        #region 任务增改删
        public void AddJob()
        {
            if (tvTask.SelectedRows.Count == 1 & tvTask.SelectedRows[0].Tag != null & tvTask.SelectedRows[0].Tag is RuleCategory)
            {
                //RuleCategory RuleCategory = (RuleCategory)tvTask.SelectedRows[0].Tag; ;
                int ParentId = GetParentId();
                Task.FrmJob job = new Task.FrmJob(ParentId);
                if (job.ShowDialog() == DialogResult.OK)
                {
                    ClassJob classJob = (ClassJob)job.Tag;
                    int jobid = SaveJob(classJob);
                    if (jobid>0)
                    {
                        TreeGridNodeCollection tgnc= GetNodes(ParentId);
                        classJob.JobId = jobid;
                        TreeGridNode tgn = tgnc.Add(classJob.JobName, classJob.SpiderUrl, classJob.SpiderContent, classJob.OutContent);
                        tgn.Tag = classJob;
                        tgn.ImageIndex = 7;
                        GacDB gacdb = new GacDB();
                        gacdb.ConvertDb(jobid, classJob.XmlData);
                        MessageBox.Show("新增成功!", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("新增失败!", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                }
            }
        }
        private void EditJob()
        {
            if (tvTask.SelectedRows.Count == 1 & tvTask.SelectedRows[0].Tag != null & tvTask.SelectedRows[0].Tag is ClassJob)
            {
                ClassJob ClassJob = (ClassJob)tvTask.SelectedRows[0].Tag; ;
                int ParentId = GetParentId();
                Task.FrmJob job = new Task.FrmJob(ClassJob, ParentId);
                if (job.ShowDialog() == DialogResult.OK)
                {
                    ClassJob classJob = (ClassJob)job.Tag;
                    if (SaveJob(classJob)>0)
                    {
                        tvTask.SelectedRows[0].Tag = classJob;
                        tvTask.SelectedRows[0].Cells[0].Value= classJob.JobName;
                        //tvTask.SelectedRows[0].
                        // tvTask.Nodes[tvTask.SelectedRows[0].Index].Nodes[0].nam = classJob.JobName;
                        GacDB gacdb = new GacDB();
                        gacdb.ConvertDb(ClassJob.JobId, classJob.XmlData);
                        MessageBox.Show("保存成功!", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("保存失败!", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private int SaveJob(ClassJob Job)
        {
            JobDB jobdb = new JobDB();
            int result = jobdb.JobUpdate(Job);
            GacDB gacdb = new GacDB();
            gacdb.ConvertDb(result, Job.XmlData);
            return result;
        }
        #endregion

        #region 获取当前分组的Nodes或者Node

        private TreeGridNodeCollection GetNodes( int ParentId, TreeGridNodeCollection Nodes=null)
        {
            if (ParentId==0)
            {
                return tvTask.Nodes;
            }
            if (Nodes == null)
            {
                Nodes = tvTask.Nodes;
            }
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].Tag == null) continue;
                if (((RuleCategory)Nodes[i].Tag).Id == ParentId)
                {
                    return Nodes[i].Nodes;
                }
                if(Nodes[i].Nodes.Count>0)
                { 
                    TreeGridNodeCollection nodes = GetNodes(ParentId, (Nodes[i].Nodes));
                    if (nodes!=null)
                    {
                        return nodes;
                    }
                }
            }
            return null;
        }

        private TreeGridNode GetNode( int ID, TreeGridNodeCollection Nodes=null)
        {
            if (Nodes==null)
            {
                Nodes = tvTask.Nodes;
            }
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].Tag == null) continue;
                if (((RuleCategory)Nodes[i].Tag).Id ==ID )
                {
                    return Nodes[i];
                }
                if (Nodes[i].Nodes.Count > 0)
                {
                    TreeGridNode node = GetNode( ID, Nodes[i].Nodes);
                    
                    if (node != null)
                    {
                        return node;
                    }
                }
            }
            return null;
        }
        private TreeGridNode GetNodeForJob(int ID, TreeGridNodeCollection Nodes = null)
        {
            if (Nodes == null)
            {
                Nodes = tvTask.Nodes;
            }
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].Tag == null) continue;
                if (Nodes[i].Tag is ClassJob)
                {
                    if (((ClassJob)Nodes[i].Tag).JobId == ID)
                    {
                        return Nodes[i];
                    }
                }
                if (Nodes[i].Nodes.Count > 0)
                {
                    TreeGridNode node = GetNodeForJob(ID, Nodes[i].Nodes);

                    if (node != null)
                    {
                        return node;
                    }
                }
            }
            return null;
        }

        private int GetParentId(TreeGridNodeCollection Nodes = null)
        {
            
            if (Nodes == null)
            {
                Nodes = tvTask.Nodes;
                if (tvTask.SelectedRows==null)
                {
                    return -1;
                }
            }
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].Tag == null) continue;

                if (Nodes[i].Nodes.Count > 0)
                {
                    int id = ((RuleCategory)Nodes[i].Tag).Id;
                    if (tvTask.SelectedRows[0] == Nodes[i])
                    {
                        return id;
                    }
                    foreach (var item in Nodes[i].Nodes)
                    {
                        if (item== tvTask.SelectedRows[0])
                        {
                            return id;
                        }
                    }
                    int result = GetParentId(Nodes[i].Nodes);
                    if (result != -1)
                    {
                        return result;
                    }
                }
            }
            return -1;
        }
        #endregion

        #region 展示分组和任务
        public void ShowNode(CategoryDB rules=null, int ParentID=0, TreeGridNodeCollection nodes=null)
        {
            if (rules == null)
            {
                rules = new CategoryDB();
            }
            if (nodes == null)
            {
                nodes = tvTask.Nodes;
            }
           
            List<RuleCategory> ruleCategorys = rules.CategoryGet(ParentID);
            for (int i = 0; i < ruleCategorys.Count; i++)
            {
              
                bool exist = false;
                for (int i2 = 0; i2 < nodes.Count; i2++)
                {
                    if (nodes[i2].Tag!=null && nodes[i2].Tag is RuleCategory && ((RuleCategory)nodes[i2].Tag).Id==ruleCategorys[i].Id)
                    {
                        ShowNode(rules, ruleCategorys[i].Id, nodes[i2].Nodes);
                        exist = true;
                    }
                }
                if (!exist)
                {
                    TreeGridNode node = nodes.Add(ruleCategorys[i].Name, ruleCategorys[i].GetUrl, ruleCategorys[i].GetContent, ruleCategorys[i].Send);
                    node.Tag = ruleCategorys[i];
                    if (ruleCategorys[i].RuleType)
                    {
                        node.ImageIndex = 5;
                        node.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        node.ImageIndex = 7;

                    }
                    ShowNode(rules, ruleCategorys[i].Id, node.Nodes);
                    ShowJob(ruleCategorys[i].Id, node.Nodes);
                }

            }
           
        }
        public void ShowJob(int CategoryID , TreeGridNodeCollection nodes)
        {

            List<ClassJob> jobs = jobdb.JobGetList(CategoryID);
            for (int i = 0; i < jobs.Count; i++)
            {

                bool exist = false;
                for (int i2 = 0; i2 < nodes.Count; i2++)
                {
                    if (nodes[i2].Tag != null && nodes[i2].Tag is ClassJob && ((ClassJob)nodes[i2].Tag).JobId == jobs[i].JobId)
                    {
                        exist = true;
                    }
                }
                if (!exist)
                {
                    TreeGridNode node = nodes.Add(jobs[i].JobName, jobs[i].SpiderUrl, jobs[i].SpiderContent, jobs[i].OutContent);
                    node.Tag = jobs[i];
                    node.ImageIndex = 7;
                }

            }
        }
        public void ShowJob()
        {

        }
        private void DeleteJob(int Id)
        {

            TreeGridNodeCollection tgnc = tvTask.Nodes;
            TreeGridNode tgn = GetNodeForJob(Id);
            tgnc.Remove(tgn);
        }
        #endregion

        #region 菜单状态改变
        private void tvTask_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                bool newvalue = !(bool)tvTask.SelectedRows[0].Cells[e.ColumnIndex].Value;
                tvTask.SelectedRows[0].Cells[e.ColumnIndex].Value = newvalue;
                if (tvTask.SelectedRows[0].Tag is ClassJob)
                {
                    ClassJob job = (ClassJob)tvTask.SelectedRows[0].Tag;
                    jobdb.JobUpdate(job.JobId,(e.ColumnIndex - 1), newvalue);
                }
                
            }
            if (tvTask.SelectedRows.Count>0&&tvTask.SelectedRows[0].Tag is ClassJob)
            {
                //Console.WriteLine("选择了任务");
                tvTask.ContextMenuStrip = cmsJob;
                CheckCategory(false);
            }
            else
            {
                //Console.WriteLine("选择了分组");
                tvTask.ContextMenuStrip = cmsCategory;
                CheckCategory(true);
            }
        }
        public delegate void CategoryStatusChange(bool IsCategory);
        public event CategoryStatusChange CheckCategory;
        private void CheckCategoryConsole(bool IsCategory)
        {
            Console.WriteLine("选择了"+(IsCategory?"分组":"任务"));
        }
        #region 任务列表获取和离开焦点
        private void TvTaskLeave(object sender, EventArgs e)
        {
            CheckCategory(false);

        }

        private void TvTaskEnter(object sender, EventArgs e)
        {
            CheckCategory(true);

        }
        #endregion
        #endregion

        private void CategoryAdd_Click(object sender, EventArgs e)
        {
            AddCategory();
        }

        private void CategoryEdit_Click(object sender, EventArgs e)
        {
            EditCategory();
        }

        private void CategoryDelete_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        private void tasknew_Click(object sender, EventArgs e)
        {
            AddJob();
        }



        private void tvTask_DoubleClick(object sender, EventArgs e)
        {
            if (tvTask.SelectedRows.Count > 0 && tvTask.SelectedRows[0].Tag is ClassJob)
            {
                EditJob();
            }
            else
            {
                EditCategory();
            }
        }

        private void 删除任务支持多选DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTask.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("删除任务后不可恢复,确定要删除么?", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    JobDB jobdb = new JobDB();
                    for (int i=tvTask.SelectedRows.Count-1; i >= 0; i--)
                    {
                        if (tvTask.SelectedRows[i].Tag is ClassJob)
                        {
                            int jobid = ((ClassJob)tvTask.SelectedRows[i].Tag).JobId;
                            jobdb.JobDelete(jobid);
                            DeleteJob(jobid);
                        }
                    }
                }
                

            }
        }

        private void 开始运行任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTask.SelectedRows!=null&&tvTask.SelectedRows[0].Tag is ClassJob)
            {
                ClassJob job = (ClassJob)tvTask.SelectedRows[0].Tag;
                Common.StartJob(job.JobId);
            }
            
        }

        private void 停止任务运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTask.SelectedRows != null && tvTask.SelectedRows[0].Tag is ClassJob)
            {
                ClassJob job = (ClassJob)tvTask.SelectedRows[0].Tag;
                Common.StopJob(job.JobId);
            }
        }

        private void 打开Data下任务文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTask.SelectedRows != null && tvTask.SelectedRows[0].Tag is ClassJob)
            {
                ClassJob job = (ClassJob)tvTask.SelectedRows[0].Tag;

                System.Diagnostics.Process.Start(System.Environment.CurrentDirectory + "\\Data\\" + job.JobId );
            }
            
        }

        private void 清空任务所有采集数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTask.SelectedRows != null && tvTask.SelectedRows[0].Tag is ClassJob)
            {
                ClassJob job = (ClassJob)tvTask.SelectedRows[0].Tag;
                SpiderDB spidb = new SpiderDB(job.JobId);
                spidb.Init();
                string result = spidb.Clear();
                if (result.StartsWith("成功"))
                {
                    MessageBox.Show(result, "清空成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result, "清空失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        private void 编辑任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTask.SelectedRows.Count > 0 && tvTask.SelectedRows[0].Tag is ClassJob)
            {
                EditJob();
            }
        }

        private void 标记内容发布状态为未发ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTask.SelectedRows != null && tvTask.SelectedRows[0].Tag is ClassJob)
            {
                ClassJob job = (ClassJob)tvTask.SelectedRows[0].Tag;
                SpiderDB spidb = new SpiderDB(job.JobId);
                spidb.Init();
                try
                {
                    spidb.OutContentUpdate(0, false);
                    MessageBox.Show("恭喜,全部数据已标记为未发", "标记成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "标记失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 标记内容发布状态为已发ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTask.SelectedRows != null && tvTask.SelectedRows[0].Tag is ClassJob)
            {
                ClassJob job = (ClassJob)tvTask.SelectedRows[0].Tag;
                SpiderDB spidb = new SpiderDB(job.JobId);
                spidb.Init();
                try
                {
                    spidb.OutContentUpdate(0, true);
                    MessageBox.Show("恭喜,全部数据已标记为已发", "标记成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "标记失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
