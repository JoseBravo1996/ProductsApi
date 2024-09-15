namespace Application.Products.Queries;

public class ProductGetResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int? Discount { get; set; }
    public string? ImageUrl { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
}
