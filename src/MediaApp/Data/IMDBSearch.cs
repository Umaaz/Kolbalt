using System;
using System.Collections;

namespace MediaApp
{
    class ImdbSearch
    {
        public ImdbSearch(String search)
        {
            Results = new ArrayList();
            this.Search = search;
        }

        public void SearchImdb(String source)
        {
            var s = source;
           
            if (source.Contains("Popular Titles"))
            {
                s = source.Remove(0, source.IndexOf("<b>Popular Titles"));
                s = s.Remove(s.IndexOf("<p><b>"));
                while (s.Contains("</a> "))
                {
                    s = s.Remove(0, s.IndexOf("<img src=\"")+10);
                    var p = s.Substring(0, s.IndexOf(("\"")));
                    s = s.Remove(0, s.IndexOf("href=\"") + 6);
                    var u = s.Substring(0, s.IndexOf("\""));
                    s = s.Remove(0,s.IndexOf(";\">")+3);
                    var t = s.Substring(0, s.IndexOf(("</a>")));
                    s = s.Remove(0, s.IndexOf("</a>") + 4);
                    var y = s.Substring(0, s.IndexOf("<"));
                    Results.Add(new Imdbresult(t, u, y,p));
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
                    s = s.Remove(0, s.IndexOf("href=\"") + 6);
                    var u = s.Substring(0, s.IndexOf("\""));
                    s = s.Remove(0, s.IndexOf(";\">") + 3);
                    var t = s.Substring(0, s.IndexOf(("</a>")));
                    s = s.Remove(0, s.IndexOf("</a>") + 4);
                    var y = s.Substring(0, s.IndexOf("<"));
                    Results.Add(new Imdbresult(t, u, y, p));
                }
            }
            if(source.Contains("<b>Titles (Partial Matches)"))
            {
                s = source.Remove(0, source.IndexOf("<b>Titles (Partial Matches)"));
                s = s.Remove(s.IndexOf("<p><b>"));
                while (s.Contains("</a> "))
                {
                    s = s.Remove(0, s.IndexOf("<img src=\"")+10);
                    var p = s.Substring(0, s.IndexOf(("\"")));
                    s = s.Remove(0, s.IndexOf("href=\"") + 6);
                    var u = s.Substring(0, s.IndexOf("\""));
                    s = s.Remove(0,s.IndexOf(";\">")+3);
                    var t = s.Substring(0, s.IndexOf(("</a>")));
                    s = s.Remove(0, s.IndexOf("</a>") + 4);
                    var y = s.Substring(0, s.IndexOf("<"));
                    Results.Add(new Imdbresult(t, u, y,p));
                }
            }
            if (source.Contains("<b>Titles (Approx Matches)"))
            {
                s = source.Remove(0, source.IndexOf("<b>Titles (Approx Matches)"));
                s = s.Remove(s.IndexOf("<p><b>"));
                while (s.Contains("</a> "))
                {
                    s = s.Remove(0, s.IndexOf("<img src=\"")+10);
                    var p = s.Substring(0, s.IndexOf(("\"")));
                    s = s.Remove(0, s.IndexOf("href=\"") + 6);
                    var u = s.Substring(0, s.IndexOf("\""));
                    s = s.Remove(0,s.IndexOf(";\">")+3);
                    var t = s.Substring(0, s.IndexOf(("</a>")));
                    s = s.Remove(0, s.IndexOf("</a>") + 4);
                    var y = s.Substring(0, s.IndexOf("<"));
                    Results.Add(new Imdbresult(t, u, y,p));
                }
            }
            
        }

        public Imdbresult GetResultByIndex(int index)
        {
            return (Imdbresult) Results[index];
        }

        public string Search { get; set; }

        public ArrayList Results { get; set; }
    }
}
