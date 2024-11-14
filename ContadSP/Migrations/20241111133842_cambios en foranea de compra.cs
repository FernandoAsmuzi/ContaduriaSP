using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class cambiosenforaneadecompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_PresupuestoPedidos_presupuesto_pedido_id",
                table: "Compra");

            migrationBuilder.RenameColumn(
                name: "presupuesto_pedido_id",
                table: "Compra",
                newName: "pedido_id");

            migrationBuilder.RenameIndex(
                name: "IX_Compra_presupuesto_pedido_id",
                table: "Compra",
                newName: "IX_Compra_pedido_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Pedido_pedido_id",
                table: "Compra",
                column: "pedido_id",
                principalTable: "Pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Pedido_pedido_id",
                table: "Compra");

            migrationBuilder.RenameColumn(
                name: "pedido_id",
                table: "Compra",
                newName: "presupuesto_pedido_id");

            migrationBuilder.RenameIndex(
                name: "IX_Compra_pedido_id",
                table: "Compra",
                newName: "IX_Compra_presupuesto_pedido_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_PresupuestoPedidos_presupuesto_pedido_id",
                table: "Compra",
                column: "presupuesto_pedido_id",
                principalTable: "PresupuestoPedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
