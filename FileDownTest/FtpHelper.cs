using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;

namespace FileDownTest
{
    /// <summary>
    /// ftp帮助类
    /// </summary>
    public class FtpHelper
    {
        private string ftpHostIP { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string ftpURI { get { return $@"ftp://{ftpHostIP}"; } }

        /// <summary>
        /// 初始化ftp参数
        /// </summary>
        /// <param name="ftpHostIP">ftp主机IP</param>
        /// <param name="username">ftp账户</param>
        /// <param name="password">ftp密码</param>
        public FtpHelper(string ftpHostIP, string username, string password)
        {
            this.ftpHostIP = ftpHostIP;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// 异常方法委托,通过Lamda委托统一处理异常，方便改写
        /// </summary>
        /// <param name="method">当前执行的方法</param>
        /// <param name="action"></param>
        /// <returns></returns>
        private bool MethodInvoke(string method, Action action)
        {
            if (action != null)
            {
                try
                {
                    action();
                    //Logger.Write2File($@"FtpHelper.{method}:执行成功");
                    //FluentConsole.Magenta.Line($@"FtpHelper({ftpHostIP},{username},{password}).{method}:执行成功");
                    Console.WriteLine($@"FtpHelper({ftpHostIP},{username},{password}).{method}:执行成功");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($@"FtpHelper({ftpHostIP},{username},{password}).{method}:执行失败:\n {ex}");
                    //FluentConsole.Red.Line($@"FtpHelper({ftpHostIP},{username},{password}).{method}:执行失败:\n {ex}");
                    // Logger.Write2File(FtpHelper({ftpHostIP},{username},{password}).{method}:执行失败 \r\n{ex}");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 异常方法委托,通过Lamda委托统一处理异常，方便改写
        /// </summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        private T MethodInvoke<T>(string method, Func<T> func)
        {
            if (func != null)
            {
                try
                {
                    //FluentConsole.Magenta.Line($@"FtpHelper({ftpHostIP},{username},{password}).{method}:执行成功");
                    //Logger.Write2File($@"FtpHelper({ftpHostIP},{username},{password}).{method}:执行成功");
                    return func();
                }
                catch (Exception ex)
                {
                    //FluentConsole.Red.Line($@"FtpHelper({ftpHostIP},{username},{password}).{method}:执行失败:").Line(ex);
                    // Logger.Write2File($@"FtpHelper({ftpHostIP},{username},{password}).{method}:执行失败 \r\n{ex}");
                    return default(T);
                }
            }
            else
            {
                return default(T);
            }
        }
        private FtpWebRequest GetRequest(string URI)
        {
            URI = URI.Replace("\\", "/");
            if (!URI.StartsWith("ftp://"))
            {
                URI = ftpURI + URI;
            }
            //根据服务器信息FtpWebRequest创建类的对象
            FtpWebRequest result = (FtpWebRequest)WebRequest.Create(URI);
            result.Credentials = new NetworkCredential(username, password);
            result.KeepAlive = false;
            result.UsePassive = false;
            result.UseBinary = true;
            return result;
        }

        /// <summary> 上传文件</summary>
        /// <param name="filePath">需要上传的文件路径</param>
        /// <param name="dirName">目标路径</param>
        public bool UploadFile(string filePath, string dirName = "")
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (dirName != "") MakeDir(dirName);//检查文件目录，不存在就自动创建
            if (!dirName.EndsWith("/"))
            {
                dirName += "/";
            }
            string uri = Path.Combine(ftpURI, dirName+ fileInfo.Name);
            return MethodInvoke($@"uploadFile({filePath},{dirName})", () =>
            {
                FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.UploadFile;
                ftp.ContentLength = fileInfo.Length;
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                using (FileStream fs = fileInfo.OpenRead())
                {
                    using (Stream strm = ftp.GetRequestStream())
                    {
                        contentLen = fs.Read(buff, 0, buffLength);
                        while (contentLen != 0)
                        {
                            strm.Write(buff, 0, contentLen);
                            contentLen = fs.Read(buff, 0, buffLength);
                        }
                        strm.Close();
                    }
                    fs.Close();
                }
            });
        }

        /// <summary>
        /// 从一个目录将其内容复制到另一目录
        /// </summary>
        /// <param name="localDir">源目录</param>
        /// <param name="DirName">目标目录</param>
        public void UploadAllFile(string localDir, string DirName = "")
        {
            string localDirName = string.Empty;
            int targIndex = localDir.LastIndexOf("/");
            if (targIndex > -1 && targIndex != (localDir.IndexOf(":/") + 1))
                localDirName = localDir.Substring(0, targIndex);
            localDirName = localDir.Substring(targIndex + 1);
            string newDir = Path.Combine(DirName, localDirName);
            MethodInvoke($@"UploadAllFile({localDir},{DirName})", () =>
            {
                MakeDir(newDir);
                DirectoryInfo directoryInfo = new DirectoryInfo(localDir);
                FileInfo[] files = directoryInfo.GetFiles();
                //复制所有文件  
                foreach (FileInfo file in files)
                {
                    UploadFile(file.FullName, newDir);
                }
                //最后复制目录  
                DirectoryInfo[] directoryInfoArray = directoryInfo.GetDirectories();
                foreach (DirectoryInfo dir in directoryInfoArray)
                {
                    UploadAllFile(Path.Combine(localDir, dir.Name), newDir);
                }
            });
        }

        /// <summary> 
        /// 删除单个文件
        /// </summary>
        /// <param name="filePath"></param>
        public bool DelFile(string filePath)
        {
            string uri = Path.Combine(ftpURI, filePath);
            return MethodInvoke($@"DelFile({filePath})", () =>
            {
                FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            });
        }

        /// <summary> 
        /// 删除最末及空目录
        /// </summary>
        /// <param name="dirName"></param>
        private bool DelDir(string dirName)
        {
            string uri = Path.Combine(ftpURI, dirName);
            return MethodInvoke($@"DelDir({dirName})", () =>
            {
                FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            });
        }

        /// <summary> 删除目录或者其目录下所有的文件 </summary>
        /// <param name="dirName">目录名称</param>
        /// <param name="ifDelSub">是否删除目录下所有的文件</param>
        public bool DelAll(string dirName)
        {
            var list = GetAllFtpFile(new List<ActFile>(), dirName);
            if (list == null) return DelDir(dirName);
            if (list.Count == 0) return DelDir(dirName);//删除当前目录
            var newlist = list.OrderByDescending(x => x.level);
            foreach (var item in newlist)
            {
                Console.WriteLine($@"level:{item.level},isDir:{item.isDir},path:{item.path}");
                //FluentConsole.Yellow.Line($@"level:{item.level},isDir:{item.isDir},path:{item.path}");
            }
            string uri = Path.Combine(ftpURI, dirName);
            return MethodInvoke($@"DelAll({dirName})", () =>
            {
                foreach (var item in newlist)
                {
                    if (item.isDir)//判断是目录调用目录的删除方法
                        DelDir(item.path);
                    else
                        DelFile(item.path);
                }
                DelDir(dirName);//删除当前目录
                return true;
            });
        }

        /// <summary>
        /// 下载单个文件
        /// </summary>
        /// <param name="ftpFilePath">从ftp要下载的文件路径</param>
        /// <param name="localDir">下载至本地路径</param>
        /// <param name="filename">文件名</param>
        public bool DownloadFile(string ftpFilePath, string saveDir)
        {
            string filename = ftpFilePath.Substring(ftpFilePath.LastIndexOf("/") + 1);
            string tmpname = Guid.NewGuid().ToString();
            string uri = Path.Combine(ftpURI, ftpFilePath);
            return MethodInvoke($@"DownloadFile({ftpFilePath},{saveDir},{filename})", () =>
            {
                if (!Directory.Exists(saveDir)) Directory.CreateDirectory(saveDir);
                FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.DownloadFile;
                using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (FileStream fs = new FileStream(Path.Combine(saveDir, filename), FileMode.CreateNew))
                        {
                            byte[] buffer = new byte[2048];
                            int read = 0;
                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                            } while (!(read == 0));
                            responseStream.Close();
                            fs.Flush();
                            fs.Close();
                        }
                        responseStream.Close();
                    }
                    response.Close();
                }
            });
        }

        /// <summary>    
        /// 从FTP下载整个文件夹    
        /// </summary>    
        /// <param name="dirName">FTP文件夹路径</param>    
        /// <param name="saveDir">保存的本地文件夹路径</param>    
        public void DownloadAllFile(string dirName, string saveDir)
        {
            MethodInvoke($@"DownloadAllFile({dirName},{saveDir})", () =>
            {
                List<ActFile> files = GetFtpFile(dirName);
                if (!Directory.Exists(saveDir))
                {
                    Directory.CreateDirectory(saveDir);
                }
                foreach (var f in files)
                {
                    if (f.isDir) //文件夹，递归查询  
                    {
                        DownloadAllFile(Path.Combine(dirName, f.name), Path.Combine(saveDir, f.name));
                    }
                    else //文件，直接下载  
                    {
                        DownloadFile(Path.Combine(dirName, f.name), saveDir);
                    }
                }
            });
        }

        /// <summary>
        /// 获取当前目录下的目录及文件
        /// </summary>
        /// param name="ftpfileList"></param>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public List<ActFile> GetFtpFile(string dirName, int ilevel = 0)
        {
            var ftpfileList = new List<ActFile>();
            string uri = Path.Combine(ftpURI, dirName);
            return MethodInvoke($@"GetFtpFile({dirName})", () =>
            {
                var a = new List<List<string>>();
                FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                Stream stream = ftp.GetResponse().GetResponseStream();
                using (StreamReader sr = new StreamReader(stream))
                {
                    string line = sr.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        ftpfileList.Add(new ActFile { isDir = line.IndexOf("<DIR>") > -1, name = line.Substring(39).Trim(), path = Path.Combine(dirName, line.Substring(39).Trim()), level = ilevel });
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                return ftpfileList;
            });


        }

        /// <summary>
        /// 获取FTP目录下的所有目录及文件包括其子目录和子文件
        /// </summary>
        /// param name="result"></param>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public List<ActFile> GetAllFtpFile(List<ActFile> result, string dirName, int level = 0)
        {
            var ftpfileList = new List<ActFile>();
            string uri = Path.Combine(ftpURI, dirName);
            return MethodInvoke($@"GetAllFtpFile({dirName})", () =>
            {
                ftpfileList = GetFtpFile(dirName, level);
                result.AddRange(ftpfileList);
                var newlist = ftpfileList.Where(x => x.isDir).ToList();
                foreach (var item in newlist)
                {
                    GetAllFtpFile(result, item.path, level + 1);
                }
                return result;
            });

        }

        /// <summary>
        /// 检查目录是否存在
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="currentDir"></param>
        /// <returns></returns>
        public bool CheckDir(string dirName, string currentDir = "")
        {
            
            if (dirName.Contains("/"))
            {
                string[] s = dirName.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                if (s.Length>1)
                {
                    for (int i = 0; i < s.Length - 1; i++)
                    {
                        currentDir += s[i] + "/";
                    }
                    dirName = s[s.Length - 1];
                }
                


            }
            string uri = Path.Combine(ftpURI, currentDir);
            return MethodInvoke($@"CheckDir({dirName}{currentDir})", () =>
            {
                FtpWebRequest ftp = GetRequest(uri);
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                Stream stream = ftp.GetResponse().GetResponseStream();
                using (StreamReader sr = new StreamReader(stream))
                {
                    //string s = sr.ReadToEnd();
                    //Console.WriteLine(s);
                    string line = sr.ReadLine();
                  
                    while (!string.IsNullOrEmpty(line))
                    {
                        Console.WriteLine(line);
                        if (line.IndexOf("<DIR>") > -1)
                        {
                            if (line.Substring(39).Trim() == dirName)
                                return true;
                        }
                        else if(line.Trim().EndsWith(dirName))
                        {
                                return true;
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                stream.Close();
                return false;
            });

        }

        ///  </summary>
        /// 在ftp服务器上创建指定目录,父目录不存在则创建
        /// </summary>
        /// <param name="dirName">创建的目录名称</param>
        public bool MakeDir(string dirName)
        {
            var dirs = dirName.Split(new char[] { '/' },StringSplitOptions.RemoveEmptyEntries).ToList();//针对多级目录分割
            string currentDir = string.Empty;
            return MethodInvoke($@"MakeDir({dirName})", () =>
            {
                foreach (var dir in dirs)
                {
                    if (!CheckDir(dir, currentDir))//检查目录不存在则创建
                    {
                        currentDir = Path.Combine(currentDir, dir);
                        string uri = Path.Combine(ftpURI, currentDir);
                        FtpWebRequest ftp = GetRequest(uri);
                        ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                        FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                        response.Close();
                    }
                    else
                    {
                        currentDir = Path.Combine(currentDir, dir);
                    }
                }

            });

        }

        /// <summary>文件重命名 </summary>
        /// <param name="currentFilename">当前名称</param>
        /// <param name="newFilename">重命名名称</param>
        /// <param name="currentFilename">所在的目录</param>
        public bool Rename(string currentFilename, string newFilename, string dirName = "")
        {
            string uri = Path.Combine(ftpURI, dirName+currentFilename);
            return MethodInvoke($@"Rename({currentFilename},{newFilename},{dirName})", () =>
            {
                FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.Rename;
                ftp.RenameTo = newFilename;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            });
        }
    }

    public class ActFile
    {
        public int level { get; set; } = 0;
        public bool isDir { get; set; }
        public string name { get; set; }
        public string path { get; set; } = "";
    }
}