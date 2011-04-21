using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MediaApp.Data.IMDB;

namespace MediaApp.Forms
{
    public partial class IMDBResultsList : Form
    {
        public String URL { get; set; }
        private readonly IList<IMDBResult> _results;
        public IMDBResultsList(IList<IMDBResult> results, String title)
        {
            _results = results;
            InitializeComponent();
            Text = "IMDB results - " + title;
            var il = new ImageList();
            var count = 0;
            listView1.View = View.Tile;
            il.ImageSize = new Size(32, 32);
            listView1.LargeImageList = il;
            foreach (var imdbResult in results)
            {
                ListViewItem item;
                if (imdbResult.PicUrl != "/images/b.gif")
                {
                    var pic = new Data.DownloadImage(imdbResult.PicUrl);
                    pic.Download();
                    il.Images.Add(pic.GetImage());
                    item = new ListViewItem(new[] {imdbResult.Title, imdbResult.Year}) {ImageIndex = count++};
                }
                else
                {
                    item = new ListViewItem(new[] {imdbResult.Title, imdbResult.Year});
                }
                listView1.Items.Add(item);
            }
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void btn_fetch_Click(object sender, EventArgs e)
        {
            URL = _results[listView1.SelectedIndices[0]].Url;
        }

        private void listView1_MouseHover(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.ShowItemToolTips = true;
                var result = _results[listView1.SelectedIndices[0]];
                var tip = "Title: " + result.Title + "\nYear: " + result.Year;
                listView1.SelectedItems[0].ToolTipText = tip;
            }
        }

        private void IMDBResultsList_Load(object sender, EventArgs e)
        {

        }
    }
}
