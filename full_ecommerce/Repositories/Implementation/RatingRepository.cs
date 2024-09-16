using full_ecommerce.Data;
using full_ecommerce.Data.Models;
using full_ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace full_ecommerce.Repositories.Implementation
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _db;

        public RatingRepository(AppDbContext db)
        {
            this._db = db;
        }
        public async Task<Rating> CreateAsync(Rating rating)
        {
            await _db.Ratings.AddAsync(rating);
            await _db.SaveChangesAsync();
            return rating;
        }

        public async Task<Rating?> DeleteAsync(Guid id)
        {
            var existingRating = await _db.Ratings.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRating != null)
            {
                _db.Ratings.Remove(existingRating);
                await _db.SaveChangesAsync();
                return existingRating;
            }
            return null;
        }

        public async Task<IEnumerable<Rating>> GetAllAsync()
        {
            return await _db.Ratings.ToListAsync();
        }

        public Task<Rating?> GetByIdAsync(Guid id)
        {
            return _db.Ratings.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rating?> UpdateAsync(Rating rating)
        {
            var existingRating = await _db.Ratings.
               FirstOrDefaultAsync(x => x.Id == rating.Id);
            if (existingRating == null)
            {
                return null;
            }

            //update BlogPost 
            _db.Entry(existingRating).CurrentValues.SetValues(rating);

       

            await _db.SaveChangesAsync();

            return rating;
        }
    }
}
