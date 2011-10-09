using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Kolbalt.Client.Data;
using Kolbalt.Core.Data;
using MediaApp.Forms.MainForms;

namespace Kolbalt.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            var cnxString = ConfigurationManager.ConnectionStrings["MediaApp.Properties.Settings.MediaConnectionString"].ConnectionString;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NhContext.Bootstrap(appPath,cnxString);
            if(Properties.Settings.Default.FilmDirectories == null)
                Properties.Settings.Default.FilmDirectories = new StringCollection();
            if(Properties.Settings.Default.FilmFileFilter == null)
                Properties.Settings.Default.FilmFileFilter = new StringCollection();
            if(Properties.Settings.Default.FilmFileTypes == null)
                Properties.Settings.Default.FilmFileTypes = new StringCollection();
            Application.Run(new FRM_Main());
        }
    }
}
