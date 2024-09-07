using Microsoft.AspNetCore.Identity;

namespace full_ecommerce.Data.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
   
        public int Quantity { get; set; }
      
        public Guid UserId { get; set; } 
        public IdentityUser IdentityUsers { get; set; }

        public ICollection<Item> Items { get; set; }




    }
}
 