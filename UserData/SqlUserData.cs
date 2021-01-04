using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.UserClasses;

namespace User_API.UserData
{
    public class SqlUserData : IUserData
    {
        //Create object to access the List in UserContext
        private UserContext _userContext;

        public SqlUserData (UserContext userContext)
        {

            _userContext = userContext;

        }


        public UserClass AddUser(UserClass user)
        {
            throw new NotImplementedException();
        }

        public UserClass GetInfoUser(string password)
        {
            var userPassw = _userContext.Users.Find(password);
            return userPassw;
        }

        public List<UserClass> GetListUsers()
        {
            //return the users from the table SqlServer
            return _userContext.Users.ToList();
        }
    }
}
