namespace MediaApp
{
    partial class FRM_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Main));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Film", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tv");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Local Media", 4, 4, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Playlists");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CMS_Settings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMSI_dataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSI_creatDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.TT_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btn_SetAlarm = new System.Windows.Forms.Button();
            this.btn_ToggleAlarm = new System.Windows.Forms.Button();
            this.btn_SetTime = new System.Windows.Forms.Button();
            this.btn_PlaylistShowHide = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SC_MainPlaylist = new System.Windows.Forms.SplitContainer();
            this.SC_APPControlsLibrary = new System.Windows.Forms.SplitContainer();
            this.PN_Controls = new System.Windows.Forms.Panel();
            this.SC_APPControlsNowPlayingDetails = new System.Windows.Forms.SplitContainer();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.btn_rndTV = new System.Windows.Forms.Button();
            this.btn_PreviousTrack = new System.Windows.Forms.Button();
            this.PN_TimeDateDisplay = new System.Windows.Forms.Panel();
            this.lbl_AlarmStatus = new System.Windows.Forms.Label();
            this.lbl_DayOfWeek = new System.Windows.Forms.Label();
            this.lbl_12HourClk = new System.Windows.Forms.Label();
            this.lbl_Alarm = new System.Windows.Forms.Label();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.lbl_runtime = new System.Windows.Forms.Label();
            this.btn_RptToggle = new System.Windows.Forms.Button();
            this.btn_RndFilm = new System.Windows.Forms.Button();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_RndPlaylist = new System.Windows.Forms.Button();
            this.btn_FF = new System.Windows.Forms.Button();
            this.lbl_CurrentPosition = new System.Windows.Forms.Label();
            this.btn_PlayPause = new System.Windows.Forms.Button();
            this.btn_Rewind = new System.Windows.Forms.Button();
            this.btn_nextTrack = new System.Windows.Forms.Button();
            this.PN_Library = new System.Windows.Forms.Panel();
            this.TBC_Library = new System.Windows.Forms.TabControl();
            this.TBP_MediaLibrary = new System.Windows.Forms.TabPage();
            this.SC_LibraryNavLibrary = new System.Windows.Forms.SplitContainer();
            this.TV_Library = new System.Windows.Forms.TreeView();
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
            this.PN_TVLibrary = new System.Windows.Forms.Panel();
            this.SC_TVLibrarySelectedDetails = new System.Windows.Forms.SplitContainer();
            this.SC_TVDetailsControlLibrary = new System.Windows.Forms.SplitContainer();
            this.SC_TVTopBottem = new System.Windows.Forms.SplitContainer();
            this.SC_TVSeriesSeason = new System.Windows.Forms.SplitContainer();
            this.lisb_TVSeries = new System.Windows.Forms.ListBox();
            this.SC_TVSeasonEpisode = new System.Windows.Forms.SplitContainer();
            this.lisb_TVSeasons = new System.Windows.Forms.ListBox();
            this.lisb_TVEpisodes = new System.Windows.Forms.ListBox();
            this.SC_TVCastSynopsis = new System.Windows.Forms.SplitContainer();
            this.lisb_TVCast = new System.Windows.Forms.ListBox();
            this.txtb_TVSynopsis = new System.Windows.Forms.TextBox();
            this.lbl_ListedDetails = new System.Windows.Forms.Label();
            this.btn_ShowHideTVDetails = new System.Windows.Forms.Button();
            this.btn_TVPlaySelected = new System.Windows.Forms.Button();
            this.btn_TVCreatePlaylist = new System.Windows.Forms.Button();
            this.TBP_Video = new System.Windows.Forms.TabPage();
            this.VLC_Player = new AxAXVLC.AxVLCPlugin2();
            this.PN_Playlist = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lisv_Playlist = new System.Windows.Forms.ListView();
            this.clm_title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_playlistSettings = new System.Windows.Forms.Button();
            this.btn_removeFromPlaylist = new System.Windows.Forms.Button();
            this.btn_AddToPlaylist = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CMS_Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_MainPlaylist)).BeginInit();
            this.SC_MainPlaylist.Panel1.SuspendLayout();
            this.SC_MainPlaylist.Panel2.SuspendLayout();
            this.SC_MainPlaylist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_APPControlsLibrary)).BeginInit();
            this.SC_APPControlsLibrary.Panel1.SuspendLayout();
            this.SC_APPControlsLibrary.Panel2.SuspendLayout();
            this.SC_APPControlsLibrary.SuspendLayout();
            this.PN_Controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_APPControlsNowPlayingDetails)).BeginInit();
            this.SC_APPControlsNowPlayingDetails.Panel1.SuspendLayout();
            this.SC_APPControlsNowPlayingDetails.Panel2.SuspendLayout();
            this.SC_APPControlsNowPlayingDetails.SuspendLayout();
            this.PN_TimeDateDisplay.SuspendLayout();
            this.PN_Library.SuspendLayout();
            this.TBC_Library.SuspendLayout();
            this.TBP_MediaLibrary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_LibraryNavLibrary)).BeginInit();
            this.SC_LibraryNavLibrary.Panel1.SuspendLayout();
            this.SC_LibraryNavLibrary.Panel2.SuspendLayout();
            this.SC_LibraryNavLibrary.SuspendLayout();
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
            this.PN_TVLibrary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVLibrarySelectedDetails)).BeginInit();
            this.SC_TVLibrarySelectedDetails.Panel1.SuspendLayout();
            this.SC_TVLibrarySelectedDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVDetailsControlLibrary)).BeginInit();
            this.SC_TVDetailsControlLibrary.Panel1.SuspendLayout();
            this.SC_TVDetailsControlLibrary.Panel2.SuspendLayout();
            this.SC_TVDetailsControlLibrary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVTopBottem)).BeginInit();
            this.SC_TVTopBottem.Panel1.SuspendLayout();
            this.SC_TVTopBottem.Panel2.SuspendLayout();
            this.SC_TVTopBottem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVSeriesSeason)).BeginInit();
            this.SC_TVSeriesSeason.Panel1.SuspendLayout();
            this.SC_TVSeriesSeason.Panel2.SuspendLayout();
            this.SC_TVSeriesSeason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVSeasonEpisode)).BeginInit();
            this.SC_TVSeasonEpisode.Panel1.SuspendLayout();
            this.SC_TVSeasonEpisode.Panel2.SuspendLayout();
            this.SC_TVSeasonEpisode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVCastSynopsis)).BeginInit();
            this.SC_TVCastSynopsis.Panel1.SuspendLayout();
            this.SC_TVCastSynopsis.Panel2.SuspendLayout();
            this.SC_TVCastSynopsis.SuspendLayout();
            this.TBP_Video.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLC_Player)).BeginInit();
            this.PN_Playlist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CMS_Settings
            // 
            this.CMS_Settings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMSI_dataBase});
            this.CMS_Settings.Name = "contextMenuStrip1";
            this.CMS_Settings.Size = new System.Drawing.Size(126, 26);
            // 
            // CMSI_dataBase
            // 
            this.CMSI_dataBase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMSI_creatDataBase});
            this.CMSI_dataBase.Name = "CMSI_dataBase";
            this.CMSI_dataBase.Size = new System.Drawing.Size(125, 22);
            this.CMSI_dataBase.Text = "Data Base";
            // 
            // CMSI_creatDataBase
            // 
            this.CMSI_creatDataBase.Name = "CMSI_creatDataBase";
            this.CMSI_creatDataBase.Size = new System.Drawing.Size(153, 22);
            this.CMSI_creatDataBase.Text = "Creat DataBase";
            this.CMSI_creatDataBase.Click += new System.EventHandler(this.creatDataBaseToolStripMenuItem_Click);
            // 
            // btn_SetAlarm
            // 
            this.btn_SetAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SetAlarm.Location = new System.Drawing.Point(232, 26);
            this.btn_SetAlarm.Name = "btn_SetAlarm";
            this.btn_SetAlarm.Size = new System.Drawing.Size(14, 10);
            this.btn_SetAlarm.TabIndex = 19;
            this.TT_toolTip.SetToolTip(this.btn_SetAlarm, "Alarm Settings");
            this.btn_SetAlarm.UseVisualStyleBackColor = true;
            // 
            // btn_ToggleAlarm
            // 
            this.btn_ToggleAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ToggleAlarm.Location = new System.Drawing.Point(232, 50);
            this.btn_ToggleAlarm.Name = "btn_ToggleAlarm";
            this.btn_ToggleAlarm.Size = new System.Drawing.Size(14, 10);
            this.btn_ToggleAlarm.TabIndex = 20;
            this.TT_toolTip.SetToolTip(this.btn_ToggleAlarm, "Toggle Alarm\\nCurrent state: Off");
            this.btn_ToggleAlarm.UseVisualStyleBackColor = true;
            // 
            // btn_SetTime
            // 
            this.btn_SetTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SetTime.Location = new System.Drawing.Point(232, 3);
            this.btn_SetTime.Name = "btn_SetTime";
            this.btn_SetTime.Size = new System.Drawing.Size(14, 10);
            this.btn_SetTime.TabIndex = 21;
            this.TT_toolTip.SetToolTip(this.btn_SetTime, "Time Settings");
            this.btn_SetTime.UseVisualStyleBackColor = true;
            this.btn_SetTime.Click += new System.EventHandler(this.btn_SetTime_Click);
            // 
            // btn_PlaylistShowHide
            // 
            this.btn_PlaylistShowHide.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_PlaylistShowHide.Location = new System.Drawing.Point(398, 0);
            this.btn_PlaylistShowHide.Name = "btn_PlaylistShowHide";
            this.btn_PlaylistShowHide.Size = new System.Drawing.Size(18, 121);
            this.btn_PlaylistShowHide.TabIndex = 22;
            this.btn_PlaylistShowHide.Text = ">";
            this.TT_toolTip.SetToolTip(this.btn_PlaylistShowHide, "Show/Hide Playlist");
            this.btn_PlaylistShowHide.UseVisualStyleBackColor = true;
            this.btn_PlaylistShowHide.Click += new System.EventHandler(this.btn_PlaylistShowHide_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Film.gif");
            this.imageList1.Images.SetKeyName(1, "Movie.gif");
            this.imageList1.Images.SetKeyName(2, "Music.gif");
            this.imageList1.Images.SetKeyName(3, "Down.gif");
            this.imageList1.Images.SetKeyName(4, "Forward.gif");
            // 
            // SC_MainPlaylist
            // 
            this.SC_MainPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.SC_MainPlaylist.DataBindings.Add(new System.Windows.Forms.Binding("Panel2Collapsed", global::MediaApp.Properties.Settings.Default, "playlistShow", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SC_MainPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_MainPlaylist.Location = new System.Drawing.Point(0, 0);
            this.SC_MainPlaylist.Name = "SC_MainPlaylist";
            // 
            // SC_MainPlaylist.Panel1
            // 
            this.SC_MainPlaylist.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.SC_MainPlaylist.Panel1.Controls.Add(this.SC_APPControlsLibrary);
            this.SC_MainPlaylist.Panel1MinSize = 650;
            // 
            // SC_MainPlaylist.Panel2
            // 
            this.SC_MainPlaylist.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.SC_MainPlaylist.Panel2.Controls.Add(this.PN_Playlist);
            this.SC_MainPlaylist.Panel2Collapsed = global::MediaApp.Properties.Settings.Default.playlistShow;
            this.SC_MainPlaylist.Size = new System.Drawing.Size(1008, 730);
            this.SC_MainPlaylist.SplitterDistance = 751;
            this.SC_MainPlaylist.TabIndex = 0;
            // 
            // SC_APPControlsLibrary
            // 
            this.SC_APPControlsLibrary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.SC_APPControlsLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_APPControlsLibrary.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SC_APPControlsLibrary.IsSplitterFixed = true;
            this.SC_APPControlsLibrary.Location = new System.Drawing.Point(0, 0);
            this.SC_APPControlsLibrary.Name = "SC_APPControlsLibrary";
            this.SC_APPControlsLibrary.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_APPControlsLibrary.Panel1
            // 
            this.SC_APPControlsLibrary.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.SC_APPControlsLibrary.Panel1.Controls.Add(this.PN_Controls);
            // 
            // SC_APPControlsLibrary.Panel2
            // 
            this.SC_APPControlsLibrary.Panel2.Controls.Add(this.PN_Library);
            this.SC_APPControlsLibrary.Size = new System.Drawing.Size(751, 730);
            this.SC_APPControlsLibrary.SplitterDistance = 125;
            this.SC_APPControlsLibrary.TabIndex = 0;
            // 
            // PN_Controls
            // 
            this.PN_Controls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.PN_Controls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PN_Controls.Controls.Add(this.SC_APPControlsNowPlayingDetails);
            this.PN_Controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_Controls.Location = new System.Drawing.Point(0, 0);
            this.PN_Controls.Name = "PN_Controls";
            this.PN_Controls.Size = new System.Drawing.Size(751, 125);
            this.PN_Controls.TabIndex = 12;
            // 
            // SC_APPControlsNowPlayingDetails
            // 
            this.SC_APPControlsNowPlayingDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_APPControlsNowPlayingDetails.Location = new System.Drawing.Point(0, 0);
            this.SC_APPControlsNowPlayingDetails.Name = "SC_APPControlsNowPlayingDetails";
            // 
            // SC_APPControlsNowPlayingDetails.Panel1
            // 
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.elementHost2);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.elementHost1);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_rndTV);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_PreviousTrack);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.PN_TimeDateDisplay);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_Stop);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_SetAlarm);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.lbl_runtime);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_RptToggle);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_RndFilm);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_Settings);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_RndPlaylist);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_FF);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.lbl_CurrentPosition);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_PlayPause);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_ToggleAlarm);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_Rewind);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_SetTime);
            this.SC_APPControlsNowPlayingDetails.Panel1.Controls.Add(this.btn_nextTrack);
            // 
            // SC_APPControlsNowPlayingDetails.Panel2
            // 
            this.SC_APPControlsNowPlayingDetails.Panel2.Controls.Add(this.btn_PlaylistShowHide);
            this.SC_APPControlsNowPlayingDetails.Size = new System.Drawing.Size(747, 121);
            this.SC_APPControlsNowPlayingDetails.SplitterDistance = 327;
            this.SC_APPControlsNowPlayingDetails.TabIndex = 24;
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(225, 66);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(21, 50);
            this.elementHost2.TabIndex = 23;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = null;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(7, 91);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(161, 21);
            this.elementHost1.TabIndex = 23;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // btn_rndTV
            // 
            this.btn_rndTV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_rndTV.Location = new System.Drawing.Point(252, 2);
            this.btn_rndTV.Name = "btn_rndTV";
            this.btn_rndTV.Size = new System.Drawing.Size(71, 22);
            this.btn_rndTV.TabIndex = 13;
            this.btn_rndTV.Text = "TV Episode";
            this.btn_rndTV.UseVisualStyleBackColor = true;
            // 
            // btn_PreviousTrack
            // 
            this.btn_PreviousTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PreviousTrack.Image = global::MediaApp.Properties.Resources.Back;
            this.btn_PreviousTrack.Location = new System.Drawing.Point(53, 66);
            this.btn_PreviousTrack.Name = "btn_PreviousTrack";
            this.btn_PreviousTrack.Size = new System.Drawing.Size(23, 23);
            this.btn_PreviousTrack.TabIndex = 3;
            this.btn_PreviousTrack.UseVisualStyleBackColor = true;
            this.btn_PreviousTrack.Click += new System.EventHandler(this.btn_PreviousTrack_Click);
            // 
            // PN_TimeDateDisplay
            // 
            this.PN_TimeDateDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PN_TimeDateDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(255)))), ((int)(((byte)(130)))));
            this.PN_TimeDateDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PN_TimeDateDisplay.Controls.Add(this.lbl_AlarmStatus);
            this.PN_TimeDateDisplay.Controls.Add(this.lbl_DayOfWeek);
            this.PN_TimeDateDisplay.Controls.Add(this.lbl_12HourClk);
            this.PN_TimeDateDisplay.Controls.Add(this.lbl_Alarm);
            this.PN_TimeDateDisplay.Controls.Add(this.lbl_Date);
            this.PN_TimeDateDisplay.Controls.Add(this.lbl_time);
            this.PN_TimeDateDisplay.Location = new System.Drawing.Point(7, 3);
            this.PN_TimeDateDisplay.Name = "PN_TimeDateDisplay";
            this.PN_TimeDateDisplay.Size = new System.Drawing.Size(225, 57);
            this.PN_TimeDateDisplay.TabIndex = 18;
            // 
            // lbl_AlarmStatus
            // 
            this.lbl_AlarmStatus.AutoSize = true;
            this.lbl_AlarmStatus.ForeColor = System.Drawing.Color.Red;
            this.lbl_AlarmStatus.Location = new System.Drawing.Point(192, 3);
            this.lbl_AlarmStatus.Name = "lbl_AlarmStatus";
            this.lbl_AlarmStatus.Size = new System.Drawing.Size(28, 13);
            this.lbl_AlarmStatus.TabIndex = 5;
            this.lbl_AlarmStatus.Text = "ALR";
            this.lbl_AlarmStatus.Visible = false;
            // 
            // lbl_DayOfWeek
            // 
            this.lbl_DayOfWeek.AutoSize = true;
            this.lbl_DayOfWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.lbl_DayOfWeek.Location = new System.Drawing.Point(84, 3);
            this.lbl_DayOfWeek.Name = "lbl_DayOfWeek";
            this.lbl_DayOfWeek.Size = new System.Drawing.Size(64, 13);
            this.lbl_DayOfWeek.TabIndex = 4;
            this.lbl_DayOfWeek.Text = "Wednesday";
            // 
            // lbl_12HourClk
            // 
            this.lbl_12HourClk.AutoSize = true;
            this.lbl_12HourClk.ForeColor = System.Drawing.Color.Red;
            this.lbl_12HourClk.Location = new System.Drawing.Point(6, 4);
            this.lbl_12HourClk.Name = "lbl_12HourClk";
            this.lbl_12HourClk.Size = new System.Drawing.Size(23, 13);
            this.lbl_12HourClk.TabIndex = 3;
            this.lbl_12HourClk.Text = "PM";
            this.lbl_12HourClk.Visible = false;
            // 
            // lbl_Alarm
            // 
            this.lbl_Alarm.AutoSize = true;
            this.lbl_Alarm.Location = new System.Drawing.Point(156, 22);
            this.lbl_Alarm.Name = "lbl_Alarm";
            this.lbl_Alarm.Size = new System.Drawing.Size(33, 13);
            this.lbl_Alarm.TabIndex = 2;
            this.lbl_Alarm.Text = "Alarm";
            // 
            // lbl_Date
            // 
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Location = new System.Drawing.Point(93, 22);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(30, 13);
            this.lbl_Date.TabIndex = 1;
            this.lbl_Date.Text = "Date";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Location = new System.Drawing.Point(30, 22);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(30, 13);
            this.lbl_time.TabIndex = 0;
            this.lbl_time.Text = "Time";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Stop.Image = global::MediaApp.Properties.Resources.stop;
            this.btn_Stop.Location = new System.Drawing.Point(136, 66);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(23, 23);
            this.btn_Stop.TabIndex = 7;
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // lbl_runtime
            // 
            this.lbl_runtime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_runtime.AutoSize = true;
            this.lbl_runtime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(255)))), ((int)(((byte)(130)))));
            this.lbl_runtime.Location = new System.Drawing.Point(174, 99);
            this.lbl_runtime.Name = "lbl_runtime";
            this.lbl_runtime.Size = new System.Drawing.Size(49, 13);
            this.lbl_runtime.TabIndex = 11;
            this.lbl_runtime.Text = "00:00:00";
            // 
            // btn_RptToggle
            // 
            this.btn_RptToggle.Location = new System.Drawing.Point(252, 71);
            this.btn_RptToggle.Name = "btn_RptToggle";
            this.btn_RptToggle.Size = new System.Drawing.Size(71, 22);
            this.btn_RptToggle.TabIndex = 16;
            this.btn_RptToggle.Text = "Repeat";
            this.btn_RptToggle.UseVisualStyleBackColor = true;
            // 
            // btn_RndFilm
            // 
            this.btn_RndFilm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_RndFilm.Location = new System.Drawing.Point(252, 25);
            this.btn_RndFilm.Name = "btn_RndFilm";
            this.btn_RndFilm.Size = new System.Drawing.Size(71, 22);
            this.btn_RndFilm.TabIndex = 14;
            this.btn_RndFilm.Text = "Film";
            this.btn_RndFilm.UseVisualStyleBackColor = true;
            this.btn_RndFilm.Click += new System.EventHandler(this.btn_RndFilm_Click);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Settings.ContextMenuStrip = this.CMS_Settings;
            this.btn_Settings.Location = new System.Drawing.Point(252, 94);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(71, 22);
            this.btn_Settings.TabIndex = 17;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_Settings_MouseClick);
            // 
            // btn_RndPlaylist
            // 
            this.btn_RndPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_RndPlaylist.Location = new System.Drawing.Point(252, 48);
            this.btn_RndPlaylist.Name = "btn_RndPlaylist";
            this.btn_RndPlaylist.Size = new System.Drawing.Size(71, 22);
            this.btn_RndPlaylist.TabIndex = 15;
            this.btn_RndPlaylist.Text = "Randomise";
            this.btn_RndPlaylist.UseVisualStyleBackColor = true;
            // 
            // btn_FF
            // 
            this.btn_FF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_FF.Image = global::MediaApp.Properties.Resources.FastFoward;
            this.btn_FF.Location = new System.Drawing.Point(163, 66);
            this.btn_FF.Name = "btn_FF";
            this.btn_FF.Size = new System.Drawing.Size(23, 23);
            this.btn_FF.TabIndex = 6;
            this.btn_FF.UseVisualStyleBackColor = true;
            this.btn_FF.Click += new System.EventHandler(this.btn_FF_Click);
            // 
            // lbl_CurrentPosition
            // 
            this.lbl_CurrentPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_CurrentPosition.AutoSize = true;
            this.lbl_CurrentPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(255)))), ((int)(((byte)(130)))));
            this.lbl_CurrentPosition.Location = new System.Drawing.Point(4, 71);
            this.lbl_CurrentPosition.Name = "lbl_CurrentPosition";
            this.lbl_CurrentPosition.Size = new System.Drawing.Size(49, 13);
            this.lbl_CurrentPosition.TabIndex = 10;
            this.lbl_CurrentPosition.Text = "00:00:00";
            // 
            // btn_PlayPause
            // 
            this.btn_PlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PlayPause.Image = global::MediaApp.Properties.Resources.Play1;
            this.btn_PlayPause.Location = new System.Drawing.Point(109, 66);
            this.btn_PlayPause.Name = "btn_PlayPause";
            this.btn_PlayPause.Size = new System.Drawing.Size(23, 23);
            this.btn_PlayPause.TabIndex = 8;
            this.btn_PlayPause.UseVisualStyleBackColor = true;
            this.btn_PlayPause.Click += new System.EventHandler(this.btn_PlayPause_Click);
            // 
            // btn_Rewind
            // 
            this.btn_Rewind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Rewind.Image = global::MediaApp.Properties.Resources.Rewind1;
            this.btn_Rewind.Location = new System.Drawing.Point(82, 66);
            this.btn_Rewind.Name = "btn_Rewind";
            this.btn_Rewind.Size = new System.Drawing.Size(23, 23);
            this.btn_Rewind.TabIndex = 9;
            this.btn_Rewind.UseVisualStyleBackColor = true;
            this.btn_Rewind.Click += new System.EventHandler(this.btn_Rewind_Click);
            // 
            // btn_nextTrack
            // 
            this.btn_nextTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_nextTrack.Image = global::MediaApp.Properties.Resources.Next;
            this.btn_nextTrack.Location = new System.Drawing.Point(190, 66);
            this.btn_nextTrack.Name = "btn_nextTrack";
            this.btn_nextTrack.Size = new System.Drawing.Size(23, 23);
            this.btn_nextTrack.TabIndex = 5;
            this.btn_nextTrack.UseVisualStyleBackColor = true;
            this.btn_nextTrack.Click += new System.EventHandler(this.btn_nextTrack_Click);
            // 
            // PN_Library
            // 
            this.PN_Library.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.PN_Library.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PN_Library.Controls.Add(this.TBC_Library);
            this.PN_Library.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_Library.Location = new System.Drawing.Point(0, 0);
            this.PN_Library.Name = "PN_Library";
            this.PN_Library.Size = new System.Drawing.Size(751, 601);
            this.PN_Library.TabIndex = 0;
            // 
            // TBC_Library
            // 
            this.TBC_Library.Controls.Add(this.TBP_MediaLibrary);
            this.TBC_Library.Controls.Add(this.TBP_Video);
            this.TBC_Library.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBC_Library.Location = new System.Drawing.Point(0, 0);
            this.TBC_Library.Name = "TBC_Library";
            this.TBC_Library.SelectedIndex = 0;
            this.TBC_Library.Size = new System.Drawing.Size(747, 597);
            this.TBC_Library.TabIndex = 0;
            // 
            // TBP_MediaLibrary
            // 
            this.TBP_MediaLibrary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.TBP_MediaLibrary.Controls.Add(this.SC_LibraryNavLibrary);
            this.TBP_MediaLibrary.Location = new System.Drawing.Point(4, 22);
            this.TBP_MediaLibrary.Name = "TBP_MediaLibrary";
            this.TBP_MediaLibrary.Padding = new System.Windows.Forms.Padding(3);
            this.TBP_MediaLibrary.Size = new System.Drawing.Size(739, 571);
            this.TBP_MediaLibrary.TabIndex = 0;
            this.TBP_MediaLibrary.Text = "Media Library";
            // 
            // SC_LibraryNavLibrary
            // 
            this.SC_LibraryNavLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_LibraryNavLibrary.IsSplitterFixed = true;
            this.SC_LibraryNavLibrary.Location = new System.Drawing.Point(3, 3);
            this.SC_LibraryNavLibrary.Name = "SC_LibraryNavLibrary";
            // 
            // SC_LibraryNavLibrary.Panel1
            // 
            this.SC_LibraryNavLibrary.Panel1.Controls.Add(this.TV_Library);
            // 
            // SC_LibraryNavLibrary.Panel2
            // 
            this.SC_LibraryNavLibrary.Panel2.Controls.Add(this.SC_SearchLibrary);
            this.SC_LibraryNavLibrary.Size = new System.Drawing.Size(733, 565);
            this.SC_LibraryNavLibrary.SplitterDistance = 113;
            this.SC_LibraryNavLibrary.TabIndex = 0;
            // 
            // TV_Library
            // 
            this.TV_Library.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.TV_Library.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Library.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.TV_Library.ImageIndex = 0;
            this.TV_Library.ImageList = this.imageList1;
            this.TV_Library.Location = new System.Drawing.Point(0, 0);
            this.TV_Library.Name = "TV_Library";
            treeNode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Node1";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "Film";
            treeNode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            treeNode2.Name = "Node2";
            treeNode2.Text = "Tv";
            treeNode3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            treeNode3.ImageIndex = 4;
            treeNode3.Name = "Node0";
            treeNode3.SelectedImageIndex = 4;
            treeNode3.StateImageKey = "(none)";
            treeNode3.Text = "Local Media";
            treeNode4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            treeNode4.Name = "Node3";
            treeNode4.Text = "Playlists";
            this.TV_Library.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.TV_Library.SelectedImageIndex = 0;
            this.TV_Library.ShowLines = false;
            this.TV_Library.ShowPlusMinus = false;
            this.TV_Library.Size = new System.Drawing.Size(113, 565);
            this.TV_Library.StateImageList = this.imageList1;
            this.TV_Library.TabIndex = 1;
            this.TV_Library.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Library_AfterSelect);
            this.TV_Library.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_Library_NodeMouseClick);
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
            this.SC_SearchLibrary.Panel2.Controls.Add(this.PN_TVLibrary);
            this.SC_SearchLibrary.Size = new System.Drawing.Size(616, 565);
            this.SC_SearchLibrary.SplitterDistance = 26;
            this.SC_SearchLibrary.TabIndex = 0;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear.Location = new System.Drawing.Point(457, 3);
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
            this.btn_AdvSearch.Location = new System.Drawing.Point(538, 3);
            this.btn_AdvSearch.Name = "btn_AdvSearch";
            this.btn_AdvSearch.Size = new System.Drawing.Size(75, 21);
            this.btn_AdvSearch.TabIndex = 2;
            this.btn_AdvSearch.Text = "Advanced";
            this.btn_AdvSearch.UseVisualStyleBackColor = true;
            this.btn_AdvSearch.Click += new System.EventHandler(this.btn_AdvSearch_Click);
            // 
            // txtb_Search
            // 
            this.txtb_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_Search.Location = new System.Drawing.Point(44, 3);
            this.txtb_Search.Name = "txtb_Search";
            this.txtb_Search.Size = new System.Drawing.Size(407, 20);
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
            this.PN_FilmLibrary.Size = new System.Drawing.Size(616, 535);
            this.PN_FilmLibrary.TabIndex = 0;
            this.PN_FilmLibrary.Visible = false;
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
            this.SC_LibraryDetails.Size = new System.Drawing.Size(616, 535);
            this.SC_LibraryDetails.SplitterDistance = 441;
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
            this.SC_MLTopFilm.Size = new System.Drawing.Size(616, 441);
            this.SC_MLTopFilm.SplitterDistance = 184;
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
            this.SC_DirectorsActors.Size = new System.Drawing.Size(616, 184);
            this.SC_DirectorsActors.SplitterDistance = 249;
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
            this.ActorList.Size = new System.Drawing.Size(249, 184);
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
            this.SC_GenresActors.Size = new System.Drawing.Size(363, 184);
            this.SC_GenresActors.SplitterDistance = 116;
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
            this.GenreList.Size = new System.Drawing.Size(116, 184);
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
            this.DirectorList.Size = new System.Drawing.Size(243, 184);
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
            this.SC_FilmDataGridDetControls.Size = new System.Drawing.Size(616, 253);
            this.SC_FilmDataGridDetControls.SplitterDistance = 219;
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
            this.SC_DatagridSynopsis.Size = new System.Drawing.Size(616, 219);
            this.SC_DatagridSynopsis.SplitterDistance = 301;
            this.SC_DatagridSynopsis.TabIndex = 6;
            // 
            // DGV_Films
            // 
            this.DGV_Films.AllowUserToAddRows = false;
            this.DGV_Films.AllowUserToDeleteRows = false;
            this.DGV_Films.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.DGV_Films.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_Films.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.DGV_Films.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_Films.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Films.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGV_Films.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Films.DefaultCellStyle = dataGridViewCellStyle9;
            this.DGV_Films.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Films.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.DGV_Films.Location = new System.Drawing.Point(0, 0);
            this.DGV_Films.Name = "DGV_Films";
            this.DGV_Films.ReadOnly = true;
            this.DGV_Films.RowHeadersVisible = false;
            this.DGV_Films.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.DGV_Films.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.DGV_Films.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Films.Size = new System.Drawing.Size(301, 219);
            this.DGV_Films.TabIndex = 2;
            this.DGV_Films.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Films_CellMouseDoubleClick);
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
            this.SC_CastSynopsis.Size = new System.Drawing.Size(311, 219);
            this.SC_CastSynopsis.SplitterDistance = 115;
            this.SC_CastSynopsis.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lv_FilmCast);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(311, 96);
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
            this.lv_FilmCast.Size = new System.Drawing.Size(311, 96);
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
            this.pn_RuntimeReleaseDate.Size = new System.Drawing.Size(311, 19);
            this.pn_RuntimeReleaseDate.TabIndex = 1;
            // 
            // lbl_RTimeLabel
            // 
            this.lbl_RTimeLabel.AutoSize = true;
            this.lbl_RTimeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_RTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_RTimeLabel.Location = new System.Drawing.Point(53, 0);
            this.lbl_RTimeLabel.Name = "lbl_RTimeLabel";
            this.lbl_RTimeLabel.Size = new System.Drawing.Size(53, 13);
            this.lbl_RTimeLabel.TabIndex = 0;
            this.lbl_RTimeLabel.Text = "Unknown";
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
            this.lbl_RDateLabel.Location = new System.Drawing.Point(183, 0);
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
            this.lbl_rdate.Location = new System.Drawing.Point(258, 0);
            this.lbl_rdate.Name = "lbl_rdate";
            this.lbl_rdate.Size = new System.Drawing.Size(53, 13);
            this.lbl_rdate.TabIndex = 2;
            this.lbl_rdate.Text = "Unknown";
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
            this.txtb_Synopsis.Size = new System.Drawing.Size(311, 100);
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
            this.lbl_LibraryDetails.Size = new System.Drawing.Size(35, 13);
            this.lbl_LibraryDetails.TabIndex = 5;
            this.lbl_LibraryDetails.Text = "label1";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(616, 30);
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
            this.SelectedFilmDetailsPanel.Size = new System.Drawing.Size(616, 90);
            this.SelectedFilmDetailsPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 19);
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
            // PN_TVLibrary
            // 
            this.PN_TVLibrary.Controls.Add(this.SC_TVLibrarySelectedDetails);
            this.PN_TVLibrary.Location = new System.Drawing.Point(3, 3);
            this.PN_TVLibrary.Name = "PN_TVLibrary";
            this.PN_TVLibrary.Size = new System.Drawing.Size(289, 524);
            this.PN_TVLibrary.TabIndex = 1;
            this.PN_TVLibrary.Visible = false;
            // 
            // SC_TVLibrarySelectedDetails
            // 
            this.SC_TVLibrarySelectedDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_TVLibrarySelectedDetails.IsSplitterFixed = true;
            this.SC_TVLibrarySelectedDetails.Location = new System.Drawing.Point(0, 0);
            this.SC_TVLibrarySelectedDetails.Name = "SC_TVLibrarySelectedDetails";
            this.SC_TVLibrarySelectedDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_TVLibrarySelectedDetails.Panel1
            // 
            this.SC_TVLibrarySelectedDetails.Panel1.Controls.Add(this.SC_TVDetailsControlLibrary);
            this.SC_TVLibrarySelectedDetails.Size = new System.Drawing.Size(289, 524);
            this.SC_TVLibrarySelectedDetails.SplitterDistance = 427;
            this.SC_TVLibrarySelectedDetails.TabIndex = 0;
            // 
            // SC_TVDetailsControlLibrary
            // 
            this.SC_TVDetailsControlLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_TVDetailsControlLibrary.IsSplitterFixed = true;
            this.SC_TVDetailsControlLibrary.Location = new System.Drawing.Point(0, 0);
            this.SC_TVDetailsControlLibrary.Name = "SC_TVDetailsControlLibrary";
            this.SC_TVDetailsControlLibrary.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_TVDetailsControlLibrary.Panel1
            // 
            this.SC_TVDetailsControlLibrary.Panel1.Controls.Add(this.SC_TVTopBottem);
            // 
            // SC_TVDetailsControlLibrary.Panel2
            // 
            this.SC_TVDetailsControlLibrary.Panel2.Controls.Add(this.lbl_ListedDetails);
            this.SC_TVDetailsControlLibrary.Panel2.Controls.Add(this.btn_ShowHideTVDetails);
            this.SC_TVDetailsControlLibrary.Panel2.Controls.Add(this.btn_TVPlaySelected);
            this.SC_TVDetailsControlLibrary.Panel2.Controls.Add(this.btn_TVCreatePlaylist);
            this.SC_TVDetailsControlLibrary.Size = new System.Drawing.Size(289, 427);
            this.SC_TVDetailsControlLibrary.SplitterDistance = 397;
            this.SC_TVDetailsControlLibrary.TabIndex = 0;
            // 
            // SC_TVTopBottem
            // 
            this.SC_TVTopBottem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_TVTopBottem.Location = new System.Drawing.Point(0, 0);
            this.SC_TVTopBottem.Name = "SC_TVTopBottem";
            this.SC_TVTopBottem.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_TVTopBottem.Panel1
            // 
            this.SC_TVTopBottem.Panel1.Controls.Add(this.SC_TVSeriesSeason);
            // 
            // SC_TVTopBottem.Panel2
            // 
            this.SC_TVTopBottem.Panel2.Controls.Add(this.SC_TVCastSynopsis);
            this.SC_TVTopBottem.Size = new System.Drawing.Size(289, 397);
            this.SC_TVTopBottem.SplitterDistance = 194;
            this.SC_TVTopBottem.TabIndex = 0;
            // 
            // SC_TVSeriesSeason
            // 
            this.SC_TVSeriesSeason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_TVSeriesSeason.Location = new System.Drawing.Point(0, 0);
            this.SC_TVSeriesSeason.Name = "SC_TVSeriesSeason";
            // 
            // SC_TVSeriesSeason.Panel1
            // 
            this.SC_TVSeriesSeason.Panel1.Controls.Add(this.lisb_TVSeries);
            // 
            // SC_TVSeriesSeason.Panel2
            // 
            this.SC_TVSeriesSeason.Panel2.Controls.Add(this.SC_TVSeasonEpisode);
            this.SC_TVSeriesSeason.Size = new System.Drawing.Size(289, 194);
            this.SC_TVSeriesSeason.SplitterDistance = 96;
            this.SC_TVSeriesSeason.TabIndex = 0;
            // 
            // lisb_TVSeries
            // 
            this.lisb_TVSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisb_TVSeries.FormattingEnabled = true;
            this.lisb_TVSeries.Location = new System.Drawing.Point(0, 0);
            this.lisb_TVSeries.Name = "lisb_TVSeries";
            this.lisb_TVSeries.Size = new System.Drawing.Size(96, 194);
            this.lisb_TVSeries.TabIndex = 0;
            // 
            // SC_TVSeasonEpisode
            // 
            this.SC_TVSeasonEpisode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_TVSeasonEpisode.Location = new System.Drawing.Point(0, 0);
            this.SC_TVSeasonEpisode.Name = "SC_TVSeasonEpisode";
            // 
            // SC_TVSeasonEpisode.Panel1
            // 
            this.SC_TVSeasonEpisode.Panel1.Controls.Add(this.lisb_TVSeasons);
            // 
            // SC_TVSeasonEpisode.Panel2
            // 
            this.SC_TVSeasonEpisode.Panel2.Controls.Add(this.lisb_TVEpisodes);
            this.SC_TVSeasonEpisode.Size = new System.Drawing.Size(189, 194);
            this.SC_TVSeasonEpisode.SplitterDistance = 62;
            this.SC_TVSeasonEpisode.TabIndex = 0;
            // 
            // lisb_TVSeasons
            // 
            this.lisb_TVSeasons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisb_TVSeasons.FormattingEnabled = true;
            this.lisb_TVSeasons.Location = new System.Drawing.Point(0, 0);
            this.lisb_TVSeasons.Name = "lisb_TVSeasons";
            this.lisb_TVSeasons.Size = new System.Drawing.Size(62, 194);
            this.lisb_TVSeasons.TabIndex = 0;
            // 
            // lisb_TVEpisodes
            // 
            this.lisb_TVEpisodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisb_TVEpisodes.FormattingEnabled = true;
            this.lisb_TVEpisodes.Location = new System.Drawing.Point(0, 0);
            this.lisb_TVEpisodes.Name = "lisb_TVEpisodes";
            this.lisb_TVEpisodes.Size = new System.Drawing.Size(123, 194);
            this.lisb_TVEpisodes.TabIndex = 0;
            // 
            // SC_TVCastSynopsis
            // 
            this.SC_TVCastSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_TVCastSynopsis.Location = new System.Drawing.Point(0, 0);
            this.SC_TVCastSynopsis.Name = "SC_TVCastSynopsis";
            // 
            // SC_TVCastSynopsis.Panel1
            // 
            this.SC_TVCastSynopsis.Panel1.Controls.Add(this.lisb_TVCast);
            // 
            // SC_TVCastSynopsis.Panel2
            // 
            this.SC_TVCastSynopsis.Panel2.Controls.Add(this.txtb_TVSynopsis);
            this.SC_TVCastSynopsis.Size = new System.Drawing.Size(289, 199);
            this.SC_TVCastSynopsis.SplitterDistance = 96;
            this.SC_TVCastSynopsis.TabIndex = 0;
            // 
            // lisb_TVCast
            // 
            this.lisb_TVCast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisb_TVCast.FormattingEnabled = true;
            this.lisb_TVCast.Location = new System.Drawing.Point(0, 0);
            this.lisb_TVCast.Name = "lisb_TVCast";
            this.lisb_TVCast.Size = new System.Drawing.Size(96, 199);
            this.lisb_TVCast.TabIndex = 0;
            // 
            // txtb_TVSynopsis
            // 
            this.txtb_TVSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtb_TVSynopsis.Location = new System.Drawing.Point(0, 0);
            this.txtb_TVSynopsis.Multiline = true;
            this.txtb_TVSynopsis.Name = "txtb_TVSynopsis";
            this.txtb_TVSynopsis.Size = new System.Drawing.Size(189, 199);
            this.txtb_TVSynopsis.TabIndex = 0;
            // 
            // lbl_ListedDetails
            // 
            this.lbl_ListedDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ListedDetails.AutoSize = true;
            this.lbl_ListedDetails.Location = new System.Drawing.Point(254, 6);
            this.lbl_ListedDetails.Name = "lbl_ListedDetails";
            this.lbl_ListedDetails.Size = new System.Drawing.Size(35, 13);
            this.lbl_ListedDetails.TabIndex = 3;
            this.lbl_ListedDetails.Text = "label1";
            // 
            // btn_ShowHideTVDetails
            // 
            this.btn_ShowHideTVDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ShowHideTVDetails.AutoSize = true;
            this.btn_ShowHideTVDetails.Location = new System.Drawing.Point(173, 0);
            this.btn_ShowHideTVDetails.Name = "btn_ShowHideTVDetails";
            this.btn_ShowHideTVDetails.Size = new System.Drawing.Size(75, 23);
            this.btn_ShowHideTVDetails.TabIndex = 4;
            this.btn_ShowHideTVDetails.Text = "Hide Details";
            this.btn_ShowHideTVDetails.UseVisualStyleBackColor = true;
            // 
            // btn_TVPlaySelected
            // 
            this.btn_TVPlaySelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_TVPlaySelected.AutoSize = true;
            this.btn_TVPlaySelected.Location = new System.Drawing.Point(3, 1);
            this.btn_TVPlaySelected.Name = "btn_TVPlaySelected";
            this.btn_TVPlaySelected.Size = new System.Drawing.Size(75, 23);
            this.btn_TVPlaySelected.TabIndex = 1;
            this.btn_TVPlaySelected.Text = "Play";
            this.btn_TVPlaySelected.UseVisualStyleBackColor = true;
            // 
            // btn_TVCreatePlaylist
            // 
            this.btn_TVCreatePlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_TVCreatePlaylist.AutoSize = true;
            this.btn_TVCreatePlaylist.Location = new System.Drawing.Point(84, 1);
            this.btn_TVCreatePlaylist.Name = "btn_TVCreatePlaylist";
            this.btn_TVCreatePlaylist.Size = new System.Drawing.Size(83, 23);
            this.btn_TVCreatePlaylist.TabIndex = 2;
            this.btn_TVCreatePlaylist.Text = "Create Playlist";
            this.btn_TVCreatePlaylist.UseVisualStyleBackColor = true;
            // 
            // TBP_Video
            // 
            this.TBP_Video.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(191)))), ((int)(((byte)(131)))));
            this.TBP_Video.Controls.Add(this.VLC_Player);
            this.TBP_Video.Location = new System.Drawing.Point(4, 22);
            this.TBP_Video.Name = "TBP_Video";
            this.TBP_Video.Padding = new System.Windows.Forms.Padding(3);
            this.TBP_Video.Size = new System.Drawing.Size(739, 603);
            this.TBP_Video.TabIndex = 1;
            this.TBP_Video.Text = "Video";
            // 
            // VLC_Player
            // 
            this.VLC_Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VLC_Player.Enabled = true;
            this.VLC_Player.Location = new System.Drawing.Point(3, 3);
            this.VLC_Player.Name = "VLC_Player";
            this.VLC_Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VLC_Player.OcxState")));
            this.VLC_Player.Size = new System.Drawing.Size(733, 597);
            this.VLC_Player.TabIndex = 0;
            // 
            // PN_Playlist
            // 
            this.PN_Playlist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PN_Playlist.Controls.Add(this.splitContainer1);
            this.PN_Playlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_Playlist.Location = new System.Drawing.Point(0, 0);
            this.PN_Playlist.Name = "PN_Playlist";
            this.PN_Playlist.Size = new System.Drawing.Size(253, 730);
            this.PN_Playlist.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lisv_Playlist);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_playlistSettings);
            this.splitContainer1.Panel2.Controls.Add(this.btn_removeFromPlaylist);
            this.splitContainer1.Panel2.Controls.Add(this.btn_AddToPlaylist);
            this.splitContainer1.Size = new System.Drawing.Size(249, 726);
            this.splitContainer1.SplitterDistance = 697;
            this.splitContainer1.TabIndex = 0;
            // 
            // lisv_Playlist
            // 
            this.lisv_Playlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.lisv_Playlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_title,
            this.clm_length});
            this.lisv_Playlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisv_Playlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lisv_Playlist.Location = new System.Drawing.Point(0, 0);
            this.lisv_Playlist.MultiSelect = false;
            this.lisv_Playlist.Name = "lisv_Playlist";
            this.lisv_Playlist.Size = new System.Drawing.Size(249, 697);
            this.lisv_Playlist.TabIndex = 0;
            this.lisv_Playlist.UseCompatibleStateImageBehavior = false;
            this.lisv_Playlist.View = System.Windows.Forms.View.Details;
            // 
            // clm_title
            // 
            this.clm_title.Text = "Title";
            this.clm_title.Width = 197;
            // 
            // clm_length
            // 
            this.clm_length.Text = "Length";
            this.clm_length.Width = 48;
            // 
            // btn_playlistSettings
            // 
            this.btn_playlistSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_playlistSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_playlistSettings.Location = new System.Drawing.Point(60, 0);
            this.btn_playlistSettings.Name = "btn_playlistSettings";
            this.btn_playlistSettings.Size = new System.Drawing.Size(30, 25);
            this.btn_playlistSettings.TabIndex = 2;
            this.btn_playlistSettings.Text = "♫";
            this.btn_playlistSettings.UseVisualStyleBackColor = true;
            // 
            // btn_removeFromPlaylist
            // 
            this.btn_removeFromPlaylist.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_removeFromPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeFromPlaylist.Location = new System.Drawing.Point(30, 0);
            this.btn_removeFromPlaylist.Name = "btn_removeFromPlaylist";
            this.btn_removeFromPlaylist.Size = new System.Drawing.Size(30, 25);
            this.btn_removeFromPlaylist.TabIndex = 1;
            this.btn_removeFromPlaylist.Text = "-";
            this.btn_removeFromPlaylist.UseVisualStyleBackColor = true;
            // 
            // btn_AddToPlaylist
            // 
            this.btn_AddToPlaylist.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_AddToPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddToPlaylist.Location = new System.Drawing.Point(0, 0);
            this.btn_AddToPlaylist.Name = "btn_AddToPlaylist";
            this.btn_AddToPlaylist.Size = new System.Drawing.Size(30, 25);
            this.btn_AddToPlaylist.TabIndex = 0;
            this.btn_AddToPlaylist.Text = "+";
            this.btn_AddToPlaylist.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FRM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.SC_MainPlaylist);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FRM_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kolbalt";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CMS_Settings.ResumeLayout(false);
            this.SC_MainPlaylist.Panel1.ResumeLayout(false);
            this.SC_MainPlaylist.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_MainPlaylist)).EndInit();
            this.SC_MainPlaylist.ResumeLayout(false);
            this.SC_APPControlsLibrary.Panel1.ResumeLayout(false);
            this.SC_APPControlsLibrary.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_APPControlsLibrary)).EndInit();
            this.SC_APPControlsLibrary.ResumeLayout(false);
            this.PN_Controls.ResumeLayout(false);
            this.SC_APPControlsNowPlayingDetails.Panel1.ResumeLayout(false);
            this.SC_APPControlsNowPlayingDetails.Panel1.PerformLayout();
            this.SC_APPControlsNowPlayingDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_APPControlsNowPlayingDetails)).EndInit();
            this.SC_APPControlsNowPlayingDetails.ResumeLayout(false);
            this.PN_TimeDateDisplay.ResumeLayout(false);
            this.PN_TimeDateDisplay.PerformLayout();
            this.PN_Library.ResumeLayout(false);
            this.TBC_Library.ResumeLayout(false);
            this.TBP_MediaLibrary.ResumeLayout(false);
            this.SC_LibraryNavLibrary.Panel1.ResumeLayout(false);
            this.SC_LibraryNavLibrary.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_LibraryNavLibrary)).EndInit();
            this.SC_LibraryNavLibrary.ResumeLayout(false);
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
            this.PN_TVLibrary.ResumeLayout(false);
            this.SC_TVLibrarySelectedDetails.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVLibrarySelectedDetails)).EndInit();
            this.SC_TVLibrarySelectedDetails.ResumeLayout(false);
            this.SC_TVDetailsControlLibrary.Panel1.ResumeLayout(false);
            this.SC_TVDetailsControlLibrary.Panel2.ResumeLayout(false);
            this.SC_TVDetailsControlLibrary.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVDetailsControlLibrary)).EndInit();
            this.SC_TVDetailsControlLibrary.ResumeLayout(false);
            this.SC_TVTopBottem.Panel1.ResumeLayout(false);
            this.SC_TVTopBottem.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVTopBottem)).EndInit();
            this.SC_TVTopBottem.ResumeLayout(false);
            this.SC_TVSeriesSeason.Panel1.ResumeLayout(false);
            this.SC_TVSeriesSeason.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVSeriesSeason)).EndInit();
            this.SC_TVSeriesSeason.ResumeLayout(false);
            this.SC_TVSeasonEpisode.Panel1.ResumeLayout(false);
            this.SC_TVSeasonEpisode.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVSeasonEpisode)).EndInit();
            this.SC_TVSeasonEpisode.ResumeLayout(false);
            this.SC_TVCastSynopsis.Panel1.ResumeLayout(false);
            this.SC_TVCastSynopsis.Panel2.ResumeLayout(false);
            this.SC_TVCastSynopsis.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_TVCastSynopsis)).EndInit();
            this.SC_TVCastSynopsis.ResumeLayout(false);
            this.TBP_Video.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VLC_Player)).EndInit();
            this.PN_Playlist.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SC_MainPlaylist;
        private System.Windows.Forms.SplitContainer SC_APPControlsLibrary;
        private System.Windows.Forms.SplitContainer SC_SearchLibrary;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_AdvSearch;
        private System.Windows.Forms.TextBox txtb_Search;
        private System.Windows.Forms.Label lbl_Search;
        private VIBlend.WinForms.Controls.vApplicationMenuItem APMI_Database;
        private VIBlend.WinForms.Controls.vApplicationMenuItem APMI_DBCreate;
        private System.Windows.Forms.ContextMenuStrip CMS_Settings;
        private System.Windows.Forms.ToolStripMenuItem CMSI_dataBase;
        private System.Windows.Forms.ToolStripMenuItem CMSI_creatDataBase;
        private System.Windows.Forms.DataGridView DGV_Films;
        private System.Windows.Forms.Button btn_SetTime;
        private System.Windows.Forms.ToolTip TT_toolTip;
        private System.Windows.Forms.Button btn_ToggleAlarm;
        private System.Windows.Forms.Button btn_SetAlarm;
        private System.Windows.Forms.Panel PN_TimeDateDisplay;
        private System.Windows.Forms.Label lbl_Alarm;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_RptToggle;
        private System.Windows.Forms.Button btn_RndPlaylist;
        private System.Windows.Forms.Button btn_RndFilm;
        private System.Windows.Forms.Button btn_rndTV;
        private System.Windows.Forms.Panel PN_Controls;
        private System.Windows.Forms.Label lbl_runtime;
        private System.Windows.Forms.Label lbl_CurrentPosition;
        private System.Windows.Forms.Button btn_Rewind;
        private System.Windows.Forms.Button btn_PlayPause;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_FF;
        private System.Windows.Forms.Button btn_nextTrack;
        private System.Windows.Forms.Button btn_PreviousTrack;
        private System.Windows.Forms.Label lbl_AlarmStatus;
        private System.Windows.Forms.Label lbl_DayOfWeek;
        private System.Windows.Forms.Label lbl_12HourClk;
        private System.Windows.Forms.SplitContainer SC_LibraryDetails;
        private System.Windows.Forms.Button btn_showHideFilmDetails;
        private System.Windows.Forms.TabControl TBC_Library;
        private System.Windows.Forms.TabPage TBP_MediaLibrary;
        private System.Windows.Forms.TreeView TV_Library;
        private System.Windows.Forms.TabPage TBP_Video;
        private System.Windows.Forms.Panel PN_Library;
        private AxAXVLC.AxVLCPlugin2 VLC_Player;
        private System.Windows.Forms.Panel PN_Playlist;
        private System.Windows.Forms.Button btn_PlaylistShowHide;
        private System.Windows.Forms.SplitContainer SC_LibraryNavLibrary;
        private System.Windows.Forms.SplitContainer SC_MLTopFilm;
        private System.Windows.Forms.SplitContainer SC_DirectorsActors;
        private System.Windows.Forms.SplitContainer SC_GenresActors;
        private System.Windows.Forms.Label lbl_LibraryDetails;
        private System.Windows.Forms.Button btn_CrtPlaylist;
        private System.Windows.Forms.Button btn_PlayFilm;
        private System.Windows.Forms.SplitContainer SC_APPControlsNowPlayingDetails;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListBox ActorList;
        private System.Windows.Forms.ListBox DirectorList;
        private System.Windows.Forms.ListBox GenreList;
        private System.Windows.Forms.TextBox txtb_Synopsis;
        private System.Windows.Forms.SplitContainer SC_DatagridSynopsis;
        private System.Windows.Forms.SplitContainer SC_FilmDataGridDetControls;
        private System.Windows.Forms.Panel PN_FilmLibrary;
        private System.Windows.Forms.Panel PN_TVLibrary;
        private System.Windows.Forms.SplitContainer SC_TVLibrarySelectedDetails;
        private System.Windows.Forms.SplitContainer SC_TVDetailsControlLibrary;
        private System.Windows.Forms.SplitContainer SC_TVTopBottem;
        private System.Windows.Forms.SplitContainer SC_TVSeriesSeason;
        private System.Windows.Forms.ListBox lisb_TVSeries;
        private System.Windows.Forms.SplitContainer SC_TVSeasonEpisode;
        private System.Windows.Forms.ListBox lisb_TVSeasons;
        private System.Windows.Forms.ListBox lisb_TVEpisodes;
        private System.Windows.Forms.SplitContainer SC_TVCastSynopsis;
        private System.Windows.Forms.ListBox lisb_TVCast;
        private System.Windows.Forms.TextBox txtb_TVSynopsis;
        private System.Windows.Forms.Button btn_ShowHideTVDetails;
        private System.Windows.Forms.Label lbl_ListedDetails;
        private System.Windows.Forms.Button btn_TVCreatePlaylist;
        private System.Windows.Forms.Button btn_TVPlaySelected;
        private System.Windows.Forms.ListView lv_FilmCast;
        private System.Windows.Forms.ColumnHeader clm_Actor;
        private System.Windows.Forms.ColumnHeader clm_Character;
        private System.Windows.Forms.SplitContainer SC_CastSynopsis;
        private System.Windows.Forms.Panel SelectedFilmDetailsPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lisv_Playlist;
        private System.Windows.Forms.ColumnHeader clm_title;
        private System.Windows.Forms.ColumnHeader clm_length;
        private System.Windows.Forms.Button btn_playlistSettings;
        private System.Windows.Forms.Button btn_removeFromPlaylist;
        private System.Windows.Forms.Button btn_AddToPlaylist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_RDateLabel;
        private System.Windows.Forms.Label lbl_rdate;
        private System.Windows.Forms.Label lbl_rTime;
        private System.Windows.Forms.Label lbl_RTimeLabel;
        private System.Windows.Forms.Panel pn_RuntimeReleaseDate;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
    }
}

