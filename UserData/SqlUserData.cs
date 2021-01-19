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
        public List<MessageClass> GetMessageId(String messageId)
        {
            //New List to store the messages
            List<MessageClass> StroreUserMessagesList = new List<MessageClass>();


            //Filtering operators/ sequence(collection) based on a given cirteria (MessageCalss - userClass)
            // Using Where -- Returns values from the collection based on a predicate function. (Method Syntax)

            var listMessage = _userContext.Messages.Where(x => x.userClass.Password == messageId);

            //Adding the messages into the List
            foreach (var s in listMessage)
            {
                StroreUserMessagesList.Add(s);
            }


            return StroreUserMessagesList;
        }


    }
}
