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

using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mU.DNiD2.Plugin_Sample
{
    /// <summary>
    /// A quick sample plugin that both works with DNiD & PEiD ;)
    /// </summary>
    public static class clsPlugin
    {
        private const string szPluginName = "Plugin_Sample by mammon";

        /// <summary>
        /// Returns the name of the plugin...
        /// </summary>
        /// <returns></returns>
        [DllExport]
        public static IntPtr LoadDll()
        {
            return Marshal.StringToHGlobalAnsi(szPluginName);
        }
        /// <summary>
        /// Initiates the job the plugin has...
        /// </summary>
        /// <param name="hMainDlg">Window of the DNiD/PEiD...</param>
        /// <param name="szFname">Filename from DNiD/PEiD...</param>
        /// <param name="empty1">Not used!</param>
        /// <param name="empty2">Not used!</param>
        /// <returns></returns>
        [DllExport]
        public static int DoMyJob(IntPtr hMainDlg, IntPtr szFname, int empty1, int empty2)
        {
            //DO SOMETHING....
            var strFileName = Marshal.PtrToStringAnsi(szFname);
            var i = MessageBox(hMainDlg, "Filename present is: " + strFileName, szPluginName, 0);
            return 0;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);
    }
}
