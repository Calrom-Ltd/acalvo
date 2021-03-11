// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-10-2021
//
// Last Modified By : senti
// Last Modified On : 03-10-2021
// ***********************************************************************
// <copyright file="IMessagesCollection.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Model;

namespace User_API.ServicesMongo
{
    /// <summary>
    /// Interface IMessagesCollection
    /// </summary>
    public interface IMessagesCollection
    {
        /// <summary>
        /// Inserts the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        Task InsertMessage(MessagesMongo message);

        /// <summary>
        /// Updates the message.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task.</returns>
        Task UpdateMessage(MessagesMongo user);

        /// <summary>
        /// Gets all messages.
        /// </summary>
        /// <returns>Task&lt;List&lt;MessagesMongo&gt;&gt;.</returns>
        Task<List<MessagesMongo>> GetAllMessages();

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;MessagesMongo&gt;.</returns>
        Task<MessagesMongo> GetUserById(string id);
    }
}
