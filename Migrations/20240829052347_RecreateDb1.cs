using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bank_account_user_UserId",
                table: "bank_account");

            migrationBuilder.DropForeignKey(
                name: "FK_history_bank_account_BankAccountOwnerId",
                table: "history");

            migrationBuilder.DropIndex(
                name: "IX_history_BankAccountOwnerId",
                table: "history");

            migrationBuilder.RenameColumn(
                name: "baank_account_target",
                table: "history",
                newName: "bank_account_target");

            migrationBuilder.RenameColumn(
                name: "BankAccountOwnerId",
                table: "history",
                newName: "bank_account_ownwer");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "bank_account",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_bank_account_UserId",
                table: "bank_account",
                newName: "IX_bank_account_user_id");

            migrationBuilder.AddColumn<long>(
                name: "BankAccountId",
                table: "history",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_history_BankAccountId",
                table: "history",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_bank_account_user_user_id",
                table: "bank_account",
                column: "user_id",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_history_bank_account_BankAccountId",
                table: "history",
                column: "BankAccountId",
                principalTable: "bank_account",
                principalColumn: "BankAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bank_account_user_user_id",
                table: "bank_account");

            migrationBuilder.DropForeignKey(
                name: "FK_history_bank_account_BankAccountId",
                table: "history");

            migrationBuilder.DropIndex(
                name: "IX_history_BankAccountId",
                table: "history");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "history");

            migrationBuilder.RenameColumn(
                name: "bank_account_target",
                table: "history",
                newName: "baank_account_target");

            migrationBuilder.RenameColumn(
                name: "bank_account_ownwer",
                table: "history",
                newName: "BankAccountOwnerId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "bank_account",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bank_account_user_id",
                table: "bank_account",
                newName: "IX_bank_account_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_history_BankAccountOwnerId",
                table: "history",
                column: "BankAccountOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_bank_account_user_UserId",
                table: "bank_account",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_history_bank_account_BankAccountOwnerId",
                table: "history",
                column: "BankAccountOwnerId",
                principalTable: "bank_account",
                principalColumn: "BankAccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
