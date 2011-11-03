using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kolbalt.Core.Data.Web.IMDB;
using Kolbalt.Core.Domain;
using Kolbalt.Core.Domain.Commands;
using Kolbalt.Core.Domain.Model;
using MediaApp.Forms.Popups;
using NHibernate;
using NHibernate.Linq;

namespace MediaApp.Forms.UserControls.Settings
{
    public partial class FilmDatabase : UserControl
    {
        private static readonly ISession NhSession = NhContext.GetSession();
        private List<FilmResult> _films = new List<FilmResult>();
        public BackgroundWorker Bgw { get; private set; }
        public Boolean UComplete { get; set; }
        public Boolean UClosePending { get; set; }
        public Boolean Building;
        
        public FilmDatabase()
        {
            InitializeComponent();
            PopulateList();
            UComplete = true;
        }
        #region Watched Folders
        private void PopulateList()
        {
            lisb_films.DataSource = new[] {""};
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
                Enable(false);
                UComplete = false;
                var appPath = Path.GetDirectoryName(Application.ExecutablePath);
                Directory.Delete(appPath + "\\SearchIndex", true);
                Directory.CreateDirectory(appPath + "\\SearchIndex");
                Bgw = Newbgw();
                Bgw.ProgressChanged += (o, args) =>
                                           {
                                               lbl_Current.Visible = true;
                                               lbl_Current.Text = (String)args.UserState;
                                           };
                Bgw.DoWork += DeleteAll;
                Bgw.RunWorkerCompleted += (o, args) =>
                                              {
                                                  UComplete = true;
                                                  if (UClosePending)
                                                      MainForms.FRM_Main.Settings.Close();
                                                  else
                                                  {
                                                      lbl_Current.Visible = false;
                                                      Build();
                                                  }
                                              };
                Bgw.RunWorkerAsync();
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
        private bool CheckNetConnection()
        {
            var code = (HttpStatusCode) 0;
            var pass = true;
            var request = (HttpWebRequest)WebRequest.Create("http://www.IMDB.com/");
            request.Proxy = null;
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                code = response.StatusCode;
            }
            catch (WebException)
            {
                pass = false;
            }
            if(code != HttpStatusCode.OK)
            {
                pass = false;
            }
            return pass;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckNetConnection())
                Build();
            else
                MessageBox.Show("Error Connection to IMDB\nCheck net connection and retry!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Build()
        {
            if(Building)
            {
                MessageBox.Show("Build currently in progress!");
            }
            UComplete = false;
            Building = true;
            Enable(false);
            Bgw = Newbgw();
            progressBar1.Enabled = true;
            progressBar1.Value = 0;
            Bgw.ProgressChanged += (o, args) =>
                                       {

                                           lbl_Current.Visible = true;
                                           lbl_Current.Text = (String) args.UserState;
                                           progressBar1.Enabled = true;
                                           progressBar1.Value = args.ProgressPercentage;
                                       };
            Bgw.DoWork += Execute;
            Bgw.RunWorkerCompleted += (o, args) =>
                                          {
                                              UComplete = true;
                                              if (UClosePending)
                                                  MainForms.FRM_Main.Settings.Close();
                                              else
                                              {
                                                  progressBar1.Enabled = false;
                                                  if (Properties.Settings.Default.filmDisplayResults)
                                                  {
                                                      if (UserVerification())
                                                      {
                                                          Complete();
                                                      }
                                                      else
                                                      {
                                                          lbl_Current.Text = "User Aborted!";
                                                          Enable(true);
                                                          
                                                      }
                                                  }
                                                  else
                                                  {
                                                      Complete();
                                                  }
                                              }
                                          };
            Bgw.RunWorkerAsync();
        }
        private void Enable(Boolean b)
        {
            btn_update.Enabled = b;
            btn_ReBuild.Enabled = b;
            btn_build.Enabled = b;
        }
        private bool UserVerification()
        {
            Results results = null;
            if (_films.Count == 0)
                return false;
            results = new Results(_films);
            if (results.ShowDialog(this) != DialogResult.OK)
                return false;
            _films = results.GetFilms();
            return true;
        }
        private void Complete()
        {
            Bgw = Newbgw();
            Bgw.ProgressChanged += (o, args) =>
                                       {
                                           lbl_Current.Visible = true;
                                           lbl_Current.Text = (String) args.UserState;

                                       };
            Bgw.DoWork += SaveFilms;
            Bgw.RunWorkerCompleted += (o, args) =>
                                          {
                                              UComplete = true;
                                              if (UClosePending)
                                                  MainForms.FRM_Main.Settings.Close();
                                              else
                                              {
                                                  lbl_Current.Visible = false;
                                                  Index();
                                              }
                                          };
            Bgw.RunWorkerAsync();
        }
        private void Index()
        {
            Bgw = Newbgw();
            Bgw.ProgressChanged += (o, args) =>
                                       {
                                           lbl_Current.Text = (String) args.UserState;
                                           lbl_Current.Visible = true;
                                       };
            Bgw.DoWork += UpdateIndex;
            Bgw.RunWorkerCompleted += (o, args) =>
                                          {
                                              UComplete = true;
                                              if (UClosePending)
                                                  MainForms.FRM_Main.Settings.Close();
                                              else
                                              {
                                                  lbl_Current.Text = "Build Complete.";
                                                  lbl_Current.Visible = true;
                                                  progressBar1.Enabled = false;
                                                  Building = false;
                                                  Enable(true);
                                              }
                                          };
            Bgw.RunWorkerAsync();
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
            var command = new AddFilmsCommand();
            command.Films = _films.Select(x => (Film)x).ToList();
            if(command.Execute())
            {
                
            }
            else
            {
                var errors = command.ValidationErrors;
            }
        }
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
                if (UClosePending)
                    return;
                var percent = (count++/(double) numFilms)*100;
                worker.ReportProgress((int)percent,film.Path);
                var newFilm = ImdbFilm.GetFilmByName(film.Title);
                if (newFilm != null)
                {
                    newFilm.FilmPath = film.Path;
                    if(Regex.IsMatch(newFilm.Title,film.Title.Trim(),RegexOptions.IgnoreCase))
                    {
                        _films.Add(new FilmResult(newFilm)
                                       {
                                           PossibleErrors = false
                                       });
                    }
                    else
                    {
                        var f = new FilmResult(newFilm)
                                    {
                                        PossibleErrors = true
                                    };
                        _films.Add(f);
                    }
                }
                else
                {
                    var f = new FilmResult()
                                {
                                    FilmPath = film.Path,
                                    PossibleErrors = null
                                };
                    _films.Add(f);
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
