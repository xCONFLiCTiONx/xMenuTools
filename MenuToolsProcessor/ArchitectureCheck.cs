using System;

namespace MenuToolsProcessor
{
    internal static class ArchitectureCheck
    {
        internal static bool ProcessorIs64Bit()
        {
            if (IntPtr.Size == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
