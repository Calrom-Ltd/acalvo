using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.UserClasses;

namespace User_API.UserData
{
    public class SqlUserData : IUserData
    {
        //Create object to access to User class 
        private UserContext _userContext;
        

        public SqlUserData (UserContext userContext)
        {

            _userContext = userContext;

        }

        //----------------------------------------------------- User Methods ---------------------------------------------//


        public UserClass AddUser(UserClass user)
        {
            throw new NotImplementedException();
        }

        //Obtain and Pass the Password

        public UserClass GetInfoUserPassw(string UPassword)
        {
            var userPassw = _userContext.Users.Find(UPassword);
            return userPassw;
        }
        //Obtain and Pass the UserName

        public UserClass GetInfoUserName(string UName)
        {
            var UserN = _userContext.Users.Find(UName);
            return UserN;
        }

        //Display the List
        public List<UserClass> GetListUsers()
        {
            //return the users from the table SqlServer
            return _userContext.Users.ToList();
        }


        //----------------------------------------------------- Message Methods ---------------------------------------------//

        public List<MessageClass> GetListMessages()
        {
            return _userContext.Messages.ToList();
        }

        public MessageClass GetMessageId()
        {
            throw new NotImplementedException();
        }
    }
}
