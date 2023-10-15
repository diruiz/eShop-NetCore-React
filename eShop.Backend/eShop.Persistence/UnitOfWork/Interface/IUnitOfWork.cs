using eShop.Persistence.Repository.Interface;

namespace eShop.Persistence.UnitOfWork.Interface;

public interface IUnitOfWork
{
    ICatalogRepository Catalog { get; }
    ICatalogBrandRepository CatalogBrand { get; }
    ICatalogTypeRepository CatalogType { get; }    

    int Save();
}
