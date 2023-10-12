using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;


namespace eShop.Application.Queries.Handlers;

public class GetAllCatalogTypeQueryHandler : IRequestHandler<GetAllCatalogTypeQuery, List<CatalogType>>
{
    private readonly ICatalogTypeService _catalogTypeService;
    public GetAllCatalogTypeQueryHandler(ICatalogTypeService catalogTypeService)
    {
        _catalogTypeService = catalogTypeService;
    }
    public async Task<List<CatalogType>> Handle(GetAllCatalogTypeQuery request, CancellationToken cancellationToken)
    {
        var catalogTypeList = await _catalogTypeService.GetAllCatalogType();
        return catalogTypeList.ToList();
    }
}
