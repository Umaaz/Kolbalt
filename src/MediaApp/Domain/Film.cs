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
        }

        public virtual Guid Id { get; set; }
        public virtual String IMDBId { get; set; }
        public virtual String PicURL { get; set; }
        public virtual String Title { get; set; }
        public virtual Person Director { get; set; }
        public virtual int RunTime { get; set; }
        public virtual String ReleaseYear { get; set; }
        public virtual IList<Role> Cast { get; set; }
        public virtual IList<FilmType> Genre { get; set; }
        public virtual String Synopsis { get; set; }
        public virtual String FilmPath { get; set; }
        public virtual String Keywords { get; set; }
        
        //reviews
        //writers
        //trailor link?
        //quotes
        //soundtrack info?
    }
}