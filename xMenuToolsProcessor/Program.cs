using System;
using System.IO;
using System.Windows.Forms;

namespace xMenuToolsProcessor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Logging
            TimeSpan ts = DateTime.Now - File.GetLastAccessTime(EasyLogger.LogFile);
            if (ts.Days > 30)
            {
                EasyLogger.BackupLogs(EasyLogger.LogFile);
            }
            EasyLogger.AddListener(EasyLogger.LogFile);

            Application.Run(new Main(args));
        }
    }
}
