using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class cambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "presupuestado",
                table: "DetalleProvision");

            migrationBuilder.AlterColumn<double>(
                name: "cantidad",
                table: "PresupuestoPedidos",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "PresupuestoPedidos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<double>(
                name: "cantidad_aprobada",
                table: "DetalleProvision",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "cantidad",
                table: "DetalleProvision",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activo",
                table: "PresupuestoPedidos");

            migrationBuilder.AlterColumn<int>(
                name: "cantidad",
                table: "PresupuestoPedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<int>(
                name: "cantidad_aprobada",
                table: "DetalleProvision",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<int>(
                name: "cantidad",
                table: "DetalleProvision",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<bool>(
                name: "presupuestado",
                table: "DetalleProvision",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
