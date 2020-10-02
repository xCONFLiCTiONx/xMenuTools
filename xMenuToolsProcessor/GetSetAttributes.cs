using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static xMenuToolsProcessor.SendMessage;

namespace xMenuToolsProcessor
{
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
            catch (Win32Exception ex)
            {
                MessageForm(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite, "xMenuTools", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
