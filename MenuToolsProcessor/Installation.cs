using MenuToolsProcessor.Properties;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static MenuToolsProcessor.SendMessage;

namespace MenuToolsProcessor
{
    internal class Installation
    {
        private static readonly string website = "https://github.com/xCONFLiCTiONx/MenuTools";

        internal static void Install(string location)
        {
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;

                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\MenuTools");
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\MenuTools\\Version.txt", version);

                RegistryKey MenuToolsSettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MenuTools\\Settings");
                RegistryKey InstallInfo = null;
                if (ArchitectureCheck.ProcessorIs64Bit())
                {
                    RegistryKey RegUninstallKey64 = Registry.LocalMachine.CreateSubKey(Resources.RegUninstallKey64String);
                    InstallInfo = RegUninstallKey64;
                }
                if (!ArchitectureCheck.ProcessorIs64Bit())
                {
                    RegistryKey RegUninstallKey32 = Registry.LocalMachine.CreateSubKey(Resources.RegUninstallKey32String);
                    InstallInfo = RegUninstallKey32;
                }
                StartProcess.StartInfo(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe", "\"" + location + "\\MenuTools.dll" + "\"" + " -codebase", true, true, true);

                // Adds Information to Uninstall - Change to 32 bit for compiling x86
                InstallInfo.SetValue("InstallLocation", "\"" + location + "\"", RegistryValueKind.String);
                InstallInfo.SetValue("InstallFileLocation", "\"" + location + @"\MenuTools.exe" + "\"", RegistryValueKind.String);
                InstallInfo.SetValue("UninstallString", "\"" + location + @"\MenuTools.exe" + "\"" + " -uninstall", RegistryValueKind.String);
                InstallInfo.SetValue("DisplayIcon", location + @"\MenuTools.exe", RegistryValueKind.String);
                InstallInfo.SetValue("Publisher", "xCONFLiCTiONx", RegistryValueKind.String);
                InstallInfo.SetValue("HelpLink", website, RegistryValueKind.String);
                InstallInfo.SetValue("DisplayName", Resources.MenuTools, RegistryValueKind.String);
                InstallInfo.SetValue("DisplayVersion", GetAssembly.AssemblyInformation("version"), RegistryValueKind.String);
                /* User Settings */

                // All Files
                MenuToolsSettings.SetValue("OpenNotepadFiles", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("BlockWithFirewallFiles", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("CopyPathFiles", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("CopyNameFiles", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("AttributesFiles", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("SymlinkFiles", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("TakeOwnershipFiles", 0x00000001, RegistryValueKind.DWord);
                // All Files Shorcuts
                MenuToolsSettings.SetValue("AttributesShortcuts", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("OpenNotepadShort", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("CopyPathShortFiles", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("CopyNameShortFiles", 0x00000001, RegistryValueKind.DWord);
                // Directories
                MenuToolsSettings.SetValue("BlockWithFirewallDirectory", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("CopyPathDirectory", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("CopyNameDirectory", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("AttributesDirectory", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("SymlinkDirectory", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("TakeOwnershipDirectory", 0x00000001, RegistryValueKind.DWord);
                // Directory Background
                MenuToolsSettings.SetValue("AttributesDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("CommandLinesDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("FindWallpaperDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("SystemFoldersDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                MenuToolsSettings.SetValue("PasteContentsDirectoryBack", 0x00000001, RegistryValueKind.DWord);

                // Create Shorcut in All Users Start Menu Programs
                StringBuilder allUserProfile = new StringBuilder(260);
                NativeMethods.SHGetSpecialFolderPath(IntPtr.Zero, allUserProfile, NativeMethods.CSIDL_COMMON_STARTMENU, false);

                string programs_path = Path.Combine(allUserProfile.ToString(), "Programs");

                string shortcutFolder = Path.Combine(programs_path, @"MenuTools");
                if (!Directory.Exists(shortcutFolder))
                {
                    Directory.CreateDirectory(shortcutFolder);
                }

                using (new Settings())
                {
                    new Settings().ShowDialog();
                }

                Shortcut.Create(shortcutFolder, InstallInfo.ToString());

                Environment.Exit(0);
            }
            catch (Exception ex)
            {

                MessageForm(ex.Message + Environment.NewLine + ex.StackTrace, Resources.MenuTools, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        internal static void Uninstall()
        {
            try
            {
                RegistryKey RegUninstallKey64 = Registry.LocalMachine.OpenSubKey(Resources.Uninstall64Bit, true);
                RegistryKey RegUninstallKey32 = Registry.LocalMachine.OpenSubKey(Resources.Uninstall32Bit, true);
                RegistryKey RegistrySoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                RegistryKey UninstallInfo = RegUninstallKey64;
                if (ArchitectureCheck.ProcessorIs64Bit())
                {
                    UninstallInfo = RegUninstallKey64;
                }
                if (!ArchitectureCheck.ProcessorIs64Bit())
                {
                    UninstallInfo = RegUninstallKey32;
                }
                StartProcess.StartInfo(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe", "-unregister " + "\"" + GetAssembly.AssemblyInformation("directory") + "\\MenuTools.dll" + "\"", true, true, true);

                UninstallInfo.DeleteSubKeyTree("MenuTools", false);
                RegistrySoftware.DeleteSubKey("MenuTools\\Settings", false);
                RegistrySoftware.DeleteSubKey("MenuTools", false);

                // Restart Explorer
                DialogResult dialog = SendMessage.MessageForm(Resources.UninstallComplete, Resources.MenuTools, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    foreach (Process proc in Process.GetProcessesByName("explorer"))
                    {
                        proc.Kill();

                        proc.WaitForExit();
                    }
                }

                // Delete shortcut
                StringBuilder allUserProfile = new StringBuilder(260);
                NativeMethods.SHGetSpecialFolderPath(IntPtr.Zero, allUserProfile, NativeMethods.CSIDL_COMMON_STARTMENU, false);
                string programs_path = Path.Combine(allUserProfile.ToString(), "Programs");
                string shortcutFolder = Path.Combine(programs_path, @"MenuTools");
                foreach (string file in Directory.GetFiles(shortcutFolder))
                {
                    File.Delete(file);
                }
                Directory.Delete(shortcutFolder, true);

                try
                {
                    File.Copy(GetAssembly.AssemblyInformation("directory") + @"\Deleter.exe", Path.GetTempPath() + "Deleter.exe", true);

                    using (Process p = new Process())
                    {
                        p.StartInfo.Arguments = "\"" + GetAssembly.AssemblyInformation("directory") + "\"";
                        p.StartInfo.FileName = Path.GetTempPath() + @"\Deleter.exe";
                        p.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageForm(ex.Message + "\n\nNot all files could be removed. You will need to remove those files manually.", "MenuTools", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageForm(ex.Message + Environment.NewLine + ex.StackTrace, Resources.MenuTools, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Environment.Exit(0);
            }
        }

        internal static void InstallerElevated()
        {
            try
            {
                RegistryKey InstallInfo = null;
                RegistryKey RegUninstallKey64 = Registry.LocalMachine.OpenSubKey(Resources.RegUninstallKey64String, true);
                RegistryKey RegUninstallKey32 = Registry.LocalMachine.OpenSubKey(Resources.RegUninstallKey32String, true);
                if (ArchitectureCheck.ProcessorIs64Bit())
                {
                    InstallInfo = RegUninstallKey64;
                }
                else
                {
                    InstallInfo = RegUninstallKey32;
                }
                if (InstallInfo == null)
                {
                    Installation.Install(GetAssembly.AssemblyInformation("directory"));
                }
                else
                {
                    DialogResult results = MessageForm(Resources.UninstallQuestion + Resources.MenuTools + Resources.UninstallNotice, Resources.MenuTools, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (results == DialogResult.Yes)
                    {
                        Installation.Uninstall();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageForm(ex.Message + Environment.NewLine + ex.StackTrace, Resources.MenuTools, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        internal static void InstallerUnelevated()
        {
            try
            {
                RegistryKey subKey = null;
                if (ArchitectureCheck.ProcessorIs64Bit())
                {
                    subKey = Registry.LocalMachine.OpenSubKey(Resources.RegUninstallKey64String);
                }
                else
                {
                    subKey = Registry.LocalMachine.OpenSubKey(Resources.RegUninstallKey32String);
                }
                if (subKey == null)
                {
                    DialogResult results = MessageForm(Resources.InstallQuestion + Resources.MenuTools + Resources.InstallNotice, Resources.MenuTools, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (results == DialogResult.Yes)
                    {
                        StartProcess.StartInfo(GetAssembly.AssemblyInformation("filelocation"), "-install", false, true);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    DialogResult results = MessageForm(Resources.UninstallQuestion + Resources.MenuTools + Resources.UninstallNotice, Resources.MenuTools, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (results == DialogResult.Yes)
                    {
                        StartProcess.StartInfo(GetAssembly.AssemblyInformation("filelocation"), "-uninstall", false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageForm(ex.Message + Environment.NewLine + ex.StackTrace, Resources.MenuTools, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Environment.Exit(0);
            }
        }
    }
}
