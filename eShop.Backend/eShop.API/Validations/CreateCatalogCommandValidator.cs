using eShop.Application.Commands;
using FluentValidation;

namespace eShop.API.Validations;

public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogCommand>
{
    public CreateCatalogCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage($"{nameof(CreateCatalogCommand.Name)} must be specified!");        
    }
}
