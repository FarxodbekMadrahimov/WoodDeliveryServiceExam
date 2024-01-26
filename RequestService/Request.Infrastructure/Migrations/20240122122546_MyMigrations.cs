using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MyMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_user_UserId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_UserId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "requests");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "requests");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "requests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_requests_UserId",
                table: "requests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_user_UserId",
                table: "requests",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId");
        }
    }
}
