using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using MediaApp.Domain;

namespace MediaApp
{
    public class ImdbFilm
    {
        public static Film GetTopResultByName(String film)
        {
            var url = "http://www.imdb.com/find?s=all&q=" + film;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return null;
            }
            var sr = new StreamReader(response.GetResponseStream());
            var source = sr.ReadToEnd();
            var imdb = new ImdbSearch((string)film);
            imdb.SearchImdb(source);
            var results = imdb.Results;
            if (results.Count > 0)
            {
                var topresult = (Imdbresult)results[0];
                var urlEnd = topresult.Url;
                url = "Http://www.imdb.com" + urlEnd;
            }
            else
            {
                url = response.ResponseUri.AbsoluteUri;
            }
            return GetTopResultByUrl(url);
        }
        
        
        public static Film GetTopResultByUrl(string url)
        {
            var cast = new List<Role>();
            String title = "", director = "";
            var cc = new HtmlEscapeCharConverter();
            // what if there is no property listed..
            //the top search is not always returning correct film, due to the way imdb lists the films. need to check acuracy of the search.
            var hw = new HtmlWeb();
            var doc = hw.Load(url);
            var imdbfilmid = url.Remove(0, url.LastIndexOf("tt") + 2);
            imdbfilmid = imdbfilmid.Remove(imdbfilmid.IndexOf("/"));
            title = doc.DocumentNode.SelectSingleNode(".//h1[@class='header']").InnerText.Trim();
            title = cc.Decode(title.Remove(title.IndexOf("(")));
            var divs = doc.DocumentNode.SelectNodes(".//div[@class='txt-block']");
            
            //genres
            var inline = doc.DocumentNode.SelectNodes(".//div[@class='see-more inline canwrap']");
            HtmlNodeCollection gen = null;
            foreach (var node in inline.Where(node => node.InnerText.Contains("Genres")))
            {
                gen = node.SelectNodes(".//a");
            }
            IList<FilmType> genres = new List<FilmType>();
            if (gen != null)
            {
                genres = gen.Select(g => new FilmType
                                                             {
                                                                 Type = cc.Decode(g.InnerText.Trim())
                                                             }).ToList();
            }
            
            //Director
            director = divs.First().SelectSingleNode(".//a").InnerText.Trim();
            var dirnum = divs.First().InnerHtml;
            var dirNum = dirnum.Remove(0, dirnum.IndexOf("nm") + 2);
            dirNum = dirNum.Remove(7);
            var directors = new Person(){imdbID = dirNum,Name = director};
            
            //Release date
            var dateString = divs
                .Where(x => x.SelectNodes(".//h4") != null)
                .Where(x => x.SelectNodes(".//h4").First().InnerText.Trim().Contains("Release Date"))
                .Single().InnerText;
            DateTime d = DateTime.Now;
            if (dateString != null)
            {
                var td = dateString.Remove(dateString.IndexOf("(")).Replace("Release Date:", "");
                d = DateTime.Parse(td);
            }
            
            //RunTime get run time from film file..
            string shouldBeRuntime = null;
            if(divs.Where(x=> x.SelectNodes(".//h4") != null && x.SelectNodes(".//h4").First().InnerText.Trim() == "Runtime:").ToList().Count > 0)
            {
                var t =
                    divs.Where(
                        x => x.SelectNodes(".//h4") != null && x.SelectNodes(".//h4").First().InnerText.Trim() == "Runtime:")
                        .Single().InnerText;
                shouldBeRuntime = Regex.Replace(t, "[^0-9]", "");
            }
            if (string.IsNullOrEmpty(shouldBeRuntime))
                shouldBeRuntime = "0";
            var rt = int.Parse(shouldBeRuntime);
            
            //Storyline
            var u =
                doc.DocumentNode.SelectNodes(".//div[@class='article']").Where(
                    x => x.SelectNodes(".//h2") != null && x.SelectNodes(".//h2").First().InnerText == "Storyline").
                    First();
            var story = cc.Decode(u.SelectNodes(".//p").First().InnerText);

            //Cast
            var tab = doc.DocumentNode.SelectNodes(".//table[@class='cast_list']//tr");
            foreach (var htmlNode in tab.Skip(1))
            {
                if (htmlNode.InnerText.Contains("Rest of cast")) break; 
                var name = htmlNode.SelectSingleNode(".//td[@class='name']").InnerText;
                var actnum = htmlNode.SelectSingleNode(".//td[@class='name']").InnerHtml;
                var actNum = actnum.Remove(0, actnum.IndexOf("nm") + 2);
                actNum = actNum.Remove(7);
                
                var character =
                    htmlNode.SelectSingleNode(".//td[@class='character']").InnerText.Trim();
                while (character.Contains("  "))
                {
                    character = character.Replace("  ", " ");
                }
                var per = new Person() { imdbID = actNum, Name = cc.Decode(name.Trim())};
                cast.Add(new Role
                             {
                                 Character = cc.Decode(character),
                                 Person = per
                             });
            }
            
            return new Film
                       {
                           Title = title,
                           Synopsis = story,
                           RunTime = rt,
                           ImdbId = imdbfilmid,
                           ReleaseDate = d,
                           Genre = genres,
                           Director = directors,
                           Cast = cast
                       };
        }
    }
}
