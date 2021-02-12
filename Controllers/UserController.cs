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

        //----------------------------------    EndPoint Return Users Based on Password from the List ---------------------------------------//

        [HttpPost]
        [Route("{UserName}/{Password}")]

        public IActionResult GetUserLogIn(String UserName, String Password)
        {
            //Getting Password
            var GetUserP = _userData.GetUserPassword(Password);

            //Getting UserName
            var GetUserN = _userData.GetUserName(UserName);

            //Getting Messages
            var ObtainMessage = _userData.GetMessageOfUser(Password);


            
            if (GetUserP != null & GetUserN != null)
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



    }
}
