﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementKoszyka",
                columns: table => new
                {
                    IdElementuKoszyka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSesjiKoszyka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TowarId = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementKoszyka", x => x.IdElementuKoszyka);
                    table.ForeignKey(
                        name: "FK_ElementKoszyka_Towar_TowarId",
                        column: x => x.TowarId,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementKoszyka_TowarId",
                table: "ElementKoszyka",
                column: "TowarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementKoszyka");
        }
    }
}
