namespace eShop.Models.eShopDbModels;

public partial class CatalogBrand
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public virtual ICollection<Catalog> Catalogs { get; set; } = new List<Catalog>();
}
