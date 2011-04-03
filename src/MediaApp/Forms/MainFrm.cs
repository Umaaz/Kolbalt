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
                RefreshFilmGrids();
            }
        }

        private void btn_Settings_MouseClick(object sender, MouseEventArgs e)
        {
            CMS_Settings.Show(btn_Settings, e.Location);
        }

        #endregion

        #region Film Database controls

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

        private void lv_FilmCast_Click(object sender, EventArgs e)
        {
            var id = lv_FilmCast.SelectedItems[0].SubItems[2].Text.ToString();
            SelectedFilmDetailsPanel.Controls.Clear();
            var fb = new ActorDetails(_nhSession.Get<Person>(new Guid(id)).imdbID) { Visible = true };
            SelectedFilmDetailsPanel.Controls.Add(fb);
            fb.Dock = DockStyle.Fill;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txtb_Search.Clear();
            buildFilm();
        }

        private void RefreshFilmGrids()
        {

            //gets the film table
            var filmsQuery = _nhSession.Query<Film>();
            //need to check if there are any films
            //query film table, for selected actor
            if (ActorList.Items.Count > 0 && ((ListBoxItem)ActorList.SelectedItem).Id != Guid.Empty)
                filmsQuery = filmsQuery.Where(x => x.Cast
                    .Where(y => y.Person.Id == ((ListBoxItem)ActorList.SelectedItem).Id).Any());
            //query film table, for selected director
            if (DirectorList.Items.Count > 0 && ((ListBoxItem)DirectorList.SelectedItem).Id != Guid.Empty)
                filmsQuery = filmsQuery.Where(x => x.Director.Id == ((ListBoxItem)DirectorList.SelectedItem).Id);
            //querey film tabl, for selected genre
            if (GenreList.Items.Count > 0 && ((ListBoxItem)GenreList.SelectedItem).Id != Guid.Empty)
                filmsQuery = filmsQuery.Where(x => x.Genre
                    .Where(y => y.Id == ((ListBoxItem)GenreList.SelectedItem).Id).Any());
            //run query
            var films = filmsQuery.Select(x => new { x.Id, x.Title, Director = x.Director.Name, x.RunTime, x.ReleaseDate })
                .ToList();

            //total films, and run time

            //set dgv data source to queried film table
            DGV_Films.DataSource = films;
            if (DGV_Films != null)
            {
                DGV_Films.Columns["Id"].Visible = false;
            }
            var totalRuntime = TimeSpan.FromMinutes(films.Sum(x => x.RunTime));
            lbl_LibraryDetails.Text = string.Format("{0} films, {1} days {2} hours {3} minutes", films.Count(),
                                                    totalRuntime.Days, totalRuntime.Hours, totalRuntime.Minutes);
        }
        
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
        
        private void btn_showHideFilmDetails_Click(object sender, EventArgs e)
        {
            btn_showHideFilmDetails.Text = Properties.Settings.Default.selectedFilmDetailsShow ? "Hide Details" : "Show Details";
            Properties.Settings.Default.selectedFilmDetailsShow = !Properties.Settings.Default.selectedFilmDetailsShow;
            Properties.Settings.Default.Save();
            SC_LibraryDetails.Panel2Collapsed = Properties.Settings.Default.selectedFilmDetailsShow;
        }

        private void buildFilm()
        {
            btn_showHideFilmDetails.Text = !Properties.Settings.Default.selectedFilmDetailsShow ? "Hide Details" : "Show Details";
            btn_PlaylistShowHide.Text = Properties.Settings.Default.playlistShow ? "<" : ">";


            var actors = _nhSession.Query<Person>()
                .OrderBy(x => x.Name)
                .Select(r => new ListBoxItem(r.Id, r.Name))
                .ToList();

            var filmstolist = _nhSession.Query<Film>();
            IList<ListBoxItem> dir = new List<ListBoxItem>();
            foreach (var film in filmstolist)
            {
                var dirs = film.Director;
                //foreach (var person in dirs)
                //{
                var d = dir.Where(x => x.Text == dirs.Name.ToString()).ToList();
                if (d.Count >= 1) continue;
                dir.Add(new ListBoxItem(dirs.Id, dirs.Name));
                //}
            }
            var directors = dir;

            var genres = _nhSession.Query<FilmType>()
                .OrderBy(r => r.Type)
                .Select(r => new ListBoxItem(r.Id, r.Type))
                .ToList();

            var defaultListOption = new[] { new ListBoxItem(Guid.Empty, "All") };
            ActorList.DataSource = defaultListOption.Union(actors).ToList();
            DirectorList.DataSource = defaultListOption.Union(directors).ToList();
            GenreList.DataSource = defaultListOption.Union(genres).ToList();

            RefreshFilmGrids();
        }

        private void ActorList_Click(object sender, EventArgs e)
        {
            if (ActorList.SelectedItem.ToString().Equals("All"))
            {
                var actors = _nhSession.Query<Person>()
                    .OrderBy(x => x.Name)
                    .Select(r => new ListBoxItem(r.Id, r.Name))
                    .ToList();

                var filmstolist = _nhSession.Query<Film>();
                IList<ListBoxItem> dir = new List<ListBoxItem>();
                foreach (var film in filmstolist)
                {
                    var person = film.Director;
                    //foreach (var person in dirs)
                    //{
                    var d = dir.Where(x => x.Text == person.Name.ToString()).ToList();
                    if (d.Count >= 1) continue;
                    dir.Add(new ListBoxItem(person.Id, person.Name));
                    //}
                }
                var directors = dir;

                var genres = _nhSession.Query<FilmType>()
                    .OrderBy(r => r.Type)
                    .Select(r => new ListBoxItem(r.Id, r.Type))
                    .ToList();

                var defaultListOption = new[] { new ListBoxItem(Guid.Empty, "All") };
                ActorList.DataSource = defaultListOption.Union(actors).ToList();
                DirectorList.DataSource = defaultListOption.Union(directors).ToList();
                GenreList.DataSource = defaultListOption.Union(genres).ToList();
                RefreshFilmGrids();

                return;

            }
            else
            {
                var personName = ActorList.SelectedItem.ToString();
                var filmstolist = _nhSession.Query<Film>()
                    .Where(x => x.Cast.Any(role => role.Person.Name == personName) || x.Director.Name == personName)
                    .ToList();

                var directors = filmstolist
                        .OrderBy(x => x.Director.Name)
                        .Select(x => new ListBoxItem(x.Director.Id, x.Director.Name))
                        .Distinct()
                        .ToList();

                var apearedinfilms =
                    filmstolist.Select(
                        x =>
                        new { x.Id, x.Title, Director = x.Director.Name, x.RunTime, x.ReleaseDate })
                        .ToList();

                var genres = filmstolist
                        .SelectMany(x => x.Genre)
                        .OrderBy(x => x.Type)
                        .Select(x => new ListBoxItem(x.Id, x.Type))
                        .Distinct()
                        .ToList();

                var defaultListOption = new[] { new ListBoxItem(Guid.Empty, "All") };
                DirectorList.DataSource = defaultListOption.Union(directors).ToList();
                GenreList.DataSource = defaultListOption.Union(genres).ToList();
                DGV_Films.DataSource = apearedinfilms;
                var newid = (ListBoxItem)ActorList.SelectedItem;
                var id = newid.Id.ToString();
                SelectedFilmDetailsPanel.Controls.Clear();
                var fb = new ActorDetails(_nhSession.Get<Person>(new Guid(id)).imdbID) { Visible = true };
                SelectedFilmDetailsPanel.Controls.Add(fb);
                fb.Dock = DockStyle.Fill;
                var films = apearedinfilms;
                var totalRuntime = TimeSpan.FromMinutes(films.Sum(x => x.RunTime));
                lbl_LibraryDetails.Text = string.Format("{0} films, {1} days {2} hours {3} minutes", films.Count(),
                                                        totalRuntime.Days, totalRuntime.Hours, totalRuntime.Minutes);
            }
        }

        private void GenreList_Click(object sender, EventArgs e)
        {
            if (GenreList.SelectedItem.ToString().Equals("All"))
            {
                ActorList_Click(sender, e);
                return;
            }
            var genreType = GenreList.SelectedItem.ToString();
            IList<Film> filmstolist = new List<Film>();
            if (ActorList.SelectedItem.ToString().Equals("All"))
            {
                filmstolist = _nhSession.Query<Film>().ToList()
                    .Where(x => x.Genre.Any(ty => ty.Type == genreType))
                    .ToList();
            }
            else
            {
                var personName = ActorList.SelectedItem.ToString();
                filmstolist = _nhSession.Query<Film>()
                    .Where(x => x.Cast.Any(role => role.Person.Name == personName) || x.Director.Name == personName)
                    .Where(y => y.Genre.Any(ty => ty.Type == genreType))
                    .ToList();
            }

            var directors = filmstolist
                .OrderBy(x => x.Director.Name)
                .Select(x => new ListBoxItem(x.Director.Id, x.Director.Name))
                .Distinct()
                .ToList();

            var apearedinfilms =
                filmstolist.Select(
                    x =>
                    new { x.Id, x.Title, Director = x.Director.Name, x.RunTime, x.ReleaseDate })
                    .ToList();

            var defaultListOption = new[] { new ListBoxItem(Guid.Empty, "All") };
            DirectorList.DataSource = defaultListOption.Union(directors).ToList();
            DGV_Films.DataSource = apearedinfilms;
            var films = apearedinfilms;
            var totalRuntime = TimeSpan.FromMinutes(films.Sum(x => x.RunTime));
            lbl_LibraryDetails.Text = string.Format("{0} films, {1} days {2} hours {3} minutes", films.Count(),
                                                    totalRuntime.Days, totalRuntime.Hours, totalRuntime.Minutes);
        }

        private void DirectorList_Click(object sender, EventArgs e)
        {
            if (DirectorList.SelectedItem.ToString().Equals("All"))
            {
                GenreList_Click(sender, e);
                return;
            }
            IList<Film> filmstolist = new List<Film>();
            var personName = ActorList.SelectedItem.ToString();
            var genreType = GenreList.SelectedItem.ToString();
            var directorName = DirectorList.SelectedItem.ToString();
            if (personName != "All" && genreType != "All")
            {
                filmstolist = _nhSession.Query<Film>()
                    .Where(x => x.Cast.Any(role => role.Person.Name == personName) || x.Director.Name == personName)
                    .Where(y => y.Genre.Any(ty => ty.Type == genreType))
                    .Where(z => z.Director.Name == directorName)
                    .ToList();
            }
            else if (personName == "All" && genreType != "All")
            {
                filmstolist = _nhSession.Query<Film>()
                    .Where(y => y.Genre.Any(ty => ty.Type == genreType))
                    .Where(x => x.Director.Name == directorName)
                    .ToList();
            }
            else if (personName != "All" && genreType == "All")
            {
                filmstolist = _nhSession.Query<Film>()
                    .Where(x => x.Cast.Any(role => role.Person.Name == personName) || x.Director.Name == personName)
                    .Where(x => x.Director.Name == directorName)
                    .ToList();
            }
            else
            {
                filmstolist = _nhSession.Query<Film>()
                    .Where(x => x.Director.Name == directorName)
                    .ToList();
            }
            var apearedinfilms =
                filmstolist.Select(
                    x =>
                    new { x.Id, x.Title, Director = x.Director.Name, x.RunTime, x.ReleaseDate })
                    .ToList();
            DGV_Films.DataSource = apearedinfilms;
            var films = apearedinfilms;
            var totalRuntime = TimeSpan.FromMinutes(films.Sum(x => x.RunTime));
            lbl_LibraryDetails.Text = string.Format("{0} films, {1} days {2} hours {3} minutes", films.Count(),
                                                    totalRuntime.Days, totalRuntime.Hours, totalRuntime.Minutes);
            var newid = (ListBoxItem)DirectorList.SelectedItem;
            var id = newid.Id.ToString();
            SelectedFilmDetailsPanel.Controls.Clear();
            var fb = new ActorDetails(_nhSession.Get<Person>(new Guid(id)).imdbID) { Visible = true };
            SelectedFilmDetailsPanel.Controls.Add(fb);
            fb.Dock = DockStyle.Fill;
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

        private void txtb_Search_TextChanged(object sender, EventArgs e)
        {
            DGV_Films.DataSource = Films().Select(
                   x =>
                   new { x.Id, x.Title, Director = x.Director.Name, x.RunTime, x.ReleaseDate })
                   .ToList();
        }

        private IQueryable<Film> Films()
        {
            var query = txtb_Search.Text;
            if (string.IsNullOrWhiteSpace(query))
                return _nhSession.Query<Film>();
            
            var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT,
                new[] { "Title", "Synopsis", "Director" }, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_CURRENT));
            var searchSession = NHibernate.Search.Search.CreateFullTextSession(_nhSession);
            return searchSession.CreateFullTextQuery(parser.Parse(query), new[] { typeof(Film) }).List<Film>().AsQueryable();
        }

        private void btn_AdvSearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}

