using eShop.Domain.Services.Interfaces;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public class DeleteCatalogTypeCommandHandler : IRequestHandler<DeleteCatalogTypeCommand, bool>
{
    private readonly ICatalogTypeService _catalogTypeService;
    public DeleteCatalogTypeCommandHandler(ICatalogTypeService catalogTypeService)
    {
        _catalogTypeService = catalogTypeService;
    }

    public async Task<bool> Handle(DeleteCatalogTypeCommand request, CancellationToken cancellationToken)
    {
        return await _catalogTypeService.DeleteCatalogType(request.Id);
    }
}
