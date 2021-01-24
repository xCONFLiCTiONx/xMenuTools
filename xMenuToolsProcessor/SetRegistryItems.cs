using Microsoft.Win32;

namespace xMenuTools
{
    class SetRegistryItems
    {
        static RegistryKey xMenuToolsSettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\xMenuTools\\Settings");
        internal static void SetItems()
        {
            // All Files
            xMenuToolsSettings.SetValue("OpenNotepadFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("BlockWithFirewallFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyNameFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyPathFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyURLFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyLONGPathFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("AttributesFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("SymlinkFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("TakeOwnershipFiles", 0x00000001, RegistryValueKind.DWord);
            // All Files Shorcuts
            xMenuToolsSettings.SetValue("AttributesShort", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("OpenNotepadShort", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyNameShortFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyPathShortFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyURLShortFiles", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyLONGPathShortFiles", 0x00000001, RegistryValueKind.DWord);
            // Directories
            xMenuToolsSettings.SetValue("BlockWithFirewallDirectory", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyNameDirectory", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyPathDirectory", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyURLDirectory", 0x00000001, RegistryValueKind.DWord);
            xMenuToolsSettings.SetValue("CopyLONGPathDirectory", 0x00000001, RegistryValueKind.DWord);
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
}
