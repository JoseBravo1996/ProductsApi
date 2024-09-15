using Application.Commons.Interfaces.Repository;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProductRepository(DataContext dbContext) : IProductRepository
{
    private readonly DataContext _dbContext = dbContext;

    public async Task<Product> CreateProduct(ProductRequest request)
    {
        var product = new Product()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.Category,
            Discount = request.Discount,
            ImageUrl = request.ImageUrl
        };

        await _dbContext.Product.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        await _dbContext.Entry(product).Reference(p => p.Category).LoadAsync();

        return product;
    }

    public async Task<Product> DeleteProduct(Guid productId)
    {
        var product = await _dbContext.Product.Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.ProductId == productId);

        if (product != null)
        {
            _dbContext.Product.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        return product;
    }

    public async Task<Product?> GetProductById(Guid productId)
    {
        return await _dbContext.Product
            .Include(p => p.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductId == productId);
    }

    public async Task<IEnumerable<Product>> GetProducts(List<int>? categories = null, string? name = null, int limit = 0, int offset = 0)
    {
        IQueryable<Product> query = _dbContext.Product.Include(p => p.Category);

        if (categories != null && categories.Count != 0)
        {
            query = query.Where(p => categories.Contains(p.CategoryId));
        }

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(p => p.Name.Contains(name));
        }

        if (limit > 0)
        {
            query = query.Skip(offset).Take(limit);
        }

        return await query.ToListAsync();
    }

    public async Task<Product> UpdateProduct(Guid id, UpdateProductRequest product)
    {
        var existingProduct = await _dbContext.Product
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.ProductId == id);

        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Discount = product.Discount;
            existingProduct.ImageUrl = product.ImageUrl;

            await _dbContext.SaveChangesAsync();
        }

        return existingProduct;
    }

    public async Task<bool> GetExistProductByName(string name)
    {
        return await _dbContext.Product
            .AnyAsync(x => x.Name.ToUpper() == name.ToUpper());
    }
}
