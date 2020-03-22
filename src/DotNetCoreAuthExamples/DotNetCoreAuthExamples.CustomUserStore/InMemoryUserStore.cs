using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCoreAuthExamples.CustomUserStore
{
    public class InMemoryUserStore : IUserPasswordStore<IdentityUser>, IUserEmailStore<IdentityUser>
    {
        private InMemoryUserDataAccess _dataAccess;
        public InMemoryUserStore(InMemoryUserDataAccess da)
        {
            _dataAccess = da;
        }

        public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<IdentityResult>.Run(() =>
            {
                IdentityResult result = IdentityResult.Failed();
                bool createResult = _dataAccess.CreateUser(user);

                if (createResult)
                {
                    result = IdentityResult.Success;
                }

                return result;
            });
        }

        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public Task<IdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task<IdentityUser>.Run(() =>
            {
                return _dataAccess.GetByEmail(normalizedEmail);
            });
        }

        public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task<IdentityUser>.Run(() =>
            {
                return _dataAccess.GetUserById(userId);
            });
        }

        public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task<IdentityUser>.Run(() =>
            {
                return _dataAccess.GetUserByUsername(normalizedUserName);
            });
        }

        public Task<string> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.Email;
            });
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<bool>.Run(() =>
            {
                return user.EmailConfirmed;
            });
        }

        public Task<string> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.NormalizedEmail;
            });
        }

        public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.NormalizedUserName;
            });
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() => { return user.PasswordHash; });
        }

        public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.Id;
            });
        }

        public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.UserName;
            });
        }

        public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<bool>.Run(() => { return true; });
        }

        public Task SetEmailAsync(IdentityUser user, string email, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                user.Email = email;
            });
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.EmailConfirmed = confirmed;
            });
        }

        public Task SetNormalizedEmailAsync(IdentityUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.NormalizedEmail = normalizedEmail;
            });
        }

        public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.NormalizedUserName = normalizedName;
            });
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
        {
            return Task.Run(() => { user.PasswordHash = passwordHash; });
        }

        public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.UserName = userName;
                user.NormalizedUserName = userName.ToUpper();
            });
        }

        public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task<IdentityResult>.Run(() =>
            {
                IdentityResult result = IdentityResult.Failed();
                bool updateResult = _dataAccess.Update(user);

                if (updateResult)
                {
                    result = IdentityResult.Success;
                }

                return result;
            });
        }

    }
}
