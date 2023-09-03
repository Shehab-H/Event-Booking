using Microsoft.AspNetCore.Identity;


namespace Application.Dto_s
{
    public record LoginResult(IdentityUser user,IList<string> roles);
}
