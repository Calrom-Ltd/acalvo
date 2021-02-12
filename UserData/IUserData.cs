using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.UserClasses;

namespace User_API.UserData
{
    public interface IUserData
    {
        //----------------------------------------------------- User Methods ---------------------------------------------//

        List<Users> GetListUsers();

        Users GetInfoUserPassw(String password);

        Users GetInfoUserName(String name);


        //----------------------------------------------------- Message Methods ---------------------------------------------//

        List<Messages> GetListMessages();

        List<Messages> GetMessageId(String messageId);

    }
}
