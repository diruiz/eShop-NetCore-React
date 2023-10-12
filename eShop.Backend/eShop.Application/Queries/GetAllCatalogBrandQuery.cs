using eShop.Models.eShopDbModels;
using MediatR;


namespace eShop.Application.Queries;

public sealed class GetAllCatalogBrandQuery : IRequest<List<CatalogBrand>>
{
}
