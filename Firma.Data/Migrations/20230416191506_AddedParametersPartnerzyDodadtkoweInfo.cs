using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class AddedParametersPartnerzyDodadtkoweInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DodatkoweInformacje",
                columns: table => new
                {
                    IdDodatkowychInformacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodatkoweInformacje", x => x.IdDodatkowychInformacji);
                });

            migrationBuilder.CreateTable(
                name: "Parametr",
                columns: table => new
                {
                    IdParametru = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wartosc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametr", x => x.IdParametru);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    IdPartnerzy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.IdPartnerzy);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DodatkoweInformacje");

            migrationBuilder.DropTable(
                name: "Parametr");

            migrationBuilder.DropTable(
                name: "Partner");
        }
    }
}
