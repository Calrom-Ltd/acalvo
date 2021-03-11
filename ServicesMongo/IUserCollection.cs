// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-10-2021
//
// Last Modified By : senti
// Last Modified On : 03-10-2021
// ***********************************************************************
// <copyright file="IUserCollection.cs" company="User_API">
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
    /// Interface IUserCollection
    /// </summary>
    public interface IUserCollection
     {
        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task.</returns>
        Task InsertUser(UsersMongo user);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task.</returns>
        Task UpdateUser(UsersMongo user);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        Task DeleteUser(string id);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>Task&lt;List&lt;UsersMongo&gt;&gt;.</returns>
        Task<List<UsersMongo>> GetAllUsers();

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;UsersMongo&gt;.</returns>
        Task<UsersMongo> GetUserById(string id);

        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>Task&lt;UsersMongo&gt;.</returns>
        Task<bool> LogIn(string password, string userName);
     }
}
