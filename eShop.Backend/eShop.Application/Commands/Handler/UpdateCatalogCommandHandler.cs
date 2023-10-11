using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Commands.Handler;

public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommand, bool>
{
    private readonly ICatalogService _catalogService;
    public UpdateCatalogCommandHandler(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    public async Task<bool> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
    {
        Catalog catalog = new Catalog() { Name = request.Name };
        return await _catalogService.UpdateCatalog(catalog);
    }
}
