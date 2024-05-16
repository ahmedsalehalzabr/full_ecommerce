using full_ecommerce.Data.Models;

namespace full_ecommerce.DTO
{
    public class GetCartDto
    {
        public Guid Id { get; set; }
       
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
