using FluentValidation;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Domain.Validations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            DefaultValidatorOptions.WithMessage<Person, string>(RuleFor(x => x.IMDBID).Must(ValidationMethods.BeEmptyOr7Digits), "IMDB ID must be empty or 7 digits long");
            DefaultValidatorOptions.WithMessage<Person, string>(RuleFor(x => x.Name).Must(ValidationMethods.BeLessThan300), "Actor name must be less than 300 char long.");
        }
    }
}
