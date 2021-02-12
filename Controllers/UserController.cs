using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.UserClasses;
using User_API.UserData;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private IUserData _userData;

     

        //Constructor which include an interface Injection
        public UserController(IUserData userData, IUserData messageData)
        {
            _userData = userData;

        }

        //----------------------------------    EndPoint  List Of User's Messages (Based on UserName/Password)  ------------------------------//

        [HttpPost]
        [Route("{UserName}/{Password}")]

        public IActionResult GetUserLogIn(String UserName, String Password)
        {
            //Getting Password
            var ExistUserPassword = _userData.GetUserPassword(Password);

            //Getting UserName
            var ExistUserName = _userData.GetUserName(UserName);

            //Getting Messages
            var ObtainMessage = _userData.GetMessageOfUser(Password);


            
            if (ExistUserPassword != null & ExistUserName != null)
            {


                if (ObtainMessage != null)
                {
                    //Return List of User Mesages
                    return Ok(ObtainMessage);
                }
                else
                {
                   //Return message (message not found)
                    return NotFound("Not Messages Not Found!!!");
                }


            }
            else
            {
                //Display Error Message (Password or UserName) Incorrest
                return NotFound($"UserName  or  Password: {UserName} / {Password} are incorrect ");
            }
        }



        //----------------------------------    EndPoint -  List of Users -----------------------------------------------------//

        [HttpGet]
        [Route("DisplayUsers")]

        public IActionResult GetUserList()
        {
            //Calling the method (SqlUserData/GetUserList())
            return Ok(_userData.GetUsersList());

        }

        //----------------------------------    EndPoint - List of Messages -----------------------------------------------------//


        [HttpGet]
        [Route("MessagesList")]
        public IActionResult GetMessageList()
        {
            //Calling the method (SqlUserData/GetMessageList())
            return Ok(_userData.GetMessageList());
        }

        //----------------------------------    EndPoint - Obtain UserId (Based on UserName/Password) -----------------------------------------------------//


        [HttpPost]
        [Route("GetUserId/{UserName}/{Password}")]
        public IActionResult GetUserIdBasedOnUserNamePassword(String UserName, string Password)
        {

            //Get UserName
            var ExistUserName = _userData.GetUserName(UserName);

            //Get Passwod
            var ExistUserPassword = _userData.GetUserPassword(Password);

           
            if (ExistUserName != null & ExistUserPassword != null)
            {

                ExistUserPassword.Password = ExistUserPassword.Password;

                //Get User-id
                _userData.GetUserId(ExistUserPassword);

                //Return User-id
                return Ok(ExistUserPassword.UserId);
            }
            else
            {
                return NotFound("Password could not be Updated");

            }


        }

        //----------------------------------    EndPoint - Change/Update Password -----------------------------------------------------//

        [HttpPost]
        [Route("ChangePassword/{UserName}/{Password}/{NewPassword}")]
        public IActionResult ChangePassword(string UserName, string Password, string NewPassword, Users User)
        {

            //Get UserName
            var ExistUserName = _userData.GetUserName(UserName);

            //Get Password
            var ExistUserPassword = _userData.GetUserPassword(Password);

            //Get Id of the User
            var UserId = _userData.GetUserId(ExistUserPassword);

            //Passing the New Password
            var EditPassword = NewPassword;

           
            if (ExistUserName != null & ExistUserPassword != null)
            {

                User.UserId = UserId.UserId;

                //Passing Paramters (Update Password)
                _userData.GetPasswordChanged(UserId, EditPassword);

                //return User details (Password Updated)
                return Ok(UserId);
            }
            else
            {
                return NotFound("Password could not be Updated");

            }


        }
    }
}
