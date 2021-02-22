// ***********************************************************************
// Assembly         : User_API
// Author           : senti
// Created          : 02-11-2021
//
// Last Modified By : senti
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="20210110125728_Messages.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore.Migrations;

namespace User_API.Migrations
{
    /// <summary>
    /// Class Messages.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    public partial class Messages : Migration
    {
        /// <inheritdoc/>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_userClassPassword",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "PasswordId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "userClassPassword",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_userClassPassword",
                table: "Messages",
                column: "userClassPassword",
                principalTable: "Users",
                principalColumn: "Password",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc/>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_userClassPassword",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "userClassPassword",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PasswordId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_userClassPassword",
                table: "Messages",
                column: "userClassPassword",
                principalTable: "Users",
                principalColumn: "Password",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
