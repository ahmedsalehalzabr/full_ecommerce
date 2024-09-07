namespace full_ecommerce.Data.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
