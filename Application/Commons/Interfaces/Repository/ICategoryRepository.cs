namespace Application.Commons.Interfaces.Repository;
public interface ICategoryRepository
{
    Task<bool> GetExistCategory(int category);
}
