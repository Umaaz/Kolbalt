using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaApp.Data;
using MediaApp.Domain;
using MediaApp.Forms;
using MediaApp.Forms.UserControls;
using NHibernate;

namespace MediaApp
{
    public partial class FRM_Main : Form
    {
        private static readonly ISession _nhSession = NhContext.GetSession();
        private Slider _player = new Slider();
        private Volume _volume = new Volume();
        private IList<Film> _playlist = new List<Film>();
        public int _playlistIndex = 0;
        private double _rate = 1.0;

        public FRM_Main()
        {
            InitializeComponent();
            VLC_Player.playlist.add(@"M:\Tv\Dilbert\Season 1\Episode 01 - The Name.avi");
            VLC_Player.playlist.add(@"M:\Tv\Dilbert\Season 1\Episode 02 - The Competition.avi");
            VLC_Player.playlist.add(@"M:\Tv\Dilbert\Season 1\Episode 03 - The Prototype.avi");
            _volume.slider1.ValueChanged +=volumeslider1_ValueChanged;
        }

        protected override void Dispose(bool disposing)
        {
            //there might be a better way of doing this, but its not important now
            _nhSession.Dispose();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            _player.slider1.IsMoveToPointEnabled = true;
            elementHost2.Child = _volume;
            elementHost1.Child = _player;
            
            switch(Properties.Settings.Default.TreeSelectionindex)
            {
                case "Film":
                    TV_Library.TopNode.Expand();
                    TV_Library.Select();
                    TV_Library.SelectedNode = TV_Library.Nodes[0].Nodes[0];
                    break;
                case "Tv":
                    TV_Library.TopNode.Expand();
                    TV_Library.Select();
                    TV_Library.SelectedNode = TV_Library.Nodes[0].Nodes[1];
                    break;
                case "Local Media":
                    TV_Library.Select();
                    TV_Library.SelectedNode = TV_Library.Nodes[0];
                    break;
                case "Playlists":
                    TV_Library.Select();
                    TV_Library.SelectedNode = TV_Library.Nodes[1];
                    break;
                default: 
                    TV_Library.Select();
                    TV_Library.SelectedNode = TV_Library.Nodes[0];
                    break;
            }
            if (!TV_Library.Nodes[0].IsExpanded)
            {
                TV_Library.Nodes[0].ImageIndex = 4;
                TV_Library.Nodes[0].SelectedImageIndex = 4;
            }
            else
            {
                TV_Library.Nodes[0].ImageIndex = 3;
                TV_Library.Nodes[0].SelectedImageIndex = 3;
            }
        }
        //Global application controls
        private void btn_PlaylistShowHide_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.playlistShow = !Properties.Settings.Default.playlistShow;
            SC_MainPlaylist.Panel2Collapsed = Properties.Settings.Default.playlistShow;
            Properties.Settings.Default.Save();
            btn_PlaylistShowHide.Text = Properties.Settings.Default.playlistShow ? "<" : ">";
        }

        private void TV_Library_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Film":
                    Properties.Settings.Default.TreeSelectionindex = e.Node.Text;
                    Properties.Settings.Default.Save();
                    var fl = new FilmLibrary();
                    SC_LibraryNavLibrary.Panel2.Controls.Clear();
                    SC_LibraryNavLibrary.Panel2.Controls.Add(fl);
                    fl.Dock = DockStyle.Fill;
                    break;
                case "Tv":

                    Properties.Settings.Default.TreeSelectionindex = e.Node.Text;
                    Properties.Settings.Default.Save();
                    PN_TVLibrary.Visible = true;
                    PN_TVLibrary.Dock = DockStyle.Fill;
                    break;
                case "Local Media":

                    Properties.Settings.Default.TreeSelectionindex = e.Node.Text;
                    Properties.Settings.Default.Save();
                    break;
                case "Playlists":

