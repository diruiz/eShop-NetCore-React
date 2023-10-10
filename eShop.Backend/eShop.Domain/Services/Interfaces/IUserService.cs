using eShop.Models.eShopDbModels;

namespace eShop.Domain.Services.Interfaces;

public interface IUserService
{
    Task<bool> CreateUser(User user);
    Task<IEnumerable<User>> GetAllUser();
    Task<User> GetUserById(int productId);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(int userId);
}
