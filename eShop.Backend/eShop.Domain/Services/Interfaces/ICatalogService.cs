using eShop.Models.DTO;
using eShop.Models.eShopDbModels;


namespace eShop.Domain.Services.Interfaces;

public interface ICatalogService
{
    Task<Catalog> CreateCatalog(Catalog catalog);
    Task<IEnumerable<Catalog>> GetAllCatalog();
    Task<GenericPagedResponse<Catalog>> GetCatalogPaged(int page, int limit);
    Task<Catalog> GetCatalogById(int catalogId);
    Task<bool> UpdateCatalog(Catalog catalog);
    Task<bool> DeleteCatalog(int catalogId);
}
