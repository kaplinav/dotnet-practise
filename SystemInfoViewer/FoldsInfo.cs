using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace SystemInfoViewer
{
    public class FoldsInfo
    {
        const int MaxPathLength = 255;
        public string WindowsDirectory { get; private set; }
        public string SystemDirectory { get; private set; }
        public string SystemWindowsDirectory { get; private set; }

        public FoldsInfo()
        {
            GetWindowsDirectory();
            GetSystemDirectory();
            GetSystemWindowsDirectory();
        }

        private void GetWindowsDirectory()
        {
            StringBuilder sb = new StringBuilder(MaxPathLength);
            uint length = GetWindowsDirectory(sb, MaxPathLength);
            WindowsDirectory = sb.ToString(0, (int)length);
        }

        private void GetSystemDirectory()
        {
            StringBuilder sb = new StringBuilder(MaxPathLength);
            uint length = GetSystemDirectory(sb, MaxPathLength);
            SystemDirectory = sb.ToString(0, (int)length);
        }

        private void GetSystemWindowsDirectory()
        {
            StringBuilder sb = new StringBuilder(MaxPathLength);
            uint length = GetSystemWindowsDirectory(sb, MaxPathLength);
            SystemWindowsDirectory = sb.ToString(0, (int)length);
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern uint GetWindowsDirectory(StringBuilder lpBuffer, uint uSize);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern uint GetSystemDirectory(StringBuilder lpBuffer, uint uSize);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern uint GetSystemWindowsDirectory(StringBuilder lpBuffer, uint uSize);
    }
}
