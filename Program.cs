#region About
/*
 <fileinfo>
	<file name="Program.cs"></file>
	<namespace name="XMLAssignment1">
	<class name="Program">
	<revisions>
		<created date="10/15/2015" author="Garima Sharma">Runs the application</created>
		<changed date="" author=""></changed>
	</revisions>
	</class>
	</namespace>
 </fileinfo>
*/
#endregion About

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLAssignment1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LearnXPath());
        }
    }
}
