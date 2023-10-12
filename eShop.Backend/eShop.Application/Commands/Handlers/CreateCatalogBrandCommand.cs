using AutoMapper;
using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public sealed class CreateCatalogBrandCommandHandler : IRequestHandler<CreateCatalogBrandCommand, CatalogBrand>
{
    private readonly ICatalogBrandService _catalogBrandService;
    private readonly IMapper _mapper;
    public CreateCatalogBrandCommandHandler(ICatalogBrandService catalogBrandService, IMapper mapper)
    {
        _catalogBrandService = catalogBrandService;      
        _mapper = mapper;
    }
    public async Task<CatalogBrand> Handle(CreateCatalogBrandCommand request, CancellationToken cancellationToken)
    {
        CatalogBrand catalogBrand = _mapper.Map<CatalogBrand>(request);
        return await _catalogBrandService.CreateCatalogBrand(catalogBrand);
    }
}
