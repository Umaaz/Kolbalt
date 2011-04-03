using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

namespace MediaApp.Data
{
    public class DownloadImage {
        private readonly string _imageUrl;
        private Bitmap _bitmap;
        public DownloadImage(string imageUrl) {
            this._imageUrl = imageUrl;
        }
        public void Download() {
            try {
                var client = new WebClient();
                var stream = client.OpenRead(_imageUrl);
                if (stream != null)
                {
                    _bitmap = new Bitmap(stream);
                    stream.Flush();
                    stream.Close();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        public Bitmap GetImage() {
            return _bitmap;
        }
        public void SaveImage(string filename, ImageFormat format) {
            if (_bitmap != null) {
                _bitmap.Save(filename, format);
            }
        }
    }
}