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

namespace DNiD2.intClasses
{
    static class clsPluginSupport
    {
        [DllImport("kernel32.dll")]
        internal static extern IntPtr LoadLibrary(string dllname);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string procname);
        [DllImport("kernel32.dll")]
        internal static extern bool FreeLibrary(IntPtr hModule);

        //TODO: Add support for both x86 & x64 plugins - both Native & .NET

        /// <summary>
        /// The complete PEiD plugins list that is present...
        /// </summary>
        public static Dictionary<string, string> plugPEiD = new Dictionary<string, string>();
        /// <summary>
        /// The complete DNiD plugins list that is present...
        /// </summary>
        public static Dictionary<string, string> plugDNiD = new Dictionary<string, string>();

        #region PEiD Plugins Support Methods:
        /// <summary>
        /// Initiates the PEiD plugins if they are present in
        /// %DNiD2_Directory%\plugins\PEiD\...
        /// </summary>
        public static void InitPeidPlugins()
        {
            var a = Directory.GetFiles(Environment.CurrentDirectory + @"\plugins\PEiD\");
            foreach(var b in a)
            {
                var c = LoadDllInfo(b);
                if (c.Length > 0)
                    AddPeidPlugin(c, b);
            }
        }
        /// <summary>
        /// Initiates the external PEiD plugin...
        /// </summary>
        /// <param name="dllName">Full Path of Plugin...</param>
        /// <param name="szFileName">Filename that is present in DNiD...</param>
        /// <param name="hWnd">Handle of DNiD's main-window...</param>
        public static void doPeidPluginJob(string dllName, string szFileName, IntPtr hWnd)
        {
            try
            {
                var a = clsNativeDllLoader.load_function<clsNativeDllLoader.DoMyJob>("DoMyJob", dllName);                
                var b = a(hWnd, Marshal.StringToHGlobalAnsi(szFileName), 0, 0);
            }
            catch (Exception ex)
            {
                using (var frm = new intForms.frmError("TargetSite: " + ex.TargetSite.Name + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "InternalHelpLink: " + ex.HelpLink))
                {
                    frm.ShowDialog();
                }
            }
        }
        #region Private Methods:
        private static void AddPeidPlugin(string DllName, string From)
        {
            if (!plugPEiD.ContainsKey(DllName))
            {
                plugPEiD.Add(DllName, From);
            }
        }
        private static string LoadDllInfo(string peidDll)
        {
            try
            {
                var dllHandler = IntPtr.Zero;
                var a = clsNativeDllLoader.load_function<clsNativeDllLoader.LoadDll>("LoadDll", peidDll);
                var b = Marshal.PtrToStringAnsi(a());
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
        #endregion
        #endregion
    }
}
