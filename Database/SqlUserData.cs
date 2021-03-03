// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 03-03-2021
// ***********************************************************************
// <copyright file="SqlUserData.cs" company="PlaceholderCompany">
//     Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using User_API.UserClasses;

namespace User_API.UserData
{
    /// <summary>
    /// Class SqlUserData.
    /// Implements the <see cref="User_API.UserData.IUserData" />.
    /// </summary>
    /// <seealso cref="User_API.UserData.IUserData" />
    public class SqlUserData : IUserData
    {
        /// <summary>
        /// The user context
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlUserData"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public SqlUserData(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Gets the users list.
        /// </summary>
        /// <returns>List&lt;Users&gt;.</returns>
        public List<Users> UsersList()
        {
            return this.userContext.Users.ToList();
        }

        /// <summary>
        /// Obtains the name of the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>Users.</returns>
        public Users ObtainUserName(string userName)
        {
            return this.userContext.Users.SingleOrDefault(x => x.UserName == userName);
        }

        /// <summary>
        /// Gets the user password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>Users.</returns>
        public Users ObtainUserPassword(string password)
        {
            return this.userContext.Users.SingleOrDefault(x => x.Password == password);
        }

        /// <summary>
        /// Obtains the user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Users.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Users ObtainUserId(Users userId)
        {
            if (userId.Password != null)
            {
                Users Id = this.userContext.Users.Find(userId.UserId);
                return Id;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Users the name and password verification.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UserNameAndPasswordVerification(string userName, string password)
        {
            Users nameVerification = this.userContext.Users.SingleOrDefault(x => x.UserName == userName);
            Users passwordVerification = this.userContext.Users.SingleOrDefault(x => x.Password == password);

            if (this.userContext.Users.ToList().Contains(nameVerification) & this.userContext.Users.ToList().Contains(passwordVerification))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the password changed.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="newPassword">Creates new password.</param>
        /// <returns>Users.</returns>
        public Users ChangePassword(Users Id, string newPassword)
        {
            Id.Password = newPassword;

            this.userContext.Users.Update(Id);

            this.userContext.SaveChanges();

            return Id;
        }

        /// <summary>
        /// Messageses the list.
        /// </summary>
        /// <returns>List&lt;Messages&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Messages> MessagesList()
        {
            return this.userContext.Messages.ToList();
        }

        /// <summary>
        /// Gets the message of user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>List&lt;Messages&gt;.</returns>
        public List<Messages> MessageOfUser(Users userId)
        {
            // New List Declared
            List<Messages> storeUserMessages = new List<Messages>();

            IQueryable<Messages> listOfMessages = this.userContext.Messages.Where(x => x.userId.UserId == userId.UserId);

            foreach (Messages i in listOfMessages)
            {
                storeUserMessages.Add(i);
            }

            return storeUserMessages;
        }

    }

}
