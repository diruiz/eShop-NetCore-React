using AutoMapper;
using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public class UpdateCatalogBrandCommandHandler : IRequestHandler<UpdateCatalogBrandCommand, bool>
{
    private readonly ICatalogBrandService _catalogBrandService;
    private readonly IMapper _mapper;
    public UpdateCatalogBrandCommandHandler(ICatalogBrandService catalogBrandService, IMapper mapper)
    {
        _catalogBrandService = catalogBrandService;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCatalogBrandCommand request, CancellationToken cancellationToken)
    {
        CatalogBrand catalogBrand = _mapper.Map<CatalogBrand>(request);
        return await _catalogBrandService.UpdateCatalogBrand(catalogBrand);
    }
}
