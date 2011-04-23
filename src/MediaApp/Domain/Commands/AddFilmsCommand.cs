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
                    if (!nhSession.Query<Film>().Where(x => x.IMDBId == film.IMDBId).Any())
                    {
                        realNewFilm.FilmPath = film.FilmPath;
                        realNewFilm.IMDBId = film.IMDBId;
                        realNewFilm.ReleaseYear = film.ReleaseYear;
                        realNewFilm.RunTime = film.RunTime;
                        realNewFilm.Synopsis = film.Synopsis;
                        realNewFilm.Title = film.Title;
                        realNewFilm.Director = GetPersonFromCache(film.Director.IMDBID)
                                               ??
                                               nhSession.Query<Person>().Where(x => x.IMDBID == film.Director.IMDBID).
                                                   SingleOrDefault()
                                               ?? film.Director;
                        AddPersonToCache(realNewFilm.Director);
                        foreach (var filmType in film.Genre)
                        {
                            var type =
                                nhSession.Query<FilmType>().Where(x => x.Type == filmType.Type).
                                    SingleOrDefault();
                            realNewFilm.Genre.Add(type ?? filmType);
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
                        ValidationErrors.Add(newFilm.FilmPath, results.Errors);
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