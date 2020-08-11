using MenuTools.Methods;
using MenuTools.Properties;
using Microsoft.Win32;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MenuTools
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Directory)]
    [DisplayName("MenuTools")]
    public class MenuToolsDirectory : SharpContextMenu
    {
        private static readonly RegistryKey ExplorerAdvanced = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;
        private ContextMenuStrip Menu;
        private ToolStripMenuItem MenuToolsMenu, BlockFirewall, CopyPath, CopyName, Attributes, SymLink, TakeOwnership;
        private ToolStripMenuItem AttributesMenu, HiddenAttributes, SystemAttributes, ReadOnlyAttributes, ShowHidden, HideHidden, ShowSystem, HideSystem;

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
                Menu.Name = "MenuToolsDirectory";

                using (MenuToolsMenu = new ToolStripMenuItem())
                {
                    MenuToolsMenu.Name = "MenuToolsMenu";

                    // BlockFirewall
                    using (BlockFirewall = new ToolStripMenuItem())
                    {
                        BlockFirewall.Text = Resources.BlockAllText;
                        BlockFirewall.Name = "BlockFirewall";
                    }
                    // CopyPath
                    using (CopyPath = new ToolStripMenuItem())
                    {
                        CopyPath.Text = Resources.CopyPathText;
                        CopyPath.Name = "CopyPath";
                    }
                    // CopyName
                    using (CopyName = new ToolStripMenuItem())
                    {
                        CopyName.Text = Resources.CopyNameText;
                        CopyName.Name = "CopyName";
                    }
                    // Attributes
                    using (Attributes = new ToolStripMenuItem())
                    {
                        Attributes.Text = Resources.AttributesText;
                        Attributes.Name = "Attributes";

                        // AttributesMenu
                        using (AttributesMenu = new ToolStripMenuItem())
                        {
                            AttributesMenu.Text = Resources.AttributesMenu;
                            AttributesMenu.Name = "AttributesMenu";
                        }
                        // Get : Set Attributes
                        string[] SelectedPath = SelectedItemPaths.Cast<string>().ToArray();
                        if (SelectedPath.Length > 1)
                        {
                            foreach (string item in SelectedPath)
                            {
                                try
                                {
                                    AttributesInfo.GetFileAttributes(item);
                                }
                                catch (Exception ex)
                                {
                                    StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "\"" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite + "\"" + " -catchhandler");
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                AttributesInfo.GetFileAttributes(SelectedPath.ToStringArray(false));
                            }
                            catch (Exception ex)
                            {
                                StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "\"" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite + "\"" + " -catchhandler");
                            }
                        }
                        SetFileAttributes();
                    }
                    // SymLink
                    using (SymLink = new ToolStripMenuItem())
                    {
                        SymLink.Text = Resources.CreateSymbolicLink;
                        SymLink.Name = "SymLink";
                    }
                    // TakeOwnership
                    using (TakeOwnership = new ToolStripMenuItem())
                    {
                        TakeOwnership.Text = Resources.TakeOwnershipText;
                        TakeOwnership.Name = "TakeOwnership";
                    }
                }
            }
            MenuDeveloper();

            return Menu;
        }
        private static void CheckUserSettings()
        {
            RegistryKey MenuToolsSettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MenuTools\\Settings");
            if (MenuToolsSettings == null)
            {
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
            }
        }
        private void MenuDeveloper()
        {
            // Main Menu
            Menu.Items.Add(MenuToolsMenu);
            MenuToolsMenu.Text = Resources.MenuToolsName;

            // Icons
            MenuToolsMenu.Image = Resources.MAIN_ICON.ToBitmap();
            BlockFirewall.Image = Resources.Firewall.ToBitmap();
            CopyPath.Image = Resources.CopyPath.ToBitmap();
            CopyName.Image = Resources.CopyName.ToBitmap();
            Attributes.Image = Resources.FileAttributes.ToBitmap();
            AttributesMenu.Image = Resources.MAIN_ICON.ToBitmap();
            SymLink.Image = Resources.SymLink.ToBitmap();
            TakeOwnership.Image = Resources.TakeOwnership.ToBitmap();

            AddMenuItems();

            // Subscriptions
            BlockFirewall.Click += (sender, args) => BlockFirewallMethod();
            CopyPath.Click += (sender, args) => CopyPathMethod();
            CopyName.Click += (sender, args) => CopyNameMethod();
            AttributesMenu.Click += (sender, args) => AttributesMenuMethod();
            HiddenAttributes.Click += (sender, args) => HiddenAttributesMethod();
            SystemAttributes.Click += (sender, args) => SystemAttributesMethod();
            ReadOnlyAttributes.Click += (sender, args) => ReadOnlyAttributesMethod();
            ShowHidden.Click += (sender, args) => ShowHiddenMethod();
            HideHidden.Click += (sender, args) => HideHiddenMethod();
            ShowSystem.Click += (sender, args) => ShowSystemMethod();
            HideSystem.Click += (sender, args) => HideSystemMethod();
            SymLink.Click += (sender, args) => SymLinkMethod();
            TakeOwnership.Click += (sender, args) => TakeOwnershipMethod();
        }
        // Add Menu Items
        private void AddMenuItems()
        {
            RegistryKey MenuToolsSettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MenuTools\\Settings");
            object BlockWithFirewallDirectory = MenuToolsSettings.GetValue("BlockWithFirewallDirectory");
            if (BlockWithFirewallDirectory != null)
            {
                if (BlockWithFirewallDirectory.ToString() == "1")
                {
                    MenuToolsMenu.DropDownItems.Add(BlockFirewall);
                }
            }
            object CopyPathDirectory = MenuToolsSettings.GetValue("CopyPathDirectory");
            if (CopyPathDirectory != null)
            {
                if (CopyPathDirectory.ToString() == "1")
                {
                    MenuToolsMenu.DropDownItems.Add(CopyPath);
                }
            }
            object CopyNameDirectory = MenuToolsSettings.GetValue("CopyNameDirectory");
            if (CopyNameDirectory != null)
            {
                if (CopyNameDirectory.ToString() == "1")
                {
                    MenuToolsMenu.DropDownItems.Add(CopyName);
                }
            }
            object AttributesDirectory = MenuToolsSettings.GetValue("AttributesDirectory");
            if (AttributesDirectory != null)
            {
                if (AttributesDirectory.ToString() == "1")
                {
                    MenuToolsMenu.DropDownItems.Add(Attributes);
                    Attributes.DropDownItems.Add(AttributesMenu);
                    Attributes.DropDownItems.Add(new ToolStripSeparator());
                    Attributes.DropDownItems.Add(HiddenAttributes);
                    Attributes.DropDownItems.Add(SystemAttributes);
                    Attributes.DropDownItems.Add(ReadOnlyAttributes);
                    Attributes.DropDownItems.Add(new ToolStripSeparator());
                    Attributes.DropDownItems.Add(ShowHidden);
                    Attributes.DropDownItems.Add(HideHidden);
                    Attributes.DropDownItems.Add(ShowSystem);
                    Attributes.DropDownItems.Add(HideSystem);
                }
            }
            object SymlinkDirectory = MenuToolsSettings.GetValue("SymlinkDirectory");
            if (SymlinkDirectory != null)
            {
                if (SymlinkDirectory.ToString() == "1")
                {
                    MenuToolsMenu.DropDownItems.Add(SymLink);
                }
            }
            object TakeOwnershipDirectory = MenuToolsSettings.GetValue("TakeOwnershipDirectory");
            if (TakeOwnershipDirectory != null)
            {
                if (TakeOwnershipDirectory.ToString() == "1")
                {
                    MenuToolsMenu.DropDownItems.Add(TakeOwnership);
                }
            }
            bool AllDisabled = true;
            foreach (ToolStripMenuItem item in MenuToolsMenu.DropDownItems)
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
        // Set File Attributes
        private void SetFileAttributes()
        {
            using (HiddenAttributes = new ToolStripMenuItem())
            {
                HiddenAttributes.Text = Resources.HiddenAttributes;
                HiddenAttributes.Name = "HiddenAttributes";
            }
            if (AttributesInfo.hidden)
            {
                HiddenAttributes.Image = Resources.AttributesShow.ToBitmap();
            }
            // SystemAttributes
            using (SystemAttributes = new ToolStripMenuItem())
            {
                SystemAttributes.Text = Resources.SystemAttributes;
                SystemAttributes.Name = "SystemAttributes";
            }
            if (AttributesInfo.system)
            {
                SystemAttributes.Image = Resources.AttributesShow.ToBitmap();
            }
            // ReadOnlyAttributes
            using (ReadOnlyAttributes = new ToolStripMenuItem())
            {
                ReadOnlyAttributes.Text = Resources.ReadOnlyAttributes;
                ReadOnlyAttributes.Name = "ReadOnlyAttributes";
            }
            if (AttributesInfo.readOnly)
            {
                ReadOnlyAttributes.Image = Resources.AttributesShow.ToBitmap();
            }
            SetInternalAttributes();
        }
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
        private void BlockFirewallMethod()
        {
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "\"" + array.ToStringArray(false) + "\" " + "-firewallfolder", false, true);
        }
        private void CopyPathMethod()
        {
            Clipboard.Clear();
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            Clipboard.SetText(array.ToStringArray(false));
        }
        private void CopyNameMethod()
        {
            Clipboard.Clear();
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            Clipboard.SetText(array.ToStringArray(true));
        }
        private void AttributesMenuMethod()
        {
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "\"" + array.ToStringArray(false) + "\" " + "-attributesmenu");
        }
        private void SystemAttributesMethod()
        {
            foreach (string file in SelectedItemPaths)
            {
                FileAttributes attributes = File.GetAttributes(file);
                if ((attributes & FileAttributes.System) == FileAttributes.System)
                {
                    attributes = AttributesInfo.RemoveAttribute(attributes, FileAttributes.System);
                    File.SetAttributes(file, attributes);
                }
                else
                {
                    File.SetAttributes(file, File.GetAttributes(file) | FileAttributes.System);
                }
            }
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "-refresh");
        }
        private void ReadOnlyAttributesMethod()
        {
            foreach (string file in SelectedItemPaths)
            {
                string[] array = file.Cast<string>().ToArray();
                FileAttributes attributes = File.GetAttributes(file);
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    attributes = AttributesInfo.RemoveAttribute(attributes, FileAttributes.ReadOnly);
                    File.SetAttributes(file, attributes);
                }
                else
                {
                    File.SetAttributes(file, File.GetAttributes(file) | FileAttributes.ReadOnly);
                }
            }
        }
        private void ShowHiddenMethod()
        {
            ExplorerAdvanced.SetValue("Hidden", 1.ToString(culture), RegistryValueKind.DWord);
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "-refresh");
        }
        private void HideHiddenMethod()
        {
            ExplorerAdvanced.SetValue("Hidden", 2.ToString(culture), RegistryValueKind.DWord);
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "-refresh");
        }
        private void ShowSystemMethod()
        {
            ExplorerAdvanced.SetValue("ShowSuperHidden", 1.ToString(culture), RegistryValueKind.DWord);
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "-refresh");
        }
        private void HideSystemMethod()
        {
            ExplorerAdvanced.SetValue("ShowSuperHidden", 2.ToString(culture), RegistryValueKind.DWord);
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "-refresh");
        }
        private void HiddenAttributesMethod()
        {
            foreach (string file in SelectedItemPaths)
            {
                FileAttributes attributes = File.GetAttributes(file);
                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    attributes = AttributesInfo.RemoveAttribute(attributes, FileAttributes.Hidden);
                    File.SetAttributes(file, attributes);
                }
                else
                {
                    File.SetAttributes(file, File.GetAttributes(file) | FileAttributes.Hidden);
                }
            }
        }
        private void SymLinkMethod()
        {
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "\"" + array.ToStringArray(false) + "\" " + "-makelink", false, true);
        }
        private void TakeOwnershipMethod()
        {
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\MenuTools.exe", "\"" + array.ToStringArray(false) + "\" " + "-ownership", false, true);
        }
    }
}
