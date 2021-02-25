using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using User_API.UserClasses;
using User_API.UserData;

namespace User_API.Controllers
{
    /// <summary>
    /// Comment that allow to have more than one Parameter with different Binding set
    /// Class UserController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        /// <summary>
        /// The user data.
        /// </summary>
        private readonly IUserData userData;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// Constructor which include an interface Injection
        public UserController(IUserData userData)
        {
            this.userData = userData;
        }

        /// <summary>
        /// Displays all users.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("DisplayAllUsers")]
        public IActionResult DisplayAllUsers()
        {
            return this.Ok(this.userData.GetUsersList());
        }



        /// <summary>
        /// Gets the information user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("DisplayInfoUser")]
        public IActionResult GetInfoUser([FromQuery] string userName)
        {
            if (userName != null)
            {
                return this.Ok(this.userData.GetInfoUser(userName));
            }
            else
            {
                return this.Ok(this.userData.GetInfoUser(userName));
            }
        }

        /// <summary>
        /// Gets the message list.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("MessagesList")]
        public IActionResult GetMessageList()
        {
            return this.Ok(userData.GetMessageList());
        }


        /// <summary>
        /// Gets the user identifier based on user name password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("ObtainUserID")]
        public IActionResult ObtainUsersID([FromQuery] string userName, [FromQuery] string password)
        {

            if (userName != null & password != null)
            {
                Users userId = this.userData.GetUserId(userName, password);

                return this.Ok(userId.UserId);
            }
            else
            {
                return this.NotFound("Fill the All required fields!!!");
            }
        }

        /// <summary>
        /// Gets the user log in.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("LogIn")]
        public IActionResult GetUserLogIn([FromQuery] string userName, [FromQuery] string password)
        {

            if (userName != null & password != null)
            {
                List<Messages> ObtainMessage = this.userData.GetMessageOfUser(password);

                if (ObtainMessage != null)
                {
                    return Ok(ObtainMessage);
                }
                else
                {
                    return this.NotFound("Not Messages Not Found!!!");
                }
            }
            else
            {
                return this.NotFound("Fill the All the fields!!!");
            }
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword([FromQuery] string userName, [FromQuery] string password, [FromQuery] string newPassword)
        {

            if (userName != null & password != null & newPassword != null)
            {
                Users theNewPassword = this.userData.GetPasswordChanged(userName, password, newPassword);

                return this.Ok(theNewPassword);
            }
            else
            {
                return this.NotFound("Fill all the fields required");
            }
        }
    }
}
