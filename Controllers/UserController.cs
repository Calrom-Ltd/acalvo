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
        //Constructo which include a interface Injection
        public UserController(IUserData userData)
        {
            _userData = userData;

        }

        //----------------------------------    EndPoint Return Users from the List -----------------------------------------------------//
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetInfoUser()
        {
            //Calling the method (FUserData/GetListUsers)
            return Ok(_userData.GetListUsers());

        }


        //----------------------------------    EndPoint Return Users Based on Password from the List ---------------------------------------//

        [HttpGet]
        [Route("api/[controller]/{UserName}/{Password}")]

        public IActionResult GetInfoUser ( String UserName, String Password)
        {
            //storing the Password into GetUser
            var GetUserP = _userData.GetInfoUser(Password);
            //storing the UserName into GetUser
            var GetUserN = _userData.GetInfoUser(UserName);
           
            //If the fields are not null /Display the message
            if (GetUserP != null || GetUserN !=null)
            {
                return Ok (GetUserP.Message);
            }
            else
            {
                //Display the message when the password is wrong entered. 
                return NotFound($"User Password: {Password} incorrect ");
            }
        }



    }
}
