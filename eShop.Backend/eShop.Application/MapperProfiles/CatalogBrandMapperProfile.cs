using AutoMapper;
using eShop.Application.Commands;
using eShop.Models.eShopDbModels;

namespace eShop.Application.MapperProfiles;

public class CatalogBrandMapperProfile : Profile
{
    public CatalogBrandMapperProfile()
    {
        this.CreateMap<CatalogBrand, CreateCatalogBrandCommand>().ReverseMap();
        this.CreateMap<CatalogBrand, UpdateCatalogBrandCommand>().ReverseMap();       
    }
}
