﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace SystemInfoViewer
{
    public enum ProcessorFeature : uint
    {
        /// <summary>
        /// On a Pentium, a floating-point precision error can occur in rare circumstances
        /// </summary>
        FloatingPointPrecisionErrata = 0,
        /// <summary>
        /// Floating-point operations are emulated using a software emulator.
        /// This function returns a nonzero value if floating-point operations are emulated; otherwise, it returns zero.
        /// </summary>
        FloatingPointEmulated = 1,
        /// <summary>
        /// The atomic compare and exchange operation (cmpxchg) is available
        /// </summary>
        CompareExchangeDouble = 2,
        /// <summary>
        /// The MMX instruction set is available
        /// </summary>
        InstructionsMMXAvailable = 3,
        /// <summary>
        /// The SSE instruction set is available
        /// </summary>
        InstructionsXMMIAvailable = 6,
        /// <summary>
        /// The 3D-Now instruction set is available.
        /// </summary>
        Instruction3DNowAvailable = 7,
        /// <summary>
        /// The RDTSC instruction is available
        /// </summary>
        InstructionRDTSCAvailable = 8,
        /// <summary>
        /// The processor is PAE-enabled
        /// </summary>
        PAEEnabled = 9,
        /// <summary>
        /// The SSE2 instruction set is available
        /// </summary>
        InstructionsXMMI64Available = 10,
        /// <summary>
        /// Data execution prevention is enabled. (This feature is not supported until Windows XP SP2 and Windows Server 2003 SP1)
        /// </summary>
        NXEnabled = 12,
        /// <summary>
        /// The SSE3 instruction set is available. (This feature is not supported until Windows Vista)
        /// </summary>
        InstructionsSSE3Available = 13,
        /// <summary>
        /// The atomic compare and exchange 128-bit operation (cmpxchg16b) is available. (This feature is not supported until Windows Vista)
        /// </summary>
        CompareExchange128 = 14,
        /// <summary>
        /// The atomic compare 64 and exchange 128-bit operation (cmp8xchg16) is available (This feature is not supported until Windows Vista.)
        /// </summary>
        Compare64Exchange128 = 15,
        /// <summary>
        /// TBD
        /// </summary>
        ChannelsEnabled = 16,
    }

    public class CPUInfo
    {
        public bool FloatingPointPrecisionErrata { get; set; }
        public bool FloatingPointEmulated { get; set; }
        public bool CompareExchangeDouble { get; set; }
        public bool InstructionsMMXAvailable { get; set; }
        public bool InstructionsXMMIAvailable { get; set; }
        public bool Instruction3DNowAvailable { get; set; }
        public bool InstructionRDTSCAvailable { get; set; }
        public bool PAEEnabled { get; set; }
        public bool InstructionsXMMI64Available { get; set; }
        public bool NXEnabled { get; set; }
        public bool InstructionsSSE3Available { get; set; }
        public bool CompareExchange128 { get; set; }
        public bool Compare64Exchange128 { get; set; }
        public bool ChannelsEnabled { get; set; }

        public CPUInfo()
        {
            FloatingPointPrecisionErrata = IsProcessorFeaturePresent(ProcessorFeature.FloatingPointPrecisionErrata);
            FloatingPointEmulated = IsProcessorFeaturePresent(ProcessorFeature.FloatingPointEmulated);
            CompareExchangeDouble = IsProcessorFeaturePresent(ProcessorFeature.CompareExchangeDouble);
            InstructionsMMXAvailable = IsProcessorFeaturePresent(ProcessorFeature.InstructionsMMXAvailable);
            InstructionsXMMIAvailable = IsProcessorFeaturePresent(ProcessorFeature.InstructionsXMMIAvailable);
            Instruction3DNowAvailable = IsProcessorFeaturePresent(ProcessorFeature.Instruction3DNowAvailable);
            InstructionRDTSCAvailable = IsProcessorFeaturePresent(ProcessorFeature.InstructionRDTSCAvailable);
            PAEEnabled = IsProcessorFeaturePresent(ProcessorFeature.PAEEnabled);
            InstructionsXMMI64Available = IsProcessorFeaturePresent(ProcessorFeature.InstructionsXMMI64Available);
            NXEnabled = IsProcessorFeaturePresent(ProcessorFeature.NXEnabled);
            InstructionsSSE3Available = IsProcessorFeaturePresent(ProcessorFeature.InstructionsSSE3Available);
            CompareExchange128 = IsProcessorFeaturePresent(ProcessorFeature.CompareExchange128);
            Compare64Exchange128 = IsProcessorFeaturePresent(ProcessorFeature.Compare64Exchange128);
            ChannelsEnabled = IsProcessorFeaturePresent(ProcessorFeature.ChannelsEnabled);
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsProcessorFeaturePresent(ProcessorFeature processorFeature);
    }
}