                    Properties.Settings.Default.TreeSelectionindex = e.Node.Text;
                    Properties.Settings.Default.Save();
                    break;
            }
        }

        private void TV_Library_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.X < 20 && e.Y < 15)
                if (e.Node.IsExpanded)
                {
                    e.Node.ImageIndex = 4;
                    e.Node.SelectedImageIndex = 4;
                    e.Node.Collapse();
                }
                else
                {
                    e.Node.ImageIndex = 3;
                    e.Node.SelectedImageIndex = 3;
                    e.Node.Expand();
                }
        }
        
        #region Settings
        
        private void creatDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var DBC = new DbCreate();
            if (DBC.ShowDialog() == DialogResult.OK)
            {
                var fl = new FilmLibrary();
                SC_LibraryNavLibrary.Panel2.Controls.Clear();
                SC_LibraryNavLibrary.Panel2.Controls.Add(fl);
                fl.Dock = DockStyle.Fill;
            }
        }

        private void btn_Settings_MouseClick(object sender, MouseEventArgs e)
        {
            CMS_Settings.Show(btn_Settings, e.Location);
        }

        #endregion

        #region TV Database Controls



        #endregion
        
        #region time and alarm

        private void btn_SetTime_Click(object sender, EventArgs e)
        {
            var ts = new ClkSettings();
            ts.Show();
        }

        #endregion

        #region Player controls
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!VLC_Player.playlist.isPlaying) return;
            var time = TimeSpan.FromMilliseconds(VLC_Player.input.Time);
            lbl_CurrentPosition.Text = (DateTime.Today + time).ToString("HH:mm:ss");
            time = TimeSpan.FromMilliseconds(VLC_Player.input.Length);
            lbl_runtime.Text = time.ToString("c");
            if (!_player.slider1.IsMouseOver)
            {
                _player.slider1.Maximum = VLC_Player.input.Length;
                _player.slider1.Value = VLC_Player.input.Time;
            }
            VLC_Player.audio.Volume = (int)_volume.slider1.Value;
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            VLC_Player.playlist.stop();
            btn_PlayPause.Image = Properties.Resources.Play1;
            lbl_runtime.Text = "00:00:00";
            lbl_CurrentPosition.Text = "00:00:00";
        }

        private void btn_FF_Click(object sender, EventArgs e)
        {
            //rate 1.0 normal 0.5 half speed 2.0 double speed
            if(VLC_Player.playlist.isPlaying)
                _rate = VLC_Player.input.rate = _rate*2;
        }

        private void btn_Rewind_Click(object sender, EventArgs e)
        {
            if (VLC_Player.playlist.isPlaying)
                _rate = VLC_Player.input.rate = _rate/2;
        }

        private void btn_nextTrack_Click(object sender, EventArgs e)
        {

            VLC_Player.playlist.next();
            _playlistIndex++;
        }

        private void btn_PreviousTrack_Click(object sender, EventArgs e)
        {
            VLC_Player.playlist.prev();
            _playlistIndex--;
        }

        private void btn_PlayPause_Click(object sender, EventArgs e)
        {
            if (VLC_Player.playlist.itemCount <= 0) return;
            VLC_Player.playlist.play();
            VLC_Player.playlist.stop();
            switch (VLC_Player.input.state)
            {
                case 4://paused
                    VLC_Player.playlist.togglePause();
                    btn_PlayPause.Image = Properties.Resources.Pause;
                    break;
                case 3://playing
                    VLC_Player.playlist.togglePause();
                    btn_PlayPause.Image = Properties.Resources.Play1;
                    break;
                case 5://stopped
                case 0://idle
                    VLC_Player.playlist.play();
                    _player.slider1.Maximum = VLC_Player.input.Length;
                    _player.slider1.ValueChanged += (slider1_ValueChanged);
                    timer1.Enabled = true;
                    btn_PlayPause.Image = Properties.Resources.Pause;
                    break;
            }
        }
        void volumeslider1_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            VLC_Player.audio.Volume = (int)_volume.slider1.Value;
        }

        void slider1_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if(_player.slider1.IsMouseOver)
                VLC_Player.input.Time = _player.slider1.Value;
        }
        #endregion

        private void btn_RndFilm_Click(object sender, EventArgs e)
        {
            var list = VLC_Player.playlist.items;
            var fs = new FullScreanVideo(@"M:\Tv\Dilbert\Season 1\Episode 01 - The Name.avi",(int)VLC_Player.input.Time, _rate, _playlistIndex,VLC_Player.audio.Volume);
            VLC_Player.playlist.togglePause();
            timer1.Enabled = false;
            this.Hide();
            fs.BringToFront();
            var results = fs.ShowDialog();
            if(results == DialogResult.OK)
            {
                fs.Hide();
                var t = fs.Time;
                VLC_Player.playlist.togglePause();
                VLC_Player.input.Time = fs.axVLCPlugin21.input.Time;
                _volume.slider1.Value = fs.axVLCPlugin21.audio.Volume;
                this.Show();
            }
            else if(results == DialogResult.Cancel)
            {
                fs.Hide();
                btn_Stop_Click(sender, e);
                this.BringToFront();
                this.Show();
            }
           
            fs.Dispose();
        }

    }
}

