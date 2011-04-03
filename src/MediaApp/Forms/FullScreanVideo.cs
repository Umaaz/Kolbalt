using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MediaApp.Forms
{
    public partial class FullScreanVideo : Form
    {
        public int Time { get; set; }
        public int _playlistIndex = 0;
        private double _rate = 1.0;
        public FullScreanVideo(string path, int time, double rate, int playListIndex)
        {
            _playlistIndex = playListIndex;
            _rate = rate;
            InitializeComponent();
            axVLCPlugin21.playlist.add(path);
            axVLCPlugin21.playlist.play();
            axVLCPlugin21.input.Time = time;
            panel1.Location = Properties.Settings.Default.FullScreenPanelLoc;
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
            String hour = time.Hours.ToString();
            String min = time.Minutes.ToString();
            String sec = time.Seconds.ToString();
            if (time.Seconds <= 9)
                sec = "0" + time.Seconds;
            if (time.Minutes <= 9)
                min = "0" + time.Minutes;
            if (time.Hours <= 9)
                hour = "0" + time.Hours;
            slider1.slider1.Maximum = axVLCPlugin21.input.Length;
            slider1.slider1.Value = axVLCPlugin21.input.Time;
            label1.Text = string.Format("{0}:{1}:{2}", hour, min, sec);
            time = TimeSpan.FromMilliseconds(axVLCPlugin21.input.Length);
            hour = time.Hours.ToString();
            min = time.Minutes.ToString();
            sec = time.Seconds.ToString();
            if (time.Seconds <= 9)
                sec = "0" + time.Seconds;
            if (time.Minutes <= 9)
                min = "0" + time.Minutes;
            if (time.Hours <= 9)
                hour = "0" + time.Hours;
            label2.Text = string.Format("{0}:{1}:{2}", hour, min, sec);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var newLoc = new Point(e.X + panel1.Location.X, e.Y + panel1.Location.Y);
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
                    Thread.Sleep(100);
                    slider1.slider1.Maximum = axVLCPlugin21.input.Length;
                    slider1.slider1.ValueChanged += (slider1_ValueChanged);
                    timer1.Enabled = true;
                    btn_PlayPause.Image = Properties.Resources.Pause;
                    break;
            }
        }

        void slider1_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            axVLCPlugin21.input.Time = slider1.slider1.Value;
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
    }
}
