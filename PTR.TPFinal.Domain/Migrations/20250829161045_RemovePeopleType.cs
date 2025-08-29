using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTR.TPFinal.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemovePeopleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeopleType",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PeopleType",
                table: "Clients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeopleType",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeopleType",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
