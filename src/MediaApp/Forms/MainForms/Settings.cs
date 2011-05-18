using System;
using System.Windows.Forms;
using MediaApp.Forms.UserControls.Settings;

namespace MediaApp.Forms.MainForms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            treeView1.SelectedNode = treeView1.TopNode;
        }

        private FilmDatabase _fd;

        private UserControl _cont; 
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _cont = new Default();
            splitContainer1.Panel2.Controls.Clear();
            switch (e.Node.Tag.ToString())
            {
                case "GeneralSettings":
                    break;
                case "ClockSettings":
                    _cont = new ClockSettings();
                    break;
                case "FilmSettings":
                    break;
                case "FilmDatabaseSettings":
                    if(_fd == null)
                        _fd = new FilmDatabase();
                    _cont = _fd;
                    break;
                case"FilmFileSettings":
                    break;
                case "TVSettings":
                    break;
                default:
                    _cont = new Default();
                    treeView1.SelectedNode = treeView1.TopNode;
                    break;
            }
            splitContainer1.Panel2.Controls.Add(_cont);
            _cont.Dock = DockStyle.Fill;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (_fd != null)
                _fd.lbl_Current.Text = "Canceling...";
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(_cont != null)
            {
                if(_cont is FilmDatabase)
                {
                    var cont = (FilmDatabase)_cont;
                    if(!cont.UComplete)
                    {
                        cont.Bgw.CancelAsync();
                        e.Cancel = true;
                        Enabled = false;
                        cont.UClosePending = true;
                    }
                }
            }
            base.OnFormClosing(e);
        }
    }
}
