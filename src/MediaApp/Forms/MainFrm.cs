using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using MediaApp.Data;
using MediaApp.Domain;
using MediaApp.Forms;
using MediaApp.Forms.UserControls;
using NHibernate;
using NHibernate.Linq;
using ListViewItem = System.Windows.Forms.ListViewItem;

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
            VLC_Player.playlist.play();
            VLC_Player.playlist.stop();
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
            DGV_Films.EnableHeadersVisualStyles = false;
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
                    PN_FilmLibrary.Dock = DockStyle.Fill;
                    Properties.Settings.Default.TreeSelectionindex = e.Node.Text;
                    Properties.Settings.Default.Save();
                    PN_TVLibrary.Visible = false;
                    PN_FilmLibrary.Visible = true;
                    buildFilm();
                    break;
                case "Tv":
                    PN_FilmLibrary.Visible = false;
                    Properties.Settings.Default.TreeSelectionindex = e.Node.Text;
                    Properties.Settings.Default.Save();
                    PN_FilmLibrary.Visible = false;
                    PN_TVLibrary.Visible = true;
                    PN_TVLibrary.Dock = DockStyle.Fill;
                    break;
                case "Local Media":
                    PN_FilmLibrary.Visible = false;
                    Properties.Settings.Default.TreeSelectionindex = e.Node.Text;
                    Properties.Settings.Default.Save();
                    break;
                case "Playlists":
                    PN_FilmLibrary.Visible = false;
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
                buildFilm();
            }
        }

        private void btn_Settings_MouseClick(object sender, MouseEventArgs e)
        {
            CMS_Settings.Show(btn_Settings, e.Location);
        }

        #endregion

        #region Film Database controls

        //Build film queryable based on search string todo needs additions to also search cast and genres
        private IQueryable<Film> GetFilms()
        {
            var query = txtb_Search.Text;
            if (string.IsNullOrWhiteSpace(query))
                return _nhSession.Query<Film>();

            var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT,
                new[] { "Title", "Synopsis", "Director" }, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_CURRENT));
            var searchSession = NHibernate.Search.Search.CreateFullTextSession(_nhSession);
            return searchSession.CreateFullTextQuery(parser.Parse(query), new[] { typeof(Film) }).List<Film>().AsQueryable();
        }
        //builds actor list based on above films
        private IList<ListBoxItem> FillActors()
        {
            var films = GetFilms();
            var actors =
                films.SelectMany(f => f.Cast).OrderBy(o => o.Person.Name).Select(
                    p => new ListBoxItem(p.Person.Id, p.Person.Name)).ToList();
            IList<ListBoxItem> aList = new List<ListBoxItem>();
            foreach (var listBoxItem in actors)
            {
                var inc = false;
                foreach (var boxItem in aList.Where(boxItem => listBoxItem.Id == boxItem.Id))
                {
                    inc = true;
                }
                if(!inc)
                    aList.Add(listBoxItem);
            }
            return aList;
        }
        //builds genre list based on above films
        private IList<ListBoxItem> FillGenres()
        {
            var films = GetFilms();
            var genres =
                films.SelectMany(f => f.Genre).OrderBy(o => o.Type).Select(g => new ListBoxItem(g.Id, g.Type)).ToList();
            IList<ListBoxItem> gList = new List<ListBoxItem>();
            foreach (var listBoxItem in genres)
            {
                var inc = false;
                foreach (var boxItem in gList.Where(boxItem => listBoxItem.Id == boxItem.Id))
                {
                    inc = true;
                }
                if(!inc)
                    gList.Add(listBoxItem);
            }
            return gList;
        }
        //builds director list based on above films
        private IList<ListBoxItem> FillDirector()
        {
            var films = GetFilms();
            var directors =
                films.OrderBy(o => o.Director.Name).Select(d => new ListBoxItem(d.Director.Id, d.Director.Name)).ToList();
            IList<ListBoxItem> dList = new List<ListBoxItem>();
            foreach (var listBoxItem in directors)
            {
                var inc = false;
                foreach (var boxItem in dList.Where(boxItem => listBoxItem.Id == boxItem.Id))
                {
                    inc = true;
                }
                if(!inc)
                    dList.Add(listBoxItem);
            }
            return dList;
        }
        //calls build film on search string change
        private void txtb_Search_TextChanged(object sender, EventArgs e)
        {
            buildFilm();
        }
        //populates Actor, Genre, Director list boxes, and sets DataSource for GridView (called upon entering film library view)
        private void buildFilm()
        {
            var defaultListBoxItem = new[] { new ListBoxItem(Guid.Empty, "All") };
            ActorList.DataSource = defaultListBoxItem.Union(FillActors()).ToList();
            GenreList.DataSource = defaultListBoxItem.Union(FillGenres()).ToList();
            DirectorList.DataSource = defaultListBoxItem.Union(FillDirector()).ToList();
            DGV_Films.DataSource = GetFilms().Select(x => new { x.Id, x.Title, Director = x.Director.Name, x.RunTime, x.ReleaseDate })
                .ToList();
            if (DGV_Films != null)
            {
                DGV_Films.Columns["Id"].Visible = false;
            }
        }
        //initiates extra Film details search
        private void DGV_Films_Click(object sender, EventArgs e)
        {
            if (!SC_LibraryDetails.Panel2Collapsed)
            {
                var id = DGV_Films.SelectedRows[0].Cells[0].Value.ToString();
                SelectedFilmDetailsPanel.Controls.Clear();
                var fb = new FilmDetails(_nhSession.Get<Film>(new Guid(id)).ImdbId);
                fb.Visible = true;
                SelectedFilmDetailsPanel.Controls.Add(fb);
                fb.Dock = DockStyle.Fill;
            }
        }
        //populates cast list of selected film, fills runtime/releaseDate labels
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV_Films.SelectedRows.Count <= 0) return;
            var id = DGV_Films.SelectedRows[0].Cells[0].Value.ToString();
            txtb_Synopsis.Text = _nhSession.Get<Film>(new Guid(id)).Synopsis;
            lv_FilmCast.Items.Clear();
            var cast = _nhSession.Get<Film>(new Guid(id)).Cast;
            foreach (Role role in cast)
            {
                String[] item = { role.Person.Name, role.Character, role.Person.Id.ToString() };
                lv_FilmCast.Items.Add(new ListViewItem(item));
            }
            lbl_rdate.Text = _nhSession.Get<Film>(new Guid(id)).ReleaseDate.ToShortDateString();
            lbl_RTimeLabel.Text = _nhSession.Get<Film>(new Guid(id)).RunTime.ToString();
        }
        //initiates extra Actor details ssearch
        private void lv_FilmCast_Click(object sender, EventArgs e)
        {
            var id = lv_FilmCast.SelectedItems[0].SubItems[2].Text.ToString();
            SelectedFilmDetailsPanel.Controls.Clear();
            var fb = new ActorDetails(_nhSession.Get<Person>(new Guid(id)).imdbID) { Visible = true };
            SelectedFilmDetailsPanel.Controls.Add(fb);
            fb.Dock = DockStyle.Fill;
        }
        //clears search box, calling txtb_Search_TextChanged -- buildFilm()
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txtb_Search.Clear();
        }
        //show or hides the extra film details, saving settings to selectedFilmDetailsShow
        private void btn_showHideFilmDetails_Click(object sender, EventArgs e)
        {
            btn_showHideFilmDetails.Text = Properties.Settings.Default.selectedFilmDetailsShow ? "Hide Details" : "Show Details";
            Properties.Settings.Default.selectedFilmDetailsShow = !Properties.Settings.Default.selectedFilmDetailsShow;
            Properties.Settings.Default.Save();
            SC_LibraryDetails.Panel2Collapsed = Properties.Settings.Default.selectedFilmDetailsShow;
        }
        //builds film list based on search string and selected actor
        private void ActorList_Click(object sender, EventArgs e)
        {
            var item = (ListBoxItem) ActorList.SelectedItem;
            if(item.Id == Guid.Empty)
            {
                buildFilm();
            }
            else
            {
                var films = GetFilms();
                
                var ff = films.ToList();
                var person = (ListBoxItem) ActorList.SelectedItem;
                var ID = person.Id;
                var gf = GetFilms().Where(f => f.Cast.Any(r => r.Person.Id == ID)).ToList();
                var genres =
                    films.Where(f => f.Cast.Any(r => r.Person.Id == ID)).SelectMany(f => f.Genre).OrderBy(o => o.Type).Select(
                        g => new ListBoxItem(g.Id, g.Type)).ToList();
                IList<ListBoxItem> gList = new List<ListBoxItem>();
                foreach (var listBoxItem in genres)
                {
                    var inc = false;
                    foreach (var boxItem in gList.Where(boxItem => listBoxItem.Id == boxItem.Id))
                    {
                        inc = true;
                    }
                    if (!inc)
                        gList.Add(listBoxItem);
                }
                var defaultListBoxItem = new[] { new ListBoxItem(Guid.Empty, "All") };
                GenreList.DataSource = defaultListBoxItem.Union(gList).ToList();

                var directors =
                    films.Where(f => f.Cast.Any(r => r.Person.Id == ID)).OrderBy(o => o.Director.Name).Select(
                        d => new ListBoxItem(d.Director.Id, d.Director.Name)).ToList();
                IList<ListBoxItem> dList = new List<ListBoxItem>();
                foreach (var listBoxItem in directors)
                {
                    var inc = false;
                    foreach (var boxItem in dList.Where(boxItem => listBoxItem.Id == boxItem.Id))
                    {
                        inc = true;
                    }
                    if (!inc)
                        dList.Add(listBoxItem);
                }
                DirectorList.DataSource = defaultListBoxItem.Union(dList).ToList();
                DGV_Films.DataSource = GetFilms().Where(f => f.Cast.Any(r => r.Person.Id == ID)).Select(x => new { x.Id, x.Title, Director = x.Director.Name, x.RunTime, x.ReleaseDate })
                .ToList();
                if (DGV_Films != null)
                {
                    DGV_Films.Columns["Id"].Visible = false;
                }
            }
        }
        //builds film list based on search string and selected actor and/or genre
        private void GenreList_Click(object sender, EventArgs e)
        {
            var item = (ListBoxItem) GenreList.SelectedItem;
            if(item.Id == Guid.Empty)
            {
                ActorList_Click(sender, e);
                return;
            }
            var genreID = item.Id;
            var aItem = (ListBoxItem) ActorList.SelectedItem;
            var films = GetFilms();
            if(aItem.Id == Guid.Empty)
            {
                films = films.Where(f => f.Genre.Any(t => t.Id == genreID));
            }
            else
            {
                films =
                    films.Where(c => c.Cast.Any(r => r.Person.Id == aItem.Id)).Where(
                        g => g.Genre.Any(t => t.Id == genreID));
            }
            var directors =
                films.OrderBy(o => o.Director.Name).Select(d => new ListBoxItem(d.Director.Id, d.Director.Name)).
                    ToList();
            IList<ListBoxItem> dList = new List<ListBoxItem>();
            foreach (var listBoxItem in directors)
            {
                var inc = false;
                foreach (var boxItem in dList.Where(boxItem => listBoxItem.Id == boxItem.Id))
                {
                    inc = true;
                }
                if (!inc)
                    dList.Add(listBoxItem);
            }
            var defaultListBoxItem = new[] { new ListBoxItem(Guid.Empty, "All") };
            DirectorList.DataSource = defaultListBoxItem.Union(dList).ToList();
            DGV_Films.DataSource =
                films.Select(x => new {x.Id, x.Title, Director = x.Director.Name, x.RunTime, x.ReleaseDate}).ToList();
            if (DGV_Films != null)
                DGV_Films.Columns["Id"].Visible = false;
        }
        //builds film list based on search string and selected actor and/or genre and/or director
        private void DirectorList_Click(object sender, EventArgs e)
        {
            var item = (ListBoxItem) DirectorList.SelectedItem;
            if(item.Id == Guid.Empty)
            {
                GenreList_Click(sender, e);
                return;
            }
            else
            {
                var directorID = item.Id;
                var aItem = (ListBoxItem) ActorList.SelectedItem;
                var gItem = (ListBoxItem) GenreList.SelectedItem;
                var films = GetFilms();
                if(aItem.Id == Guid.Empty && gItem.Id == Guid.Empty)
                {
                    films = films.Where(f => f.Director.Id == directorID);
                }
                else if(aItem.Id == Guid.Empty && gItem.Id != Guid.Empty)
                {
                    films = films.Where(f => f.Genre.Any(t => t.Id == gItem.Id)).Where(f => f.Director.Id == directorID);
                }
                else if(aItem.Id != Guid.Empty && gItem.Id == Guid.Empty)
                {
                    films =
                        films.Where(f => f.Cast.Any(r => r.Person.Id == aItem.Id)).Where(
                            f => f.Director.Id == directorID);
                }
                else if(aItem.Id != Guid.Empty && gItem.Id != Guid.Empty)
                {
                    films =
                        films.Where(f => f.Cast.Any(r => r.Person.Id == aItem.Id)).Where(
                            f => f.Genre.Any(t => t.Id == gItem.Id)).Where(f => f.Director.Id == directorID);
                }
                DGV_Films.DataSource =
                films.Select(x => new { x.Id, x.Title, Director = x.Director.Name, x.RunTime, x.ReleaseDate }).ToList();
                if (DGV_Films != null)
                    DGV_Films.Columns["Id"].Visible = false;
            }
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

        private void DGV_Films_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        #region Player controls
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!VLC_Player.playlist.isPlaying) return;
            var time = TimeSpan.FromMilliseconds(VLC_Player.input.Time);
            String hour = time.Hours.ToString();
            String min = time.Minutes.ToString();
            String sec = time.Seconds.ToString();
            if (time.Seconds <= 9)
                sec = "0" + time.Seconds;
            if (time.Minutes <= 9)
                min = "0" + time.Minutes;
            if (time.Hours <= 9)
                hour = "0" + time.Hours;
            lbl_CurrentPosition.Text = string.Format("{0}:{1}:{2}", hour, min, sec);
            time = TimeSpan.FromMilliseconds(VLC_Player.input.Length);
            hour = time.Hours.ToString();
            min = time.Minutes.ToString();
            sec = time.Seconds.ToString();
            if (time.Seconds <= 9)
                sec = "0" + time.Seconds;
            if (time.Minutes <= 9)
                min = "0" + time.Minutes;
            if (time.Hours <= 9)
                hour = "0" + time.Hours;
            lbl_runtime.Text = string.Format("{0}:{1}:{2}", hour, min, sec);
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
            _rate = VLC_Player.input.rate = _rate*2;
        }

        private void btn_Rewind_Click(object sender, EventArgs e)
        {
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
                    Thread.Sleep(100);
                    _player.slider1.Maximum = VLC_Player.input.Length;
                    _player.slider1.ValueChanged += (slider1_ValueChanged);
                    timer1.Enabled = true;
                    btn_PlayPause.Image = Properties.Resources.Pause;
                    break;
            }
        }

        void slider1_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            VLC_Player.input.Time = _player.slider1.Value;
        }
        #endregion

        private void btn_RndFilm_Click(object sender, EventArgs e)
        {
            var list = VLC_Player.playlist.items;
            var fs = new FullScreanVideo(@"M:\Tv\Dilbert\Season 1\Episode 01 - The Name.avi",(int)VLC_Player.input.Time, _rate, _playlistIndex);
            VLC_Player.playlist.togglePause();
            timer1.Enabled = false;
            this.Hide();
            if(fs.ShowDialog() == DialogResult.OK)
            {
                fs.Hide();
                var t = fs.Time;
                VLC_Player.playlist.togglePause();
                VLC_Player.input.Time = fs.axVLCPlugin21.input.Time;
                this.Show();
            }
            fs.Dispose();
        }

        private void btn_AdvSearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}

