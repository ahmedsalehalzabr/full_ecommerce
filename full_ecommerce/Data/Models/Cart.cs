using Microsoft.AspNetCore.Identity;

namespace full_ecommerce.Data.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
      //  public int Qty { get; set; }
      //  public Guid ItemId { get; set; }
        // public Item Items { get; set; }
        public decimal SubTotal { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; } 
        public IdentityUser IdentityUsers { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}
 