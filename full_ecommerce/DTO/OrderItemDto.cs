namespace full_ecommerce.DTO
{
    public class OrderItemDto
    {
      
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public decimal? Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PriceDiscount { get; set; }
    }
}
