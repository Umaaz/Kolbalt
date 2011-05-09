using System;

namespace MediaApp.Data.Web
{
    public class HtmlEscapeCharConverter
    {
        private static readonly char[] C = {   '€',        ' ',       '\"',      '&',       '<',       '>',       '¡',        '¢',        '£',       '¤',        '¥',      '¦',       '§',       '¨',
                               '©',        'ª',       '¬',       '®',       '¯',       '°',       '±',        '²',        '³',       '´',        'µ',      '¶',       '·',       '¸',
                               '¹',        'º',       '»',       '¼',       '½',       '¾',       '¿',        'À',        'Á',       'Â',        'Ã',      'Ä',       'Å',
                               'Æ',        'Ç',       'È',       'É',       'Ê',       'Ë',       'Ì',        'Í',        'Î',       'Ï',        'Ð',      'Ñ',       'Ò',
                               'Ó',        'Ô',       'Õ',       'Ö',       '×',       'Ø',       'Ù',        'Ú',        'Û',       'Ü',        'Ý',      'Þ',       'ß',
                               'à',        'á',       'â',       'ã',       'ä',       'å',       'æ',        'ç',        'è',       'é',        'ê',      'ë',       'ì',
                               'í',        'î',       'ï',       'ð',       'ñ',       'ò',       'ó',        'ô',        'õ',       'ö',        '÷',      'ø',       'ù',
                               'ú',        'û',       'ü',       'ý',       'þ',       'ÿ',       '\'',       '-'};
        private static readonly string[] S = { "&euro;",   "&nbsp;",  "&quot;",  "&amp;",   "&lt;",    "&gt;",    "&iexcl;",  "&cent;",   "&pound;", "&curren;","&yen;",   "&brvbar;","&sect;",  "&uml;",
                               "&copy;",   "&ordf;",  "&not;",   "&reg;",   "&macr;",  "&deg;",   "&plusmn;", "&sup2;",   "&sup3;",  "&acute;", "&micro;", "&para;",  "&middot;","&cedil;",
                               "&sup1;",   "&ordm;",  "&raquo;", "&frac14;","&frac12;","&frac34;","&iquest;", "&Agrave;", "&Aacute;","&Acirc;", "&Atilde;","&Auml;",  "&Aring;",
                               "&AElig;",  "&Ccedil;","&Egrave;","&Eacute;","&Ecirc;", "&Euml;",  "&Igrave;", "&Iacute;", "&Icirc;", "&Iuml;",  "&ETH;",   "&Ntilde;","&Ograve;", 
                               "&Oacute;", "&Ocirc;", "&Otilde;","&Ouml;",  "&times;", "&Oslash;","&Ugrave;", "&Uacute;", "&Ucirc;", "&Uuml;",  "&Yacute;","&THORN;", "&szlig;", 
                               "&agrave;", "&aacute;","&acirc;", "&atilde;","&auml;",  "&aring;", "&aelig;",  "&ccedil;", "&egrave;","&eacute;","&ecirc;", "&euml;",  "&igrave;", 
                               "&iacute;", "&icirc;", "&iuml;",  "&eth;",   "&ntilde;","&ograve;","&oacute;", "&ocirc;",  "&otilde;","&ouml;",  "&divide;","&oslash;","&ugrave;", 
                               "&uacute;", "&ucirc;", "&uuml;",  "&yacute;","&thorn;", "xx",      "xx",       "&ndash;"};
        private static readonly string[] Hs = { "&#x80;",  "xx",      "&#x22;",  "&#x26;",  "&#x3C;",  "&#x3E;",  "&#xA1;",   "&#xA2;",   "&#xA3;",  "&#xA4;",  "&#xA5;",  "&#xA6;",  "&#xA7;",   "&#xA8;",
                                "&#xA9;",  "&#xAA;",  "&#xAC;",  "&#xAE;",  "&#xAF;",  "&#xB0;",  "&#xB1;",   "&#xB2;",   "&#xB3;",  "&#xB4;",  "&#xB5;",  "&#xB6;",  "&#xB7;",   "&#xB8;",
                                "&#xB9;",  "&#xBA;",  "&#xBB;",  "&#xBC;",  "&#xBD;",  "&#xBE;",  "&#xBF;",   "&#xC0;",   "&#xC1;",  "&#xC2;",  "&#xC3;",  "&#xC4;",  "&#xC5;",
                                "&#xC6;",  "&#xC7;",  "&#xC8;",  "&#xC9;",  "&#xCA;",  "&#xCB;",  "&#xCC;",   "&#xCD;",   "&#xCE;",  "&#xCF;",  "&#xD0;",  "&#xD1;",  "&#xD2;",
                                "&#xD3;",  "&#xD4;",  "&#xD5;",  "&#xD6;",  "&#xD7;",  "&#xD8;",  "&#xD9;",   "&#xDA;",   "&#xDB;",  "&#xDC;",  "&#xDD;",  "&#xDE;",  "&#xDF;",
                                "&#xE0;",  "&#xE1;",  "&#xE2;",  "&#xE3;",  "&#xE4;",  "&#xE5;",  "&#xE6;",   "&#xE7;",   "&#xE8;",  "&#xE9;",  "&#xEA;",  "&#xEB;",  "&#xEC;",
                                "&#xED;",  "&#xEE;",  "&#xEF;",  "&#xF0;",  "&#xF1;",  "&#xF2;",  "&#xF3;",   "&#xF4;",   "&#xF5;",  "&#xF6;",  "&#xF7;",  "&#xF8;",  "&#xF9;",
                                "&#xFA;",  "&#xFB;",  "&#xFC;",  "&#xFD;",  "&#xFE;",  "&#xFF;",  "&#x27;"};

        public static string Decode(String ss)
        {
            for (var i = 0; i < S.Length; i++)
            {
                if (S[i].Equals("xx")) continue;
                if (ss.IndexOf(S[i]) != -1)
                {
                    ss = ss.Replace(S[i], "" + C[i]);
                }
            }
            while (ss.IndexOf("&#") != -1)
            {
                var temp = ss.Remove(0, ss.IndexOf("&#")+2);
                temp = temp.Remove(temp.IndexOf(";"));
                if (temp.Equals(""))
                {
                    return ss;
                }
                if (temp.IndexOf("x") == -1)
                {
                    var x = int.Parse(temp);
                    var c = (char) x;
                    ss = ss.Replace("&#" + temp + ";", "" + c);
                }
                else
                {
                    if (temp.IndexOf("x") != -1)
                    {
                        for (var i = 0; i < Hs.Length; i++)
                        {
                            if (ss.IndexOf(Hs[i]) != -1)
                            {
                                ss = ss.Replace(Hs[i], "" + C[i]);
                            }
                        }
                    }
                }
            }
            return ss;
        }
    }
}
