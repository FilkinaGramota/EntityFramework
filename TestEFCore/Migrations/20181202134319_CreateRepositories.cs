using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEFCore.Migrations
{
    public partial class CreateRepositories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CassetteFilms_Cassette_CassetteId",
                table: "CassetteFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderCassettes_Cassette_CassetteId",
                table: "OrderCassettes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cassette",
                table: "Cassette");

            migrationBuilder.RenameTable(
                name: "Cassette",
                newName: "Cassettes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cassettes",
                table: "Cassettes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CassetteFilms_Cassettes_CassetteId",
                table: "CassetteFilms",
                column: "CassetteId",
                principalTable: "Cassettes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCassettes_Cassettes_CassetteId",
                table: "OrderCassettes",
                column: "CassetteId",
                principalTable: "Cassettes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CassetteFilms_Cassettes_CassetteId",
                table: "CassetteFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderCassettes_Cassettes_CassetteId",
                table: "OrderCassettes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cassettes",
                table: "Cassettes");

            migrationBuilder.RenameTable(
                name: "Cassettes",
                newName: "Cassette");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cassette",
                table: "Cassette",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CassetteFilms_Cassette_CassetteId",
                table: "CassetteFilms",
                column: "CassetteId",
                principalTable: "Cassette",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCassettes_Cassette_CassetteId",
                table: "OrderCassettes",
                column: "CassetteId",
                principalTable: "Cassette",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
