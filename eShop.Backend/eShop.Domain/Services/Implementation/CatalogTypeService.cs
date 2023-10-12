using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using eShop.Persistence.UnitOfWork.Interface;

namespace eShop.Domain.Services.Implementation;

public class CatalogTypeService : ICatalogTypeService
{
    public IUnitOfWork _unitOfWork { get; }
    public CatalogTypeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CatalogType> CreateCatalogType(CatalogType catalogType)
    {        
        await _unitOfWork.CatalogType.Add(catalogType);

        var result = _unitOfWork.Save();

        return catalogType;        
    }

    public async Task<IEnumerable<CatalogType>> GetAllCatalogType()
    {
        var CatalogTypeList = await _unitOfWork.CatalogType.GetAll();
        return CatalogTypeList;
    }

    public async Task<CatalogType> GetCatalogTypeById(int catalogTypeId)
    {
        if (catalogTypeId > 0)
        {
            var CatalogType = await _unitOfWork.CatalogType.GetById(catalogTypeId);
            if (CatalogType != null)
            {
                return CatalogType;
            }
        }
        return null;
    }

    public async Task<bool> UpdateCatalogType(CatalogType catalogType)
    {
        if (catalogType != null)
        {
            var dbCatalogType = await _unitOfWork.CatalogType.GetById(catalogType.Id);
            if (dbCatalogType != null)
            {
                dbCatalogType.Type = catalogType.Type;

                _unitOfWork.CatalogType.Update(dbCatalogType);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }

    public async Task<bool> DeleteCatalogType(int catalogTypeId)
    {
        if (catalogTypeId > 0)
        {
            var catalogType = await _unitOfWork.CatalogType.GetById(catalogTypeId);
            if (catalogType != null)
            {
                _unitOfWork.CatalogType.Delete(catalogType);
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
