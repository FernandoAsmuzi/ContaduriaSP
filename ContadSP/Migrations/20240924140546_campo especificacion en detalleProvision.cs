using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class campoespecificacionendetalleProvision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CancelarProvision",
                table: "Provision",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObservacionCancela",
                table: "Provision",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "cancela_provision",
                table: "DetalleProvision",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "especificacion",
                table: "DetalleProvision",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "observa_cancelacion",
                table: "DetalleProvision",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "estado_articulo_id",
                table: "Articulo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstadoArticulo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoArticulo", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_estado_articulo_id",
                table: "Articulo",
                column: "estado_articulo_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_EstadoArticulo_estado_articulo_id",
                table: "Articulo",
                column: "estado_articulo_id",
                principalTable: "EstadoArticulo",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_EstadoArticulo_estado_articulo_id",
                table: "Articulo");

            migrationBuilder.DropTable(
                name: "EstadoArticulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_estado_articulo_id",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "CancelarProvision",
                table: "Provision");

            migrationBuilder.DropColumn(
                name: "ObservacionCancela",
                table: "Provision");

            migrationBuilder.DropColumn(
                name: "cancela_provision",
                table: "DetalleProvision");

            migrationBuilder.DropColumn(
                name: "especificacion",
                table: "DetalleProvision");

            migrationBuilder.DropColumn(
                name: "observa_cancelacion",
                table: "DetalleProvision");

            migrationBuilder.DropColumn(
                name: "estado_articulo_id",
                table: "Articulo");
        }
    }
}
