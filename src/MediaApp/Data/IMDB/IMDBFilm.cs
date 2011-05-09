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
            var url = "http://www.IMDB.com/find?s=tt&q=" + film;
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
            if (response.ResponseUri.ToString().Contains("http://www.imdb.com/find?s=tt"))
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
            if (!Regex.IsMatch(url, @"(http://)www.imdb.com/title/tt\d\d\d\d\d\d\d", RegexOptions.IgnoreCase))
                return null;
            var hw = new HtmlWeb();
            var doc = hw.Load(url);
            if (hw.StatusCode != HttpStatusCode.OK)
                return null;
            
            //imdb ID
            var IMDBFilmId = url.Remove(0, url.LastIndexOf("tt") + 2);
            IMDBFilmId = IMDBFilmId.Replace("/", "");
            if (IMDBFilmId.Contains("?"))
                IMDBFilmId = IMDBFilmId.Remove(IMDBFilmId.IndexOf("?"));
            var docString = doc.DocumentNode.InnerHtml.ToString();
            
            //title
            var title = "";
            if (docString.Contains("class=\"header\""))
                title = GetTitle(doc);

            //picurl
            var picURL = "";
            if (docString.Contains("id=\"img_primary\""))
                picURL = GetPicURL(doc);
            
            //genres
            var genres = new List<FilmType>();
            if (docString.Contains("class=\"see-more inline\""))
                genres = GetGenres(doc);
            
            //Director
            var directors = new List<Person>();
            if (Regex.IsMatch(docString, @"director(s:|:)", RegexOptions.IgnoreCase))
                directors = GetDirectors(doc);
            
            //Writers
            var writers = new List<Person>();
            if (Regex.IsMatch(docString, @"writer(s:|:)", RegexOptions.IgnoreCase))
                writers = GetWriters(doc);
            
            //plot keywords
            var keywords = "";
            if (docString.Contains("class=\"see-more inline canwrap\""))
                keywords = GetKeywords(doc);
            
            //Release date
            var releaseDate = "";
            if (docString.Contains("class=\"txt-block\""))
                releaseDate = GetReleaseDate(doc);
            
            //RunTime
            var runTime = 0;
            if (docString.Contains("Runtime"))
                runTime = GetRunTime(doc);
            
            //Storyline
            var storyLine = "";
            if (docString.Contains("class=\"article\""))
                storyLine = GetStoryLine(doc);
            
            //Cast
            var cast = new List<Role>();
            if (docString.Contains("class=\"cast_list\""))
                cast = GetCast(doc);
            
            //trailer link
            var tlink = "";
            if (docString.Contains("id=\"overview-bottom\""))
                tlink = GetTrailerLink(doc);
            
            //indexing
            var directorindexing = "";
            foreach (var person in directors)
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
                           Synopsis = storyLine,
                           RunTime = runTime,
                           IMDBId = IMDBFilmId,
                           ReleaseYear = releaseDate,
                           Genre = genres,
                           Director = directors,
                           Cast = cast,
                           PicURL = picURL,
                           Writers = writers,
                           Keywords = keywords,
                           TrailerLink = tlink,
                           DirectorIndexing = directorindexing,
                           GenreIndexing = genreIndexing,
                           CharIndexing = charIndexing,
                           PersonIndexing = personIndexing
                       };
        }

        private static String GetTitle(HtmlDocument doc)
        {
            var titleNode = doc.DocumentNode.SelectNodes(".//h1[@class='header']").FirstOrDefault();
            string title = null;
            if (titleNode != null)
            {
                title = titleNode.InnerText.Trim();
                title = HtmlEscapeCharConverter.Decode(title.Remove(title.IndexOf("(")));
            }
            return title.Replace("\n","");
        }

        private static String GetPicURL(HtmlDocument doc)
        {
            var picURL = doc.DocumentNode.SelectNodes(".//td[@id='img_primary']").FirstOrDefault().InnerHtml;
            if (picURL.Contains("<img src="))
            {
                picURL = picURL.Remove(0, picURL.IndexOf("<img src=") + 10);
                picURL = picURL.Remove(picURL.IndexOf("\""));
            }
            return picURL;
        }
    
        private static List<FilmType> GetGenres(HtmlDocument doc)
        {
            var inline = doc.DocumentNode.SelectNodes(".//div[@class='see-more inline canwrap']");
            HtmlNodeCollection gen = null;
            if (inline != null)
                foreach (var node in inline.Where(node => node.InnerText.Contains("Genres")))
                {
                    gen = node.SelectNodes(".//a");
                }
            var genres = new List<FilmType>();
            if (gen != null)
            {
                genres = gen.Select(g => new FilmType
                {
                    Type = HtmlEscapeCharConverter.Decode(g.InnerText.Trim())
                }).ToList();
            }
            return genres;
        }
    
        private static List<Person> GetDirectors(HtmlDocument doc)
        {
            var directors = new List<Person>();
            var divs = doc.DocumentNode.SelectNodes(".//div[@class='txt-block']");
            var directorss = divs.Where(x => x.InnerText.Contains("Directors:")).FirstOrDefault() ?? divs.Where(x => x.InnerText.Contains("Director:")).FirstOrDefault();
            var dnames = directorss.SelectNodes(".//a");
            foreach (var dname in dnames)
            {
                var matches = Regex.Matches(dname.OuterHtml, @"/nm\d\d\d\d\d\d\d/");
                if (matches.Count > 0)
                    directors.Add(new Person
                    {
                        IMDBID = matches[0].Value.Replace("/", "").Replace("nm", ""),
                        Name = dname.InnerText
                    });
            }
            return directors;
        }
    
        private static List<Person> GetWriters(HtmlDocument doc)
        {
            var writers = new List<Person>();
            var divs = doc.DocumentNode.SelectNodes(".//div[@class='txt-block']");

            var writerss = divs.Where(x => x.InnerText.Contains("Writers:")).FirstOrDefault() ??
                          divs.Where(x => x.InnerText.Contains("Writer:")).FirstOrDefault();
            HtmlNodeCollection wnames = null;
            if (writerss != null)
                wnames = writerss.SelectNodes(".//a");
            if (wnames != null)
                foreach (var wname in wnames)
                {
                    var matches = Regex.Matches(wname.OuterHtml, @"/nm\d\d\d\d\d\d\d/");
                    if (matches.Count > 0)
                        writers.Add(new Person
                        {
                            IMDBID = matches[0].Value.Replace("/", "").Replace("nm", ""),
                            Name = wname.InnerText
                        });
                }
            return writers;
        }
    
        private static String GetKeywords(HtmlDocument doc)
        {
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
            return keywords;
        }

        private static String GetReleaseDate(HtmlDocument doc)
        {
            var divs = doc.DocumentNode.SelectNodes(".//div[@class='txt-block']");
            var dateString = divs
                .Where(x => x.SelectNodes(".//h4") != null)
                .Where(x => x.SelectNodes(".//h4").First().InnerText.Trim().Contains("Release Date"))
                .SingleOrDefault();
            string d = null;
            if (dateString != null)
            {
                var td = dateString.InnerText.Remove(dateString.InnerText.IndexOf("(")).Replace("Release Date:", "");
                d = td.Replace("\n", "");
                d = d.Remove(0, d.Length - 4);
            }
            return d;
        }
    
        private static int GetRunTime(HtmlDocument doc)
        {
            var runtime = "";
            var divs = doc.DocumentNode.SelectNodes(".//div[@class='txt-block']");
            if (divs.Where(x => x.SelectNodes(".//h4") != null && x.SelectNodes(".//h4").First().InnerText.Trim() == "Runtime:").ToList().Count > 0)
            {
                var t =
                    divs.Where(
                        x => x.SelectNodes(".//h4") != null && x.SelectNodes(".//h4").First().InnerText.Trim() == "Runtime:")
                        .Single().InnerText;
                var matches = Regex.Matches(t, "[0-9]{3} min",RegexOptions.IgnoreCase);
                if(matches.Count > 0)
                    runtime = matches[0].Value.Replace(" min","");
            }
            if (string.IsNullOrEmpty(runtime))
                runtime = "0";
            int rt;
            return (int.TryParse(runtime,out rt)) ? rt : 0;
        }
    
        private static String GetStoryLine(HtmlDocument doc)
        {
            var u =
                doc.DocumentNode.SelectNodes(".//div[@class='article']").Where(
                    x => x.SelectNodes(".//h2") != null && x.SelectNodes(".//h2").First().InnerText == "Storyline").
                    FirstOrDefault();
            HtmlNode storyNode = null;
            String story = null;
            if (u.InnerHtml.Contains("<p>"))
                storyNode = u.SelectNodes(".//p").FirstOrDefault();
            if (storyNode != null)
            {
                story = storyNode.InnerText;
                story = HtmlEscapeCharConverter.Decode(story);
            }
            return story;
        }
    
        private static List<Role> GetCast(HtmlDocument doc)
        {
            var cast = new List<Role>();
            var tab = doc.DocumentNode.SelectNodes(".//table[@class='cast_list']//tr").DefaultIfEmpty();
            if (tab != null)
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
            return cast;
        }
    
        private static String GetTrailerLink(HtmlDocument doc)
        {
            var tlink = doc.DocumentNode.SelectNodes(".//td[@id='overview-bottom']").FirstOrDefault();
            var link = "";
            if (tlink != null && tlink.InnerText.Contains("Watch Trailer"))
            {
                link = tlink.InnerHtml.Remove(0, tlink.InnerHtml.IndexOf("href=\"")+6);
                link = link.Remove(link.IndexOf("\""));
            }
            return link;
        }
    }
}
