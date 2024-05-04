using full_ecommerce.Data.Models;

namespace full_ecommerce.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetById(Guid id);
        Task<Category?> GetByIdHandleAsync(string urlHandle);
        Task<Category> UpdateAsync(Category category);

        Task<Category?> DeleteAsync(Guid id);
    }
}
