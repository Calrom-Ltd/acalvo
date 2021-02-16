using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using User_API.UserClasses;
using User_API.UserData;

namespace User_API.Controllers
{
    [Route("api/[controller]")]

    // Comment that allow to have more than one Parameter with different Binding set
    [ApiController]
    public class UserController : Controller
    {


        private readonly IUserData _userData;



        //Constructor which include an interface Injection
        public UserController(IUserData userData, IUserData messageData)
        {
            _userData = userData;

        }

        //----------------------------------    EndPoint  List Of User's Messages (Based on UserName/Password)  ------------------------------//

        [HttpPost]
        [Route("LogIn")]

        public IActionResult GetUserLogIn([FromQuery]string UserName, [FromQuery]string Password)
        {
            //Getting Password
            Users ExistUserPassword = _userData.GetUserPassword(Password);

            //Getting UserName
            Users ExistUserName = _userData.GetUserName(UserName);

            //Getting Messages
            List<Messages> ObtainMessage = _userData.GetMessageOfUser(Password);



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

        public IActionResult GetUserList([FromQuery] string findUser)
        {
            //Calling the method (SqlUserData/GetUserList())
           // return Ok(_userData.GetUsersList());

            switch (findUser)
            {

                case "All":
                    return Ok(_userData.GetUsersList());

                case "Robb":
                    return Ok(_userData.GetUserName(findUser));

                case "Tomasa":
                    return Ok(_userData.GetUserName(findUser));

                case "Diana":
                    return Ok(_userData.GetUserName(findUser));

                case "Tom":
                    return Ok(_userData.GetUserName(findUser));

                default:
                    return NotFound("User Not Found");

            }



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
        [Route("GetUserId")]
        public IActionResult GetUserIdBasedOnUserNamePassword([FromQuery]string UserName, [FromQuery]string Password)
        {

            //Get UserName
            Users ExistUserName = _userData.GetUserName(UserName);

            //Get Passwod
            Users ExistUserPassword = _userData.GetUserPassword(Password);


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
        [Route("ChangePassword")]
        public IActionResult ChangePassword([FromQuery] string UserName, [FromQuery] string Password,[FromQuery] string NewPassword, Users User)
        {
            try
            {
               

                if (UserName != null & Password != null & NewPassword != null)
                {

                    //Get UserName
                    Users ExistUserName = _userData.GetUserName(UserName);
                    
                    //Get Password
                    Users ExistUserPassword = _userData.GetUserPassword(Password);

                    
                    Users UserId; 

                    //Passing the New Password
                    string EditPassword = NewPassword;

                    if (_userData.GetUsersList().Contains(ExistUserPassword) & _userData.GetUsersList().Contains(ExistUserName))
                    {
                        UserId = _userData.GetUserId(ExistUserPassword);

                        User.UserId = UserId.UserId;

                        //Passing Paramters (Update Password)
                        _userData.GetPasswordChanged(UserId, EditPassword);

                        //return User details (Password Updated)
                        return Ok(UserId);
                    }
                    else
                    {
                        return NotFound("UserName or Password Not Valid ");

                    }
                    
                }
                else
                {
                    return NotFound("Fill all the fields required");
                }
              
               
            }
            catch (KeyNotFoundException)
            {
               return NotFound("UserName or Password ");
            }

        }
    }
}
