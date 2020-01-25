using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace SystemInfoViewer
{
    public class SystemInfo
    {
        // LayoutKind.Sequential Члены объекта располагаются последовательно, 
        // в порядке своего появления при экспортировании в неуправляемую память.
        // Pack Поле управляет выравниванием полей типа в памяти.
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct SYSTEM_INFO
        {
            internal ushort wProcessorArchitecture;
            internal ushort wReserved;
            internal uint dwPageSize;
            internal IntPtr lpMinimumApplicationAddress;
            internal IntPtr lpMaximumApplicationAddress;
            internal IntPtr dwActiveProcessorMask;
            internal uint dwNumberOfProcessors;
            internal uint dwProcessorType;
            internal uint dwAllocationGranularity;
            internal ushort wProcessorLevel;
            internal ushort wProcessorRevision;
        }

        internal static SYSTEM_INFO si;
        public string NumberOfCPUs { get => si.dwNumberOfProcessors.ToString(); }
        public string PageSize { get => si.dwPageSize.ToString(); }
        public string CPUType { get => si.dwProcessorType.ToString(); }
        public string MinAppAddress { get => si.lpMinimumApplicationAddress.ToString(); }
        public string MaxAppAddress { get => si.lpMaximumApplicationAddress.ToString(); }
        public string ActiveCPUMask { get => si.dwActiveProcessorMask.ToString(); }

        public SystemInfo()
        {
            GetSystemInfo(out si);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern void GetSystemInfo(out SYSTEM_INFO si);
    }
}
