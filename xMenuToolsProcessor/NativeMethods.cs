using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace xMenuToolsProcessor
{
    internal static class ExplorerRefresh
    {
        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = NativeMethods.GetForegroundWindow();

            if (NativeMethods.GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public static void ForceSetForegroundWindow(IntPtr hWnd, IntPtr mainThreadId)
        {
            uint foregroundThreadID = NativeMethods.GetWindowThreadProcessId(NativeMethods.GetForegroundWindow(), IntPtr.Zero);
            IntPtr ForeGroundThreadID = new IntPtr(foregroundThreadID);
            if (ForeGroundThreadID != mainThreadId)
            {
                NativeMethods.AttachThreadInput(mainThreadId, ForeGroundThreadID, true);
                NativeMethods.SetForegroundWindow(hWnd);
                NativeMethods.AttachThreadInput(mainThreadId, ForeGroundThreadID, false);
            }
            else
            {
                NativeMethods.SetForegroundWindow(hWnd);
            }
        }

        internal static void RefreshWindowsExplorer()
        {
            // Refresh the desktop
            string ActiveWindow = GetActiveWindowTitle();
            NativeMethods.SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero).GetTypeCode();
            ForceSetForegroundWindow(NativeMethods.GetShellWindow(), IntPtr.Zero);
            SendKeys.SendWait("{F5}");

            // Refresh Explorer Windows
            Guid CLSID_ShellApplication = new Guid("13709620-C279-11CE-A49E-444553540000");
            Type shellApplicationType = Type.GetTypeFromCLSID(CLSID_ShellApplication, true);

            object shellApplication = Activator.CreateInstance(shellApplicationType);
            object windows = shellApplicationType.InvokeMember("Windows", System.Reflection.BindingFlags.InvokeMethod, null, shellApplication, new object[] { });

            Type windowsType = windows.GetType();
            object count = windowsType.InvokeMember("Count", System.Reflection.BindingFlags.GetProperty, null, windows, null);
            for (int i = 0; i < (int)count; i++)
            {
                object item = windowsType.InvokeMember("Item", System.Reflection.BindingFlags.InvokeMethod, null, windows, new object[] { i });
                Type itemType = item.GetType();

                string itemName = (string)itemType.InvokeMember("Name", System.Reflection.BindingFlags.GetProperty, null, item, null);
                if (itemName == "Windows Explorer" || itemName == "File Explorer")
                {
                    itemType.InvokeMember("Refresh", System.Reflection.BindingFlags.InvokeMethod, null, item, null);
                }
            }
            // Make recently active window active again
            if (ActiveWindow != null)
            {
                IntPtr hWnd = NativeMethods.FindWindowByCaption(IntPtr.Zero, ActiveWindow);
                if (hWnd != IntPtr.Zero)
                {
                    NativeMethods.SetForegroundWindow(hWnd);
                }
            }
        }
    }
    internal static class NativeMethods
    {
        // Refresh Explorer
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindow", SetLastError = true)]
        internal static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, [MarshalAs(UnmanagedType.Bool)] bool fAttach);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetShellWindow();

        [DllImport("shell32.dll")]
        internal static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

        // Create Shorcut in All Users Start Menu Programs
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, [MarshalAs(UnmanagedType.Bool)] bool fCreate);
        internal const int CSIDL_COMMON_STARTMENU = 0x16;

        internal const uint WM_QUIT = 0x12;

        [StructLayout(LayoutKind.Sequential)]
        internal struct RM_UNIQUE_PROCESS
        {
            internal int dwProcessId;
            internal System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
        }
        internal const int RmRebootReasonNone = 0;
        internal const int CCH_RM_MAX_APP_NAME = 255;
        internal const int CCH_RM_MAX_SVC_NAME = 63;

        internal enum RM_APP_TYPE
        {
            RmUnknownApp = 0,
            RmMainWindow = 1,
            RmOtherWindow = 2,
            RmService = 3,
            RmExplorer = 4,
            RmConsole = 5,
            RmCritical = 1000
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct RM_PROCESS_INFO
        {
            internal RM_UNIQUE_PROCESS Process;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_APP_NAME + 1)]
            internal string strAppName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_SVC_NAME + 1)]
            internal string strServiceShortName;

            internal RM_APP_TYPE ApplicationType;
            internal uint AppStatus;
            internal uint TSSessionId;
            [MarshalAs(UnmanagedType.Bool)]
            internal bool bRestartable;
        }
    }
}