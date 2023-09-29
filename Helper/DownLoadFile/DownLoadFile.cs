using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Gac
{
  
    public class DownLoadFile
    {
        public int ThreadNum = 3;
        List<Thread> list = new List<Thread>();
        private int _DownNumber = 0;

        public int DownNumber
        {
            get
            {
                return _DownNumber;
            }
        }

        public DownLoadFile()
        {
            doSendMsg += Change;
        }
        private void Change(DownMsg msg)
        {
            if (msg.Tag==DownStatus.Error||msg.Tag==DownStatus.End)
            {
                lock (this)
                {
                    _DownNumber--;
                    StartDown(1,true);
                }
                
            }
        }
        List<string> listUrls = new List<string>();
        public void Clear()
        {
            list.Clear();
            listUrls.Clear();
        }
        public void AddDown(string DownUrl,string Dir, int Id = 0,string FileName="")
        {
            listUrls.Add(DownUrl);
            Thread tsk = new Thread(() =>
            {
                download(DownUrl, Dir, FileName,Id);
            });
            list.Add(tsk);
        }
        public bool Check(string Url)
        {
            return !listUrls.Contains(Url);
        }
        private void StartDown(int StartNum = 3, bool IsSystem=false)
        {
            for (int i2 = 0; i2 < StartNum; i2++)
            {
                lock (list)
                {
                    if (IsSystem ? true: DownNumber < StartNum)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].ThreadState == System.Threading.ThreadState.Unstarted || list[i].ThreadState == ThreadState.Suspended)
                            {
                                list[i].Start();
                                _DownNumber++;
                                break;
                            }
                        }
                    }
                   
                }
            }
        }
        public void StartDown(int StartNum=3)
        {
            if (DownNumber<StartNum)
            {
                StartDown(StartNum,false);
            }
            
        }

        public delegate void dlgSendMsg(DownMsg msg);
        public event dlgSendMsg doSendMsg;
        //public event doSendMsg;
        //public dlgSendMsg doSendMsg = null;
        private void download(string path, string dir,string filename,int id = 0)
        {
            DownMsg msg = new DownMsg();
            msg.Id = id;
            msg.Url =Uri.EscapeUriString( path);
            try
            {
                
                msg.Tag = DownStatus.Start;
                doSendMsg(msg);
                FileDownloader loader = new FileDownloader(path, dir, filename, ThreadNum);
                loader.data.Clear();
                msg.Tag = DownStatus.GetLength;
                msg.Length = (int)loader.getFileSize(); ;
                msg.Name= loader.getFileName(); ;
                msg.ResumeBrokenTransfer = loader.getResumeBrokenTransfer();
                doSendMsg(msg);
                DownloadProgressListener linstenter = new DownloadProgressListener(msg);
                linstenter.doSendMsg = new DownloadProgressListener.dlgSendMsg(doSendMsg);
                loader.download(linstenter);
            }
            catch (Exception ex)
            {
                
                msg.Length = 0;
                msg.Tag =DownStatus.Error;
                msg.ErrMessage = ex.Message;
                doSendMsg(msg);
               
                Console.WriteLine(ex.Message);
            }
        }


    }
   
}
