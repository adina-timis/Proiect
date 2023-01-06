using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    public partial class Marca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeMarca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_MarcaID",
                table: "Serviciu",
                column: "MarcaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Marca_MarcaID",
                table: "Serviciu",
                column: "MarcaID",
                principalTable: "Marca",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Marca_MarcaID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_MarcaID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "MarcaID",
                table: "Serviciu");
        }
    }
}
