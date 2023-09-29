using Gac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GAC_Collection
{

    public class OutFile: OutHelper
    {
        string _JobName = "";
        int _JobId = 0;
        string _saveDir = "";
        string _FileTemplate = "";
        string _SaveFileFormat = "";
        
        int _FileType = 0;

        string Extension = "";
        string FileCount = "";
        public OutFile()
        {
        }

        public OutFile(string jobName, int jobId, string saveDir, string fileTemplate, string saveFileFormat, int fileType)
        {
            JobName = jobName;
            JobId = jobId;

            //保存路径处理,禁止特殊字符
            SaveDir = saveDir;
            foreach (char rInvalidChar in Path.GetInvalidPathChars())
                SaveDir=SaveDir.Replace(rInvalidChar.ToString(), string.Empty);

            SaveFileFormat = saveFileFormat;
            FileType = fileType;
            FileTemplate=fileTemplate;
            //一条记录保存为一个txt文件
            //一条记录保存为一个html文件
            //一条记录保存为一个Word文档
            //所有记录保存在一个Csv文件
            //所有记录保存在一个Excel文件
            //所有记录保存为一个txt文件
            //所有记录保存为一个html文件
            switch (fileType)
            {
                case 0:
                    Extension=".txt";break;
                case 1:
                    Extension = ".html"; break;
                case 2:
                    Extension = ".Word"; break;
                case 3:
                    Extension = ".Csv"; break;
                case 4:
                    Extension = ".Excel"; break;
                case 5:
                    Extension = ".txt"; break;
                case 6:
                    Extension = ".html"; break;
                default:
                    Extension = ".gac"; break;
            }
        }
        public string GetFileName(Dictionary<string, string> dic)
        {

            string result = SaveFileFormat;
            result = DateTime.Now.ToString(result);

            string randfilename = Path.GetRandomFileName().Replace(".", "");
            result = result.Replace("[随机文件名]", randfilename);

            result = result.Replace("[任务名]", JobName);
            result = result.Replace("[任务Id]", JobId.ToString());
            result = result.Replace("[记录Id]", dic["Id"]);

            foreach (var item in dic)
            {
                result = result.Replace("[标签:" + item.Key + "]", item.Value);
            }

            //string safe = "?*:\" <>\\/| ";
            //文件名处理,预防特殊字符
            result= result.TrimStart(new char[]{ ' '});
            foreach (char rInvalidChar in Path.GetInvalidFileNameChars())
            { 
                result=result.Replace(rInvalidChar.ToString(), string.Empty);
            }

            if (!result.EndsWith(Extension))
            {
                result += Extension;
            }
            if (!SaveDir.EndsWith("\\"))
            {
                SaveDir += "\\";
            }
            return SaveDir + result;
        }

        public override ReturnResult Out(Dictionary<string, string> dic)
        {
            string filename = GetFileName(dic);
            string filecontent = FileCount;
            foreach (var item in dic)
            {
                filecontent = filecontent.Replace("[标签:" + item.Key + "]", item.Value);
            }
            try
            {
                File.WriteAllText(filename, filecontent);
                return new ReturnResult()
                {
                    Success = true,
                    Title = "成功保存到本地文件"
                };
            }
            catch (Exception ex)
            {
                return new ReturnResult()
                {
                    Success = true,
                    Title = "保存到本地文件失败："+ex.Message
                };
            }
           
        }
        public string JobName
        {
            get
            {
                return _JobName;
            }

            set
            {
                _JobName = value;
            }
        }

        public int JobId
        {
            get
            {
                return _JobId;
            }

            set
            {
                _JobId = value;
            }
        }

        public string SaveDir
        {
            get
            {
                return _saveDir;
            }

            set
            {
                _saveDir = value;
            }
        }



        public string SaveFileFormat
        {
            get
            {
                return _SaveFileFormat;
            }

            set
            {
                _SaveFileFormat = value;
               
            }
        }

        public int FileType
        {
            get
            {
                return _FileType;
            }

            set
            {
                _FileType = value;
            }
        }

        public string FileTemplate
        {
            get
            {
                return _FileTemplate;
            }

            set
            {
                _FileTemplate = value;
                FileCount = File.ReadAllText(value);
            }
        }
    }
}
