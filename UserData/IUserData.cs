// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 02-15-2021
// ***********************************************************************
// <copyright file="IUserData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using User_API.UserClasses;

namespace User_API.UserData
{
    /// <summary>
    /// Interface IUserData.
    /// </summary>
    public interface IUserData
    {
        /// <summary>
        /// Gets the users list.
        /// </summary>
        /// <returns>List&lt;Users&gt;.</returns>
        List<Users> GetUsersList();

        /// <summary>
        /// Gets the information user.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>List&lt;Users&gt;.</returns>
        List<Users> GetInfoUser(string name);

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Users.</returns>
        Users GetId(Guid id);

        /// <summary>
        /// Gets the user password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>Users.</returns>
        Users GetUserPassword(string password);

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Users.</returns>
        Users GetUserName(string name);

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>Users.</returns>
        Users GetUserId(string userName, string password);

        /// <summary>Gets the password changed.</summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="newPassword">Creates new password.</param>
        /// <returns>Users.</returns>
        Users GetPasswordChanged(string userName, string password, string newPassword);

        /// <summary>
        /// Gets the message list.
        /// </summary>
        /// <returns>List&lt;Messages&gt;.</returns>
        List<Messages> GetMessageList();

        /// <summary>
        /// Gets the message of user.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>List&lt;Messages&gt;.</returns>
        List<Messages> GetMessageOfUser(string messageId);


    }
}
