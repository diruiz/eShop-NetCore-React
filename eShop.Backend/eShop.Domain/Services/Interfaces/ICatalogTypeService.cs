using eShop.Models.eShopDbModels;


namespace eShop.Domain.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<CatalogType> CreateCatalogType(CatalogType catalogType);
    Task<IEnumerable<CatalogType>> GetAllCatalogType();
    Task<CatalogType> GetCatalogTypeById(int catalogTypeId);
    Task<bool> UpdateCatalogType(CatalogType catalogType);
    Task<bool> DeleteCatalogType(int catalogTypeId);
}
