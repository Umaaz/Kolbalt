namespace MediaApp.Forms.UserControls
{
    partial class FilmDetails
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_picloading = new System.Windows.Forms.Label();
            this.pb_Filmposter = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_Directors = new System.Windows.Forms.Label();
            this.lbl_stars = new System.Windows.Forms.Label();
            this.lbl_rating = new System.Windows.Forms.Label();
            this.lbl_Year = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.llbl_title = new System.Windows.Forms.LinkLabel();
            this.llbl_year = new System.Windows.Forms.LinkLabel();
            this.llbl_director = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.llbl_Star1 = new System.Windows.Forms.LinkLabel();
            this.llbl_star2 = new System.Windows.Forms.LinkLabel();
            this.lbl_Frating = new System.Windows.Forms.Label();
            this.lbl_loading = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Filmposter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbl_picloading);
            this.splitContainer1.Panel1.Controls.Add(this.pb_Filmposter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(610, 87);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbl_picloading
            // 
            this.lbl_picloading.AutoSize = true;
            this.lbl_picloading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.lbl_picloading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_picloading.Location = new System.Drawing.Point(15, 39);
            this.lbl_picloading.Name = "lbl_picloading";
            this.lbl_picloading.Size = new System.Drawing.Size(54, 13);
            this.lbl_picloading.TabIndex = 16;
            this.lbl_picloading.Text = "Loading...";
            // 
            // pb_Filmposter
            // 
            this.pb_Filmposter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.pb_Filmposter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Filmposter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Filmposter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Filmposter.Location = new System.Drawing.Point(0, 0);
            this.pb_Filmposter.Name = "pb_Filmposter";
            this.pb_Filmposter.Size = new System.Drawing.Size(76, 87);
            this.pb_Filmposter.TabIndex = 0;
            this.pb_Filmposter.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.splitContainer2.Panel2.Controls.Add(this.lbl_loading);
            this.splitContainer2.Size = new System.Drawing.Size(530, 87);
            this.splitContainer2.SplitterDistance = 232;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.llbl_year);
            this.panel1.Controls.Add(this.llbl_director);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lbl_Frating);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 87);
            this.panel1.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbl_Directors);
            this.panel4.Controls.Add(this.lbl_stars);
            this.panel4.Controls.Add(this.lbl_rating);
            this.panel4.Controls.Add(this.lbl_Year);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(72, 69);
            this.panel4.TabIndex = 16;
            // 
            // lbl_Directors
            // 
            this.lbl_Directors.AutoSize = true;
            this.lbl_Directors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_Directors.Location = new System.Drawing.Point(17, 10);
            this.lbl_Directors.Name = "lbl_Directors";
            this.lbl_Directors.Size = new System.Drawing.Size(50, 13);
            this.lbl_Directors.TabIndex = 1;
            this.lbl_Directors.Text = "Director: ";
            // 
            // lbl_stars
            // 
            this.lbl_stars.AutoSize = true;
            this.lbl_stars.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_stars.Location = new System.Drawing.Point(30, 23);
            this.lbl_stars.Name = "lbl_stars";
            this.lbl_stars.Size = new System.Drawing.Size(37, 13);
            this.lbl_stars.TabIndex = 2;
            this.lbl_stars.Text = "Stars: ";
            // 
            // lbl_rating
            // 
            this.lbl_rating.AutoSize = true;
            this.lbl_rating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_rating.Location = new System.Drawing.Point(-2, 49);
            this.lbl_rating.Name = "lbl_rating";
            this.lbl_rating.Size = new System.Drawing.Size(69, 13);
            this.lbl_rating.TabIndex = 4;
            this.lbl_rating.Text = "IMDB rating: ";
            // 
            // lbl_Year
            // 
            this.lbl_Year.AutoSize = true;
            this.lbl_Year.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_Year.Location = new System.Drawing.Point(32, 36);
            this.lbl_Year.Name = "lbl_Year";
            this.lbl_Year.Size = new System.Drawing.Size(35, 13);
            this.lbl_Year.TabIndex = 3;
            this.lbl_Year.Text = "Year: ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbl_Title);
            this.panel3.Controls.Add(this.llbl_title);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 16);
            this.panel3.TabIndex = 15;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(33, 13);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "Title: ";
            // 
            // llbl_title
            // 
            this.llbl_title.AutoSize = true;
            this.llbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.llbl_title.LinkColor = System.Drawing.Color.DodgerBlue;
            this.llbl_title.Location = new System.Drawing.Point(39, 1);
            this.llbl_title.Name = "llbl_title";
            this.llbl_title.Size = new System.Drawing.Size(105, 13);
            this.llbl_title.TabIndex = 5;
            this.llbl_title.TabStop = true;
            this.llbl_title.Text = "Title of file goes here";
            this.llbl_title.Visible = false;
            // 
            // llbl_year
            // 
            this.llbl_year.AutoSize = true;
            this.llbl_year.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.llbl_year.LinkColor = System.Drawing.Color.DodgerBlue;
            this.llbl_year.Location = new System.Drawing.Point(74, 53);
            this.llbl_year.Name = "llbl_year";
            this.llbl_year.Size = new System.Drawing.Size(29, 13);
            this.llbl_year.TabIndex = 15;
            this.llbl_year.TabStop = true;
            this.llbl_year.Text = "Year";
            this.llbl_year.Visible = false;
            this.llbl_year.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_year_LinkClicked);
            // 
            // llbl_director
            // 
            this.llbl_director.AutoSize = true;
            this.llbl_director.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.llbl_director.LinkColor = System.Drawing.Color.DodgerBlue;
            this.llbl_director.Location = new System.Drawing.Point(74, 27);
            this.llbl_director.Name = "llbl_director";
            this.llbl_director.Size = new System.Drawing.Size(145, 13);
            this.llbl_director.TabIndex = 6;
            this.llbl_director.TabStop = true;
            this.llbl_director.Text = "First Director name goes here";
            this.llbl_director.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.llbl_Star1);
            this.panel2.Controls.Add(this.llbl_star2);
            this.panel2.Location = new System.Drawing.Point(74, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 14);
            this.panel2.TabIndex = 15;
            // 
            // llbl_Star1
            // 
            this.llbl_Star1.AutoSize = true;
            this.llbl_Star1.Dock = System.Windows.Forms.DockStyle.Left;
            this.llbl_Star1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.llbl_Star1.LinkColor = System.Drawing.Color.DodgerBlue;
            this.llbl_Star1.Location = new System.Drawing.Point(30, 0);
            this.llbl_Star1.Name = "llbl_Star1";
            this.llbl_Star1.Size = new System.Drawing.Size(30, 13);
            this.llbl_Star1.TabIndex = 7;
            this.llbl_Star1.TabStop = true;
            this.llbl_Star1.Text = "star1";
            this.llbl_Star1.Visible = false;
            // 
            // llbl_star2
            // 
            this.llbl_star2.AutoSize = true;
            this.llbl_star2.Dock = System.Windows.Forms.DockStyle.Left;
            this.llbl_star2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.llbl_star2.LinkColor = System.Drawing.Color.DodgerBlue;
            this.llbl_star2.Location = new System.Drawing.Point(0, 0);
            this.llbl_star2.Name = "llbl_star2";
            this.llbl_star2.Size = new System.Drawing.Size(30, 13);
            this.llbl_star2.TabIndex = 10;
            this.llbl_star2.TabStop = true;
            this.llbl_star2.Text = "star2";
            this.llbl_star2.Visible = false;
            // 
            // lbl_Frating
            // 
            this.lbl_Frating.AutoSize = true;
            this.lbl_Frating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_Frating.Location = new System.Drawing.Point(74, 66);
            this.lbl_Frating.Name = "lbl_Frating";
            this.lbl_Frating.Size = new System.Drawing.Size(33, 13);
            this.lbl_Frating.TabIndex = 13;
            this.lbl_Frating.Text = "rating";
            this.lbl_Frating.Visible = false;
            // 
            // lbl_loading
            // 
            this.lbl_loading.AutoSize = true;
            this.lbl_loading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_loading.Location = new System.Drawing.Point(3, 41);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(54, 13);
            this.lbl_loading.TabIndex = 14;
            this.lbl_loading.Text = "Loading...";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FilmDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FilmDetails";
            this.Size = new System.Drawing.Size(610, 87);
            this.Load += new System.EventHandler(this.UCFilmBase_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Filmposter)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pb_Filmposter;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_Frating;
        private System.Windows.Forms.Label lbl_Directors;
        private System.Windows.Forms.LinkLabel llbl_title;
        private System.Windows.Forms.Label lbl_rating;
        private System.Windows.Forms.Label lbl_Year;
        private System.Windows.Forms.LinkLabel llbl_director;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_stars;
        private System.Windows.Forms.LinkLabel llbl_star2;
        private System.Windows.Forms.LinkLabel llbl_Star1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_loading;
        private System.Windows.Forms.LinkLabel llbl_year;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label lbl_picloading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;

    }
}
