using eShop.Application.Commands;
using FluentValidation;

namespace eShop.Application.Validations;

public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogCommand>
{
    public CreateCatalogCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage($"{nameof(CreateCatalogCommand.Name)} must be specified!");
        RuleFor(x => x.PictureFileName).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.PictureFileName));
    }
}
