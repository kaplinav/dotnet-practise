using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace SystemInfoViewer
{
    public class VarsInfo
    {
        const int MaxPathLength = 300;
        public string PATH { get; set; }
        public string TMP { get; set; }
        public string TEMP { get; set; }
        public string OS { get; set; }
        public string USERNAME { get; set; }

        public VarsInfo()
        {
            FillValues();
        }

        private void FillValues()
        {
            string value = null;
            value = GetValue("PATH");
            if (value != null)
                PATH = value;

            value = GetValue("TMP");
            if (value != null)
                TMP = value;

            value = GetValue("TEMP");
            if (value != null)
                TEMP = value;

            value = GetValue("OS");
            if (value != null)
                OS = value;

            value = GetValue("USERNAME");
            if (value != null)
                USERNAME = value;
        }

        private string GetValue(string lpName)
        {
            StringBuilder sb = new StringBuilder(MaxPathLength);
            uint length = GetEnvironmentVariable(lpName, sb, MaxPathLength);
            return sb.ToString(0, (int)length);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern uint GetEnvironmentVariable(string lpName, StringBuilder lpBuffer, uint nSize);
    }
}
