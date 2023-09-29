using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GacApi
{
    public static class AppFactory
    {
        public static object CreateInterface(Type type, string dllPath)
        {
            object result = null;
            try
            {
                Assembly assembly = Assembly.LoadFrom(dllPath);
                Type[] exportedTypes = assembly.GetExportedTypes();
                for (int i = 0; i < exportedTypes.Length; i++)
                {
                    Type type2 = exportedTypes[i];
                    if (!type2.IsAbstract && type2.IsPublic && type2.IsClass && type.IsAssignableFrom(type2))
                    {
                        result = Activator.CreateInstance(type2);
                        break;
                    }
                }
            }
            catch
            {
            }
            return result;
        }
        public static ISpider CreateSpider(string dllPath)
        {
            object obj = CreateInterface(typeof(ISpider), dllPath);
            if (obj != null)
            {
                return (ISpider)obj;
            }
            return null;
        }
        public static IWebPost CreateWebPost(string dllPath)
        {
            object obj = CreateInterface(typeof(IWebPost), dllPath);
            if (obj != null)
            {
                return (IWebPost)obj;
            }
            return null;
        }


    }
}
