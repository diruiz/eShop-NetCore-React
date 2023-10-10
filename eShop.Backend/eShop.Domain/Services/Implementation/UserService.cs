using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using eShop.Persistence.UnitOfWork.Interface;

namespace eShop.Domain.Services.Implementation;

public class UserService : IUserService
{
    public IUnitOfWork _unitOfWork { get; }
    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CreateUser(User user)
    {
        if (user != null)
        {
            await _unitOfWork.User.Add(user);

            var result = _unitOfWork.Save();

            if (result > 0)
                return true;
            else
                return false;
        }
        return false;
    }

    public async Task<IEnumerable<User>> GetAllUser()
    {
        var UserList = await _unitOfWork.User.GetAll();
        return UserList;
    }

    public async Task<User> GetUserById(int productId)
    {
        if (productId > 0)
        {
            var User = await _unitOfWork.User.GetById(productId);
            if (User != null)
            {
                return User;
            }
        }
        return null;
    }

    public async Task<bool> UpdateUser(User user)
    {
        if (user != null)
        {
            var dbUser = await _unitOfWork.User.GetById(user.Id);
            if (dbUser != null)
            {
                dbUser.Name = user.Name;              

                _unitOfWork.User.Update(dbUser);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }

    public async Task<bool> DeleteUser(int userId)
    {
        if (userId > 0)
        {
            var user = await _unitOfWork.User.GetById(userId);
            if (user != null)
            {
                _unitOfWork.User.Delete(user);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }


}
