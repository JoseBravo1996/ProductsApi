namespace Domain.Entities;

public class Product
{
    public Product()
    {
        ProductId = Guid.NewGuid();
    }

    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int? Discount { get; set; }
    public string ImageUrl { get; set; }

    public virtual Category Category { get; set; }
}
