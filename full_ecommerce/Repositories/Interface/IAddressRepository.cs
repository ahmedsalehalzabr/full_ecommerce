using full_ecommerce.Data.Models;

namespace full_ecommerce.Repositories.Interface
{
    public interface IAddressRepository
    {
        Task<Address> GetByUserIdAsync(Guid id);
        Task<Address?> UpdateAsync(Address address);
        Task<Address> CreateAsync(Address address);

        Task<IEnumerable<Address>> GetAllAsync();

        Task<Address?> DeleteAsync(Guid id);
    }
}
