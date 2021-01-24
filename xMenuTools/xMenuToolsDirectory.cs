using Microsoft.Win32;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using xMenuTools.Methods;
using xMenuTools.Properties;

namespace xMenuTools
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Directory)]
    [DisplayName("xMenuTools")]
#pragma warning disable IDE1006 // Naming Styles
    public class xMenuToolsDirectory : SharpContextMenu
#pragma warning restore IDE1006 // Naming Styles
    {
        private static readonly RegistryKey ExplorerAdvanced = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;
        private ContextMenuStrip Menu;
        private ToolStripMenuItem xMenuToolsMenu, BlockFirewall, CopyName, CopyPath, CopyPathURL, CopyLONGPath, Attributes, SymLink, TakeOwnership;
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
                Menu.Name = "xMenuToolsDirectory";

                using (xMenuToolsMenu = new ToolStripMenuItem())
                {
                    xMenuToolsMenu.Name = "xMenuToolsMenu";

                    // BlockFirewall
                    using (BlockFirewall = new ToolStripMenuItem())
                    {
                        BlockFirewall.Text = Resources.BlockAllText;
                        BlockFirewall.Name = "BlockFirewall";
                    }
                    // CopyName
                    using (CopyName = new ToolStripMenuItem())
                    {
                        CopyName.Text = Resources.CopyNameText;
                        CopyName.Name = "CopyName";
                    }
                    // CopyPath
                    using (CopyPath = new ToolStripMenuItem())
                    {
                        CopyPath.Text = Resources.CopyPathText;
                        CopyPath.Name = "CopyPath";
                    }
                    // CopyPathURL
                    using (CopyPathURL = new ToolStripMenuItem())
                    {
                        CopyPathURL.Text = Resources.CopyPathURLText;
                        CopyPathURL.Name = "CopyPathURL";
                    }
                    // CopyLONGPath
                    using (CopyLONGPath = new ToolStripMenuItem())
                    {
                        CopyLONGPath.Text = Resources.CopyLONGPathText;
                        CopyLONGPath.Name = "CopyLONGPath";
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
                                    StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "\"" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite + "\"" + " -catchhandler");
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
                                StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "\"" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite + "\"" + " -catchhandler");
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
            RegistryKey xMenuToolsSettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\xMenuTools\\Settings");
            if (xMenuToolsSettings == null)
            {
                SetRegistryItems.SetItems();
            }
        }
        private void MenuDeveloper()
        {
            // Main Menu
            Menu.Items.Add(xMenuToolsMenu);
            xMenuToolsMenu.Text = Resources.xMenuToolsName;

            // Icons
            xMenuToolsMenu.Image = Resources.MAIN_ICON.ToBitmap();
            BlockFirewall.Image = Resources.Firewall.ToBitmap();
            CopyName.Image = Resources.CopyName.ToBitmap();
            CopyPath.Image = Resources.CopyPath.ToBitmap();
            CopyPathURL.Image = Resources.CopyPath.ToBitmap();
            CopyLONGPath.Image = Resources.CopyPath.ToBitmap();
            Attributes.Image = Resources.FileAttributes.ToBitmap();
            AttributesMenu.Image = Resources.MAIN_ICON.ToBitmap();
            SymLink.Image = Resources.SymLink.ToBitmap();
            TakeOwnership.Image = Resources.TakeOwnership.ToBitmap();

            AddMenuItems();

            // Subscriptions
            BlockFirewall.Click += (sender, args) => BlockFirewallMethod();
            CopyName.Click += (sender, args) => CopyNameMethod();
            CopyPath.Click += (sender, args) => CopyPathMethod();
            CopyPathURL.Click += (sender, args) => CopyPathURLMethod();
            CopyLONGPath.Click += (sender, args) => CopyLONGPathMethod();
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
            RegistryKey xMenuToolsSettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\xMenuTools\\Settings");
            object BlockWithFirewallDirectory = xMenuToolsSettings.GetValue("BlockWithFirewallDirectory");
            if (BlockWithFirewallDirectory != null)
            {
                if (BlockWithFirewallDirectory.ToString() == "1")
                {
                    xMenuToolsMenu.DropDownItems.Add(BlockFirewall);
                }
            }
            object CopyNameDirectory = xMenuToolsSettings.GetValue("CopyNameDirectory");
            if (CopyNameDirectory != null)
            {
                if (CopyNameDirectory.ToString() == "1")
                {
                    xMenuToolsMenu.DropDownItems.Add(CopyName);
                }
            }
            object CopyPathDirectory = xMenuToolsSettings.GetValue("CopyPathDirectory");
            if (CopyPathDirectory != null)
            {
                if (CopyPathDirectory.ToString() == "1")
                {
                    xMenuToolsMenu.DropDownItems.Add(CopyPath);
                }
            }
            object CopyURLDirectory = xMenuToolsSettings.GetValue("CopyURLDirectory");
            if (CopyURLDirectory != null)
            {
                if (CopyURLDirectory.ToString() == "1")
                {
                    xMenuToolsMenu.DropDownItems.Add(CopyPathURL);
                }
            }
            object CopyLONGPathDirectory = xMenuToolsSettings.GetValue("CopyLONGPathDirectory");
            if (CopyLONGPathDirectory != null)
            {
                if (CopyLONGPathDirectory.ToString() == "1")
                {
                    xMenuToolsMenu.DropDownItems.Add(CopyLONGPath);
                }
            }
            object AttributesDirectory = xMenuToolsSettings.GetValue("AttributesDirectory");
            if (AttributesDirectory != null)
            {
                if (AttributesDirectory.ToString() == "1")
                {
                    xMenuToolsMenu.DropDownItems.Add(Attributes);
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
            object SymlinkDirectory = xMenuToolsSettings.GetValue("SymlinkDirectory");
            if (SymlinkDirectory != null)
            {
                if (SymlinkDirectory.ToString() == "1")
                {
                    xMenuToolsMenu.DropDownItems.Add(SymLink);
                }
            }
            object TakeOwnershipDirectory = xMenuToolsSettings.GetValue("TakeOwnershipDirectory");
            if (TakeOwnershipDirectory != null)
            {
                if (TakeOwnershipDirectory.ToString() == "1")
                {
                    xMenuToolsMenu.DropDownItems.Add(TakeOwnership);
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
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "\"" + array.ToStringArray(false) + "\" " + "-firewallfolder", false, true);
        }
        private void CopyNameMethod()
        {
            Clipboard.Clear();
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            Clipboard.SetText(array.ToStringArray(true));
        }
        private void CopyPathMethod()
        {
            Clipboard.Clear();
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            Clipboard.SetText(array.ToStringArray(false));
        }
        private void CopyPathURLMethod()
        {
            Clipboard.Clear();
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            try
            {
                Clipboard.SetText(new Uri(array.ToStringArray(false)).AbsoluteUri);
            }
            catch (Exception ex)
            {
                EasyLogger.Error(ex);
            }
        }
        private void CopyLONGPathMethod()
        {
            Clipboard.Clear();
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            Clipboard.SetText(@"\\?\" + array.ToStringArray(false));
        }
        private void AttributesMenuMethod()
        {
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "\"" + array.ToStringArray(false) + "\" " + "-attributesmenu");
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
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "-refresh");
        }
        private void ReadOnlyAttributesMethod()
        {
            foreach (string file in SelectedItemPaths)
            {
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
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "\"" + array.ToStringArray(false) + "\" " + "-makelink", false, true);
        }
        private void TakeOwnershipMethod()
        {
            string[] array = SelectedItemPaths.Cast<string>().ToArray();
            StartProcess.StartInfo(AttributesInfo.GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "\"" + array.ToStringArray(false) + "\" " + "-ownership", false, true);
        }
    }
}
