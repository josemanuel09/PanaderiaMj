using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanaderiaMj.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_Campos_a_modelo_de_insumos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Insumos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Insumos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Insumos");
        }
    }
}
