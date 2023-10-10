using eShop.Models.eShopDbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Persistence.Mappings;

public class BasketMapping : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> entity)
    {        
        entity.ToTable("Basket");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        entity.Property(e => e.Fecha)
            .IsRowVersion()
            .IsConcurrencyToken()
            .HasColumnName("fecha");
        entity.Property(e => e.Item)
            .HasMaxLength(10)
            .IsFixedLength()
            .HasColumnName("item");        
    }
}
