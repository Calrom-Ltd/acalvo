// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-03-2021
//
// Last Modified By : senti
// Last Modified On : 03-03-2021
// ***********************************************************************
// <copyright file="MessageServices.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using User_API.UserClasses;
using User_API.UserData;

namespace User_API.Services
{
    /// <summary>
    /// Class MessageServices.
    /// Implements the <see cref="User_API.Services.IMessageServices" />
    /// </summary>
    /// <seealso cref="User_API.Services.IMessageServices" />
    public class MessageServices : IMessageServices
    {
        /// <summary>
        /// The user data
        /// </summary>
        private readonly IUserData userData;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageServices"/> class.
        /// </summary>
        /// <param name="userData">The user data.</param>
        public MessageServices(IUserData userData)
        {
            this.userData = userData;
        }

        /// <summary>
        /// Gets the message list.
        /// </summary>
        /// <returns>List&lt;Messages&gt;.</returns>
        public List<Messages> ListOfMessages()
        {
            return this.userData.MessagesList().ToList();
        }

        /// <summary>
        /// Gets the messages of user.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>List&lt;Messages&gt;.</returns>
        /// <exception cref="Exception"></exception>
        public List<Messages> GetMessagesOfUser(Users Id)
        {
            List<Messages> messageList = new List<Messages>();

            return messageList = this.userData.MessageOfUser(Id);
        }
    }
}
