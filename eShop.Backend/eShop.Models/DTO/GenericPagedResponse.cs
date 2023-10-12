namespace eShop.Models.DTO;

public class GenericPagedResponse<T>
{
    public List<T> Items { get; set; }
    public int Count { get; set; }
}
