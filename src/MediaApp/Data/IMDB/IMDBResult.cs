using System;

namespace MediaApp.Data.IMDB
{
    public class IMDBResult
    {

        public IMDBResult()
        {
            
        }

        public IMDBResult(String title, String url, String year, String picUrl)
        {
            Url = url;
            Title = title;
            Year = year;
            PicUrl = picUrl;
        }


        public string PicUrl { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Year { get; set; }

    }
}
