// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 02-12-2021
// ***********************************************************************
// <copyright file="UserContextModelSnapshot.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using User_API.UserClasses;

namespace User_API.Migrations
{
    /// <summary>
    /// Class UserContextModelSnapshot.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />
    [DbContext(typeof(UserContext))]
    internal partial class UserContextModelSnapshot : ModelSnapshot
    {
        /// <summary>
        /// Builds the model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("User_API.UserClasses.Messages", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Body")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("User_API.UserClasses.Users", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("User_API.UserClasses.Messages", b =>
                {
                    b.HasOne("User_API.UserClasses.Users", "userId")
                        .WithMany("messageId")
                        .HasForeignKey("UserId");

                    b.Navigation("userId");
                });

            modelBuilder.Entity("User_API.UserClasses.Users", b =>
                {
                    b.Navigation("messageId");
                });
        }
    }
}
