using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolnica_back.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDLEKARA",
                table: "OsobaPodaci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LekarPodaci",
                columns: table => new
                {
                    IDLekara = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREZIME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SPECIJALIZACIJA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LekarPodaci", x => x.IDLekara);
                    table.ForeignKey(
                        name: "FK_LekarPodaci_BolnicaPodaci_BolnicaID",
                        column: x => x.BolnicaID,
                        principalTable: "BolnicaPodaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LekarPodaci_BolnicaID",
                table: "LekarPodaci",
                column: "BolnicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LekarPodaci");

            migrationBuilder.DropColumn(
                name: "IDLEKARA",
                table: "OsobaPodaci");
        }
    }
}
