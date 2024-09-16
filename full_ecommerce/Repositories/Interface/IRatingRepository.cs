using full_ecommerce.Data.Models;

namespace full_ecommerce.Repositories.Interface
{
    public interface IRatingRepository
    {
        Task<Rating> CreateAsync(Rating rating);

        Task<IEnumerable<Rating>> GetAllAsync();

        Task<Rating?> GetByIdAsync(Guid id);


        Task<Rating?> UpdateAsync(Rating rating);

        Task<Rating?> DeleteAsync(Guid id);
    }
}
