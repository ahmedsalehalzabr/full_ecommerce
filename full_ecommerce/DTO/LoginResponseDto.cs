namespace full_ecommerce.DTO
{
    public class LoginResponseDto
    {
     
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
