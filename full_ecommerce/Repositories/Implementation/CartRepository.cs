using full_ecommerce.Data;
using full_ecommerce.Data.Models;
using full_ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace full_ecommerce.Repositories.Implementation
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _db;

        public CartRepository(AppDbContext db)
        {
            this._db = db; 
        }

        public async Task<Cart> CreateAsync(Cart cart) 
        {
            await _db.Carts.AddAsync(cart);
            await _db.SaveChangesAsync();
            return cart;
        }

       
        public async Task<Cart?> DeleteAsync(Guid id)
        {
            var existingBlogPost = await _db.Carts.FirstOrDefaultAsync(x => x.Id == id); 
            if (existingBlogPost != null)
            {
                _db.Carts.Remove(existingBlogPost);
                await _db.SaveChangesAsync();
                return existingBlogPost;
            }
            return null;
        }

        public async Task<IEnumerable<Cart>> GetAllAsync() 
        {
            return await _db.Carts.Include(x => x.Items).ToListAsync();  
        }

        public async Task<List<Cart>> GetCartsByUserId(Guid userId)
        {
            return await _db.Carts
                .Include(x => x.Items)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }
}
