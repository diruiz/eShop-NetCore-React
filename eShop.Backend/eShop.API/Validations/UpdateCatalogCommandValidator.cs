using eShop.Application.Commands;
using FluentValidation;

namespace eShop.API.Validations;

public class UpdateCatalogCommandValidator : AbstractValidator<UpdateCatalogCommand>
{
    public UpdateCatalogCommandValidator()
    {
        this.RuleFor(x => x.Id).NotNull().WithMessage($"{nameof(UpdateCatalogCommand.Id)} must be specified!");
        this.RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage($"{nameof(UpdateCatalogCommand.Name)} must be specified!");     
    }
}
