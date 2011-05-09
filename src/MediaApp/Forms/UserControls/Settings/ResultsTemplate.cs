using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediaApp.Data.Items;
using MediaApp.Data.Web.IMDB;
using MediaApp.Domain.Model;
using MediaApp.Forms.Popups;

namespace MediaApp.Forms.UserControls.Settings
{
    public partial class ResultsTemplate : UserControl
    {
        public static Film Film { get; set; }
        
        public ResultsTemplate()
        {
            Film = null;
        }
        
        public ResultsTemplate(Film film)
        {
            InitializeComponent();
            Film = film;
            populate();
            lbl_filepath.Text = Film.FilmPath;
        }

        private void populate()
        {
            txtb_Title.Text = Film.Title;

            txtb_RunTime.Text = Film.RunTime.ToString();
            txtb_IMDBURL.Text = "http://www.imdb.com/title/tt" + Film.IMDBId;
            txtb_Synopsis.Text = Film.Synopsis;
            txtb_Keywords.Text = Film.Keywords;
            txtb_Year.Text = Film.ReleaseYear;

            var data = Film.Cast.Select(x => new { x.Character, PersonIMDBID = x.Person.IMDBID, x.Person.Name }).ToList();
            dataGridView1.DataSource = data.ToArray();
            
            lstb_genres.DataSource = Film.Genre.Select(x => new GenreListBoxItem(x.Id, x.Type)).ToList();
            lstb_Directors.DataSource = Film.Director.Select(x => new PersonListBoxItem(x.Id,x.IMDBID, x.Name)).ToList();
            lstb_Writers.DataSource = Film.Writers.Select(x => new PersonListBoxItem(x.Id,x.IMDBID, x.Name)).ToList();
        }

        private void btn_rescan_Click(object sender, System.EventArgs e)
        {
            Scan(txtb_IMDBURL.Text);
        }

        private void Scan(String url)
        {

            if (Regex.IsMatch(url, @"^http://www.IMDB.com/title/tt\d\d\d\d\d\d\d$", RegexOptions.IgnoreCase) || Regex.IsMatch(url, @"^http://www.IMDB.com/title/tt\d\d\d\d\d\d\d/$", RegexOptions.IgnoreCase))
            {
                ExecuteScan(url);
            }
            else if(Regex.IsMatch(url,@"\d\d\d\d\d\d\d"))
            {
                ExecuteScan("http://www.IMDB.com/title/tt" +url);
            }
            else
            {
                MessageBox.Show(
                    @"Mismatch in IMDB URL!
Expected ""http://www.IMDB.com/title/tt"" followed by a 7 digit number, or just a 7 digit number!",
                    "Error - Input mismatch!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteScan(string url)
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
                if ((Film)ee.UserState != null)
                {
                    var path = Film.FilmPath;
                    Film = (Film) ee.UserState;
                    Film.FilmPath = path;
                }
                else
                    if (MessageBox.Show("No film found!\n Check URL!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Retry)
                    {
                        Scan(url);
                    }
            };
            bg.RunWorkerCompleted += (s, ee) =>
            {
                populate();
                panel1.Enabled = true;
                panel2.Visible = false;
            };

            bg.RunWorkerAsync();
        }

        
        private void txtb_Title_TextChanged(object sender, System.EventArgs e)
        {
            Film.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtb_Title.Text);
        }

        private void txtb_RunTime_TextChanged(object sender, System.EventArgs e)
        {
            if(Regex.IsMatch(txtb_RunTime.Text,@"/([0-9])/"))
                Film.RunTime = int.Parse(txtb_RunTime.Text);
        }

        private void txtb_Keywords_TextChanged(object sender, System.EventArgs e)
        {
            Film.Keywords = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtb_Keywords.Text);
        }

        private void txtb_Synopsis_TextChanged(object sender, System.EventArgs e)
        {
            Film.Synopsis = txtb_Synopsis.Text;
        }

        private void btn_add_Click(object sender, System.EventArgs e)
        {
            //add genre
            string value = null;  
            if(InputBox.Show("New Genre","Please enter the new genre","example: 'comedy'",ref value) == DialogResult.OK)
            {
                Film.Genre.Add(new FilmType
                                        {
                                            Type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value)
                                        });
            }
            populate();
        }

