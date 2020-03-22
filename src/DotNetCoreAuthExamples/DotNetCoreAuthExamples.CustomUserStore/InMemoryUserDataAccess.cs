using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreAuthExamples.CustomUserStore
{
    public class InMemoryUserDataAccess
    {
        private List<IdentityUser> _users;
        public InMemoryUserDataAccess()
        {
            _users = new List<IdentityUser>();
        }
        public bool CreateUser(IdentityUser user)
        {
            _users.Add(user);
            return true;
        }

        public IdentityUser GetUserById(string id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public IdentityUser GetByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.NormalizedEmail == email);
        }

        public IdentityUser GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.NormalizedUserName == username);
        }

        public string GetNormalizedUsername(IdentityUser user)
        {
            return user.NormalizedUserName;
        }

        public bool Update(IdentityUser user)
        {
            // Since get user gets the user from the same in-memory list,
            // the user parameter is the same as the object in the list, so nothing needs to be updated here.
            return true;
        }
    }
}
