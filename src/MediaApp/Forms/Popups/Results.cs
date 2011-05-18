using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MediaApp.Data.Web;
using MediaApp.Domain.Model;
using MediaApp.Forms.UserControls.Settings;

namespace MediaApp.Forms.Popups
{
    public partial class Results : Form
    {
        private int _previousIndex;
        private ResultsTemplate _cont = null;
        private ImageList _il = new ImageList();
        private String _previousId = "";
        
        #region Film Dictionary
        private Dictionary<string, FilmResult> _filmDic = new Dictionary<string, FilmResult>();

        void ReplaceFilm(FilmResult film, String path)
        {
            if (_filmDic.ContainsKey(path))
                _filmDic[path] = film;
        }

        public List<FilmResult> GetFilms()
        {
            return _filmDic.Values.ToList();
        }

        void AddFilm(FilmResult film)
        {
            if (!_filmDic.ContainsKey(film.FilmPath))
                _filmDic[film.FilmPath] = film;
        }

        void DeleteFilm(Film film)
        {
            if (HasFilm(film.FilmPath))
                _filmDic.Remove(film.FilmPath);
        }

        FilmResult GetFilm(String filmPath)
        {
            FilmResult film;
            _filmDic.TryGetValue(filmPath, out film);
            return film;
        }

        bool HasFilm(String filmPath)
        {
            return _filmDic.ContainsKey(filmPath);
        }
        #endregion

        public Results(IList<FilmResult> filmstolist)
        {
            InitializeComponent();
            foreach (var film in filmstolist)
            {
                AddFilm(film);
            }
            PopulateList();
            if (filmstolist.Count > 0)
            {
                var film = filmstolist[0];
                ShowControl(film, film.Title);
            }
        }

        public void PopulateList()
        {
            listView1.Groups.Clear();
            listView1.Items.Clear();
            var count = 0;
            listView1.Groups.Add(new ListViewGroup("Films"));
            listView1.Groups.Add(new ListViewGroup("Possible Errors"));
            listView1.Groups.Add(new ListViewGroup("Not Found"));
            listView1.View = View.Tile;
            _il.ImageSize = new Size(32, 32);
            listView1.LargeImageList = _il;
            foreach (var film in _filmDic.Values)
            {
                ListViewItem item;
                if (film.PicURL != "/images/b.gif" && !string.IsNullOrEmpty(film.PicURL))
                {
                    var pic = new DownloadImage(film.PicURL);
                    pic.Download();
                    var picture = pic.GetImage();
                        _il.Images.Add(picture ?? Properties.Resources.no_image);
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear, film.FilmPath }) { ImageIndex = count++ };
                }
                else
                {
                    _il.Images.Add(Properties.Resources.no_image);
                    item = new ListViewItem(new[] { film.Title, film.ReleaseYear, film.FilmPath }) {ImageIndex = count++};
                }
                if (film.PossibleErrors.HasValue)
                    item.Group = film.PossibleErrors.Value ? listView1.Groups[1] : listView1.Groups[0];
                else
                {
                    item.SubItems[0].Text = film.FilmPath;
                    item.SubItems[1].Text = "";
                    item.SubItems[2].Text = film.FilmPath;
                    item.Group = listView1.Groups[2];
                }
                listView1.Items.Add(item);
            }
        }

        private ImageList GetImageList(Film film)
        {
            var nil = new ImageList {ImageSize = new Size(32, 32)};
            for (int i = 0; i < _il.Images.Count; i++)
            {
                if (i == _previousIndex)
                {
                    if (film.PicURL != "/images/b.gif" && !string.IsNullOrEmpty(film.PicURL))
                    {
                        var pic = new DownloadImage(film.PicURL);
                        pic.Download();
                        nil.Images.Add(pic.GetImage() ?? Properties.Resources.no_image);
                    }
                    else
                    {
                        nil.Images.Add(Properties.Resources.no_image);
                    }
                }
                else
                {
                    nil.Images.Add(_il.Images[i]);
                }
            }
            return nil;
        }
        
        private void Replace()
        {
            var film = GetFilm(_previousId);
            var nil = GetImageList(film);
            listView1.LargeImageList = nil;
            _il = nil;
            listView1.Items[_previousIndex].SubItems[0].Text = film.Title;
            listView1.Items[_previousIndex].SubItems[1].Text = film.ReleaseYear;
        }

        private void Build()
        {
            Text = "Results - ";
            if(_previousId != "")
                Replace();
            panel1.Controls.Clear();
            if (listView1.SelectedIndices.Count > 0)
            {
                var film = GetFilm(listView1.SelectedItems[0].SubItems[2].Text);
                Text += film.FilmPath;
                
                ShowControl(film,film.Title);
            }
            _previousIndex = listView1.SelectedIndices[0];
            _previousId = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void ShowControl(FilmResult film, string title)
        {
            _cont = new ResultsTemplate(film, title);
            panel1.Controls.Add(_cont);
            _cont.Dock = DockStyle.Fill;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            SaveCurrent();
            Build();
        }

        private void SaveCurrent()
        {
            ReplaceFilm(ResultsTemplate.Film, ResultsTemplate.Film.FilmPath);
        }

        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
                return;
            var index = listView1.SelectedIndices[0];
            DeleteFilm(GetFilm(listView1.SelectedItems[0].SubItems[2].Text));
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            //does a control remove a image from image list if the item using tha timage is removed? i doubt it
            listView1.LargeImageList.Images.RemoveAt(index);
            _previousId = "";
            index = index == 0 ? index : index - 1;
            var prevFilm = GetFilm(listView1.Items[index].SubItems[2].Text);
            ShowControl(prevFilm, prevFilm.Title);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            ReplaceFilm(ResultsTemplate.Film, ResultsTemplate.Film.FilmPath);
        }
    }
}
