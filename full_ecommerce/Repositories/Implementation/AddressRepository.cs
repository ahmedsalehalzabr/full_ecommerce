using full_ecommerce.Data;
using full_ecommerce.Data.Models;
using full_ecommerce.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace full_ecommerce.Repositories.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _db;

        public AddressRepository(AppDbContext context)
        {
            this._db = context;
        }

        public async Task<Address> CreateAsync(Address address)
        {
            await _db.Addresses.AddAsync(address);
            await _db.SaveChangesAsync();
            return address;
        }

        public async Task<Address?> DeleteAsync(Guid id)
        {
            var existingAddresses = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAddresses != null)
            {
                _db.Addresses.Remove(existingAddresses);
                await _db.SaveChangesAsync();
                return existingAddresses;
            }
            return null;
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _db.Addresses.ToListAsync();
        }

        public async Task<Address> GetByUserIdAsync(Guid id)
        {
            return await _db.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Address?> UpdateAsync(Address address)
        {
            var existingAddress = await _db.Items.
               FirstOrDefaultAsync(x => x.Id == address.Id);
            if (existingAddress == null)
            {
                return null;
            }

            //update BlogPost 
            _db.Entry(existingAddress).CurrentValues.SetValues(address);

        

            await _db.SaveChangesAsync();

            return address;
        }
    }
}
