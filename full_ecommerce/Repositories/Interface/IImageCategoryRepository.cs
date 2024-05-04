using full_ecommerce.Data.Models;

namespace full_ecommerce.Repositories.Interface
{
    public interface IImageCategoryRepository
    {
        Task<CategoryIamge> Upload(IFormFile file, CategoryIamge blogImage);

        Task<IEnumerable<CategoryIamge>> GetAll();
    }
}
