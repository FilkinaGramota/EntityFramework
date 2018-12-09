using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEFCore.Migrations
{
    public partial class ComplexTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Client",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Client",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Client",
                nullable: true);
        }
    }
}
