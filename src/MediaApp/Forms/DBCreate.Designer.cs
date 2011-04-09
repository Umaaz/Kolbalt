namespace MediaApp.Forms
{
    partial class DbCreate
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() //see this method, yes, 
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_tv = new System.Windows.Forms.TabPage();
            this.tp_film = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_PMatches = new System.Windows.Forms.CheckBox();
            this.chk_AllMatches = new System.Windows.Forms.CheckBox();
            this.chk_ApproxMatches = new System.Windows.Forms.CheckBox();
            this.chk_PopTitles = new System.Windows.Forms.CheckBox();
            this.chk_ExactMatches = new System.Windows.Forms.CheckBox();
            this.chk_TakeFirstFilm = new System.Windows.Forms.CheckBox();
            this.btn_Build = new System.Windows.Forms.Button();
            this.chk_DisplayFilmResults = new System.Windows.Forms.CheckBox();
            this.lbl_Current = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_Addfilm = new System.Windows.Forms.Button();
            this.btn_RemoveFilm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lisb_films = new System.Windows.Forms.ListBox();
            this.tp_music = new System.Windows.Forms.TabPage();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tp_film.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_tv);
            this.tabControl1.Controls.Add(this.tp_film);
            this.tabControl1.Controls.Add(this.tp_music);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 466);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_tv
            // 
            this.tp_tv.BackColor = System.Drawing.SystemColors.Control;
            this.tp_tv.Location = new System.Drawing.Point(4, 22);
            this.tp_tv.Name = "tp_tv";
            this.tp_tv.Padding = new System.Windows.Forms.Padding(3);
            this.tp_tv.Size = new System.Drawing.Size(456, 440);
            this.tp_tv.TabIndex = 0;
            this.tp_tv.Text = "TV";
            // 
            // tp_film
            // 
            this.tp_film.BackColor = System.Drawing.SystemColors.Control;
            this.tp_film.Controls.Add(this.groupBox1);
            this.tp_film.Controls.Add(this.btn_Addfilm);
            this.tp_film.Controls.Add(this.btn_RemoveFilm);
            this.tp_film.Controls.Add(this.label1);
            this.tp_film.Controls.Add(this.lisb_films);
            this.tp_film.Location = new System.Drawing.Point(4, 22);
            this.tp_film.Name = "tp_film";
            this.tp_film.Padding = new System.Windows.Forms.Padding(3);
            this.tp_film.Size = new System.Drawing.Size(456, 440);
            this.tp_film.TabIndex = 1;
            this.tp_film.Text = "Film";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chk_TakeFirstFilm);
            this.groupBox1.Controls.Add(this.btn_Build);
            this.groupBox1.Controls.Add(this.chk_DisplayFilmResults);
            this.groupBox1.Controls.Add(this.lbl_Current);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(11, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 228);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 11;
            this.button1.Text = "Build";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_PMatches);
            this.groupBox2.Controls.Add(this.chk_AllMatches);
            this.groupBox2.Controls.Add(this.chk_ApproxMatches);
            this.groupBox2.Controls.Add(this.chk_PopTitles);
            this.groupBox2.Controls.Add(this.chk_ExactMatches);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(278, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 147);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Include";
            // 
            // chk_PMatches
            // 
            this.chk_PMatches.AutoSize = true;
            this.chk_PMatches.Location = new System.Drawing.Point(16, 46);
            this.chk_PMatches.Name = "chk_PMatches";
            this.chk_PMatches.Size = new System.Drawing.Size(99, 17);
            this.chk_PMatches.TabIndex = 9;
            this.chk_PMatches.Text = "Partial Matches";
            this.chk_PMatches.UseVisualStyleBackColor = true;
            this.chk_PMatches.CheckedChanged += new System.EventHandler(this.Chk_PMatches_CheckedChanged);
            // 
            // chk_AllMatches
            // 
            this.chk_AllMatches.AutoSize = true;
            this.chk_AllMatches.Location = new System.Drawing.Point(16, 115);
            this.chk_AllMatches.Name = "chk_AllMatches";
            this.chk_AllMatches.Size = new System.Drawing.Size(37, 17);
            this.chk_AllMatches.TabIndex = 5;
            this.chk_AllMatches.Text = "All";
            this.chk_AllMatches.UseVisualStyleBackColor = true;
            this.chk_AllMatches.CheckedChanged += new System.EventHandler(this.chk_AllMatches_CheckedChanged);
            // 
            // chk_ApproxMatches
            // 
            this.chk_ApproxMatches.AutoSize = true;
            this.chk_ApproxMatches.Location = new System.Drawing.Point(16, 92);
            this.chk_ApproxMatches.Name = "chk_ApproxMatches";
            this.chk_ApproxMatches.Size = new System.Drawing.Size(103, 17);
            this.chk_ApproxMatches.TabIndex = 8;
            this.chk_ApproxMatches.Text = "Approx Matches";
            this.chk_ApproxMatches.UseVisualStyleBackColor = true;
            this.chk_ApproxMatches.CheckedChanged += new System.EventHandler(this.chk_ApproxMatches_CheckedChanged);
            // 
            // chk_PopTitles
            // 
            this.chk_PopTitles.AutoSize = true;
            this.chk_PopTitles.Location = new System.Drawing.Point(16, 19);
            this.chk_PopTitles.Name = "chk_PopTitles";
            this.chk_PopTitles.Size = new System.Drawing.Size(90, 17);
            this.chk_PopTitles.TabIndex = 6;
            this.chk_PopTitles.Text = "Popular Titles";
            this.chk_PopTitles.UseVisualStyleBackColor = true;
            this.chk_PopTitles.CheckedChanged += new System.EventHandler(this.chk_PopTitles_CheckedChanged);
            // 
            // chk_ExactMatches
            // 
            this.chk_ExactMatches.AutoSize = true;
            this.chk_ExactMatches.Location = new System.Drawing.Point(16, 69);
            this.chk_ExactMatches.Name = "chk_ExactMatches";
            this.chk_ExactMatches.Size = new System.Drawing.Size(97, 17);
            this.chk_ExactMatches.TabIndex = 7;
            this.chk_ExactMatches.Text = "Exact Matches";
            this.chk_ExactMatches.UseVisualStyleBackColor = true;
            this.chk_ExactMatches.CheckedChanged += new System.EventHandler(this.chk_ExactMatches_CheckedChanged);
            // 
            // chk_TakeFirstFilm
            // 
            this.chk_TakeFirstFilm.AutoSize = true;
            this.chk_TakeFirstFilm.Enabled = false;
            this.chk_TakeFirstFilm.Location = new System.Drawing.Point(278, 19);
            this.chk_TakeFirstFilm.Name = "chk_TakeFirstFilm";
            this.chk_TakeFirstFilm.Size = new System.Drawing.Size(128, 17);
            this.chk_TakeFirstFilm.TabIndex = 4;
            this.chk_TakeFirstFilm.Text = "Take first IMDB result";
            this.chk_TakeFirstFilm.UseVisualStyleBackColor = true;
            this.chk_TakeFirstFilm.CheckedChanged += new System.EventHandler(this.chk_TakeFirstFilm_CheckedChanged);
            // 
            // btn_Build
            // 
            this.btn_Build.Location = new System.Drawing.Point(353, 195);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Size = new System.Drawing.Size(75, 23);
            this.btn_Build.TabIndex = 3;
            this.btn_Build.Text = "Re-Build";
            this.btn_Build.UseVisualStyleBackColor = true;
            this.btn_Build.Click += new System.EventHandler(this.btn_Build_Click);
            // 
            // chk_DisplayFilmResults
            // 
            this.chk_DisplayFilmResults.AutoSize = true;
            this.chk_DisplayFilmResults.Location = new System.Drawing.Point(9, 19);
            this.chk_DisplayFilmResults.Name = "chk_DisplayFilmResults";
            this.chk_DisplayFilmResults.Size = new System.Drawing.Size(186, 17);
            this.chk_DisplayFilmResults.TabIndex = 2;
            this.chk_DisplayFilmResults.Text = "Display search results before build";
            this.chk_DisplayFilmResults.UseVisualStyleBackColor = true;
            this.chk_DisplayFilmResults.CheckedChanged += new System.EventHandler(this.chk_DisplayFilmResults_CheckedChanged);
            // 
            // lbl_Current
            // 
            this.lbl_Current.AutoSize = true;
            this.lbl_Current.Location = new System.Drawing.Point(6, 138);
            this.lbl_Current.Name = "lbl_Current";
            this.lbl_Current.Size = new System.Drawing.Size(57, 13);
            this.lbl_Current.TabIndex = 1;
            this.lbl_Current.Text = "lbl_Current";
            this.lbl_Current.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(6, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(262, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // btn_Addfilm
            // 
            this.btn_Addfilm.Image = global::MediaApp.Properties.Resources.Add;
            this.btn_Addfilm.Location = new System.Drawing.Point(151, 169);
            this.btn_Addfilm.Name = "btn_Addfilm";
            this.btn_Addfilm.Size = new System.Drawing.Size(25, 25);
            this.btn_Addfilm.TabIndex = 4;
            this.btn_Addfilm.UseVisualStyleBackColor = true;
            this.btn_Addfilm.Click += new System.EventHandler(this.btn_Addfilm_Click);
            // 
            // btn_RemoveFilm
            // 
            this.btn_RemoveFilm.Image = global::MediaApp.Properties.Resources.Delete;
            this.btn_RemoveFilm.Location = new System.Drawing.Point(182, 169);
            this.btn_RemoveFilm.Name = "btn_RemoveFilm";
            this.btn_RemoveFilm.Size = new System.Drawing.Size(25, 25);
            this.btn_RemoveFilm.TabIndex = 2;
            this.btn_RemoveFilm.UseVisualStyleBackColor = true;
            this.btn_RemoveFilm.Click += new System.EventHandler(this.btn_RemoveFilm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Film Directories - Watched folders";
            // 
            // lisb_films
            // 
            this.lisb_films.FormattingEnabled = true;
            this.lisb_films.Location = new System.Drawing.Point(6, 29);
            this.lisb_films.Name = "lisb_films";
            this.lisb_films.Size = new System.Drawing.Size(201, 134);
            this.lisb_films.TabIndex = 0;
            // 
            // tp_music
            // 
            this.tp_music.BackColor = System.Drawing.SystemColors.Control;
            this.tp_music.Location = new System.Drawing.Point(4, 22);
            this.tp_music.Name = "tp_music";
            this.tp_music.Size = new System.Drawing.Size(456, 440);
            this.tp_music.TabIndex = 2;
            this.tp_music.Text = "Music";
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(296, 468);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "&OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(377, 468);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // DbCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 502);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DbCreate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings ";
            this.tabControl1.ResumeLayout(false);
            this.tp_film.ResumeLayout(false);
            this.tp_film.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_tv;
        private System.Windows.Forms.TabPage tp_film;
        private System.Windows.Forms.TabPage tp_music;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ListBox lisb_films;
        private System.Windows.Forms.Button btn_Addfilm;
        private System.Windows.Forms.Button btn_RemoveFilm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_PMatches;
        private System.Windows.Forms.CheckBox chk_AllMatches;
        private System.Windows.Forms.CheckBox chk_ApproxMatches;
        private System.Windows.Forms.CheckBox chk_PopTitles;
        private System.Windows.Forms.CheckBox chk_ExactMatches;
        private System.Windows.Forms.CheckBox chk_TakeFirstFilm;
        private System.Windows.Forms.Button btn_Build;
        private System.Windows.Forms.CheckBox chk_DisplayFilmResults;
        private System.Windows.Forms.Label lbl_Current;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
    }
}

