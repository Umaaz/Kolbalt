using System;
using System.Windows.Forms;

namespace MediaApp.Forms.MainForms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UserControl cont = null;
            switch (e.Node.Tag.ToString())
            {
                case "FilmSettings":
                    break;
                case "FilmDatabaseSettings":
                    cont = new UserControls.Settings.FilmDatabase();
                    splitContainer1.Panel2.Controls.Add(cont);
                    cont.Dock = DockStyle.Fill;
                    break;
                case"FilmFileSettings":
                    break;
                case "TVSettings":
                    break;
                default:
                    return;
            }
        }
    }
}
