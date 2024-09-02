using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_history_bank_account_BankAccountId",
                table: "history");

            migrationBuilder.DropColumn(
                name: "bank_account_ownwer",
                table: "history");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "history",
                newName: "bank_account_owner");

            migrationBuilder.RenameIndex(
                name: "IX_history_BankAccountId",
                table: "history",
                newName: "IX_history_bank_account_owner");

            migrationBuilder.AlterColumn<long>(
                name: "bank_account_owner",
                table: "history",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_history_bank_account_bank_account_owner",
                table: "history",
                column: "bank_account_owner",
                principalTable: "bank_account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_history_bank_account_bank_account_owner",
                table: "history");

            migrationBuilder.RenameColumn(
                name: "bank_account_owner",
                table: "history",
                newName: "BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_history_bank_account_owner",
                table: "history",
                newName: "IX_history_BankAccountId");

            migrationBuilder.AlterColumn<long>(
                name: "BankAccountId",
                table: "history",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "bank_account_ownwer",
                table: "history",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_history_bank_account_BankAccountId",
                table: "history",
                column: "BankAccountId",
                principalTable: "bank_account",
                principalColumn: "Id");
        }
    }
}
