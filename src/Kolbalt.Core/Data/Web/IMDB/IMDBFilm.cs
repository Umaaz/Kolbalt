using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Kolbalt.Client.Data.Web;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Data.Web.IMDB
{
    public class IMDBFilm
    {
        public static IMDBItem GetFilmByName(String film)
        {
            var url = "http://www.IMDB.com/find?s=tt&q=" + film;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;
            HttpWebResponse response;
            string source;
            try
            {
                //something wrong here, when canceling and restarting application stops on this line..why?
                request.Timeout = 20000;
                request.ReadWriteTimeout = 20000;
                response = (HttpWebResponse)request.GetResponse();
                
                var sr = new StreamReader(response.GetResponseStream());
                source = sr.ReadToEnd();
            }
            catch (WebException)
            {
                return null;
            }
            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            IMDBResult result = null;
            if (response.ResponseUri.ToString().Contains("http://www.imdb.com/find?s=tt"))
            {
                result = IMDBSearch.TopResultBySource(source);
            }
            if (result != null)
            {
                var urlEnd = result.IMDBIDUrl;
                url = "Http://www.IMDB.com/title/tt" + urlEnd;
            }
            else
            {
                url = response.ResponseUri.AbsoluteUri;
            }
            
            return GetFilmByUrl(url);
        }
        
        public static IMDBItem GetFilmByUrl(string url)
        {
            if (!Regex.IsMatch(url, @"(http://)www.imdb.com/title/tt\d\d\d\d\d\d\d(/|)", RegexOptions.IgnoreCase))
                return null;
            var hw = new HtmlWeb();
            HtmlDocument doc;
            try
            {
                 doc = hw.Load(url);
            }
            catch(WebException)
            {
                return null;
            }
            
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
            {
                if (VideoGame(doc))
                    return new Game();
                title = GetTitle(doc);
            }

            //rating
            var imdbRating = 0.0;
            if (docString.Contains("class=\"rating-rating\""))
                imdbRating = GetImdbRating(doc);

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
                if(!directorindexing.Contains(person.Name))
                    directorindexing += person.Name + " ";
            }
            var genreIndexing = "";
            foreach (var filmType in genres)
            {
                if(!genreIndexing.Contains(filmType.Type))
                    genreIndexing += filmType.Type + " ";
            }
            var charIndexing = "";
            var personIndexing = "";
            foreach (var role in cast)
            {
                if(!charIndexing.Contains(role.Character))
                    charIndexing += role.Character + " ";
                if(!personIndexing.Contains(role.Person.Name))
                    personIndexing += role.Person.Name + " ";
            }
            var film = new Film
                       {
                           Title = title,
                           IMDBRating = imdbRating,
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

            film = ValidateFilm(film);


            return film;
        }

        private static Film ValidateFilm(Film film)
        {
            var lFilm = film;
            if (lFilm.IMDBId.Length != 7)
                return null;
            if (lFilm.PicURL.Length > 300)
                lFilm.PicURL = "";
            if (lFilm.Title.Length > 300)
                lFilm.Title = lFilm.Title.Remove(299);
            if (lFilm.RunTime > 999)
                lFilm.RunTime = 999;
            if (lFilm.ReleaseYear.Length > 4)
                lFilm.ReleaseYear = lFilm.ReleaseYear.Remove(3);
            if (lFilm.Synopsis.Length > 4000)
                lFilm.Synopsis = lFilm.Synopsis.Remove(3999);
            if (lFilm.TrailerLink.Length > 300)
                lFilm.TrailerLink = "";
            if (lFilm.Keywords.Length > 4000)
                lFilm.Keywords = lFilm.Keywords.Remove(3999);
            lFilm.Writers = ValidatePeople(lFilm.Writers);
            lFilm.Director = ValidatePeople(lFilm.Director);
            lFilm.Genre = ValidateGenres(lFilm.Genre);
            lFilm.Cast = ValidateRoles(lFilm.Cast);
            if (lFilm.DirectorIndexing.Length > 4000)
                lFilm.DirectorIndexing = lFilm.DirectorIndexing.Remove(3999);
            if (lFilm.CharIndexing.Length > 4000)
                lFilm.CharIndexing = lFilm.CharIndexing.Remove(3999);
            if (lFilm.GenreIndexing.Length > 4000)
                lFilm.GenreIndexing = lFilm.GenreIndexing.Remove(3999);
            if (lFilm.PersonIndexing.Length > 4000)
                lFilm.PersonIndexing = lFilm.PersonIndexing.Remove(3999);
            return lFilm;
        }

        private static IList<FilmType> ValidateGenres(IList<FilmType> genres)
        {
            var lGenres = new List<FilmType>();
            foreach (var filmType in genres)
            {
                if (filmType.Type.Length > 300)
                    filmType.Type = filmType.Type.Remove(299);
                lGenres.Add(filmType);
            }
            return lGenres;
        }

        private static IList<Role> ValidateRoles(IList<Role> roles)
        {
            var lRoles = new List<Role>();
            foreach (var role in roles.Where(role => role.Person.IMDBID.Length == 7))
            {
                if (role.Character.Length > 300)
                    role.Character = role.Character.Remove(299);
                if (role.Person.Name.Length > 300)
                    role.Person.Name = role.Person.Name.Remove(299);
                lRoles.Add(role);
            }
            return lRoles;
        }

        private static IList<Person> ValidatePeople(IList<Person> people)
        {
            var lPeople = new List<Person>();
            foreach (var person in people.Where(person => person.IMDBID.Length == 7))
            {
                if (person.Name.Length > 300)
                    person.Name = person.Name.Remove(299);
                lPeople.Add(person);
            }
            return lPeople;
        }

        private static bool VideoGame(HtmlDocument doc)
        {
            var titleNode = doc.DocumentNode.SelectNodes(".//h1[@class='header']").FirstOrDefault();
            if(titleNode != null)
            {
                if(Regex.IsMatch(titleNode.InnerText,@"\(video game( [0-9]+|)\)",RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }
            return false;
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

        private static Double GetImdbRating(HtmlDocument doc)
        {
            var rating = doc.DocumentNode.SelectNodes(".//span[@class='rating-rating']").Single().InnerText;
            var IMDBrating = rating.Replace("\"", "");
            IMDBrating = IMDBrating.Remove(IMDBrating.IndexOf('/'));
            Double drating = 0.0;
            Double.TryParse(IMDBrating,out drating);
            return drating;
        }

        private static String GetPicURL(HtmlDocument doc)
        {
            var picURL = doc.DocumentNode.SelectNodes(".//td[@id='img_primary']").FirstOrDefault().InnerHtml;
            if (picURL.Contains("<img src="))
            {
                picURL = picURL.Remove(0, picURL.IndexOf("<img src=") + 10);
                picURL = picURL.Remove(picURL.IndexOf("\""));
            }
            return picURL.Replace("\n", "");
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
                    Type = HtmlEscapeCharConverter.Decode(g.InnerText.Trim().Replace("\n", ""))
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
                                          IMDBID = matches[0].Value.Replace("/", "").Replace("nm", "").Replace("\n", ""),
                                          Name = HtmlEscapeCharConverter.Decode(dname.InnerText.Replace("\n", ""))
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
                                            Name = HtmlEscapeCharConverter.Decode(wname.InnerText.Replace("\n", ""))
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
                    if (word.InnerText.Contains(" "))
                    {
                        var splitWord = word.InnerText.Split(' ');
                        foreach (var s in splitWord)
                        {
                            if (!keywords.Contains(s))
                                keywords += s + " ";
                        }
                    }
                    else
                    {
                        if (!keywords.Contains(word.InnerText))
                            keywords += word.InnerText + " ";
                    }
                }
            }
            return keywords.Replace("See more", "").Replace("\n", "").Trim();
        }

        private static String GetReleaseDate(HtmlDocument doc)
        {
            var divs = doc.DocumentNode.SelectNodes(".//div[@class='txt-block']");
            var dateString = divs
                .Where(x => x.SelectNodes(".//h4") != null)
                .Where(x => x.SelectNodes(".//h4").First().InnerText.Trim().Contains("Release Date"))
                .SingleOrDefault();
            string d = "";
            if (dateString != null)
            {
                var td = dateString.InnerText.Remove(dateString.InnerText.IndexOf("(")).Replace("Release Date:", "");
                d = td.Replace("\n", "");
                d = d.Remove(0, d.Length - 4);
            }
            
            return d.Replace("\n", "").Trim();
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
                var matches = Regex.Matches(t, "[0-9]+ min",RegexOptions.IgnoreCase);
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
            if (u == null)
                return "";
            if (u.InnerHtml.Contains("<p>"))
                storyNode = u.SelectNodes(".//p").FirstOrDefault();
            if (storyNode != null)
            {
                story = storyNode.InnerText;
                story = HtmlEscapeCharConverter.Decode(story);
            }
            if(story != null)
                return (story.Contains("Written by ")) ? story.Remove(story.LastIndexOf("Written by ")).Replace("\n", "").Trim() : story.Replace("\n", "").Trim();
            return "";
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
                    cast.Add(new Role
                                 {
                                     Character =
                                         HtmlEscapeCharConverter.Decode(Regex.Replace(character, @"(\{.*\}|\(.*\)|\[.*\])", "")
                                         .Replace("\n", "").Trim()),
                                     Person = new Person
                                                  {
                                                      IMDBID = actNum,
                                                      Name = HtmlEscapeCharConverter.Decode(name.Trim().Replace("\n", ""))
                                                  }
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
            return link.Trim().Replace("\n", "");
        }
    }
}
