using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using MediaApp.Data;
using MediaApp.Forms.MainForms;

namespace MediaApp
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
            NhContext.Bootstrap();
            if(Properties.Settings.Default.FilmDirectories == null)
                Properties.Settings.Default.FilmDirectories = new StringCollection();
            Application.Run(new FRM_Main());
        }
    }
}
