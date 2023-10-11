using AutoMapper;
using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommand, bool>
{
    private readonly ICatalogService _catalogService;
    private readonly IMapper _mapper;
    public UpdateCatalogCommandHandler(ICatalogService catalogService, IMapper mapper)
    {
        _catalogService = catalogService;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
    {
        Catalog catalog = _mapper.Map<Catalog>(request);
        return await _catalogService.UpdateCatalog(catalog);
    }
}
