using MediatR;
using eShop.Models.eShopDbModels;

namespace eShop.Application.Commands;

public sealed class CreateCatalogCommand : IRequest<Catalog> 
{
    public int CatalogBrandId { get; set; }

    public int CatalogTypeId { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public string? PictureFileName { get; set; }

    public decimal Price { get; set; }

    public int AvailableStock { get; set; }
}