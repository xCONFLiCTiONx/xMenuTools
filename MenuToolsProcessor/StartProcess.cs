using System;
using System.Diagnostics;

namespace MenuToolsProcessor
{
    internal static class StartProcess
    {
        // Process StartInfo Method
        internal static void StartInfo(string process, string arguments = null, bool hidden = false, bool runas = false, bool wait = false)
        {
            try
            {
                using (Process proc = new Process())
                {
                    if (arguments != null)
                    {
                        proc.StartInfo.Arguments = arguments;
                    }

                    proc.StartInfo.FileName = process;
                    if (hidden)
                    {
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    }

                    if (runas)
                    {
                        proc.StartInfo.Verb = "runas";
                    }

                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                    if (wait)
                    {
                        proc.WaitForExit();
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
