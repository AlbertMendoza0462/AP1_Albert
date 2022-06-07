using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AportesBlazor.Migrations
{
    public partial class InitialCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aportes",
                columns: table => new
                {
                    AporteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Persona = table.Column<string>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aportes", x => x.AporteID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aportes");
        }
    }
}
