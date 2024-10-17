using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    categoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    destino = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "SitFiscal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    sit_fiscal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitFiscal", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoPedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPedido", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    unidad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_usuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rol = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    monto_aprox = table.Column<double>(type: "double", nullable: false),
                    fecha_ultimo_monto = table.Column<DateOnly>(type: "date", nullable: false),
                    foto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    categoria_id = table.Column<int>(type: "int", nullable: false),
                    estado_articulo_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Articulo_Categoria_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulo_EstadoArticulo_estado_articulo_id",
                        column: x => x.estado_articulo_id,
                        principalTable: "EstadoArticulo",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre_comercial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cuit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ingresos_brutos = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sit_fiscal_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proveedor_SitFiscal_sit_fiscal_id",
                        column: x => x.sit_fiscal_id,
                        principalTable: "SitFiscal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proceso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    proceso = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    monto_minimo = table.Column<double>(type: "double", nullable: false),
                    monto_maximo = table.Column<double>(type: "double", nullable: false),
                    sigla = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo_pedido_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proceso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proceso_TipoPedido_tipo_pedido_id",
                        column: x => x.tipo_pedido_id,
                        principalTable: "TipoPedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Provision",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha_provision = table.Column<DateOnly>(type: "date", nullable: false),
                    descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total_aprox = table.Column<double>(type: "double", nullable: false),
                    total_letra = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    destino_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    tipo_pedido_id = table.Column<int>(type: "int", nullable: false),
                    estado_id = table.Column<int>(type: "int", nullable: false),
                    CancelarProvision = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ObservacionCancela = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provision", x => x.id);
                    table.ForeignKey(
                        name: "FK_Provision_Destino_destino_id",
                        column: x => x.destino_id,
                        principalTable: "Destino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provision_Estado_estado_id",
                        column: x => x.estado_id,
                        principalTable: "Estado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provision_TipoPedido_tipo_pedido_id",
                        column: x => x.tipo_pedido_id,
                        principalTable: "TipoPedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provision_Usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleProvision",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    subtotal_aprox = table.Column<double>(type: "double", nullable: false),
                    subtotal_letra = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especificacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    presupuestado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    articulo_id = table.Column<int>(type: "int", nullable: false),
                    unidad_id = table.Column<int>(type: "int", nullable: false),
                    provision_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProvision", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetalleProvision_Articulo_articulo_id",
                        column: x => x.articulo_id,
                        principalTable: "Articulo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleProvision_Provision_provision_id",
                        column: x => x.provision_id,
                        principalTable: "Provision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleProvision_UnidadMedida_unidad_id",
                        column: x => x.unidad_id,
                        principalTable: "UnidadMedida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    abreviatura = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    acta_num = table.Column<int>(type: "int", nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false),
                    fecha_pedido = table.Column<DateOnly>(type: "date", nullable: false),
                    provision_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Provision_provision_id",
                        column: x => x.provision_id,
                        principalTable: "Provision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProvisionExp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    exp_num = table.Column<int>(type: "int", nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false),
                    abreviatura = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    provision_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvisionExp", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProvisionExp_Provision_provision_id",
                        column: x => x.provision_id,
                        principalTable: "Provision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidoProveedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    carga = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    proveedor_id = table.Column<int>(type: "int", nullable: false),
                    pedido_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProveedor", x => x.id);
                    table.ForeignKey(
                        name: "FK_PedidoProveedor_Pedido_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProveedor_Proveedor_proveedor_id",
                        column: x => x.proveedor_id,
                        principalTable: "Proveedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcesoPedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    num_proceso = table.Column<int>(type: "int", nullable: false),
                    proceso_completo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    anio = table.Column<int>(type: "int", nullable: false),
                    proceso_id = table.Column<int>(type: "int", nullable: false),
                    pedido_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcesoPedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProcesoPedido_Pedido_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcesoPedido_Proceso_proceso_id",
                        column: x => x.proceso_id,
                        principalTable: "Proceso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PresupuestoPedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    precio_unitario = table.Column<double>(type: "double", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    subtotal = table.Column<double>(type: "double", nullable: false),
                    subtotal_letra = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especificacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_presupuesto = table.Column<DateOnly>(type: "date", nullable: false),
                    detalle_provision_id = table.Column<int>(type: "int", nullable: false),
                    pedido_proveedor_id = table.Column<int>(type: "int", nullable: false),
                    proveedor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresupuestoPedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_PresupuestoPedidos_DetalleProvision_detalle_provision_id",
                        column: x => x.detalle_provision_id,
                        principalTable: "DetalleProvision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresupuestoPedidos_PedidoProveedor_pedido_proveedor_id",
                        column: x => x.pedido_proveedor_id,
                        principalTable: "PedidoProveedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresupuestoPedidos_Proveedor_proveedor_id",
                        column: x => x.proveedor_id,
                        principalTable: "Proveedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_categoria_id",
                table: "Articulo",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_estado_articulo_id",
                table: "Articulo",
                column: "estado_articulo_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProvision_articulo_id",
                table: "DetalleProvision",
                column: "articulo_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProvision_provision_id",
                table: "DetalleProvision",
                column: "provision_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProvision_unidad_id",
                table: "DetalleProvision",
                column: "unidad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_provision_id",
                table: "Pedido",
                column: "provision_id");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProveedor_pedido_id",
                table: "PedidoProveedor",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProveedor_proveedor_id",
                table: "PedidoProveedor",
                column: "proveedor_id");

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestoPedidos_detalle_provision_id",
                table: "PresupuestoPedidos",
                column: "detalle_provision_id");

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestoPedidos_pedido_proveedor_id",
                table: "PresupuestoPedidos",
                column: "pedido_proveedor_id");

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestoPedidos_proveedor_id",
                table: "PresupuestoPedidos",
                column: "proveedor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Proceso_tipo_pedido_id",
                table: "Proceso",
                column: "tipo_pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProcesoPedido_pedido_id",
                table: "ProcesoPedido",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProcesoPedido_proceso_id",
                table: "ProcesoPedido",
                column: "proceso_id");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_sit_fiscal_id",
                table: "Proveedor",
                column: "sit_fiscal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Provision_destino_id",
                table: "Provision",
                column: "destino_id");

            migrationBuilder.CreateIndex(
                name: "IX_Provision_estado_id",
                table: "Provision",
                column: "estado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Provision_tipo_pedido_id",
                table: "Provision",
                column: "tipo_pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_Provision_usuario_id",
                table: "Provision",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProvisionExp_provision_id",
                table: "ProvisionExp",
                column: "provision_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresupuestoPedidos");

            migrationBuilder.DropTable(
                name: "ProcesoPedido");

            migrationBuilder.DropTable(
                name: "ProvisionExp");

            migrationBuilder.DropTable(
                name: "DetalleProvision");

            migrationBuilder.DropTable(
                name: "PedidoProveedor");

            migrationBuilder.DropTable(
                name: "Proceso");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "EstadoArticulo");

            migrationBuilder.DropTable(
                name: "Provision");

            migrationBuilder.DropTable(
                name: "SitFiscal");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "TipoPedido");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
