using AutoMapper;
using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public sealed class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, Catalog>
{
    private readonly ICatalogService _catalogService;
    private readonly IMapper _mapper;
    public CreateCatalogCommandHandler(ICatalogService catalogService, IMapper mapper)
    {
        _catalogService = catalogService;      
        _mapper = mapper;
    }
    public async Task<Catalog> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
    {
        Catalog catalog = _mapper.Map<Catalog>(request);
        return await _catalogService.CreateCatalog(catalog);
    }
}
