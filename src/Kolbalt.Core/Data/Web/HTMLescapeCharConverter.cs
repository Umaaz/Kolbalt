using System;
using System.Text.RegularExpressions;

namespace Kolbalt.Client.Data.Web
{
    public class HtmlEscapeCharConverter
    {
        private static readonly char[] C = { 
                               '€',        ' ',       '\"',      '&',       '<',       '>',       '¡',        '¢',        '£',       '¤',        '¥',      '¦',       '§',       '¨',
                               '©',        'ª',       '¬',       '®',       '¯',       '°',       '±',        '²',        '³',       '´',        'µ',      '¶',       '·',       '¸',
                               '¹',        'º',       '»',       '¼',       '½',       '¾',       '¿',        'À',        'Á',       'Â',        'Ã',      'Ä',       'Å',
                               'Æ',        'Ç',       'È',       'É',       'Ê',       'Ë',       'Ì',        'Í',        'Î',       'Ï',        'Ð',      'Ñ',       'Ò',
                               'Ó',        'Ô',       'Õ',       'Ö',       '×',       'Ø',       'Ù',        'Ú',        'Û',       'Ü',        'Ý',      'Þ',       'ß',
                               'à',        'á',       'â',       'ã',       'ä',       'å',       'æ',        'ç',        'è',       'é',        'ê',      'ë',       'ì',
                               'í',        'î',       'ï',       'ð',       'ñ',       'ò',       'ó',        'ô',        'õ',       'ö',        '÷',      'ø',       'ù',
                               'ú',        'û',       'ü',       'ý',       'þ',       '-'};
        private static readonly string[] S = { 
                               "&euro;",   "&nbsp;",  "&quot;",  "&amp;",   "&lt;",    "&gt;",    "&iexcl;",  "&cent;",   "&pound;", "&curren;","&yen;",   "&brvbar;","&sect;",  "&uml;",
                               "&copy;",   "&ordf;",  "&not;",   "&reg;",   "&macr;",  "&deg;",   "&plusmn;", "&sup2;",   "&sup3;",  "&acute;", "&micro;", "&para;",  "&middot;","&cedil;",
                               "&sup1;",   "&ordm;",  "&raquo;", "&frac14;","&frac12;","&frac34;","&iquest;", "&Agrave;", "&Aacute;","&Acirc;", "&Atilde;","&Auml;",  "&Aring;",
                               "&AElig;",  "&Ccedil;","&Egrave;","&Eacute;","&Ecirc;", "&Euml;",  "&Igrave;", "&Iacute;", "&Icirc;", "&Iuml;",  "&ETH;",   "&Ntilde;","&Ograve;", 
                               "&Oacute;", "&Ocirc;", "&Otilde;","&Ouml;",  "&times;", "&Oslash;","&Ugrave;", "&Uacute;", "&Ucirc;", "&Uuml;",  "&Yacute;","&THORN;", "&szlig;", 
                               "&agrave;", "&aacute;","&acirc;", "&atilde;","&auml;",  "&aring;", "&aelig;",  "&ccedil;", "&egrave;","&eacute;","&ecirc;", "&euml;",  "&igrave;", 
                               "&iacute;", "&icirc;", "&iuml;",  "&eth;",   "&ntilde;","&ograve;","&oacute;", "&ocirc;",  "&otilde;","&ouml;",  "&divide;","&oslash;","&ugrave;", 
                               "&uacute;", "&ucirc;", "&uuml;",  "&yacute;","&thorn;", "&ndash;"};
        
        public static string Decode(String ss)
        {
            if (String.IsNullOrEmpty(ss))
                return ss;
            if (Regex.IsMatch(ss, @"&[\w]+;"))
            {
                for (var i = 0; i < S.Length; i++)
                {
                    if (S[i].Equals("xx")) continue;
                    if (ss.IndexOf(S[i]) != -1)
                    {
                        ss = ss.Replace(S[i], "" + C[i]);
                    }
                }
            }
            
            if (Regex.IsMatch(ss, @"&#x[a-fA-F0-9]{2};"))
            {
                var matches = Regex.Matches(ss, @"&#x[a-fA-F0-9]{2};");
                foreach (Match match in matches)
                {
                    if(!ss.Contains(match.Value))
                        continue;
                    var code = Regex.Replace(match.Value, @"[\Wx]", "");
                    var decCode = Convert.ToInt32(code, 16);
                    var c = (char) decCode;
                    ss = ss.Replace(match.Value, c.ToString());
                }
            }
            
            if(Regex.IsMatch(ss,"&#[0-9]+;"))
            {
                var matches = Regex.Matches(ss, @"&#[0-9]+;");
                foreach (Match match in matches)
                {
                    if (!ss.Contains(match.Value))
                        continue;
                    var code = ss.Remove(0, ss.IndexOf("&#") + 2);
                    code = code.Remove(code.IndexOf(";"));
                    var c = (char) int.Parse(code);
                    ss = ss.Replace(match.Value, c.ToString());
                }
            }
            return ss;
        }
    }
}
