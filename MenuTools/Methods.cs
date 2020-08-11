using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace MenuTools.Methods
{
    internal static class ShortcutHandler
    {
        internal static string GetShortcutTarget(string shortcutFilename)
        {
            string pathOnly = Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = Path.GetFileName(shortcutFilename);
            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder folder = shell.NameSpace(pathOnly);
            Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                if (folderItem.IsLink)
                {
                    Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                    return link.Path;
                }
                return shortcutFilename;
            }
            else
            {
                return "";
            }
        }
    }
    internal static class DesktopWallpaper
    {
        private static byte[] SliceMe(byte[] source, int pos)
        {
            byte[] dest = new byte[source.Length - pos];
            Array.Copy(source, pos, dest, 0, dest.Length);
            return dest;
        }
        internal static void GetWallpaper()
        {
            byte[] path = (byte[])Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop").GetValue("TranscodedImageCache");
            string wallpaper = Encoding.Unicode.GetString(SliceMe(path, 24)).TrimEnd("\0".ToCharArray());
            StartProcess.StartInfo("explorer.exe", "/select, \"" + wallpaper + "\"");
        }
    }
    internal static class StartProcess
    {
        // Process StartInfo Method
        internal static void StartInfo(string process, string arguments = null, bool hidden = false, bool runas = false, bool wait = false)
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
                proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(process);
                proc.Start();
                if (wait)
                {
                    proc.WaitForExit();
                }
            }
        }
    }
    internal static class AttributesInfo
    {
        // Boolean
        internal static bool hidden;
        internal static bool system;
        internal static bool readOnly;
        internal static bool HiddenFilesShowing;
        internal static bool SystemFilesShowing;
        // Strings
        internal const string UserRoot = "HKEY_CURRENT_USER\\";
        internal const string ExplorerAdvanced = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
        internal static FileAttributes RemoveAttribute
        (FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
        internal static void GetFileAttributes(string folderPath)
        {
            try
            {
                // Get : Set Attributes
                FileAttributes attributes = File.GetAttributes(folderPath);
                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    hidden = true;
                }
                if ((attributes & FileAttributes.System) == FileAttributes.System)
                {
                    system = true;
                }
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    readOnly = true;
                }
                if ((attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    hidden = false;
                }
                if ((attributes & FileAttributes.System) != FileAttributes.System)
                {
                    system = false;
                }
                if ((attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    readOnly = false;
                }
            }
            catch (Exception ex)
            {
                StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "\"" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite + "\"" + " -catchhandler");
            }
            // Get Attributes
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(ExplorerAdvanced))
                {
                    Trace.Assert(key != null);
                    object hidden = key.GetValue("Hidden");
                    Trace.Assert(hidden != null);
                    if (hidden.ToString() == "1")
                    {
                        HiddenFilesShowing = true;
                    }
                    if (hidden.ToString() == "2")
                    {
                        HiddenFilesShowing = false;
                    }
                    object system = key.GetValue("ShowSuperHidden");
                    Trace.Assert(system != null);
                    if (system.ToString() == "1")
                    {
                        SystemFilesShowing = true;
                    }
                    if (system.ToString() == "2")
                    {
                        SystemFilesShowing = false;
                    }
                }
            }
            catch (Win32Exception wex)
            {
                StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "\"" + wex.Message + Environment.NewLine + wex.StackTrace + Environment.NewLine + wex.Source + Environment.NewLine + wex.GetBaseException() + Environment.NewLine + wex.TargetSite + "\"" + " -catchhandler");
            }
            catch (Exception ex)
            {
                StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "\"" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite + "\"" + " -catchhandler");
            }
        }
        internal static class GetAssembly
        {
            // Get Assembly Information
            public static string AssemblyInformation(string args)
            {
                string AssemblyInfo = null;
                if (args == "filelocation")
                {
                    AssemblyInfo = Assembly.GetEntryAssembly().Location;
                }
                if (args == "directory")
                {
                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    UriBuilder uri = new UriBuilder(codeBase);
                    string uriInfo = Uri.UnescapeDataString(uri.Path);
                    AssemblyInfo = Path.GetDirectoryName(uriInfo);
                }
                if (args == "filename")
                {
                    AssemblyInfo = Assembly.GetEntryAssembly().GetName().Name;
                }
                if (args == "version")
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    AssemblyInfo = fvi.FileVersion;
                }
                return AssemblyInfo;
            }
        }
    }

    internal static class ToStringExtension
    {
        public static string ToStringArray(this string[] array, bool Naming = false)
        {
            string result = string.Empty;
            if (Naming)
            {
                if (array.Length > 1)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        string name = Path.GetFileName(array[i]);
                        if (i == array.Length - 1)
                        {
                            result += ((i + 1) % 5 == 0) ? name + "" : name + "";
                        }
                        else
                        {
                            result += ((i + 1) % 5 == 0) ? name + "\n" : name + "\n";
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        string name = Path.GetFileName(array[i]);
                        result += ((i + 1) % 5 == 0) ? name + "" : name + "";
                    }
                }
            }
            else
            {
                if (array.Length > 1)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (i == array.Length - 1)
                        {
                            result += ((i + 1) % 5 == 0) ? array[i] + "" : array[i] + "";
                        }
                        else
                        {
                            result += ((i + 1) % 5 == 0) ? array[i] + "\n" : array[i] + "\n";
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        result += ((i + 1) % 5 == 0) ? array[i] + "" : array[i] + "";
                    }
                }
            }
            return result;
        }
    }
}
