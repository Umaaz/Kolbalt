using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediaApp.Data;
using MediaApp.Data.Web.IMDB;
using MediaApp.Domain.Commands;
using MediaApp.Domain.Model;
using MediaApp.Forms.Popups;
using NHibernate;
using NHibernate.Linq;

namespace MediaApp.Forms.UserControls.Settings
{
    public partial class FilmDatabase : UserControl
    {
        private static readonly ISession NhSession = NhContext.GetSession();
        public FilmDatabase()
        {
            InitializeComponent();
            PopulateList();
        }
        #region Watched Folders
        private void PopulateList()
        {
            lisb_films.DataSource = Properties.Settings.Default.FilmDirectories;
        }

        private void btn_Addfilm_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.FilmDirectories.Add(fbd.SelectedPath);
                Properties.Settings.Default.Save();
            }
            PopulateList();
        }

        private void btn_RemoveFilm_Click(object sender, EventArgs e)
        {
            var appPath = Path.GetDirectoryName(Application.ExecutablePath);
            Directory.Delete(appPath + "\\SearchIndex",true);
            Directory.CreateDirectory(appPath + "\\SearchIndex");
            if(lisb_films.SelectedItems.Count > 0)
            {
                if(MessageBox.Show("Are you sure you want to remove this path?\n" + lisb_films.SelectedItem, "Are you sure?",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Properties.Settings.Default.FilmDirectories.RemoveAt(lisb_films.SelectedIndex);
                    Properties.Settings.Default.Save();
                }
            }
            PopulateList();
        }
        #endregion

        private void btn_ReBuild_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue?\n - This will clear the current database!","Are you Sure?",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var bgw = Newbgw();
                bgw.ProgressChanged += (o, args) =>
                                           {
                                               lbl_Current.Visible = true;
                                               lbl_Current.Text = (String)args.UserState;
                                           };
                bgw.DoWork += DeleteAll;
                bgw.RunWorkerCompleted += (o, args) =>
                                              {
                                                  lbl_Current.Visible = false;
                                                  Build();
                                              };
                bgw.RunWorkerAsync();
            }
        }

        private void DeleteAll(object sender, DoWorkEventArgs args)
        {
            var worker = sender as BackgroundWorker;
            using(var tx = NhSession.BeginTransaction())
            {
                var films = NhSession.Query<Film>();
                foreach (var film in films)
                {
                    worker.ReportProgress(1,"Deleted: " + film.Title);
                    NhSession.Delete(film);
                }
                tx.Commit();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Build();
        }
        
        private void Build()
        {
            progressBar1.Enabled = true;
            progressBar1.Value = 0;
            var bgw = Newbgw();
            bgw.ProgressChanged += (o, args) =>
                                       {
                                           lbl_Current.Visible = true;
                                           lbl_Current.Text = (String) args.UserState;
                                           progressBar1.Enabled = true;
                                           progressBar1.Value = args.ProgressPercentage;
                                       };
            bgw.DoWork += Execute;
            bgw.RunWorkerCompleted += (o, args) =>
                                          {
                                              progressBar1.Enabled = false;
                                              UserVerification();
                                              
                                          };
            bgw.RunWorkerAsync();
        }

        private void UserVerification()
        {
            var results = new Results(_foundFilms,_possibleErrors);
            if (results.ShowDialog(this) != DialogResult.OK)
                return;
            var bgw = Newbgw();
            bgw.ProgressChanged += (o, args) =>
                                       {
                                           lbl_Current.Visible = true;
                                           lbl_Current.Text = (String) args.UserState;

                                       };
            bgw.DoWork += SaveFilms;
            bgw.RunWorkerCompleted += (o, args) =>
                                          {
                                              lbl_Current.Visible = false;
                                              Index();
                                          };
            bgw.RunWorkerAsync();
        }
        private void Index()
        {
            var bgw = Newbgw();
            bgw.ProgressChanged += (o, args) =>
                                       {
                                           lbl_Current.Text = (String) args.UserState;
                                           lbl_Current.Visible = true;
                                       };
            bgw.DoWork += UpdateIndex;
            bgw.RunWorkerCompleted += (o, args) =>
                                          {
                                              lbl_Current.Text = "Build Coimplete.";
                                              lbl_Current.Visible = true;
                                              progressBar1.Enabled = false;
                                          };
            bgw.RunWorkerAsync();
        }

        private void UpdateIndex(object sender, DoWorkEventArgs args)
        {
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(99,"Indexing...");
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

        private void SaveFilms(object sender, DoWorkEventArgs args)
        {
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(99,"Saving films...");
            var allFilms = new List<Film>(_foundFilms);
            allFilms.AddRange(_possibleErrors);
            var command = new AddFilmsCommand();
            command.Films = allFilms;
            if(command.Execute())
            {
                
            }
            else
            {
                var errors = command.ValidationErrors;
            }
        }
        private List<Film> _foundFilms = new List<Film>();
        private List<Film> _possibleErrors = new List<Film>();
        private void Execute (object sender, DoWorkEventArgs args)
        {
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(1, "Gathering Files...");
            var files = GetFiles();
            if (files.Count <= 0)
            {
                //todo Error, no files found
                return;
            }
            worker.ReportProgress(2, "Scanning Files...");
            var ffilms = FilterFilms(files);
            worker.ReportProgress(3, "Searching...");
            GrapFilms(sender,ffilms);
            worker.ReportProgress(99, "Awaiting user verification...");
        }
        
        private void GrapFilms(object sender, List<PossibleFilm> films)
        {
            var worker = sender as BackgroundWorker;
            var numFilms = films.Count;
            var count = 1;
            foreach (var film in films)
            {
                var percent = (count++/(double) numFilms)*100;
                worker.ReportProgress((int)percent,film.Path);
                var newFilm = IMDBFilm.GetFilmByName(film.Title);
                if (newFilm != null)
                {
                    newFilm.FilmPath = film.Path;
                    if(Regex.IsMatch(newFilm.Title,film.Title.Trim(),RegexOptions.IgnoreCase))
                    {
                        _foundFilms.Add(newFilm);
                    }
                    else
                    {
                        _possibleErrors.Add(newFilm);
                    }
                }
            }
        }

        private List<PossibleFilm> FilterFilms(List<String> files)
        {
            var filter = GetFilter();
            var pFilms = new List<PossibleFilm>();
            foreach (var file in files)
            {
                if(InExtrasDirectory(file))
                    continue;
                var title = file.Remove(0, file.LastIndexOf("\\")+1);
                title = title.Remove(title.LastIndexOf('.'));
                title = title.Replace(".", " ").Replace("_", " ").Replace("-", " ");
                title = Regex.Replace(title, filter, "", RegexOptions.IgnoreCase);
                title = Regex.Replace(title, @"(\{.*\}|\(.*\)|\[.*\])", "");
                title = Regex.Replace(title, @"(cd|part|parts)[\s\d][\s\d]", "", RegexOptions.IgnoreCase);
                title = title.Trim();
                var splitTitle = title.Split(' ');
                //removes words that are mostly capitals, "usually tags from Torrent sites"
                var nsplitTitle = splitTitle.Where(x => !MostCapitals(x)).ToList();
                title = "";
                foreach (var s in nsplitTitle)
                {
                    title += s + " ";
                }
                pFilms.Add(new PossibleFilm
                               {
                                   Path = file,
                                   Title = title
                               });
            }
            return pFilms;
        }

        private String GetFilter()
        {
            var filter = Properties.Settings.Default.FilmFileFilter;
            var nfilter = "(";
            foreach (var s in filter)
            {
                nfilter += s + "|";
            }
            nfilter += ")";
            return nfilter;
        }

        private bool MostCapitals(String s)
        {
            var length = s.Length;
            var passCount = s.Count(c => char.IsUpper(c));
            return ((passCount / (Double)length) * 100) > 80;
        }

        private bool InExtrasDirectory(String file)
        {
            return (Regex.IsMatch(file, @"(\\extra\\|\\extras\\)", RegexOptions.IgnoreCase));
        }

        private List<String> GetFiles()
        {
            var folders = Properties.Settings.Default.FilmDirectories;
            var files = new List<String>();
            var types = Properties.Settings.Default.FilmFileTypes;
            foreach (var folder in folders)
            {
                foreach (var type in types)
                {
                    files.AddRange(Directory.GetFiles(folder,type,SearchOption.AllDirectories));
                }
            }
            return files;
        }
        private BackgroundWorker Newbgw()
        {
            return new BackgroundWorker {WorkerReportsProgress = true, WorkerSupportsCancellation = true};
        }
    }


    public class PossibleFilm
    {
        public String Path { get; set; }
        public String Title { get; set; }
    }
}
