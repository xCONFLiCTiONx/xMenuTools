using xMenuToolsProcessor.Properties;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using static xMenuToolsProcessor.SendMessage;

namespace xMenuToolsProcessor
{
    public partial class Settings : Form
    {
        private static RegistryKey key;
        private const string SoftwarexMenuTools = "SOFTWARE\\xMenuTools\\Settings";
        private bool AllFilesCheckBoxesChecked = true;
        private bool ShortcutsCheckBoxesChecked = true;
        private bool DirectoriesCheckBoxesChecked = true;
        private bool DirBackgroundCheckBoxesChecked = true;
        private object OpenNotepadFiles;
        private object BlockWithFirewallFiles;
        private object CopyPathFiles;
        private object CopyNameFiles;
        private object AttributesFiles;
        private object SymlinkFiles;
        private object TakeOwnershipFiles;
        private object AttributesShortcuts;
        private object OpenNotepadShort;
        private object SystemFoldersDirectoryBack;
        private object CopyPathShortFiles;
        private object CopyNameShortFiles;
        private object BlockWithFirewallDirectory;
        private object CopyPathDirectory;
        private object CopyNameDirectory;
        private object AttributesDirectory;
        private object SymlinkDirectory;
        private object TakeOwnershipDirectory;
        private object AttributesDirectoryBack;
        private object CommandLinesDirectoryBack;
        private object FindWallpaperDirectoryBack;
        private object PasteContentsDirectoryBack;

