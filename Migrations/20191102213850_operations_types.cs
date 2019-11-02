using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Api.Migrations
{
    public partial class operations_types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationsType",
                table: "operation");

            migrationBuilder.AlterColumn<string>(
                name: "OperationType",
                table: "operation",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OperationType",
                table: "operation",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "OperationsType",
                table: "operation",
                nullable: false,
                defaultValue: "");
        }
    }
}
