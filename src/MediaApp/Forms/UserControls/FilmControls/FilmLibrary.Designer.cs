namespace MediaApp.Forms.UserControls.FilmControls
{
    partial class FilmLibrary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SC_SearchLibrary = new System.Windows.Forms.SplitContainer();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_AdvSearch = new System.Windows.Forms.Button();
            this.txtb_Search = new System.Windows.Forms.TextBox();
            this.lbl_Search = new System.Windows.Forms.Label();
            this.PN_FilmLibrary = new System.Windows.Forms.Panel();
            this.SC_LibraryDetails = new System.Windows.Forms.SplitContainer();
            this.SC_MLTopFilm = new System.Windows.Forms.SplitContainer();
            this.SC_DirectorsActors = new System.Windows.Forms.SplitContainer();
            this.ActorList = new System.Windows.Forms.ListBox();
            this.SC_GenresActors = new System.Windows.Forms.SplitContainer();
            this.GenreList = new System.Windows.Forms.ListBox();
            this.DirectorList = new System.Windows.Forms.ListBox();
            this.SC_FilmDataGridDetControls = new System.Windows.Forms.SplitContainer();
            this.SC_DatagridSynopsis = new System.Windows.Forms.SplitContainer();
            this.DGV_Films = new System.Windows.Forms.DataGridView();
            this.SC_CastSynopsis = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lv_FilmCast = new System.Windows.Forms.ListView();
            this.clm_Actor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_Character = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pn_RuntimeReleaseDate = new System.Windows.Forms.Panel();
            this.lbl_RTimeLabel = new System.Windows.Forms.Label();
            this.lbl_rTime = new System.Windows.Forms.Label();
            this.lbl_RDateLabel = new System.Windows.Forms.Label();
            this.lbl_rdate = new System.Windows.Forms.Label();
            this.txtb_Synopsis = new System.Windows.Forms.TextBox();
            this.btn_PlayFilm = new System.Windows.Forms.Button();
            this.btn_showHideFilmDetails = new System.Windows.Forms.Button();
            this.btn_CrtPlaylist = new System.Windows.Forms.Button();
            this.lbl_LibraryDetails = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.SelectedFilmDetailsPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SC_SearchLibrary)).BeginInit();
            this.SC_SearchLibrary.Panel1.SuspendLayout();
            this.SC_SearchLibrary.Panel2.SuspendLayout();
            this.SC_SearchLibrary.SuspendLayout();
            this.PN_FilmLibrary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_LibraryDetails)).BeginInit();
            this.SC_LibraryDetails.Panel1.SuspendLayout();
            this.SC_LibraryDetails.Panel2.SuspendLayout();
            this.SC_LibraryDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_MLTopFilm)).BeginInit();
            this.SC_MLTopFilm.Panel1.SuspendLayout();
            this.SC_MLTopFilm.Panel2.SuspendLayout();
            this.SC_MLTopFilm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_DirectorsActors)).BeginInit();
            this.SC_DirectorsActors.Panel1.SuspendLayout();
            this.SC_DirectorsActors.Panel2.SuspendLayout();
            this.SC_DirectorsActors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_GenresActors)).BeginInit();
            this.SC_GenresActors.Panel1.SuspendLayout();
            this.SC_GenresActors.Panel2.SuspendLayout();
            this.SC_GenresActors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_FilmDataGridDetControls)).BeginInit();
            this.SC_FilmDataGridDetControls.Panel1.SuspendLayout();
            this.SC_FilmDataGridDetControls.Panel2.SuspendLayout();
            this.SC_FilmDataGridDetControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_DatagridSynopsis)).BeginInit();
            this.SC_DatagridSynopsis.Panel1.SuspendLayout();
            this.SC_DatagridSynopsis.Panel2.SuspendLayout();
            this.SC_DatagridSynopsis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Films)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SC_CastSynopsis)).BeginInit();
            this.SC_CastSynopsis.Panel1.SuspendLayout();
            this.SC_CastSynopsis.Panel2.SuspendLayout();
            this.SC_CastSynopsis.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pn_RuntimeReleaseDate.SuspendLayout();
            this.SelectedFilmDetailsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SC_SearchLibrary
            // 
            this.SC_SearchLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_SearchLibrary.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SC_SearchLibrary.IsSplitterFixed = true;
            this.SC_SearchLibrary.Location = new System.Drawing.Point(0, 0);
            this.SC_SearchLibrary.Name = "SC_SearchLibrary";
            this.SC_SearchLibrary.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_SearchLibrary.Panel1
            // 
            this.SC_SearchLibrary.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.SC_SearchLibrary.Panel1.Controls.Add(this.btn_Clear);
            this.SC_SearchLibrary.Panel1.Controls.Add(this.btn_AdvSearch);
            this.SC_SearchLibrary.Panel1.Controls.Add(this.txtb_Search);
            this.SC_SearchLibrary.Panel1.Controls.Add(this.lbl_Search);
            // 
            // SC_SearchLibrary.Panel2
            // 
            this.SC_SearchLibrary.Panel2.Controls.Add(this.PN_FilmLibrary);
            this.SC_SearchLibrary.Size = new System.Drawing.Size(633, 579);
            this.SC_SearchLibrary.SplitterDistance = 26;
            this.SC_SearchLibrary.TabIndex = 1;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear.Location = new System.Drawing.Point(474, 3);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 21);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_AdvSearch
            // 
            this.btn_AdvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AdvSearch.Location = new System.Drawing.Point(555, 3);
            this.btn_AdvSearch.Name = "btn_AdvSearch";
            this.btn_AdvSearch.Size = new System.Drawing.Size(75, 21);
            this.btn_AdvSearch.TabIndex = 2;
            this.btn_AdvSearch.Text = "Advanced";
            this.btn_AdvSearch.UseVisualStyleBackColor = true;
            // 
            // txtb_Search
            // 
            this.txtb_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_Search.Location = new System.Drawing.Point(44, 3);
            this.txtb_Search.Name = "txtb_Search";
            this.txtb_Search.Size = new System.Drawing.Size(424, 20);
            this.txtb_Search.TabIndex = 1;
            this.txtb_Search.TextChanged += new System.EventHandler(this.txtb_Search_TextChanged);
            // 
            // lbl_Search
            // 
            this.lbl_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Search.AutoSize = true;
            this.lbl_Search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_Search.Location = new System.Drawing.Point(3, 6);
            this.lbl_Search.Name = "lbl_Search";
            this.lbl_Search.Size = new System.Drawing.Size(41, 13);
            this.lbl_Search.TabIndex = 0;
            this.lbl_Search.Text = "Search";
            // 
            // PN_FilmLibrary
            // 
            this.PN_FilmLibrary.Controls.Add(this.SC_LibraryDetails);
            this.PN_FilmLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_FilmLibrary.Location = new System.Drawing.Point(0, 0);
            this.PN_FilmLibrary.Name = "PN_FilmLibrary";
            this.PN_FilmLibrary.Size = new System.Drawing.Size(633, 549);
            this.PN_FilmLibrary.TabIndex = 0;
            // 
            // SC_LibraryDetails
            // 
            this.SC_LibraryDetails.DataBindings.Add(new System.Windows.Forms.Binding("Panel2Collapsed", global::MediaApp.Properties.Settings.Default, "selectedFilmDetailsShow", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SC_LibraryDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_LibraryDetails.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SC_LibraryDetails.IsSplitterFixed = true;
            this.SC_LibraryDetails.Location = new System.Drawing.Point(0, 0);
            this.SC_LibraryDetails.Name = "SC_LibraryDetails";
            this.SC_LibraryDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_LibraryDetails.Panel1
            // 
            this.SC_LibraryDetails.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.SC_LibraryDetails.Panel1.Controls.Add(this.SC_MLTopFilm);
            // 
            // SC_LibraryDetails.Panel2
            // 
            this.SC_LibraryDetails.Panel2.Controls.Add(this.SelectedFilmDetailsPanel);
            this.SC_LibraryDetails.Panel2Collapsed = global::MediaApp.Properties.Settings.Default.selectedFilmDetailsShow;
            this.SC_LibraryDetails.Size = new System.Drawing.Size(633, 549);
            this.SC_LibraryDetails.SplitterDistance = 455;
            this.SC_LibraryDetails.TabIndex = 0;
            // 
            // SC_MLTopFilm
            // 
            this.SC_MLTopFilm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.SC_MLTopFilm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_MLTopFilm.Location = new System.Drawing.Point(0, 0);
            this.SC_MLTopFilm.Name = "SC_MLTopFilm";
            this.SC_MLTopFilm.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_MLTopFilm.Panel1
            // 
            this.SC_MLTopFilm.Panel1.Controls.Add(this.SC_DirectorsActors);
            // 
            // SC_MLTopFilm.Panel2
            // 
            this.SC_MLTopFilm.Panel2.Controls.Add(this.SC_FilmDataGridDetControls);
            this.SC_MLTopFilm.Size = new System.Drawing.Size(633, 455);
            this.SC_MLTopFilm.SplitterDistance = 189;
            this.SC_MLTopFilm.TabIndex = 6;
            // 
            // SC_DirectorsActors
            // 
            this.SC_DirectorsActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_DirectorsActors.Location = new System.Drawing.Point(0, 0);
            this.SC_DirectorsActors.Name = "SC_DirectorsActors";
            // 
            // SC_DirectorsActors.Panel1
            // 
            this.SC_DirectorsActors.Panel1.Controls.Add(this.ActorList);
            // 
            // SC_DirectorsActors.Panel2
            // 
            this.SC_DirectorsActors.Panel2.Controls.Add(this.SC_GenresActors);
            this.SC_DirectorsActors.Size = new System.Drawing.Size(633, 189);
            this.SC_DirectorsActors.SplitterDistance = 255;
            this.SC_DirectorsActors.TabIndex = 0;
            // 
            // ActorList
            // 
            this.ActorList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.ActorList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ActorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActorList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.ActorList.FormattingEnabled = true;
            this.ActorList.Location = new System.Drawing.Point(0, 0);
            this.ActorList.Name = "ActorList";
            this.ActorList.ScrollAlwaysVisible = true;
            this.ActorList.Size = new System.Drawing.Size(255, 189);
            this.ActorList.TabIndex = 0;
            this.ActorList.Click += new System.EventHandler(this.ActorList_Click);
            // 
            // SC_GenresActors
            // 
            this.SC_GenresActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_GenresActors.Location = new System.Drawing.Point(0, 0);
            this.SC_GenresActors.Name = "SC_GenresActors";
            // 
            // SC_GenresActors.Panel1
            // 
            this.SC_GenresActors.Panel1.Controls.Add(this.GenreList);
            // 
            // SC_GenresActors.Panel2
            // 
            this.SC_GenresActors.Panel2.Controls.Add(this.DirectorList);
            this.SC_GenresActors.Size = new System.Drawing.Size(374, 189);
            this.SC_GenresActors.SplitterDistance = 119;
            this.SC_GenresActors.TabIndex = 0;
            // 
            // GenreList
            // 
            this.GenreList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.GenreList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GenreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenreList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.GenreList.FormattingEnabled = true;
            this.GenreList.Location = new System.Drawing.Point(0, 0);
            this.GenreList.Name = "GenreList";
            this.GenreList.Size = new System.Drawing.Size(119, 189);
            this.GenreList.TabIndex = 0;
            this.GenreList.Click += new System.EventHandler(this.GenreList_Click);
            // 
            // DirectorList
            // 
            this.DirectorList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.DirectorList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DirectorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectorList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.DirectorList.FormattingEnabled = true;
            this.DirectorList.Location = new System.Drawing.Point(0, 0);
            this.DirectorList.Name = "DirectorList";
            this.DirectorList.ScrollAlwaysVisible = true;
            this.DirectorList.Size = new System.Drawing.Size(251, 189);
            this.DirectorList.TabIndex = 0;
            this.DirectorList.Click += new System.EventHandler(this.DirectorList_Click);
            // 
            // SC_FilmDataGridDetControls
            // 
            this.SC_FilmDataGridDetControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_FilmDataGridDetControls.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SC_FilmDataGridDetControls.IsSplitterFixed = true;
            this.SC_FilmDataGridDetControls.Location = new System.Drawing.Point(0, 0);
            this.SC_FilmDataGridDetControls.Name = "SC_FilmDataGridDetControls";
            this.SC_FilmDataGridDetControls.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_FilmDataGridDetControls.Panel1
            // 
            this.SC_FilmDataGridDetControls.Panel1.Controls.Add(this.SC_DatagridSynopsis);
            // 
            // SC_FilmDataGridDetControls.Panel2
            // 
            this.SC_FilmDataGridDetControls.Panel2.Controls.Add(this.btn_PlayFilm);
            this.SC_FilmDataGridDetControls.Panel2.Controls.Add(this.btn_showHideFilmDetails);
            this.SC_FilmDataGridDetControls.Panel2.Controls.Add(this.btn_CrtPlaylist);
            this.SC_FilmDataGridDetControls.Panel2.Controls.Add(this.lbl_LibraryDetails);
            this.SC_FilmDataGridDetControls.Panel2.Controls.Add(this.shapeContainer1);
            this.SC_FilmDataGridDetControls.Size = new System.Drawing.Size(633, 262);
            this.SC_FilmDataGridDetControls.SplitterDistance = 228;
            this.SC_FilmDataGridDetControls.TabIndex = 6;
            // 
            // SC_DatagridSynopsis
            // 
            this.SC_DatagridSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_DatagridSynopsis.Location = new System.Drawing.Point(0, 0);
            this.SC_DatagridSynopsis.Name = "SC_DatagridSynopsis";
            // 
            // SC_DatagridSynopsis.Panel1
            // 
            this.SC_DatagridSynopsis.Panel1.Controls.Add(this.DGV_Films);
            // 
            // SC_DatagridSynopsis.Panel2
            // 
            this.SC_DatagridSynopsis.Panel2.Controls.Add(this.SC_CastSynopsis);
            this.SC_DatagridSynopsis.Size = new System.Drawing.Size(633, 228);
            this.SC_DatagridSynopsis.SplitterDistance = 309;
            this.SC_DatagridSynopsis.TabIndex = 6;
            // 
            // DGV_Films
            // 
            this.DGV_Films.AllowUserToAddRows = false;
            this.DGV_Films.AllowUserToDeleteRows = false;
            this.DGV_Films.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.DGV_Films.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Films.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.DGV_Films.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_Films.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Films.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_Films.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Films.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_Films.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Films.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.DGV_Films.Location = new System.Drawing.Point(0, 0);
            this.DGV_Films.Name = "DGV_Films";
            this.DGV_Films.ReadOnly = true;
            this.DGV_Films.RowHeadersVisible = false;
            this.DGV_Films.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.DGV_Films.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.DGV_Films.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Films.Size = new System.Drawing.Size(309, 228);
            this.DGV_Films.TabIndex = 2;
            this.DGV_Films.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.DGV_Films.Click += new System.EventHandler(this.DGV_Films_Click);
            // 
            // SC_CastSynopsis
            // 
            this.SC_CastSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_CastSynopsis.Location = new System.Drawing.Point(0, 0);
            this.SC_CastSynopsis.Name = "SC_CastSynopsis";
            this.SC_CastSynopsis.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_CastSynopsis.Panel1
            // 
            this.SC_CastSynopsis.Panel1.Controls.Add(this.panel3);
            this.SC_CastSynopsis.Panel1.Controls.Add(this.pn_RuntimeReleaseDate);
            // 
            // SC_CastSynopsis.Panel2
            // 
            this.SC_CastSynopsis.Panel2.Controls.Add(this.txtb_Synopsis);
            this.SC_CastSynopsis.Size = new System.Drawing.Size(320, 228);
            this.SC_CastSynopsis.SplitterDistance = 119;
            this.SC_CastSynopsis.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lv_FilmCast);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 100);
            this.panel3.TabIndex = 0;
            // 
            // lv_FilmCast
            // 
            this.lv_FilmCast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.lv_FilmCast.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_FilmCast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_Actor,
            this.clm_Character});
            this.lv_FilmCast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_FilmCast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lv_FilmCast.FullRowSelect = true;
            this.lv_FilmCast.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_FilmCast.Location = new System.Drawing.Point(0, 0);
            this.lv_FilmCast.Name = "lv_FilmCast";
            this.lv_FilmCast.Size = new System.Drawing.Size(320, 100);
            this.lv_FilmCast.TabIndex = 0;
            this.lv_FilmCast.UseCompatibleStateImageBehavior = false;
            this.lv_FilmCast.View = System.Windows.Forms.View.Details;
            this.lv_FilmCast.Click += new System.EventHandler(this.lv_FilmCast_Click);
            // 
            // clm_Actor
            // 
            this.clm_Actor.Text = "Actor";
            this.clm_Actor.Width = 152;
            // 
            // clm_Character
            // 
            this.clm_Character.Text = "Character";
            this.clm_Character.Width = 151;
            // 
            // pn_RuntimeReleaseDate
            // 
            this.pn_RuntimeReleaseDate.Controls.Add(this.lbl_RTimeLabel);
            this.pn_RuntimeReleaseDate.Controls.Add(this.lbl_rTime);
            this.pn_RuntimeReleaseDate.Controls.Add(this.lbl_RDateLabel);
            this.pn_RuntimeReleaseDate.Controls.Add(this.lbl_rdate);
            this.pn_RuntimeReleaseDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_RuntimeReleaseDate.Location = new System.Drawing.Point(0, 0);
            this.pn_RuntimeReleaseDate.Name = "pn_RuntimeReleaseDate";
            this.pn_RuntimeReleaseDate.Size = new System.Drawing.Size(320, 19);
            this.pn_RuntimeReleaseDate.TabIndex = 1;
            // 
            // lbl_RTimeLabel
            // 
            this.lbl_RTimeLabel.AutoSize = true;
            this.lbl_RTimeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_RTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_RTimeLabel.Location = new System.Drawing.Point(53, 0);
            this.lbl_RTimeLabel.Name = "lbl_RTimeLabel";
            this.lbl_RTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.lbl_RTimeLabel.TabIndex = 0;
            // 
            // lbl_rTime
            // 
            this.lbl_rTime.AutoSize = true;
            this.lbl_rTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_rTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_rTime.Location = new System.Drawing.Point(0, 0);
            this.lbl_rTime.Name = "lbl_rTime";
            this.lbl_rTime.Size = new System.Drawing.Size(53, 13);
            this.lbl_rTime.TabIndex = 1;
            this.lbl_rTime.Text = "RunTime:";
            // 
            // lbl_RDateLabel
            // 
            this.lbl_RDateLabel.AutoSize = true;
            this.lbl_RDateLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_RDateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_RDateLabel.Location = new System.Drawing.Point(245, 0);
            this.lbl_RDateLabel.Name = "lbl_RDateLabel";
            this.lbl_RDateLabel.Size = new System.Drawing.Size(75, 13);
            this.lbl_RDateLabel.TabIndex = 3;
            this.lbl_RDateLabel.Text = "Release Date:";
            // 
            // lbl_rdate
            // 
            this.lbl_rdate.AutoSize = true;
            this.lbl_rdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_rdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_rdate.Location = new System.Drawing.Point(320, 0);
            this.lbl_rdate.Name = "lbl_rdate";
            this.lbl_rdate.Size = new System.Drawing.Size(0, 13);
            this.lbl_rdate.TabIndex = 2;
            // 
            // txtb_Synopsis
            // 
            this.txtb_Synopsis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.txtb_Synopsis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtb_Synopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtb_Synopsis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.txtb_Synopsis.Location = new System.Drawing.Point(0, 0);
            this.txtb_Synopsis.Multiline = true;
            this.txtb_Synopsis.Name = "txtb_Synopsis";
            this.txtb_Synopsis.ReadOnly = true;
            this.txtb_Synopsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtb_Synopsis.Size = new System.Drawing.Size(320, 105);
            this.txtb_Synopsis.TabIndex = 6;
            // 
            // btn_PlayFilm
            // 
            this.btn_PlayFilm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PlayFilm.Location = new System.Drawing.Point(3, 3);
            this.btn_PlayFilm.Name = "btn_PlayFilm";
            this.btn_PlayFilm.Size = new System.Drawing.Size(75, 23);
            this.btn_PlayFilm.TabIndex = 3;
            this.btn_PlayFilm.Text = "Play";
            this.btn_PlayFilm.UseVisualStyleBackColor = true;
            // 
            // btn_showHideFilmDetails
            // 
            this.btn_showHideFilmDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_showHideFilmDetails.AutoSize = true;
            this.btn_showHideFilmDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_showHideFilmDetails.Location = new System.Drawing.Point(175, 3);
            this.btn_showHideFilmDetails.Name = "btn_showHideFilmDetails";
            this.btn_showHideFilmDetails.Size = new System.Drawing.Size(74, 23);
            this.btn_showHideFilmDetails.TabIndex = 5;
            this.btn_showHideFilmDetails.Text = "Hide Details";
            this.btn_showHideFilmDetails.UseVisualStyleBackColor = true;
            this.btn_showHideFilmDetails.Click += new System.EventHandler(this.btn_showHideFilmDetails_Click);
            // 
            // btn_CrtPlaylist
            // 
            this.btn_CrtPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CrtPlaylist.Location = new System.Drawing.Point(84, 3);
            this.btn_CrtPlaylist.Name = "btn_CrtPlaylist";
            this.btn_CrtPlaylist.Size = new System.Drawing.Size(85, 23);
            this.btn_CrtPlaylist.TabIndex = 4;
            this.btn_CrtPlaylist.Text = "Create Playlist";
            this.btn_CrtPlaylist.UseVisualStyleBackColor = true;
            // 
            // lbl_LibraryDetails
            // 
            this.lbl_LibraryDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_LibraryDetails.AutoSize = true;
            this.lbl_LibraryDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_LibraryDetails.Location = new System.Drawing.Point(255, 8);
            this.lbl_LibraryDetails.Name = "lbl_LibraryDetails";
            this.lbl_LibraryDetails.Size = new System.Drawing.Size(0, 13);
            this.lbl_LibraryDetails.TabIndex = 5;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(633, 30);
            this.shapeContainer1.TabIndex = 6;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = -1;
            this.lineShape2.X2 = 620;
            this.lineShape2.Y1 = 29;
            this.lineShape2.Y2 = 29;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = -4;
            this.lineShape1.X2 = 614;
            this.lineShape1.Y1 = 0;
            this.lineShape1.Y2 = 0;
            // 
            // SelectedFilmDetailsPanel
            // 
            this.SelectedFilmDetailsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.SelectedFilmDetailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectedFilmDetailsPanel.Controls.Add(this.panel1);
            this.SelectedFilmDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedFilmDetailsPanel.Location = new System.Drawing.Point(0, 0);
            this.SelectedFilmDetailsPanel.Name = "SelectedFilmDetailsPanel";
            this.SelectedFilmDetailsPanel.Size = new System.Drawing.Size(633, 90);
            this.SelectedFilmDetailsPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 19);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click on a film in your local library to see more details.";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FilmLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SC_SearchLibrary);
            this.Name = "FilmLibrary";
            this.Size = new System.Drawing.Size(633, 579);
            this.SC_SearchLibrary.Panel1.ResumeLayout(false);
            this.SC_SearchLibrary.Panel1.PerformLayout();
            this.SC_SearchLibrary.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_SearchLibrary)).EndInit();
            this.SC_SearchLibrary.ResumeLayout(false);
            this.PN_FilmLibrary.ResumeLayout(false);
            this.SC_LibraryDetails.Panel1.ResumeLayout(false);
            this.SC_LibraryDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_LibraryDetails)).EndInit();
            this.SC_LibraryDetails.ResumeLayout(false);
            this.SC_MLTopFilm.Panel1.ResumeLayout(false);
            this.SC_MLTopFilm.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_MLTopFilm)).EndInit();
            this.SC_MLTopFilm.ResumeLayout(false);
            this.SC_DirectorsActors.Panel1.ResumeLayout(false);
            this.SC_DirectorsActors.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_DirectorsActors)).EndInit();
            this.SC_DirectorsActors.ResumeLayout(false);
            this.SC_GenresActors.Panel1.ResumeLayout(false);
            this.SC_GenresActors.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_GenresActors)).EndInit();
            this.SC_GenresActors.ResumeLayout(false);
            this.SC_FilmDataGridDetControls.Panel1.ResumeLayout(false);
            this.SC_FilmDataGridDetControls.Panel2.ResumeLayout(false);
            this.SC_FilmDataGridDetControls.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_FilmDataGridDetControls)).EndInit();
            this.SC_FilmDataGridDetControls.ResumeLayout(false);
            this.SC_DatagridSynopsis.Panel1.ResumeLayout(false);
            this.SC_DatagridSynopsis.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_DatagridSynopsis)).EndInit();
            this.SC_DatagridSynopsis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Films)).EndInit();
            this.SC_CastSynopsis.Panel1.ResumeLayout(false);
            this.SC_CastSynopsis.Panel2.ResumeLayout(false);
            this.SC_CastSynopsis.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_CastSynopsis)).EndInit();
            this.SC_CastSynopsis.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pn_RuntimeReleaseDate.ResumeLayout(false);
            this.pn_RuntimeReleaseDate.PerformLayout();
            this.SelectedFilmDetailsPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SC_SearchLibrary;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_AdvSearch;
        private System.Windows.Forms.TextBox txtb_Search;
        private System.Windows.Forms.Label lbl_Search;
        private System.Windows.Forms.Panel PN_FilmLibrary;
        private System.Windows.Forms.SplitContainer SC_LibraryDetails;
        private System.Windows.Forms.SplitContainer SC_MLTopFilm;
        private System.Windows.Forms.SplitContainer SC_DirectorsActors;
        private System.Windows.Forms.ListBox ActorList;
        private System.Windows.Forms.SplitContainer SC_GenresActors;
        private System.Windows.Forms.ListBox GenreList;
        private System.Windows.Forms.ListBox DirectorList;
        private System.Windows.Forms.SplitContainer SC_FilmDataGridDetControls;
        private System.Windows.Forms.SplitContainer SC_DatagridSynopsis;
        private System.Windows.Forms.DataGridView DGV_Films;
        private System.Windows.Forms.SplitContainer SC_CastSynopsis;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lv_FilmCast;
        private System.Windows.Forms.ColumnHeader clm_Actor;
        private System.Windows.Forms.ColumnHeader clm_Character;
        private System.Windows.Forms.Panel pn_RuntimeReleaseDate;
        private System.Windows.Forms.Label lbl_RTimeLabel;
        private System.Windows.Forms.Label lbl_rTime;
        private System.Windows.Forms.Label lbl_RDateLabel;
        private System.Windows.Forms.Label lbl_rdate;
        private System.Windows.Forms.TextBox txtb_Synopsis;
        private System.Windows.Forms.Button btn_PlayFilm;
        private System.Windows.Forms.Button btn_showHideFilmDetails;
        private System.Windows.Forms.Button btn_CrtPlaylist;
        private System.Windows.Forms.Label lbl_LibraryDetails;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Panel SelectedFilmDetailsPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}
