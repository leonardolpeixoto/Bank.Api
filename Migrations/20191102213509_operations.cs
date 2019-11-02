using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Api.Migrations
{
    public partial class operations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "operation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    OperationType = table.Column<string>(maxLength: 200, nullable: true),
                    AccountNumber = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Rate = table.Column<decimal>(type: "money", nullable: false),
                    OperationsType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_operation_account_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "account",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_operation_AccountNumber",
                table: "operation",
                column: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operation");
        }
    }
}
