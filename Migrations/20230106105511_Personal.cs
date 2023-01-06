using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    public partial class Personal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Angajat",
                table: "Serviciu");

            migrationBuilder.AddColumn<int>(
                name: "ServiciuID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_ServiciuID",
                table: "Serviciu",
                column: "ServiciuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Serviciu_ServiciuID",
                table: "Serviciu",
                column: "ServiciuID",
                principalTable: "Serviciu",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Serviciu_ServiciuID",
                table: "Serviciu");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_ServiciuID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "ServiciuID",
                table: "Serviciu");

            migrationBuilder.AddColumn<string>(
                name: "Angajat",
                table: "Serviciu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
