using full_ecommerce.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace full_ecommerce.Repositories.Interface
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllAsync();

      //  Task<IActionResult> AddToCart(Guid itemId, int quantity);

        Task<Cart> CreateAsync(Cart cart);

        Task<Cart?> DeleteAsync(Guid id);
        Task<List<Cart>> GetCartsByUserId(Guid userId);
        Task<Cart> GetByUserIdAsync(Guid userId);
        Task UpdateAsync(Cart cart);
    }
}
