using AutoMapper;
using eShop.Application.Commands;
using eShop.Models.eShopDbModels;

namespace eShop.Application.MapperProfiles;

public class CatalogMapperProfile : Profile
{
    public CatalogMapperProfile()
    {
        this.CreateMap<Catalog, CreateCatalogCommand>();
        this.CreateMap<Catalog, UpdateCatalogCommand>();
        this.CreateMap<CreateCatalogCommand, Catalog>();
        this.CreateMap<UpdateCatalogCommand, Catalog>();
    }
}
