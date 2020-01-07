using Microsoft.Win32;
using System.IO;

namespace MenuToolsProcessor
{
    internal class Shortcut
    {
        internal static void Create(string shortcutFolder, string InstallInfo)
        {
            IWshRuntimeLibrary.WshShell shellClass = new IWshRuntimeLibrary.WshShell();
            //Create Shortcut for Application Settings
            string settingsLink = Path.Combine(shortcutFolder, "Settings.lnk");
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shellClass.CreateShortcut(settingsLink);

            string FileLocationInfo = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\MenuTools";
            RegistryKey MenuToolsKey = Registry.LocalMachine.OpenSubKey(FileLocationInfo, false);

            string fileLocation = (string)MenuToolsKey.GetValue("InstallFileLocation");

            if (!string.IsNullOrEmpty(fileLocation))
            {
                shortcut.TargetPath = fileLocation;
                shortcut.Description = "MenuTools Settings";
                shortcut.Save();
            }
        }
    }
}
