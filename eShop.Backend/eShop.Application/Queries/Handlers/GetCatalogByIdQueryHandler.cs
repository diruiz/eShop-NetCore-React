using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Queries.Handlers;

public class GetCatalogByIdQueryHandler : IRequestHandler<GetCatalogByIdQuery, Catalog>
{
    private readonly ICatalogService _catalogService;
    public GetCatalogByIdQueryHandler(ICatalogService catalogService)
    {
        _catalogService = catalogService;        
    }
    public async Task<Catalog> Handle(GetCatalogByIdQuery request, CancellationToken cancellationToken)
    {        
        return await _catalogService.GetCatalogById(request.Id);
    }
}
