using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Api.Migrations
{
    public partial class operations_transfer_deposit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operation_account_AccountToAccountNumber",
                table: "operation");

            migrationBuilder.DropIndex(
                name: "IX_operation_AccountToAccountNumber",
                table: "operation");

            migrationBuilder.DropColumn(
                name: "AccountNumberTo",
                table: "operation");

            migrationBuilder.DropColumn(
                name: "AccountToAccountNumber",
                table: "operation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountNumberTo",
                table: "operation",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AccountToAccountNumber",
                table: "operation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_operation_AccountToAccountNumber",
                table: "operation",
                column: "AccountToAccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_operation_account_AccountToAccountNumber",
                table: "operation",
                column: "AccountToAccountNumber",
                principalTable: "account",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
