using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GAC_Collection
{
    public static class Path
    {
        public static string ModuleDir;
        public static string PluginDIr;
        

        public static string UserConfigDir;

        public static string AppExtensionDir;

        public static string SystemDir;

        public static string LogsDir;

        public static string CommitLogFile;

        public static string DllCacheDir;

        public static string SysDataDir;

        public static string TempDir;

        public static string ChmFile;

        public static string AutoUpdate;

        public static string CronXmlFile;

        public static string AppData;

        static Path()
        {
            LoadPath();
        }

        private static void LoadPath()
        {
            Path.ModuleDir = AppDomain.CurrentDomain.BaseDirectory + "Module\\";
            Path.PluginDIr = AppDomain.CurrentDomain.BaseDirectory + "Plugins\\";
            Path.UserConfigDir = AppDomain.CurrentDomain.BaseDirectory + "Configuration\\";
            Path.AppExtensionDir = AppDomain.CurrentDomain.BaseDirectory + "Extensions\\";
            Path.SystemDir = AppDomain.CurrentDomain.BaseDirectory + "System\\";
            Path.LogsDir = AppDomain.CurrentDomain.BaseDirectory + "System\\Logs\\";
            //Path.CommitLogFile = AppDomain.CurrentDomain.BaseDirectory + "System\\SysData\\LogFile.txt";
            Path.DllCacheDir = AppDomain.CurrentDomain.BaseDirectory + "System\\DllCache\\";
            Path.SysDataDir = AppDomain.CurrentDomain.BaseDirectory + "System\\SysData\\";
            Path.TempDir = System.IO.Path.GetTempPath() + "~GacSpider~\\";
            Path.ChmFile = AppDomain.CurrentDomain.BaseDirectory + "help.chm";
            Path.AutoUpdate = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdate.exe";
            Path.CronXmlFile = AppDomain.CurrentDomain.BaseDirectory + "Configuration\\Cron.xml";
            Path.AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "GacSpider\\";
            try
            {
                if (!Directory.Exists(Path.PluginDIr))
                {
                    Directory.CreateDirectory(Path.PluginDIr);
                }
                if (!Directory.Exists(Path.UserConfigDir))
                {
                    Directory.CreateDirectory(Path.UserConfigDir);
                }
                if (!Directory.Exists(Path.SystemDir))
                {
                    Directory.CreateDirectory(Path.SystemDir);
                }
                if (!Directory.Exists(Path.DllCacheDir))
                {
                    Directory.CreateDirectory(Path.DllCacheDir);
                }
                if (!Directory.Exists(Path.TempDir))
                {
                    Directory.CreateDirectory(Path.TempDir);
                }
                if (!Directory.Exists(Path.AppData))
                {
                    Directory.CreateDirectory(Path.AppData);
                }
            }
            catch
            {
            }
        }
    }
}
