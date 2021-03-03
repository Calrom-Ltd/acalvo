// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-03-2021
//
// Last Modified By : senti
// Last Modified On : 03-03-2021
// ***********************************************************************
// <copyright file="IMessageServices.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using User_API.UserClasses;

namespace User_API.Services
{
    /// <summary>
    /// Interface IMessageServices
    /// </summary>
    public interface IMessageServices
    {
        /// <summary>
        /// Gets the message list.
        /// </summary>
        /// <returns>List&lt;Messages&gt;.</returns>
        List<Messages> ListOfMessages();

        /// <summary>
        /// Gets the messages of user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List&lt;Messages&gt;.</returns>
        List<Messages> GetMessagesOfUser(Users id);
    }
}
