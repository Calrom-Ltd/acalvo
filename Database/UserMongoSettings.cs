// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-10-2021
//
// Last Modified By : senti
// Last Modified On : 03-10-2021
// ***********************************************************************
// <copyright file="UserMongoSettings.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Database
{
    /// <summary>
    /// Interface IUserMongoSettings
    /// </summary>
    public interface IUserMongoSettings
    {
        /// <summary>
        /// Gets or sets the name of the user collection.
        /// </summary>
        /// <value>The name of the user collection.</value>
        public string UserCollectionName { get; set; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the user database.
        /// </summary>
        /// <value>The name of the user database.</value>
        public string UserDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the message collection.
        /// </summary>
        /// <value>The name of the message collection.</value>
        public string MessageCollectionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the message database.
        /// </summary>
        /// <value>The name of the message database.</value>
        public string MessageDatabaseName { get; set; }
    }

    /// <summary>
    /// Class UserMongoSettings.
    /// Implements the <see cref="User_API.Database.IUserMongoSettings" />
    /// </summary>
    /// <seealso cref="User_API.Database.IUserMongoSettings" />
    public class UserMongoSettings : IUserMongoSettings
    {
        /// <summary>
        /// Gets or sets the name of the user collection.
        /// </summary>
        /// <value>The name of the user collection.</value>
        public string UserCollectionName { get; set; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the user database.
        /// </summary>
        /// <value>The name of the user database.</value>
        public string UserDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the message collection.
        /// </summary>
        /// <value>The name of the message collection.</value>
        public string MessageCollectionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the message database.
        /// </summary>
        /// <value>The name of the message database.</value>
        public string MessageDatabaseName { get; set; }
    }
}
