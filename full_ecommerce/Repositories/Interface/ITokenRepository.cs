using Microsoft.AspNetCore.Identity;

namespace full_ecommerce.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
