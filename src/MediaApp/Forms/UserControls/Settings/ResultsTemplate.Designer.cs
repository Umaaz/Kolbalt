namespace MediaApp.Forms.UserControls.Settings
{
    partial class ResultsTemplate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_deleteWriter = new System.Windows.Forms.Button();
            this.btn_addWriter = new System.Windows.Forms.Button();
            this.lstb_Writers = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_deleteDirector = new System.Windows.Forms.Button();
            this.lstb_Directors = new System.Windows.Forms.ListBox();
            this.btn_otherresults = new System.Windows.Forms.Button();
            this.lbl_filepath = new System.Windows.Forms.Label();
            this.txtb_Year = new System.Windows.Forms.TextBox();
            this.lbl_file = new System.Windows.Forms.Label();
            this.btn_rescan = new System.Windows.Forms.Button();
            this.lbl_cast = new System.Windows.Forms.Label();
            this.btn_addDirector = new System.Windows.Forms.Button();
            this.txtb_Synopsis = new System.Windows.Forms.TextBox();
            this.txtb_IMDBURL = new System.Windows.Forms.TextBox();
            this.lbl_director = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtb_Keywords = new System.Windows.Forms.TextBox();
            this.lbl_RunTime = new System.Windows.Forms.Label();
            this.lbl_ReleaseDate = new System.Windows.Forms.Label();
            this.txtb_RunTime = new System.Windows.Forms.TextBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_deleteGenre = new System.Windows.Forms.Button();
            this.txtb_Title = new System.Windows.Forms.TextBox();
            this.btn_addGenre = new System.Windows.Forms.Button();
            this.lbl_Genres = new System.Windows.Forms.Label();
            this.lstb_genres = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms2_SimiliarTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.cms2_SearchFor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_deleteWriter);
            this.panel1.Controls.Add(this.btn_addWriter);
            this.panel1.Controls.Add(this.lstb_Writers);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_deleteDirector);
            this.panel1.Controls.Add(this.lstb_Directors);
            this.panel1.Controls.Add(this.btn_otherresults);
            this.panel1.Controls.Add(this.lbl_filepath);
            this.panel1.Controls.Add(this.txtb_Year);
            this.panel1.Controls.Add(this.lbl_file);
            this.panel1.Controls.Add(this.btn_rescan);
            this.panel1.Controls.Add(this.lbl_cast);
            this.panel1.Controls.Add(this.btn_addDirector);
            this.panel1.Controls.Add(this.txtb_Synopsis);
            this.panel1.Controls.Add(this.txtb_IMDBURL);
            this.panel1.Controls.Add(this.lbl_director);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.txtb_Keywords);
            this.panel1.Controls.Add(this.lbl_RunTime);
            this.panel1.Controls.Add(this.lbl_ReleaseDate);
            this.panel1.Controls.Add(this.txtb_RunTime);
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Controls.Add(this.btn_deleteGenre);
            this.panel1.Controls.Add(this.txtb_Title);
            this.panel1.Controls.Add(this.btn_addGenre);
            this.panel1.Controls.Add(this.lbl_Genres);
            this.panel1.Controls.Add(this.lstb_genres);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 295);
            this.panel1.TabIndex = 0;
            // 
            // btn_deleteWriter
            // 
            this.btn_deleteWriter.Image = global::MediaApp.Properties.Resources.Delete;
            this.btn_deleteWriter.Location = new System.Drawing.Point(437, 239);
            this.btn_deleteWriter.Name = "btn_deleteWriter";
            this.btn_deleteWriter.Size = new System.Drawing.Size(24, 23);
            this.btn_deleteWriter.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btn_deleteWriter, "Remove selected writer.");
            this.btn_deleteWriter.UseVisualStyleBackColor = true;
            this.btn_deleteWriter.Click += new System.EventHandler(this.btn_deleteWriter_Click);
            // 
            // btn_addWriter
            // 
            this.btn_addWriter.Image = global::MediaApp.Properties.Resources.Add;
            this.btn_addWriter.Location = new System.Drawing.Point(437, 210);
            this.btn_addWriter.Name = "btn_addWriter";
            this.btn_addWriter.Size = new System.Drawing.Size(24, 23);
            this.btn_addWriter.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btn_addWriter, "Add a new writer.");
            this.btn_addWriter.UseVisualStyleBackColor = true;
            this.btn_addWriter.Click += new System.EventHandler(this.btn_addWriter_Click);
            // 
            // lstb_Writers
            // 
            this.lstb_Writers.FormattingEnabled = true;
            this.lstb_Writers.Location = new System.Drawing.Point(300, 190);
            this.lstb_Writers.Name = "lstb_Writers";
            this.lstb_Writers.Size = new System.Drawing.Size(131, 69);
            this.lstb_Writers.TabIndex = 11;
            this.lstb_Writers.SelectedIndexChanged += new System.EventHandler(this.lstb_Writers_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "Writers:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Location = new System.Drawing.Point(310, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 29);
            this.panel2.TabIndex = 70;
            this.panel2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(96, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loading...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            // 
            // btn_deleteDirector
            // 
            this.btn_deleteDirector.Image = global::MediaApp.Properties.Resources.Delete;
            this.btn_deleteDirector.Location = new System.Drawing.Point(437, 151);
            this.btn_deleteDirector.Name = "btn_deleteDirector";
            this.btn_deleteDirector.Size = new System.Drawing.Size(24, 23);
            this.btn_deleteDirector.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btn_deleteDirector, "Remove selected director.");
            this.btn_deleteDirector.UseVisualStyleBackColor = true;
            this.btn_deleteDirector.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstb_Directors
            // 
            this.lstb_Directors.FormattingEnabled = true;
            this.lstb_Directors.Location = new System.Drawing.Point(300, 102);
            this.lstb_Directors.Name = "lstb_Directors";
            this.lstb_Directors.Size = new System.Drawing.Size(131, 69);
            this.lstb_Directors.TabIndex = 8;
            this.lstb_Directors.SelectedIndexChanged += new System.EventHandler(this.lstb_Directors_SelectedIndexChanged);
            // 
            // btn_otherresults
            // 
            this.btn_otherresults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_otherresults.Location = new System.Drawing.Point(404, 265);
            this.btn_otherresults.Name = "btn_otherresults";
            this.btn_otherresults.Size = new System.Drawing.Size(57, 23);
            this.btn_otherresults.TabIndex = 17;
            this.btn_otherresults.Text = "O&ther";
            this.toolTip1.SetToolTip(this.btn_otherresults, "View other similiar results.");
            this.btn_otherresults.UseVisualStyleBackColor = true;
            this.btn_otherresults.Click += new System.EventHandler(this.btn_otherresults_Click);
            // 
            // lbl_filepath
            // 
            this.lbl_filepath.AutoSize = true;
            this.lbl_filepath.Location = new System.Drawing.Point(565, 10);
            this.lbl_filepath.Name = "lbl_filepath";
            this.lbl_filepath.Size = new System.Drawing.Size(82, 13);
            this.lbl_filepath.TabIndex = 59;
            this.lbl_filepath.Text = "c:/asd/asd/asd";
            // 
            // txtb_Year
            // 
            this.txtb_Year.Location = new System.Drawing.Point(84, 62);
            this.txtb_Year.Name = "txtb_Year";
            this.txtb_Year.Size = new System.Drawing.Size(210, 20);
            this.txtb_Year.TabIndex = 2;
            this.txtb_Year.TextChanged += new System.EventHandler(this.txtb_Year_TextChanged);
            // 
            // lbl_file
            // 
            this.lbl_file.AutoSize = true;
            this.lbl_file.Location = new System.Drawing.Point(533, 10);
            this.lbl_file.Name = "lbl_file";
            this.lbl_file.Size = new System.Drawing.Size(26, 13);
            this.lbl_file.TabIndex = 58;
            this.lbl_file.Text = "File:";
            // 
            // btn_rescan
            // 
            this.btn_rescan.Location = new System.Drawing.Point(344, 265);
            this.btn_rescan.Name = "btn_rescan";
            this.btn_rescan.Size = new System.Drawing.Size(57, 23);
            this.btn_rescan.TabIndex = 16;
            this.btn_rescan.Text = "Re-&Scan";
            this.toolTip1.SetToolTip(this.btn_rescan, "Scan Url for film data.");
            this.btn_rescan.UseVisualStyleBackColor = true;
            this.btn_rescan.Click += new System.EventHandler(this.btn_rescan_Click);
            // 
            // lbl_cast
            // 
            this.lbl_cast.AutoSize = true;
            this.lbl_cast.Location = new System.Drawing.Point(464, 10);
            this.lbl_cast.Name = "lbl_cast";
            this.lbl_cast.Size = new System.Drawing.Size(28, 13);
            this.lbl_cast.TabIndex = 57;
            this.lbl_cast.Text = "Cast";
            // 
            // btn_addDirector
            // 
            this.btn_addDirector.Image = global::MediaApp.Properties.Resources.Add;
            this.btn_addDirector.Location = new System.Drawing.Point(437, 122);
            this.btn_addDirector.Name = "btn_addDirector";
            this.btn_addDirector.Size = new System.Drawing.Size(24, 23);
            this.btn_addDirector.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btn_addDirector, "Add a new director.");
            this.btn_addDirector.UseVisualStyleBackColor = true;
            this.btn_addDirector.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtb_Synopsis
            // 
            this.txtb_Synopsis.Location = new System.Drawing.Point(3, 131);
            this.txtb_Synopsis.Multiline = true;
            this.txtb_Synopsis.Name = "txtb_Synopsis";
            this.txtb_Synopsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtb_Synopsis.Size = new System.Drawing.Size(291, 127);
            this.txtb_Synopsis.TabIndex = 4;
            this.txtb_Synopsis.TextChanged += new System.EventHandler(this.txtb_Synopsis_TextChanged);
            // 
            // txtb_IMDBURL
            // 
            this.txtb_IMDBURL.Location = new System.Drawing.Point(56, 267);
            this.txtb_IMDBURL.Name = "txtb_IMDBURL";
            this.txtb_IMDBURL.Size = new System.Drawing.Size(282, 20);
            this.txtb_IMDBURL.TabIndex = 15;
            this.txtb_IMDBURL.Text = "http://www.IMDB.com/title/tt";
            // 
            // lbl_director
            // 
            this.lbl_director.AutoSize = true;
            this.lbl_director.Location = new System.Drawing.Point(298, 86);
            this.lbl_director.Name = "lbl_director";
            this.lbl_director.Size = new System.Drawing.Size(47, 13);
            this.lbl_director.TabIndex = 46;
            this.lbl_director.Text = "Director:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "IMDB Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "KeyWords:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Synopsis:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(467, 34);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(396, 258);
            this.dataGridView1.TabIndex = 14;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditItem,
            this.DeleteItem,
            this.AddItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 70);
            // 
            // EditItem
            // 
            this.EditItem.Name = "EditItem";
            this.EditItem.Size = new System.Drawing.Size(107, 22);
            this.EditItem.Text = "&Edit";
            this.EditItem.ToolTipText = "Edit selected role.";
            this.EditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(107, 22);
            this.DeleteItem.Text = "&Delete";
            this.DeleteItem.ToolTipText = "Delete selected role.";
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // AddItem
            // 
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(107, 22);
            this.AddItem.Text = "&Add";
            this.AddItem.ToolTipText = "Add a new role.";
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // txtb_Keywords
            // 
            this.txtb_Keywords.Location = new System.Drawing.Point(71, 88);
            this.txtb_Keywords.Name = "txtb_Keywords";
            this.txtb_Keywords.Size = new System.Drawing.Size(223, 20);
            this.txtb_Keywords.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtb_Keywords, "Seperate keywords with an empty space");
            this.txtb_Keywords.TextChanged += new System.EventHandler(this.txtb_Keywords_TextChanged);
            // 
            // lbl_RunTime
            // 
            this.lbl_RunTime.AutoSize = true;
            this.lbl_RunTime.Location = new System.Drawing.Point(3, 39);
            this.lbl_RunTime.Name = "lbl_RunTime";
            this.lbl_RunTime.Size = new System.Drawing.Size(56, 13);
            this.lbl_RunTime.TabIndex = 49;
            this.lbl_RunTime.Text = "Run Time:";
            // 
            // lbl_ReleaseDate
            // 
            this.lbl_ReleaseDate.AutoSize = true;
            this.lbl_ReleaseDate.Location = new System.Drawing.Point(4, 65);
            this.lbl_ReleaseDate.Name = "lbl_ReleaseDate";
            this.lbl_ReleaseDate.Size = new System.Drawing.Size(74, 13);
            this.lbl_ReleaseDate.TabIndex = 50;
            this.lbl_ReleaseDate.Text = "Release Year:";
            // 
            // txtb_RunTime
            // 
            this.txtb_RunTime.Location = new System.Drawing.Point(65, 36);
            this.txtb_RunTime.Name = "txtb_RunTime";
            this.txtb_RunTime.Size = new System.Drawing.Size(229, 20);
            this.txtb_RunTime.TabIndex = 1;
            this.txtb_RunTime.TextChanged += new System.EventHandler(this.txtb_RunTime_TextChanged);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(3, 13);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(30, 13);
            this.lbl_title.TabIndex = 45;
            this.lbl_title.Text = "Title:";
            // 
            // btn_deleteGenre
            // 
            this.btn_deleteGenre.Image = global::MediaApp.Properties.Resources.Delete;
            this.btn_deleteGenre.Location = new System.Drawing.Point(437, 62);
            this.btn_deleteGenre.Name = "btn_deleteGenre";
            this.btn_deleteGenre.Size = new System.Drawing.Size(24, 23);
            this.btn_deleteGenre.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btn_deleteGenre, "Remove selected genre.");
            this.btn_deleteGenre.UseVisualStyleBackColor = true;
            this.btn_deleteGenre.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txtb_Title
            // 
            this.txtb_Title.Location = new System.Drawing.Point(39, 10);
            this.txtb_Title.Name = "txtb_Title";
            this.txtb_Title.Size = new System.Drawing.Size(255, 20);
            this.txtb_Title.TabIndex = 0;
            this.txtb_Title.TextChanged += new System.EventHandler(this.txtb_Title_TextChanged);
            // 
            // btn_addGenre
            // 
            this.btn_addGenre.Image = global::MediaApp.Properties.Resources.Add;
            this.btn_addGenre.Location = new System.Drawing.Point(437, 33);
            this.btn_addGenre.Name = "btn_addGenre";
            this.btn_addGenre.Size = new System.Drawing.Size(24, 23);
            this.btn_addGenre.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btn_addGenre, "Add a new genre.");
            this.btn_addGenre.UseVisualStyleBackColor = true;
            this.btn_addGenre.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_Genres
            // 
            this.lbl_Genres.AutoSize = true;
            this.lbl_Genres.Location = new System.Drawing.Point(297, 10);
            this.lbl_Genres.Name = "lbl_Genres";
            this.lbl_Genres.Size = new System.Drawing.Size(41, 13);
            this.lbl_Genres.TabIndex = 52;
            this.lbl_Genres.Text = "Genres";
            // 
            // lstb_genres
            // 
            this.lstb_genres.FormattingEnabled = true;
            this.lstb_genres.Location = new System.Drawing.Point(300, 26);
            this.lstb_genres.Name = "lstb_genres";
            this.lstb_genres.Size = new System.Drawing.Size(131, 56);
            this.lstb_genres.TabIndex = 5;
            this.toolTip1.SetToolTip(this.lstb_genres, "l");
            this.lstb_genres.SelectedIndexChanged += new System.EventHandler(this.lstb_genres_SelectedIndexChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms2_SimiliarTitle,
            this.cms2_SearchFor,
            this.toolStripTextBox1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(161, 95);
            // 
            // cms2_SimiliarTitle
            // 
            this.cms2_SimiliarTitle.Name = "cms2_SimiliarTitle";
            this.cms2_SimiliarTitle.Size = new System.Drawing.Size(160, 22);
            this.cms2_SimiliarTitle.Text = "Similiar Titles";
            this.cms2_SimiliarTitle.Click += new System.EventHandler(this.cms2_SimiliarTitle_Click);
            // 
            // cms2_SearchFor
            // 
            this.cms2_SearchFor.Name = "cms2_SearchFor";
            this.cms2_SearchFor.Size = new System.Drawing.Size(160, 22);
            this.cms2_SearchFor.Text = "Search for..";
            this.cms2_SearchFor.Click += new System.EventHandler(this.cms2_SearchFor_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Enter Film Title..";
            this.toolStripTextBox1.ToolTipText = "Enter title of film to search IMDB for.";
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            // 
            // ResultsTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ResultsTemplate";
            this.Size = new System.Drawing.Size(866, 295);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtb_Year;
        private System.Windows.Forms.Button btn_otherresults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtb_Keywords;
        private System.Windows.Forms.Button btn_rescan;
        private System.Windows.Forms.TextBox txtb_Synopsis;
        private System.Windows.Forms.ToolStripMenuItem AddItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem DeleteItem;
        private System.Windows.Forms.TextBox txtb_IMDBURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_filepath;
        private System.Windows.Forms.Label lbl_file;
        private System.Windows.Forms.Label lbl_cast;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EditItem;
        private System.Windows.Forms.Button btn_deleteGenre;
        private System.Windows.Forms.Button btn_addGenre;
        private System.Windows.Forms.ListBox lstb_genres;
        private System.Windows.Forms.Label lbl_Genres;
        private System.Windows.Forms.TextBox txtb_RunTime;
        private System.Windows.Forms.Label lbl_ReleaseDate;
        private System.Windows.Forms.Label lbl_RunTime;
        private System.Windows.Forms.TextBox txtb_Title;
        private System.Windows.Forms.Label lbl_director;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_deleteDirector;
        private System.Windows.Forms.ListBox lstb_Directors;
        private System.Windows.Forms.Button btn_addDirector;
        private System.Windows.Forms.Button btn_deleteWriter;
        private System.Windows.Forms.Button btn_addWriter;
        private System.Windows.Forms.ListBox lstb_Writers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem cms2_SimiliarTitle;
        private System.Windows.Forms.ToolStripMenuItem cms2_SearchFor;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;

    }
}
