/*
    DNiD 2 - PE Identifier.
    Copyright (C) 2018  mammon

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
using System.Runtime.InteropServices;

namespace DNiD2.intClasses
{
    static class clsNativeDllLoader
    {
        static Logger log = new Logger(LoggerType.Console_File, "DNiD2.clsNativeDllLoader");

        #region Native Calls
        [DllImport("kernel32.dll")]
        internal static extern IntPtr LoadLibrary(string dllname);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string procname);
        [DllImport("kernel32.dll")]
        internal static extern bool FreeLibrary(IntPtr hModule);
        #endregion
        #region Delegates:
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr LoadDll();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        public delegate int DoMyJob(IntPtr hMainDlg, IntPtr szFname, int empty1, int empty2);
        #endregion

        public static T load_function<T>(string name, string m_dll) where T : class
        {
            log.Log(LogType.Normal, "load_function");

            var address = GetProcAddress(LoadLibrary(m_dll), name);
            var fn_ptr = Marshal.GetDelegateForFunctionPointer((IntPtr)address, typeof(T));
            return fn_ptr as T;
        }
    }
}
