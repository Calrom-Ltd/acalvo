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

        //-----------                                         USER METHOD                                          -------------//

        public List<Users> GetUsersList()
        {
            //return the users from Users Table
            return _userContext.Users.ToList();
        }

        //Obtain Password
        public Users GetUserPassword(string UPassword)
        {

            //Obtaining User/Password from Table Users
            return _userContext.Users.SingleOrDefault(x => x.Password == UPassword);



        }

        //Obtain Username
        public Users GetUserName(string UName)
        {
            //return  UserName from Users Table

            return _userContext.Users.SingleOrDefault(x => x.UserName == UName);
        }


        public Users GetId(Guid id)
        {
            var UserId = _userContext.Users.Find(id);
            //Return UserId
            return UserId;
        }

        public Users GetUserId(Users userId)
        {
             //Finding UserId 
            var existingUserPassword = _userContext.Users.Find(userId.UserId);


            if (existingUserPassword != null)
            {

                //Return User Data (Based on the Id)
                return existingUserPassword;
            }
            else
            {
                throw new NotImplementedException();

            }

        }

        public Users GetPasswordChanged(Users userId, string NewPassword)
        {


            if (userId.Password != null)
            {
                //Passing New Password
                userId.Password = NewPassword;

                //Updating the Password
                _userContext.Users.Update(userId);

                //Save Changes
                _userContext.SaveChanges();

                //Return User Data (New ID)
                return userId;
            }
            else
            {
                throw new NotImplementedException();
            }


        }

        //-----------                                         MESSAGE METHODS                                          -------------//

        public List<Messages> GetMessageList()
        {
            //return List of Messages
            return _userContext.Messages.ToList();
        }

        //----------------------------------------------------- Lisf of Messages Based on UsersName/Password  ---------------------------------------------//
        public List<Messages> GetMessageOfUser(String messageId)
        {
            //New List Delcared
            List<Messages> StoreUserMessages = new List<Messages>();

            //Getting the messages
            var ListOfMessages = _userContext.Messages.Where(x => x.userId.Password == messageId);

            //Passing messages to new List
            foreach (var i in ListOfMessages)
            {
                StoreUserMessages.Add(i);
            }

            //Return the List
            return StoreUserMessages;
        }

    }

}
