using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Queries.Handlers;

public class GetCatalogBrandByIdQueryHandler : IRequestHandler<GetCatalogBrandByIdQuery, CatalogBrand>
{
    private readonly ICatalogBrandService _catalogBrandService;
    public GetCatalogBrandByIdQueryHandler(ICatalogBrandService catalogBrandService)
    {
        _catalogBrandService = catalogBrandService;        
    }
    public async Task<CatalogBrand> Handle(GetCatalogBrandByIdQuery request, CancellationToken cancellationToken)
    {        
        return await _catalogBrandService.GetCatalogBrandById(request.Id);
    }
}
