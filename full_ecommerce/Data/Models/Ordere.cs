namespace full_ecommerce.Data.Models
{
    public class Ordere
    {
        public Guid Id { get; set; }
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
        public ICollection<OrderItem> OrderItems { get; set; }



    } 
  

}
