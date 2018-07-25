using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AG.Web
{
    public class MyUserStore 
    {
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken) => throw new NotImplementedException();
        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken) => throw new NotImplementedException();

        public void Dispose() { }
    }
}
