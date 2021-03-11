// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-10-2021
//
// Last Modified By : senti
// Last Modified On : 03-10-2021
// ***********************************************************************
// <copyright file="UserCollection.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Database;
using User_API.Model;

namespace User_API.ServicesMongo
{
    /// <summary>
    /// Class UserCollection.
    /// </summary>
    public class UserCollection : IUserCollection
    {
        /// <summary>
        /// The user collection
        /// </summary>
        private IMongoCollection<UsersMongo> userCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCollection" /> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public UserCollection(IUserMongoSettings settings)
        {
            // Passing the connection string
            var client = new MongoClient(settings.ConnectionString);

            // Passing the database name
            var database = client.GetDatabase(settings.UserDatabaseName);

            // Passing the name collection
            this.userCollection = database.GetCollection<UsersMongo>(settings.UserCollectionName);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public async Task DeleteUser(string Id)
        {
            var filter = Builders<UsersMongo>.Filter.Eq(x => x.Id, new ObjectId(Id));

            await this.userCollection.DeleteOneAsync(filter);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>List&lt;UsersMongo&gt;.</returns>
        public async Task<List<UsersMongo>> GetAllUsers()
        {
            return await this.userCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>UsersMongo.</returns>
        public async Task<UsersMongo> GetUserById(string Id)
        {
            return await this.userCollection.FindAsync(
                new BsonDocument { { "UserId", new ObjectId(Id) } }).Result.FirstAsync();
        }

        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task.</returns>
        public async Task InsertUser(UsersMongo user)
        {
            await this.userCollection.InsertOneAsync(user);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task.</returns>
        public async Task UpdateUser(UsersMongo user)
        {
            var filter = Builders<UsersMongo>.Filter.Eq(x => x.Id, user.Id);
            await this.userCollection.ReplaceOneAsync(filter, user);
        }

        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        //public async Task<bool> LogIn(string password, string userName)
        //{
        //    var filterUserName = this.userCollection.FindAsync(new BsonDocument()).Result.ToListAsync().Equals(userName);
        //    var filterPassword = this.userCollection.FindAsync(new BsonDocument()).Result.ToListAsync().Equals(password);

        //    if ((await filterPassword.Equals(password) && filterUserName.Equals(userName)))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
