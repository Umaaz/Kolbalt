using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using MediaApp.Data;
using MediaApp.Domain.Model;
using MediaApp.Domain.Validations;
using NHibernate.Linq;

namespace MediaApp.Domain.Commands
{
    public class AddFilmsCommand
    {
        public AddFilmsCommand()
        {
            ValidationErrors = new Dictionary<string, IList<ValidationFailure>>();
        }

        public IList<Film> Films { get; set; }
        public IDictionary<string, IList<ValidationFailure>> ValidationErrors { get; set; }
        #region Person Dictonary
        private readonly Dictionary<string, Person> _people = new Dictionary<string, Person>();
        Person GetPersonFromCache(string imdb)
        {
            Person temp;
            _people.TryGetValue(imdb, out temp);
            return temp;
        }
        void AddPersonToCache(Person person)
        {
            if (!_people.ContainsKey(person.IMDBID))
                _people[person.IMDBID] = person;
        }
        #endregion
        #region Genre Dictonary
        private readonly Dictionary<string, FilmType> _types = new Dictionary<string, FilmType>();
        FilmType GetTypeFromCache(string ftype)
        {
            FilmType type;
            _types.TryGetValue(ftype, out type);
            return type;
        }
        void AddTypeToCache(FilmType type)
        {
            if (!_types.ContainsKey(type.Type))
                _types[type.Type] = type;
        }
        #endregion
        #region Film Dictonary

        private readonly IDictionary<string, Film> _filmDictonary  = new Dictionary<string, Film>();
        Film GetFilmFromCache(string imdbID)
        {
            Film film;
            _filmDictonary.TryGetValue(imdbID, out film);
            return film;
        }
        void AddFilmToCache(Film film)
        {
            if (!_filmDictonary.ContainsKey(film.IMDBId))
                _filmDictonary[film.IMDBId] = film;
        }

        #endregion

        public bool Execute()
        {
            var mayCommit = true;

            var nhSession = NhContext.GetSession();
            using (var tx = nhSession.BeginTransaction())
            {
                var newFilms = new List<Film>();

                foreach (var film in Films)
                {
                    var realNewFilm = new Film();
                    if(GetFilmFromCache(film.IMDBId) != null || nhSession.Query<Film>().Where(x => x.IMDBId == film.IMDBId).Any()) 
                        continue;
                    AddFilmToCache(film);
                    realNewFilm.FilmPath = film.FilmPath;
                    realNewFilm.IMDBId = film.IMDBId;
                    realNewFilm.ReleaseYear = film.ReleaseYear;
                    realNewFilm.RunTime = film.RunTime;
                    realNewFilm.Synopsis = film.Synopsis;
                    realNewFilm.Title = film.Title;
                    realNewFilm.Keywords = film.Keywords;
                    realNewFilm.DirectorIndexing = film.DirectorIndexing;
                    realNewFilm.GenreIndexing = film.GenreIndexing;
                    realNewFilm.CharIndexing = film.CharIndexing;
                    realNewFilm.PersonIndexing = film.PersonIndexing;
                    realNewFilm.PicURL = film.PicURL;

                    foreach (var person in film.Director)
                    {
                        var director = GetPersonFromCache(person.IMDBID) ??
                                       nhSession.Query<Person>().Where(x => x.IMDBID == person.IMDBID).
                                           SingleOrDefault() ?? person;
                        AddPersonToCache(director);
                        realNewFilm.Director.Add(director);
                    }

                    foreach (var person in film.Writers)
                    {
                        var writer = GetPersonFromCache(person.IMDBID) ??
                                     nhSession.Query<Person>().Where(x => x.IMDBID == person.IMDBID).
                                         SingleOrDefault() ?? person;
                        AddPersonToCache(writer);
                        realNewFilm.Writers.Add(writer);
                    }

                    foreach (var genre in film.Genre)
                    {
                        var type = GetTypeFromCache(genre.Type) ??
                                   nhSession.Query<FilmType>().Where(x => x.Type == genre.Type).
                                       SingleOrDefault() ?? genre;
                        AddTypeToCache(type);
                        realNewFilm.Genre.Add(type);
                    }

                    foreach (var role in film.Cast)
                    {
                        var actor = GetPersonFromCache(role.Person.IMDBID)
                                    ??
                                    nhSession.Query<Person>().Where(x => x.IMDBID == role.Person.IMDBID).
                                        SingleOrDefault()
                                    ?? role.Person;
                        AddPersonToCache(actor);
                        var role2 = new Role
                                        {
                                            Character = role.Character,
                                            Person = actor
                                        };
                        realNewFilm.Cast.Add(role2);
                    }
                    newFilms.Add(realNewFilm);
                }

                var validator = new FilmValidator();
                foreach (var newFilm in newFilms)
                {
                    var results = validator.Validate(newFilm);
                    if (results.IsValid)
                    {
                        nhSession.Save(newFilm);
                    }
                    else
                    {
                        ValidationErrors.Add(newFilm.IMDBId, results.Errors);
                        mayCommit = false;
                    }
                }

                if (mayCommit)
                    tx.Commit();
            }
            return mayCommit;
        }
    }
}