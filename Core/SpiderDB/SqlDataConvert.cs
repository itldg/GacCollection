using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GAC_Collection.Helper
{
    public class SqlDataConvert
    {

        private T TableToEntity<T>(DataRow row) where T : class, new()
        {
            Type type = typeof(T);
            PropertyInfo[] pArray = type.GetProperties();
            T entity = new T();
            foreach (PropertyInfo p in pArray)
            {
                if (row[p.Name] is Int64)
                {
                    if (p.PropertyType.Name == "Boolean")
                    {
                        p.SetValue(entity, Convert.ToBoolean(row[p.Name]), null);
                    }
                    else
                    {
                        p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                    }
                }
                else if (row[p.Name] is byte)
                {
                    p.SetValue(entity, Convert.ToBoolean(row[p.Name]), null);
                }
                else
                {
                    p.SetValue(entity, row[p.Name], null);
                }
            }
            return entity;
        }
    }
}
