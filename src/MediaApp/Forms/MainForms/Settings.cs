using System;
using System.Windows.Forms;

namespace MediaApp.Forms.MainForms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            treeView1.SelectedNode = treeView1.TopNode;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UserControl cont = new UserControls.Settings.Default();
            splitContainer1.Panel2.Controls.Clear();
            switch (e.Node.Tag.ToString())
            {
                case "GeneralSettings":
                    break;
                case "ClockSettings":
                    cont = new UserControls.Settings.ClockSettings();
                    break;
                case "FilmSettings":
                    break;
                case "FilmDatabaseSettings":
                    cont = new UserControls.Settings.FilmDatabase();
                    break;
                case"FilmFileSettings":
                    break;
                case "TVSettings":
                    break;
                default:
                    cont = new UserControls.Settings.Default();
                    treeView1.SelectedNode = treeView1.TopNode;
                    break;
            }
            splitContainer1.Panel2.Controls.Add(cont);
            cont.Dock = DockStyle.Fill;
        }
    }
}
