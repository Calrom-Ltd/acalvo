// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-03-2021
//
// Last Modified By : senti
// Last Modified On : 03-03-2021
// ***********************************************************************
// <copyright file="IUserServices.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using User_API.UserClasses;

namespace User_API.Services
{
    /// <summary>
    /// Interface IUserServices
    /// </summary>
    public interface IUserServices
    {
        /// <summary>
        /// Lists the of users.
        /// </summary>
        /// <returns>List&lt;Users&gt;.</returns>
        List<Users> ListOfUsers();

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>Users.</returns>
        Users GetUserId(string userName, string password);

        /// <summary>
        /// Gets the password changed.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Users.</returns>
        Users GetPasswordChanged(Users Id, string newPassword);
    }
}
