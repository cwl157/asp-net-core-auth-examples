using DotNetCoreExamples.CustomUserStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreExamples.CustomUserStore
{
    public class InMemoryUserDataAccess
    {
        private List<ApplicationUser> _users;
        public InMemoryUserDataAccess()
        {
            _users = new List<ApplicationUser>();
        }
        public bool CreateUser(ApplicationUser user)
        {
            _users.Add(user);
            return true;
        }

        public ApplicationUser GetUserById(string id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public ApplicationUser GetByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.NormalizedEmail == email);
        }

        public ApplicationUser GetUserByUsername(string username)
        {
             return _users.FirstOrDefault(u => u.NormalizedUserName == username);
        }

        public string GetNormalizedUsername(ApplicationUser user)
        {
            return user.NormalizedUserName;
        }

        public bool Update(ApplicationUser user)
        {
            // Since get user gets the user from the same in-memory list,
            // the user parameter is the same as the object in the list, so nothing needs to be updated here.
            return true;
        }
    }
}
