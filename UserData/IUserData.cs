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

        List<UserClass> GetListUsers();

        UserClass GetInfoUserPassw(String password);

        UserClass GetInfoUserName(String name);

        UserClass AddUser(UserClass user);

        //----------------------------------------------------- Message Methods ---------------------------------------------//

        List<MessageClass> GetListMessages();

        MessageClass GetMessageId(String messageId);

    }
}
