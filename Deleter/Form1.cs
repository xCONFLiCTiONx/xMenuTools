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
                    // ignore
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
            catch (Exception)
            {
                // ignore
            }

            Environment.Exit(0);
        }
    }
}
