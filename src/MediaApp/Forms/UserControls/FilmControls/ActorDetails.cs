using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;
using Kolbalt.Core.Data.Web;

namespace MediaApp.Forms.UserControls.FilmControls
{
    public partial class ActorDetails : UserControl
    {
        private String _url;
        public ActorDetails(String url)
        {
            InitializeComponent();
            _url = "http://www.IMDB.com/name/nm" +url;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.ProgressChanged += (o, args) =>
                                                     {
                                                         switch(args.ProgressPercentage)
                                                         {
 //error with amanda tapping.. not displaying bio, although it is succseful in retrieving it
                                                             case 30:
                                                                     lbl_Born.Text = args.UserState.ToString();
                                                                     lbl_Born.Visible = true;
                                                                 break;
                                                             case 60:
                                                                 lbl_Name.Text = args.UserState.ToString();
                                                                 llbl_page.Click +=
                                                                     (s, ee) => System.Diagnostics.Process.Start(_url);
                                                                 llbl_page.Visible = true;
                                                                 lbl_Name.Visible = true;
                                                                 break;
                                                             case 90:
                                                                 txt_bio.Text = args.UserState.ToString().Trim().Replace("See full bio »", "");
                                                                 if (lbl_Born.Text.Contains("Trivia:"))
                                                                 {
                                                                     txt_bio.Text = lbl_Born.Text.ToString().Replace("  ", " ").Replace("See more trivia »", "");
                                                                     lbl_Born.Visible = false;
                                                                     lbl_loading.Visible = false;
                                                                 }
                                                                 break;
                                                         }
                                                         lbl_loading.Visible = false;
                                                     };
            backgroundWorker1.DoWork += LoadBio;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.ProgressChanged += (s, args) => lbl_picloading.Visible = false;
            backgroundWorker2.DoWork += loadPicture;
            backgroundWorker2.RunWorkerAsync();
        }

        private void loadPicture(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var hw = new HtmlWeb();
            var doc = hw.Load(_url).DocumentNode.WriteContentTo();
            var p = doc.IndexOf("<img src=\"http://ia.media-IMDB.com");
            var pp = doc.IndexOf("<img src=\"http://ia.media-imdb.com");
            string picURL = null;
            if(p != -1)
            {
                picURL = doc.Remove(0, p + 10);
            }
            else if(pp != -1)
            {
                picURL = doc.Remove(0, pp + 10);
            }
            if (picURL != null)
            {
                picURL = picURL.Remove(picURL.IndexOf("\""));
                var pic = new DownloadImage(picURL);
                pic.Download();
                pictureBox1.Image = pic.GetImage();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            worker.ReportProgress(100);
        }

        private void LoadBio(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var hw = new HtmlWeb();
            var doc = hw.Load(_url);

            var born = doc.DocumentNode.SelectSingleNode(".//div[@class='txt-block']").InnerText.Trim();
            worker.ReportProgress(30, HtmlEscapeCharConverter.Decode(born.Replace("  ", " ").Replace("\n", "")));
            var name = doc.DocumentNode.SelectSingleNode(".//h1[@class='header']").InnerText.Trim();
            worker.ReportProgress(60, HtmlEscapeCharConverter.Decode(name.Replace("  ", " ").Replace("\n", "")));
            var bio = doc.DocumentNode.SelectNodes(".//p").First().InnerText.Trim();
            worker.ReportProgress(90, HtmlEscapeCharConverter.Decode(bio));
        }
    }
}
