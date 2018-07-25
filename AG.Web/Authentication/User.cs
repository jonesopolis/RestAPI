using Microsoft.AspNetCore.Identity;

namespace AG.Web
{
    public sealed class User : IdentityUser<long>
    {
        public User() { }
        
        public User(long id, string username)
        {
            Id = id;
            UserName = username;
        }      
    }
}
