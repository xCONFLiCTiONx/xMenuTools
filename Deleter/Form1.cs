using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Deleter
{
    public partial class Form1 : Form
    {
        public Form1(string[] args)
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            if (args.Length > 0)
            {
                Thread t = new Thread(() => DELETER(args[0]))
                {
                    IsBackground = true
                };
                t.Start();
            }
            else
            {
                Environment.Exit(0);
            }

            TopMost = false;

            WindowState = FormWindowState.Normal;
        }

        #region Global Exception Handling
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            EasyLogger.Error("Application.ThreadException: Base Exception: " + e.Exception.GetBaseException() + Environment.NewLine + "Exception Message: " + e.Exception.Message);
        }

        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            EasyLogger.Error("AppDomain.UnhandledException: Exception Object: " + e.ExceptionObject + Environment.NewLine + "Exception Object: " + ((Exception)e.ExceptionObject).Message);
        }

        #endregion Global Exception Handling

        private void DELETER(string directory)
        {
            Thread.Sleep(5000);
            while (Directory.Exists(directory))
            {
                try
                {
                    Directory.Delete(directory, true);
                }
                catch (Exception)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

            try
            {
                using (StreamWriter sw = File.CreateText(Path.GetTempPath() + "Deleter.bat"))
                {
                    sw.WriteLine("timeout 5");
                    sw.WriteLine("del " + "\"" + Path.GetTempPath() + "Deleter.exe" + "\"" + " /f /q");
                    sw.WriteLine("del " + "\"" + Path.GetTempPath() + "Deleter.bat" + "\"" + " /f /q");
                    sw.WriteLine("pause");
                }
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = Path.GetTempPath() + "Deleter.bat";
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                EasyLogger.Error(ex);
            }

            Environment.Exit(0);
        }
    }
}
