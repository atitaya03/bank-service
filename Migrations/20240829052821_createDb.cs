using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HistoryId",
                table: "history",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "bank_account",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "history",
                newName: "HistoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "bank_account",
                newName: "BankAccountId");
        }
    }
}
