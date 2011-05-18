using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace MediaApp.Data.Web.IMDB
{
    public class IMDBSearch
    {
        public static IMDBResult TopResultByTitle(String source)
        {
            var results = SearchIMDBByTitle(source);
            return results[0];
        }

        public static IMDBResult TopResultBySource(String source)
        {
            return Regex.IsMatch(source, "no matches",RegexOptions.IgnoreCase) ? null : SearchIMDBBySource(source)[0];
        }

        public static IList<IMDBResult> SearchIMDBByTitle(String title)
        {
            var url = "http://www.IMDB.com/find?s=tt&q=" + title;
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
            if (source.Contains("No matches."))
            {
                return null;
            }
            if (Regex.IsMatch(response.ResponseUri.ToString(), "http://www.imdb.com/title/tt[0-9]{7}(/|)"))
            {
                return SingleResult(response.ResponseUri.ToString());
            }
            if(Regex.IsMatch(response.ResponseUri.ToString(),@"http://www.imdb.com/find\?s=(all|tt)&q="))
            {
                return SearchIMDBBySource(source);
            }
            return null;
        }

        public static IList<IMDBResult> SingleResult(String url)
        {
            var film = IMDBFilm.GetFilmByUrl(url);
            return new List<IMDBResult>
                       {
                           new IMDBResult
                               {
                                   PicUrl = film.PicURL,
                                   Title = film.Title,
                                   IMDBIDUrl = film.IMDBId,
                                   Year = film.ReleaseYear
                               }
                       };
        }
         
        public static IList<IMDBResult> SearchIMDBBySource(String source)
        {
            IList<IMDBResult> results = new List<IMDBResult>();
            results.Clear();
            string s;
            if (source.Contains("Popular Titles"))
            {
                s = source.Remove(0, source.IndexOf("<b>Popular Titles"));
                s = s.Remove(s.IndexOf("<p><b>"));
                while (s.Contains("</a> "))
                {
                    s = s.Remove(0, s.IndexOf("<img src=\"")+10);
                    var p = s.Substring(0, s.IndexOf(("\"")));
                    s = s.Remove(0, s.IndexOf("href=\"/title/tt") + 15);
                    var u = s.Substring(0, s.IndexOf("\""));
                    s = s.Remove(0,s.IndexOf(";\">")+3);
                    var t = s.Substring(0, s.IndexOf(("</td>")));
                    var y = t.Remove(t.IndexOf(")") + 1);
                    y = y.Remove(0, y.IndexOf("("));
                    t = t.Remove(t.IndexOf("</a>"));
                    s = s.Remove(0, s.IndexOf("</td>") + 5);
                    results.Add(new IMDBResult(HtmlEscapeCharConverter.Decode(t.Trim()), u.Trim(), HtmlEscapeCharConverter.Decode(y.Trim()), p.Trim()));
                }
            }
            if (source.Contains("Titles (Exact Matches)"))
            {
                s = source.Remove(0, source.IndexOf("<b>Titles (Exact Matches)"));
                s = s.Remove(s.IndexOf("<p><b>"));
                while (s.Contains("</a> "))
                {
                    s = s.Remove(0, s.IndexOf("<img src=\"") + 10);
                    var p = s.Substring(0, s.IndexOf(("\"")));
                    s = s.Remove(0, s.IndexOf("href=\"/title/tt") + 15);
                    var u = s.Substring(0, s.IndexOf("\""));
                    s = s.Remove(0, s.IndexOf(";\">") + 3);
                    var t = s.Substring(0, s.IndexOf(("</td>")));
                    var y = t.Remove(t.IndexOf(")") + 1);
                    y = y.Remove(0, y.IndexOf("("));
                    t = t.Remove(t.IndexOf("</a>"));
                    s = s.Remove(0, s.IndexOf("</td>") + 5);
                    results.Add(new IMDBResult(HtmlEscapeCharConverter.Decode(t.Trim()), u.Trim(), HtmlEscapeCharConverter.Decode(y.Trim()), p.Trim()));
                }
            }
            if(source.Contains("<b>Titles (Partial Matches)"))
            {
                s = source.Remove(0, source.IndexOf("<b>Titles (Partial Matches)"));
                s = s.Remove(s.IndexOf("<p><b>"));
                while (s.Contains("</a> "))
                {
                    s = s.Remove(0, s.IndexOf("<img src=\"") + 10);
                    var p = s.Substring(0, s.IndexOf(("\"")));
                    s = s.Remove(0, s.IndexOf("href=\"/title/tt") + 15);
                    var u = s.Substring(0, s.IndexOf("\""));
                    s = s.Remove(0, s.IndexOf(";\">") + 3);
                    var t = s.Substring(0, s.IndexOf(("</td>")));
                    var y = t.Remove(t.IndexOf(")") + 1);
                    y = y.Remove(0, y.IndexOf("("));
                    t = t.Remove(t.IndexOf("</a>"));
                    s = s.Remove(0, s.IndexOf("</td>") + 5);
                    results.Add(new IMDBResult(HtmlEscapeCharConverter.Decode(t.Trim()), u.Trim(), HtmlEscapeCharConverter.Decode(y.Trim()), p.Trim()));
                }
            }
            if (source.Contains("<b>Titles (Approx Matches)"))
            {
                s = source.Remove(0, source.IndexOf("<b>Titles (Approx Matches)"));
                s = s.Remove(s.IndexOf("<p><b>"));
                while (s.Contains("</a> "))
                {
                    s = s.Remove(0, s.IndexOf("<img src=\"") + 10);
                    var p = s.Substring(0, s.IndexOf(("\"")));
                    s = s.Remove(0, s.IndexOf("href=\"/title/tt") + 15);
                    var u = s.Substring(0, s.IndexOf("\""));
                    s = s.Remove(0, s.IndexOf(";\">") + 3);
                    var t = s.Substring(0, s.IndexOf(("</td>")));
                    var y = t.Remove(t.IndexOf(")") + 1);
                    y = y.Remove(0, y.IndexOf("("));
                    t = t.Remove(t.IndexOf("</a>"));
                    s = s.Remove(0, s.IndexOf("</td>") + 5);
                    results.Add(new IMDBResult(HtmlEscapeCharConverter.Decode(t.Trim()), u.Trim(), HtmlEscapeCharConverter.Decode(y.Trim()), p.Trim()));
                }
            }
            return results;
        }

        
    }
}
