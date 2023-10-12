using AutoMapper;
using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public class UpdateCatalogTypeCommandHandler : IRequestHandler<UpdateCatalogTypeCommand, bool>
{
    private readonly ICatalogTypeService _catalogTypeService;
    private readonly IMapper _mapper;
    public UpdateCatalogTypeCommandHandler(ICatalogTypeService catalogTypeService, IMapper mapper)
    {
        _catalogTypeService = catalogTypeService;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCatalogTypeCommand request, CancellationToken cancellationToken)
    {
        CatalogType catalogType = _mapper.Map<CatalogType>(request);
        return await _catalogTypeService.UpdateCatalogType(catalogType);
    }
}
