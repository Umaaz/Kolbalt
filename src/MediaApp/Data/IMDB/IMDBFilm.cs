using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
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
            if (response.StatusCode != HttpStatusCode.OK)
                return null;
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
            var hw = new HtmlWeb();
            var doc = hw.Load(url);
            if (hw.StatusCode != HttpStatusCode.OK)
                return null;
            
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
            IList<Person> director = new List<Person>();
            var directors = divs.Where(x => x.InnerText.Contains("Directors:")).FirstOrDefault() ?? divs.Where(x => x.InnerText.Contains("Director:")).FirstOrDefault();
            var dnames = directors.SelectNodes(".//a");
            foreach (var dname in dnames)
            {
                var matches = Regex.Matches(dname.OuterHtml, @"/nm\d\d\d\d\d\d\d/");
                if(matches.Count > 0)
                    director.Add(new Person
                                     {
                                         IMDBID = matches[0].Value.Replace("/","").Replace("nm", ""),
                                         Name = dname.InnerText
                                     });
            }

            //Writers
            IList<Person> writer = new List<Person>();
            var writers = divs.Where(x => x.InnerText.Contains("Writers:")).FirstOrDefault() ??
                          divs.Where(x => x.InnerText.Contains("Writer:")).FirstOrDefault();
            var wnames = writers.SelectNodes(".//a");
            foreach (var wname in wnames)
            {
                var matches = Regex.Matches(wname.OuterHtml, @"/nm\d\d\d\d\d\d\d/");
                if(matches.Count > 0)
                    writer.Add(new Person
                                   {
                                       IMDBID = matches[0].Value.Replace("/", "").Replace("nm", ""),
                                       Name = wname.InnerText
                                   });
            }
            
            //plot keywords
            var keywords = "";
            var kw = doc.DocumentNode.SelectNodes(".//div[@class='see-more inline canwrap']");
            var keyword = kw.Where(x => x.InnerText.Contains("Plot Keywords:")).FirstOrDefault();
            if (keyword != null)
            {
                var words = keyword.SelectNodes(".//a");
                foreach (var word in words)
                {
                    keywords += word.InnerText + " ";
                }
            }

            //Release date
            var dateString = divs
                .Where(x => x.SelectNodes(".//h4") != null)
                .Where(x => x.SelectNodes(".//h4").First().InnerText.Trim().Contains("Release Date"))
                .SingleOrDefault();
            string d = null;
            if (dateString != null)
            {
                var td = dateString.InnerText.Remove(dateString.InnerText.IndexOf("(")).Replace("Release Date:", "");
                d = td.Replace("\n","");
                d = d.Remove(0, d.Length - 4);
            }
            
            //RunTime
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
            if(u.InnerHtml.Contains("<p>"))
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
            
            //trailer link
            var tlink = doc.DocumentNode.SelectNodes(".//td[@id='overview-bottom']").FirstOrDefault();
            String link = null;
            if (tlink != null && tlink.InnerText.Contains("Watch Trailer"))
            {
                link = tlink.InnerHtml.Remove(0, 9);
                link = link.Remove(link.IndexOf("\""));
            }

            //indexing
            var directorindexing = "";
            foreach (var person in director)
            {
                directorindexing += person.Name + " ";
            }
            var genreIndexing = "";
            foreach (var filmType in genres)
            {
                genreIndexing += filmType.Type + " ";
            }
            var charIndexing = "";
            var personIndexing = "";
            foreach (var role in cast)
            {
                charIndexing += role.Character + " ";
                personIndexing += role.Person.Name + " ";
            }

            return new Film
                       {
                           Title = title,
                           Synopsis = story,
                           RunTime = rt,
                           IMDBId = IMDBFilmId,
                           ReleaseYear = d,
                           Genre = genres,
                           Director = director,
                           Cast = cast,
                           PicURL = picURL,
                           Writers = writer,
                           Keywords = keywords,
                           TrailerLink = link,
                           DirectorIndexing = directorindexing,
                           GenreIndexing = genreIndexing,
                           CharIndexing = charIndexing,
                           PersonIndexing = personIndexing
                       };
        }
    }
}
