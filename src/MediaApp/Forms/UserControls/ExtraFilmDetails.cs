using System;
using System.Windows.Forms;

namespace MediaApp.Forms.UserControls
{
    public partial class ExtraFilmDetails : UserControl
    {
        public ExtraFilmDetails(String url, String type, String comment)
        {
            InitializeComponent();
            llbl_moreType.Click += (s, ee) => System.Diagnostics.Process.Start(url);
            llbl_moreType.Text = "More " + type;
            txt_comment.Text = comment;
            lbl_Type.Text = type;
        }
    }
}
