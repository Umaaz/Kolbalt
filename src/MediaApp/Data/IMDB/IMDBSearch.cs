using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MediaApp.Data.IMDB
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
            return SearchIMDBBySource(source)[0];
        }

        public static IList<IMDBResult> SearchIMDBByTitle(String title)
        {
            var url = "http://www.IMDB.com/find?s=all&q=" + title;
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
            return SearchIMDBBySource(source);
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
                    results.Add(new IMDBResult(HtmlEscapeCharConverter.Decode(t), u, HtmlEscapeCharConverter.Decode(y), p));
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
                    results.Add(new IMDBResult(HtmlEscapeCharConverter.Decode(t), u, HtmlEscapeCharConverter.Decode(y), p));
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
                    results.Add(new IMDBResult(HtmlEscapeCharConverter.Decode(t), u, HtmlEscapeCharConverter.Decode(y), p));
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
                    results.Add(new IMDBResult(HtmlEscapeCharConverter.Decode(t), u, HtmlEscapeCharConverter.Decode(y), p));
                }
            }
            return results;
        }

        
    }
}
