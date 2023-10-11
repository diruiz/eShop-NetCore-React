using eShop.Models.eShopDbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Persistence.Mappings;

public class CatalogMapping : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> entity)
    {
        entity.ToTable("Catalog");

        entity.HasIndex(e => e.CatalogBrandId, "IX_Catalog_CatalogBrandId");

        entity.HasIndex(e => e.CatalogTypeId, "IX_Catalog_CatalogTypeId");
        
        entity.Property(e => e.Name).HasMaxLength(50);
        entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

        entity.HasOne(d => d.CatalogBrand).WithMany(p => p.Catalogs).HasForeignKey(d => d.CatalogBrandId);

        entity.HasOne(d => d.CatalogType).WithMany(p => p.Catalogs).HasForeignKey(d => d.CatalogTypeId);
    }
}
