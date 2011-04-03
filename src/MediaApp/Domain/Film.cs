using System;
using System.Collections.Generic;

namespace MediaApp.Domain
{  
    public class Film
    {
        public Film()
        {
            Cast = new List<Role>();
            Genre = new List<FilmType>();
            //Director = new List<Person>();
            Keywords = new List<Keyword>();
        }

        public virtual Guid Id { get; set; }
        public virtual string ImdbId { get; set; }

        public virtual string Title { get; set; }
        public virtual Person Director { get; set; }
        public virtual int RunTime { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual IList<Role> Cast { get; set; }
        public virtual IList<FilmType> Genre { get; set; }
        public virtual string Synopsis { get; set; }
        public virtual String FilmPath { get; set; }
        public virtual IList<Keyword> Keywords { get; set; }
        
        //reviews
        //writers
        //trailor link?
        //quotes
        //soundtrack info?
    }
}