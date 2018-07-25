using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AG.Web
{
    public sealed class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        public ClaimsPrincipalFactory(UserManager<User> userManager, 
                                      RoleManager<Role> roleManager, 
                                      IOptions<IdentityOptions> optionsAccessor) 
                                        : base(userManager, roleManager, optionsAccessor) { }

        public async override Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user);
            var claims = (ClaimsIdentity)principal.Identity;

            claims.AddClaims(new[] { new Claim("Id", user.Id.ToString()) });

            return principal;
        }
    }    
}
