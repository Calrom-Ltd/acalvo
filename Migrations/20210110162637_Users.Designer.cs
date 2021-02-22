// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 02-11-2021
// ***********************************************************************
// <copyright file="20210110162637_Users.Designer.cs" company="User_API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using User_API.UserClasses;

namespace User_API.Migrations
{
    /// <summary>
    /// Class Users.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    [DbContext(typeof(UserContext))]
    [Migration("20210110162637_Users")]
    partial class Users
    {
        /// <summary>
        /// Builds the target model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("User_API.UserClasses.MessageClass", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Body")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Subject")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("userClassPassword")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MessageId");

                    b.HasIndex("userClassPassword");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("User_API.UserClasses.UserClass", b =>
                {
                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Password");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("User_API.UserClasses.MessageClass", b =>
                {
                    b.HasOne("User_API.UserClasses.UserClass", "userClass")
                        .WithMany("messageClasses")
                        .HasForeignKey("userClassPassword");

                    b.Navigation("userClass");
                });

            modelBuilder.Entity("User_API.UserClasses.UserClass", b =>
                {
                    b.Navigation("messageClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
