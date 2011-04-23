using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediaApp.Data.IMDB;
using MediaApp.Data.Items;
using MediaApp.Domain;
using MediaApp.Domain.Model;
using MediaApp.Forms.Popups;

namespace MediaApp.Forms.UserControls
{
    public partial class ResultsTemplate : UserControl
    {
        public static Film Film { get; set; }
        private IList<IMDBResult> Results { get; set; }
        
        public ResultsTemplate()
        {
            Film = null;
            Results = null;
        }
        
        public ResultsTemplate(Film film)
        {
            InitializeComponent();
            Film = film;
            populate();
            lbl_filepath.Text = Film.FilmPath;
        }

        public ResultsTemplate(Film film, IList<IMDBResult> results)
        {
            InitializeComponent();
            Film = film;
            Results = results;
            populate();
            lbl_filepath.Text = Film.FilmPath;
        }

        private void populate()
        {
            txtb_Title.Text = Film.Title;
            txtb_director.Text = Film.Director.Name;
            txtb_RunTime.Text = Film.RunTime.ToString();
            txtb_IMDBURL.Text = "Http://www.imdb.com/title/tt" + Film.IMDBId;
            txtb_Synopsis.Text = Film.Synopsis;
            txtb_Keywords.Text = Film.Keywords;
            txtb_Year.Text = Film.ReleaseYear;

            var data = Film.Cast.Select(x => new { x.Character, PersonIMDBID = x.Person.IMDBID, x.Person.Name }).ToList();
            dataGridView1.DataSource = data.ToArray();
            
            lstb_genres.DataSource = Film.Genre.Select(x => new ListBoxItem(x.Id, x.Type)).ToList();
        }

        private void btn_rescan_Click(object sender, System.EventArgs e)
        {
            Scan(txtb_IMDBURL.Text);
        }

        private void Scan(String url)
        {

            if (Regex.IsMatch(url, @"^http://www.IMDB.com/title/tt\d\d\d\d\d\d\d$", RegexOptions.IgnoreCase) || Regex.IsMatch(url, @"^http://www.IMDB.com/title/tt\d\d\d\d\d\d\d/$", RegexOptions.IgnoreCase))
            {
                var bg = new BackgroundWorker();
                bg.WorkerReportsProgress = true;
                panel1.Enabled = false;
                panel2.Visible = true;
                bg.DoWork += (s, ee) =>
                                 {
                                     var worker = s as BackgroundWorker;
                                     worker.ReportProgress(100, IMDBFilm.GetFilmByUrl(url));
                                 };
                bg.ProgressChanged += (s, ee) =>
                                          {
                                              Film = (Film)ee.UserState;
                                          };
                bg.RunWorkerCompleted += (s, ee) =>
                                             {
                                                 populate();
                                                 panel1.Enabled = true;
                                                 panel2.Visible = false;
                                             };
                    
                bg.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show(
                    @"Mismatch in IMDB URL!
Expected ""http://www.IMDB.com/title/tt"" followed by a 6 digit number!",
                    "Error - Input mismatch!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void txtb_Title_TextChanged(object sender, System.EventArgs e)
        {
            Film.Title = txtb_Title.Text;
        }

        private void txtb_RunTime_TextChanged(object sender, System.EventArgs e)
        {
            if(Regex.IsMatch(txtb_RunTime.Text,@"/([0-9])/"))
                Film.RunTime = int.Parse(txtb_RunTime.Text);
        }

        private void txtb_Keywords_TextChanged(object sender, System.EventArgs e)
        {
            Film.Keywords = txtb_Keywords.Text;
        }

        private void txtb_Synopsis_TextChanged(object sender, System.EventArgs e)
        {
            Film.Synopsis = txtb_Synopsis.Text;
        }

        private void btn_add_Click(object sender, System.EventArgs e)
        {
            string value = null;  
            if(InputBox.Show("New Genre","Please enter the new genre","example: 'comedy'",ref value) == DialogResult.OK)
            {
                Film.Genre.Add(new FilmType
                                        {
                                            Type = value
                                        });
            }
            populate();
        }

        private void btn_delete_Click(object sender, System.EventArgs e)
        {
            if (lstb_genres.SelectedIndices.Count > 0)
            {
                Film.Genre.RemoveAt(lstb_genres.SelectedIndex);
                populate();
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            var value = new List<String>();
            var cast = new[] { dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString() };
            var prompts = new[] { "Character Name", "Actor IMDB ID", "Actor Name" };
            if (InputBox.Show("Cast details - Unrecommended", prompts, cast, ref value, true) == DialogResult.OK)
            {
                var role = Film.Cast.Where(x => x.Person.IMDBID == dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).First();

                role.Character = value[0];
                role.Person.IMDBID = value[1];
                role.Person.Name = value[2];

                populate();
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Delete cast member?", "Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                for (var i = 0; i < Film.Cast.Count; i++)
                {
                    if(Film.Cast[i].Person.IMDBID == (String) dataGridView1.SelectedRows[0].Cells[1].Value)
                    {
                        Film.Cast.RemoveAt(i);
                    }
                }
            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            var value = new List<String>();
            var prompts = new[] { "Character Name", "Actor IMDB ID", "Actor Name" };
            var defualts = new[] { "Please enter character name", "Please enter Actor IMDB ID", "Please enter Actor Name" };
            if (InputBox.Show("Add new cast member - Unrecommended", prompts, defualts, ref value, true) == DialogResult.OK)
            {
                Film.Cast.Add(new Role
                {
                    Character = value[0],
                    Person = new Person
                    {
                        IMDBID = value[1],
                        Name = value[2]
                    }
                });
                populate();
            }
        }

        private void txtb_Year_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(txtb_Year.Text,@"^\d\d\d\d$"))
            {
                Film.ReleaseYear = txtb_Year.Text;
            }
        }

        private void btn_otherresults_Click(object sender, EventArgs e)
        {
            if (Results.Count != 0)
            {
                var cont = new IMDBResultsList(Results, Film.Title);
                Enabled = false;
                if (cont.ShowDialog() == DialogResult.OK)
                {
                    Scan("http://www.imdb.com/title/tt" + cont.URL);
                }
                Enabled = true;
            }
            else
            {
                MessageBox.Show("Sorry there are no other results!", "Sorry", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var value = new List<string>();
            var director = new[] { Film.Director.IMDBID.ToString(), Film.Director.Name };
            var prompts = new[] { "Director IMDB ID", "Director Name" };
            if (InputBox.Show("Director details", prompts, director, ref value) == DialogResult.OK)
            {
                Film.Director.IMDBID = value[0];
                Film.Director.Name = value[1];
                populate();
            }
        }
    }
}
