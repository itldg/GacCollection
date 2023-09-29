using Gac;
using GAC_Collection.Ex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GacDB.Class;
using GAC_Collection.Common;

namespace GAC_Collection.MainUi.Task
{
    public partial class FrmRun : DockContentEx
    {
        public SpiderCommon Spider;
        public SystemCommon Common;
        public RuleCommon Rule;
        public SpiderDB spiderdb;
        Thread thContent = null;
        int JobId = 0;

        /// <summary>
        /// 采集内容线程数
        /// </summary>
        int ThreadCount = 0;
        /// <summary>
        /// 发布线程数
        /// </summary>
        int ThreadOutCount = 0;

        int SpiderContentSuccess = 0;
        int SpiderContentError = 0;
        int SpiderContentFilter = 0;

        int OutContentSuccess = 0;
        int OutContentError = 0;
        public FrmRun(int JobId, SystemCommon Common)
        {
            InitializeComponent();
            this.Common = Common;
            this.JobId = JobId;
            Common.StopJobCallBack += Common_StopJobCallBack;

        }
        private void Init(int JobId)
        {
             SpiderContentSuccess = 0;
             SpiderContentError = 0;
             SpiderContentFilter = 0;

             OutContentSuccess = 0;
             OutContentError = 0;

            this.Spider = new SpiderCommon(JobId);
            this.Rule = new RuleCommon(Spider.Job);
           
            Spider.spiderUrl.UrlStatusChange += SpiderUrl_UrlStatusChange;
            Spider.spiderUrl.ShowUrls += SpiderUrl_ShowUrls;
            Spider.spiderUrl.SpiderProgress += SpiderUrl_SpiderProgress;
            Spider.spiderUrl.SpiderFinish += SpiderUrl_SpiderFinish;
            spiderdb = new SpiderDB(JobId);

            //Rule.LogAdd += Rule_LogAdd;
            Rule.StatusChange += Rule_StatusChange;

            List<string> listLables = Rule.GetListLable();
            spiderdb.SetListLables(listLables);

            List<string> lisLabelNotRepeat = Rule.GetLabelNotRepeat();
            spiderdb.SetLabelNotRepeat(lisLabelNotRepeat);

            
        }

        private void Rule_StatusChange(string Status)
        {
            SetStatus(Status);
        }

        private void Rule_LogAdd(string Log)
        {
            SetStatus(Log);
        }

