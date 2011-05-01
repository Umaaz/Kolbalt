using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MediaApp.Domain.Model;
using MediaApp.Forms.UserControls;
using MediaApp.Data.IMDB;

namespace MediaApp.Forms
{
    public partial class Results : Form
    {
        private readonly IList<Film> _films;
        private int _currentIndex;
        private ResultsTemplate _cont = new ResultsTemplate();
        private IList<IList<IMDBResult>> _results;
        public Results(IList<Film> filmstolist, IList<IList<IMDBResult>> results)
        {
            InitializeComponent();
            _films = filmstolist;
            _results = results;
            var il = new ImageList();
            var count = 0;
            listView1.View = View.Tile;
            il.ImageSize = new Size(32, 32);
            listView1.LargeImageList = il;
            foreach (var film in _films)
            {
                ListViewItem item;
                if (film.PicURL != "/images/b.gif")
                {
                    var pic = new Data.DownloadImage(film.PicURL);
                    pic.Download();
                    il.Images.Add(pic.GetImage());
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear }) { ImageIndex = count++ };
                }
                else
                {
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear });
                }
                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _films[_currentIndex] = ResultsTemplate.Film ?? _films[_currentIndex];
            panel1.Controls.Clear();
            if (listView1.SelectedIndices.Count > 0)
            {
                _cont = new ResultsTemplate(_films[listView1.SelectedIndices[0]], _results[listView1.SelectedIndices[0]]);
                panel1.Controls.Add(_cont);
                _cont.Dock = DockStyle.Fill;
                _currentIndex = listView1.SelectedIndices[0];
            }
        }
    }
}
