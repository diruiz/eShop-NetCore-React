using eShop.Models.eShopDbModels;
using eShop.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Context;

public partial class EShopDBContext : DbContext
{
    public EShopDBContext()
    {
    }

    public EShopDBContext(DbContextOptions<EShopDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catalog> Catalogs { get; set; }

    public virtual DbSet<CatalogBrand> CatalogBrands { get; set; }

    public virtual DbSet<CatalogType> CatalogTypes { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CatalogMapping().Configure(modelBuilder.Entity<Catalog>());
        new CatalogBrandMapping().Configure(modelBuilder.Entity<CatalogBrand>());
        new CatalogTypeMapping().Configure(modelBuilder.Entity<CatalogType>());       


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
