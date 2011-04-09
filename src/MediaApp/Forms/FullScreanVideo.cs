using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MediaApp.Forms.UserControls;

namespace MediaApp.Forms
{
    public partial class FullScreanVideo : Form
    {
        public int Time { get; set; }
        public int _playlistIndex = 0;
        private double _rate = 1.0;
        private Point _oldPoint;
        private Slider _player = new Slider();
        public FullScreanVideo(string path, int time, double rate, int playListIndex, int vol)
        {
            _playlistIndex = playListIndex;
            _rate = rate;
            InitializeComponent();
            axVLCPlugin21.playlist.add(path);
            axVLCPlugin21.playlist.play();
            axVLCPlugin21.input.Time = time;
            _oldPoint = new Point(this.Location.X, this.Location.Y);
            panel1.Location = Properties.Settings.Default.FullScreenPanelLoc;
            volume1.slider1.Value = vol;
            _player.slider1.IsMoveToPointEnabled = true;
            elementHost2.Child = _player;
            _player.slider1.Value = time;
        }

        private void FullScreanVideo_DoubleClick(object sender, System.EventArgs e)
        {
            button1_Click(sender, e);
        }

        void button1_Click(object sender, System.EventArgs e)
        {
            axVLCPlugin21.playlist.togglePause();
            Time = (int)axVLCPlugin21.input.Time;
            this.Hide();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (!axVLCPlugin21.playlist.isPlaying) return;
            var time = TimeSpan.FromMilliseconds(axVLCPlugin21.input.Time);
            label1.Text = (DateTime.Today + time).ToString("HH:mm:ss");
            time = TimeSpan.FromMilliseconds(axVLCPlugin21.input.Length);
            label2.Text = time.ToString("c");
            if (!_player.slider1.IsMouseOver)
            {
                _player.slider1.Maximum = axVLCPlugin21.input.Length;
                _player.slider1.Value = axVLCPlugin21.input.Time;
            }
            axVLCPlugin21.audio.Volume = (int) volume1.slider1.Value;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var newLoc = new Point(e.X + panel1.Location.X - _oldPoint.X, e.Y + panel1.Location.Y - _oldPoint.Y);
            panel1.Location = newLoc;
            Properties.Settings.Default.FullScreenPanelLoc = newLoc;
            Properties.Settings.Default.Save();
            panel1.Invalidate();
        }

        private void btn_PreviousTrack_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.prev();
            _playlistIndex--;
        }

        private void btn_Rewind_Click(object sender, EventArgs e)
        {
            _rate = axVLCPlugin21.input.rate = _rate / 2;
        }

        private void btn_PlayPause_Click(object sender, EventArgs e)
        {
            if (axVLCPlugin21.playlist.itemCount <= 0) return;
            switch (axVLCPlugin21.input.state)
            {
                case 4://paused
                    axVLCPlugin21.playlist.togglePause();
                    btn_PlayPause.Image = Properties.Resources.Pause;
                    break;
                case 3://playing
                    axVLCPlugin21.playlist.togglePause();
                    btn_PlayPause.Image = Properties.Resources.Play1;
                    break;
                case 5://stopped
                case 0://idle
                    axVLCPlugin21.playlist.play();
                    _player.slider1.Maximum = axVLCPlugin21.input.Length;
                    _player.slider1.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(slider1_ValueChanged);
                    timer1.Enabled = true;
                    btn_PlayPause.Image = Properties.Resources.Pause;
                    break;
            }
        }

        void slider1_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            axVLCPlugin21.input.Time = _player.slider1.Value;
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_FF_Click(object sender, EventArgs e)
        {
            _rate = axVLCPlugin21.input.rate = _rate * 2;
        }

        private void btn_nextTrack_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.next();
            _playlistIndex++;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _oldPoint = new Point(e.X, e.Y);
        }
    }
}
