using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanaderiaMj.Migrations
{
    /// <inheritdoc />
    public partial class Mejora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Empleados",
                newName: "FechaIngreso");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Empleados",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "FechaIngreso",
                table: "Empleados",
                newName: "FechaNacimiento");
        }
    }
}
