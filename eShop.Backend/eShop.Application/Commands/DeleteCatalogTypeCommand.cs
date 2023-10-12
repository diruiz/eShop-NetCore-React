using MediatR;

namespace eShop.Application.Commands;

public sealed record DeleteCatalogTypeCommand(int Id) : IRequest<bool>;

