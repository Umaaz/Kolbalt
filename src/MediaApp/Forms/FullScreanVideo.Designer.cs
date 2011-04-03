namespace MediaApp.Forms
{
    partial class FullScreanVideo
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullScreanVideo));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_PreviousTrack = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_FF = new System.Windows.Forms.Button();
            this.btn_PlayPause = new System.Windows.Forms.Button();
            this.btn_Rewind = new System.Windows.Forms.Button();
            this.btn_nextTrack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.slider1 = new MediaApp.Forms.UserControls.Slider();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.volume1 = new MediaApp.Forms.UserControls.Volume();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_PreviousTrack
            // 
            this.btn_PreviousTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PreviousTrack.Image = global::MediaApp.Properties.Resources.Back;
            this.btn_PreviousTrack.Location = new System.Drawing.Point(3, 34);
            this.btn_PreviousTrack.Name = "btn_PreviousTrack";
            this.btn_PreviousTrack.Size = new System.Drawing.Size(23, 23);
            this.btn_PreviousTrack.TabIndex = 17;
            this.btn_PreviousTrack.UseVisualStyleBackColor = true;
            this.btn_PreviousTrack.Click += new System.EventHandler(this.btn_PreviousTrack_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Stop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Stop.Image = global::MediaApp.Properties.Resources.stop;
            this.btn_Stop.Location = new System.Drawing.Point(86, 34);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(23, 23);
            this.btn_Stop.TabIndex = 20;
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_FF
            // 
            this.btn_FF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_FF.Image = global::MediaApp.Properties.Resources.FastFoward;
            this.btn_FF.Location = new System.Drawing.Point(113, 34);
            this.btn_FF.Name = "btn_FF";
            this.btn_FF.Size = new System.Drawing.Size(23, 23);
            this.btn_FF.TabIndex = 19;
            this.btn_FF.UseVisualStyleBackColor = true;
            this.btn_FF.Click += new System.EventHandler(this.btn_FF_Click);
            // 
            // btn_PlayPause
            // 
            this.btn_PlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PlayPause.Image = global::MediaApp.Properties.Resources.Play1;
            this.btn_PlayPause.Location = new System.Drawing.Point(59, 34);
            this.btn_PlayPause.Name = "btn_PlayPause";
            this.btn_PlayPause.Size = new System.Drawing.Size(23, 23);
            this.btn_PlayPause.TabIndex = 21;
            this.btn_PlayPause.UseVisualStyleBackColor = true;
            this.btn_PlayPause.Click += new System.EventHandler(this.btn_PlayPause_Click);
            // 
            // btn_Rewind
            // 
            this.btn_Rewind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Rewind.Image = global::MediaApp.Properties.Resources.Rewind1;
            this.btn_Rewind.Location = new System.Drawing.Point(32, 34);
            this.btn_Rewind.Name = "btn_Rewind";
            this.btn_Rewind.Size = new System.Drawing.Size(23, 23);
            this.btn_Rewind.TabIndex = 22;
            this.btn_Rewind.UseVisualStyleBackColor = true;
            this.btn_Rewind.Click += new System.EventHandler(this.btn_Rewind_Click);
            // 
            // btn_nextTrack
            // 
            this.btn_nextTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_nextTrack.Image = global::MediaApp.Properties.Resources.Next;
            this.btn_nextTrack.Location = new System.Drawing.Point(140, 34);
            this.btn_nextTrack.Name = "btn_nextTrack";
            this.btn_nextTrack.Size = new System.Drawing.Size(23, 23);
            this.btn_nextTrack.TabIndex = 18;
            this.btn_nextTrack.UseVisualStyleBackColor = true;
            this.btn_nextTrack.Click += new System.EventHandler(this.btn_nextTrack_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Image = global::MediaApp.Properties.Resources.RestoreScreen;
            this.button1.Location = new System.Drawing.Point(190, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // axVLCPlugin21
            // 
            this.axVLCPlugin21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axVLCPlugin21.Enabled = true;
            this.axVLCPlugin21.Location = new System.Drawing.Point(0, 0);
            this.axVLCPlugin21.Name = "axVLCPlugin21";
            this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
            this.axVLCPlugin21.Size = new System.Drawing.Size(421, 342);
            this.axVLCPlugin21.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.elementHost2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.elementHost1);
            this.panel1.Controls.Add(this.btn_PreviousTrack);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_nextTrack);
            this.panel1.Controls.Add(this.btn_Stop);
            this.panel1.Controls.Add(this.btn_Rewind);
            this.panel1.Controls.Add(this.btn_FF);
            this.panel1.Controls.Add(this.btn_PlayPause);
            this.panel1.Location = new System.Drawing.Point(78, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 60);
            this.panel1.TabIndex = 24;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(59, 2);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(169, 26);
            this.elementHost2.TabIndex = 26;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.slider1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "label1";
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(278, 3);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(22, 54);
            this.elementHost1.TabIndex = 23;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.volume1;
            // 
            // FullScreanVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 342);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axVLCPlugin21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreanVideo";
            this.Text = "FullScreanVideo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.DoubleClick += new System.EventHandler(this.FullScreanVideo_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_PreviousTrack;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_FF;
        private System.Windows.Forms.Button btn_PlayPause;
        private System.Windows.Forms.Button btn_Rewind;
        private System.Windows.Forms.Button btn_nextTrack;
        private System.Windows.Forms.Button button1;
        public AxAXVLC.AxVLCPlugin2 axVLCPlugin21;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private UserControls.Slider slider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private UserControls.Volume volume1;
    }
}