using eShop.Persistence.Repository.Interface;

namespace eShop.Persistence.UnitOfWork.Interface;

public interface IUnitOfWork
{
    IUserRepository User { get; }

    int Save();
}
