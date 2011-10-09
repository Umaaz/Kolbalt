using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Domain.Validations
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RoleErrors = new Dictionary<int, IList<ValidationFailure>>();

            RuleFor(x => x.Cast).Must(Roles).WithMessage("Invalid Roles");
            RuleFor(x => x.Genre).Must(Types).WithMessage("Invalid Genres");
            RuleFor(x => x.Director).Must(Directors).WithMessage("Invalid Directors");
            RuleFor(x => x.Writers).Must(Writers).WithMessage("Invalid Writers");
            
            RuleFor(x => x.Title).NotNull().NotEmpty().Must(ValidationMethods.BeLessThan300).WithMessage("Must specify a title less than 300 characters long.");
            RuleFor(x => x.FilmPath).NotEmpty().When(x => x.OnExternalMedia == false).WithMessage("Must specify path to file if not on external media");
            RuleFor(x => x.IMDBId).Must(ValidationMethods.BeEmptyOr7Digits).WithMessage("IMDB ID must be empty or 7 digits long");
            RuleFor(x => x.PicURL).Must(ValidationMethods.BeLessThan300).WithMessage("PicURL is too long, must be less than 300 char");
            RuleFor(x => x.ReleaseYear).Length(0, 4).WithMessage("Release year must no less than for digits");
            RuleFor(x => x.Synopsis).Must(ValidationMethods.BeLessThan4000).WithMessage("Synopsis must be less than 4000 characters long");
            RuleFor(x => x.Keywords).Must(ValidationMethods.BeLessThan4000).WithMessage("Keyword list must not exceed 4000 characters");
            RuleFor(x => x.TrailerLink).Must(ValidationMethods.BeLessThan300).WithMessage("Trailor link must not exceed 300 characters");
            RuleFor(x => x.RunTime).LessThanOrEqualTo(999).WithMessage("Runtime must be between 0 - 999 minutes long");

            RuleFor(x => x.DirectorIndexing).Must(ValidationMethods.BeLessThan4000).WithMessage("Error: DI01");
            RuleFor(x => x.GenreIndexing).Must(ValidationMethods.BeLessThan4000).WithMessage("Error: GI01");
            RuleFor(x => x.CharIndexing).Must(ValidationMethods.BeLessThan4000).WithMessage("Error: CI01");
            RuleFor(x => x.PersonIndexing).Must(ValidationMethods.BeLessThan4000).WithMessage("Error: PI01");
            RuleFor(x => x.IMDBRating).LessThanOrEqualTo(10).WithMessage("Rating must be Equla or less than 10");

        }

        public Dictionary<int, IList<ValidationFailure>> RoleErrors { get; set; }
        public Dictionary<int, IList<ValidationFailure>> GenreErrors { get; set; }
        public Dictionary<int, IList<ValidationFailure>> WriterErrors { get; set; }
        public Dictionary<int, IList<ValidationFailure>> DirectorErrors { get; set; }
        
        private bool Directors(IList<Person> directors)
        {
            var result = true;
            var val = new PersonValidator();
            for (int i = 0; i < directors.Count; i++)
            {
                var director = directors[i];
                var results = val.Validate(director);
                if (!results.IsValid)
                {
                    result = false;
                    WriterErrors.Add(i, results.Errors);
                }
            }
            return result;
        }

        private bool Writers(IList<Person> writers)
        {
            var result = true;
            var val = new PersonValidator();
            for (int i = 0; i < writers.Count; i++)
            {
                var writer = writers[i];
                var results = val.Validate(writer);
                if(!results.IsValid)
                {
                    result = false;
                    WriterErrors.Add(i,results.Errors);
                }
            }
            return result;
        }

        private bool Types(IList<FilmType> Genres)
        {
            var result = true;
            var val = new GenreValidator();
            for (var i = 0; i < Genres.Count; i++)
            {
                var genre = Genres[i];
                var results = val.Validate(genre);
                if(!results.IsValid)
                {
                    result = false;
                    GenreErrors.Add(i,results.Errors);
                }
            }
            return result;
        }

        private bool Roles(IList<Role> roles)
        {
            var result = true;
            var val = new RoleValidator();
            for (var index = 0; index < roles.Count; index++)
            {
                var role = roles[index];
                var results = val.Validate(role);
                if (!results.IsValid)
                {
                    result = false;
                    RoleErrors.Add(index, results.Errors);
                }
            }
            return result;
        }
    }
}
