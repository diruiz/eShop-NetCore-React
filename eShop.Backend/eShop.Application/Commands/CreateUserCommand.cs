using MediatR;

namespace eShop.Application.Commands;

public sealed record CreateUserCommand(string Name) : IRequest<bool>;
