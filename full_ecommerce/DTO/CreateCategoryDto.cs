namespace full_ecommerce.DTO
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string UrlHandle { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }

        public Guid[] Items { get; set; }
    }
}
