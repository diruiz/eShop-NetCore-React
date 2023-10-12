using eShop.Models.eShopDbModels;

namespace eShop.Domain.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<CatalogBrand> CreateCatalogBrand(CatalogBrand catalogBrand);
    Task<IEnumerable<CatalogBrand>> GetAllCatalogBrand();
    Task<CatalogBrand> GetCatalogBrandById(int catalogBrandId);
    Task<bool> UpdateCatalogBrand(CatalogBrand catalogBrand);
    Task<bool> DeleteCatalogBrand(int catalogBrandId);
}
