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

        //----------------------------------EndPoint Return User from the List -----------------------------------------------------//
        [HttpGet]
        [Route ("api/[controller]")]    

        public IActionResult GetInfoUser ()
        {

            return Ok(_userData.GetListUsers());

        }

    }
}
