using System.Windows.Controls;
using System.Windows.Input;

namespace MediaApp.Forms.UserControls.WPFControls
{
    /// <summary>
    /// Interaction logic for Slider.xaml
    /// </summary>
    public partial class Slider : UserControl
    {
        public double Value { get; set; }
        public Slider()
        {
            InitializeComponent();
        }

        private void slider1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Value = this.slider1.Value;
            
        }
    }
}
