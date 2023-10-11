using eShop.Models.eShopDbModels;
using eShop.Persistence.Context;
using eShop.Persistence.Repository.Interface;

namespace eShop.Persistence.Repository.Implementation;

public class CatalogRepository : GenericRepository<Catalog>, ICatalogRepository
{
    public CatalogRepository(EShopDBContext dbContext) : base(dbContext)
    {
    }
}
