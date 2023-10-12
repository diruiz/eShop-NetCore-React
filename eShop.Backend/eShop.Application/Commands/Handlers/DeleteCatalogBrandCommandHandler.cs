using eShop.Domain.Services.Interfaces;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public class DeleteCatalogBrandCommandHandler : IRequestHandler<DeleteCatalogBrandCommand, bool>
{
    private readonly ICatalogBrandService _catalogBrandService;
    public DeleteCatalogBrandCommandHandler(ICatalogBrandService catalogBrandService)
    {
        _catalogBrandService = catalogBrandService;
    }

    public async Task<bool> Handle(DeleteCatalogBrandCommand request, CancellationToken cancellationToken)
    {
        return await _catalogBrandService.DeleteCatalogBrand(request.Id);
    }
}
