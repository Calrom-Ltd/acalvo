// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 03-03-2021
// ***********************************************************************
// <copyright file="IUserData.cs" company="PlaceholderCompany">
//     Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
        List<Users> UsersList();

        /// <summary>
        /// Gets the user password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>Users.</returns>
        Users ObtainUserPassword(string password);


        /// <summary>
        /// Obtains the name of the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>Users.</returns>
        Users ObtainUserName(string userName);

        /// <summary>
        /// Users the name and password verification.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool UserNameAndPasswordVerification(string name, string password);

        /// <summary>
        /// Obtains the user identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Users.</returns>
        Users ObtainUserId(Users Id);

        /// <summary>
        /// Gets the password changed.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="newPassword">Creates new password.</param>
        /// <returns>Users.</returns>
        Users ChangePassword(Users Id, string newPassword);

        /// <summary>
        /// Messageses the list.
        /// </summary>
        /// <returns>List&lt;Messages&gt;.</returns>
        List<Messages> MessagesList();


        /// <summary>
        /// Gets the message of user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>List&lt;Messages&gt;.</returns>
        List<Messages> MessageOfUser(Users userId);



    }
}
