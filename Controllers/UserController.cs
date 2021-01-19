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

        public IActionResult GetInfoUser(String UserName, String Password)
        {
            //Getting the password from SqlUserData 
            var GetUserP = _userData.GetInfoUserPassw(Password);

            //Getting the username from SqlUserData 
            var GetUserN = _userData.GetInfoUserName(UserName);

            //Get userClassPassword (from Message Table) 
            var ObtainMessage = _userData.GetMessageId(Password);


            //If these are not null /Display the message
            if (GetUserP != null & GetUserN != null)
            {


                //If UserPassword (User Table) and userClassPassword (from Message Table) match 
                //And// ObtainMessage is not null

                if (ObtainMessage != null)
                {
                    //Display the messages 
                    return Ok(ObtainMessage);
                }
                else
                {
                    //Display the messages when there is not messages for a particular user
                    //such as Diego/Admin2
                    return NotFound("Not Messages Available!!!");
                }


            }
            else
            {
                //Display the message when the password is wrong.
                return NotFound($"UserName  or  Password: {UserName} / {Password} are incorrect ");
            }
        }



        //----------------------------------    EndPoint Return Users from User Table -----------------------------------------------------//
        [HttpGet]
        [Route("DisplayUsers")]

        public IActionResult GetInfoUser()
        {
            //Calling the method (GetListUsers)
            return Ok(_userData.GetListUsers());

        }

        //----------------------------------    EndPoint Return Messages from Messages Table -----------------------------------------------------//

        [HttpGet]
        [Route("DisplayMessages")]
        public IActionResult GetInfoMessage()
        {
            //Calling the method (GetListUsers)
            return Ok(_userData.GetListMessages());

        }



    }
}
