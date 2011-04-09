using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediaApp.Data;
using MediaApp.Domain;
using NHibernate;
using NHibernate.Linq;

namespace MediaApp.Forms
{
    public partial class DbCreate : Form
    {
        private static readonly ISession NhSession = NhContext.GetSession();
        private readonly Dictionary<string, Person> _people = new Dictionary<string, Person>();
        Person GetPersonFromCache(string imDb)
        {
            Person temp;
            _people.TryGetValue(imDb, out temp);
            return temp;
        }
        void AddPersonToCache(Person person)
        {
            if (!_people.ContainsKey(person.imdbID))
                _people[person.imdbID] = person;
        }


        public DbCreate()
        {
            InitializeComponent();

            var films = Properties.Settings.Default.FilmDirectories.Split('|');
            foreach (var film in films.Where(film => !film.Equals("")))
            {
                lisb_films.Items.Add(film);
            }
            chk_ApproxMatches.Checked = Properties.Settings.Default.filmApproxMatches;
            chk_DisplayFilmResults.Checked = Properties.Settings.Default.filmDisplayResults;
            chk_ExactMatches.Checked = Properties.Settings.Default.filmExactMatches;
            chk_PMatches.Checked = Properties.Settings.Default.filmPartialMatches;
            chk_PopTitles.Checked = Properties.Settings.Default.filmPopTitles;
            chk_TakeFirstFilm.Checked = Properties.Settings.Default.filmTakeFirst;
            chk_AllMatches.Checked = Properties.Settings.Default.filmAll;
            chkChanged();
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

        #region checkBoxes

        private void chkChanged()
        {
            if (chk_DisplayFilmResults.Checked)
            {
                chk_TakeFirstFilm.Enabled = true;
            }
            else
            {
                chk_TakeFirstFilm.Enabled = false;
                chk_TakeFirstFilm.Checked = true;
                groupBox2.Enabled = false;
            }
            if (!chk_TakeFirstFilm.Checked)
            {
                groupBox2.Enabled = true;
                if (chk_PopTitles.Checked)
                {
                    chk_TakeFirstFilm.Checked = false;
                }
                if (chk_PopTitles.Checked)
                {
                    chk_TakeFirstFilm.Checked = false;
                }
                if (chk_PopTitles.Checked)
                {
                    chk_TakeFirstFilm.Checked = false;
                }
                if (chk_PopTitles.Checked)
                {
                    chk_TakeFirstFilm.Checked = false;
                }
                if (chk_AllMatches.Checked)
                {
                    chk_TakeFirstFilm.Checked = false;
                    chk_ApproxMatches.Checked = true;
                    chk_ExactMatches.Checked = true;
                    chk_PMatches.Checked = true;
                    chk_PopTitles.Checked = true;
                }
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void chk_DisplayFilmResults_CheckedChanged(object sender, EventArgs e)
        {
            chkChanged();
        }

        private void chk_TakeFirstFilm_CheckedChanged(object sender, EventArgs e)
        {
            chkChanged();
        }

        private void chk_PopTitles_CheckedChanged(object sender, EventArgs e)
        {
            chkChanged();
        }

        private void Chk_PMatches_CheckedChanged(object sender, EventArgs e)
        {
            chkChanged();
        }

        private void chk_ExactMatches_CheckedChanged(object sender, EventArgs e)
        {
            chkChanged();
        }

        private void chk_ApproxMatches_CheckedChanged(object sender, EventArgs e)
        {
            chkChanged();
        }

        private void chk_AllMatches_CheckedChanged(object sender, EventArgs e)
        {
            chkChanged();
        }
        #endregion

        private void btn_ok_Click(object sender, EventArgs e)
        {
//todo check the datbindings again
            Properties.Settings.Default.filmApproxMatches = chk_ApproxMatches.Checked;
            Properties.Settings.Default.filmDisplayResults = chk_DisplayFilmResults.Checked;
            Properties.Settings.Default.filmExactMatches = chk_ExactMatches.Checked;
            Properties.Settings.Default.filmPartialMatches = chk_PMatches.Checked;
            Properties.Settings.Default.filmPopTitles = chk_PopTitles.Checked;
            Properties.Settings.Default.filmTakeFirst = chk_TakeFirstFilm.Checked;
            Properties.Settings.Default.filmAll = chk_AllMatches.Checked;
            Properties.Settings.Default.Save();
            this.Hide();
        }

        private List<String> getFilms()
        {
            List<String> files = new List<string>();
            foreach (string s in lisb_films.Items)
            {
                string[] types = {"*.avi", "*.mkv", "*.wmv"};
                foreach (var type in types)
                {
                    files.AddRange(Directory.GetFiles(s, type, SearchOption.AllDirectories));
                }
            }
            return files;
        }

        private List<String> filterFilms(List<String> files)
        {
            var filteredfilms = new List<String>();
            var filter = new[] {"xvid", "divx", "dvdrip","ac3","hdtv","repack", "proper", "mp3"};
            foreach (var file in files)
            {
                if (file.Contains("\\extras\\")) //does contains ignore case?
                    continue; 
                var f = file.Replace("."," ").Replace("_"," ");
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

                    filteredfilms.Add(f);

            }

            return filteredfilms;
        }

        private Film grapFilm(String film)
        {
            var realNewFilm = new Film();
            var url = film.Remove(0, film.LastIndexOf("\\")+1);
            url = url.Remove(url.Length - 4);
            var newFilm = ImdbFilm.GetTopResultByName(url);
            if (newFilm == null)
            {
                //todo some form of error record.
                return null;
            }
            if (!NhSession.Query<Film>().Where(x => x.ImdbId == newFilm.ImdbId).Any())
            {
                realNewFilm.FilmPath = film;
                realNewFilm.ImdbId = newFilm.ImdbId;
                realNewFilm.ReleaseDate = newFilm.ReleaseDate;
                realNewFilm.RunTime = newFilm.RunTime;
                realNewFilm.Synopsis = newFilm.Synopsis;
                realNewFilm.Title = newFilm.Title;
                realNewFilm.Director = GetPersonFromCache(newFilm.Director.imdbID)
                    ?? NhSession.Query<Person>().Where(x => x.imdbID == newFilm.Director.imdbID).SingleOrDefault()
                    ?? newFilm.Director;
                AddPersonToCache(realNewFilm.Director);
                foreach (var filmType in newFilm.Genre)
                {
                    var type =
                        NhSession.Query<FilmType>().Where(x => x.Type == filmType.Type).
                            SingleOrDefault();
                    realNewFilm.Genre.Add(type ?? filmType);
                }
                foreach (var role in newFilm.Cast)
                {
                    var actor = GetPersonFromCache(role.Person.imdbID)
                        ?? NhSession.Query<Person>().Where(x => x.imdbID == role.Person.imdbID).SingleOrDefault()
                        ?? role.Person;
                    AddPersonToCache(actor);
                    var role2 = new Role
                    {
                        Character = role.Character,
                        Person = actor
                    };
                    realNewFilm.Cast.Add(role2);
                }
                return realNewFilm;
            }
            return null;
        }

        private void Execute(object sender, DoWorkEventArgs e)
        {
            IList<Film> filmstoadd = new List<Film>();
            var worker = sender as BackgroundWorker;
            var films = getFilms();
            var count = 1;
                foreach (var film in films)
                {
                    var f = grapFilm(film);
                    if(f != null)
                        filmstoadd.Add(f);
                    var per = (int)(((double)count / films.Count) * 100);
                    worker.ReportProgress(per,film);
                    count++;
                }
            //display filmstoadd in control for user verification
            //if ok
            SaveFilms(filmstoadd);
        }

        private void SaveFilms(IList<Film> films)
        {
            using (var tx = NhSession.BeginTransaction())
            {
                foreach (var film in films)
                {
                    NhSession.Save(film);
                }
                tx.Commit();
            }
        }

        private void btn_Build_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete all entries in the current database!\nWould you like to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
            //    NhSession.Delete(NhSession.Query<Film>());
                progressBar1.Maximum = 100;
                lbl_Current.Text = "Scanning...";
                lbl_Current.Visible = true;
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.ProgressChanged += (o, args) =>
                                                         {
                                                             progressBar1.Value = args.ProgressPercentage;
                                                             lbl_Current.Text = (string) args.UserState;
                                                         };
                backgroundWorker1.DoWork += Execute;
                backgroundWorker1.RunWorkerCompleted += (s, ee) =>
                                                            {
                                                                lbl_Current.Visible = false;
                                                                MessageBox.Show("done");
                                                                updateIndex();
                                                            };
                backgroundWorker1.RunWorkerAsync();

            }
        }

        private void updateIndex()
        {
            var session = NHibernate.Search.Search.CreateFullTextSession(NhSession);
            using (var trans = session.BeginTransaction())
            {
                foreach (var thing in session.CreateCriteria(typeof(Film)).List<Film>())
                {
                    session.Index(thing);
                }
                trans.Commit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}