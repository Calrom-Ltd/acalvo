// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 02-15-2021
// ***********************************************************************
// <copyright file="Messages.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace User_API.UserClasses
{
    /// <summary>
    /// Class Messages.
    /// </summary>
    public class Messages
    {

        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>The message identifier.</value>
        [Key]
        public int MessageId { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        [MaxLength(50, ErrorMessage = "Only admit 50 characters")]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [MaxLength(300, ErrorMessage = "Body cannot be over 300 characters")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the message date.
        /// </summary>
        /// <value>The message date.</value>
        [Required]
        public DateTime MessageDate { get; set; }


        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [JsonIgnore]//ForeignKey
        public Users userId { get; set; }


    }
}
