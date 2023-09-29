using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Security.Cryptography;
using Lv;

namespace LVWebPostModule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Web发布模块文件(*.wpm)|*.wpm";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
               string result= SelectModule(ofd.FileName);
                if (!result.StartsWith("<?xml"))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    File.WriteAllText("result.xml", result);
                    MessageBox.Show("保存成功");
                }
            }
        }
        public bool IsZipFile(string string_0)
        {
            if (!File.Exists(string_0))
            {
                return false;
            }
            StreamReader streamReader = new StreamReader(string_0);
            return IsZipFile(streamReader.BaseStream);
        }

        public  bool IsZipFile(Stream stream_0)
        {
            MemoryStream memoryStream = new MemoryStream();
            byte[] buffer = new byte[4096];
            int count;
            while ((count = stream_0.Read(buffer, 0, 4096)) > 0)
            {
                memoryStream.Write(buffer, 0, count);
            }
            bool result = false;
            if (memoryStream.Length > 2L)
            {
                byte[] array = new byte[2];
                memoryStream.Position = 0L;
                memoryStream.Read(array, 0, 2);
                if (array[0] == 80 && array[1] == 75)
                {
                    result = true;
                }
            }
            memoryStream.Position = 0L;
            memoryStream.Close();
            stream_0.Close();
            return result;
        }

        public string SelectModule(string fileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
                {
                    if (IsZipFile(fileName))
                    {
                        string text = Path.GetTempPath() + RadomFileNameWithoutExt() + ".xml";
                        ZipStorer zipStorer = ZipStorer.Open(fileName, FileAccess.Read);
                        foreach (ZipStorer.ZipFileEntry current in zipStorer.ReadCentralDir())
                        {
                            if (current.FilenameInZip.ToLower().EndsWith(".xml"))
                            {
                                zipStorer.ExtractStoredFile(current, text);
                            }
                            else if (current.FilenameInZip.ToLower().EndsWith(".dll"))
                            {
                               // string path = AppDomain.CurrentDomain.BaseDirectory + "System\\DllCache\\" + current.FilenameInZip;
                               // if (!File.Exists(path))
                               // {
                               //     zipStorer.ExtractStoredFile(current, path);
                               // }
                               ////this.string_24 = current.FilenameInZip;
                            }
                        }
                        zipStorer.Close();
                        if (File.Exists(text))
                        {
                            try
                            {
                                string result = ReadModel(text);
                                File.Delete(text);
                                return result;
                            }
                            catch (Exception)
                            {
                                return ("ReadModel Faild!");
                            }
                        }
                        else
                        {
                            return ("Extract WebPostModule Faild!");
                            
                        }
                    }
                    else
                    {
                        return ("Error WebPostModule File!");
                    }
                }
                else
                {
                    return ("没有找到发布模块文件");
                }
            }
            catch (Exception ex)
            {
                return ("读取模块出错:"+ex.Message);
            }
        }

        public string RadomFileNameWithoutExt()
        {
            string str = string.Concat(new string[]
            {
                DateTime.Now.Year.ToString(),
                DateTime.Now.Month.ToString(),
                DateTime.Now.Day.ToString(),
                DateTime.Now.Hour.ToString(),
                DateTime.Now.Minute.ToString(),
                DateTime.Now.Second.ToString(),
                DateTime.Now.Millisecond.ToString()
            });
            return str;
        }

        private string ReadModel(string string_26)
        {
            
            string text =File.ReadAllText (string_26, Encoding.UTF8);
            if (!text.StartsWith("<?xml"))
            {
                text = DecryptString(text, "CZK\u001f*\u0013TN");
            }
            return text;

        }
        public  string DecryptString(string string_0, string string_1)
        {
            string[] array = string_0.Split("-".ToCharArray());
            byte[] array2 = new byte[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = byte.Parse(array[i], NumberStyles.HexNumber);
            }
            ICryptoTransform cryptoTransform = new DESCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(string_1),
                IV = Encoding.ASCII.GetBytes(string_1),
                Mode = CipherMode.CBC
            }.CreateDecryptor();
            byte[] bytes = cryptoTransform.TransformFinalBlock(array2, 0, array2.Length);
            return Encoding.UTF8.GetString(bytes);
        }


        //public bool Save(string string_26)
        //{
        //    bool result;
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(string_26))
        //        {
        //            string s = this.method_1();
        //            ZipStorer zipStorer = ZipStorer.Create(string_26, "");
        //            zipStorer.AddStream(ZipStorer.Compression.Deflate, "module.xml", new MemoryStream(Encoding.UTF8.GetBytes(s)), DateTime.Now, "");
        //            if (!string.IsNullOrEmpty(this.string_24) && File.Exists(Path.DllCacheDir + this.string_24))
        //            {
        //                zipStorer.AddFile(ZipStorer.Compression.Deflate, Path.DllCacheDir + this.string_24, this.string_24, "");
        //            }
        //            zipStorer.Close();
        //            result = true;
        //        }
        //        else
        //        {
        //            result = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.string_25 = ex.Message + ex.StackTrace;
        //        result = false;
        //    }
        //    return result;
        //}

    }
}
