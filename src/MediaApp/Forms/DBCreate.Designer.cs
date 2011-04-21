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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_tv = new System.Windows.Forms.TabPage();
            this.tp_film = new System.Windows.Forms.TabPage();
            this.grpBoxDatabase = new System.Windows.Forms.GroupBox();
            this.lbl_TR = new System.Windows.Forms.Label();
            this.lbl_TRemaing = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_ReBuild = new System.Windows.Forms.Button();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tp_film.SuspendLayout();
            this.grpBoxDatabase.SuspendLayout();
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
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
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
            this.tp_film.Controls.Add(this.grpBoxDatabase);
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
            // grpBoxDatabase
            // 
            this.grpBoxDatabase.Controls.Add(this.lbl_TR);
            this.grpBoxDatabase.Controls.Add(this.lbl_TRemaing);
            this.grpBoxDatabase.Controls.Add(this.button1);
            this.grpBoxDatabase.Controls.Add(this.btn_ReBuild);
            this.grpBoxDatabase.Controls.Add(this.chk_DisplayFilmResults);
            this.grpBoxDatabase.Controls.Add(this.lbl_Current);
            this.grpBoxDatabase.Controls.Add(this.progressBar1);
            this.grpBoxDatabase.Location = new System.Drawing.Point(11, 201);
            this.grpBoxDatabase.Name = "grpBoxDatabase";
            this.grpBoxDatabase.Size = new System.Drawing.Size(434, 228);
            this.grpBoxDatabase.TabIndex = 5;
            this.grpBoxDatabase.TabStop = false;
            this.grpBoxDatabase.Text = "Database";
            // 
            // lbl_TR
            // 
            this.lbl_TR.AutoSize = true;
            this.lbl_TR.Location = new System.Drawing.Point(90, 157);
            this.lbl_TR.Name = "lbl_TR";
            this.lbl_TR.Size = new System.Drawing.Size(68, 13);
            this.lbl_TR.TabIndex = 13;
            this.lbl_TR.Text = "Calculating...";
            this.lbl_TR.Visible = false;
            // 
            // lbl_TRemaing
            // 
            this.lbl_TRemaing.AutoSize = true;
            this.lbl_TRemaing.Location = new System.Drawing.Point(6, 157);
            this.lbl_TRemaing.Name = "lbl_TRemaing";
            this.lbl_TRemaing.Size = new System.Drawing.Size(78, 13);
            this.lbl_TRemaing.TabIndex = 12;
            this.lbl_TRemaing.Text = "Time Remaing:";
            this.lbl_TRemaing.Visible = false;
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
            // btn_ReBuild
            // 
            this.btn_ReBuild.Location = new System.Drawing.Point(353, 195);
            this.btn_ReBuild.Name = "btn_ReBuild";
            this.btn_ReBuild.Size = new System.Drawing.Size(75, 23);
            this.btn_ReBuild.TabIndex = 3;
            this.btn_ReBuild.Text = "Re-Build";
            this.btn_ReBuild.UseVisualStyleBackColor = true;
            this.btn_ReBuild.Click += new System.EventHandler(this.btn_ReBuild_Click);
            // 
            // chk_DisplayFilmResults
            // 
            this.chk_DisplayFilmResults.AutoSize = true;
            this.chk_DisplayFilmResults.Checked = global::MediaApp.Properties.Settings.Default.filmDisplayResults;
            this.chk_DisplayFilmResults.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MediaApp.Properties.Settings.Default, "filmDisplayResults", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chk_DisplayFilmResults.Location = new System.Drawing.Point(9, 19);
            this.chk_DisplayFilmResults.Name = "chk_DisplayFilmResults";
            this.chk_DisplayFilmResults.Size = new System.Drawing.Size(186, 17);
            this.chk_DisplayFilmResults.TabIndex = 2;
            this.chk_DisplayFilmResults.Text = "Display search results before build";
            this.chk_DisplayFilmResults.UseVisualStyleBackColor = true;
            // 
            // lbl_Current
            // 
            this.lbl_Current.AutoSize = true;
            this.lbl_Current.Location = new System.Drawing.Point(6, 138);
            this.lbl_Current.Name = "lbl_Current";
            this.lbl_Current.Size = new System.Drawing.Size(427, 13);
            this.lbl_Current.TabIndex = 1;
            this.lbl_Current.Text = "1234567890123456789012345678901234567890123456789012345678901234667890";
            this.lbl_Current.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(6, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(413, 23);
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
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.grpBoxDatabase.ResumeLayout(false);
            this.grpBoxDatabase.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpBoxDatabase;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_ReBuild;
        private System.Windows.Forms.CheckBox chk_DisplayFilmResults;
        private System.Windows.Forms.Label lbl_Current;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_TR;
        private System.Windows.Forms.Label lbl_TRemaing;
    }
}

