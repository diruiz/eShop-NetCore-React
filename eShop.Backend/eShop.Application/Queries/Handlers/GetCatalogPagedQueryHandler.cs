using eShop.Domain.Services.Interfaces;
using eShop.Models.DTO;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Queries.Handlers;

public sealed class GetCatalogPagedQueryHandler : IRequestHandler<GetCatalogPagedQuery, GenericPagedResponse<Catalog>>
{
    private readonly ICatalogService _catalogService;
    public GetCatalogPagedQueryHandler(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    public async Task<GenericPagedResponse<Catalog>> Handle(GetCatalogPagedQuery request, CancellationToken cancellationToken)
    {
        return await _catalogService.GetCatalogPaged(request.Page, request.Limit);
    }
}
