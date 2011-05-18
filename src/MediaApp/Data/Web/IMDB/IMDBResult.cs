﻿using System;

namespace MediaApp.Data.Web.IMDB
{
    public class IMDBResult
    {

        public IMDBResult()
        {
            
        }

        public IMDBResult(String title, String url, String year, String picUrl)
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
