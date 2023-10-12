using MediatR;
using eShop.Models.eShopDbModels;

namespace eShop.Application.Commands;

public sealed class CreateCatalogBrandCommand : IRequest<CatalogBrand> 
{   
    public string Brand { get; set; } = null!;
}