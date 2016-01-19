/*
    DNiD 2 - PE Identifier.
    Copyright (C) 2016  mammon

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DNiD2.intClasses.BeaEngine
{
    public class BeaConstants
    {
        public static int INSTRUCT_LENGTH = 64;
        public enum SegmentRegister : byte
        {
            ESReg = 1,
            DSReg = 2,
            FSReg = 3,
            GSReg = 4,
            CSReg = 5,
            SSReg = 6
        }

        public enum PrefixType : byte
        {
            NotUsedPrefix = 0,
            InUsePrefix = 1,
            SuperfluousPrefix = 2,
            InvalidPrefix = 4,
            MandatoryPrefix = 8
        }

        public enum InstructionType : uint
        {
            GENERAL_PURPOSE_INSTRUCTION = 0x10000,
            FPU_INSTRUCTION = 0x20000,
            MMX_INSTRUCTION = 0x40000,
            SSE_INSTRUCTION = 0x80000,
            SSE2_INSTRUCTION = 0x100000,
            SSE3_INSTRUCTION = 0x200000,
            SSSE3_INSTRUCTION = 0x400000,
            SSE41_INSTRUCTION = 0x800000,
            SSE42_INSTRUCTION = 0x1000000,
            SYSTEM_INSTRUCTION = 0x2000000,
            VM_INSTRUCTION = 0x4000000,
            UNDOCUMENTED_INSTRUCTION = 0x8000000,
            AMD_INSTRUCTION = 0x10000000,
            ILLEGAL_INSTRUCTION = 0x20000000,
            AES_INSTRUCTION = 0x40000000,
            CLMUL_INSTRUCTION = 0x80000000,

            DATA_TRANSFER = 0x1,
            ARITHMETIC_INSTRUCTION,
            LOGICAL_INSTRUCTION,
            SHIFT_ROTATE,
            BIT_UInt8,
            CONTROL_TRANSFER,
            STRING_INSTRUCTION,
            InOutINSTRUCTION,
            ENTER_LEAVE_INSTRUCTION,
            FLAG_CONTROL_INSTRUCTION,
            SEGMENT_REGISTER,
            MISCELLANEOUS_INSTRUCTION,
            COMPARISON_INSTRUCTION,
            LOGARITHMIC_INSTRUCTION,
            TRIGONOMETRIC_INSTRUCTION,
            UNSUPPORTED_INSTRUCTION,
            LOAD_CONSTANTS,
            FPUCONTROL,
            STATE_MANAGEMENT,
            CONVERSION_INSTRUCTION,
            SHUFFLE_UNPACK,
            PACKED_SINGLE_PRECISION,
            SIMD128bits,
            SIMD64bits,
            CACHEABILITY_CONTROL,
            FP_INTEGER_CONVERSION,
            SPECIALIZED_128bits,
            SIMD_FP_PACKED,
            SIMD_FP_HORIZONTAL,
            AGENT_SYNCHRONISATION,
            PACKED_ALIGN_RIGHT,
            PACKED_SIGN,
            PACKED_BLENDING_INSTRUCTION,
            PACKED_TEST,
            PACKED_MINMAX,
            HORIZONTAL_SEARCH,
            PACKED_EQUALITY,
            STREAMING_LOAD,
            INSERTION_EXTRACTION,
            DOT_PRODUCT,
            SAD_INSTRUCTION,
            ACCELERATOR_INSTRUCTION,
            ROUND_INSTRUCTION
        }

        public enum EFlagState : byte
        {
            TE_ = 1,
            MO_ = 2,
            RE_ = 4,
            SE_ = 8,
            UN_ = 0x10,
            PR_ = 0x20
        }

        public enum BranchType : short
        {
            JO = 1,
            JC,
            JE,
            JA,
            JS,
            JP,
            JL,
            JG,
            JB,
            JECXZ,
            JmpType,
            CallType,
            RetType,
            JNO = -1,
            JNC = -2,
            JNE = -3,
            JNA = -4,
            JNS = -5,
            JNP = -6,
            JNL = -7,
            JNG = -8,
            JNB = -9
        }

        public enum ArgumentType : uint
        {
            NO_ARGUMENT = 0x10000000,
            REGISTER_TYPE = 0x20000000,
            MEMORY_TYPE = 0x40000000,
            CONSTANT_TYPE = 0x80000000,

            MMX_REG = 0x10000,
            GENERAL_REG = 0x20000,
            FPU_REG = 0x40000,
            SSE_REG = 0x80000,
            CR_REG = 0x100000,
            DR_REG = 0x200000,
            SPECIAL_REG = 0x400000,
            MEMORY_MANAGEMENT_REG = 0x800000,
            SEGMENT_REG = 0x1000000,

            RELATIVE_ = 0x4000000,
            ABSOLUTE_ = 0x8000000,

            READ = 0x1,
            WRITE = 0x2,

            REG0 = 0x1,
            REG1 = 0x2,
            REG2 = 0x4,
            REG3 = 0x8,
            REG4 = 0x10,
            REG5 = 0x20,
            REG6 = 0x40,
            REG7 = 0x80,
            REG8 = 0x100,
            REG9 = 0x200,
            REG10 = 0x400,
            REG11 = 0x800,
            REG12 = 0x1000,
            REG13 = 0x2000,
            REG14 = 0x4000,
            REG15 = 0x8000
        }

        public enum SpecialInfo : int
        {
            UNKNOWN_OPCODE = -1,
            OUT_OF_BLOCK = 0,

            /* === mask = 0xff */
            NoTabulation = 0x00000000,
            Tabulation = 0x00000001,

            /* === mask = 0xff00 */
            MasmSyntax = 0x00000000,
            GoAsmSyntax = 0x00000100,
            NasmSyntax = 0x00000200,
            ATSyntax = 0x00000400,

            /* === mask = 0xff0000 */
            PrefixedNumeral = 0x00010000,
            SuffixedNumeral = 0x00000000,

            /* === mask = 0xff000000 */
            ShowSegmentRegs = 0x01000000
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class REX_Struct
    {
        public byte W_;
        public byte R_;
        public byte X_;
        public byte B_;
        public byte state;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PrefixInfo
    {
        public int Number;
        public int NbUndefined;
        public byte LockPrefix;
        public byte OperandSize;
        public byte AddressSize;
        public byte RepnePrefix;
        public byte RepPrefix;
        public byte FSPrefix;
        public byte SSPrefix;
        public byte GSPrefix;
        public byte ESPrefix;
        public byte CSPrefix;
        public byte DSPrefix;
        public byte BranchTaken;
        public byte BranchNotTaken;
        public REX_Struct REX;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class EFLStruct
    {
        public byte OF_;
        public byte SF_;
        public byte ZF_;
        public byte AF_;
        public byte PF_;
        public byte CF_;
        public byte TF_;
        public byte IF_;
        public byte DF_;
        public byte NT_;
        public byte RF_;
        public byte alignment;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class MemoryType
    {
        public Int32 BaseRegister;
        public Int32 IndexRegister;
        public Int32 Scale;
        public Int64 Displacement;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class InstructionType
    {
        public Int32 Category;
        public Int32 Opcode;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string Mnemonic;
        public Int32 BranchType;
        public EFLStruct Flags;
        public UInt64 AddrValue;
        public Int64 Immediat;
        public UInt32 ImplicitModifiedRegs;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ArgumentType
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string ArgMnemonic;
        public Int32 ArgType;
        public Int32 ArgSize;
        public UInt32 AccessMode;
        public MemoryType Memory;
        public UInt32 SegmentReg;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalDatas
    {
        private UIntPtr EIP_;
        private UInt64 EIP_VA;
        private UIntPtr EIP_REAL;
        private Int32 OriginalOperandSize;
        private Int32 OperandSize;
        private Int32 MemDecoration;
        private Int32 AddressSize;
        private Int32 MOD_;
        private Int32 RM_;
        private Int32 INDEX_;
        private Int32 SCALE_;
        private Int32 BASE_;
        private Int32 MMX_;
        private Int32 SSE_;
        private Int32 CR_;
        private Int32 DR_;
        private Int32 SEG_;
        private Int32 REGOPCODE;
        private UInt32 DECALAGE_EIP;
        private Int32 FORMATNUMBER;
        private Int32 SYNTAX_;
        private UInt64 EndOfBlock;
        private Int32 RelativeAddress;
        private UInt32 Architecture;
        private Int32 ImmediatSize;
        private Int32 NB_PREFIX;
        private Int32 PrefRepe;
        private Int32 PrefRepne;
        private UInt32 SEGMENTREGS;
        private UInt32 SEGMENTFS;
        private Int32 third_arg;
        private Int32 TAB_;
        private Int32 ERROR_OPCODE;
        private REX_Struct REX;
        private Int32 OutOfBlock;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Disasm
    {
        public IntPtr EIP;
        public UInt64 VirtualAddr;
        public UInt32 SecurityBlock;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string CompleteInstr;
        public UInt32 Archi;
        public UInt64 Options;
        public InstructionType Instruction;
        public ArgumentType Argument1;
        public ArgumentType Argument2;
        public ArgumentType Argument3;
        public PrefixInfo Prefix;
        public InternalDatas reserved;
    }
    public class BeaEngine
    {
        public static int Disasm([In, Out, MarshalAs(UnmanagedType.LPStruct)] Disasm disasm)
        {
            try
            {
                var a = clsNativeDllLoader.load_function<clsNativeDllLoader.Disasm>("_Disasm@4", Path.GetTempPath() + "BeaEngine.dll");
                var b = a(disasm);
                return b;
            }
            catch (Exception ex)
            {
                using (var frm = new intForms.frmError("TargetSite: " + ex.TargetSite.Name + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "InternalHelpLink: " + ex.HelpLink))
                {
                    frm.ShowDialog();
                }
                return -1;
            }
        }

        private static string BeaEngineVersion()
        {
            try
            {
                var a = clsNativeDllLoader.load_function<clsNativeDllLoader.BeaEngineVersion>("_BeaEngineVersion@0", Path.GetTempPath() + "BeaEngine.dll");
                var b = a();
                return b;
            }
            catch (Exception ex)
            {
                using (var frm = new intForms.frmError("TargetSite: " + ex.TargetSite.Name + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "InternalHelpLink: " + ex.HelpLink))
                {
                    frm.ShowDialog();
                }
                return null;
            }
        }

        private static string BeaEngineRevision()
        {
            try
            {
                var a = clsNativeDllLoader.load_function<clsNativeDllLoader.BeaEngineRevision>("_BeaEngineRevision@0", Path.GetTempPath() + "BeaEngine.dll");
                var b = a();
                return b;
            }
            catch (Exception ex)
            {
                using (var frm = new intForms.frmError("TargetSite: " + ex.TargetSite.Name + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "InternalHelpLink: " + ex.HelpLink))
                {
                    frm.ShowDialog();
                }
                return null;
            }
        }
        public static string Version
        {
            get
            {
                return BeaEngineVersion();
            }
        }

        public static string Revision
        {
            get
            {
                return BeaEngineRevision();
            }
        }
    }
    public class UnmanagedBuffer
    {
        public readonly IntPtr Ptr = IntPtr.Zero;
        public readonly int Length = 0;

        public UnmanagedBuffer(byte[] data)
        {
            Ptr = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, Ptr, data.Length);
            Length = data.Length;
        }
        ~UnmanagedBuffer()
        {
            if (Ptr != IntPtr.Zero)
                Marshal.FreeHGlobal(Ptr);
        }
    }
}
