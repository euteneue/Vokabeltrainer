using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VokabelTrainerAPI.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WortTyp_Typ",
                table: "WortTyp",
                column: "Typ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sprache_Name",
                table: "Sprache",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WortTyp_Typ",
                table: "WortTyp");

            migrationBuilder.DropIndex(
                name: "IX_Sprache_Name",
                table: "Sprache");
        }
    }
}
