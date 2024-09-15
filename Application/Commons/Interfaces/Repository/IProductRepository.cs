using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using Domain.Entities;

namespace Application.Commons.Interfaces.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts(List<int>? categories, string? name, int limit = 0, int offset = 0);
    Task<Product> CreateProduct(ProductRequest product);
    Task<Product> GetProductById(Guid productId);
    Task<Product> UpdateProduct(Guid productId, UpdateProductRequest product);
    Task<Product> DeleteProduct(Guid productId);
}