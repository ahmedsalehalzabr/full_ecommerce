namespace full_ecommerce.DTO
{
    public class UpdateAddressDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }
    }
}
