using full_ecommerce.Data;
using full_ecommerce.Data.Models;
using full_ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace full_ecommerce.Repositories.Implementation
{
    public class ItemRepository : IItemRepository
    {

        private readonly AppDbContext _db;

        public ItemRepository(AppDbContext db)
        {
            this._db = db;
        }
        public async Task<Item> CreateAsync(Item blogPost)
        {
            await _db.Items.AddAsync(blogPost);
            await _db.SaveChangesAsync();
            return blogPost;
        }

        public async Task<Item?> DeleteAsync(Guid id)
        {
            var existingBlogPost = await _db.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBlogPost != null)
            {
                _db.Items.Remove(existingBlogPost);
                await _db.SaveChangesAsync();
                return existingBlogPost;
            }
            return null;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _db.Items.ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(Guid id)
        {
            return await _db.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

      

        public async Task<Item?> UpdateAsync(Item blogPost)
        {
            var existingBlogPost = await _db.Items.
                FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            if (existingBlogPost == null)
            {
                return null;
            }

            //update BlogPost 
            _db.Entry(existingBlogPost).CurrentValues.SetValues(blogPost);

            //update Categories
            existingBlogPost.Categories = blogPost.Categories;

            await _db.SaveChangesAsync();

            return blogPost;
        }
    }
}
