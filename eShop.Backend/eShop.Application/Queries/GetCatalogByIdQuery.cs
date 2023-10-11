using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Queries;

public sealed class GetCatalogByIdQuery : IRequest<Catalog>
{
    public int Id { get; set; }
}
