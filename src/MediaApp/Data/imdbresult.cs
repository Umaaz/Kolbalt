using System;

namespace MediaApp
{
    class Imdbresult
    {
        public Imdbresult(String title, String url, String year, String picUrl)
        {
            this.Url = url;
            this.Title = title;
            this.Year = year;
            this.PicUrl = picUrl;
        }

        public string PicUrl { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Year { get; set; }

    }
}
