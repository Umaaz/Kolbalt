using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using MediaApp.Data;
using MediaApp.Data.Items;
using MediaApp.Domain.Model;
using NHibernate;
using NHibernate.Linq;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace MediaApp.Forms.UserControls
{
    public partial class FilmLibrary : UserControl
    {
        private static readonly ISession _nhSession = NhContext.GetSession();

        public FilmLibrary()
        {
            InitializeComponent();
            DGV_Films.EnableHeadersVisualStyles = false;
            buildFilm();
        }

        //Build film queryable based on search string todo needs additions to also search cast and genres
        private IQueryable<Film> GetFilms()
        {
            var query = txtb_Search.Text;
            if (string.IsNullOrWhiteSpace(query))
                return _nhSession.Query<Film>();
            var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT,
                new[] { "Title", "Synopsis", "Director", "Cast" }, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_CURRENT));
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
                if (!inc)
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
                if (!inc)
                    gList.Add(listBoxItem);
            }
            return gList;
        }
        //builds director list based on above films
        private IList<ListBoxItem> FillDirector()
        {
            var films = GetFilms();
            var directors = films.SelectMany(film => film.Director).ToList();
            //var directors =
              //  films.OrderBy(o => o.Director.First().Name).Select(d => new ListBoxItem(d.Director.First().Id, d.Director.First().Name)).ToList();
            IList<ListBoxItem> dList = new List<ListBoxItem>();
            foreach (var person in directors)
            {
                var inc = false;
                foreach (var boxItem in dList.Where(boxItem => person.Id == boxItem.Id))
                {
                    inc = true;
                }
                if (!inc)
                    dList.Add(new ListBoxItem(person.Id, person.Name));
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
            DGV_Films.DataSource = GetFilms().OrderBy(x => x.Title).Select(x => new { x.Id, x.Title, x.RunTime, ReleaseDate = x.ReleaseYear })
                .ToList();
            if (DGV_Films != null)
            {
                DGV_Films.Columns["Id"].Visible = false;
            }
        }
        //initiates extra Film details search
        private void DGV_Films_Click(object sender, EventArgs e)
        {
            if (!SC_LibraryDetails.Panel2Collapsed && DGV_Films.SelectedRows.Count > 0)
            {
                var id = DGV_Films.SelectedRows[0].Cells[0].Value.ToString();
                SelectedFilmDetailsPanel.Controls.Clear();
                var fb = new FilmDetails(_nhSession.Get<Film>(new Guid(id)).IMDBId);
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
            lbl_rdate.Text = _nhSession.Get<Film>(new Guid(id)).ReleaseYear;
            lbl_RTimeLabel.Text = _nhSession.Get<Film>(new Guid(id)).RunTime.ToString();
        }
        //initiates extra Actor details ssearch
        private void lv_FilmCast_Click(object sender, EventArgs e)
        {
            var id = lv_FilmCast.SelectedItems[0].SubItems[2].Text.ToString();
            SelectedFilmDetailsPanel.Controls.Clear();
            var fb = new ActorDetails(_nhSession.Get<Person>(new Guid(id)).IMDBID) { Visible = true };
            SelectedFilmDetailsPanel.Controls.Add(fb);
            fb.Dock = DockStyle.Fill;
        }
        //clears search box, calling txtb_Search_TextChanged -- buildFilm()
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txtb_Search.Clear();
            buildFilm();
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
            var item = (ListBoxItem)ActorList.SelectedItem;
            if (item.Id == Guid.Empty)
            {
                buildFilm();
            }
            else
            {
                var films = GetFilms();
                var person = (ListBoxItem)ActorList.SelectedItem;
                var ID = person.Id;
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

                var directors = films.Where(f => f.Cast.Any(r => r.Person.Id == ID)).SelectMany(x => x.Director).OrderBy(o => o.Name).Select(p => new ListBoxItem(p.Id, p.Name)).ToList();
                
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
                DGV_Films.DataSource = GetFilms().Where(f => f.Cast.Any(r => r.Person.Id == ID)).Select(x => new { x.Id, x.Title, x.RunTime, ReleaseDate = x.ReleaseYear })
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
            var item = (ListBoxItem)GenreList.SelectedItem;
            if (item.Id == Guid.Empty)
            {
                ActorList_Click(sender, e);
                return;
            }
            var genreID = item.Id;
            var aItem = (ListBoxItem)ActorList.SelectedItem;
            var films = GetFilms();
            if (aItem.Id == Guid.Empty)
            {
                films = films.Where(f => f.Genre.Any(t => t.Id == genreID));
            }
            else
            {
                films =
                    films.Where(c => c.Cast.Any(r => r.Person.Id == aItem.Id)).Where(
                        g => g.Genre.Any(t => t.Id == genreID));
            }
            
            var directors = films.SelectMany(x => x.Director).OrderBy(o => o.Name).Select(p => new ListBoxItem(p.Id, p.Name)).ToList();
            
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
                films.Select(x => new { x.Id, x.Title, x.RunTime, ReleaseDate = x.ReleaseYear }).ToList();
            if (DGV_Films != null)
                DGV_Films.Columns["Id"].Visible = false;
        }
        //builds film list based on search string and selected actor and/or genre and/or director
        private void DirectorList_Click(object sender, EventArgs e)
        {
            var item = (ListBoxItem)DirectorList.SelectedItem;
            if (item.Id == Guid.Empty)
            {
                GenreList_Click(sender, e);
                return;
            }
            else
            {
                var directorID = item.Id;
                var aItem = (ListBoxItem)ActorList.SelectedItem;
                var gItem = (ListBoxItem)GenreList.SelectedItem;
                var films = GetFilms();
                if (aItem.Id == Guid.Empty && gItem.Id == Guid.Empty)
                {
                    films = films.Where(f => f.Director.Any(d => d.Id == directorID));
                }
                else if (aItem.Id == Guid.Empty && gItem.Id != Guid.Empty)
                {
                    films = films.Where(f => f.Genre.Any(t => t.Id == gItem.Id)).Where(f => f.Director.Any(d => d.Id == directorID));
                }
                else if (aItem.Id != Guid.Empty && gItem.Id == Guid.Empty)
                {
                    films =
                        films.Where(f => f.Cast.Any(r => r.Person.Id == aItem.Id)).Where(
                            f => f.Director.Any(d => d.Id == directorID));
                }
                else if (aItem.Id != Guid.Empty && gItem.Id != Guid.Empty)
                {
                    films =
                        films.Where(f => f.Cast.Any(r => r.Person.Id == aItem.Id)).Where(
                            f => f.Genre.Any(t => t.Id == gItem.Id)).Where(f => f.Director.Any(d => d.Id == directorID));
                }
                DGV_Films.DataSource =
                films.Select(x => new { x.Id, x.Title, x.RunTime, ReleaseDate = x.ReleaseYear }).ToList();
                if (DGV_Films != null)
                    DGV_Films.Columns["Id"].Visible = false;
            }
        }
    }
}
