namespace eShop.Models.eShopDbModels;

public partial class CatalogType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Catalog> Catalogs { get; set; } = new List<Catalog>();
}
