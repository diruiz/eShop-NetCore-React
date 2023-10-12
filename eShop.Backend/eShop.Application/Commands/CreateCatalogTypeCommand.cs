using MediatR;
using eShop.Models.eShopDbModels;

namespace eShop.Application.Commands;

public sealed class CreateCatalogTypeCommand : IRequest<CatalogType> 
{  
    public string Type { get; set; } = null!;   
}