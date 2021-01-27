using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolnica_back.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdeljenjePodaci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BolnicaPodaci",
                table: "BolnicaPodaci");

            migrationBuilder.AlterColumn<string>(
                name: "IME",
                table: "BolnicaPodaci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "BolnicaPodaci",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "M",
                table: "BolnicaPodaci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N",
                table: "BolnicaPodaci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BolnicaPodaci",
                table: "BolnicaPodaci",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "OsobaPodaci",
                columns: table => new
                {
                    JMBG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREZIME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HITAN_SLUCAJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIP_OSIGURANJA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ODELJENJE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobaPodaci", x => x.JMBG);
                    table.ForeignKey(
                        name: "FK_OsobaPodaci_BolnicaPodaci_BolnicaID",
                        column: x => x.BolnicaID,
                        principalTable: "BolnicaPodaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OsobaPodaci_BolnicaID",
                table: "OsobaPodaci",
                column: "BolnicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OsobaPodaci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BolnicaPodaci",
                table: "BolnicaPodaci");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "BolnicaPodaci");

            migrationBuilder.DropColumn(
                name: "M",
                table: "BolnicaPodaci");

            migrationBuilder.DropColumn(
                name: "N",
                table: "BolnicaPodaci");

            migrationBuilder.AlterColumn<string>(
                name: "IME",
                table: "BolnicaPodaci",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BolnicaPodaci",
                table: "BolnicaPodaci",
                column: "IME");

            migrationBuilder.CreateTable(
                name: "OdeljenjePodaci",
                columns: table => new
                {
                    IME = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BolnicaIme = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BROJ_KREVETA = table.Column<int>(type: "int", nullable: false),
                    BROJ_ZAUZETIH_KREVETA = table.Column<int>(type: "int", nullable: false)
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
    }
}
