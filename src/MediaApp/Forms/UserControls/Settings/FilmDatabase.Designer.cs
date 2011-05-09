namespace MediaApp.Forms.UserControls.Settings
{
    partial class FilmDatabase
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
            this.grpBoxDatabase = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_TR = new System.Windows.Forms.Label();
            this.lbl_TRemaing = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_ReBuild = new System.Windows.Forms.Button();
            this.chk_DisplayFilmResults = new System.Windows.Forms.CheckBox();
            this.lbl_Current = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lisb_films = new System.Windows.Forms.ListBox();
            this.btn_Addfilm = new System.Windows.Forms.Button();
            this.btn_RemoveFilm = new System.Windows.Forms.Button();
            this.grpBoxDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxDatabase
            // 
            this.grpBoxDatabase.Controls.Add(this.button2);
            this.grpBoxDatabase.Controls.Add(this.lbl_TR);
            this.grpBoxDatabase.Controls.Add(this.lbl_TRemaing);
            this.grpBoxDatabase.Controls.Add(this.button1);
            this.grpBoxDatabase.Controls.Add(this.btn_ReBuild);
            this.grpBoxDatabase.Controls.Add(this.chk_DisplayFilmResults);
            this.grpBoxDatabase.Controls.Add(this.lbl_Current);
            this.grpBoxDatabase.Controls.Add(this.progressBar1);
            this.grpBoxDatabase.Location = new System.Drawing.Point(6, 188);
            this.grpBoxDatabase.Name = "grpBoxDatabase";
            this.grpBoxDatabase.Size = new System.Drawing.Size(434, 228);
            this.grpBoxDatabase.TabIndex = 10;
            this.grpBoxDatabase.TabStop = false;
            this.grpBoxDatabase.Text = "Database";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 22);
            this.button2.TabIndex = 14;
            this.button2.Text = "Update Index";
            this.button2.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Film Directories - Watched folders";
            // 
            // lisb_films
            // 
            this.lisb_films.FormattingEnabled = true;
            this.lisb_films.Location = new System.Drawing.Point(1, 16);
            this.lisb_films.Name = "lisb_films";
            this.lisb_films.Size = new System.Drawing.Size(201, 134);
            this.lisb_films.TabIndex = 6;
            // 
            // btn_Addfilm
            // 
            this.btn_Addfilm.Image = global::MediaApp.Properties.Resources.Add;
            this.btn_Addfilm.Location = new System.Drawing.Point(146, 156);
            this.btn_Addfilm.Name = "btn_Addfilm";
            this.btn_Addfilm.Size = new System.Drawing.Size(25, 25);
            this.btn_Addfilm.TabIndex = 9;
            this.btn_Addfilm.UseVisualStyleBackColor = true;
            this.btn_Addfilm.Click += new System.EventHandler(this.btn_Addfilm_Click);
            // 
            // btn_RemoveFilm
            // 
            this.btn_RemoveFilm.Image = global::MediaApp.Properties.Resources.Delete;
            this.btn_RemoveFilm.Location = new System.Drawing.Point(177, 156);
            this.btn_RemoveFilm.Name = "btn_RemoveFilm";
            this.btn_RemoveFilm.Size = new System.Drawing.Size(25, 25);
            this.btn_RemoveFilm.TabIndex = 8;
            this.btn_RemoveFilm.UseVisualStyleBackColor = true;
            this.btn_RemoveFilm.Click += new System.EventHandler(this.btn_RemoveFilm_Click);
            // 
            // FilmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxDatabase);
            this.Controls.Add(this.btn_Addfilm);
            this.Controls.Add(this.btn_RemoveFilm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lisb_films);
            this.Name = "FilmDatabase";
            this.Size = new System.Drawing.Size(445, 421);
            this.grpBoxDatabase.ResumeLayout(false);
            this.grpBoxDatabase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxDatabase;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_TR;
        private System.Windows.Forms.Label lbl_TRemaing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_ReBuild;
        private System.Windows.Forms.CheckBox chk_DisplayFilmResults;
        private System.Windows.Forms.Label lbl_Current;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_Addfilm;
        private System.Windows.Forms.Button btn_RemoveFilm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lisb_films;
    }
}
