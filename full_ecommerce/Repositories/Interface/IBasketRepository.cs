using full_ecommerce.Data.Models;

namespace full_ecommerce.Repositories.Interface
{
    public interface IBasketRepository
    {
        Task<Basket> GetByUserIdAsync(Guid userId);
        Task<Basket> UpdateAsync(Basket basket);
    }
}
