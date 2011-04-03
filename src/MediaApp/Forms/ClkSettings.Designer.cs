namespace MediaApp
{
    partial class ClkSettings
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_12hour = new System.Windows.Forms.CheckBox();
            this.chk_seconds = new System.Windows.Forms.CheckBox();
            this.lv_Alarms = new System.Windows.Forms.ListView();
            this.btn_add = new System.Windows.Forms.Button();
            this.NSel_Hours = new System.Windows.Forms.NumericUpDown();
            this.NSel_Minutes = new System.Windows.Forms.NumericUpDown();
            this.btn_delete = new System.Windows.Forms.Button();
            this.chk_Showweek = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NSel_Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSel_Minutes)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(240, 356);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 0;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(159, 356);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 1;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_Showweek);
            this.groupBox1.Controls.Add(this.chk_seconds);
            this.groupBox1.Controls.Add(this.chk_12hour);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clock settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Controls.Add(this.NSel_Minutes);
            this.groupBox2.Controls.Add(this.NSel_Hours);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.lv_Alarms);
            this.groupBox2.Location = new System.Drawing.Point(12, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 227);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alarm settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clock time is taken from system time.";
            // 
            // chk_12hour
            // 
            this.chk_12hour.AutoSize = true;
            this.chk_12hour.Checked = global::MediaApp.Properties.Settings.Default.twelvehour;
            this.chk_12hour.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MediaApp.Properties.Settings.Default, "twelvehour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chk_12hour.Location = new System.Drawing.Point(9, 32);
            this.chk_12hour.Name = "chk_12hour";
            this.chk_12hour.Size = new System.Drawing.Size(64, 17);
            this.chk_12hour.TabIndex = 1;
            this.chk_12hour.Text = "12 Hour";
            this.chk_12hour.UseVisualStyleBackColor = true;
            // 
            // chk_seconds
            // 
            this.chk_seconds.AutoSize = true;
            this.chk_seconds.Checked = global::MediaApp.Properties.Settings.Default.Showseconds;
            this.chk_seconds.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MediaApp.Properties.Settings.Default, "Showseconds", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chk_seconds.Location = new System.Drawing.Point(9, 55);
            this.chk_seconds.Name = "chk_seconds";
            this.chk_seconds.Size = new System.Drawing.Size(96, 17);
            this.chk_seconds.TabIndex = 2;
            this.chk_seconds.Text = "Show seconds";
            this.chk_seconds.UseVisualStyleBackColor = true;
            // 
            // lv_Alarms
            // 
            this.lv_Alarms.Location = new System.Drawing.Point(9, 56);
            this.lv_Alarms.Name = "lv_Alarms";
            this.lv_Alarms.Size = new System.Drawing.Size(288, 165);
            this.lv_Alarms.TabIndex = 0;
            this.lv_Alarms.UseCompatibleStateImageBehavior = false;
            this.lv_Alarms.View = System.Windows.Forms.View.Details;
            // 
            // btn_add
            // 
            this.btn_add.AutoSize = true;
            this.btn_add.Location = new System.Drawing.Point(207, 27);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(36, 23);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // NSel_Hours
            // 
            this.NSel_Hours.Location = new System.Drawing.Point(51, 27);
            this.NSel_Hours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.NSel_Hours.Name = "NSel_Hours";
            this.NSel_Hours.Size = new System.Drawing.Size(34, 20);
            this.NSel_Hours.TabIndex = 2;
            // 
            // NSel_Minutes
            // 
            this.NSel_Minutes.Location = new System.Drawing.Point(147, 28);
            this.NSel_Minutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.NSel_Minutes.Name = "NSel_Minutes";
            this.NSel_Minutes.Size = new System.Drawing.Size(34, 20);
            this.NSel_Minutes.TabIndex = 3;
            // 
            // btn_delete
            // 
            this.btn_delete.AutoSize = true;
            this.btn_delete.Location = new System.Drawing.Point(249, 28);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(48, 23);
            this.btn_delete.TabIndex = 5;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // chk_Showweek
            // 
            this.chk_Showweek.AutoSize = true;
            this.chk_Showweek.Checked = global::MediaApp.Properties.Settings.Default.Showweekday;
            this.chk_Showweek.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MediaApp.Properties.Settings.Default, "Showweekday", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chk_Showweek.Location = new System.Drawing.Point(9, 78);
            this.chk_Showweek.Name = "chk_Showweek";
            this.chk_Showweek.Size = new System.Drawing.Size(102, 17);
            this.chk_Showweek.TabIndex = 3;
            this.chk_Showweek.Text = "Show week day";
            this.chk_Showweek.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hours";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Minutes";
            // 
            // ClkSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClkSettings";
            this.ShowInTaskbar = false;
            this.Text = "Clock Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NSel_Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSel_Minutes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_Showweek;
        private System.Windows.Forms.CheckBox chk_seconds;
        private System.Windows.Forms.CheckBox chk_12hour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.NumericUpDown NSel_Minutes;
        private System.Windows.Forms.NumericUpDown NSel_Hours;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ListView lv_Alarms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}