using Gac;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Gac
{
    public class ModuleCommon
    {
        const string modulekey = "Gac\u5927*\u54E5NB";
        public ModuleInfo ReadModule(string fileName)
        {
           
            if (!fileName.Contains(".gpm")&& !fileName.Contains(".wpm"))
            {
                //string ModuleDir = Application.StartupPath + 
                fileName = System.Environment.CurrentDirectory+ "\\Module\\" + fileName + ".gpm";
            }
            XmlSerializerHelper xsh = new XmlSerializerHelper();
            //XmlHelper xml = new XmlHelper();
            string result = SelectModule(fileName);
            result = ReplaceMoudleKey(result);
            ModuleInfo module = new ModuleInfo();
            try
            {
                module=(ModuleInfo)xsh.LoadFromXml(result, module.GetType());
                //module = xml.XmlToEntity<ModuleInfo>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取模块时发生错误:" + ex.Message);
            }
            return module;
        }
        public bool SaveModule(string FileName, ModuleInfo mi)
        {
            //XmlHelper xml = new XmlHelper();
            XmlSerializerHelper xsh = new XmlSerializerHelper();
            try
            {
                string xmlstr = xsh.GetXmlCode(mi);

                if (xmlstr.Contains("[分类ID]"))
                {
                    mi.HaveSortId = "True";
                }
                if (xmlstr.Contains("[分类名称]"))
                {
                    mi.HaveSortName = "True"; 
                }
                if (xmlstr.Contains("[全局变量]"))
                {
                    mi.HaveGlobalVar = "True";
                }
                xmlstr = xsh.GetXmlCode(mi);
                xmlstr = EncryptString(xmlstr, modulekey);
                SaveModule(FileName, xmlstr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("保存模块时发生错误:" + ex.Message);
                return false;
            }
            return true;
        }
        public void SaveModule(string FileName, string Xml)
        {
         
            ZipStorer zipStorer = ZipStorer.Create(FileName, "");
            zipStorer.AddStream(ZipStorer.Compression.Deflate, "module.xml", new MemoryStream(Encoding.UTF8.GetBytes(Xml)), DateTime.Now, "");
            /*
             //插件添加
            if (!string.IsNullOrEmpty(this.string_24) && File.Exists(Path.DllCacheDir + this.string_24))
            {
                zipStorer.AddFile(ZipStorer.Compression.Deflate, Path.DllCacheDir + this.string_24, this.string_24, "");
            }
            */
            zipStorer.Close();


           
        }
        public List<string> GetLables(ModuleInfo mi)
        {
            List<string> list = new List<string>();
            VariableHelper vh = new VariableHelper();
            foreach (var item in mi.PostData)
            {
                List<string> listlables = vh.GetLables(item.Value);
                foreach (var item1 in listlables)
                {
                    if (!list.Contains(item1))
                    {
                        list.Add(item1);
                    }
                }

            }
            return list;
        }
        public PostList GetTestData(string ModuleName, ModuleInfo mi, Dictionary<string, string> TestLable = null)
        {
            PostList pl = new PostList();
            if (TestLable == null)
            {
                TestLable = new Dictionary<string, string>();
                string testfile = "Configuration\\TestLabel\\" + ModuleName + "_wp.xml";
                if (File.Exists(testfile))
                {
                    XmlSerializerHelper xsh = new XmlSerializerHelper();
                    PostList pl1 = (PostList)xsh.LoadFromFile(testfile, pl.GetType());

                    foreach (var item in pl1.PostData)
                    {
                        TestLable.Add(item.Key, item.Value);
                    }
                }
            }
            List<PostData> lp = new List<PostData>();
            List<string> listLable = GetLables(mi);
            foreach (var item in listLable)
            {
                lp.Add(new PostData()
                {
                    Key = item,
                    Value = TestLable.ContainsKey(item) ? TestLable[item] : ""
                });
            }
            //VariableHelper vh = new VariableHelper();
            //Dictionary<string, bool> dictemp = new Dictionary<string, bool>();
            //foreach (var item in mi.PostData)
            //{
            //    List<string> listlables = vh.GetLables(item.Value);
            //    foreach (var item1 in listlables)
            //    {
            //        if (!dictemp.ContainsKey(item1))
            //        {
            //            dictemp.Add(item1, false);
            //            lp.Add(new PostData()
            //            {
            //                Key = item1,
            //                Value = TestLable.ContainsKey(item1) ? TestLable[item1] : ""
            //            });
            //        }
            //    }

            //}
            pl.PostData = lp.ToArray();
            return pl;
        }
        public PostList GetTestData(string ModuleName, Dictionary<string, string> TestLable=null)
        {
            PostList pl = new PostList();
            ModuleInfo mi = ReadModule("Module\\" + ModuleName + ".gpm");
            if (TestLable == null)
            {
                TestLable = new Dictionary<string, string>();
                string testfile = "Configuration\\TestLabel\\" + ModuleName + "_wp.xml";
                if (File.Exists(testfile))
                {
                    XmlSerializerHelper xsh = new XmlSerializerHelper();
                    PostList pl1 =(PostList) xsh.LoadFromFile(testfile, pl.GetType());
                  
                    foreach (var item in pl1.PostData)
                    {
                        TestLable.Add(item.Key, item.Value);
                    }
                }
            }
            List<PostData> lp = new List<PostData>();
            List<string> listLable = GetLables(mi);
            foreach (var item in listLable)
            {
                lp.Add(new PostData()
                {
                    Key = item,
                    Value = TestLable.ContainsKey(item) ? TestLable[item] : ""
                });
            }
            //VariableHelper vh = new VariableHelper();
            //Dictionary<string, bool> dictemp = new Dictionary<string, bool>();
            //foreach (var item in mi.PostData)
            //{
            //    List<string> listlables = vh.GetLables(item.Value);
            //    foreach (var item1 in listlables)
            //    {
            //        if (!dictemp.ContainsKey(item1))
            //        {
            //            dictemp.Add(item1, false);
            //            lp.Add(new PostData()
            //            {
            //                Key = item1,
            //                Value = TestLable.ContainsKey(item1) ? TestLable[item1] : ""
            //            });
            //        }
            //    }

            //}
            pl.PostData = lp.ToArray();
            return pl;
        }
        public bool SaveTestData(string ModuleName, PostList pl)
        {
            string testfile = "Configuration\\TestLabel\\" + ModuleName + "_wp.xml";
            XmlSerializerHelper xsh = new XmlSerializerHelper();
            try
            {
                xsh.SaveToXml(testfile, pl);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("保存测试数据失败" + ex.Message);
            }
            return false;
            

        }





        Regex regMoudleKey = new Regex("\\[db:([^]]*?)\\]");
        private string ReplaceMoudleKey(string oldxml)
        {
            string newxml = oldxml;
            newxml = newxml.Replace("[UserName]", "[用户名]");
            newxml = newxml.Replace("[Password]", "[密码]");

            newxml = newxml.Replace("[SortId]", "[分类ID]");
            newxml = newxml.Replace("[SortName]", "[分类名称]");

            MatchCollection mcs= regMoudleKey.Matches(newxml);
            foreach (Match item in mcs)
            {
                newxml = newxml.Replace(item.Value,"[标签:"+item.Groups[1].Value+"]");
            }


            return newxml;
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

        public bool IsZipFile(Stream stream_0)
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
                                zipStorer.ExtractFile(current, text);
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
                return ("读取模块出错:" + ex.Message);
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

            string text = File.ReadAllText(string_26, Encoding.UTF8);
            string result = text;
            try
            {
                if (!result.StartsWith("<?xml"))
                {
                    result = DecryptString(text, modulekey);
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (!result.StartsWith("<?xml"))
                {
                    result = DecryptString(text, "CZK\u001f*\u0013TN");
                }
            }
            catch (Exception)
            {
            }

            return result;

        }
        public string DecryptString(string str, string key)
        {
            string[] array = str.Split("-".ToCharArray());
            byte[] array2 = new byte[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = byte.Parse(array[i], NumberStyles.HexNumber);
            }
            ICryptoTransform cryptoTransform = new DESCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(key),
                IV = Encoding.ASCII.GetBytes(key),
                Mode = CipherMode.CBC
            }.CreateDecryptor();
            byte[] bytes = cryptoTransform.TransformFinalBlock(array2, 0, array2.Length);
            return Encoding.UTF8.GetString(bytes);
        }
        public string EncryptString(string str, string key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            ICryptoTransform cryptoTransform = new DESCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(key),
                IV = Encoding.ASCII.GetBytes(key)
            }.CreateEncryptor();
            byte[] value = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
            return BitConverter.ToString(value);
        }

    }
}
