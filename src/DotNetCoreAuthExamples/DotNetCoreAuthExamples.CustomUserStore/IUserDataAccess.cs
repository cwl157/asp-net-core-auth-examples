using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreExamples.CustomUserStore
{
    public interface IUserDataAccess<TUser> where TUser : class
    {
        bool CreateUser(TUser user);

        TUser GetUserByUsername(string username);

        TUser GetUserById(string id);

        bool Update(TUser user);

        TUser GetByEmail(string email);
    }
}
