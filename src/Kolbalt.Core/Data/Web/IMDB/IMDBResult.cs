using System;

namespace Kolbalt.Core.Data.Web.IMDB
{
    public class ImdbResult
    {

        public ImdbResult()
        {
            
        }

        public ImdbResult(String title, String url, String year, String picUrl)
        {
            IMDBIDUrl = url;
            Title = title;
            Year = year;
            PicUrl = picUrl;
        }


        public string PicUrl { get; set; }

        public string Title { get; set; }

        public string IMDBIDUrl { get; set; }

        public string Year { get; set; }

    }
}
