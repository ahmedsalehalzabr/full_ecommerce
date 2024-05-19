namespace full_ecommerce.DTO
{
    public class CartDto
    {
        public Guid Id { get; set; }
      //  public int Qty { get; set; }
      //  public Guid ItemId { get; set; }
      
        public int Quantity { get; set; }
       
        public Guid UserId { get; set; }
        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
