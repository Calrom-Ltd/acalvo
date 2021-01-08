using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.UserClasses;

namespace User_API.UserData
{
    //Implement the interface created
    public class FUserData : IUserData
    {

        //Hard Code / Develop List of Users / To test the API
        List<UserClass> ListOfUsers = new List<UserClass>()
        {

             new UserClass()
            {
                Password = "Admin1",
                UserName = "Tom",
                Message = "Working on the API"
             },
                new UserClass()
            {
                Password = "Admin2",
                UserName = "Maria",
                Message = "Developing Training API"
             }
         };

        public UserClass AddUser(UserClass user)
        {
            throw new NotImplementedException();
        }

        //Obtain and Pass the Password
        public UserClass GetInfoUserPassw(string UPassword)
        {
            
            return ListOfUsers.SingleOrDefault(x => x.Password == UPassword); ;
        }

        //Obtain and Pass the Username
        public UserClass GetInfoUserName(string UName)
        {
            
            return ListOfUsers.SingleOrDefault(y => y.UserName == UName);
        }

        //Display the  List AboveS
        public List<UserClass> GetListUsers()
        {
           //Retrun the Lisf of user above
            return ListOfUsers;
        }
    }
}


     

