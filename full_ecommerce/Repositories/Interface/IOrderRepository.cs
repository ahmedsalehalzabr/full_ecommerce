using full_ecommerce.Data.Models;

namespace full_ecommerce.Repositories.Interface
{
    public interface IOrderRepository
    {
    Task<IEnumerable<Ordere>> GetOrdersByUserIdAsync(Guid userId);
       
        Task<IEnumerable<Ordere>> GetAllOrdersAsync();
    Task<Ordere> CreateOrderAsync(Ordere order);
    Task<bool> UpdateOrderAsync(Ordere order);
    Task<bool> DeleteOrderAsync(Guid orderId);
    }
}
