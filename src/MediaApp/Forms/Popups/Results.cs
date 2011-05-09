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
        private readonly List<Film> _searchFilms;
        private int _currentIndex;
        private ResultsTemplate _cont = null;
        private readonly IList<Film> _possiblefilms;
        private ImageList il = new ImageList();

        public Results(IList<Film> filmstolist, IList<Film> possiblefilmstolist)
        {
            InitializeComponent();
            _films = filmstolist;
            _searchFilms = new List<Film>(_films);
            _searchFilms.AddRange(possiblefilmstolist);
            _possiblefilms = possiblefilmstolist;
            PopulateList();
            ShowControl(_films.Count > 0 ? _films[0] : _possiblefilms[0], _searchFilms[0].Title);
        }

        public void PopulateList()
        {
            listView1.Groups.Clear();
            listView1.Items.Clear();
            var count = 0;
            listView1.Groups.Add(new ListViewGroup("Films"));
            listView1.Groups.Add(new ListViewGroup("Possible Errors"));
            listView1.View = View.Tile;
            il.ImageSize = new Size(32, 32);
            listView1.LargeImageList = il;
            foreach (var film in _films)
            {
                ListViewItem item;
                if (film.PicURL != "/images/b.gif" && !string.IsNullOrEmpty(film.PicURL))
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
                    il.Images.Add(Properties.Resources.no_image);
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear }) {ImageIndex = count++};
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
                    il.Images.Add(Properties.Resources.no_image);
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear }){ ImageIndex = count++};
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

        private void ReplaceAtIndex()
        {
            if(_currentIndex >= _films.Count)
            {
                var film = _possiblefilms[_currentIndex - _films.Count];
                var pic = new DownloadImage(film.PicURL);
                pic.Download();
                var nil = new ImageList {ImageSize = new Size(32, 32)};
                for (int i = 0; i < il.Images.Count; i++)
                {
                    if(i == _currentIndex)
                    {
                        nil.Images.Add(pic.GetImage());
                    }
                    else
                    {
                        nil.Images.Add(il.Images[i]);
                    }
                }
                listView1.LargeImageList = nil;
                listView1.Items[_currentIndex].SubItems[0].Text = film.Title;
                listView1.Items[_currentIndex].SubItems[1].Text = film.ReleaseYear;
            }
            else
            {
                var film = _films[_currentIndex];
                var pic = new DownloadImage(film.PicURL);
                pic.Download();
                var nil = new ImageList {ImageSize = new Size(32, 32)};
                for (int i = 0; i < il.Images.Count; i++)
                {
                    if (i == _currentIndex)
                    {
                        nil.Images.Add(pic.GetImage());
                    }
                    else
                    {
                        nil.Images.Add(il.Images[i]);
                    }
                }
                listView1.LargeImageList = nil;
                listView1.Items[_currentIndex].SubItems[0].Text = film.Title;
                listView1.Items[_currentIndex].SubItems[1].Text = film.ReleaseYear;
            }
        }

        private void Build()
        {
            if (_currentIndex >= _films.Count)
            {
                _possiblefilms[_currentIndex - _films.Count] = ResultsTemplate.Film ??
                                                               _possiblefilms[_currentIndex - _films.Count];
                ReplaceAtIndex();
            }
            else
            {
                _films[_currentIndex] = ResultsTemplate.Film ?? _films[_currentIndex];
                ReplaceAtIndex();
            }
            panel1.Controls.Clear();
            if (listView1.SelectedIndices.Count > 0)
            {
                if (listView1.SelectedIndices[0] < _films.Count)
                {
                    ShowControl(_films[listView1.SelectedIndices[0]], _searchFilms[listView1.SelectedIndices[0]].Title);
                }
                else
                {
                    var index = listView1.SelectedIndices[0] - _films.Count;
                    ShowControl(_possiblefilms[index], _searchFilms[listView1.SelectedIndices[0]].Title);
                }
            }
            _currentIndex = listView1.SelectedIndices[0];
        }
        private void ShowControl(Film film, string title)
        {
            _cont = new ResultsTemplate(film, title);
            panel1.Controls.Add(_cont);
            _cont.Dock = DockStyle.Fill;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            Build();
        }
    }
}
