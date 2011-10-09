using FluentValidation;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Domain.Validations
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            DefaultValidatorOptions.WithMessage<Role, string>(RuleFor(x => x.Character).Must(ValidationMethods.BeLessThan300), "Character name must be less than 300 char long.");
            DefaultValidatorOptions.WithMessage<Role, string>(RuleFor(x => x.Person.IMDBID).Must(ValidationMethods.BeEmptyOr7Digits), "IMDB ID must be empty or 7 digits long");
            DefaultValidatorOptions.WithMessage<Role, string>(RuleFor(x => x.Person.Name).Must(ValidationMethods.BeLessThan300), "Actor name must be less than 300 char long.");
        }
    }
}
