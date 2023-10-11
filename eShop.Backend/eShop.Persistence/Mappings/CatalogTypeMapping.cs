using eShop.Models.eShopDbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Persistence.Mappings;

public class CatalogTypeMapping : IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> entity)
    {
        entity.ToTable("CatalogType");
        
        entity.Property(e => e.Type).HasMaxLength(100);
    }
}
