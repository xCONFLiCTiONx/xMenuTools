using Microsoft.Win32;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using xMenuTools.Methods;
using xMenuTools.Properties;

namespace xMenuTools
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Class, @"Directory\Background")]
    [DisplayName("xMenuTools")]
#pragma warning disable IDE1006 // Naming Styles
    public class xMenuToolsDirectoryBack : SharpContextMenu
#pragma warning restore IDE1006 // Naming Styles
    {
        private static readonly RegistryKey ExplorerAdvanced = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;
        private ContextMenuStrip Menu;
        private ToolStripMenuItem xMenuToolsMenu, CommandLine, Attributes, FindWallpaper, SystemFolders, PasteContents;
        private ToolStripMenuItem OpenTerminalAsAdmin, OpenTerminalAsUser, OpenCmdAsAdmin, OpenCmdAsUser, OpenGitAsUser, OpenGitAsAdmin, OpenPSAsUser, OpenPSAsAdmin;
        private ToolStripMenuItem AttributesMenu, ShowHidden, HideHidden, ShowSystem, HideSystem;
        private ToolStripMenuItem AppDataFolder, ProgramDataFolder, UserStartMenuFolder, AllUsersStartMenuFolder, UserTempFolder;

        [STAThread]
        protected override bool CanShowMenu()
        {
            return true;
        }

        // Create the Menu
        protected override ContextMenuStrip CreateMenu()
        {
            CheckUserSettings();

            // Main Menu
            using (Menu = new ContextMenuStrip())
            {
                Menu.Name = "xMenuToolsMenu";

                using (xMenuToolsMenu = new ToolStripMenuItem())
                {
                    xMenuToolsMenu.Name = "xMenuToolsMenu";

                    // CommandLine
                    using (CommandLine = new ToolStripMenuItem())
                    {
                        CommandLine.Text = Resources.CommandLines;
                        CommandLine.Name = "CommandLine";

                        // OpenTerminalAsUser
                        using (OpenTerminalAsUser = new ToolStripMenuItem())
                        {
                            OpenTerminalAsUser.Text = Resources.OpenTerminal;
                            OpenTerminalAsUser.Name = "OpenTerminalAsUser";
                        }
                        // OpenTerminalAsAdmin
                        using (OpenTerminalAsAdmin = new ToolStripMenuItem())
                        {
                            OpenTerminalAsAdmin.Text = Resources.OpenTerminalElevated;
                            OpenTerminalAsAdmin.Name = "OpenTerminalAsAdmin";
                        }

                        // OpenCmdAsUser
                        using (OpenCmdAsUser = new ToolStripMenuItem())
                        {
                            OpenCmdAsUser.Text = Resources.CommandPrompt;
                            OpenCmdAsUser.Name = "OpenCmdAsUser";
                        }
                        // OpenCmdAsAdmin
                        using (OpenCmdAsAdmin = new ToolStripMenuItem())
                        {
                            OpenCmdAsAdmin.Text = Resources.CommandPromptElevated;
                            OpenCmdAsAdmin.Name = "OpenCmdAsAdmin";
                        }

                        // OpenGitAsUser
                        using (OpenGitAsUser = new ToolStripMenuItem())
                        {
                            OpenGitAsUser.Text = Resources.OpenGitAsUser;
                            OpenGitAsUser.Name = "OpenGitAsUser";
                        }
                        // OpenGitAsAdmin
                        using (OpenGitAsAdmin = new ToolStripMenuItem())
                        {
                            OpenGitAsAdmin.Text = Resources.OpenGitAsAdmin;
                            OpenGitAsAdmin.Name = "OpenGitAsAdmin";
                        }

                        // OpenPSAsUser
                        using (OpenPSAsUser = new ToolStripMenuItem())
                        {
                            OpenPSAsUser.Text = Resources.OpenPSAsUser;
                            OpenPSAsUser.Name = "OpenPSAsUser";
                        }
                        // OpenPSAsAdmin
                        using (OpenPSAsAdmin = new ToolStripMenuItem())
                        {
                            OpenPSAsAdmin.Text = Resources.OpenPSAsAdmin;
                            OpenPSAsAdmin.Name = "OpenPSAsAdmin";
                        }
                    }
                    // Attributes
                    using (Attributes = new ToolStripMenuItem())
                    {
                        Attributes.Text = Resources.AttributesText;
                        Attributes.Name = "Attributes";

                        using (AttributesMenu = new ToolStripMenuItem())
                        {
                            AttributesMenu.Text = Resources.AttributesMenu;
                            AttributesMenu.Name = "AttributesMenu";
                        }
                        try
                        {
                            AttributesInfo.GetFileAttributes(FolderPath);
                        }
                        catch (Exception ex)
                        {
                            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "\"" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite + "\"" + " -catchhandler");
                        }
                        SetInternalAttributes();
                    }
                    // System Folders
                    using (SystemFolders = new ToolStripMenuItem())
                    {
                        SystemFolders.Text = "System Folders";
                        SystemFolders.Name = "SystemFolders";

                        using (AppDataFolder = new ToolStripMenuItem())
                        {
                            AppDataFolder.Text = "AppData Folder";
                            AppDataFolder.Name = "AppDataFolder";
                        }
                        using (ProgramDataFolder = new ToolStripMenuItem())
                        {
                            ProgramDataFolder.Text = "ProgramData Folder";
                            ProgramDataFolder.Name = "ProgramDataFolder";
                        }
                        using (UserStartMenuFolder = new ToolStripMenuItem())
                        {
                            UserStartMenuFolder.Text = "Start Menu Folder";
                            UserStartMenuFolder.Name = "UserStartMenuFolder";
                        }
                        using (AllUsersStartMenuFolder = new ToolStripMenuItem())
                        {
                            AllUsersStartMenuFolder.Text = "All Users Start Menu Folder";
                            AllUsersStartMenuFolder.Name = "AllUsersStartMenuFolder";
                        }
                        using (UserTempFolder = new ToolStripMenuItem())
                        {
                            UserTempFolder.Text = "Temp Folder";
                            UserTempFolder.Name = "UserTempFolder";
                        }
                    }
                    // FindWallpaper
                    using (FindWallpaper = new ToolStripMenuItem())
                    {
                        FindWallpaper.Text = Resources.FindWallpaperText;
                        FindWallpaper.Name = "FindWallpaper";
                    }
                    // Paste Contents
                    using (PasteContents = new ToolStripMenuItem())
                    {
                        PasteContents.Text = "Paste clipboard text to file";
                        PasteContents.Name = "PasteContents";
                    }
                }
            }
            MenuDeveloper();

            return Menu;
        }

        [STAThread]
        private static void CheckUserSettings()
        {
            RegistryKey xMenuToolsSettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\xMenuTools\\Settings");
            if (xMenuToolsSettings == null)
            {
                // All Files
                xMenuToolsSettings.SetValue("OpenNotepadFiles", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("BlockWithFirewallFiles", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("CopyPathFiles", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("CopyNameFiles", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("AttributesFiles", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("SymlinkFiles", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("TakeOwnershipFiles", 0x00000001, RegistryValueKind.DWord);
                // All Files Shorcuts
                xMenuToolsSettings.SetValue("AttributesShortcuts", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("OpenNotepadShort", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("CopyPathShortFiles", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("CopyNameShortFiles", 0x00000001, RegistryValueKind.DWord);
                // Directories
                xMenuToolsSettings.SetValue("BlockWithFirewallDirectory", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("CopyPathDirectory", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("CopyNameDirectory", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("AttributesDirectory", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("SymlinkDirectory", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("TakeOwnershipDirectory", 0x00000001, RegistryValueKind.DWord);
                // Directory Background
                xMenuToolsSettings.SetValue("AttributesDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("CommandLinesDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("FindWallpaperDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("SystemFoldersDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                xMenuToolsSettings.SetValue("PasteContentsDirectoryBack", 0x00000001, RegistryValueKind.DWord);
            }
        }

        [STAThread]
        private void MenuDeveloper()
        {
            // Main Menu
            Menu.Items.Add(xMenuToolsMenu);
            xMenuToolsMenu.Text = Resources.xMenuToolsName;

            // Icons
            xMenuToolsMenu.Image = Resources.MAIN_ICON.ToBitmap();
            CommandLine.Image = Resources.cmd.ToBitmap();
            OpenTerminalAsUser.Image = Resources.terminal.ToBitmap();
            OpenCmdAsUser.Image = Resources.cmd.ToBitmap();
            OpenGitAsUser.Image = Resources.GitCmd.ToBitmap();
            OpenPSAsUser.Image = Resources.PS.ToBitmap();
            Attributes.Image = Resources.FileAttributes.ToBitmap();
            AttributesMenu.Image = Resources.MAIN_ICON.ToBitmap();
            SystemFolders.Image = Resources.SystemIcon.ToBitmap();
            FindWallpaper.Image = Resources.FindWallpaper.ToBitmap();
            AppDataFolder.Image = Resources.FolderIcon.ToBitmap();
            ProgramDataFolder.Image = Resources.FolderIcon.ToBitmap();
            UserStartMenuFolder.Image = Resources.FolderIcon.ToBitmap();
            AllUsersStartMenuFolder.Image = Resources.FolderIcon.ToBitmap();
            UserTempFolder.Image = Resources.FolderIcon.ToBitmap();
            PasteContents.Image = Resources.CopyName.ToBitmap();

            AddMenuItems();

            // Subscriptions
            OpenTerminalAsUser.Click += (sender, args) => OpenTerminalAsUserMethod();
            OpenTerminalAsAdmin.Click += (sender, args) => OpenTerminalAsAdminMethod();
            OpenCmdAsUser.Click += (sender, args) => OpenCmdAsUserMethod();
            OpenCmdAsAdmin.Click += (sender, args) => OpenCmdAsAdminMethod();
            OpenGitAsUser.Click += (sender, args) => OpenGitAsUserMethod();
            OpenGitAsAdmin.Click += (sender, args) => OpenGitAsAdminMethod();
            OpenPSAsUser.Click += (sender, args) => OpenPSAsUserMethod();
            OpenPSAsAdmin.Click += (sender, args) => OpenPSAsAdminMethod();
            AttributesMenu.Click += (sender, args) => AttributesMenuMethod();
            ShowHidden.Click += (sender, args) => ShowHiddenMethod();
            HideHidden.Click += (sender, args) => HideHiddenMethod();
            ShowSystem.Click += (sender, args) => ShowSystemMethod();
            HideSystem.Click += (sender, args) => HideSystemMethod();
            FindWallpaper.Click += (sender, args) => FindWallpaperMethod();
            AppDataFolder.Click += (sender, args) => AppDataFolderMethod();
            ProgramDataFolder.Click += (sender, args) => ProgramDataFolderMethod();
            UserStartMenuFolder.Click += (sender, args) => UserStartMenuFolderMethod();
            AllUsersStartMenuFolder.Click += (sender, args) => AllUsersStartMenuFolderMethod();
            UserTempFolder.Click += (sender, args) => UserTempFolderMethod();

            if (!string.IsNullOrEmpty(Clipboard.GetText()))
            {
                PasteContents.Click += (sender, args) => PasteContentsMethod();
            }
            else
            {
                PasteContents.Dispose();
            }
        }

        [STAThread]
        // Add Menu Items
        private void AddMenuItems()
        {
            try
            {
                RegistryKey xMenuToolsSettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\xMenuTools\\Settings");
                if (xMenuToolsSettings != null)
                {
                    object AttributesDirectoryBack = xMenuToolsSettings.GetValue("AttributesDirectoryBack");
                    if (AttributesDirectoryBack != null)
                    {
                        if (AttributesDirectoryBack.ToString() == "1")
                        {
                            xMenuToolsMenu.DropDownItems.Add(Attributes);
                            Attributes.DropDownItems.Add(AttributesMenu);
                            Attributes.DropDownItems.Add(new ToolStripSeparator());
                            Attributes.DropDownItems.Add(ShowHidden);
                            Attributes.DropDownItems.Add(HideHidden);
                            Attributes.DropDownItems.Add(ShowSystem);
                            Attributes.DropDownItems.Add(HideSystem);
                        }
                    }
                    object CommandLinesDirectoryBack = xMenuToolsSettings.GetValue("CommandLinesDirectoryBack");
                    if (CommandLinesDirectoryBack != null)
                    {
                        if (CommandLinesDirectoryBack.ToString() == "1")
                        {
                            xMenuToolsMenu.DropDownItems.Add(CommandLine);

                            string appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Microsoft\WindowsApps\Microsoft.WindowsTerminal_8wekyb3d8bbwe\wt.exe");

                            if (File.Exists(appPath))
                            {
                                CommandLine.DropDownItems.Add(OpenTerminalAsUser);
                                CommandLine.DropDownItems.Add(OpenTerminalAsAdmin);
                                CommandLine.DropDownItems.Add(new ToolStripSeparator());
                            }

                            CommandLine.DropDownItems.Add(OpenCmdAsUser);
                            CommandLine.DropDownItems.Add(OpenCmdAsAdmin);
                            CommandLine.DropDownItems.Add(new ToolStripSeparator());
                            string programFiles = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
                            string programFilesX86 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");
                            if (Directory.Exists(programFiles + @"\Git") || Directory.Exists(programFilesX86 + @"\Git"))
                            {
                                CommandLine.DropDownItems.Add(OpenGitAsUser);
                                CommandLine.DropDownItems.Add(OpenGitAsAdmin);
                                CommandLine.DropDownItems.Add(new ToolStripSeparator());
                            }
                            CommandLine.DropDownItems.Add(OpenPSAsUser);
                            CommandLine.DropDownItems.Add(OpenPSAsAdmin);
                        }
                    }
                    object SystemFoldersDirectoryBack = xMenuToolsSettings.GetValue("SystemFoldersDirectoryBack");
                    if (SystemFoldersDirectoryBack != null)
                    {
                        if (SystemFoldersDirectoryBack.ToString() == "1")
                        {
                            xMenuToolsMenu.DropDownItems.Add(SystemFolders);
                            SystemFolders.DropDownItems.Add(AppDataFolder);
                            SystemFolders.DropDownItems.Add(ProgramDataFolder);
                            SystemFolders.DropDownItems.Add(UserStartMenuFolder);
                            SystemFolders.DropDownItems.Add(AllUsersStartMenuFolder);
                            SystemFolders.DropDownItems.Add(UserTempFolder);
                        }
                    }
                    object PasteContentsDirectoryBack = xMenuToolsSettings.GetValue("PasteContentsDirectoryBack");
                    if (PasteContentsDirectoryBack != null)
                    {
                        if (PasteContentsDirectoryBack.ToString() == "1")
                        {
                            xMenuToolsMenu.DropDownItems.Add(PasteContents);
                        }
                    }
                    object FindWallpaperDirectoryBack = xMenuToolsSettings.GetValue("FindWallpaperDirectoryBack");
                    if (FindWallpaperDirectoryBack != null)
                    {
                        if (FindWallpaperDirectoryBack.ToString() == "1")
                        {
                            xMenuToolsMenu.DropDownItems.Add(FindWallpaper);
                        }
                    }
                    bool AllDisabled = true;
                    foreach (ToolStripMenuItem item in xMenuToolsMenu.DropDownItems)
                    {
                        if (item != null)
                        {
                            AllDisabled = false;
                        }
                    }
                    if (AllDisabled)
                    {
                        Menu.Dispose();
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "\"" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite + "\"" + " -catchhandler");
            }
        }

        [STAThread]
        private void SetInternalAttributes()
        {
            using (ShowHidden = new ToolStripMenuItem())
            {
                ShowHidden.Text = Resources.ShowHidden;
                ShowHidden.Name = "ShowHidden";
            }
            using (HideHidden = new ToolStripMenuItem())
            {
                HideHidden.Text = Resources.HideHidden;
                HideHidden.Name = "HideHidden";
            }
            if (AttributesInfo.HiddenFilesShowing)
            {
                ShowHidden.Image = Resources.AttributesShow.ToBitmap();
            }
            if (!AttributesInfo.HiddenFilesShowing)
            {
                HideHidden.Image = Resources.AttributesHide.ToBitmap();
            }
            using (ShowSystem = new ToolStripMenuItem())
            {
                ShowSystem.Text = Resources.ShowSystem;
                ShowSystem.Name = "ShowSystem";
            }
            using (HideSystem = new ToolStripMenuItem())
            {
                HideSystem.Text = Resources.HideSystem;
                HideSystem.Name = "HideSystem";
            }
            if (AttributesInfo.SystemFilesShowing)
            {
                ShowSystem.Image = Resources.AttributesShow.ToBitmap();
            }
            if (!AttributesInfo.SystemFilesShowing)
            {
                HideSystem.Image = Resources.AttributesHide.ToBitmap();
            }
        }
        // Methods
        private void OpenTerminalAsUserMethod()
        {
            string appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Microsoft\WindowsApps\Microsoft.WindowsTerminal_8wekyb3d8bbwe\wt.exe");

            if (FolderPath.Contains(" "))
            {
                StartProcess.StartInfo(appPath, "-d " + "\"" + FolderPath + "\"");
            }
            else
            {
                StartProcess.StartInfo(appPath, "-d " + FolderPath);
            }
        }
        private void OpenTerminalAsAdminMethod()
        {
            string appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Microsoft\WindowsApps\Microsoft.WindowsTerminal_8wekyb3d8bbwe\wt.exe");

            if (FolderPath.Contains(" "))
            {
                StartProcess.StartInfo(appPath, "-d " + "\"" + FolderPath + "\"", false, true);
            }
            else
            {
                StartProcess.StartInfo(appPath, "-d " + FolderPath, false, true);
            }
        }
        private void OpenCmdAsUserMethod()
        {
            StartProcess.StartInfo("cmd.exe", "/s /k pushd " + "\"" + FolderPath + "\"");
        }
        private void OpenCmdAsAdminMethod()
        {
            StartProcess.StartInfo("cmd.exe", "/s /k pushd " + "\"" + FolderPath + "\"", false, true);
        }
        private void OpenGitAsUserMethod()
        {
            if (FolderPath.Contains(" "))
            {
                StartProcess.StartInfo("C:\\Program Files\\Git\\git-cmd.exe", "--cd=" + "\"" + FolderPath + "\"");
            }
            else
            {
                StartProcess.StartInfo("C:\\Program Files\\Git\\git-cmd.exe", "--cd=" + FolderPath);
            }

        }
        private void OpenGitAsAdminMethod()
        {
            if (FolderPath.Contains(" "))
            {
                StartProcess.StartInfo("C:\\Program Files\\Git\\git-cmd.exe", "--cd=" + "\"" + FolderPath + "\"", false, true);
            }
            else
            {
                StartProcess.StartInfo("C:\\Program Files\\Git\\git-cmd.exe", "--cd=" + FolderPath, false, true);
            }
        }
        private void OpenPSAsUserMethod()
        {
            StartProcess.StartInfo("C:\\Windows\\system32\\WindowsPowerShell\\v1.0\\powershell.exe", "-NoExit -Command Set-Location -LiteralPath " + "\'" + FolderPath + "\'");
        }
        private void OpenPSAsAdminMethod()
        {

            StartProcess.StartInfo("C:\\Windows\\system32\\WindowsPowerShell\\v1.0\\powershell.exe", "-NoExit -Command Set-Location -LiteralPath " + "\'" + FolderPath + "\'", false, true);
        }
        private void AttributesMenuMethod()
        {
            DirectoryInfo DirectoryPath = new DirectoryInfo(FolderPath);
            if (DirectoryPath.Parent == null)
            {
                StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", DirectoryPath + " -attributesmenu");
            }
            else
            {
                StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "\"" + DirectoryPath + "\" " + "-attributesmenu");
            }
        }
        private void ShowHiddenMethod()
        {
            ExplorerAdvanced.SetValue("Hidden", 1.ToString(culture), RegistryValueKind.DWord);
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "-refresh");
        }
        private void HideHiddenMethod()
        {
            ExplorerAdvanced.SetValue("Hidden", 2.ToString(culture), RegistryValueKind.DWord);
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "-refresh");
        }
        private void ShowSystemMethod()
        {
            ExplorerAdvanced.SetValue("ShowSuperHidden", 1.ToString(culture), RegistryValueKind.DWord);
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "-refresh");
        }

        private void HideSystemMethod()
        {
            ExplorerAdvanced.SetValue("ShowSuperHidden", 2.ToString(culture), RegistryValueKind.DWord);
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "-refresh");
        }

        private void UserTempFolderMethod()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp");
        }

        private void AllUsersStartMenuFolderMethod()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu));
        }

        private void UserStartMenuFolderMethod()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
        }

        private void ProgramDataFolderMethod()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
        }

        private void AppDataFolderMethod()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData");
        }

        private static void FindWallpaperMethod()
        {
            DesktopWallpaper.GetWallpaper();
        }

        [STAThread]
        private void PasteContentsMethod()
        {
            if (!string.IsNullOrEmpty(Clipboard.GetText()))
            {
                File.AppendAllText(FolderPath + "\\ClipboardContents.txt", Clipboard.GetText());
            }
        }
    }
}
