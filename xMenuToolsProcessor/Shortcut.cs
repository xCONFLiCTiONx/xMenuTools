using Microsoft.Win32;
using System.IO;

namespace xMenuToolsProcessor
{
    internal class Shortcut
    {
        internal static void Create(string shortcutFolder, string InstallInfo)
        {
            IWshRuntimeLibrary.WshShell shellClass = new IWshRuntimeLibrary.WshShell();
            //Create Shortcut for Application Settings
            string settingsLink = Path.Combine(shortcutFolder, "xMenuTools Settings.lnk");
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shellClass.CreateShortcut(settingsLink);

            string FileLocationInfo = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\xMenuTools";
            RegistryKey xMenuToolsKey = Registry.LocalMachine.OpenSubKey(FileLocationInfo, false);

            string fileLocation = (string)xMenuToolsKey.GetValue("InstallFileLocation");

            if (!string.IsNullOrEmpty(fileLocation))
            {
                shortcut.TargetPath = fileLocation;
                shortcut.Description = "xMenuTools Settings";
                shortcut.Save();
            }
        }
    }
}
