using eShop.Models.eShopDbModels;
using eShop.Persistence.Context;
using eShop.Persistence.Repository.Interface;

namespace eShop.Persistence.Repository.Implementation;

public class CatalogTypeRepository : GenericRepository<CatalogType>, ICatalogTypeRepository
{
    public CatalogTypeRepository(EShopDBContext dbContext) : base(dbContext)
    {
    }
}
