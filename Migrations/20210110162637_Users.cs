using Microsoft.EntityFrameworkCore.Migrations;

namespace User_API.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_userClassPassword",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "userClassPassword",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_userClassPassword",
                table: "Messages",
                column: "userClassPassword",
                principalTable: "Users",
                principalColumn: "Password",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_userClassPassword",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
