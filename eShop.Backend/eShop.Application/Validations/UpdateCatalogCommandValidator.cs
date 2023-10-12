using eShop.Application.Commands;
using FluentValidation;

namespace eShop.Application.Validations;

public class UpdateCatalogCommandValidator : AbstractValidator<UpdateCatalogCommand>
{
    public UpdateCatalogCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage($"{nameof(UpdateCatalogCommand.Id)} must be specified!");
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage($"{nameof(UpdateCatalogCommand.Name)} must be specified!");
        RuleFor(x => x.PictureFileName).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.PictureFileName));
    }
}
