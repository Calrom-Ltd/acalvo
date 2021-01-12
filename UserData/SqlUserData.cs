using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.UserClasses;

namespace User_API.UserData
{
    public class SqlUserData : IUserData
    {
        //Create an object to access  User class 
        private UserContext _userContext;


        public SqlUserData(UserContext userContext)
        {

            _userContext = userContext;

        }

        //----------------------------------------------------- User Methods ---------------------------------------------//


        //Obtain Password
        public UserClass GetInfoUserPassw(string UPassword)
        {

            //Obtaining User/Password from Table Users
            return _userContext.Users.SingleOrDefault(x => x.Password == UPassword);



        }

        //Obtain Username
        public UserClass GetInfoUserName(string UName)
        {
            //return  UserName from Users Table

            return _userContext.Users.SingleOrDefault(x => x.UserName == UName);
        }

        //Display the List
        public List<UserClass> GetListUsers()
        {
            //return the users from Users Table
            return _userContext.Users.ToList();
        }


        //----------------------------------------------------- Message Methods ---------------------------------------------//

        //Display the Message from the Database 

        public List<MessageClass> GetListMessages()
        {

            return _userContext.Messages.ToList();
        }

        //Obtain the userClass/Password (from Messages Table)
        //It will be used to compare that with User/Passwrod (from Users Table) (Admin1 / Admin1)
        public MessageClass GetMessageId(String messageId)
        {

            //Obtaining userClass.Password value from Table Messages

            return _userContext.Messages.SingleOrDefault(x => x.userClass.Password == messageId);
        }


    }
}
