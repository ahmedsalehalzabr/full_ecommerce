namespace full_ecommerce.DTO
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; }
        public string UrlHandle { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }

       public List<Guid> Items { get; set; } = new List<Guid>();
    }
}
