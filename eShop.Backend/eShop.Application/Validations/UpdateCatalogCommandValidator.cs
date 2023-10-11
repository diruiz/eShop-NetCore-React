using eShop.Application.Commands;
using FluentValidation;

namespace eShop.Application.Validations;

public class UpdateCatalogCommandValidator : AbstractValidator<UpdateCatalogCommand>
{
    public UpdateCatalogCommandValidator()
    {
        this.RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage($"{nameof(CreateCatalogCommand.Name)} must be specified!");
        this.RuleFor(x => x.Price).GreaterThan(0).WithMessage($"{nameof(CreateCatalogCommand.Price)} must be greater than 0!");
    }
}
