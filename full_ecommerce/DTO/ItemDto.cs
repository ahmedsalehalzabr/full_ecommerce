namespace full_ecommerce.DTO
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public decimal? Price { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PriceDiscount { get; set; }  
    }
}
