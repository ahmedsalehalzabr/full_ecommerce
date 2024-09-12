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
        public string Status { get; set; } = "Pending";
        public DateTime OrderDate { get; set; }

    }
}