        private void SpiderUrl_SpiderProgress(int Index, int Count)
        {
            if (!this.IsDisposed)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    pgSpider.Maximum = Count;
                    pgSpider.Value = Index;
                    lblSpiderProgress.Text = "("+ Index + "/"+Count+")";

                });
            }
        }
        
        private void Common_StopJobCallBack(int ID)
        {
            if (ID==Spider.JobId)
            {
                Stop(false);
            }
        }

        private void FrmRun_Load(object sender, EventArgs e)
        {
            rtbeLog.Rich.DetectUrls = true;
            
        }

        private void SpiderUrl_ShowUrls(List<KeyValuePair<string, Dictionary<string, string>>> list, bool IsParent)
        {
            if (!IsParent)
            {
                foreach (var item in list)
                {
                    bool UrlCheck = false;
                    if (Spider.Job.CheckUrlRepeat && Spider.Job.UrlRepeat > 0)
                    {
                        UrlCheck = spiderdb.UrlCheck(item.Key, Spider.Job.UrlRepeat);
                    }
                    else
                    {
                        UrlCheck =spiderdb.UrlCheck(item.Key);
                    }
                    if (UrlCheck)
                    {
                        if (spiderdb.UrlInsert(item.Key,item.Value))
                        {
                            Spider.spiderUrl.UrlCountSuccess++;
                            AddLog("成功采集并更新数据到数据库：" + item.Key);
                        }
                        else
                        {
                            Spider.spiderUrl.UrlCountError++;
                            AddLog("网址录入数据库时出错：" + item.Key);
                        }
                        
                    }
                    else
                    {
                        Spider.spiderUrl.UrlCountRepeat++;
                        AddLog("发现重复网址,忽略采集：" + item.Key);
                    }
                    
                }
            }
            
        }

        private void SpiderUrl_UrlStatusChange(int Level, string Url, int Page = 0)
        {
            string log = "正在下载并分析" + Level + "级网址" + (Page > 0 ? "第" + Page + "分页" : "") + Url;
            SetStatus(log);
            AddLog(log);
        }
        private void ShowResult()
        {
            StringBuilder sb = new StringBuilder();
            if (Spider.classJob.SpiderUrl)
            {
                sb.Append("采网址成功"+ Spider.spiderUrl .UrlCountSuccess+ "条,重复"+ Spider.spiderUrl .UrlCountRepeat+ "条");
                if (Spider.spiderUrl.UrlCountError>0)
                {
                    sb.Append("失败"+ Spider.spiderUrl.UrlCountError + "条");
                }
            }
            if (Spider.classJob.SpiderContent)
            {

                if (sb.Length>0)
                {
                    sb.Append("。");
                }
                sb.Append("采内容成功"+ SpiderContentSuccess + "条,失败"+SpiderContentError+ "条");

                if (SpiderContentFilter>0)
                {
                    sb.Append(", 过滤" + SpiderContentFilter + "条");
                }

            }
            if (Spider.classJob.OutContent)
            {
                if (sb.Length > 0)
                {
                    sb.Append("。");
                }
                sb.Append("发布成功"+ OutContentSuccess + "条,失败"+OutContentError+"条");
            }
            AddLog(sb.ToString());
        }

        private void Stop(bool Auto = true)
        {
            SpiderContent = false;
            
            if (thContent!=null)
            {
                thContent.Abort();
            }
           
            if (Auto)
            {
                Common.StopJob(Spider.JobId);
            }
            string status = "当前任务被用户停止";
            if (Auto)
            {
                status = "任务停止";
            }
            else
            {
                Spider.StopJob();
                SetStatus(status);
                AddLog(status);
                ShowResult();
            }
            
            this.Invoke((MethodInvoker)delegate ()
            {
                this.Text = Spider.classJob.JobName + "[任务停止]";
            });
            
          
        }
        
        private bool CheckOut()
        {
            if (Spider.Job.UseWebOutput&& Spider.Job.JobWebPostCollection.Count>0)
            {
                return true;
            }
            if (Spider.Job.UseFileOut)
            {
                return true;
            }
            if (Spider.Job.JobDatabase.Count>0)
            {
                return true;
            }
            return false;
        }
        private void AddLog(string Msg)
        {
            if(!this.IsDisposed)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    //rtbeLog.Rich.AppendText(Msg + "\r\n");
                    rtbeLog.AppendLog(Msg);

                });
            }
        }
        private void SetStatus(string Status)
        {
            if (!this.IsDisposed)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    lblStauts.Text = Status;

                });
            }
        }

        private void FrmRun_Shown(object sender, EventArgs e)
        {
            Start();
        }
        public void Start()
        {
            index = 0;
            SpiderContentSuccess = 0;
            SpiderContentError = 0;
            SpiderContentFilter = 0;
            Init(JobId);
            thContent = new Thread(Content_Begin);
            rtbeLog.Rich.Clear();

            this.Text = Spider.classJob.JobName + "[正在运行]";
            AddLog("正在初始化配置,请稍等...");
            if (Spider.classJob.OutContent && !CheckOut())
            {
                AddLog("您选择了数据发布，但您没有配置任何发布配置");
                Stop();
                return;
            }
            string sqlresult = spiderdb.Init();
            if (sqlresult!="ok")
            {
                AddLog("初始化配置失败,"+sqlresult);
                return;
            }
            AddLog("初始化配置成功,开始数据采集...");
            lblSpiderType.Text = "采网址：";
            AddLog("任务开始运行");
            if (!Spider.classJob.SpiderUrl)
            {
                AddLog("当前任务没有选择采网址，跳过采网址步骤");
                if (Spider.classJob.SpiderContent)
                {
                    thContent.Start();
                }
                else
                {
                    SetStatus("无需采集内容,开始发布");
                    Out_Begin();
                }
                
                
            }
            else
            {
                Spider.Start();
            }
            
        }

        //采集网址结束,准备采集内容
        private void SpiderUrl_SpiderFinish()
        {
            if (Spider.classJob.SpiderContent)
            {
                SetStatus("采集网址结束,开始采集内容");
                thContent.Start();


            }
            else
            {
                SetStatus("无需采集内容,开始发布");
                Out_Begin();
            }
        }
        private bool SpiderContent = false;
        private void Content_Begin()
        {
            AddLog("开始查找可采集的数据，如果您的数据比较多，可能需要一些时间，请稍等");
            int urlcount = spiderdb.UrlGetCount(1);
            AddLog("共有" + urlcount + "条记录需要采集内容");
            this.Invoke((MethodInvoker)delegate ()
            {
                lblSpiderType.Text = "采内容：";
                pgSpider.Maximum = urlcount;
                pgSpider.Value = 0;
                lblSpiderProgress.Text = "(" + 0 + "/" + urlcount + ")";
            });
            SpiderContent = true;
            for (int i = 0; i < Spider.Job.SpiderThreadNum; i++)
            {
                ThreadCount++;
                Thread th = new Thread(GetContent);
                th.Start();
            } 
            
        }
        int index = 0;
        private bool OutContentIng = false;
        List<object> listOut = new List<object>();
        ModuleConfigCommon mcc = new ModuleConfigCommon();
        ModuleDb md = new ModuleDb();
        ModuleCommon mc = new ModuleCommon();
        private void Out_Begin()
        {
            if (Spider.classJob.OutContent)
            {
                int urlcount = spiderdb.UrlGetCount(2);
                AddLog("共有" + urlcount + "条记录需要发布");


                string file = Spider.Job.FileTemplate;
                Encoding encooding = Encoding.UTF8;
                if (!string.IsNullOrEmpty(Spider.Job.FileEncoding))
                {
                    encooding = Encoding.GetEncoding(Spider.Job.FileEncoding);
                }


               listOut = new List<object>();
                if (Spider.Job.UseFileOut)
                {
                    OutFile of = new OutFile(Spider.Job.JobName, Spider.Job.JobId, Spider.Job.FileSavePath, Spider.Job.FileTemplate, Spider.Job.FilenNameType, Spider.Job.FileType);
                    listOut.Add(of);
                }
               
                if (Spider.Job.UseWebOutput)
                {
                    foreach (var item in Spider.Job.JobWebPostCollection)
                    {
                        ClassModule cm = md.GetClassModule(item.WebPostId);
                        
                        if (cm != null)
                        {
                            ModuleConfigInfo mci = mcc.GetModuleConfigInfo(cm.XmlData);
                            ModuleInfo mi = mc.ReadModule(mci.ModuleName);

                            OutWeb ow = new OutWeb(mi, mci,cm);
                            listOut.Add(ow);
                        }
                    }
                }


                this.Invoke((MethodInvoker)delegate ()
                {
                    lblSpiderType.Text = "发数据：";
                    pgSpider.Maximum = urlcount;
                    pgSpider.Value = 0;
                    lblSpiderProgress.Text = "(" + 0 + "/" + urlcount + ")";
                });
                OutContentIng = true;
                index = 0;
                for (int i = 0; i < Spider.Job.OutThreadNum; i++)
                {
                    ThreadCount++;
                    Thread th = new Thread(OutContent);
                    th.Start();
                }

               
                //AddLog("等待开发发布");
            }
            else
            {
                JobOver();
            }
            //Stop(true);
        }
        private void JobOver()
        {
            SetStatus("采集运行完毕");
            AddLog("采集运行完毕");
            this.Invoke((MethodInvoker)delegate ()
            {
                this.Text = Spider.classJob.JobName + "[任务停止]";
            });

            ShowResult();
        }
        OutData od = new OutData();
        private void OutContent()
        {
            
            while (index>=0&&listOut.Count>0)
            {
                List<Dictionary<string, string>> list = GetUrlList(2);
                if (!OutContentIng || index < 0)
                {
                    break;
                }
                
                foreach (Dictionary<string, string> item in list)
                {
                    string contenttip = item["PageUrl"];
                    if (item.ContainsKey("标题"))
                    {
                        contenttip = item["标题"];
                    }

                    bool IsOkOne = false;
                    bool IsOkAll = true;
                    foreach (var itemOut in listOut)
                    {
                        ReturnResult outResult= od.Out(itemOut, item);
                        //string outType = "";
                        //if (itemOut is OutFile)
                        //{
                        //    outType = "";
                        //}
                        //else
                        //{
                        //    outType = "发布到其他渠道";
                        //}


                        AddLog(outResult.Title + " - Id:" + item["Id"] + " - " + contenttip);
                        if (outResult.Success)
                        {
                            IsOkOne = true;
                            OutContentSuccess++;
                        }
                        else
                        {
                            IsOkAll = false;
                            OutContentError++;
                            
                        }
                    }
                    if (Spider.Job.SignSucessIfAllPost)
                    {
                        if (IsOkAll)//全部发布成功
                        {
                            spiderdb.OutContentUpdate(Convert.ToInt32(item["Id"]),true);
                        }
                    }
                    else if(IsOkOne)//起码有一个成功
                    {
                        spiderdb.OutContentUpdate(Convert.ToInt32(item["Id"]), true);
                    }
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        pgSpider.Value += 1;
                        lblSpiderProgress.Text = "(" + pgSpider.Value + "/" + pgSpider.Maximum + ")";
                    });

                }
            }

            ThreadCount--;
            if (ThreadCount == 0)
            {
                JobOver();
            }

        }
        
        private string GetName(LableMergeInfo lmi)
        {
            foreach (var item in lmi.Dic)
            {
                if (item.Key=="标题")
                {
                    return item.Value;
                }
            }
            foreach (var item in lmi.Dic)
            {
                if (item.Key.EndsWith("标题"))
                {
                    return item.Value;
                }
            }
            return "";
        }
        object obj = new object();
        private void GetContent()
        {
            while (index>=0)
            {
                List<Dictionary<string, string>> list=GetUrlList(1);
                if (!SpiderContent||index<0)
                {
                    break;
                }
                foreach (Dictionary<string, string> item in list)
                {
                    List<LableMergeInfo> listResult = Rule.GetResult(item["PageUrl"], item);
                    
                    if (!SpiderContent)
                    {
                        break;
                    }
                    for (int i = 0; i < listResult.Count; i++)
                    {

                        LableMergeInfo itemResult = listResult[i];
                        int id = Convert.ToInt32(item["Id"]);
                        string contenttip = GetName(itemResult);
                        if (string.IsNullOrEmpty(contenttip))
                        {
                            contenttip = item["PageUrl"];
                        }

                        string resultCheck = Rule.CheckResult(itemResult);
                        if (resultCheck == "ok")//数据库存在检测
                        {
                            if (spiderdb.ChecktLabelNotRepeat(itemResult))
                            {
                                resultCheck = "数据库中已存在相同结果" + contenttip;
                            }

                        }
                        if (resultCheck == "ok")
                        {

                            bool result = false;
                            if (i == 0)
                            {
                                //单挑记录更新结果
                                result=spiderdb.ContentUpdate(id, itemResult);
                            }
                            else
                            {
                                //多条结果重新插入记录
                                result = spiderdb.ContentInsert(itemResult);
                            }
                                
                            if (result)
                            {
                                lock (obj)
                                {
                                    SpiderContentSuccess++;
                                }
                                AddLog("成功采集并更新数据到数据库：" + contenttip);
                            }
                            else
                            {
                                lock (obj)
                                {
                                    SpiderContentError++;
                                }
                                AddLog("内容结果录入数据库时出错：" + contenttip);
                            }
                        }
                        else
                        {
                            //AddLog("内容结果过滤剔除：" +resultCheck);
                            AddLog(resultCheck+"  网址：" + item["PageUrl"]);
                            lock (obj)
                            {
                                SpiderContentFilter++;
                            }
                        }



                    }
                    
                    if (!this.IsDisposed)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            if (pgSpider.Value!=pgSpider.Maximum)
                            {
                                pgSpider.Value++;
                            }
                            lblSpiderProgress.Text = "(" + pgSpider.Value + "/" + pgSpider.Maximum + ")";

                        });
                    }
                    Thread.Sleep(Spider.Job.SpiderTimeInterval);
                    if (!SpiderContent)
                    {
                        break;
                    }
                }
            }
            ThreadCount--;
            if (ThreadCount==0)
            {
                AddLog("内容采集结束,准备发布内容");
                Out_Begin();
            }
        }
        private List<Dictionary<string, string>> GetUrlList(int Type)
        {
            List<Dictionary<string, string>> list=new List<Dictionary<string, string>>();
            
                lock (obj)
                {
                if (index >= 0)
                {
                    Console.WriteLine("["+ Type + "]本轮获取从大于" + index + "开始");

                    list = spiderdb.CotentGetTop(index, 1, Type);
                    if (list.Count > 0)
                    {
                        index = Convert.ToInt32(list[list.Count - 1]["Id"]);
                    }
                    else
                    {
                        index = -1;
                    }
                }
            }
            
            return list;
        }
        private void FrmRun_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Text.EndsWith("[任务停止]"))
            {
                if (MessageBox.Show("当前任务还没有结束，您确认要退出该任务?", "确定退出么", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Stop();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
