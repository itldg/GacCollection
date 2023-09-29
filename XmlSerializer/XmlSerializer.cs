using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Gac
{
    public  class XmlSerializerHelper
    {
        public  void SaveToXml(string filePath, object sourceObj, Type type = null, string xmlRootName = "")
        {
            if (!string.IsNullOrEmpty(filePath) && sourceObj != null)
            {
                type = type != null ? type : sourceObj.GetType();

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrEmpty(xmlRootName) ?
                        new System.Xml.Serialization.XmlSerializer(type) :
                        new System.Xml.Serialization.XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                    xmlSerializer.Serialize(writer, sourceObj);
                }
            }
        }
        public string GetXmlCode(object sourceObj, Type type=null, string xmlRootName="")
        {
            if (sourceObj != null)
            {
                type = type != null ? type : sourceObj.GetType();

                using (StringWriter writer = new StringWriter())
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrEmpty(xmlRootName) ?
                        new System.Xml.Serialization.XmlSerializer(type) :
                        new System.Xml.Serialization.XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                    xmlSerializer.Serialize(writer, sourceObj);
                    return writer.ToString();
                }
            }
            return "";
        }

        public  object LoadFromFile(string filePath, Type type)
        {
            object result = null;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                    result = xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }

        public object LoadFromXml(string XmlContent, Type type)
        {
            using (StringReader sr = new StringReader(XmlContent))
            {
                XmlSerializer xmldes = new XmlSerializer(type);
                return xmldes.Deserialize(sr);
            }
        }
    }
}
