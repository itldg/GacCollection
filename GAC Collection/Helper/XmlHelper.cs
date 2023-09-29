using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace GAC_Collection.Helper
{
    public class XmlHelper
    {
        public static void Save2File(string xml, string filePath, ref string errMsg)
        {
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false))
                {
                    sw.Write(xml);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                //DMSFrame.Loggers.LoggerManager.FileLogger.LogWithTime(ex.Message);
                errMsg = "writer file " + filePath + ex.Message;
            }
        }
        public static void DeleteFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
        public static string LoadFromString(string filePath, ref string errMsg)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                {
                    return string.Empty;
                }
                using (System.IO.StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    string xmlStr = reader.ReadToEnd();
                    reader.Close();
                    return xmlStr;
                }

            }
            catch (Exception ex)
            {
                //DMSFrame.Loggers.LoggerManager.FileLogger.LogWithTime(ex.Message);
                errMsg = "load file string" + filePath + ex.Message;
            }
            return string.Empty;
        }
        public static string Save2File<T>(T entity, string filePath)
        {
            string errMsg0 = string.Empty;
            string xml = LoadFromString(filePath, ref errMsg0);
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
                xmlSerializer.Serialize(streamWriter, entity);
                streamWriter.Close();
                return "";
            }
            catch (Exception ex)
            {
                string errMsg = "save file " + filePath + ex.Message;
                //LoggerManager.FileLogger.Log("", "不能保存TableConfigCollection配置文件!", ReflectionUtils.GetMethodBaseInfo(System.Reflection.MethodBase.GetCurrentMethod()), ErrorLevel.Fatal);
                Save2File(xml, filePath, ref errMsg0);//做备份
                //throw new Exception("不能保存TableConfigCollection配置文件：" + ex.Message, ex);
                return errMsg;

            }
        }

        public static T LoadFromXml<T>(string filePath, ref string errMsg) where T : new()
        {
            errMsg = string.Empty;
            T configResult = default(T);
            if (!System.IO.File.Exists(filePath))
            {
                configResult = new T();
                Save2File(configResult, filePath);
                return configResult;
            }
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    string xmlStr = reader.ReadToEnd();
                    reader.Close();
                    byte[] b = Encoding.UTF8.GetBytes(xmlStr);
                    MemoryStream ms = new MemoryStream(b);
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    StreamReader sr = new StreamReader(ms, Encoding.UTF8);
                    configResult = (T)ser.Deserialize(sr);
                    sr.Close();
                    ms.Close();
                }

            }
            catch (Exception ex)
            {
               // DMSFrame.Loggers.LoggerManager.FileLogger.LogWithTime(ex.Message);
                errMsg = "load file " + filePath + ex.Message;
            }
            return configResult;
        }
    }
}
