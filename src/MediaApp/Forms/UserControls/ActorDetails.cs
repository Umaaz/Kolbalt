using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace MediaApp.Forms.UserControls
{
    public partial class ActorDetails : UserControl
    {
        private String _url;
        public ActorDetails(String url)
        {
            InitializeComponent();
            _url = "http://www.imdb.com/name/nm" +url;
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
            var picURL = doc.Remove(0, doc.IndexOf("<img src=\"http://ia.media-imdb.com") + 10);
            picURL = picURL.Remove(picURL.IndexOf("\""));
            var pic = new Data.DownloadImage(picURL);
            pic.Download();
            pictureBox1.Image = pic.GetImage();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (worker != null) worker.ReportProgress(100);
        }

        private void LoadBio(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var hw = new HtmlWeb();
            var doc = hw.Load(_url);
            var cc = new HtmlEscapeCharConverter();
            
            var born = doc.DocumentNode.SelectSingleNode(".//div[@class='txt-block']").InnerText.Trim();
            worker.ReportProgress(30,cc.Decode(born.Replace("  ", " ").Replace("\n", "")));
            var name = doc.DocumentNode.SelectSingleNode(".//h1[@class='header']").InnerText.Trim();
            worker.ReportProgress(60, cc.Decode(name.Replace("  ", " ").Replace("\n", "")));
            var bio = doc.DocumentNode.SelectNodes(".//p").First().InnerText.Trim();
            worker.ReportProgress(90, cc.Decode(bio));
        }
    }
}
