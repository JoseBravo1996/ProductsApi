using Application.Commons.Interfaces.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CategoryRepository(DataContext dbContext) : ICategoryRepository
{
    private readonly DataContext _dbContext = dbContext;
    public async Task<bool> GetExistCategory(int category)
    {
        var existingCategory = await _dbContext.Category.FirstOrDefaultAsync(x => x.CategoryId == category);
        return existingCategory != null;
    }
}
