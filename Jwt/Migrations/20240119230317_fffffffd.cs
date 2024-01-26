using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWT.Migrations
{
    /// <inheritdoc />
    public partial class fffffffd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserAdmin");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserAdmin",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "UserAdmin",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserAdmin",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "UserAdmin",
                newName: "Fullname");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
