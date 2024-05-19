namespace full_ecommerce.DTO
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public object? Id { get; internal set; }
    }
}
