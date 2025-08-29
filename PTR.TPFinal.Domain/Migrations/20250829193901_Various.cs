using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTR.TPFinal.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Various : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShoppingsCart_ClientId",
                table: "ShoppingsCart",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingsCart_EmployeeId",
                table: "ShoppingsCart",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingsCart_Clients_ClientId",
                table: "ShoppingsCart",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingsCart_Employees_EmployeeId",
                table: "ShoppingsCart",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingsCart_Clients_ClientId",
                table: "ShoppingsCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingsCart_Employees_EmployeeId",
                table: "ShoppingsCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingsCart_ClientId",
                table: "ShoppingsCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingsCart_EmployeeId",
                table: "ShoppingsCart");
        }
    }
}
