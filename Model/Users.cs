// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="Users.cs" company="PlaceholderCompany">
//     Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace User_API.UserClasses
{
    /// <summary>
    /// Class Users.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [Key]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        [MaxLength(50, ErrorMessage = "Name can be only 50 characters Long!")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [Required]
        [MaxLength(50, ErrorMessage = "Name can be only 50 characters Long!")]
        public string UserName { get; set; }

        /// <summary>
        /// Create relationShip (oneToMany).
        /// </summary>
        /// <value>The message identifier.</value>
        public ICollection<Messages> messageId { get; set; }
    }
}
