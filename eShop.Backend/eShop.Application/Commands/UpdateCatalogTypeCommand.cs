using MediatR;

namespace eShop.Application.Commands;

public sealed record UpdateCatalogTypeCommand(string Type) : IRequest<bool>;
