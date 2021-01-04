using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.UserClasses;

namespace User_API.UserData
{
    public interface IUserData
    {
        
        List<UserClass> GetListUsers();

        UserClass GetInfoUser(String password);

        UserClass AddUser(UserClass user);



    }
}
