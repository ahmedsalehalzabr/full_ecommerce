namespace full_ecommerce.DTO
{
    public class CreateItemDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }

       
    }
}
