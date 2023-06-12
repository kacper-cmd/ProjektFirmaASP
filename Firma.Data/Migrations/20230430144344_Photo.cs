using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoData",
                table: "Towar",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoData",
                table: "Towar");
        }
    }
}