        private void btn_delete_Click(object sender, System.EventArgs e)
        {
            //delete genre
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

                role.Character = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value[0]);
                role.Person.IMDBID = value[1];
                role.Person.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value[2]);

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
            while (true)
            {
                if (InputBox.Show("Add new cast member - Unrecommended", prompts, defualts, ref value, true) != DialogResult.OK) 
                    return;
                if (Regex.IsMatch(value[1], "^[0-9]{7}$"))
                {
                    Film.Cast.Add(new Role
                                      {
                                          Character = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value[0]),
                                          Person = new Person
                                                       {
                                                           IMDBID = value[1],
                                                           Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value[2])
                                                       }
                                      });
                    populate();
                    return;
                }
                if (MessageBox.Show("Invalid IMDB ID, expected a 7 didigt number.", "IMDB ID - Validation error.", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    defualts = value.ToArray();
                }
                else
                {
                    return;
                }
            }
            
        }


        private void txtb_Year_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(txtb_Year.Text,@"^[0-9]{4}$"))
            {
                Film.ReleaseYear = txtb_Year.Text;
            }
        }

        private void btn_otherresults_Click(object sender, EventArgs e)
        {
            var results = new List<IMDBResult>();
            var bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            panel1.Enabled = false;
            panel2.Visible = true;
            bgw.ProgressChanged += (o, args) =>
                                       {
                                           results = (List<IMDBResult>)args.UserState;
                                       };
            bgw.DoWork += (o, args) =>
                              {
                                  var worker = o as BackgroundWorker;
                                  worker.ReportProgress(100,IMDBSearch.SearchIMDBByTitle(Film.Title));
                              };
            bgw.RunWorkerCompleted += (o, args) =>
                                          {
                                              if (results.Count != 0)
                                              {
                                                  var cont = new IMDBResultsList(results, Film.Title);
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
                                              panel1.Enabled = true;
                                              panel2.Visible = false;
                                          };
            bgw.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete director
            if(lstb_Directors.SelectedIndices.Count > 0)
            {
                Film.Director.RemoveAt(lstb_Directors.SelectedIndex);
                populate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newDirector = AddPerson(new[] {"IMDB ID", "Director Name"}, "New Director");
            if(newDirector == null)
                return;
            Film.Director.Add(newDirector);
            populate();
        }

        private Person AddPerson(string[] prompts, string title)
        {
            var defaults = new[] { "Example \"0012487\"", "Example \"Joe Bloggs\"" };
            var value = new List<string>();
            while (true)
            {
                if (InputBox.Show(title, prompts, defaults, ref value, true) != DialogResult.OK)
                    return null;
                if(Regex.IsMatch(value[0],"^[0-9]{7}$"))
                    return new Person
                               {
                                   IMDBID = value[0],
                                   Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value[1])
                                };
                if (MessageBox.Show("Invalid IMDB ID, expected a 7 digit number.", "IMDB ID - Validation error.", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    defaults = value.ToArray();
                }
                else
                {
                    return null;
                }
            }
        }

        private void btn_addWriter_Click(object sender, EventArgs e)
        {
            var newWriter = AddPerson(new[] { "IMDB ID", "Writer Name" }, "New Writer");
            if (newWriter == null)
                return;
            Film.Writers.Add(newWriter);
            populate();
        }

        private void btn_deleteWriter_Click(object sender, EventArgs e)
        {
            //delete Writer
            if(lstb_Writers.SelectedIndices.Count > 0)
            {
                Film.Writers.RemoveAt(lstb_Writers.SelectedIndex);
                populate();
            }
        }

        private void SetToolTip(object sender)
        {
            var cont = sender as ListBox;
            var item = (ListBoxItem)cont.SelectedItem;
            var tip = item.ToolTipText();
            toolTip1.SetToolTip(cont,tip);
        }

        private void lstb_genres_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetToolTip(sender);
        }

        private void lstb_Directors_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetToolTip(sender);
        }

        private void lstb_Writers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetToolTip(sender);
        }
    }
}
