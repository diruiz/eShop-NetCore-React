namespace eShop.Models.eShopDbModels;

public partial class Catalog
{
    public int Id { get; set; }

    public int CatalogBrandId { get; set; }

    public int CatalogTypeId { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public string? PictureFileName { get; set; }

    public decimal Price { get; set; }

    public int AvailableStock { get; set; }

    public virtual CatalogBrand CatalogBrand { get; set; } = null!;

    public virtual CatalogType CatalogType { get; set; } = null!;
}
