using full_ecommerce.Data;
using full_ecommerce.Data.Models;
using full_ecommerce.Migrations;
using full_ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace full_ecommerce.Repositories.Implementation
{
    public class BasketRepository : IBasketRepository
    {
        private readonly AppDbContext _context;

        public BasketRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<Basket> GetByUserIdAsync(Guid userId)
        {
            return await _context.Baskets
               .Include(c => c.Items) // تضمين العناصر المرتبطة بالسلة
               .ThenInclude(ci => ci.Item) // تضمين تفاصيل العناصر
               .FirstOrDefaultAsync(c => c.UserId == userId);
        }
  

        public async Task<Basket> UpdateAsync(Basket basket)
        {
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();
            return basket;
        }
    }
}
