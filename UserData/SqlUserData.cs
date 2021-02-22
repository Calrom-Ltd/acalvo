// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="SqlUserData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
        //Create an object to access  User class 

        /// <summary>
        /// The user context.
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
        public List<Users> GetUsersList()
        {
            return this.userContext.Users.ToList();
        }

        /// <summary>
        /// Gets the information user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>List User details;.</returns>
        public List<Users> GetInfoUser(string userName)
        {
            Users userDetails = new Users();

            List<Users> usersList = new List<Users>();

            if (userName != null)
            {
                switch (userName)
                {
                    case "Robb":

                        userDetails = this.GetUserName(userName);

                        usersList.Add(userDetails);

                        return usersList;

                    case "Diana":

                        userDetails = this.GetUserName(userName);

                        usersList.Add(userDetails);

                        return usersList;

                    case "Tom":

                        userDetails = this.GetUserName(userName);

                        usersList.Add(userDetails);

                        return usersList;

                    case "Tomasa":

                        userDetails = this.GetUserName(userName);

                        usersList.Add(userDetails);

                        return usersList;

                    default:
                        return usersList;

                }
            }
            else
            {
                return this.userContext.Users.ToList();
            }
        }

        /// <summary>
        /// Gets the user password.
        /// </summary>
        /// <param name="UPassword">The u password.</param>
        /// <returns>Users.</returns>
        public Users GetUserPassword(string UPassword)
        {
            return this.userContext.Users.SingleOrDefault(x => x.Password == UPassword);
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <param name="UName">Name of the u.</param>
        /// <returns>Users.</returns>
        public Users GetUserName(string UName)
        {
            return this.userContext.Users.SingleOrDefault(x => x.UserName == UName);
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Users.</returns>
        public Users GetId(Guid id)
        {
            Users UserId = this.userContext.Users.Find(id);
            return UserId;
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>Users.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Users GetUserId(string userName, string password)
        {
            // Get UserName 
            Users obtainUserName = this.GetUserName(userName);

            // Get Password
            Users obtainPassword = this.GetUserPassword(password);

            // Passing the Password to user
            Users userId = obtainPassword;

            if (obtainPassword != null & obtainUserName != null)
            {
                Users existingUserPassword = this.userContext.Users.Find(userId.UserId);

                return existingUserPassword;
            }
            else
            {
                throw new NotImplementedException();
            }

        }

        /// <summary>
        /// Gets the password changed.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="newPassword">Creates new password.</param>
        /// <returns>Users.</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public Users GetPasswordChanged(string userName, string password, string newPassword)
        {
            Users userId;

            Users existUserName = this.GetUserName(userName);

            Users existUserPassword = this.GetUserPassword(password);

            if (this.GetUsersList().Contains(existUserPassword) & this.GetUsersList().Contains(existUserName))
            {
                userId = this.GetUserId(userName, password);

                if (this.GetUsersList().Contains(this.GetUserPassword(newPassword)) & userId.Password != null)
                {
                    throw new NotImplementedException();

                }
                else
                {
                    userId.UserId = userId.UserId;

                    userId.Password = newPassword;

                    this.userContext.Users.Update(userId);

                    this.userContext.SaveChanges();

                    return userId;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the message list.
        /// </summary>
        /// <returns>List&lt;Messages&gt;.</returns>
        public List<Messages> GetMessageList()
        {
            //return List of Messages
            return this.userContext.Messages.ToList();
        }

        /// <summary>
        /// Gets the message of user.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>List&lt;Messages&gt;.</returns>
        public List<Messages> GetMessageOfUser(string messageId)
        {
            // New List Declared
            List<Messages> StoreUserMessages = new List<Messages>();

            IQueryable<Messages> ListOfMessages = this.userContext.Messages.Where(x => x.userId.Password == messageId);

            foreach (Messages i in ListOfMessages)
            {
                StoreUserMessages.Add(i);
            }

            return StoreUserMessages;
        }

    }

}
