using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace MenuToolsProcessor
{

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
                Uri assemblyUri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
                AssemblyInfo = Path.GetDirectoryName(assemblyUri.LocalPath);
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
