using GAC_Collection.MainUi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;


namespace GAC_Collection
{
    public partial class FrmMain : Form
    {
        #region 任务列表焦点
        
        #endregion
        public FrmMain()
        {
            InitializeComponent();

        }
        MainUi.FrmRunTask frmruntask = new MainUi.FrmRunTask();
        public MainUi.FrmTaskList frmtask;
        SystemCommon common = new SystemCommon();
        private void FrmMain_Load(object sender, EventArgs e)
        {
            frmtask = new MainUi.FrmTaskList(common);
            if (!LoadBock())
            {
              
                frmruntask.Show(dp, WeifenLuo.WinFormsUI.Docking.DockState.DockTop);
                
            }

            frmtask.Show(dp, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            //frmtask.Show();


            MainUi.FrmWelcome frmwelcome = new MainUi.FrmWelcome();
            frmwelcome.Show(dp);
            this.Text= GacInfo.Name+" Ver:"+ System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveBock();
        }

        #region 布局读写
        /// <summary> 保存布局 </summary>
        private void SaveBock()
        {
            string uiFile = System.IO. Path.Combine(Application.StartupPath+Properties.Resources.UserData, "\\CustomUI.xml");
            dp.SaveAsXml(uiFile);
        }
        /// <summary> 加载布局 </summary>
        private bool LoadBock()
        {
            string uiFile = System.IO.Path.Combine(Application.StartupPath + Properties.Resources.UserData, "\\CustomUI.xml");
            if (File.Exists(uiFile))
            {
                WeifenLuo.WinFormsUI.Docking.DeserializeDockContent ddContent =
                        new WeifenLuo.WinFormsUI.Docking.DeserializeDockContent(GetContentFromPersistString);
                dp.LoadFromXml(uiFile, ddContent);
                return true;
            }
            
            return false;
        }
        /// <summary>
        /// 加载布局
        /// </summary>
        /// <param name="persistString"></param>
        /// <returns></returns>
        private IDockContent GetContentFromPersistString(string persistString)
        {
            try
            {
                if (persistString == typeof(FrmRunTask).ToString())
                {
                    return new FrmRunTask();
                }
                else if (persistString == typeof(FrmTaskList).ToString())
                {

                    return null;
                }
                else if (persistString == typeof(FrmWelcome).ToString())
                {
                    return null;
                }
                else
                {
                    Console.WriteLine(persistString);
                    return null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(persistString);
                return null;
            }
            throw new Exception();
        }
        #endregion
        #region 菜单注册
        private void MenuInit()
        {
            ToolStripItem[] tsis = new ToolStripItem[9];
            
            //tsis[0]= new ToolStripItem("新建任务",);
            //ToolStripItemCollection tsics = new ToolStripItemCollection(cmsCategory,tsis);
            //tsics.Add("新建任务"); ;
            //tsics[0] = item;


            //tsmiCategory.DropDownItems.Add("新建任务");

        }
        #endregion

        #region 启动后注册事件
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            frmtask.CheckCategory += Frmtask_CheckCategory;
            common.StartJobCallBack += Common_StartJobCallBack;
            MenuInit();
        }

        private void Common_StartJobCallBack(int ID)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item is MainUi.Task.FrmRun)
                {
                    MainUi.Task.FrmRun f = item as MainUi.Task.FrmRun;
                    if (f.Spider.JobId == ID)
                    {
                        if (f.Text.EndsWith("[任务停止]"))
                        {
                            f.Start();
                        }
                        else
                        {
                            f.Activate();
                        }
                        
                        return;
                    }
                }
                
            }
            MainUi.Task.FrmRun frm = new MainUi.Task.FrmRun(ID,common);
            frm.Show(dp);
        }

        private void Frmtask_CheckCategory(bool IsCategory)
        {
            tsbnew.Enabled = IsCategory;
        }
        #endregion


        private void 分组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtask.AddCategory();
        }


        private void tsiAbout_Click(object sender, EventArgs e)
        {
            MainUi.Help.FrmAbout frmabout = new MainUi.Help.FrmAbout();
            frmabout.ShowDialog();
        }

        private void 任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtask.AddJob();
        }
    }
}
