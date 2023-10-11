using eShop.Persistence.Context;
using eShop.Persistence.Repository.Interface;
using eShop.Persistence.UnitOfWork.Interface;

namespace eShop.Persistence.UnitOfWork.Implementation;

public class UnitOfWork : IUnitOfWork
{
    public EShopDBContext _dbContext { get; }
    public IUserRepository User { get; }
    public ICatalogRepository Catalog { get; }
    public ICatalogBrandRepository CatalogBrand { get; }
    public ICatalogTypeRepository CatalogType { get; }


    public UnitOfWork(
        EShopDBContext dbContext,
        ICatalogRepository catalog,        
        ICatalogBrandRepository catalogBrand,
        ICatalogTypeRepository catalogType,

        IUserRepository userRepository)
    {
        _dbContext = dbContext;
        Catalog = catalog;
        CatalogBrand = catalogBrand;
        CatalogType = catalogType;
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
