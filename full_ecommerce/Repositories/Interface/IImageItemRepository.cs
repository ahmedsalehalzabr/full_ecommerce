using full_ecommerce.Data.Models;

namespace full_ecommerce.Repositories.Interface
{
    public interface IImageItemRepository
    {
        Task<ItemImage> Upload(IFormFile file, ItemImage blogImage);

        Task<IEnumerable<ItemImage>> GetAll();
    }
}
