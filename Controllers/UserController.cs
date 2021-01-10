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

        private IUserData _messageData;
        //Constructo which include a interface Injection
        public UserController(IUserData userData, IUserData messageData)
        {
            _userData = userData;

            _messageData = messageData;

        }

        //----------------------------------    EndPoint Return Users Based on Password from the List ---------------------------------------//

        [HttpPost]
        [Route("api/[controller]/{UserName}/{Password}")]

        public IActionResult GetInfoUser(String UserName, String Password)
        {
            //Getting the password from SqlUserData /or / FUserData
            var GetUserP = _userData.GetInfoUserPassw(Password);
            
            //Getting the username from SqlUserData /or / FUserData
            var GetUserN = _userData.GetInfoUserName(UserName);




            //If the fields are not null /Display the message
            if (GetUserP != null && GetUserN !=null)
            {
                //var GetMessage = _messageData.GetListMessages();

                //Get userClassPassword (from Message Table) 
                var ObtainMessage = _messageData.GetMessageId(Password);

                //If UserPassword (User Table) and userClassPassword (from Message Table) //Same
                if (GetUserP.Password == ObtainMessage.userClass.Password)
                {
                    //Display the message
                    return Ok(ObtainMessage);
                }
                else
                {
                    // return Ok(GetMessage.Find(ObtainMessage); 
                    return NotFound("Not Messages for this User Available!!!");
                }

               // GetUserP.Message
            }
            else
            {
                //Display the message when the password is wrong entered. 
                return NotFound($"UserName  or  Password: {UserName} / {Password} are incorrect ");
            }
        }



        //----------------------------------    EndPoint Return Users from the List -----------------------------------------------------//
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetInfoUser()
        {
            //Calling the method (FUserData/GetListUsers)
            return Ok(_userData.GetListUsers());

        }

        [HttpGet]
        [Route("api/[Controller] Message")]
        public IActionResult GetInfoMessage()
        {
            //Calling the method (FUserData/GetListUsers)
            return Ok(_messageData.GetListMessages());

        }



    }
}
