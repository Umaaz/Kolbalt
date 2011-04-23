using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using MediaApp.Domain;
using MediaApp.Domain.Model;

namespace MediaApp.Data.IMDB
{
    public class IMDBFilm
    {
        public static Film GetFilmByName(String film)
        {
            var url = "http://www.IMDB.com/find?s=all&q=" + film;
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
            IMDBResult result = null;
            if (response.ResponseUri.ToString().Contains("http://www.imdb.com/find?s=all"))
            {
                result = IMDBSearch.TopResultBySource(source);
            }
            if (result!= null)
            {
                var urlEnd = result.Url;
                url = "Http://www.IMDB.com/title/tt" + urlEnd;
            }
            else
            {
                url = response.ResponseUri.AbsoluteUri;
            }
            
            return GetFilmByUrl(url);
        }
        
        
        public static Film GetFilmByUrl(string url)
        {
            var cast = new List<Role>();
            //todo what if there is no property listed..
            var hw = new HtmlWeb();
            var doc = hw.Load(url);
            
            //imdb ID
            var IMDBFilmId = url.Remove(0, url.LastIndexOf("tt") + 2);
            IMDBFilmId = IMDBFilmId.Replace("/", "");
            if (IMDBFilmId.Contains("?"))
                IMDBFilmId = IMDBFilmId.Remove(IMDBFilmId.IndexOf("?"));

            //title
            var titleNode = doc.DocumentNode.SelectNodes(".//h1[@class='header']").FirstOrDefault();
            string title = null;
            if(titleNode != null)
            {
                title = titleNode.InnerText.Trim();
                title = HtmlEscapeCharConverter.Decode(title.Remove(title.IndexOf("(")));
            }
            
            var divs = doc.DocumentNode.SelectNodes(".//div[@class='txt-block']");
            
            //picurl
            var picURL = doc.DocumentNode.SelectNodes(".//td[@id='img_primary']").FirstOrDefault().InnerHtml;
            if (picURL.Contains("<img src="))
            {
                picURL = picURL.Remove(0, picURL.IndexOf("<img src=") + 10);
                picURL = picURL.Remove(picURL.IndexOf("\""));
            }

            //genres
            var inline = doc.DocumentNode.SelectNodes(".//div[@class='see-more inline canwrap']");
            HtmlNodeCollection gen = null;
            if(inline != null)
            foreach (var node in inline.Where(node => node.InnerText.Contains("Genres")))
            {
                gen = node.SelectNodes(".//a");
            }
            IList<FilmType> genres = new List<FilmType>();
            if (gen != null)
            {
                genres = gen.Select(g => new FilmType
                                                  {
                                                      Type = HtmlEscapeCharConverter.Decode(g.InnerText.Trim())
                                                  }).ToList();
            }
            
            //Director
            var director = divs.First().SelectSingleNode(".//a").InnerText.Trim();
            var dirnum = divs.First().InnerHtml;
            var dirNum = dirnum.Remove(0, dirnum.IndexOf("nm") + 2);
            dirNum = dirNum.Remove(7);
            var directors = new Person {IMDBID = dirNum,Name = director};
            
            //Release date
            var dateString = divs
                .Where(x => x.SelectNodes(".//h4") != null)
                .Where(x => x.SelectNodes(".//h4").First().InnerText.Trim().Contains("Release Date"))
                .SingleOrDefault();
            string d = null;
            if (dateString != null)
            {
                var td = dateString.InnerText.Remove(dateString.InnerText.IndexOf("(")).Replace("Release Date:", "");
                //var dd = DateTime.Parse(td);
                d = td.Replace("\n","");
                d = d.Remove(0, d.Length - 4);
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
                    FirstOrDefault();
            HtmlNode storyNode = null;
            String story = null;
            if (u.InnerText.Contains("<p>"))
                storyNode = u.SelectNodes(".//p").FirstOrDefault();
            if (storyNode != null)
            {
                story = storyNode.InnerText;
                story = HtmlEscapeCharConverter.Decode(story);
            }

            //Cast
            var tab = doc.DocumentNode.SelectNodes(".//table[@class='cast_list']//tr").DefaultIfEmpty();
            if(tab != null)
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
                var per = new Person { IMDBID = actNum, Name = HtmlEscapeCharConverter.Decode(name.Trim()) };
                cast.Add(new Role
                             {
                                 Character = HtmlEscapeCharConverter.Decode(character),
                                 Person = per
                             });
            }
            
            return new Film
                       {
                           Title = title,
                           Synopsis = story,
                           RunTime = rt,
                           IMDBId = IMDBFilmId,
                           ReleaseYear = d,
                           Genre = genres,
                           Director = directors,
                           Cast = cast,
                           PicURL = picURL
                       };
        }
    }
}
