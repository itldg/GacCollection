
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GacBrowser
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmBrowser fb= new FrmBrowser(Properties.Resources.SiteUrl);
            fb.getFlag = -1;
            Application.Run(fb);
        }
    }
}
