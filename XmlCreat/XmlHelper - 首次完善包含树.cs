using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Windows.Forms;
namespace GacXml
{
    public class XmlHelper2
    {
        Dictionary<string, object> diclist = new Dictionary<string, object>();
        #region 辅助程序
        public string GetName(string oldName)
        {
            string key = "abstract,as,base,bool,break,byte,case,catch,char,checked,class,const,continue,decimal,default,delegate,do,double,else,enum,event,explicit,extern,FALSE,finally,static,float,for,foreach,goto,if,implicit,in,int,interface,internal,is,lock,long,namespace,new,null,object,operator,out,override,params,private,protected,public,readonly,ref,return,sbyte,sealed,short,sizeof,stackalloc,string,struct,switch,this,throw,TRUE,try,typeof,uint,ulong,unchecked,unsafe,ushort,using,virtual,void,volatile,while";
            string[] keys = key.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == oldName)
                {
                    string temp = oldName;
                    temp = temp.Substring(0, 1).ToUpper() + temp.Substring(1, temp.Length - 1);
                    return temp;
                }
            }
            return oldName;

        }
        #endregion

        #region xml转实体类
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
                        if (xmlnode.ChildNodes[i].Name + "Collection" == p.Name||p.Name== xmlnode.ChildNodes[i].Name)
                        {
                            //Object objiect= System.Activator.CreateInstance(p.PropertyType);
                            //p.SetValue(entity, XmlToEntity(xmlnode.ChildNodes[i], p.PropertyType), null);
                            IList listtemp = XmlToList(xmlnode, p, xmlnode.ChildNodes[i].Name);
                            p.SetValue(entity, listtemp, null);
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
        public IList XmlToList(XmlNode xmlnode, PropertyInfo p, string Name)
        {
            IList templist = null;
            PropertyInfo[] pArray = p.PropertyType.GetProperties();
            foreach (var item in pArray)
            {
                if (item.Name == "Item")
                {
                    for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
                    {
                        if (Name== "StartAddress")
                        {

                        }
                         if (xmlnode.ChildNodes[i].Name == Name)
                        {
                            if (templist == null)
                            {
                                Type type = typeof(List<>);
                                Type specificListType = type.MakeGenericType(item.PropertyType);
                                templist = (IList)Activator.CreateInstance(specificListType);
                            }
                            if (Name == "Filters")
                            {
                                for (int i2 = 0; i2 < xmlnode.ChildNodes[i].ChildNodes.Count; i2++)
                                {
                                    object xmlvalue = XmlToEntity(xmlnode.ChildNodes[i].ChildNodes[i2], Type.GetType("GacXml."+xmlnode.ChildNodes[i].ChildNodes[i2].Name));
                                    templist.Add(xmlvalue);
                                }
                            }
                            else
                            {
                                object xmlvalue = XmlToEntity(xmlnode.ChildNodes[i], item.PropertyType);
                                templist.Add(xmlvalue);
                            }
                                //p.SetValue()
                                
                        }
                    }
                }
            }
            return templist;
        }

        private IList MakeListOfType(Type listType)
        {
            Type type = typeof(List<>);
            Type specificListType = type.MakeGenericType(listType);

            return (IList)Activator.CreateInstance(specificListType);
        }

        public Object XmlToEntity(XmlNode xmlnode, Type type)
        {
            if (type.Name== "String")
            {
                return xmlnode.InnerXml;
            }
             object o = Activator.CreateInstance(type);
            for (int i = 0; i < xmlnode.Attributes.Count; i++)
            {
                string name = GetName(xmlnode.Attributes[i].Name);
                PropertyInfo p= type.GetProperty(name);
                if (p != null)
                {
                    object value = ValueConvert(xmlnode.Attributes[i].Value, p.PropertyType.FullName);
                    p.SetValue(o, value, null);
                }
                else
                {
                    Console.WriteLine("缺少属性：" + xmlnode.Attributes[i].Name);
                }
            }

            if (xmlnode.Value != null)
            {
                PropertyInfo p = type.GetProperty("Value");
                object value = ValueConvert(xmlnode.Value, p.PropertyType.FullName);
                p.SetValue(o, value, null);
            }

            for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
            {
                if (xmlnode.ChildNodes[i].Name == "#text")
                {
                    PropertyInfo p = type.GetProperty("Value");
                    object value = ValueConvert(xmlnode.ChildNodes[i].Value, p.PropertyType.FullName);
                    p.SetValue(o, value, null);
                }
                else
                {
                    string name = GetName(xmlnode.ChildNodes[i].Name);
                    if (type.Name== "Object")
                    {
                        Type typetemp = Type.GetType("GacXml."+ name);
                        return XmlToEntity(xmlnode.ChildNodes[i], typetemp);
                    }else
                    {
                      
                        PropertyInfo p = type.GetProperty(name + "Collection");
                        if (p==null)
                        {
                            p = type.GetProperty(name);
                        }
                        if (p!=null)
                        {
                            if ("Filters" == xmlnode.ChildNodes[i].Name)
                            {
                            }
                            IList listtemp = XmlToList(xmlnode, p, xmlnode.ChildNodes[i].Name);
                            p.SetValue(o, listtemp, null);
                        }
                        else
                        {
                            PropertyInfo[] pArray = type.GetProperties();
                            Console.WriteLine("缺少列表属性：" + name + "Collection");
                        }
                    }
                }

            }

            //    if (xmlnode.ChildNodes.Count==1 && xmlnode.ChildNodes[0].Name == "#text")
            //{
               
            //}

            return o;
            //PropertyInfo[] pArray = type.GetProperties();
            //object o = Activator.CreateInstance(type);
            //foreach (PropertyInfo p in pArray)
            //{
            //    if (p.PropertyType.Name == "List`1")
            //    {
            //        if (p.Name == "FiltersCollection")
            //        {

            //        }
            //        for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
            //        {
            //            if (xmlnode.ChildNodes[i].Name + "Collection" == p.Name)
            //            {
            //                //Object objiect = System.Activator.CreateInstance(p.PropertyType);
            //                //p.SetValue(o, XmlToEntity(xmlnode.ChildNodes[i], p.PropertyType), null);
            //                //XmlToList(xmlnode, p, xmlnode.ChildNodes[i].Name);
            //                IList listtemp = XmlToList(xmlnode, p, xmlnode.ChildNodes[i].Name);
            //                p.SetValue(o, listtemp, null);
            //            }
            //        }

            //    }
            //    else
            //    {
            //        string str = GetValue(xmlnode, p.Name);
            //        if (p.PropertyType.Name == "Boolean" && string.IsNullOrEmpty(str))
            //        {
            //            str = "true";
            //        }
            //        if (!string.IsNullOrEmpty(str))
            //        {
            //            object value = ValueConvert(str, p.PropertyType.FullName);
            //            p.SetValue(o, value, null);
            //        }

            //    }
            //}

            //return o;
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
        public string GetValue(XmlNode xmlnode, string key)
        {
            for (int i = 0; i < xmlnode.Attributes.Count; i++)
            {
                if (xmlnode.Attributes[i].Name.ToLower() == key.ToLower())
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
        #endregion
        #region  xml转代码
        public void ShowXml(XmlNode xmlnode, TreeNodeCollection tnc)
        {
            if (xmlnode.Attributes != null)
            {
                for (int i = 0; i < xmlnode.Attributes.Count; i++)
                {
                    string name = GetName(xmlnode.Attributes[i].Name);
                    tnc.Add(name + "=" + xmlnode.Attributes[i].Value);
                }
            }
            if (xmlnode.Value != null)
            {
                tnc.Add("Value=" + xmlnode.Value);
            }
            for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
            {
                TreeNodeCollection tnctemp = null;
                if (xmlnode.ChildNodes[i].Name == "#text")
                {

                    tnc.Add("Value=" + xmlnode.ChildNodes[i].OuterXml);

                }
                else
                {
                    tnctemp = tnc.Add(xmlnode.ChildNodes[i].Name).Nodes;
                    ShowXml(xmlnode.ChildNodes[i], tnctemp);
                }


                //foreach (var item in dictemp)
                //{
                //    bool islist = false;
                //    int tempcount = GetXmlCount(xmlnode, item.Key);
                //    if (tempcount > 1)
                //    {
                //        islist = true;
                //    }
                //    if (xmlnode.ChildNodes[i].Name != "#text")
                //    {
                //        if (!((Dictionary<string, object>)dic[xmlnode.ChildNodes[i].Name]).ContainsKey(item.Key))
                //        {
                //            ((Dictionary<string, object>)dic[xmlnode.ChildNodes[i].Name]).Add(item.Key, item.Value);
                //        }

                //    }
                //}
            }
        }
        Dictionary<string, object> dic = new Dictionary<string, object>();
        public void GetXml(XmlNode xmlnode)
        {
            dic.Clear();
            diclist.Clear();
            GetXml(xmlnode, ref dic);
        }
        public void GetXml(XmlNode xmlnode, ref Dictionary<string, object> dic)
        {
            if (xmlnode.Attributes != null)
            {
                for (int i = 0; i < xmlnode.Attributes.Count; i++)
                {
                    if (!dic.ContainsKey(xmlnode.Attributes[i].Name))
                    {
                        string name = GetName(xmlnode.Attributes[i].Name);
                        dic.Add(name, new OneValue { Defult = xmlnode.Attributes[i].Value, TypeName = GetValueTryParse(xmlnode.Attributes[i].Value) });

                    }
                }
            }
            if (xmlnode.Value != null)
            {
                if (!dic.ContainsKey("Value"))
                {
                    dic.Add("Value", new OneValue() { Defult = xmlnode.Value, TypeName = GetValueTryParse(xmlnode.Value) });
                }

            }
            for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
            {
                if (!dic.ContainsKey(xmlnode.ChildNodes[i].Name))
                {
                    if (xmlnode.ChildNodes[i].Name == "#text")
                    {
                        if (!dic.ContainsKey("Value"))
                        {
                            dic.Add("Value", new OneValue() { Defult = xmlnode.ChildNodes[i].OuterXml, TypeName = GetValueTryParse(xmlnode.ChildNodes[i].OuterXml) });
                        }
                        continue;
                    }
                }
                Dictionary<string, object> dictemp = null;
                if (!diclist.ContainsKey(xmlnode.ChildNodes[i].Name))
                    {
                        Dictionary<string, object> dictemp1 = new Dictionary<string, object>();
                        dic.Add(xmlnode.ChildNodes[i].Name, dictemp1);
                        diclist.Add(xmlnode.ChildNodes[i].Name, dictemp1);
                        dictemp = dictemp1;
                    }
                    else
                    {
                   
                        dictemp = (Dictionary<string, object>)diclist[xmlnode.ChildNodes[i].Name];
                    }
                if (diclist.ContainsKey(xmlnode.ChildNodes[i].Name))
                {
                    if (diclist.ContainsKey(xmlnode.Name))
                    {
                        if (!((Dictionary<string, object>)diclist[xmlnode.Name]).ContainsKey(xmlnode.ChildNodes[i].Name))
                        {
                            ((Dictionary<string, object>)diclist[xmlnode.Name]).Add(xmlnode.ChildNodes[i].Name, dictemp);
                        }
                       
                    }
                  
                  
                }
                //}

                //int tempcount = GetXmlCount(xmlnode, xmlnode.ChildNodes[i].Name);
                //if (tempcount > 1)
                //{
                //    if (!dictemp.ContainsKey("IsGacList"))
                //    {
                //        dictemp.Add("IsGacList", true);
                //    }
                //}
                //
                GetXml(xmlnode.ChildNodes[i], ref dictemp);
            }
        }
        public int GetXmlCount(XmlNode xmlnode, string Name)
        {
            int temp = 0;
            for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
            {
                if (xmlnode.ChildNodes[i].Name == Name)
                {
                    temp++;
                }
            }
            return temp;
        }
        Dictionary<string, string> dictype = new Dictionary<string, string>();
        public string GetValueTryParse(string p_Value)
        {
            //if (string.IsNullOrEmpty(p_Value))
            //{
            //    return "bool";
            //}
            // Assembly _Assembly = Assembly.Load("mscorlib");
            //            Type[] _TypeList = _Assembly.GetTypes();
            Type[] _TypeList = new Type[] { Type.GetType("System.Int32"), Type.GetType("System.Int64"), Type.GetType("System.Double"), Type.GetType("System.Decimal"), Type.GetType("System.Char") };
            string[] types = new
                 string[] { };
            foreach (Type _TypeInfo in _TypeList)
            {
                if (_TypeInfo.IsSerializable == false) continue;

                MethodInfo _Method = _TypeInfo.GetMethod("TryParse", new Type[] { Type.GetType("System.String"), Type.GetType(_TypeInfo.FullName + "&") });
                if (_Method == null) continue;
                object _ObjectValue = Activator.CreateInstance(_TypeInfo);
                bool _Value = (bool)_Method.Invoke(null, new object[] { p_Value, _ObjectValue });
                if (_Value == true)
                {
                    if (!dictype.ContainsKey(_TypeInfo.FullName))
                    {
                        dictype.Add(_TypeInfo.FullName, _TypeInfo.Name);
                    }
                    return _TypeInfo.Name;
                }


            }

            return "string";
        }
        private class OneValue
        {
            private bool _IsList = false;
            public string Defult { get; set; }
            public string TypeName { get; set; }

            public bool IsList { get { return _IsList; } set { _IsList = value; } }
        }
        public void ShowXml(Dictionary<string, object> dic, TreeNodeCollection tnc)
        {
            foreach (var item in dic)
            {

                if (item.Value is OneValue)
                {
                    TreeNode tn = tnc.Add(item.Key + "=" + ((OneValue)item.Value).Defult);
                }
                else
                {
                    TreeNode tn = tnc.Add(item.Key);
                    Dictionary<string, object> dictemp = (Dictionary<string, object>)item.Value;
                    ShowXml(dictemp, tn.Nodes);
                }
            }
        }
        private string ShowCode(string name, string type, string value, bool islist)
        {
            if (islist)
            {
                if (name == "Filters")
                {
                    string tempstr = "    private   List<object>   _" + name + @"Collection   =   default(List<object>);
    public  List<object> " + name + @"Collection
    {
        get { return _" + name + @"Collection; }
        set { _" + name + @"Collection = value; }
    }
";
                    return tempstr;
                }
                else
                {
                    if (type == "Value")
                    {
                        string tempstr = "    private   List<string>   _" + name + @"  =   default(List<string>);" + (string.IsNullOrEmpty(value) ? "" : @"
     /// <summary>
     /// 参考值：" + value + @" 
     /// </summary>") + @"
    public  List<string> " + name + @"
    {
        get { return _" + name +@"; }
        set { _" + name + @" = value; }
    }
";
                        return tempstr;
                    }
                    else
                    {
                        string tempstr = "    private   List<" + name + ">   _" + name + @"Collection   =   default(List<" + name + @">);
        public List<" + name + "> " + name + @"Collection
    {
        get { return _" + name + @"Collection; }
        set { _" + name + @"Collection = value; }
    }
";
                        return tempstr;
                    }
                   
                   
                }
            }
            else
            {
                string tempstr = "    private   " + type + "   _" + name + @"   =   default(" + type + @");" + (string.IsNullOrEmpty(value) ? "" : @"
     /// <summary>
    /// 参考值：" + value + @" 
    /// </summary>") + @"
    public  " + type + "  " + name + @"
    {
        get { return _" + name + @"; }
        set { _" + name + @" = value; }
    }
";
                return tempstr;
            }
        }
        public string ShowClass()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"using System;
using System.Xml;
using System.Collections.Generic;
namespace GacXml{");
            string classstr = ShowClass(dic);
            string liststr= ShowClass(diclist,"",false);
            sb.AppendLine(classstr);
            sb.AppendLine(liststr);
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string ShowClass(Dictionary<string, object> dic1, string key = "",bool IsClass=true)
        {
            StringBuilder sb = new StringBuilder();
            #region 头部
            if (!string.IsNullOrEmpty(key))
            {
                sb.AppendLine(@" 
public  class " + key + @"
{ ");

            }
            else
            {
                if (IsClass)
                {
                    sb.AppendLine(@" 
public  class root
{ ");
                }

            }
            #endregion
            if (key == "StartAddress")
            {

            }
            if (IsClass)
            {
                foreach (var item in dic1)
                {
                    if (item.Value is OneValue)
                    {
                        if (item.Key == "StartAddress")
                        {

                        }
                        OneValue temp = (OneValue)item.Value;
                        string tempstr = ShowCode(item.Key, temp.TypeName, temp.Defult, temp.IsList);
                        sb.AppendLine(tempstr);
                    }
                    else
                    {
                        Dictionary<string, object> dictemp = (Dictionary<string, object>)item.Value;
                        string type = "";
                        string value = "";
                        if (dictemp.Count == 1 && dictemp.ContainsKey("Value"))
                        {
                            type ="Value";
                            OneValue temp = (OneValue)dictemp["Value"];
                            value = temp.Defult;
                        }
                        if (item.Key == "StartAddress")
                        {

                        }
                        string tempstr = ShowCode(item.Key, type, value, true);
                        sb.AppendLine(tempstr);
                        //}
                    }
                }
            }else
            {
                foreach (var item in dic1)
                {
                    if (item.Value is OneValue)
                    {

                    }
                    else
                    {
                        Dictionary<string, object> dictemp = (Dictionary<string, object>)item.Value;

                        //else
                        //{ 
                            string temp = ShowClass(dictemp, item.Key,true);
                            sb.AppendLine(temp);
                        //}
                    }
                }
            }
            if (IsClass)
            {
                sb.AppendLine("}");
            }
            
            return sb.ToString();
        }


        #endregion
    }
}
