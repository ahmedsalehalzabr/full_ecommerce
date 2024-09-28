using full_ecommerce.Data;
using full_ecommerce.Data.Models;
using full_ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace full_ecommerce.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context; // استبدل بـ DbContext الخاص بك

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ordere>> GetOrdersByUserIdAsync(Guid userId)
        {
            return await _context.Ordere.Include(x => x.OrderItems).Where(o => o.UserId == userId).ToListAsync();
        }
        public async Task<Ordere?> GetByIdAsync(Guid id)
        {
            return await _context.Ordere.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Ordere>> GetAllOrdersAsync()
        {
            return await _context.Ordere.Include(x => x.OrderItems).ToListAsync();
        }

        public async Task<Ordere> CreateOrderAsync(Ordere order)
        {
            await _context.Ordere.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateOrderAsync(Ordere order)
        {
            _context.Ordere.Update(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            var order = await _context.Ordere.FindAsync(orderId);
            if (order == null) return false;

            _context.Ordere.Remove(order);
            return await _context.SaveChangesAsync() > 0;
        }

      
    }
}
