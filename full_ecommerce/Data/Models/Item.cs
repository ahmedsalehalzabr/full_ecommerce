namespace full_ecommerce.Data.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public decimal? Price { get; set; }
        public DateTime PublishedDate { get; set; }
       

        public ICollection<Category> Categories { get; set; }
       // public ICollection<Cart> Carts { get; set; }
    }
}
