using MediatR;

namespace eShop.Application.Commands;

public sealed record UpdateCatalogCommand(
    int Id,
    int CatalogBrandId,
    int CatalogTypeId,
    string? Description,
    string Name,
    string? PictureFileName,
    decimal Price,
    int AvailableStock) : IRequest<bool>;
