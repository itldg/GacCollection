using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DotNet.Utilities;
using System.Net;
using PanGu;

namespace FileDownTest
{
    public partial class txtPath : Form
    {
        public txtPath()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadFile(textBox1.Text,Application.StartupPath+ "\\bootstrap-3.3.7-dist.zip");
        }

        /// <summary>  
        /// c#,.net 下载文件  
        /// </summary>  
        /// <param name="URL">下载文件地址</param>  
        /// 
        /// <param name="Filename">下载后的存放地址</param>  
        /// <param name="Prog">用于显示的进度条</param>  
        /// 
        public void DownloadFile(string URL, string filename)
        {
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                //if (prog != null)
                //{
                //    prog.Maximum = (int)totalBytes;
                //}
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    //if (prog != null)
                    //{
                    //    prog.Value = (int)totalDownloadedByte;
                    //}
                   Console.WriteLine("已经下载"+ (int)totalDownloadedByte);
                    osize = st.Read(by, 0, (int)by.Length);

                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    Console.WriteLine("当前补丁下载进度" + percent.ToString() + "%");
                    System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FtpHelper ftp = new FtpHelper(txtip.Text, txtuser.Text, txtpass.Text);
       
               
                   //FtpClient ftp = new FtpClient(txtip.Text, txtuser.Text, txtpass.Text);
                //ftp.MakeDirectory(txtFtpPath.Text)
                
                if (ftp.CheckDir(txtFtpPath.Text)||ftp.MakeDir(txtFtpPath.Text))
                {
                    MessageBox.Show("ok");
                   
                }
                else
                {
                    MessageBox.Show("no");
                }
                //ftp.MkDir();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FTPClient ftp = new FTPClient(txtip.Text, txtFtpPath.Text, txtuser.Text, txtpass.Text, Convert.ToInt32(txtPort.Text));
            //ftp.Put(Application.StartupPath + "\\Test.zip");
            //FtpClient ftp = new FtpClient(txtip.Text, txtuser.Text, txtpass.Text);
            //ftp.Upload(new System.IO.FileInfo(Application.StartupPath + "\\Test.zip"), txtFtpPath.Text);
            FtpHelper ftp = new FtpHelper(txtip.Text, txtuser.Text, txtpass.Text);
            if (ftp.UploadFile(Application.StartupPath + "\\Test.zip", txtFtpPath.Text))
            {
                MessageBox.Show("ok");

            }
            else
            {
                MessageBox.Show("no");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PanGu.Segment.Init();
            var segment = new Segment();

            var words = segment.DoSegment(textBox2.Text);
            StringBuilder sb = new StringBuilder();
            foreach (var wordInfo in words)
            {
                sb.Append(wordInfo + "/");
               // Trace.WriteLine(wordInfo.Word);
            }
            textBox3.Text = sb.ToString();
        }

        private void txtFtpPath_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtFtpPath_Leave(object sender, EventArgs e)
        {
            if (txtFtpPath.Text != "" && !txtFtpPath.Text.EndsWith("\\"))
            {
                //txtFtpPath.Text+="\\";
            }
        }
    }
}
