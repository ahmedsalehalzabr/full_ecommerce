namespace full_ecommerce.DTO
{
    public class CartDto2
    {
        public List<GetCartDto> Carts { get; set; } = new List<GetCartDto>();
        public decimal SubTotal { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
