using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using eShop.Persistence.UnitOfWork.Interface;

namespace eShop.Domain.Services.Implementation;

public class CatalogBrandService : ICatalogBrandService
{
    public IUnitOfWork _unitOfWork { get; }
    public CatalogBrandService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CatalogBrand> CreateCatalogBrand(CatalogBrand catalogBrand)
    {        
        await _unitOfWork.CatalogBrand.Add(catalogBrand);

        var result = _unitOfWork.Save();

        return catalogBrand;        
    }

    public async Task<IEnumerable<CatalogBrand>> GetAllCatalogBrand()
    {
        var CatalogBrandList = await _unitOfWork.CatalogBrand.GetAll();
        return CatalogBrandList;
    }

    public async Task<CatalogBrand> GetCatalogBrandById(int catalogBrandId)
    {
        if (catalogBrandId > 0)
        {
            var CatalogBrand = await _unitOfWork.CatalogBrand.GetById(catalogBrandId);
            if (CatalogBrand != null)
            {
                return CatalogBrand;
            }
        }
        return null;
    }

    public async Task<bool> UpdateCatalogBrand(CatalogBrand catalogBrand)
    {
        if (catalogBrand != null)
        {
            var dbCatalogBrand = await _unitOfWork.CatalogBrand.GetById(catalogBrand.Id);
            if (dbCatalogBrand != null)
            {
                dbCatalogBrand.Brand = catalogBrand.Brand;
                _unitOfWork.CatalogBrand.Update(dbCatalogBrand);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }

    public async Task<bool> DeleteCatalogBrand(int catalogBrandId)
    {
        if (catalogBrandId > 0)
        {
            var catalogBrand = await _unitOfWork.CatalogBrand.GetById(catalogBrandId);
            if (catalogBrand != null)
            {
                _unitOfWork.CatalogBrand.Delete(catalogBrand);
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
