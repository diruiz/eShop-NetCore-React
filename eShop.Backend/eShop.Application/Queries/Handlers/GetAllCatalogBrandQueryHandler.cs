using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;


namespace eShop.Application.Queries.Handlers;

public class GetAllCatalogBrandQueryHandler : IRequestHandler<GetAllCatalogBrandQuery, List<CatalogBrand>>
{
    private readonly ICatalogBrandService _catalogBrandService;
    public GetAllCatalogBrandQueryHandler(ICatalogBrandService catalogBrandService)
    {
        _catalogBrandService = catalogBrandService;
    }
    public async Task<List<CatalogBrand>> Handle(GetAllCatalogBrandQuery request, CancellationToken cancellationToken)
    {
        var catalogBrandList = await _catalogBrandService.GetAllCatalogBrand();
        return catalogBrandList.ToList();
    }
}
