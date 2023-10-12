using AutoMapper;
using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public sealed class CreateCatalogTypeCommandHandler : IRequestHandler<CreateCatalogTypeCommand, CatalogType>
{
    private readonly ICatalogTypeService _catalogTypeService;
    private readonly IMapper _mapper;
    public CreateCatalogTypeCommandHandler(ICatalogTypeService catalogTypeService, IMapper mapper)
    {
        _catalogTypeService = catalogTypeService;      
        _mapper = mapper;
    }
    public async Task<CatalogType> Handle(CreateCatalogTypeCommand request, CancellationToken cancellationToken)
    {
        CatalogType catalogType = _mapper.Map<CatalogType>(request);
        return await _catalogTypeService.CreateCatalogType(catalogType);
    }
}
