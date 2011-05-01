using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using MediaApp.Domain.Model;

namespace MediaApp.Domain.Validations
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RoleErrors = new Dictionary<int, IList<ValidationFailure>>();

            RuleFor(x => x.Title).NotNull().NotEmpty().Must(BeLessThan300).WithMessage("Must specify a title less than 300 characters long.");
            RuleFor(x => x.RunTime).LessThanOrEqualTo(999).WithMessage("Runtime must be between 0 - 999 minutes long");
            RuleFor(x => x.FilmPath).NotEmpty().When(x => x.OnExternalMedia == false).WithMessage("Must specify path to file if not on external media");
            RuleFor(x => x.Synopsis).Must(BeLessThan4000).WithMessage("Synopsis must be less than 4000 characters long");
            RuleFor(x => x.IMDBId).Must(BeEmptyOr7Digits).WithMessage("IMDB ID must be empty or 7 digits long");
            RuleFor(x => x.Cast).Must(Roles).WithMessage("Invalid Roles");
            
        }

        public Dictionary<int, IList<ValidationFailure>> RoleErrors { get; set; } 

        private bool BeLessThan4000(string synopsis)
        {
            if (synopsis != null)
                return synopsis.Length <= 4000;
            return true;
        }

        private bool BeLessThan300(string title)
        {
            return title.Length <= 300;
        }

        private bool BeEmptyOr7Digits(string imdbId)
        {
            var pass = false;
            if (string.IsNullOrEmpty(imdbId))
                pass = true;
            else if (imdbId.Length == 7)
            {
                int result;
                if (int.TryParse(imdbId, out result))
                    pass = true;
            }
            return pass;
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

    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            
        }
    }
}
