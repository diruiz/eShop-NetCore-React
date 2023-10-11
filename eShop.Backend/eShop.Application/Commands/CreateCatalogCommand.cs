using MediatR;
using eShop.Models.eShopDbModels;

namespace eShop.Application.Commands;

public sealed record CreateCatalogCommand(
    int CatalogBrandId,
    int CatalogTypeId,
    string? Description,
    string Name,
    string? PictureFileName,
    decimal Price,
    int AvailableStock
    ) : IRequest<Catalog>;