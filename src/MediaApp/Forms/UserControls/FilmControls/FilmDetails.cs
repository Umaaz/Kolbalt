using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;
using MediaApp.Data;
using MediaApp.Data.Web;
using MediaApp.Domain.Model;
using NHibernate.Linq;

namespace MediaApp.Forms.UserControls.FilmControls
{
    public partial class FilmDetails : UserControl
    {
        private int _count = 0;
        private readonly String _url;
        private readonly Film _film;
        public FilmDetails(Film film)
        {
            _url ="Http://www.IMDB.com/title/tt" + film.IMDBId;
            _film = film;
            InitializeComponent();
            var bgw = new BackgroundWorker {WorkerReportsProgress = true};
            bgw.ProgressChanged += (o, args) =>
                                       {

                                       };
            bgw.DoWork += loadPicture;
            bgw.RunWorkerCompleted += (o, args) =>
                                          {
                                              lbl_picloading.Visible = false;
                                          };
            bgw.RunWorkerAsync();
            populate();
            timer1.Enabled = true;
        }
        
        private void populate()
        {
            llbl_title.Text = _film.Title;
            llbl_title.Click += (o, ee) => System.Diagnostics.Process.Start("http://www.imdb.com/title/tt" + _film.IMDBId);
            llbl_title.Visible = true;
            llbl_year.Text = _film.ReleaseYear;
            llbl_year.Click += (o, ee) => System.Diagnostics.Process.Start("http://www.imdb.com/year/"+_film.ReleaseYear);
            llbl_year.Visible = true;
            llbl_director.Text = _film.Director.Select(x => x.Name).First();
            llbl_director.Click += (o, ee) => System.Diagnostics.Process.Start("http://www.imdb.com/name/nm" + _film.Director.Select(x => x.IMDBID).First());
            llbl_director.Visible = true;
            llbl_Star1.Text = _film.Cast.Select(x => x.Person.Name).First();
            llbl_Star1.Click += (o, ee) => System.Diagnostics.Process.Start("http://www.imdb.com/name/nm" + _film.Cast.Select(x => x.Person.IMDBID).First());
            llbl_Star1.Visible = true;
            llbl_star2.Text = _film.Cast.Select(x => x.Person.Name).Skip(1).First();
            llbl_star2.Click += (o, ee) => System.Diagnostics.Process.Start("http://www.imdb.com/name/nm" + _film.Cast.Select(x => x.Person.Name).Skip(1).First());
            llbl_star2.Visible = true;
            lbl_Frating.Text = string.Format("{0}/10", _film.IMDBRating);
            lbl_Frating.Visible = true;
            lbl_loading.Visible = false;
        }
        
        private void LoadTrivia(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var hw = new HtmlWeb();
            var doc = hw.Load(_url + "/trivia");
            if (doc.DocumentNode.InnerHtml.Contains("class=\"sodatext\""))
            {

                var trivi = doc.DocumentNode.SelectNodes(".//div[@class='sodatext']").ToList();
                var trivis =
                    HtmlEscapeCharConverter.Decode(trivi[randomNum(0, trivi.Count - 1)].InnerText).Trim().Replace(
                        "Link this trivia", "");
                worker.ReportProgress(100, trivis);
            }
        }

        private void LoadGoof(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var cc = new HtmlEscapeCharConverter();
            var hw = new HtmlWeb();
            var doc = hw.Load(_url + "/goofs");
            var f = doc.DocumentNode.InnerHtml.Contains("class=\"trivia\"");
            if (f)
            {
                var goofs = doc.DocumentNode.SelectNodes(".//ul [@class='trivia']");
                if (goofs != null)
                {
                    IList<String> goo = new List<String>();
                    foreach (var htmlNode in goofs)
                    {
                        var g = htmlNode.SelectNodes(".//li").ToList();
                        foreach (var node in g)
                        {
                            goo.Add(node.InnerText);
                        }
                    }
                    var goof = HtmlEscapeCharConverter.Decode(goo[randomNum(0, goo.Count - 1)].Trim());
                    worker.ReportProgress(100, goof);
                }
            }
        }

        private int randomNum(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BackgroundWorker bgw;
            string url;
            switch (_count)
            {
                case 0:
                    _count = 1;
                    url = _url + "/trivia";
                    bgw = new BackgroundWorker {WorkerReportsProgress = true};
                    bgw.ProgressChanged += (o, args) =>
                                               {
                                                   splitContainer2.Panel2.Controls.Clear();
                                                   var trivia = args.UserState.ToString();
                                                   var triviaControl = new ExtraFilmDetails(url,"Trivia",trivia);
                                                   splitContainer2.Panel2.Controls.Add(triviaControl);
                                                   triviaControl.Dock = DockStyle.Fill;
                                               };
                    bgw.DoWork += LoadTrivia;
                    bgw.RunWorkerAsync();
                    break;
                case 1:
                    _count = 0;
                    url = _url + "/goofs";
                    bgw = new BackgroundWorker {WorkerReportsProgress = true};
                    bgw.ProgressChanged += (o, args) =>
                                               {
                                                   splitContainer2.Panel2.Controls.Clear();
                                                   var goof = args.UserState.ToString();
                                                   var goofControl = new ExtraFilmDetails(url,"Goofs", goof);
                                                   splitContainer2.Panel2.Controls.Add(goofControl);
                                                   goofControl.Dock = DockStyle.Fill;
                                               };
                    bgw.DoWork += LoadGoof;
                    bgw.RunWorkerAsync();
                    break;
                default:
                    _count = 0;
                    timer1_Tick(sender,e);
                    break;
            }
        }

        private void loadPicture(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            if (_film.PicURL != null)
            {
                var pic = new DownloadImage(_film.PicURL);
                pic.Download();
                pb_Filmposter.Image = pic.GetImage();
                pb_Filmposter.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            worker.ReportProgress(100);
        }
        
        private void llbl_year_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
