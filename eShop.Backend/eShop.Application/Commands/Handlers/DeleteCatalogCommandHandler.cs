using eShop.Domain.Services.Interfaces;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommand, bool>
{
    private readonly ICatalogService _catalogService;
    public DeleteCatalogCommandHandler(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    public async Task<bool> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
    {
        return await _catalogService.DeleteCatalog(request.Id);
    }
}
