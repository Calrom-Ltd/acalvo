// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-03-2021
//
// Last Modified By : senti
// Last Modified On : 03-03-2021
// ***********************************************************************
// <copyright file="MessageController.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Services;

namespace User_API.Controllers
{
    /// <summary>
    /// Class MessageController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class MessageController : Controller
    {
        /// <summary>
        /// The message services
        /// </summary>
        private readonly IMessageServices messageServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController"/> class.
        /// </summary>
        /// <param name="messageServices">The message services.</param>
        public MessageController(IMessageServices messageServices)
        {
            this.messageServices = messageServices;
        }
        /// <summary>
        /// Displays all messages.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("DisplayListOfMessages")]
        public IActionResult DisplayAllMessages()
        {
            return this.Ok(this.messageServices.ListOfMessages());
        }
    }
}
