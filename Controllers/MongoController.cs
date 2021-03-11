// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-10-2021
//
// Last Modified By : senti
// Last Modified On : 03-10-2021
// ***********************************************************************
// <copyright file="MongoController.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Model;
using User_API.ServicesMongo;

namespace User_API.Controllers
{
    /// <summary>
    /// Class MongoController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [ApiController]
    public class MongoController : Controller
    {
        /// <summary>
        /// The user collection
        /// </summary>
        private readonly IUserCollection userCollection;

        /// <summary>
        /// The messages collection
        /// </summary>
        private readonly IMessagesCollection messagesCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoController"/> class.
        /// </summary>
        /// <param name="userCollection">The user collection.</param>
        /// <param name="messagesCollection">The messages collection.</param>
        public MongoController(IUserCollection userCollection, IMessagesCollection messagesCollection)
        {
            this.userCollection = userCollection;

            this.messagesCollection = messagesCollection;
        }

        /// <summary>
        /// Gets the list of users.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("ListOfUsers")]
        public async Task<IActionResult> GetListOfUsers()
        {
            return this.Ok(await this.userCollection.GetAllUsers());
        }

        /// <summary>
        /// Gets the list of messages.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("ListOfMessages")]
        public async Task<IActionResult> GetListOfMessages()
        {
            return this.Ok(await this.messagesCollection.GetAllMessages());
        }

        /// <summary>
        /// Creates the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("CreateMessage")]
        public async Task<IActionResult> InsertMessage([FromBody] MessagesMongo message)
        {
            if (message == null)
            {
                return this.BadRequest();
            }
            else
            {
                await this.messagesCollection.InsertMessage(message);
                return this.Created("Cretated", true);
            }
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("InsertNewUser")]
        public async Task<IActionResult> CreateUser([FromBody] UsersMongo user)
        {
            if (user == null)
            {
                return this.BadRequest();
            }
            else
            {
                await this.userCollection.InsertUser(user);
                return this.Created("Cretated", true);
            }
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdateUser([FromBody] UsersMongo user, string id)
        {
            if (user == null)
            {
                return this.BadRequest();
            }
            else
            {
                user.Id = new MongoDB.Bson.ObjectId(id);
                await this.userCollection.UpdateUser(user);
                return this.Created("Cretated", true);
            }
        } 
        
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromQuery] string userName, string password)
        {
            if (userName == null && password == null)
            {
                return this.BadRequest();
            }
            else
            {
                return this.Ok("LogIn Success");
            }
        }



        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUser([FromQuery] string id)
        {
            await this.userCollection.DeleteUser(id);
            return this.NoContent(); 
        }
    }
}
