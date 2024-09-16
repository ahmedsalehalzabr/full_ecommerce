namespace full_ecommerce.Data.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public decimal? Ratings { get; set; }
        public string CommuntRating { get; set; }
        public ICollection<Ordere> Orders { get; set; }
    }
}
