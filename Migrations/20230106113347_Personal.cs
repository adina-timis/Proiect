using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    public partial class Personal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Serviciu_ServiciuID",
                table: "Serviciu");

            migrationBuilder.RenameColumn(
                name: "ServiciuID",
                table: "Serviciu",
                newName: "PersonalID");

            migrationBuilder.RenameIndex(
                name: "IX_Serviciu_ServiciuID",
                table: "Serviciu",
                newName: "IX_Serviciu_PersonalID");

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Personal_PersonalID",
                table: "Serviciu",
                column: "PersonalID",
                principalTable: "Personal",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Personal_PersonalID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.RenameColumn(
                name: "PersonalID",
                table: "Serviciu",
                newName: "ServiciuID");

            migrationBuilder.RenameIndex(
                name: "IX_Serviciu_PersonalID",
                table: "Serviciu",
                newName: "IX_Serviciu_ServiciuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Serviciu_ServiciuID",
                table: "Serviciu",
                column: "ServiciuID",
                principalTable: "Serviciu",
                principalColumn: "ID");
        }
    }
}
