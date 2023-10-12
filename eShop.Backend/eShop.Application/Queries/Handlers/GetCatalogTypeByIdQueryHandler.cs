using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Queries.Handlers;

public class GetCatalogTypeByIdQueryHandler : IRequestHandler<GetCatalogTypeByIdQuery, CatalogType>
{
    private readonly ICatalogTypeService _catalogTypeService;
    public GetCatalogTypeByIdQueryHandler(ICatalogTypeService catalogTypeService)
    {
        _catalogTypeService = catalogTypeService;        
    }
    public async Task<CatalogType> Handle(GetCatalogTypeByIdQuery request, CancellationToken cancellationToken)
    {        
        return await _catalogTypeService.GetCatalogTypeById(request.Id);
    }
}
