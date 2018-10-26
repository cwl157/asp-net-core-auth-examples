using DotNetCoreExamples.CustomUserStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCoreExamples.CustomUserStore
{
    public class InMemoryUserStore : IUserPasswordStore<ApplicationUser>, IUserEmailStore<ApplicationUser>
    {
        private InMemoryUserDataAccess _dataAccess;
        public InMemoryUserStore(InMemoryUserDataAccess da)
        {
            _dataAccess = da;
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
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

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           
        }

        public Task<ApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task<ApplicationUser>.Run(() =>
            {
                return _dataAccess.GetByEmail(normalizedEmail);
            });
        }

        public Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task<ApplicationUser>.Run(() =>
            {
                return _dataAccess.GetUserById(userId);
            });
        }

        public Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task<ApplicationUser>.Run(() =>
            {
                return _dataAccess.GetUserByUsername(normalizedUserName);
            });
        }

        public Task<string> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
                return Task<string>.Run(() =>
                {
                    return user.Email;
                });
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task<bool>.Run(() =>
            {
                return user.EmailConfirmed;
            });
        }

        public Task<string> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.NormalizedEmail;
            });
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.NormalizedUserName;
            });
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() => { return user.PasswordHash; });
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.Id;
            });
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task<string>.Run(() =>
            {
                return user.UserName;
            });
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task<bool>.Run(() => { return true; });
        }

        public Task SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                user.Email = email;
            });
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.EmailConfirmed = confirmed;
            });
        }

        public Task SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.NormalizedEmail = normalizedEmail;
            });
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.NormalizedUserName = normalizedName;
            });
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            return Task.Run(() => { user.PasswordHash = passwordHash; });
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.UserName = userName;
                user.NormalizedUserName = userName.ToUpper();
            });
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
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
