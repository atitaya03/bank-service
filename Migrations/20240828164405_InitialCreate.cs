using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bank_accounts_user_UserId",
                table: "bank_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_history_bank_accounts_BankAccountOwnerId",
                table: "history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bank_accounts",
                table: "bank_accounts");

            migrationBuilder.RenameTable(
                name: "bank_accounts",
                newName: "bank_account");

            migrationBuilder.RenameColumn(
                name: "BankAccountTargetId",
                table: "history",
                newName: "baank_account_target");

            migrationBuilder.RenameIndex(
                name: "IX_bank_accounts_UserId",
                table: "bank_account",
                newName: "IX_bank_account_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bank_account",
                table: "bank_account",
                column: "BankAccountId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bank_account_user_UserId",
                table: "bank_account");

            migrationBuilder.DropForeignKey(
                name: "FK_history_bank_account_BankAccountOwnerId",
                table: "history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bank_account",
                table: "bank_account");

            migrationBuilder.RenameTable(
                name: "bank_account",
                newName: "bank_accounts");

            migrationBuilder.RenameColumn(
                name: "baank_account_target",
                table: "history",
                newName: "BankAccountTargetId");

            migrationBuilder.RenameIndex(
                name: "IX_bank_account_UserId",
                table: "bank_accounts",
                newName: "IX_bank_accounts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bank_accounts",
                table: "bank_accounts",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_bank_accounts_user_UserId",
                table: "bank_accounts",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_history_bank_accounts_BankAccountOwnerId",
                table: "history",
                column: "BankAccountOwnerId",
                principalTable: "bank_accounts",
                principalColumn: "BankAccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
