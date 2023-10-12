using MediatR;

namespace eShop.Application.Commands;

public sealed record DeleteCatalogBrandCommand(int Id) : IRequest<bool>;

