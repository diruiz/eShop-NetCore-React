using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Queries;

public sealed class GetCatalogBrandByIdQuery : IRequest<CatalogBrand>
{
    public int Id { get; set; }
}
