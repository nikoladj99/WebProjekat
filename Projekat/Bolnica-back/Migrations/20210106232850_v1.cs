using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolnica_back.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BolnicaPodaci",
                columns: table => new
                {
                    IME = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolnicaPodaci", x => x.IME);
                });

            migrationBuilder.CreateTable(
                name: "OdeljenjePodaci",
                columns: table => new
                {
                    IME = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BROJ_KREVETA = table.Column<int>(type: "int", nullable: false),
                    BROJ_ZAUZETIH_KREVETA = table.Column<int>(type: "int", nullable: false),
                    BolnicaIme = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdeljenjePodaci", x => x.IME);
                    table.ForeignKey(
                        name: "FK_OdeljenjePodaci_BolnicaPodaci_BolnicaIme",
                        column: x => x.BolnicaIme,
                        principalTable: "BolnicaPodaci",
                        principalColumn: "IME",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdeljenjePodaci_BolnicaIme",
                table: "OdeljenjePodaci",
                column: "BolnicaIme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdeljenjePodaci");

            migrationBuilder.DropTable(
                name: "BolnicaPodaci");
        }
    }
}
