using FluentValidation;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Domain.Validations
{
    public class GenreValidator: AbstractValidator<FilmType>
    {
        public GenreValidator()
        {
            DefaultValidatorOptions.WithMessage<FilmType, string>(RuleFor(x => x.Type).Must(ValidationMethods.BeLessThan300), "Genre name must be less than 300 char long.");
        }
    }
}
