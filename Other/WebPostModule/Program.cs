﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WebPostModule
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length>0)
            {
                string ModuleDir = Application.StartupPath + "\\Module\\";
                string filename = ModuleDir + args[0] + ".gpm";
                Application.Run(new FrmM(filename));
            }
            else
            {
                Application.Run(new FrmM());
            }
        }
    }
}
