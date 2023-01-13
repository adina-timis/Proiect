using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    public partial class PPS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Personal_PersonalID",
                table: "Serviciu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personal",
                table: "Personal");

            migrationBuilder.RenameTable(
                name: "Personal",
                newName: "Personalul");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personalul",
                table: "Personalul",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Personalul_PersonalID",
                table: "Serviciu",
                column: "PersonalID",
                principalTable: "Personalul",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Personalul_PersonalID",
                table: "Serviciu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personalul",
                table: "Personalul");

            migrationBuilder.RenameTable(
                name: "Personalul",
                newName: "Personal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personal",
                table: "Personal",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Personal_PersonalID",
                table: "Serviciu",
                column: "PersonalID",
                principalTable: "Personal",
                principalColumn: "ID");
        }
    }
}
