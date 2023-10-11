using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;


namespace eShop.Application.Queries.Handlers;

public class GetAllCatalogQueryHandler : IRequestHandler<GetAllCatalogQuery, List<Catalog>>
{
    private readonly ICatalogService _catalogService;
    public GetAllCatalogQueryHandler(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }
    public async Task<List<Catalog>> Handle(GetAllCatalogQuery request, CancellationToken cancellationToken)
    {
        var catalogList = await _catalogService.GetAllCatalog();
        return catalogList.ToList();
    }
}
