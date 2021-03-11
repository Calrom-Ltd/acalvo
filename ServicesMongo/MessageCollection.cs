// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 03-10-2021
//
// Last Modified By : senti
// Last Modified On : 03-10-2021
// ***********************************************************************
// <copyright file="MessageCollection.cs" company="User_API">
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
    /// Class MessageCollection.
    /// </summary>
    public class MessageCollection : IMessagesCollection
    {
        /// <summary>
        /// The message collection
        /// </summary>
        private IMongoCollection<MessagesMongo> messageCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageCollection"/> class.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public MessageCollection(IUserMongoSettings setting)
        {
            var client = new MongoClient(setting.ConnectionString);

            var database = client.GetDatabase(setting.MessageDatabaseName);

            this.messageCollection = database.GetCollection<MessagesMongo>(setting.MessageCollectionName);
        }

        /// <summary>
        /// Gets all messages.
        /// </summary>
        /// <returns>List&lt;MessagesMongo&gt;.</returns>
        public async Task<List<MessagesMongo>> GetAllMessages()
        {
            return await this.messageCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>MessagesMongo.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<MessagesMongo> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public async Task InsertMessage(MessagesMongo message)
        {
            await this.messageCollection.InsertOneAsync(message);
        }

        /// <summary>
        /// Updates the message.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateMessage(MessagesMongo user)
        {
            throw new NotImplementedException();
        }
    }
}
