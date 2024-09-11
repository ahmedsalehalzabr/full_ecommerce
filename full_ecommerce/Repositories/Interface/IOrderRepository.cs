using full_ecommerce.Data.Models;

namespace full_ecommerce.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<Ordere> GetOrderByIdAsync(Guid orderId);
        Task<IEnumerable<Ordere>> GetAllOrdersAsync();
        Task<Ordere> CreateOrderAsync(Ordere order);
        Task<bool> UpdateOrderAsync(Ordere order);
        Task<bool> DeleteOrderAsync(Guid orderId);
    }
}
