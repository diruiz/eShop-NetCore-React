using eShop.Models.eShopDbModels;
using eShop.Persistence.Context;
using eShop.Persistence.Repository.Interface;

namespace eShop.Persistence.Repository.Implementation;

public class CatalogBrandRepository : GenericRepository<CatalogBrand>, ICatalogBrandRepository
{
    public CatalogBrandRepository(EShopDBContext dbContext) : base(dbContext)
    {
    }
}
