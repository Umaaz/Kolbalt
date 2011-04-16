namespace MediaApp.Forms.UserControls
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
            this.btn_rescan = new System.Windows.Forms.Button();
            this.txtb_IMDBURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_filepath = new System.Windows.Forms.Label();
            this.lbl_file = new System.Windows.Forms.Label();
            this.lbl_cast = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstb_genres = new System.Windows.Forms.ListBox();
            this.lbl_Genres = new System.Windows.Forms.Label();
            this.txtb_RunTime = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbl_ReleaseDate = new System.Windows.Forms.Label();
            this.lbl_RunTime = new System.Windows.Forms.Label();
            this.txtb_director = new System.Windows.Forms.TextBox();
            this.txtb_Title = new System.Windows.Forms.TextBox();
            this.lbl_director = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.txtb_Keywords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtb_Synopsis = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_otherresults = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_rescan
            // 
            this.btn_rescan.Location = new System.Drawing.Point(254, 264);
            this.btn_rescan.Name = "btn_rescan";
            this.btn_rescan.Size = new System.Drawing.Size(57, 23);
            this.btn_rescan.TabIndex = 37;
            this.btn_rescan.Text = "Re-Scan";
            this.btn_rescan.UseVisualStyleBackColor = true;
            this.btn_rescan.Click += new System.EventHandler(this.btn_rescan_Click);
            // 
            // txtb_IMDBURL
            // 
            this.txtb_IMDBURL.Location = new System.Drawing.Point(53, 264);
            this.txtb_IMDBURL.Name = "txtb_IMDBURL";
            this.txtb_IMDBURL.Size = new System.Drawing.Size(195, 20);
            this.txtb_IMDBURL.TabIndex = 36;
            this.txtb_IMDBURL.Text = "http://www.IMDB.com/title/tt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "IMDB Url:";
            // 
            // lbl_filepath
            // 
            this.lbl_filepath.AutoSize = true;
            this.lbl_filepath.Location = new System.Drawing.Point(475, 8);
            this.lbl_filepath.Name = "lbl_filepath";
            this.lbl_filepath.Size = new System.Drawing.Size(82, 13);
            this.lbl_filepath.TabIndex = 34;
            this.lbl_filepath.Text = "c:/asd/asd/asd";
            // 
            // lbl_file
            // 
            this.lbl_file.AutoSize = true;
            this.lbl_file.Location = new System.Drawing.Point(443, 8);
            this.lbl_file.Name = "lbl_file";
            this.lbl_file.Size = new System.Drawing.Size(26, 13);
            this.lbl_file.TabIndex = 33;
            this.lbl_file.Text = "File:";
            // 
            // lbl_cast
            // 
            this.lbl_cast.AutoSize = true;
            this.lbl_cast.Location = new System.Drawing.Point(374, 8);
            this.lbl_cast.Name = "lbl_cast";
            this.lbl_cast.Size = new System.Drawing.Size(28, 13);
            this.lbl_cast.TabIndex = 32;
            this.lbl_cast.Text = "Cast";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(377, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(396, 258);
            this.dataGridView1.TabIndex = 31;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditItem,
            this.DeleteItem,
            this.AddItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // EditItem
            // 
            this.EditItem.Name = "EditItem";
            this.EditItem.Size = new System.Drawing.Size(152, 22);
            this.EditItem.Text = "Edit";
            this.EditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteItem.Text = "Delete";
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // AddItem
            // 
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(152, 22);
            this.AddItem.Text = "Add";
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // lstb_genres
            // 
            this.lstb_genres.FormattingEnabled = true;
            this.lstb_genres.Location = new System.Drawing.Point(257, 28);
            this.lstb_genres.Name = "lstb_genres";
            this.lstb_genres.Size = new System.Drawing.Size(84, 108);
            this.lstb_genres.TabIndex = 28;
            // 
            // lbl_Genres
            // 
            this.lbl_Genres.AutoSize = true;
            this.lbl_Genres.Location = new System.Drawing.Point(254, 8);
            this.lbl_Genres.Name = "lbl_Genres";
            this.lbl_Genres.Size = new System.Drawing.Size(41, 13);
            this.lbl_Genres.TabIndex = 27;
            this.lbl_Genres.Text = "Genres";
            // 
            // txtb_RunTime
            // 
            this.txtb_RunTime.Location = new System.Drawing.Point(62, 57);
            this.txtb_RunTime.Name = "txtb_RunTime";
            this.txtb_RunTime.Size = new System.Drawing.Size(186, 20);
            this.txtb_RunTime.TabIndex = 26;
            this.txtb_RunTime.TextChanged += new System.EventHandler(this.txtb_RunTime_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(81, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(167, 20);
            this.dateTimePicker1.TabIndex = 25;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lbl_ReleaseDate
            // 
            this.lbl_ReleaseDate.AutoSize = true;
            this.lbl_ReleaseDate.Location = new System.Drawing.Point(0, 89);
            this.lbl_ReleaseDate.Name = "lbl_ReleaseDate";
            this.lbl_ReleaseDate.Size = new System.Drawing.Size(75, 13);
            this.lbl_ReleaseDate.TabIndex = 24;
            this.lbl_ReleaseDate.Text = "Release Date:";
            // 
            // lbl_RunTime
            // 
            this.lbl_RunTime.AutoSize = true;
            this.lbl_RunTime.Location = new System.Drawing.Point(0, 60);
            this.lbl_RunTime.Name = "lbl_RunTime";
            this.lbl_RunTime.Size = new System.Drawing.Size(56, 13);
            this.lbl_RunTime.TabIndex = 23;
            this.lbl_RunTime.Text = "Run Time:";
            // 
            // txtb_director
            // 
            this.txtb_director.Location = new System.Drawing.Point(53, 31);
            this.txtb_director.Name = "txtb_director";
            this.txtb_director.Size = new System.Drawing.Size(153, 20);
            this.txtb_director.TabIndex = 22;
            // 
            // txtb_Title
            // 
            this.txtb_Title.Location = new System.Drawing.Point(36, 5);
            this.txtb_Title.Name = "txtb_Title";
            this.txtb_Title.Size = new System.Drawing.Size(212, 20);
            this.txtb_Title.TabIndex = 21;
            this.txtb_Title.TextChanged += new System.EventHandler(this.txtb_Title_TextChanged);
            // 
            // lbl_director
            // 
            this.lbl_director.AutoSize = true;
            this.lbl_director.Location = new System.Drawing.Point(0, 34);
            this.lbl_director.Name = "lbl_director";
            this.lbl_director.Size = new System.Drawing.Size(47, 13);
            this.lbl_director.TabIndex = 20;
            this.lbl_director.Text = "Director:";
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(0, 8);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(30, 13);
            this.lbl_title.TabIndex = 19;
            this.lbl_title.Text = "Title:";
            // 
            // txtb_Keywords
            // 
            this.txtb_Keywords.Location = new System.Drawing.Point(68, 109);
            this.txtb_Keywords.Name = "txtb_Keywords";
            this.txtb_Keywords.Size = new System.Drawing.Size(180, 20);
            this.txtb_Keywords.TabIndex = 38;
            this.txtb_Keywords.TextChanged += new System.EventHandler(this.txtb_Keywords_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "KeyWords:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Synopsis:";
            // 
            // txtb_Synopsis
            // 
            this.txtb_Synopsis.Location = new System.Drawing.Point(0, 152);
            this.txtb_Synopsis.Multiline = true;
            this.txtb_Synopsis.Name = "txtb_Synopsis";
            this.txtb_Synopsis.Size = new System.Drawing.Size(368, 105);
            this.txtb_Synopsis.TabIndex = 41;
            this.txtb_Synopsis.TextChanged += new System.EventHandler(this.txtb_Synopsis_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 20);
            this.button1.TabIndex = 42;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::MediaApp.Properties.Resources.Delete;
            this.btn_delete.Location = new System.Drawing.Point(347, 113);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(24, 23);
            this.btn_delete.TabIndex = 30;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.Image = global::MediaApp.Properties.Resources.Add;
            this.btn_add.Location = new System.Drawing.Point(347, 84);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(24, 23);
            this.btn_add.TabIndex = 29;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_otherresults
            // 
            this.btn_otherresults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_otherresults.Location = new System.Drawing.Point(314, 264);
            this.btn_otherresults.Name = "btn_otherresults";
            this.btn_otherresults.Size = new System.Drawing.Size(57, 23);
            this.btn_otherresults.TabIndex = 43;
            this.btn_otherresults.Text = "Other";
            this.btn_otherresults.UseVisualStyleBackColor = true;
            this.btn_otherresults.Click += new System.EventHandler(this.button2_Click);
            // 
            // ResultsTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_otherresults);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtb_Synopsis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtb_Keywords);
            this.Controls.Add(this.btn_rescan);
            this.Controls.Add(this.txtb_IMDBURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_filepath);
            this.Controls.Add(this.lbl_file);
            this.Controls.Add(this.lbl_cast);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lstb_genres);
            this.Controls.Add(this.lbl_Genres);
            this.Controls.Add(this.txtb_RunTime);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lbl_ReleaseDate);
            this.Controls.Add(this.lbl_RunTime);
            this.Controls.Add(this.txtb_director);
            this.Controls.Add(this.txtb_Title);
            this.Controls.Add(this.lbl_director);
            this.Controls.Add(this.lbl_title);
            this.Name = "ResultsTemplate";
            this.Size = new System.Drawing.Size(776, 295);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_rescan;
        private System.Windows.Forms.TextBox txtb_IMDBURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_filepath;
        private System.Windows.Forms.Label lbl_file;
        private System.Windows.Forms.Label lbl_cast;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ListBox lstb_genres;
        private System.Windows.Forms.Label lbl_Genres;
        private System.Windows.Forms.TextBox txtb_RunTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lbl_ReleaseDate;
        private System.Windows.Forms.Label lbl_RunTime;
        private System.Windows.Forms.TextBox txtb_director;
        private System.Windows.Forms.TextBox txtb_Title;
        private System.Windows.Forms.Label lbl_director;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.TextBox txtb_Keywords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtb_Synopsis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EditItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteItem;
        private System.Windows.Forms.ToolStripMenuItem AddItem;
        private System.Windows.Forms.Button btn_otherresults;
    }
}
