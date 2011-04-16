using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;
using MediaApp.Data;

namespace MediaApp.Forms.UserControls
{
    public partial class FilmDetails : UserControl
    {
        private int _count = 0;
        private readonly String _url;
        public FilmDetails(String url)
        {
            _url ="Http://www.IMDB.com/title/tt" + url;
            InitializeComponent();
        }

        private void LoadTrivia(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var hw = new HtmlWeb();
            var doc = hw.Load(_url + "/trivia");
            if (!doc.ToString().Contains("class=\"sodatext\""))
                return;
            var trivi = doc.DocumentNode.SelectNodes(".//div[@class='sodatext']").ToList();
            var trivis = HtmlEscapeCharConverter.Decode(trivi[randomNum(0, trivi.Count - 1)].InnerText).Trim().Replace("Link this trivia", "");
            if (worker != null) worker.ReportProgress(100,trivis);
        }

        private void LoadGoof(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var cc = new HtmlEscapeCharConverter();
            var hw = new HtmlWeb();
            var doc = hw.Load(_url + "/goofs");
            if (!doc.ToString().Contains("class\"trivia\""))
                return;
            var goofs = doc.DocumentNode.SelectNodes(".//ul [@class='trivia']").ToList();
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
            if (worker != null) worker.ReportProgress(100,goof);
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
                    //reviews get <p> tag from site filmurl/usercomments, where doesn't contain innerHTML <small>
                //case 2:
                //    _count = 0;
                //    url = _url + "/goofs";
                //    bgw = new BackgroundWorker { WorkerReportsProgress = true };
                //    bgw.ProgressChanged += (o, args) =>
                //    {
                //        splitContainer2.Panel2.Controls.Clear();
                //        var goof = args.UserState.ToString();
                //        var goofControl = new ExtraFilmDetails(url, "Goofs", goof);
                //        splitContainer2.Panel2.Controls.Add(goofControl);
                //        goofControl.Dock = DockStyle.Fill;
                //    };
                //    bgw.DoWork += LoadGoof;
                //    bgw.RunWorkerAsync();
                //    break;
                default:
                    _count = 0;
                    timer1_Tick(sender,e);
                    break;
            }
        }


        private void LoadDetails(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var hw = new HtmlWeb();
            var doc = hw.Load(_url);
            var cc = new HtmlEscapeCharConverter();
            var title = doc.DocumentNode.SelectSingleNode(".//h1[@class='header']").InnerText.Trim();
            var year = title.Substring(title.LastIndexOf("(")+1, 4);
            title = HtmlEscapeCharConverter.Decode(title.Remove(title.IndexOf("(")));
            worker.ReportProgress(10,title);
            worker.ReportProgress(20, year);
            var divs = doc.DocumentNode.SelectNodes(".//div[@class='txt-block']");
            var director = divs.First().SelectSingleNode(".//a").InnerText.Trim();
            var dirnum = divs.First().InnerHtml;
            var dirNum = dirnum.Remove(0, dirnum.IndexOf("nm") + 2);
            dirNum = dirNum.Remove(7);
            var rating = doc.DocumentNode.SelectNodes(".//span[@class='rating-rating']").Single().InnerText;
            var IMDBrating = rating.Replace("\"", "");
            worker.ReportProgress(30, IMDBrating);
            worker.ReportProgress(40, director);
            worker.ReportProgress(50,dirNum);
            var stars = divs
                .Where(x => x.SelectNodes(".//h4") != null)
                .Where(x => x.SelectNodes(".//h4").First().InnerText.Trim().Contains("Stars"))
                .Single().InnerText;
            stars = stars.Replace("and ", "").Replace(",", "").Replace("Stars:", "").Replace("\n", "");
            worker.ReportProgress(60,stars);
            var starslinks = divs
                .Where(x => x.SelectNodes(".//h4") != null)
                .Where(x => x.SelectNodes(".//h4").First().InnerText.Trim().Contains("Stars"))
                .Single().InnerHtml;
            var i = 70;
            while (starslinks.Contains("href"))
            {
                starslinks = starslinks.Remove(0, starslinks.IndexOf("href")+14);
                worker.ReportProgress(i,starslinks.Remove(starslinks.IndexOf("/")));
                i += 10;
            }
            worker.ReportProgress(100);
        }
        
        private void loadPicture(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var hw = new HtmlWeb();
            var doc = hw.Load(_url).DocumentNode.WriteContentTo();
            var picURL = doc.Remove(0, doc.IndexOf("<img src=\"http://ia.media-IMDB.com") + 10);
            picURL = picURL.Remove(picURL.IndexOf("\""));
            var pic = new Data.DownloadImage(picURL);
            pic.Download();
            pb_Filmposter.Image = pic.GetImage();
            pb_Filmposter.SizeMode = PictureBoxSizeMode.StretchImage;
            if (worker != null) worker.ReportProgress(100);
        }
        
        private void UCFilmBase_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.ProgressChanged += (o, args) =>
            {
                switch (args.ProgressPercentage)
                {
                    case 10:
                        llbl_title.Text = args.UserState.ToString();
                        llbl_title.Click += (s, ee) => System.Diagnostics.Process.Start(_url);
                        break;
                    case 20:
                        llbl_year.Text = args.UserState.ToString();
                        llbl_year.Click += (s, ee) => System.Diagnostics.Process.Start("HTTP://www.IMDB.com/year/" + args.UserState.ToString());
                        break;
                    case 30:
                        lbl_Frating.Text = args.UserState.ToString();
                        break;
                    case 40:
                        llbl_director.Text = args.UserState.ToString();
                        llbl_director.BringToFront();
                        break;
                    case 50:
                        llbl_director.Click += (s, ee) => System.Diagnostics.Process.Start("HTTP://www.IMDB.com/name/nm" + args.UserState.ToString());
                        break;
                    case 60:
                        var star = args.UserState.ToString().Split(' ');
                        if (star.Count() >= 2)
                        {
                            llbl_Star1.Text = star[0] + " " + star[1];
                            llbl_Star1.Visible = true;
                        }
                        if (star.Count() >= 4)
                        {
                            llbl_star2.Text = star[2] + " " + star[3];
                            llbl_star2.Visible = true;
                        }
                        panel2.BringToFront();
                        break;
                    case 70:
                        llbl_Star1.Click +=
                            (s, ee) =>
                            System.Diagnostics.Process.Start("HTTP://www.IMDB.com/name/nm" + args.UserState.ToString());
                        break;
                    case 80:
                        llbl_star2.Click +=
                            (s, ee) =>
                            System.Diagnostics.Process.Start("HTTP://www.IMDB.com/name/nm" + args.UserState.ToString());
                        break;
                    case 100:
                        panel1.Visible = true;
                        lbl_loading.Visible = false;
                        timer1_Tick(sender, e);
                        break;
                }
            };
            backgroundWorker1.DoWork += LoadDetails;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.ProgressChanged += (s, args) => lbl_picloading.Visible = false;
            backgroundWorker2.DoWork += loadPicture;
            backgroundWorker2.RunWorkerAsync();
            timer1.Enabled = true;
        }

        private void llbl_year_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
