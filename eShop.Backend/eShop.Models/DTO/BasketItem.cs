namespace eShop.Models.DTO;

public class BasketItem
{
    public int Id { get; set; }

    public int CatalogBrandId { get; set; }

    public int CatalogTypeId { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public string? PictureFileName { get; set; }

    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
