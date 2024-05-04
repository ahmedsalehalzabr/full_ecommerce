using full_ecommerce.Data.Models;
using full_ecommerce.Data;
using full_ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace full_ecommerce.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
            this._db = db;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory = await _db.Categories.Include(x => x.Items).FirstOrDefaultAsync(l => l.Id == id);
            if (existingCategory is null)
            {
                return null;
            }
            _db.Categories.Remove(existingCategory);
            await _db.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Categories.Include(x => x.Items).ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await _db.Categories.Include(x => x.Items).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Category?> GetByIdHandleAsync(string urlHandle)
        {
            return await _db.Categories.Include(x => x.Items).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);

        }
        public async Task<Category> UpdateAsync(Category category)
        {
            var existingCategory = await _db.Categories.Include(x => x.Items).FirstOrDefaultAsync(c => c.Id == category.Id);

            if (existingCategory != null)
            {
                _db.Entry(existingCategory).CurrentValues.SetValues(category);
                await _db.SaveChangesAsync();
                return category;
            }
            return null;
        }

      
    }
}
