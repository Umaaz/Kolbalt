using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

        private void Execute(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            using (var tx = NhSession.BeginTransaction())
            {
                var total = 0;
                foreach (string s in lisb_films.Items)
                    total += Directory.GetDirectories(s).Count();
                var count = 0;
                foreach (string s in lisb_films.Items)
                {
                    if (Directory.Exists(s))
                    {
                        foreach (var folder in Directory.GetDirectories(s))
                        {
                            #region grap film
                            //getting film from folder, change to getting film from file
                            //possible use of while loop, or some lamda expression
                            //get all vedio files into a list, if mutlipule files found for one film
                            //mark in db as multifile film, at run time scan folder to find additional parts
                            var film = folder.Remove(0, folder.LastIndexOf("\\") + 1);
                            var realNewFilm = new Film();
                            var newFilm = ImdbFilm.GetTopResultByName(film);
                            if (newFilm == null)
                            {
//todo some form of error record.
                                continue;
                            }
                            if (!NhSession.Query<Film>().Where(x => x.ImdbId == newFilm.ImdbId).Any())
                            {
                                realNewFilm.FilmPath = folder;
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
                                NhSession.Save(realNewFilm);
                            }
                            count++;
                            worker.ReportProgress((count / total) * 100, "Scanned " + folder);
                            #endregion
                        }
                    }
                }
                tx.Commit();
            }
        }

        private void btn_Build_Click(object sender, EventArgs e)
        {
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
                                                        };
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}