using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VokabelTrainerAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sprache",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprache", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WortTyp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Typ = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WortTyp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vokabel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Wort = table.Column<string>(type: "TEXT", nullable: false),
                    Tip = table.Column<string>(type: "TEXT", nullable: false),
                    Uebersetzung = table.Column<string>(type: "TEXT", nullable: false),
                    Abschnitt = table.Column<string>(type: "TEXT", nullable: false),
                    TypId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpracheId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vokabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vokabel_Sprache_SpracheId",
                        column: x => x.SpracheId,
                        principalTable: "Sprache",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vokabel_WortTyp_TypId",
                        column: x => x.TypId,
                        principalTable: "WortTyp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vokabel_SpracheId",
                table: "Vokabel",
                column: "SpracheId");

            migrationBuilder.CreateIndex(
                name: "IX_Vokabel_TypId",
                table: "Vokabel",
                column: "TypId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vokabel");

            migrationBuilder.DropTable(
                name: "Sprache");

            migrationBuilder.DropTable(
                name: "WortTyp");
        }
    }
}
