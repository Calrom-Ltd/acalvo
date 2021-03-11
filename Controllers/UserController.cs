// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 02-25-2021
// ***********************************************************************
// <copyright file="UserController.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using User_API.Services;
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
    [Route("[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// The user services
        /// </summary>
        private readonly IUserServices userServices;

        /// <summary>
        /// The messages services
        /// </summary>
        private readonly IMessageServices messageServices;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userServices">The user services.</param>
        /// <param name="messageServices">The messages services.</param>
        public UserController(IUserServices userServices, IMessageServices messageServices)
        {
            this.userServices = userServices;

            this.messageServices = messageServices;
        }

        /// <summary>
        /// Displays all users.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("DisplayListOfUsers")]
        public IActionResult DisplayAllUsers()
        {
            return this.Ok(this.userServices.ListOfUsers());
        }

        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("LogIn")]
        public IActionResult LogIn([FromQuery] string userName, string password)
        {
            if (userName != null & password != null)
            {
                var userId = this.userServices.GetUserId(userName, password);
                var Message = this.messageServices.GetMessagesOfUser(userId);

                return this.Ok(Message);
            }
            else
            {
                return this.NotFound("Fill All the Field!!!");
            }
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("ChangedPassword")]
        public IActionResult ChangePassword([FromQuery] string userName, [FromQuery] string password, [FromQuery] string newPassword)
        {

            if (userName != null & password != null & newPassword != null)
            {
                var userId = this.userServices.GetUserId(userName, password);

                Users theNewPassword = this.userServices.GetPasswordChanged(userId, newPassword);

                return this.Ok(theNewPassword);
            }
            else
            {
                return this.NotFound("Fill all the fields required");
            }
        }
    }
}
