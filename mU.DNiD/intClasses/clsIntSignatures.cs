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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNiD2.intClasses
{
    internal sealed class Signatures
    {
        private static bool m_Initialized;
        /// <summary>
        /// A quite simple setup of the signatures (originally added by Rue, except for the ConfuserEx one...);
        /// Protection Name (String), Search-Array (Short-Array), Start At EP (Bool)
        /// </summary>
        public static Dictionary<string, Tuple<short[], bool>> SignatureList = new Dictionary<string, Tuple<short[], bool>>();
        public static void Initialize()
        {
            if (!Initialized)
            {
                SignatureList.Add("ConfuserEx -> Ki", Tuple.Create(SignaturesList.sigConfuserEx, false));
                SignatureList.Add("AssemblyInvoke", Tuple.Create(SignaturesList.sigAssemblyInvoke, false));
                SignatureList.Add("Dotfuscator -> PreEmptive Solutions", Tuple.Create(SignaturesList.sigDotfuscator, false));
                SignatureList.Add("SmartAssembly v3.X -> RedGate", Tuple.Create(SignaturesList.sigSmartAssembly3, false));
                SignatureList.Add("SmartAssembly v4.X -> RedGate", Tuple.Create(SignaturesList.sigSmartAssembly4, false));
                SignatureList.Add("SmartAssembly v5.X -> RedGate", Tuple.Create(SignaturesList.sigSmartAssembly5, false));
                SignatureList.Add("SmartAssembly v6.X -> RedGate", Tuple.Create(SignaturesList.sigSmartAssembly6, false));
                SignatureList.Add("ReNET-Pack -> stx [Lz0]", Tuple.Create(SignaturesList.sigReNETPack, false));
                SignatureList.Add("DotNet Reactor v4.X -> Eziriz", Tuple.Create(SignaturesList.sigDotNetReactor4, false));
                SignatureList.Add("DotNet Reactor v4.X [Native] -> Eziriz", Tuple.Create(SignaturesList.sigDotNetReactor4Native, false));
                SignatureList.Add("DotNet Reactor v3.X [Native] -> Eziriz", Tuple.Create(SignaturesList.sigDotNetReactor3Native, false));
                SignatureList.Add("Phoenix Protector v1.7 - v1.8 -> NTCore", Tuple.Create(SignaturesList.sigPhoenixProtector17, false));
                SignatureList.Add("Phoenix Protector v1.X -> NTCore  ", Tuple.Create(SignaturesList.sigPhoenixProtector1x, false));
                SignatureList.Add("Confuser v1.X -> yck1509", Tuple.Create(SignaturesList.sigConfuser1x, false));
                SignatureList.Add("The Enigma Protector", Tuple.Create(SignaturesList.sigEnigmaProtector, false));
                SignatureList.Add("Enigma Virtual Box v1.X", Tuple.Create(SignaturesList.sigEnigmaVB1x, false));
                SignatureList.Add("PECompact .NET v2.0 - v3.X -> Bitsum Technologies", Tuple.Create(SignaturesList.sigPECompact2x3xNET, false));
                SignatureList.Add("dotNet Protector v4.0 - v5.x -> PV Logiciels", Tuple.Create(SignaturesList.sigdotNETProtector4x5x, false));
                SignatureList.Add(".NETZ Packer -> MadeBits", Tuple.Create(SignaturesList.sigNETZ, false));
                SignatureList.Add("DNGuard HVM -> ZiYuXuan Studio", Tuple.Create(SignaturesList.sigDNGuardHVM, false));
                SignatureList.Add("Eazfuscator.NET -> Oleksiy Gapotchenko", Tuple.Create(SignaturesList.sigEazfuscator, false));
                SignatureList.Add("Obfuscar v1.0 - v2.X", Tuple.Create(SignaturesList.sigObfuscar1x2x, false));
                SignatureList.Add("PC Guard for .NET v5.X -> SofPro", Tuple.Create(SignaturesList.sigPCGuardNET5x, false));
                SignatureList.Add("Rummage Obfuscator -> Aldaray", Tuple.Create(SignaturesList.sigRummage, false));
                SignatureList.Add("MaxToCode v3.5X -> Aiasted.SOFT", Tuple.Create(SignaturesList.sigMaxToCode35x, false));
                SignatureList.Add("MaxToCode Runtime .DLL -> Aiasted.SOFT", Tuple.Create(SignaturesList.sigMaxToCodeDLL, false));
                SignatureList.Add("Crypto Obfuscator For .Net v5.X -> LogicNP Software", Tuple.Create(SignaturesList.sigCryptoObfuscator5x, false));
                SignatureList.Add("Crypto Obfuscator For .Net v5.X -> LogicNP Software ", Tuple.Create(SignaturesList.sigCryptoObfuscator5x_2, false));
                SignatureList.Add("Skater .NET Obfuscator -> Rustemsoft", Tuple.Create(SignaturesList.sigSkater, false));
                SignatureList.Add("Codewall Obfuscator Evaluation v4.X", Tuple.Create(SignaturesList.sigCodewallEval4x, false));
                SignatureList.Add("Codewall Obfuscator v4.X", Tuple.Create(SignaturesList.sigCodewall4x, false));
                SignatureList.Add("Xenocode Postbuild v2.X - v3.X -> Code Systems", Tuple.Create(SignaturesList.sigXenocodePostBuild2x3x, false));
                SignatureList.Add("Xenocode Postbuild v2.X - v3.X -> Code Systems ", Tuple.Create(SignaturesList.sigXenocodePostBuild2x3x_2, false));
                SignatureList.Add("CliSecure 4.0 - 5.X -> Secure Team", Tuple.Create(SignaturesList.sigCliSecure4x5x, false));
                SignatureList.Add("CliSecure -> Secure Team", Tuple.Create(SignaturesList.sigCliSecure, false));
                SignatureList.Add("CodeVeil 4.X -> XHEO", Tuple.Create(SignaturesList.sigCodeVeil4x, false));
                SignatureList.Add("CodeVeil 3.0 - 4.X -> XHEO", Tuple.Create(SignaturesList.sigCodeVeil3x4x, false));
                SignatureList.Add("Spices.Net Obfuscator Evaluation -> 9Rays.Net", Tuple.Create(SignaturesList.sigSpicesEval, false));
                SignatureList.Add("Spices.Net Obfuscator -> 9Rays.Net", Tuple.Create(SignaturesList.sigSpices_1, false));
                SignatureList.Add("Spices.Net Obfuscator -> 9Rays.Net ", Tuple.Create(SignaturesList.sigSpices_2, false));
                SignatureList.Add("Obfuscator.NET 2009 Unregistered -> Macrobject Software", Tuple.Create(SignaturesList.sigObfuscatorNET2009Unreg, false));
                SignatureList.Add("Obfuscator.NET 2009 -> Macrobject Software", Tuple.Create(SignaturesList.sigObfuscatorNET2009, false));
                SignatureList.Add("Goliath .NET Obfuscator -> Cantelmo Software", Tuple.Create(SignaturesList.sigGoliath_1, false));
                SignatureList.Add("Goliath .NET Obfuscator -> Cantelmo Software ", Tuple.Create(SignaturesList.sigGoliath_2, false));
                SignatureList.Add("Babel Obfuscator v3.X -> Alberto Ferrazzoli", Tuple.Create(SignaturesList.sigBabelObf3x, false));
                SignatureList.Add("Babel Obfuscator v1.0 - 2.X -> Alberto Ferrazzoli", Tuple.Create(SignaturesList.sigBabelObf1x2x, false));
                SignatureList.Add("DeepSea Obfuscator Evaluation -> TallApplications BV.", Tuple.Create(SignaturesList.sigDeepSeaObfEval, false));
                SignatureList.Add("DeepSea Obfuscator -> TallApplications BV.", Tuple.Create(SignaturesList.sigDeepSeaObf, false));
                SignatureList.Add("FISH.NET v1.X -> Dr.Pc.Putte", Tuple.Create(SignaturesList.sigFISH1x_1, false));
                SignatureList.Add("FISH.NET v1.X -> Dr.Pc.Putte ", Tuple.Create(SignaturesList.sigFISH1x_2, false));
                SignatureList.Add(".NET Spider v0.5A - v1.3 -> Dr.Pc.Putte", Tuple.Create(SignaturesList.sigNETSpider0513, false));
                SignatureList.Add("MPAC Packer -> Dr.Pc.Putte", Tuple.Create(SignaturesList.sigMPAC, false));
                SignatureList.Add("MPRESS v1.0 - v2.X  -> MATCODE Software", Tuple.Create(SignaturesList.sigMPRESS1x2x_1, false));
                SignatureList.Add("MPRESS v1.0 - v2.X -> MATCODE Software ", Tuple.Create(SignaturesList.sigMPRESS1x2x_2, false));
                SignatureList.Add("ElecKey [AnyCPU] -> Sciensoft Research", Tuple.Create(SignaturesList.sigElecKeyAnyCPU, false));
                SignatureList.Add("ElecKey [x64] -> Sciensoft Research", Tuple.Create(SignaturesList.sigElecKeyx64, false));
                SignatureList.Add("Protect Me! 2010 [ GUI ] -> DiSTANTX", Tuple.Create(SignaturesList.sigProtectMe2010, false));
                SignatureList.Add("Themida v1.9 -> Oreans Technologies", Tuple.Create(SignaturesList.sigThemida19, false));
                SignatureList.Add("Themida v2.X -> Oreans Technologies", Tuple.Create(SignaturesList.sigThemida2x, false));
                SignatureList.Add("Adept Protector v1.X -> Singleply Software", Tuple.Create(SignaturesList.sigAdept1x, false));
                SignatureList.Add("Adept Protector v2.1 -> Singleply Software", Tuple.Create(SignaturesList.sigAdept21, false));
                SignatureList.Add("Sixxpack v2.2 -> PeArmor.com", Tuple.Create(SignaturesList.sigSixxpack22, false));
                SignatureList.Add("Sixxpack v2.4 -> reversers.net", Tuple.Create(SignaturesList.sigSixxpack24, false));
                SignatureList.Add(".netshrink v2.01 Demo [Password] -> PELock Software ", Tuple.Create(SignaturesList.signetshrink201demo_pass_1, false));
                SignatureList.Add(".netshrink v2.01 Demo [Password] -> PELock Software", Tuple.Create(SignaturesList.signetshrink201demo_pass_2, false));
                SignatureList.Add(".netshrink v2.01 Demo -> PELock Software ", Tuple.Create(SignaturesList.signetshrink201demo_1, false));
                SignatureList.Add(".netshrink v2.01 Demo -> PELock Software", Tuple.Create(SignaturesList.signetshrink201demo_2, false));
                SignatureList.Add("Dotpack 1.0B1 [ Deflate+Params ] -> Cody Brocious", Tuple.Create(SignaturesList.sigDotpack10b1_deflate_params, false));
                SignatureList.Add("Dotpack 1.0B1 [ Deflate ] -> Cody Brocious", Tuple.Create(SignaturesList.sigDotpack10b1_deflate, false));
                SignatureList.Add("Dotpack 1.0B1 [ LZMA ] -> Cody Brocious", Tuple.Create(SignaturesList.sigDotpack10b1_lzma, false));
                SignatureList.Add("Dotpack 1.0B1 Silverlight [ LZMA ] -> Cody Brocious", Tuple.Create(SignaturesList.sigDotpack10b1_lzma_silver, false));
                SignatureList.Add("Dotpack 1.0B1 Silverlight [ Deflate ] -> Cody Brocious", Tuple.Create(SignaturesList.sigDotpack10b1_deflate_silver, false));
                SignatureList.Add("Yano Obfuscator -> NToolbox", Tuple.Create(SignaturesList.sigYanoObf, false));
                Initialized = true;
            }
        }
        private static bool Initialized
        {
            get
            {
                return m_Initialized;
            }
            set
            {
                m_Initialized = value;
            }
        }
        internal sealed class SignaturesList
        {
            public static readonly short[] sigConfuserEx = new short[] {
                0x43, 0x6F, 0x6E, 0x66, 0x75, 0x73, 0x65, 0x72, 0x45, 0x78, 0x20, 0x76
            };

            public static readonly short[] sigSpices_2 = new short[] {
        0x4e, 0x69, 110, 0x65, 0x52, 0x61, 0x79, 0x73, 0x2e, 0x44, 0x65, 0x63, 0x6f, 0x6d, 0x70, 0x69,
        0x6c, 0x65, 0x72
     };
            public static readonly short[] sigRummage = new short[] {
        0x16, 0x1a, 0x8d, -1, -1, -1, -1, 0x25, 0x80, -1, -1, -1, -1, 0x16, 0x1f, 0x10,
        40, -1, -1, -1, -1, 0xde, -1, 7, 6, 8, 7, 0x1f, 0x10, 7, 0x59, 0x6f,
        -1, -1, -1, -1, 0x58, 0x2b
     };
            public static readonly short[] sigPhoenixProtector1x = new short[] {
        0x3f, -1, 0x3f, 0x2e, 0x3f, -1, 0x3f, 0x2e, 0x72, 0x65, 0x73, 0x6f, 0x75, 0x72, 0x63, 0x65,
        0x73
     };
            public static readonly short[] sigConfuser1x = new short[] {
        0x43, 0x6f, 110, 0x66, 0x75, 0x73, 0x65, 100, 0x42, 0x79, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62,
        0x75, 0x74, 0x65, 0, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65
     };
            public static readonly short[] sigNETSpider0513 = new short[] {
        80, 0x72, 0x6f, 0x74, 0x65, 0x63, 0x74, 0x65, 100, 0x5f, 0x42, 0x79, 0x5f, 0x41, 0x74, 0x74,
        0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0, 0x4e, 0x45, 0x54, 0x53, 0x70, 0x69, 100, 0x65, 0x72,
        0x2e, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65
     };
            public static readonly short[] sigEnigmaProtector = new short[] { 0x45, 0x4e, 0x49, 0x47, 0x4d, 0x41 };
            public static readonly short[] sigEnigmaVB1x = new short[] { 0x5b, 0x65, 110, 0x69, 0x67, 0x6d, 0x61, 0x6d, 0x61, 0x73, 0x6b, 0x73 };
            public static readonly short[] sigPECompact2x3xNET = new short[] {
        0x6d, 0x73, 0x63, 0x6f, 0x72, 0x65, 0x65, 0x2e, 100, 0x6c, 0x6c, 0, 0, 0, 0x43, 0x6f,
        0x72, 0x42, 0x69, 110, 100, 0x54, 0x6f, 0x52, 0x75, 110, 0x74, 0x69, 0x6d, 0x65, 0x45, 120
     };
            public static readonly short[] sigBabelObf3x = new short[] { 0, 0x42, 0x61, 0x62, 0x65, 0x6c, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0 };
            public static readonly short[] sigBabelObf1x2x = new short[] {
        0, 0x42, 0x61, 0x62, 0x65, 0x6c, 0x4f, 0x62, 0x66, 0x75, 0x73, 0x63, 0x61, 0x74, 0x6f, 0x72,
        0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0
     };
            public static readonly short[] sigFISH1x_1 = new short[] { 8, 0, 70, 0x49, 0x53, 0x48, 0x5f, 0x4e, 0x45, 0x54 };
            public static readonly short[] sigFISH1x_2 = new short[] { 70, 0x49, 0x53, 0x48, 0x2e, 0x4e, 0x45, 0x54 };
            public static readonly short[] sigYanoObf = new short[] {
        0, 0x41, 0x73, 0x73, 0x65, 0x6d, 0x62, 0x6c, 0x79, 0x44, 0x65, 0x73, 0x63, 0x72, 0x69, 0x70,
        0x74, 0x69, 0x6f, 110, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0, 0x59, 0x61,
        110, 0x6f, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0
     };
            public static readonly short[] sigMPRESS1x2x_1 = new short[] { 0x21, 0x49, 0x74, 0x27, 0x73, 0x20, 0x2e, 0x4e, 0x45, 0x54, 0x20, 0x45, 0x58, 0x45, 0x24 };
            public static readonly short[] sigMPRESS1x2x_2 = new short[] { 0x5f, 0, 0x6d, 0x70, 0x72, 0x65, 0x73, 0x73 };
            public static readonly short[] sigDotpack10b1_deflate = new short[] {
        0x53, 0x74, 0x61, 0x67, 0x65, -1, 0x2e, 0x44, 0x65, 0x66, 0x6c, 0x61, 0x74, 0x65, 0x2e, -1,
        -1, -1, 0
     };
            public static readonly short[] sigDotpack10b1_lzma = new short[] { 0x53, 0x74, 0x61, 0x67, 0x65, -1, 0x2e, 0x4c, 90, 0x4d, 0x41, 0x2e, -1, -1, -1, 0 };
            public static readonly short[] sigDotpack10b1_deflate_params = new short[] {
        0x53, 0x74, 0x61, 0x67, 0x65, -1, 0x2e, 0x44, 0x65, 0x66, 0x6c, 0x61, 0x74, 0x65, 0x2e, 80,
        0x61, 0x72, 0x61, 0x6d, 0x73, 0x2e, -1, -1, -1, 0
     };
            public static readonly short[] sigDotpack10b1_deflate_silver = new short[] {
        0x53, 0x74, 0x61, 0x67, 0x65, -1, 0x2e, 0x53, 0x69, 0x6c, 0x76, 0x65, 0x72, 0x6c, 0x69, 0x67,
        0x68, 0x74, 0x2e, 0x44, 0x65, 0x66, 0x6c, 0x61, 0x74, 0x65, 0x2e, -1, -1, -1, 0
     };
            public static readonly short[] sigDotpack10b1_lzma_silver = new short[] {
        0x53, 0x74, 0x61, 0x67, 0x65, -1, 0x2e, 0x53, 0x69, 0x6c, 0x76, 0x65, 0x72, 0x6c, 0x69, 0x67,
        0x68, 0x74, 0x2e, 0x4c, 90, 0x4d, 0x41, 0x2e, -1, -1, -1, 0
     };
            public static readonly short[] sigProtectMe2010 = new short[] {
        0, 80, 0x72, 0x6f, 0x74, 0x65, 0x63, 0x74, 0x5f, 0x4d, 0x65, 0x5f, 0x5f, 50, 0x30, 0x31,
        0x30, 0x5f, 0x47, 0x55, 0x49, 0x5f, 0x53, 0x74, 0x75, 0x62, 0
     };
            public static readonly short[] sigDotNetReactor4 = new short[] { 0x38, 2, 0, 0, 0, 0x26, 0x16 };
            public static readonly short[] sigDotNetReactor4Native = new short[] { 0xe4, 4, 0, 0, 0, 0, 0, 0, 2, 0, 0x5f, 0, 0x5f, 0, 0, 0 };
            public static readonly short[] sigMaxToCodeDLL = new short[] {
        0, 0x41, 0x74, 0x74, 0x69, 0x63, 0x6b, 0x2e, 100, 0x6c, 0x6c, 0, -1, -1, -1, -1,
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0x43, 0x68,
        0x65, 0x63, 0x6b, 0x52, 0x75, 110, 0x74, 0x69, 0x6d, 0x65, 0
     };
            public static readonly short[] sigMPAC = new short[] { 0, 0x4d, 80, 0x41, 0x43, 0, 0x4d, 80, 0x41, 0x43, 0x2e, 0x65, 120, 0x65, 0 };
            public static readonly short[] sigdotNETProtector4x5x = new short[] {
        0, 60, 100, 0x6f, 0x74, 0x4e, 0x65, 0x74, 80, 0x72, 0x6f, 0x74, 0x65, 0x63, 0x74, 0x6f,
        0x72, 0x3e, 0
     };
            public static readonly short[] sigNETZ = new short[] {
        0, 0x4e, 0x65, 0x74, 0x7a, 0x53, 0x74, 0x61, 0x72, 0x74, 0x65, 0x72, 0, 110, 0x65, 0x74,
        0x7a, 0
     };
            public static readonly short[] sigCliSecure4x5x = new short[] {
        0, 0x4f, 0x62, 0x66, 0x75, 0x73, 0x63, 0x61, 0x74, 0x65, 100, 0x42, 0x79, 0x43, 0x6c, 0x69,
        0x53, 0x65, 0x63, 0x75, 0x72, 0x65, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0
     };
            public static readonly short[] sigCliSecure = new short[] { 0x43, 0x6c, 0x69, 0, 0x53, 0, 0x65, 0, 0x63, 0, 0x75, 0, 0x72, 0, 0x65 };
            public static readonly short[] sigDeepSeaObfEval = new short[] {
        0, 0x44, 0x65, 0x65, 0x70, 0x53, 0x65, 0x61, 0x4f, 0x62, 0x66, 0x75, 0x73, 0x63, 0x61, 0x74,
        0x6f, 0x72, 0, 0x45, 0x76, 0x61, 0x6c, 0x75, 0x61, 0x74, 0x69, 0x6f, 110, 0
     };
            public static readonly short[] sigDeepSeaObf = new short[] {
        0, 0x44, 0x65, 0x65, 0x70, 0x53, 0x65, 0x61, 0x4f, 0x62, 0x66, 0x75, 0x73, 0x63, 0x61, 0x74,
        0x6f, 0x72, 0
     };
            public static readonly short[] sigDNGuardHVM = new short[] { 0, 90, 0x59, 0x58, 0x44, 0x4e, 0x47, 0x75, 0x61, 0x72, 100, 0x65, 0x72, 0 };
            public static readonly short[] sigGoliath_1 = new short[] {
        0, 0x4f, 0x62, 0x66, 0x75, 0x73, 0x63, 0x61, 0x74, 0x65, 100, 0x42, 0x79, 0x47, 0x6f, 0x6c,
        0x69, 0x61, 0x74, 0x68, 0
     };
            public static readonly short[] sigGoliath_2 = new short[] {
        0x2e, 0x47, 0x6f, 0x6c, 0x69, 0x61, 0x74, 0x68, 0x2e, 0x4e, 0x45, 0x54, 0x2e, 0x43, 0x6f, 100,
        0x65, 0x53, 0x68, 0x69, 0x65, 0x6c, 100, 0x2e
     };
            public static readonly short[] sigMaxToCode35x = new short[] {
        0, 0x49, 110, 0x66, 0x61, 0x63, 0x65, 0x4d, 0x61, 120, 0x74, 0x6f, 0x43, 0x6f, 100, 0x65,
        0x5f, 0x69, 110, 0x74, 0x65, 0x72, 0x66, 0x61, 0x63, 0x65, 0
     };
            public static readonly short[] sigEazfuscator = new short[] { 0x20, 0x72, 0xff, 0xff, 15, 0x5f, 0x20, 0x84, 0x1a, 0, 0, 0x61 };
            public static readonly short[] sigObfuscar1x2x = new short[] {
        0x7e, -1, -1, -1, -1, 6, 0x7e, -1, -1, -1, -1, 6, 0x91, 6, 0x61, 0x20,
        170, 0, 0, 0, 0x61, 210, 0x9c, 6, 0x17, 0x58, 10
     };
            public static readonly short[] sigPCGuardNET5x = new short[] {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0xfc, 0x55, 80, 0xe8, 0, 0, 0, 0, 0x5d, 0x60, 0xe8, 3, 0, 0, 0, 0x83
     };
            public static readonly short[] sigObfuscatorNET2009 = new short[] {
        0, 0x4d, 0x61, 0x63, 0x72, 0x6f, 0x62, 0x6a, 0x65, 0x63, 0x74, 0x2e, 0x4f, 0x62, 0x66, 0x75,
        0x73, 0x63, 0x61, 0x74, 0x6f, 0x72, 0
     };
            public static readonly short[] sigObfuscatorNET2009Unreg = new short[] {
        0, 0x4f, 0x62, 0x66, 0x75, 0x73, 0x63, 0x61, 0x74, 0x65, 100, 0x20, 0x62, 0x79, 0x20, 0x4d,
        0x61, 0x63, 0x72, 0x6f, 0x62, 0x6a, 0x65, 0x63, 0x74, 0x20, 0x4f, 0x62, 0x66, 0x75, 0x73, 0x63,
        0x61, 0x74, 0x6f, 0x72, 0x2e, 0x4e, 0x45, 0x54, 0x20, 0x55, 0x4e, 0x52, 0x45, 0x47, 0x49, 0x53,
        0x54, 0x52, 0x45, 0x44
     };
            public static readonly short[] sigSpices_1 = new short[] {
        0, 0x4e, 0x69, 110, 0x65, 0x52, 0x61, 0x79, 0x73, 0x2e, 0x4f, 0x62, 0x66, 0x75, 0x73, 0x63,
        0x61, 0x74, 0x6f, 0x72, 0
     };
            public static readonly short[] sigSpicesEval = new short[] {
        0x5f, 0x43, 0x6f, 0x72, 0x45, 120, 0x65, 0x4d, 0x61, 0x69, 110, 0, 0x6d, 0x73, 0x63, 0x6f,
        0x72, 0x65, 0x65, 0x2e, 100, 0x6c, 0x6c, -1, -1, -1, -1, -1, -1, -1, -1, -1,
        -1, -1, 0x42, 0x75, 0x69, 0x6c, 0x74, 0x20, 0x75, 0x73, 0x69, 110, 0x67, 0x20, 0x61, 110,
        0x20, 0x65, 0x76, 0x61, 0x6c, 0x75, 0x61, 0x74, 0x69, 0x6f, 110, 0x20, 0x76, 0x65, 0x72, 0x73,
        0x69, 0x6f, 110, 0x20, 0x6f, 0x66, 0x20, 0x39, 0x52, 0x61, 0x79, 0x73, 0x2e, 0x4e, 0x65, 0x74,
        0x20, 0x53, 0x70, 0x69, 0x63, 0x65, 0x73, 0x2e, 0x4f, 0x62, 0x66, 0x75, 0x73, 0x63, 0x61, 0x74,
        0x6f, 0x72, 0x2e
     };
            public static readonly short[] sigCodeVeil4x = new short[] { 0, 0x5f, 0x5f, 0x5f, 0x5f, 0x4b, 0x49, 0x4c, 0x4c, 0 };
            public static readonly short[] sigCodeVeil3x4x = new short[] {
        0x21, 0x45, 0, 0x5f, 0, 0x54, 0, 0x61, 0, 0x6d, 0, 0x70, 0, 0x65, 0, 0x72,
        0, 0x44, 0, 0x65, 0, 0x74, 0, 0x65, 0, 0x63, 0, 0x74, 0, 0x65, 0, 100,
        0, 0
     };
            public static readonly short[] sigXenocodePostBuild2x3x = new short[] {
        0x58, 0x65, 110, 0x6f, 0x63, 0x6f, 100, 0x65, 0x2e, 0x43, 0x6c, 0x69, 0x65, 110, 0x74, 0x2e,
        0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0x73, 0x2e, 0x41, 0x73, 0x73, 0x65, 0x6d,
        0x62, 0x6c, 0x79, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0x73
     };
            public static readonly short[] sigSmartAssembly6 = new short[] {
        80, 0x6f, 0x77, 0x65, 0x72, 0x65, 100, 0x20, 0x62, 0x79, 0x20, 0x53, 0x6d, 0x61, 0x72, 0x74,
        0x41, 0x73, 0x73, 0x65, 0x6d, 0x62, 0x6c, 0x79, 0x20, 0x36, 0x2e, -1, 0x2e, -1, 0x2e
     };
            public static readonly short[] sigXenocodePostBuild2x3x_2 = new short[] { 0x58, 0x65, 110, 0x6f, 0x63, 0x6f, 100, 0x65, 0x20, 50, 0x30, 0x30, 0x38 };
            public static readonly short[] sigSkater = new short[] {
        0x52, 0x75, 0x73, 0x74, 0x65, 0x6d, 0x53, 0x6f, 0x66, 0x74, 0x2e, 0x53, 0x6b, 0x61, 0x74, 0x65,
        0x72
     };
            public static readonly short[] sigDotfuscator = new short[] {
        0x44, 0x6f, 0x74, 0x66, 0x75, 0x73, 0x63, 0x61, 0x74, 0x6f, 0x72, 0x41, 0x74, 0x74, 0x72, 0x69,
        0x62, 0x75, 0x74, 0x65
     };
            public static readonly short[] sigThemida19 = new short[] { 0xb8, 0, 0, 0, 0, 0x60, 0x11, 0xc0 };
            public static readonly short[] sigThemida2x = new short[] { 0x83, 0xec, 4, 0x80, 0x53, 0xe8, 1, 0 };
            public static readonly short[] signetshrink201demo_pass_2 = new short[] {
        0x20, 0xfe, 0x2b, 0x13, 0x60, 40, -1, -1, -1, -1, 0x13, -1, 0x20, 0x3b, 40, 0x13,
        0x60, 40, -1, -1, -1, -1, 0x13, -1, 0x11, -1, 0x11, -1, 0x16, 0x1f, 0x40, 40,
        -1, -1, -1, -1, 0x26
     };
            public static readonly short[] signetshrink201demo_1 = new short[] {
        0x20, 230, 0xea, 0x19, 190, 40, -1, -1, -1, -1, 0x13, -1, 0x20, 0x39, 0xea, 0x19,
        190, 40, -1, -1, -1, -1, 0x13, -1, 0x11, -1, 0x11, -1, 0x16, 0x1f, 0x40, 40,
        -1, -1, -1, -1, 0x26
     };
            public static readonly short[] signetshrink201demo_pass_1 = new short[] {
        0x20, 0xad, 0x65, 0x13, 50, 40, -1, -1, -1, -1, 0x13, -1, 0x20, 0x68, 0x66, 0x13,
        50, 40, -1, -1, -1, -1, 0x13, -1, 0x11, -1, 0x11, -1, 0x16, 0x1f, 0x40, 40,
        -1, -1, -1, -1, 0x26
     };
            public static readonly short[] signetshrink201demo_2 = new short[] {
        0x20, 0xb9, 5, 0x9f, 7, 40, -1, -1, -1, -1, 0x13, -1, 0x20, 0x66, 5, 0x9f,
        7, 40, -1, -1, -1, -1, 0x13, -1, 0x11, -1, 0x11, -1, 0x16, 0x1f, 0x40, 40,
        -1, -1, -1, -1, 0x26
     };
            public static readonly short[] sigDotNetReactor3Native = new short[] {
        0x55, 0x8b, 0xec, 0xb9, 15, 0, 0, 0, 0x6a, 0, 0x6a, 0, 0x49, 0x75, 0xf9, 0x51,
        0x53, 0x56, 0x57, 0xb8, 4, 0x10, 0x42, 0, 0xe8, 0x53, 0x4e, 0xfe, 0xff, 0x33, 0xc0, 0x55,
        0x68, 0x21, 20, 0x42, 0, 100, 0xff, 0x30, 100, 0x89, 0x20, 0x68, 0, 0x7f, 0, 0,
        0x6a, 0, 0xe8, 0x95, 80, 0xfe, 0xff, 80, 0xe8, 0x7f, 80, 0xfe, 0xff, 0xa3, 0xfc, 0x48,
        0x42, 0, 0x68, 0x8a, 0x7f, 0, 0, 0x6a, 0, 0xe8, 0x7e, 80, 0xfe, 0xff, 80, 0xe8,
        0x68, 80, 0xfe, 0xff, 0x8b, 0xd8, 0xa1, 0xc0, 60, 0x42, 0, 0x83, 0x38, 0, 0x74, 10,
        0x8b, 0x35, 0xc0, 60
     };
            public static readonly short[] sigSmartAssembly5 = new short[] {
        80, 0x6f, 0x77, 0x65, 0x72, 0x65, 100, 0x20, 0x62, 0x79, 0x20, 0x53, 0x6d, 0x61, 0x72, 0x74,
        0x41, 0x73, 0x73, 0x65, 0x6d, 0x62, 0x6c, 0x79
     };
            public static readonly short[] sigSixxpack22 = new short[] {
        0, 0x61, 0x63, 0x74, 0x6d, 0x70, 0x2e, 100, 0x6c, 0x6c, 0, 0x73, 0x74, 0x75, 0x62, 0,
        0x53, 0x69, 120, 120, 0x70, 0x61, 0x63, 0x6b, 0
     };
            public static readonly short[] sigSixxpack24 = new short[] {
        0, 0x21, -1, -1, -1, 120, 0x70, 0x61, 0x63, 0x6b, 0x21, 0, -1, -1, -1, -1,
        -1, -1, -1, -1, 120, 0x70, 0x61, 0x63, 0x6b, 0
     };
            public static readonly short[] sigAdept1x = new short[] {
        0, 0x53, 0x6d, 0x61, 0x73, 0x68, 0x65, 100, 0x42, 0x79, 0x41, 100, 0x65, 0x70, 0x74, 80,
        0x72, 0x6f, 0x74, 0x65, 0x63, 0x74, 0x6f, 0x72, 0x2e
     };
            public static readonly short[] sigAdept21 = new short[] {
        0, 80, 0x72, 0x6f, 0x74, 0x65, 0x63, 0x74, 0x65, 100, 0x42, 0x79, 0x41, 100, 0x65, 0x70,
        0x74, 80, 0x72, 0x6f, 0x74, 0x65, 0x63, 0x74, 0x6f, 0x72, 0, 0x53, 0x54, 0x41, 0x54, 0x68,
        0x72, 0x65, 0x61, 100, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0
     };
            public static readonly short[] sigCryptoObfuscator5x = new short[] {
        0x20, -1, -1, 0, 2, 0x20, -1, -1, 0, 10, 0x20, 0xff, 0xff, 0xff, 0, 40,
        -1, -1, -1, -1, 0x2a
     };
            public static readonly short[] sigCryptoObfuscator5x_2 = new short[] {
        0x7e, -1, -1, -1, -1, 2, 0x91, 0x20, 0x3f, 0xff, 0xff, 0xff, 0x5f, 0x1f, 0x18, 0x62,
        10, 6, 0x7e, -1, -1, -1, -1, 2, 0x17, 0x58, 0x91, 0x1f, 0x10, 0x62, 0x60, 10,
        6, 0x7e
     };
            public static readonly short[] sigElecKeyAnyCPU = new short[] {
        0x83, 0xc4, 0x20, 0x68, 60, 0x81, 0x40, 0, 0x68, 0x30, 0x81, 0x40, 0, 0xc7, 0x44, 0x24,
        8, 0, 0, 0, 0, 0xff, 0x15, -1, -1, -1, -1, 80, 0xff, 0x15, -1, -1,
        -1, -1, 0x85, 0xc0, 0xa3, 0xc0, 0xac, 0x40, 0, 0x74, 0x11, 0x8d, 12, 0x24, 0x51, 0xff,
        0x15, -1, -1, -1, -1, 80, 0xff, 0x15, -1, -1, -1, -1, 0x8d, 0x84, 0x24, 0x10,
        1, 0, 0, 0x83, 0xc0, 0xff, 0x83, 60, 0x24, 0, 0x74, 0x23, 0x8d, 0x49, 0, 0x8a,
        0x48, 1, 0x83, 0xc0, 1, 0x84, 0xc9, 0x75, 0xf6, 0x66, 0x8b, 0x15, 0x58, 0x81, 0x40, 0,
        0x8a, 13, 90, 0x81, 0x40, 0, 0xeb, 30, 0x8d, 0xa4, 0x24, 0, 0, 0, 0, 0x8a,
        0x48, 1, 0x83, 0xc0, 1, 0x84, 0xc9, 0x75, 0xf6, 0x66, 0x8b, 0x15, 0x54, 0x81, 0x40, 0,
        0x8a, 13, 0x56, 0x81, 0x40
     };
            public static readonly short[] sigElecKeyx64 = new short[] {
        0x48, 0x8b, 13, 210, 190, 1, 0, 0x66, 0x41, 0xb8, 50, 0, 0x48, 0x8d, 0x91, 0x7b,
        7, 0, 0, 0xff, 0x15, 160, 0x40, 1, 0, 0x33, 0xc9, 0xff, 0x15, 0xb8, 0x40, 1,
        0, 0x48, 0x8b, 0xcb, 0xe8, 0x88, 250, 0xff, 0xff, 0xff, 0x15, 0xb2, 0x40, 1, 0, 0x33,
        0xc0, 0x48, 0x8b, 0x5c, 0x24, 0x30, 0x48, 0x83, 0xc4, 0x38, 0xc3
     };
            public static readonly short[] sigCodewallEval4x = new short[] {
        0, 60, 0x4d, 0x6f, 100, 0x75, 0x6c, 0x65, 0x3e, 0, 0x43, 0x6f, 100, 0x65, 0x57, 0x61,
        0x6c, 0x6c, 0x54, 0x72, 0x69, 0x61, 0x6c, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6f, 110
     };
            public static readonly short[] sigCodewall4x = new short[] {
        0x11, -1, 0x11, -1, 0x8f, -1, -1, -1, -1, 0x25, 0x71, -1, -1, -1, -1, 0x11,
        -1, 0x11, -1, 0x91, 0x61, 210, 0x81, -1, -1, -1, -1, 0x11, -1, 0x17, 0x58, 0x13,
        -1, 0x11, -1, 0x11, -1, 50, -1, 40, -1, -1, -1, -1, 0x11, -1, 0x6f, -1,
        -1, -1, -1, 0x13, -1, 0x7e, -1, -1, -1, -1, 0x2d, -1, 0x73
     };
            public static readonly short[] sigSmartAssembly4 = new short[] {
        80, 0x6f, 0x77, 0x65, 0x72, 0x65, 100, 0x20, 0x62, 0x79, 0x20, 0x7b, 0x73, 0x6d, 0x61, 0x72,
        0x74, 0x61, 0x73, 0x73, 0x65, 0x6d, 0x62, 0x6c, 0x79, 0x7d
     };
            public static readonly short[] sigReNETPack = new short[] {
        80, 0x72, 0x6f, 0x74, 0x65, 0x63, 0x74, 0x65, 100, 0x2f, 80, 0x61, 0x63, 0x6b, 0x65, 100,
        0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x52, 0x65, 0x4e, 0x45, 0x54, 0x2d, 80, 0x61, 0x63, 0x6b,
        0x20, 0x62, 0x79, 0x20, 0x73, 0x74, 120
     };
            public static readonly short[] sigAssemblyInvoke = new short[] {
        40, 0x2d, 0, 0, 10, 0x6f, 0x2e, 0, 0, 10, 20, 20, 0x6f, 0x2f, 0, 0,
        10
     };
            public static readonly short[] sigSmartAssembly3 = new short[] { 0x20, 0xff, 0xff, 0xff, 0, 0x5f, 0x17, 0x59, 0x20, 0xff, 0xff, 0, 0 };
            public static readonly short[] sigPhoenixProtector17 = new short[] {
        2, -1, -1, 0, 0, -1, 10, 6, -1, -1, 0, 0, 1, 11, 0x16, 12,
        -1, -1, -1, -1, -1, 2, 8, -1, -1, -1, -1, -1, 13, 9, 6, 8,
        0x59, 0x61, 210, 0x13, 4, 9, 30, 0x63, 8, 0x61, 210, 0x13, 5, 7, 8, 0x11,
        5, 30, 0x62, 0x11, 4, 0x60, 0xd1, 0x9d, 8, 0x17, 0x58
     };
        }
    }
}
