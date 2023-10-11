using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using eShop.Persistence.UnitOfWork.Interface;

namespace eShop.Domain.Services.Implementation;

public class CatalogService : ICatalogService
{
    public IUnitOfWork _unitOfWork { get; }
    public CatalogService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Catalog> CreateCatalog(Catalog catalog)
    {        
        await _unitOfWork.Catalog.Add(catalog);

        var result = _unitOfWork.Save();

        return catalog;        
    }

    public async Task<IEnumerable<Catalog>> GetAllCatalog()
    {
        var CatalogList = await _unitOfWork.Catalog.GetAll();
        return CatalogList;
    }

    public async Task<Catalog> GetCatalogById(int catalogId)
    {
        if (catalogId > 0)
        {
            var Catalog = await _unitOfWork.Catalog.GetById(catalogId);
            if (Catalog != null)
            {
                return Catalog;
            }
        }
        return null;
    }

    public async Task<bool> UpdateCatalog(Catalog catalog)
    {
        if (catalog != null)
        {
            var dbCatalog = await _unitOfWork.Catalog.GetById(catalog.Id);
            if (dbCatalog != null)
            {
                dbCatalog.Name = catalog.Name;

                _unitOfWork.Catalog.Update(dbCatalog);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }

    public async Task<bool> DeleteCatalog(int catalogId)
    {
        if (catalogId > 0)
        {
            var catalog = await _unitOfWork.Catalog.GetById(catalogId);
            if (catalog != null)
            {
                _unitOfWork.Catalog.Delete(catalog);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
}
