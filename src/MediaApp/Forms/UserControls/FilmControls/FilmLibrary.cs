using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Kolbalt.Client.Data;
using Kolbalt.Client.Data.Items;
using Kolbalt.Client.Domain.Model;
using Kolbalt.Core.Data;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using MediaApp.Data;
using NHibernate;
using NHibernate.Linq;

namespace MediaApp.Forms.UserControls.FilmControls
{
    public partial class FilmLibrary : UserControl
    {
        private static readonly ISession _nhSession = NhContext.GetSession();

        private IQueryable<Film> _films;

        public FilmLibrary()
        {
            InitializeComponent();
            DGV_Films.EnableHeadersVisualStyles = false;
            buildFilm();
        }

        //Build film queryable based on search string todo needs additions to also search cast and genres
        private void GetFilms()
        {
            var pattern = new string[Properties.Settings.Default.Searchpattern.Count];
                Properties.Settings.Default.Searchpattern.CopyTo(pattern, 0);
            var query = txtb_Search.Text.Trim();
            if (string.IsNullOrWhiteSpace(query) || !char.IsLetterOrDigit(query[0]) || !char.IsLetterOrDigit(query[query.Length - 1]))
            {
                _films = _nhSession.Query<Film>();
                return;
            }
            var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, pattern, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
            var searchSession = NHibernate.Search.Search.CreateFullTextSession(_nhSession);
            _films = searchSession.CreateFullTextQuery(parser.Parse(query + "*"), new[] { typeof(Film) }).List<Film>().AsQueryable();
        }

