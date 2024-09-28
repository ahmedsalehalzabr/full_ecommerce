using full_ecommerce.Data.Models;

namespace full_ecommerce.DTO
{
    public class OrderDto
    {

        public Guid UserId { get; set; }
        public string Addressid { get; set; }
        public string OrdrsType { get; set; }
        public string PriceDelivery { get; set; }
        public string OrdersPrice { get; set; }
        public string TotalPrice { get; set; }

        public string PaymentMethod { get; set; }
        public string Status { get; set; } = "0";
        public DateTime OrderDate { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
      

        // public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();

    }

    //public class CartItemDto
    //{
    //    public Guid CartId { get; set; }
    //    public string Title { get; set; }
    //    public string Qty { get; set; }
    //    public string Price { get; set; }

    //}
}
