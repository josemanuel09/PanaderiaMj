using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanaderiaMj.Migrations
{
    /// <inheritdoc />
    public partial class Mejora2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Recepciones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Recepciones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Recepciones");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Recepciones");
        }
    }
}
