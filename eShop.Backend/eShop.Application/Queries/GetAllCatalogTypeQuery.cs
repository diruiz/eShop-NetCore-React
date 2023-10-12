using eShop.Models.eShopDbModels;
using MediatR;


namespace eShop.Application.Queries;

public sealed class GetAllCatalogTypeQuery : IRequest<List<CatalogType>>
{
}
