using eShop.Persistence.Context;
using eShop.Persistence.Repository.Interface;
using eShop.Persistence.UnitOfWork.Interface;

namespace eShop.Persistence.UnitOfWork.Implementation;

public class UnitOfWork : IUnitOfWork
{
    public EShopDBContext _dbContext { get; }
    public IUserRepository User { get; }

    public UnitOfWork(EShopDBContext dbContext,
                        IUserRepository userRepository)
    {
        _dbContext = dbContext;
        User = userRepository;
    }

    public int Save()
    {
        return _dbContext.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}
