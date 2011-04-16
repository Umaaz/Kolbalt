using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediaApp.Data;
using MediaApp.Data.IMDB;
using MediaApp.Domain;
using NHibernate;
using NHibernate.Linq;

namespace MediaApp.Forms
{
    public partial class DbCreate : Form
    {
        
        private static readonly ISession NhSession = NhContext.GetSession();
        public DbCreate()
        {
            InitializeComponent();
        }

        private void TabControl1SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    BuildFilm();
                    break;
                case 2:
                    break;
            }
        }

        #region film
        private readonly Dictionary<string, Person> _people = new Dictionary<string, Person>();
        private double _time;

        Person GetPersonFromCache(string IMDB)
        {
            Person temp;
            _people.TryGetValue(IMDB, out temp);
            return temp;
        }
        void AddPersonToCache(Person person)
        {
            if (!_people.ContainsKey(person.IMDBID))
                _people[person.IMDBID] = person;
        }

        private void BuildFilm()
        {
            PopulateList();
        }

        #region watchedfolders

        private void PopulateList()
        {
            lisb_films.Items.Clear();
            var films = Properties.Settings.Default.FilmDirectories.Split('|');
            foreach (var film in films.Where(film => !film.Equals("")))
            {
                lisb_films.Items.Add(film);
            }
        }

        private void btn_Addfilm_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            var nfilm = folderBrowserDialog1.SelectedPath;
            Properties.Settings.Default.FilmDirectories += nfilm + "|";
            Properties.Settings.Default.Save();
            lisb_films.Items.Clear();
            var films = Properties.Settings.Default.FilmDirectories.Split('|');
            foreach (var film in films)
            {
                lisb_films.Items.Add(film);
            }
        }

        private void btn_RemoveFilm_Click(object sender, EventArgs e)
        {
            if (!lisb_films.SelectedItem.Equals(""))
            {
                Properties.Settings.Default.FilmDirectories = Properties.Settings.Default.FilmDirectories.Replace(lisb_films.SelectedItem.ToString() + "|", "");
                Properties.Settings.Default.Save();
                lisb_films.Items.RemoveAt(lisb_films.SelectedIndex);
            }
        }
        #endregion

        #region Build film database
        
        private static IList<IList<IMDBResult>> _results = new List<IList<IMDBResult>>();
        
        private void btn_ReBuild_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete all entries in the current database!\nWould you like to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //todo delete all films
                var films = NhSession.Query<Film>();
                foreach (var film in films)
                {
                    NhSession.Delete(film);
                }
                build();
            }
        }

        private void build()
        {
            progressBar1.Maximum = 100;
            lbl_Current.Text = "Scanning...";
            lbl_Current.Visible = true;
            lbl_TR.Visible = true;
            lbl_TRemaing.Visible = true;
            backgroundWorker1.WorkerReportsProgress = true;
            timer1.Enabled = true;
            backgroundWorker1.ProgressChanged += (o, args) =>
            {
                if (args.ProgressPercentage == 99)
                    BringToFront();
                progressBar1.Value = args.ProgressPercentage;
                if (args.UserState.ToString().Length <= 80)
                    lbl_Current.Text = (string)args.UserState;
                else
                {
                    var temp = args.UserState.ToString().Remove(80);
                    lbl_Current.Text = temp + "...";
                }

                UpdateTimeRemaining(args.ProgressPercentage);
                _time = 0;
            };
            backgroundWorker1.DoWork += Execute;
            backgroundWorker1.RunWorkerCompleted += (s, ee) =>
            {
                lbl_Current.Visible = false;
                lbl_TR.Visible = false;
                lbl_TRemaing.Visible = false;

                MessageBox.Show("done");
            };
            backgroundWorker1.RunWorkerAsync();
        }


        private void Execute(object sender, DoWorkEventArgs e)
        {
            IList<Film> filmstoadd = new List<Film>();
            var worker = sender as BackgroundWorker;
            var films = GetFilms();
            var count = 1;
            foreach (var film in films)
            {
                var ff = FilterFilms(film);
                Film f = null;
                if (ff != null)
                    f = GrapFilm(ff);
                if (f != null)
                    filmstoadd.Add(f);
                var per = (int)(((double)count / films.Count) * 100);
                worker.ReportProgress(per - 1, film);
                count++;
            }
            IList<Film> filmstoreallyadd = new List<Film>();
            IList<IList<IMDBResult>> realResults = new List<IList<IMDBResult>>();
            for (int i = 0; i < filmstoadd.Count; i++)
            {
                var inc = false;
                foreach (var film in filmstoreallyadd)
                {
                    if(film.IMDBId == filmstoadd[i].IMDBId)
                    {
                        inc = true;
                    }
                }
                if(!inc)
                {
                    filmstoreallyadd.Add(filmstoadd[i]);
                    realResults.Add(_results[i]);
                }
            }
            if (Properties.Settings.Default.filmDisplayResults)
            {
                var dr = new Results(filmstoreallyadd, realResults);
                worker.ReportProgress(98, "Awaiting user verification!");
                if (dr.ShowDialog() == DialogResult.OK)
                {
                    worker.ReportProgress(98, "Commiting to database");
                    SaveFilms(filmstoreallyadd);
                    worker.ReportProgress(98, "Indexing...");
                    UpdateIndex();
                }
                worker.ReportProgress(99,"");
            }
            else
            {
                worker.ReportProgress(98, "Commiting to database");
                SaveFilms(filmstoreallyadd);
                worker.ReportProgress(98, "Indexing...");
                UpdateIndex();
            }
            
            worker.ReportProgress(100, "");
        }
        
        private List<String> GetFilms()
        {
            var files = new List<string>();
            foreach (string s in lisb_films.Items)
            {
                if(!Directory.Exists(s)) continue;
                string[] types = {"*.avi", "*.mkv", "*.wmv"};
                foreach (var type in types)
                {
                    files.AddRange(Directory.GetFiles(s, type, SearchOption.AllDirectories));
                }
            }
            return files;
        }

        private static String FilterFilms(String file)
        {
            var filter = new[] {"xvid", "divx", "dvdrip","ac3","hdtv","repack", "proper", "mp3"};

            if (file.Contains("\\extras\\") || file.Contains("\\EXTRAS\\") || file.Contains("\\extra\\") || file.Contains("\\EXTRA\\"))
                return null;

            var f = file.Replace("."," ").Replace("_"," ").Replace("-","");
            f = Regex.Replace(f, @"\dch",""); //may need re worked to include 5.1 7.1 2.0 2 etc
            foreach (var s in filter)
            {
                f = f.Replace(s, "");
            }
            if (f.IndexOf("(") > 0 && f.IndexOf(")") > 0)
                f = f.Remove(f.IndexOf("("), f.IndexOf(")") - f.IndexOf("(") - 1);
            if (f.IndexOf("[") > 0 && f.IndexOf("]") > 0)
                f = f.Remove(f.IndexOf("["), f.IndexOf("]") - f.IndexOf("[") - 1);
            if (f.IndexOf("{") > 0 && f.IndexOf("}") > 0)
                f = f.Remove(f.IndexOf("{"), f.IndexOf("}") - f.IndexOf("{") - 1);
            f = Regex.Replace(f, @"Part\s\d", "", RegexOptions.IgnoreCase);
            f = Regex.Replace(f, @"CD\s\d", "", RegexOptions.IgnoreCase);
            f = Regex.Replace(f, @"Part\d", "", RegexOptions.IgnoreCase);
            f = Regex.Replace(f, @"CD\d", "", RegexOptions.IgnoreCase);
            f = f.Trim();
            
            return f;
        }

        private static Film GrapFilm(String film)
        {
            var title = film.Remove(0, film.LastIndexOf("\\")+1);
            title = title.Remove(title.Length - 4);
            Film newFilm = new Film();
            newFilm = IMDBFilm.GetFilmByName(title);
            GetIMDBResults(title);
           
            return newFilm;
        }

        private static void GetIMDBResults(String title)
        {
            _results.Add(IMDBSearch.SearchIMDBByTitle(title));
        }

        private void SaveFilms(IList<Film> films)
        {
            using (var tx = NhSession.BeginTransaction())
            {
                foreach (var film in films)
                {
                    var realNewFilm = new Film();
                    if (!NhSession.Query<Film>().Where(x => x.IMDBId == film.IMDBId).Any())
                    {
                        realNewFilm.FilmPath = film.FilmPath;
                        realNewFilm.IMDBId = film.IMDBId;
                        realNewFilm.ReleaseDate = film.ReleaseDate;
                        realNewFilm.RunTime = film.RunTime;
                        realNewFilm.Synopsis = film.Synopsis;
                        realNewFilm.Title = film.Title;
                        realNewFilm.Director = GetPersonFromCache(film.Director.IMDBID)
                                               ??
                                               NhSession.Query<Person>().Where(x => x.IMDBID == film.Director.IMDBID).
                                                   SingleOrDefault()
                                               ?? film.Director;
                        AddPersonToCache(realNewFilm.Director);
                        foreach (var filmType in film.Genre)
                        {
                            var type =
                                NhSession.Query<FilmType>().Where(x => x.Type == filmType.Type).
                                    SingleOrDefault();
                            realNewFilm.Genre.Add(type ?? filmType);
                        }
                        foreach (var role in film.Cast)
                        {
                            var actor = GetPersonFromCache(role.Person.IMDBID)
                                        ??
                                        NhSession.Query<Person>().Where(x => x.IMDBID == role.Person.IMDBID).
                                            SingleOrDefault()
                                        ?? role.Person;
                            AddPersonToCache(actor);
                            var role2 = new Role
                                            {
                                                Character = role.Character,
                                                Person = actor
                                            };
                            realNewFilm.Cast.Add(role2);
                        }
                        NhSession.Save(realNewFilm);
                    }
                }
                tx.Commit();
            }
        }
        
        private void UpdateTimeRemaining(int prog)
        {
            var total = 100-prog;
            var totalt = _time* total;
            var time = TimeSpan.FromSeconds(totalt);
            lbl_TR.Text = time.ToString("c");
        }

        private static void UpdateIndex()
        {
            var session = NHibernate.Search.Search.CreateFullTextSession(NhSession);
            using (var trans = session.BeginTransaction())
            {
                foreach (var thing in session.CreateCriteria(typeof(Film)).List<Film>())
                {
                    session.Index(thing);
                }
                //foreach (var thing in session.CreateCriteria(typeof(Role)).List<Role>())
                //{
                //    session.Index(thing);
                //}
                trans.Commit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _time++;
        }
        
        #endregion
        
        #endregion

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Hide();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            build();
        }
    }
}