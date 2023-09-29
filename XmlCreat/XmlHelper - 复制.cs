using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;


namespace XmlCreat1
{
    public class XmlHelper
    {
        public T XmlToEntity<T>(string XmlContent) where T : class, new()
        {
            Type type = typeof(T);
            PropertyInfo[] pArray = type.GetProperties();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XmlContent);
            XmlElement root = doc.DocumentElement;
            return XmlToEntity<T>(root);
        }
        public T XmlToEntityFromFile<T>(string XmlFile) where T : class, new()
        {
            Type type = typeof(T);
            PropertyInfo[] pArray = type.GetProperties();
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFile);
            XmlElement root = doc.DocumentElement;
            return XmlToEntity<T>(root);
        }

        public T XmlToEntity<T>(XmlNode xmlnode) where T : class, new()
        {
            Type type = typeof(T);
            PropertyInfo[] pArray = type.GetProperties();
            T entity = new T();

            foreach (PropertyInfo p in pArray)
            {
                if (p.PropertyType.Name == "List`1")
                {
                    for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
                    {
                        if (xmlnode.ChildNodes[i].Name + "Collection" == p.Name)
                        {
                            //Object objiect= System.Activator.CreateInstance(p.PropertyType);
                            p.SetValue(entity, XmlToEntity(xmlnode.ChildNodes[i], p.PropertyType), null);
                            XmlToList(xmlnode, p, xmlnode.ChildNodes[i].Name);
                        }
                    }

                }
                else
                {
                    string str = GetValue(xmlnode, p.Name);
                    if (p.PropertyType.Name == "Boolean" && string.IsNullOrEmpty(str))
                    {
                        str = "true";
                    }
                    object value = ValueConvert(str, p.PropertyType.FullName);
                    p.SetValue(entity, value, null);
                }
            }

            return entity;
        }
        public void XmlToList(XmlNode xmlnode, PropertyInfo p,string Name)
        {
            PropertyInfo[] pArray = p.PropertyType.GetProperties();
            foreach (var item in pArray)
            {
                if (item.Name == "Item")
                {
                    for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
                    {
                        if (xmlnode.ChildNodes[i].Name == Name)
                        {
                            //p.SetValue()
                            object xmlvalue = XmlToEntity(xmlnode.ChildNodes[i], item.PropertyType);

                            //MethodInfo method =("Add", new Type[] { item.PropertyType });
                            ////method.Invoke(null, new object[]{ xmlvalue});
                            //IList test = MakeListOfType(p.GetType().GetGenericArguments()[0]);
                            Type type = typeof(List<>);
                            Type specificListType = type.MakeGenericType(item.PropertyType);

                            IList test = (IList)Activator.CreateInstance(specificListType);
                            //object objItem = Activator.CreateInstance(obj.GetType().GetGenericArguments()[0]);
                            test.Add(xmlvalue);
                        }
                    }
                }
            }
        }
     
        private IList MakeListOfType(Type listType)
    {
        Type type = typeof(List<>);
        Type specificListType = type.MakeGenericType(listType);

        return (IList)Activator.CreateInstance(specificListType);
    }

public Object XmlToEntity(XmlNode xmlnode,Type type)
        {
           
            PropertyInfo[] pArray = type.GetProperties();
           object o = Activator.CreateInstance(type);
            foreach (PropertyInfo p in pArray)
            {
                if (p.PropertyType.Name == "List`1")
                {
                    for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
                    {
                        if (xmlnode.ChildNodes[i].Name + "Collection" == p.Name)
                        {
                            Object objiect = System.Activator.CreateInstance(p.PropertyType);
                            p.SetValue(o, XmlToEntity(xmlnode.ChildNodes[i],p.PropertyType), null);
                            XmlToList(xmlnode, p, xmlnode.ChildNodes[i].Name);
                        }
                    }

                }
                else
                {
                    string str = GetValue(xmlnode, p.Name);
                    if (p.PropertyType.Name == "Boolean" && string.IsNullOrEmpty(str))
                    {
                        str = "true";
                    }
                    if (!string.IsNullOrEmpty(str))
                    {
                        object value = ValueConvert(str, p.PropertyType.FullName);
                        p.SetValue(o, value, null);
                    }
                   
                }
            }

            return o;
        }

        private object ValueConvert(string value, string type)
        {
            if (type == "System.String")
            {
                return value;
            }
            Type typeinfo = Type.GetType(type);
            MethodInfo _Method = typeinfo.GetMethod("Parse", new Type[] { typeof(string) });
            if (_Method == null) return "";
            object _ObjectValue = Activator.CreateInstance(typeinfo);
            try
            {
                object _Value = (object)_Method.Invoke(null, new object[] { value });
                return _Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("数据转换出错：" + ex.Message);
                return "";
            }
            
        }
        public string GetValue(XmlNode xmlnode,string key)
        {
            for (int i = 0; i < xmlnode.Attributes.Count; i++)
            {
                if (xmlnode.Attributes[i].Name.ToLower()==key.ToLower())
                {
                    return xmlnode.Attributes[i].Value;
                }
            }
            if (key == "Value")
            {
                if (xmlnode.Value != null)
                {
                    return xmlnode.Value;
                }
                for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
                {
                    if (xmlnode.ChildNodes[i].Name == "#text")
                    {
                        return xmlnode.ChildNodes[i].OuterXml;
                    }
                }
            }
            return "";

        }
    }
}
