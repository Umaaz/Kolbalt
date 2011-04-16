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
        private IList<IMDBResult> _results;
        public IMDBResultsList(IList<IMDBResult> results)
        {
            _results = results;
            InitializeComponent();
            var il = new ImageList();
            var count = 0;
            listView1.View = View.LargeIcon;
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
                    item = item = new ListViewItem(new[] {imdbResult.Title, imdbResult.Year});
                }
                listView1.Items.Add(item);
            }
        }

        private void btn_fetch_Click(object sender, EventArgs e)
        {
            URL = _results[listView1.SelectedIndices[0]].Url;
        }
    }
}
