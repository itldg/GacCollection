using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GAC_Collection
{
    public static class GacCommon
    {
        public static void ShowTip(string message, Control contror)
        {
            int TimeOut = 3000;
            ToolTip ttMessage = new ToolTip();
            ttMessage.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            ttMessage.ToolTipTitle = "GAC警告提示";
            Form frm= contror.Parent.FindForm();

            contror.Focus();
            ttMessage.Show(message, contror, 0, contror.Height + 5, TimeOut);
            Thread th = new Thread(delegate ()
            {
                Thread.Sleep(TimeOut);
                if (!frm.IsDisposed)
                {
                    frm.Invoke((MethodInvoker)delegate ()
                    {

                        ttMessage.Dispose();
                    });

                }

            });
            th.Start();
            
            
            
        }
        public static List<string> ItemsToTList(IList Items)
        {
            string[] items = new string[Items.Count] ;
            string type = Items.GetType().ToString();
            if (type == "System.Windows.Forms.ListView+ListViewItemCollection")
            {
                List<string> list = new List<string>();
                foreach (var item in Items)
                {
                    list.Add(((ListViewItem)item).Text);
                }
                return list;
            }
            else
            {
                Items.CopyTo(items, 0);
                List<string> list = items.ToList<string>();
                return list;
            }
            
           

        }
        //
        public static List<T> ItemsToTList<T>(ListView.ListViewItemCollection Items) where T : class, new()
        {
            List<T> list = new List<T>();

            Type type = typeof(T);
            PropertyInfo[] pArray = type.GetProperties();

            bool isStr = type.Name == "String";

            for (int i = 0; i < Items.Count; i++)
            {
                if (isStr)
                {
                    list.Add((T)(Object)Items[i].ToString());
                }
                else
                {
                    T entity = new T();
                    entity = (T)Items[i].Tag;
                    list.Add(entity);
                }
            }
            return list;
        }
    }
}