        //builds actor list based on above films
        private IList<ListBoxItem> FillActors()
        {
            var actors =
                _films.SelectMany(f => f.Cast).OrderBy(o => o.Person.Name).Select(
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
            var genres =
                _films.SelectMany(f => f.Genre).OrderBy(o => o.Type).Select(g => new ListBoxItem(g.Id, g.Type)).ToList();
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
            var directors = _films.SelectMany(film => film.Director).ToList();
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
            timer1.Stop();
            timer1.Interval = 500;
            timer1.Enabled = true;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            buildFilm();
            timer1.Enabled = false;
        }
        //populates Actor, Genre, Director list boxes, and sets DataSource for GridView (called upon entering film library view)
        private void buildFilm()
        {
            GetFilms();
            var defaultListBoxItem = new[] { new ListBoxItem(Guid.Empty, "All") };
            ActorList.DataSource = defaultListBoxItem.Union(FillActors()).ToList();
            GenreList.DataSource = defaultListBoxItem.Union(FillGenres()).ToList();
            DirectorList.DataSource = defaultListBoxItem.Union(FillDirector()).ToList();
            DGV_Films.DataSource = _films.OrderBy(x => x.Title).Select(x => new { x.Id, x.Title, x.RunTime, x.ReleaseYear, x.Synopsis })
                .ToList();
            if (DGV_Films != null)
            {
                DGV_Films.Columns["Id"].Visible = false;
                DGV_Films.Columns["Synopsis"].Visible = false;
            }
            if (DGV_Films.Rows.Count == 0)
                return;
            FillLabel(_films.Count(), _films.Sum(x => x.RunTime));
        }
        //initiates extra Film details search
        private void DGV_Films_Click(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.selectedFilmDetailsShow && DGV_Films.SelectedRows.Count > 0)
            {
                var id = DGV_Films.SelectedRows[0].Cells[0].Value.ToString();
                SelectedFilmDetailsPanel.Controls.Clear();
                var fb = new FilmDetails(_nhSession.Get<Film>(new Guid(id)));
                fb.Visible = true;
                SelectedFilmDetailsPanel.Controls.Add(fb);
                fb.Dock = DockStyle.Fill;
            }
        }
        //populates cast list of selected film, fills runtime/releaseDate labels
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV_Films.SelectedRows.Count <= 0) return;
            txtb_Synopsis.Text = DGV_Films.SelectedRows[0].Cells[4].Value.ToString();
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
            var actor = (ListBoxItem)ActorList.SelectedItem;
            if(!Properties.Settings.Default.selectedFilmDetailsShow && actor.Text != "All")
            {
                var a = _nhSession.Get<Person>(new Guid(actor.Id.ToString()));
                var ad = new ActorDetails(a.IMDBID);
                SelectedFilmDetailsPanel.Controls.Clear();
                SelectedFilmDetailsPanel.Controls.Add(ad);
                ad.Visible = true;
                ad.Dock = DockStyle.Fill;
            }
            else if(Properties.Settings.Default.selectedFilmDetailsShow && ActorList.SelectedItem.ToString() == "All")
            {
                
            }
            var item = (ListBoxItem)ActorList.SelectedItem;
            if (item.Id == Guid.Empty)
            {
                buildFilm();
            }
            else
            {
                var person = (ListBoxItem)ActorList.SelectedItem;
                var ID = person.Id;
                var genres =
                    _films.Where(f => f.Cast.Any(r => r.Person.Id == ID)).SelectMany(f => f.Genre).OrderBy(o => o.Type).Select(
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

                var directors = _films.Where(f => f.Cast.Any(r => r.Person.Id == ID)).SelectMany(x => x.Director).OrderBy(o => o.Name).Select(p => new ListBoxItem(p.Id, p.Name)).ToList();
                
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
                DGV_Films.DataSource = _films.Where(f => f.Cast.Any(r => r.Person.Id == ID)).OrderBy(x => x.Title).Select(x => new { x.Id, x.Title, x.RunTime, x.ReleaseYear, x.Synopsis })
                .ToList();
                if (DGV_Films != null)
                {
                    DGV_Films.Columns["Id"].Visible = false;
                }
                var numFIlms = _films.Where(x => x.Cast.Any(r => r.Person.Id == ID)).Count();
                var sumMins = _films.Where(x => x.Cast.Any(r => r.Person.Id == ID)).Sum(x => x.RunTime);
                FillLabel(numFIlms,sumMins);
            }
        }
        //fill label
        private void FillLabel(int numFilms, int sumMins)
        {
            var stime = TimeSpan.FromMinutes(sumMins);
            var numFilmsString = "{0} Films,";
            var numDaysString = stime.Days > 1 ? "{x} Day ": "{x} Days ";
            var numHoursString = stime.Hours > 1 ? "{x} Hour ":"{x} Hours ";
            var numMinsString = "{x} Mins";
            
            if (sumMins < 60)
            {
                lbl_LibraryDetails.Text = string.Format(numFilmsString + numMinsString.Replace('x','1'), numFilms, stime.Minutes);
            }
            else if (sumMins >= 60)
            {
                //display hours
                lbl_LibraryDetails.Text = string.Format(numFilmsString + numHoursString.Replace('x', '1') + numMinsString.Replace('x', '2'), numFilms, stime.Hours, stime.Minutes);
            }
            else if (sumMins >= 1440)
            {
                //display days
                lbl_LibraryDetails.Text = string.Format(numFilmsString + numDaysString.Replace('x', '1') + numHoursString.Replace('x', '2') + numMinsString.Replace('x', '3'), numFilms, stime.Days, stime.Hours, stime.Minutes);
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
            IQueryable<Film> films;
            if (aItem.Id == Guid.Empty)
            {
                films = _films.Where(f => f.Genre.Any(t => t.Id == genreID));
            }
            else
            {
                films =
                    _films.Where(c => c.Cast.Any(r => r.Person.Id == aItem.Id)).Where(
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
            DGV_Films.DataSource = films.OrderBy(x => x.Title).Select(x => new { x.Id, x.Title, x.RunTime, x.ReleaseYear, x.Synopsis })
                .ToList();
            if (DGV_Films != null)
                DGV_Films.Columns["Id"].Visible = false;
            var numFilms = films.Count();
            var sumMins = films.Sum(x => x.RunTime);
            FillLabel(numFilms,sumMins);
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
            var directorID = item.Id;
            var aItem = (ListBoxItem)ActorList.SelectedItem;
            var gItem = (ListBoxItem)GenreList.SelectedItem;
            IQueryable<Film> films = null;
            if (aItem.Id == Guid.Empty && gItem.Id == Guid.Empty)
            {
                films = _films.Where(f => f.Director.Any(d => d.Id == directorID));
            }
            else if (aItem.Id == Guid.Empty && gItem.Id != Guid.Empty)
            {
                films = _films.Where(f => f.Genre.Any(t => t.Id == gItem.Id)).Where(f => f.Director.Any(d => d.Id == directorID));
            }
            else if (aItem.Id != Guid.Empty && gItem.Id == Guid.Empty)
            {
                films =
                    _films.Where(f => f.Cast.Any(r => r.Person.Id == aItem.Id)).Where(
                        f => f.Director.Any(d => d.Id == directorID));
            }
            else if (aItem.Id != Guid.Empty && gItem.Id != Guid.Empty)
            {
                films =
                    _films.Where(f => f.Cast.Any(r => r.Person.Id == aItem.Id)).Where(
                        f => f.Genre.Any(t => t.Id == gItem.Id)).Where(f => f.Director.Any(d => d.Id == directorID));
            }
            DGV_Films.DataSource = films.OrderBy(x => x.Title).Select(x => new { x.Id, x.Title, x.RunTime, x.ReleaseYear, x.Synopsis })
                .ToList();
            if (DGV_Films != null)
                DGV_Films.Columns["Id"].Visible = false;

            FillLabel(_films.Count(), _films.Sum(x => x.RunTime));
        }
    }
}
