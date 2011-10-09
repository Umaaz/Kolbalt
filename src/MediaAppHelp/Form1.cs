using System;
using System.Windows.Forms;

namespace Kolbalt.Help
{
    public partial class HelpFrom : Form
    {
        public HelpFrom()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(@"e:\users\cv2.docx");
        }
    }
}
