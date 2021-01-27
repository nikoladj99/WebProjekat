using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolnica_back.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BROJ_KREVETA",
                table: "OsobaPodaci",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BROJ_KREVETA",
                table: "OsobaPodaci");
        }
    }
}
