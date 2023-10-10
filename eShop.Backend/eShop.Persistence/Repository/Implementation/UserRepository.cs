using eShop.Models.eShopDbModels;
using eShop.Persistence.Context;
using eShop.Persistence.Repository.Interface;

namespace eShop.Persistence.Repository.Implementation;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(EShopDBContext dbContext) : base(dbContext)
    {
    }
}
