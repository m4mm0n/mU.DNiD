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
using System.Windows.Forms;

namespace DNiDGUI
{
    using System.Diagnostics;

    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Debug.WriteLine("[Main]");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                using (var form1 = new frmMain(args[0]))
                {
                    Application.Run(form1);
                }
            }
            else
            {
                using (var form1 = new frmMain())
                {
                    Application.Run(form1);
                }
            }
        }
    }
}
