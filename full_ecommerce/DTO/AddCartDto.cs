namespace full_ecommerce.DTO
{
    public class AddCartDto
    {
       
        public Guid UserId { get; set; }
        public Guid[] Items { get; set; } 
    }
}
