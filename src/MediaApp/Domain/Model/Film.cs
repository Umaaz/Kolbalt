using System;
using System.Collections.Generic;

namespace MediaApp.Domain.Model
{  
    public class Film
    {
        public Film()
        {
            Cast = new List<Role>();
            Genre = new List<FilmType>();
        }
        //required
        public virtual Guid Id { get; set; }
        public virtual String Title { get; set; }

        //requirs one or the other
        public virtual Boolean OnExternalMedia { get; set; }
        public virtual String FilmPath { get; set; }
        
        //optional
        public virtual String IMDBId { get; set; }
        public virtual String PicURL { get; set; }
        public virtual Person Director { get; set; }
        public virtual int RunTime { get; set; }
        public virtual String ReleaseYear { get; set; }
        public virtual IList<Role> Cast { get; set; }
        public virtual IList<FilmType> Genre { get; set; }
        public virtual String Synopsis { get; set; }
        public virtual String Keywords { get; set; }
        public virtual String TrailerLink { get; set; }
        public virtual String Writers { get; set; }
        public virtual String SoundTrack { get; set; }
    }
}