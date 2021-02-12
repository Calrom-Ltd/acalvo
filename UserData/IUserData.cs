using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.UserClasses;

namespace User_API.UserData
{
    public interface IUserData
    {
        //-----------                                         USER METHOD                                          -------------//

        List<Users> GetUsersList();

        Users GetUserId(Guid id);

        Users GetUserPassword(string password);

        Users GetUserName(string name);

        Users GetUserId(Users GetId);

        Users GetPasswordChanged(Users ChangePasswod, string NewPassword);


        //-----------                                         MESSAGE METHODS                                          -------------//

        List<Messages> GetMessageList();

        List<Messages> GetMessageOfUser(string messageId);


    }
}
