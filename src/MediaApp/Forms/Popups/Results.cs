using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MediaApp.Data.Web;
using MediaApp.Domain.Model;
using MediaApp.Forms.UserControls.Settings;

namespace MediaApp.Forms.Popups
{
    public partial class Results : Form
    {
        private readonly IList<Film> _films;
        private int _currentIndex;
        private ResultsTemplate _cont = new ResultsTemplate();
        private readonly IList<Film> _possiblefilms;

        public Results(IList<Film> filmstolist, IList<Film> possiblefilmstolist)
        {
            InitializeComponent();
            _films = filmstolist;
            _possiblefilms = possiblefilmstolist;
            PopulateList();
            listView1.Items[0].Selected = true;
            listView1.EnsureVisible(0);
            Build();
        }

        public void PopulateList()
        {
            listView1.Groups.Clear();
            listView1.Items.Clear();
            var il = new ImageList();
            var count = 0;
            listView1.Groups.Add(new ListViewGroup("Films"));
            listView1.Groups.Add(new ListViewGroup("Possible Errors"));
            listView1.View = View.Tile;
            il.ImageSize = new Size(32, 32);
            listView1.LargeImageList = il;
            foreach (var film in _films)
            {
                ListViewItem item;
                if (film.PicURL != "/images/b.gif")
                {
                    var pic = new DownloadImage(film.PicURL);
                    pic.Download();
                    var picture = pic.GetImage();
                    if(picture != null)
                        il.Images.Add(picture);
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear }) { ImageIndex = count++ };
                }
                else
                {
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear });
                }
                item.Group = listView1.Groups[0];
                listView1.Items.Add(item);
            }
            foreach (var film in _possiblefilms)
            {
                ListViewItem item;
                if (film.PicURL != "/images/b.gif" && !string.IsNullOrEmpty(film.PicURL))
                {
                    var pic = new DownloadImage(film.PicURL);
                    pic.Download();
                    il.Images.Add(pic.GetImage());
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear }) { ImageIndex = count++ };
                }
                else
                {
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear });
                }
                item.Group = listView1.Groups[1];
                listView1.Items.Add(item);
            }
        }

        public Results(IList<Film> filmstolist)
        {
            InitializeComponent();
            _films = filmstolist;
            PopulateList();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }
        private void Build()
        {
            if (_currentIndex >= _films.Count)
            {
                _possiblefilms[_currentIndex - _films.Count] = ResultsTemplate.Film ??
                                                               _possiblefilms[_currentIndex - _films.Count];
            }
            else
            {
                _films[_currentIndex] = ResultsTemplate.Film ?? _films[_currentIndex];
            }
            panel1.Controls.Clear();
            if (listView1.SelectedIndices.Count > 0)
            {
                if (listView1.SelectedIndices[0] < _films.Count)
                {
                    _cont = new ResultsTemplate(_films[listView1.SelectedIndices[0]]);
                    panel1.Controls.Add(_cont);
                    _cont.Dock = DockStyle.Fill;
                    _currentIndex = listView1.SelectedIndices[0];
                }
                else
                {
                    var index = listView1.SelectedIndices[0] - _films.Count;
                    _cont = new ResultsTemplate(_possiblefilms[index]);
                    panel1.Controls.Add(_cont);
                    _cont.Dock = DockStyle.Fill;
                    _currentIndex = listView1.SelectedIndices[0];
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            Build();
            PopulateList();
            listView1.Items[_currentIndex].Selected = true;
            listView1.EnsureVisible(_currentIndex);
        }
    }
}
