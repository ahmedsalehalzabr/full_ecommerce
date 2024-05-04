namespace full_ecommerce.DTO
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }

        public List<ItemDto> Items { get; set; } = new List<ItemDto>();

    }
}
