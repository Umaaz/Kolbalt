using System;
using System.Collections.Generic;

namespace Kolbalt.Core.Domain.Model
{  
    public class Film
    {
        public Film()
        {
            Cast = new List<Role>();
            Genre = new List<FilmType>();
            Director = new List<Person>();
            Writers = new List<Person>();

            Title = "";
            OnExternalMedia = false;
            FilmPath = "";
            IMDBId = "";
            PicURL = "";
            ReleaseYear = "";
            Synopsis = "";
            Keywords = "";
            TrailerLink = "";

            DirectorIndexing = "";
            GenreIndexing = "";
            CharIndexing = "";
            PersonIndexing = "";
            IMDBRating = 0;
        }
        //required
        public virtual Guid Id { get; set; }
        public virtual String Title { get; set; }

        //requirs one or the other
        public virtual Boolean OnExternalMedia { get; set; }
        public virtual String FilmPath { get; set; }
        
        //optional
        public virtual Double IMDBRating { get; set; }
        public virtual String IMDBId { get; set; }
        public virtual String PicURL { get; set; }
        public virtual IList<Person> Director { get; set; }
        public virtual int RunTime { get; set; }
        public virtual String ReleaseYear { get; set; }
        public virtual IList<Role> Cast { get; set; }
        public virtual IList<FilmType> Genre { get; set; }
        public virtual String Synopsis { get; set; }
        public virtual String Keywords { get; set; }
        public virtual String TrailerLink { get; set; }
        public virtual IList<Person> Writers { get; set; }

        //indexing
        public virtual String DirectorIndexing { get; set; }
        public virtual String GenreIndexing { get; set; }
        public virtual String CharIndexing { get; set; }
        public virtual String PersonIndexing { get; set; }
    }
    public class FilmResult : Film
    {
        public FilmResult()
        {
            PossibleErrors = null;
        }

        public FilmResult(Film film)
        {
            PossibleErrors = null;
            IMDBRating = film.IMDBRating;
            Title = film.Title;
            Director = film.Director;
            Id = film.Id;
            OnExternalMedia = film.OnExternalMedia;
            FilmPath = film.FilmPath;
            IMDBId = film.IMDBId;
            PicURL = film.PicURL;
            RunTime = film.RunTime;
            ReleaseYear = film.ReleaseYear;
            Cast = film.Cast;
            Genre = film.Genre;
            Synopsis = film.Synopsis;
            Keywords = film.Keywords;
            TrailerLink = film.TrailerLink;
            Writers = film.Writers;
            DirectorIndexing = film.DirectorIndexing;
            GenreIndexing = film.GenreIndexing;
            CharIndexing = film.CharIndexing;
            PersonIndexing = film.PersonIndexing;
        }
        public Boolean? PossibleErrors { get; set; }
    }
}