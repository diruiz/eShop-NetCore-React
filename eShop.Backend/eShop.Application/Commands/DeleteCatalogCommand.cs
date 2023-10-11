using MediatR;

namespace eShop.Application.Commands;

public sealed record DeleteCatalogCommand(int Id) : IRequest<bool>;

