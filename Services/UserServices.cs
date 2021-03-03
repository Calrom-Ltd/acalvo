// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-03-2021
//
// Last Modified By : senti
// Last Modified On : 03-03-2021
// ***********************************************************************
// <copyright file="UserServices.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using User_API.UserClasses;
using User_API.UserData;

namespace User_API.Services
{
    /// <summary>
    /// Class UserServices.
    /// Implements the <see cref="User_API.Services.IUserServices" />
    /// </summary>
    /// <seealso cref="User_API.Services.IUserServices" />
    public class UserServices : IUserServices
    {
        /// <summary>
        /// The user data
        /// </summary>
        private readonly IUserData userData;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserServices"/> class.
        /// </summary>
        /// <param name="userData">The user data.</param>
        public UserServices(IUserData userData)
        {
            this.userData = userData;
        }

        /// <summary>
        /// Lists the of users.
        /// </summary>
        /// <returns>List&lt;Users&gt;.</returns>
        public List<Users> ListOfUsers()
        {
            return this.userData.UsersList();
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>Users.</returns>
        /// <exception cref="NotImplementedException">User is not found</exception>
        public Users GetUserId(string userName, string password)
        {
            var ParametersValidation = this.userData.UserNameAndPasswordVerification(userName, password);

            if (ParametersValidation)
            {
                var userPassword = this.userData.ObtainUserPassword(password);
                var userId = this.userData.ObtainUserId(userPassword);

                return userId;
            }
            else
            {
                // return false;
                throw new NotImplementedException("User is not found");
            }
        }

        /// <summary>
        /// Gets the password changed.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Users.</returns>
        /// <exception cref="Exception"></exception>
        public Users GetPasswordChanged(Users Id, string newPassword)
        {
            var passwordVerification = this.userData.UsersList();

            if (passwordVerification.Contains(this.userData.ObtainUserPassword(newPassword)))
            {
                throw new Exception();
            }
            else
            {
                var theNewPassword = this.userData.ChangePassword(Id, newPassword);

                return theNewPassword;
            }
        }
    }
}
