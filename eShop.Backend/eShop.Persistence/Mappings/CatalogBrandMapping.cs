using eShop.Models.eShopDbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Persistence.Mappings;

public class CatalogBrandMapping : IEntityTypeConfiguration<CatalogBrand>
{
    public void Configure(EntityTypeBuilder<CatalogBrand> entity)
    {
        entity.ToTable("CatalogBrand");

        entity.Property(e => e.Brand).HasMaxLength(100);
    }
}
