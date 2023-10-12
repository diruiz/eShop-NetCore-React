using AutoMapper;
using eShop.Application.Commands;
using eShop.Models.eShopDbModels;

namespace eShop.Application.MapperProfiles;

public class CatalogTypeMapperProfile : Profile
{
    public CatalogTypeMapperProfile()
    {
        this.CreateMap<CatalogType, CreateCatalogTypeCommand>().ReverseMap();
        this.CreateMap<CatalogType, UpdateCatalogTypeCommand>().ReverseMap();       
    }
}
