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

        /// <summary>
        /// The complete plugins list that is present...
        /// </summary>
        public static Dictionary<string, string> plugins = new Dictionary<string, string>();

        #region Plugins Support Methods:
        /// <summary>
        /// Initiates the plugins if they are present in
        /// %DNiD2_Directory%\plugins\...
        /// </summary>
        public static void InitPlugins()
        {
            var a = Directory.GetFiles(Environment.CurrentDirectory + @"\plugins\");
            foreach(var b in a)
            {
                if (b.EndsWith(".dll"))
                {
                    var c = LoadDllInfo(b);
                    if (c.Length > 0) AddPlugin(c, b);
                }
            }
        }
        /// <summary>
        /// Initiates the external PEiD plugin...
        /// </summary>
        /// <param name="dllName">Full Path of Plugin...</param>
        /// <param name="szFileName">Filename that is present in DNiD...</param>
        /// <param name="hWnd">Handle of DNiD's main-window...</param>
        public static void doPluginJob(string dllName, string szFileName, IntPtr hWnd)
        {
            try
            {
                var a = clsNativeDllLoader.load_function<clsNativeDllLoader.DoMyJob>("DoMyJob", dllName);                
                var b = a(hWnd, Marshal.StringToHGlobalAnsi(szFileName), 0, 0);
            }
            catch (Exception ex)
            {
                using (var frm = new intForms.frmError("[doPluginJob]" + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "InternalHelpLink: " + ex.HelpLink))
                {
                    frm.ShowDialog();
                }
            }
        }
        #region Private Methods:
        private static void AddPlugin(string DllName, string From)
        {
            if (!plugins.ContainsKey(DllName))
            {
                plugins.Add(DllName, From);
            }
        }
        private static string LoadDllInfo(string pluginDll)
        {
            try
            {
                var a = clsNativeDllLoader.load_function<clsNativeDllLoader.LoadDll>("LoadDll", pluginDll);
                var b = Marshal.PtrToStringAnsi(a());
                return b;
            }
            catch (Exception ex)
            {
                using (var frm = new intForms.frmError("[LoadDllInfo]" + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "InternalHelpLink: " + ex.HelpLink))
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
