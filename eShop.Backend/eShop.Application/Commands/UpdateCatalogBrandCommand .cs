using MediatR;

namespace eShop.Application.Commands;

public sealed record UpdateCatalogBrandCommand(string Brand) : IRequest<bool>;
