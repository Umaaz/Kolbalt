using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MediaApp.Domain;
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
        }

        private void Results_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = _films.Select(x => new Data.Items.ComboBoxItem(x.Title)).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _films[_currentIndex] = _cont.Film ?? _films[_currentIndex];
            panel1.Controls.Clear();
            _cont = new ResultsTemplate(_films.ToList()[comboBox1.SelectedIndex],_results[comboBox1.SelectedIndex]);
            panel1.Controls.Add(_cont);
            _currentIndex = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _films[_currentIndex] = _cont.Film;
        }
    }
}
