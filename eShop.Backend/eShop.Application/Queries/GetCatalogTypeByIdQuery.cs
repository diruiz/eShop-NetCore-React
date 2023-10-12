using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Queries;

public sealed class GetCatalogTypeByIdQuery : IRequest<CatalogType>
{
    public int Id { get; set; }
}
