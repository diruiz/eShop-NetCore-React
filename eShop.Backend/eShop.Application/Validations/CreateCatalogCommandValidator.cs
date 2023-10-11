using eShop.Application.Commands;
using FluentValidation;

namespace eShop.Application.Validations;

public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogCommand>
{
    public CreateCatalogCommandValidator()
    {
        this.RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage($"{nameof(CreateCatalogCommand.Name)} must be specified!");
        this.RuleFor(x => x.Price).GreaterThan(0).WithMessage($"{nameof(CreateCatalogCommand.Price)} must be greater than 0!");
    }
}
