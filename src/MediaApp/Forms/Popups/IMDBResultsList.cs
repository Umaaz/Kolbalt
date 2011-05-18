using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MediaApp.Data.Web;
using MediaApp.Data.Web.IMDB;

namespace MediaApp.Forms.Popups
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
                if (imdbResult.PicUrl != "/images/b.gif" && !String.IsNullOrEmpty(imdbResult.PicUrl))
                {
                    var pic = new DownloadImage(imdbResult.PicUrl);
                    pic.Download();
                    il.Images.Add(pic.GetImage());
                    item = new ListViewItem(new[] {imdbResult.Title, imdbResult.Year, imdbResult.IMDBIDUrl}) {ImageIndex = count++};
                }
                else
                {
                    il.Images.Add(Properties.Resources.no_image);
                    item = new ListViewItem(new[] { imdbResult.Title, imdbResult.Year, imdbResult.IMDBIDUrl }) { ImageIndex = count++ };
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
            URL = _results[listView1.SelectedIndices[0]].IMDBIDUrl;
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = listView1.SelectedItems[0];
            var url = item.SubItems[2].Text;
            if(url != "")
            {
                System.Diagnostics.Process.Start("http://www.imdb.com/title/tt" + url);
            }
            
        }

        
    }
}
