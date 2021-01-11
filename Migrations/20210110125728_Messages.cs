using Microsoft.EntityFrameworkCore.Migrations;

namespace User_API.Migrations
{
    public partial class Messages : Migration
    {
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
