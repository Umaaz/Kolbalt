namespace MediaApp.Forms.UserControls
{
    partial class ActorDetails
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_picloading = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llbl_page = new System.Windows.Forms.LinkLabel();
            this.lbl_Born = new System.Windows.Forms.Label();
            this.lbl_loading = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_bio = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbl_picloading);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(610, 87);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbl_picloading
            // 
            this.lbl_picloading.AutoSize = true;
            this.lbl_picloading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.lbl_picloading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_picloading.Location = new System.Drawing.Point(12, 37);
            this.lbl_picloading.Name = "lbl_picloading";
            this.lbl_picloading.Size = new System.Drawing.Size(51, 13);
            this.lbl_picloading.TabIndex = 1;
            this.lbl_picloading.Text = "Loading..";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 87);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.llbl_page);
            this.panel1.Controls.Add(this.lbl_Born);
            this.panel1.Controls.Add(this.lbl_loading);
            this.panel1.Controls.Add(this.lbl_Name);
            this.panel1.Controls.Add(this.txt_bio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 87);
            this.panel1.TabIndex = 0;
            // 
            // llbl_page
            // 
            this.llbl_page.AutoSize = true;
            this.llbl_page.Dock = System.Windows.Forms.DockStyle.Right;
            this.llbl_page.LinkColor = System.Drawing.Color.DodgerBlue;
            this.llbl_page.Location = new System.Drawing.Point(497, 0);
            this.llbl_page.Name = "llbl_page";
            this.llbl_page.Size = new System.Drawing.Size(31, 13);
            this.llbl_page.TabIndex = 1;
            this.llbl_page.TabStop = true;
            this.llbl_page.Text = "More";
            this.llbl_page.Visible = false;
            // 
            // lbl_Born
            // 
            this.lbl_Born.AutoSize = true;
            this.lbl_Born.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Born.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_Born.Location = new System.Drawing.Point(35, 0);
            this.lbl_Born.Name = "lbl_Born";
            this.lbl_Born.Size = new System.Drawing.Size(35, 13);
            this.lbl_Born.TabIndex = 3;
            this.lbl_Born.Text = "label2";
            this.lbl_Born.Visible = false;
            // 
            // lbl_loading
            // 
            this.lbl_loading.AutoSize = true;
            this.lbl_loading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_loading.Location = new System.Drawing.Point(227, 29);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(51, 13);
            this.lbl_loading.TabIndex = 1;
            this.lbl_loading.Text = "Loading..";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_Name.Location = new System.Drawing.Point(0, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 2;
            this.lbl_Name.Text = "label1";
            this.lbl_Name.Visible = false;
            // 
            // txt_bio
            // 
            this.txt_bio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.txt_bio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_bio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.txt_bio.Location = new System.Drawing.Point(0, 16);
            this.txt_bio.Multiline = true;
            this.txt_bio.Name = "txt_bio";
            this.txt_bio.Size = new System.Drawing.Size(528, 69);
            this.txt_bio.TabIndex = 0;
            // 
            // ActorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ActorDetails";
            this.Size = new System.Drawing.Size(610, 87);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Born;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.LinkLabel llbl_page;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_bio;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label lbl_picloading;
        private System.Windows.Forms.Label lbl_loading;
    }
}
