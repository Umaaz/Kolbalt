namespace MediaApp.Forms.UserControls.FilmControls
{
    partial class ExtraFilmDetails
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
            this.lbl_Type = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llbl_moreType = new System.Windows.Forms.LinkLabel();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.lbl_Type.Location = new System.Drawing.Point(0, 0);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(35, 13);
            this.lbl_Type.TabIndex = 4;
            this.lbl_Type.Text = "Goofs";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_Type);
            this.panel1.Controls.Add(this.llbl_moreType);
            this.panel1.Controls.Add(this.txt_comment);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 98);
            this.panel1.TabIndex = 5;
            // 
            // llbl_moreType
            // 
            this.llbl_moreType.AutoSize = true;
            this.llbl_moreType.Dock = System.Windows.Forms.DockStyle.Right;
            this.llbl_moreType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.llbl_moreType.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.llbl_moreType.Location = new System.Drawing.Point(259, 0);
            this.llbl_moreType.Name = "llbl_moreType";
            this.llbl_moreType.Size = new System.Drawing.Size(62, 13);
            this.llbl_moreType.TabIndex = 3;
            this.llbl_moreType.TabStop = true;
            this.llbl_moreType.Text = "More Goofs";
            // 
            // txt_comment
            // 
            this.txt_comment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.txt_comment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_comment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_comment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(166)))), ((int)(((byte)(184)))));
            this.txt_comment.Location = new System.Drawing.Point(0, 22);
            this.txt_comment.Multiline = true;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.ReadOnly = true;
            this.txt_comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_comment.Size = new System.Drawing.Size(321, 74);
            this.txt_comment.TabIndex = 0;
            // 
            // ExtraFilmDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ExtraFilmDetails";
            this.Size = new System.Drawing.Size(323, 98);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_comment;
        private System.Windows.Forms.LinkLabel llbl_moreType;

    }
}
