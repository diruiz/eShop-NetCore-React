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

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new BasketMapping().Configure(modelBuilder.Entity<Basket>());

        new UserMapping().Configure(modelBuilder.Entity<User>());


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