        public Settings()
        {
            InitializeComponent();
            key = Registry.CurrentUser.CreateSubKey(SoftwarexMenuTools);
            key = Registry.CurrentUser.OpenSubKey(SoftwarexMenuTools, true);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            label1.Text = Resources.Version + version;

            RegistryKey subKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\xMenuTools");
            if (subKey == null)
            {
                StartProcess.StartInfo(GetAssembly.AssemblyInformation("directory") + @"\xMenuTools.exe", "-install", false, true);
                Environment.Exit(0);
            }
            GetSettings();
        }
        private void GetSettings()
        {
            try
            {
                if (key != null)
                {
                    OpenNotepadFiles = key.GetValue("OpenNotepadFiles");
                    BlockWithFirewallFiles = key.GetValue("BlockWithFirewallFiles");
                    CopyPathFiles = key.GetValue("CopyPathFiles");
                    CopyNameFiles = key.GetValue("CopyNameFiles");
                    AttributesFiles = key.GetValue("AttributesFiles");
                    SymlinkFiles = key.GetValue("SymlinkFiles");
                    TakeOwnershipFiles = key.GetValue("TakeOwnershipFiles");
                    AttributesShortcuts = key.GetValue("AttributesShortcuts");
                    OpenNotepadShort = key.GetValue("OpenNotepadShort");
                    SystemFoldersDirectoryBack = key.GetValue("SystemFoldersDirectoryBack");
                    CopyPathShortFiles = key.GetValue("CopyPathShortFiles");
                    CopyNameShortFiles = key.GetValue("CopyNameShortFiles");
                    PasteContentsDirectoryBack = key.GetValue("PasteContentsDirectoryBack");

                    if (OpenNotepadFiles != null)
                    {
                        if (OpenNotepadFiles.ToString() == "1")
                        {
                            NotepadCheckBox.Checked = true;
                        }
                    }
                    if (BlockWithFirewallFiles != null)
                    {
                        if (BlockWithFirewallFiles.ToString() == "1")
                        {
                            BlockWithFirewallCheckBox.Checked = true;
                        }
                    }
                    if (CopyPathFiles != null)
                    {
                        if (CopyPathFiles.ToString() == "1")
                        {
                            CopyFilePathCheckBox.Checked = true;
                        }
                    }
                    if (CopyNameFiles != null)
                    {
                        if (CopyNameFiles.ToString() == "1")
                        {
                            CopyFileNameCheckBox.Checked = true;
                        }
                    }
                    if (AttributesFiles != null)
                    {
                        if (AttributesFiles.ToString() == "1")
                        {
                            FileAttributesCheckBox.Checked = true;
                        }
                    }
                    if (SymlinkFiles != null)
                    {
                        if (SymlinkFiles.ToString() == "1")
                        {
                            FileSymLinkCheckBox.Checked = true;
                        }
                    }
                    if (TakeOwnershipFiles != null)
                    {
                        if (TakeOwnershipFiles.ToString() == "1")
                        {
                            TakeOwnershipFileCheckBox.Checked = true;
                        }
                    }
                    if (AttributesShortcuts != null)
                    {
                        if (AttributesShortcuts.ToString() == "1")
                        {
                            AttributesShortcutsCheckbox.Checked = true;
                        }
                    }
                    if (OpenNotepadShort != null)
                    {
                        if (OpenNotepadShort.ToString() == "1")
                        {
                            ShortNotepadCheckbox.Checked = true;
                        }
                    }
                    if (CopyPathShortFiles != null)
                    {
                        if (CopyPathShortFiles.ToString() == "1")
                        {
                            CopyPathShorcutCheckbox.Checked = true;
                        }
                    }
                    if (CopyNameShortFiles != null)
                    {
                        if (CopyNameShortFiles.ToString() == "1")
                        {
                            CopyNameShortcutCheckbox.Checked = true;
                        }
                    }
                    GetSettingsFinal(key);
                }
                else
                {
                    // All Files
                    key.SetValue("OpenNotepadFiles", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("BlockWithFirewallFiles", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("CopyPathFiles", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("CopyNameFiles", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("AttributesFiles", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("SymlinkFiles", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("TakeOwnershipFiles", 0x00000001, RegistryValueKind.DWord);
                    // All Files Shorcuts
                    key.SetValue("AttributesShortcuts", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("OpenNotepadShort", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("CopyPathShortFiles", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("CopyNameShortFiles", 0x00000001, RegistryValueKind.DWord);
                    // Directories
                    key.SetValue("BlockWithFirewallDirectory", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("CopyPathDirectory", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("CopyNameDirectory", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("AttributesDirectory", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("SymlinkDirectory", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("TakeOwnershipDirectory", 0x00000001, RegistryValueKind.DWord);
                    // Directory Background
                    key.SetValue("AttributesDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("CommandLinesDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("FindWallpaperDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("SystemFoldersDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                    key.SetValue("PasteContentsDirectoryBack", 0x00000001, RegistryValueKind.DWord);
                }
            }
            catch (Win32Exception ex)
            {
                MessageForm(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.GetBaseException() + Environment.NewLine + ex.TargetSite, "xMenuTools", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetSettingsFinal(RegistryKey key)
        {
            BlockWithFirewallDirectory = key.GetValue("BlockWithFirewallDirectory");
            CopyPathDirectory = key.GetValue("CopyPathDirectory");
            CopyNameDirectory = key.GetValue("CopyNameDirectory");
            AttributesDirectory = key.GetValue("AttributesDirectory");
            SymlinkDirectory = key.GetValue("SymlinkDirectory");
            TakeOwnershipDirectory = key.GetValue("TakeOwnershipDirectory");
            AttributesDirectoryBack = key.GetValue("AttributesDirectoryBack");
            CommandLinesDirectoryBack = key.GetValue("CommandLinesDirectoryBack");
            FindWallpaperDirectoryBack = key.GetValue("FindWallpaperDirectoryBack");
            SystemFoldersDirectoryBack = key.GetValue("SystemFoldersDirectoryBack");
            PasteContentsDirectoryBack = key.GetValue("PasteContentsDirectoryBack");
            if (BlockWithFirewallDirectory != null)
            {
                if (BlockWithFirewallDirectory.ToString() == "1")
                {
                    BlockFirewallDirectoryCheckBox.Checked = true;
                }
            }
            if (CopyPathDirectory != null)
            {
                if (CopyPathDirectory.ToString() == "1")
                {
                    CopyPathDirectoryCheckbox.Checked = true;
                }
            }
            if (CopyNameDirectory != null)
            {
                if (CopyNameDirectory.ToString() == "1")
                {
                    CopyNameDirectoryCheckbox.Checked = true;
                }
            }
            if (AttributesDirectory != null)
            {
                if (AttributesDirectory.ToString() == "1")
                {
                    AttributesDirectoryCheckbox.Checked = true;
                }
            }
            if (SymlinkDirectory != null)
            {
                if (SymlinkDirectory.ToString() == "1")
                {
                    SymLinkDirectoryCheckbox.Checked = true;
                }
            }
            if (TakeOwnershipDirectory != null)
            {
                if (TakeOwnershipDirectory.ToString() == "1")
                {
                    TakeOwnershipDirectoryCheckbox.Checked = true;
                }
            }
            if (AttributesDirectoryBack != null)
            {
                if (AttributesDirectoryBack.ToString() == "1")
                {
                    DirBackAttributesCheckbox.Checked = true;
                }
            }
            if (CommandLinesDirectoryBack != null)
            {
                if (CommandLinesDirectoryBack.ToString() == "1")
                {
                    DirBackComLinesCheckbox.Checked = true;
                }
            }
            if (SystemFoldersDirectoryBack != null)
            {
                if (SystemFoldersDirectoryBack.ToString() == "1")
                {
                    SystemFoldersCheckbox.Checked = true;
                }
            }
            if (FindWallpaperDirectoryBack != null)
            {
                if (FindWallpaperDirectoryBack.ToString() == "1")
                {
                    DirBackWallpaperCheckbox.Checked = true;
                }
            }
            if (PasteContentsDirectoryBack != null)
            {
                if (PasteContentsDirectoryBack.ToString() == "1")
                {
                    PasteContentsCheckbox.Checked = true;
                }
            }
            CheckBoxCheck();
        }
        private void CheckBoxCheck()
        {
            foreach (CheckBox checkbox in tabPage1.Controls)
            {
                if (!checkbox.Checked && checkbox.Text != Resources.SelectAll)
                {
                    AllFilesCheckBoxesChecked = false;
                }
            }
            foreach (CheckBox checkbox in tabPage2.Controls)
            {
                if (!checkbox.Checked && checkbox.Text != Resources.SelectAll)
                {
                    ShortcutsCheckBoxesChecked = false;
                }
            }
            foreach (CheckBox checkbox in tabPage3.Controls)
            {
                if (!checkbox.Checked && checkbox.Text != Resources.SelectAll)
                {
                    DirectoriesCheckBoxesChecked = false;
                }
            }
            foreach (CheckBox checkbox in tabPage4.Controls)
            {
                if (!checkbox.Checked && checkbox.Text != Resources.SelectAll)
                {
                    DirBackgroundCheckBoxesChecked = false;
                }
            }
            if (AllFilesCheckBoxesChecked)
            {
                AllFilesSelectAllCheckbox.Checked = true;
            }
            if (ShortcutsCheckBoxesChecked)
            {
                ShorcutsSelectAllCheckbox.Checked = true;
            }
            if (DirectoriesCheckBoxesChecked)
            {
                DirSelectAllCheckbox.Checked = true;
            }
            if (DirBackgroundCheckBoxesChecked)
            {
                DirBackSelectAllCheckbox.Checked = true;
            }
        }
        // All Files
        private void NotepadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotepadCheckBox.Checked)
            {
                key.SetValue("OpenNotepadFiles", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("OpenNotepadFiles", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void BlockWithFirewallCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BlockWithFirewallCheckBox.Checked)
            {
                key.SetValue("BlockWithFirewallFiles", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("BlockWithFirewallFiles", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void CopyFilePathCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CopyFilePathCheckBox.Checked)
            {
                key.SetValue("CopyPathFiles", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("CopyPathFiles", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void CopyFileNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CopyFileNameCheckBox.Checked)
            {
                key.SetValue("CopyNameFiles", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("CopyNameFiles", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void FileAttributesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FileAttributesCheckBox.Checked)
            {
                key.SetValue("AttributesFiles", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("AttributesFiles", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void FileSymLinkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FileSymLinkCheckBox.Checked)
            {
                key.SetValue("SymlinkFiles", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("SymlinkFiles", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void TakeOwnershipFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TakeOwnershipFileCheckBox.Checked)
            {
                key.SetValue("TakeOwnershipFiles", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("TakeOwnershipFiles", 0x00000000, RegistryValueKind.DWord);
            }
        }
        // All Files Shortcuts
        private void AttributesShortcutsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AttributesShortcutsCheckbox.Checked)
            {
                key.SetValue("AttributesShortcuts", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("AttributesShortcuts", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void ShortNotepadCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShortNotepadCheckbox.Checked)
            {
                key.SetValue("OpenNotepadShort", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("OpenNotepadShort", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void CopyPathShorcutCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (CopyPathShorcutCheckbox.Checked)
            {
                key.SetValue("CopyPathShortFiles", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("CopyPathShortFiles", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void CopyNameShortcutCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (CopyNameShortcutCheckbox.Checked)
            {
                key.SetValue("CopyNameShortFiles", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("CopyNameShortFiles", 0x00000000, RegistryValueKind.DWord);
            }
        }
        // Directories
        private void BlockFirewallDirectoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BlockFirewallDirectoryCheckBox.Checked)
            {
                key.SetValue("BlockWithFirewallDirectory", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("BlockWithFirewallDirectory", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void CopyPathDirectoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (CopyPathDirectoryCheckbox.Checked)
            {
                key.SetValue("CopyPathDirectory", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("CopyPathDirectory", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void CopyNameDirectoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (CopyNameDirectoryCheckbox.Checked)
            {
                key.SetValue("CopyNameDirectory", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("CopyNameDirectory", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void AttributesDirectoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AttributesDirectoryCheckbox.Checked)
            {
                key.SetValue("AttributesDirectory", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("AttributesDirectory", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void SymLinkDirectoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SymLinkDirectoryCheckbox.Checked)
            {
                key.SetValue("SymlinkDirectory", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("SymlinkDirectory", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void TakeOwnershipDirectoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (TakeOwnershipDirectoryCheckbox.Checked)
            {
                key.SetValue("TakeOwnershipDirectory", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("TakeOwnershipDirectory", 0x00000000, RegistryValueKind.DWord);
            }
        }
        // Directory Background
        private void DirBackAttributesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DirBackAttributesCheckbox.Checked)
            {
                key.SetValue("AttributesDirectoryBack", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("AttributesDirectoryBack", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void DirBackComLinesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DirBackComLinesCheckbox.Checked)
            {
                key.SetValue("CommandLinesDirectoryBack", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("CommandLinesDirectoryBack", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void DirBackWallpaperCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DirBackWallpaperCheckbox.Checked)
            {
                key.SetValue("FindWallpaperDirectoryBack", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("FindWallpaperDirectoryBack", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void SystemFoldersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SystemFoldersCheckbox.Checked)
            {
                key.SetValue("SystemFoldersDirectoryBack", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("SystemFoldersDirectoryBack", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void PasteContentsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SystemFoldersCheckbox.Checked)
            {
                key.SetValue("PasteContentsDirectoryBack", 0x00000001, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("PasteContentsDirectoryBack", 0x00000000, RegistryValueKind.DWord);
            }
        }

        private void AllFilesSelectAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AllFilesSelectAllCheckbox.Checked)
            {
                AllFilesSelectAllCheckbox.Text = Resources.SelectNone;
                NotepadCheckBox.Checked = true;
                BlockWithFirewallCheckBox.Checked = true;
                CopyFileNameCheckBox.Checked = true;
                CopyFilePathCheckBox.Checked = true;
                FileAttributesCheckBox.Checked = true;
                FileSymLinkCheckBox.Checked = true;
                TakeOwnershipFileCheckBox.Checked = true;
            }
            else
            {
                AllFilesSelectAllCheckbox.Text = Resources.SelectAll;
                NotepadCheckBox.Checked = false;
                BlockWithFirewallCheckBox.Checked = false;
                CopyFileNameCheckBox.Checked = false;
                CopyFilePathCheckBox.Checked = false;
                FileAttributesCheckBox.Checked = false;
                FileSymLinkCheckBox.Checked = false;
                TakeOwnershipFileCheckBox.Checked = false;
            }
        }

        private void DirSelectAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DirSelectAllCheckbox.Checked)
            {
                DirSelectAllCheckbox.Text = Resources.SelectNone;
                AttributesDirectoryCheckbox.Checked = true;
                BlockFirewallDirectoryCheckBox.Checked = true;
                CopyNameDirectoryCheckbox.Checked = true;
                CopyPathDirectoryCheckbox.Checked = true;
                SymLinkDirectoryCheckbox.Checked = true;
                TakeOwnershipDirectoryCheckbox.Checked = true;
            }
            else
            {
                DirSelectAllCheckbox.Text = Resources.SelectAll;
                AttributesDirectoryCheckbox.Checked = false;
                BlockFirewallDirectoryCheckBox.Checked = false;
                CopyNameDirectoryCheckbox.Checked = false;
                CopyPathDirectoryCheckbox.Checked = false;
                SymLinkDirectoryCheckbox.Checked = false;
                TakeOwnershipDirectoryCheckbox.Checked = false;
            }
        }

        private void ShorcutsSelectAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShorcutsSelectAllCheckbox.Checked)
            {
                ShorcutsSelectAllCheckbox.Text = Resources.SelectNone;
                AttributesShortcutsCheckbox.Checked = true;
                ShortNotepadCheckbox.Checked = true;
                CopyPathShorcutCheckbox.Checked = true;
                CopyNameShortcutCheckbox.Checked = true;
            }
            else
            {
                ShorcutsSelectAllCheckbox.Text = Resources.SelectAll;
                AttributesShortcutsCheckbox.Checked = false;
                ShortNotepadCheckbox.Checked = false;
                CopyPathShorcutCheckbox.Checked = false;
                CopyNameShortcutCheckbox.Checked = false;
            }
        }

        private void DirBackSelectAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DirBackSelectAllCheckbox.Checked)
            {
                DirBackSelectAllCheckbox.Text = Resources.SelectNone;
                DirBackAttributesCheckbox.Checked = true;
                DirBackComLinesCheckbox.Checked = true;
                SystemFoldersCheckbox.Checked = true;
                DirBackWallpaperCheckbox.Checked = true;
                PasteContentsCheckbox.Checked = true;
            }
            else
            {
                DirBackSelectAllCheckbox.Text = Resources.SelectAll;
                DirBackAttributesCheckbox.Checked = false;
                DirBackComLinesCheckbox.Checked = false;
                SystemFoldersCheckbox.Checked = false;
                DirBackWallpaperCheckbox.Checked = false;
                PasteContentsCheckbox.Checked = false;
            }
        }
    }
}
