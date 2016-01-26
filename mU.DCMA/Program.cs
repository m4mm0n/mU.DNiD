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

namespace mU.DCMA
{
    using Microsoft.Win32;


    /// <summary>
    /// Just a small console-app to set DNiD2 to the Windows Explorer's Context Menu...
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (Registry.ClassesRoot.CreateSubKey("*\\shell\\Scan with DNiD 2") != null)
            {
                var cmd = Registry.ClassesRoot.CreateSubKey("*\\shell\\Scan with DNiD 2\\command");
                if (cmd != null)
                {
                    cmd.SetValue("", Environment.CurrentDirectory + "\\DNiD2.exe %1");
                    Console.WriteLine("All done!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Something went wrong.... :/");
                    Console.ReadKey();
                }
            }
        }
    }
}
