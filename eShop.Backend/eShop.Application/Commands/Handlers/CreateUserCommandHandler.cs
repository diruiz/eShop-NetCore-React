using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Commands.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IUserService _userService;
    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }        

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user = new User() { Name = request.Name };
        return await _userService.CreateUser(user);            
    }
}
