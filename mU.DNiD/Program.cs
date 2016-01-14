using DNiD2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNiDGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //EmbeddedAssembly.Load("DNiD2.Embedded.ReaperTheme.dll", "ReaperTheme.dll");
            //EmbeddedAssembly.Load("DNiD2.Embedded.dnlib.dll", "dnlib.dll");
            //EmbeddedAssembly.Load("DNiD2.Embedded.mU.MLib.dll", "mU.MLib.dll");
            

            //AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

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
        static HashSet<string> IncludedAssemblies = new HashSet<string>();
        //static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    return EmbeddedAssembly.Get(args.Name);
        //}
    }
}
