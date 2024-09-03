﻿// <auto-generated />
using System;
using ContadSP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContadSP.Migrations
{
    [DbContext(typeof(ContadSPContext))]
    partial class ContadSPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ContadSP.Models.Articulo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("categoria_id")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("fecha_ultimo_monto")
                        .HasColumnType("date");

                    b.Property<string>("foto")
                        .HasColumnType("longtext");

                    b.Property<double>("monto_aprox")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("categoria_id");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("ContadSP.Models.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("categoria")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ContadSP.Models.Destino", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("destino")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Destino");
                });

            modelBuilder.Entity("ContadSP.Models.DetallePedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("articulo_id")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("pedido_id")
                        .HasColumnType("int");

                    b.Property<int>("unidad_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("articulo_id");

                    b.HasIndex("pedido_id");

                    b.HasIndex("unidad_id");

                    b.ToTable("DetallePedido");
                });

            modelBuilder.Entity("ContadSP.Models.DetalleProvision", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("articulo_id")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("provision_id")
                        .HasColumnType("int");

                    b.Property<double>("subtotal_aprox")
                        .HasColumnType("double");

                    b.Property<string>("subtotal_letra")
                        .HasColumnType("longtext");

                    b.Property<int>("unidad_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("articulo_id");

                    b.HasIndex("provision_id");

                    b.HasIndex("unidad_id");

                    b.ToTable("DetalleProvision");
                });

            modelBuilder.Entity("ContadSP.Models.Estado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("ContadSP.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("abreviatura")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("acta_num")
                        .HasColumnType("int");

                    b.Property<int>("anio")
                        .HasColumnType("int");

                    b.Property<DateOnly>("fecha_pedido")
                        .HasColumnType("date");

                    b.Property<int>("provision_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("provision_id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ContadSP.Models.PedidoProveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("pedido_id")
                        .HasColumnType("int");

                    b.Property<int>("proveedor_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("pedido_id");

                    b.HasIndex("proveedor_id");

                    b.ToTable("PedidoProveedor");
                });

            modelBuilder.Entity("ContadSP.Models.Proceso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("monto_maximo")
                        .HasColumnType("double");

                    b.Property<double>("monto_minimo")
                        .HasColumnType("double");

                    b.Property<string>("proceso")
                        .HasColumnType("longtext");

                    b.Property<string>("sigla")
                        .HasColumnType("longtext");

                    b.Property<int>("tipo_pedido_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tipo_pedido_id");

                    b.ToTable("Proceso");
                });

            modelBuilder.Entity("ContadSP.Models.ProcesoPedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("num_proceso")
                        .HasColumnType("int");

                    b.Property<int>("pedido_id")
                        .HasColumnType("int");

                    b.Property<string>("proceso_completo")
                        .HasColumnType("longtext");

                    b.Property<int>("proceso_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("pedido_id");

                    b.HasIndex("proceso_id");

                    b.ToTable("ProcesoPedido");
                });

            modelBuilder.Entity("ContadSP.Models.Proveedor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre_comercial")
                        .HasColumnType("longtext");

                    b.Property<int>("sit_fiscal_id")
                        .HasColumnType("int");

                    b.Property<string>("telefono")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("sit_fiscal_id");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("ContadSP.Models.Provision", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext");

                    b.Property<int>("destino_id")
                        .HasColumnType("int");

                    b.Property<int>("estado_id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("fecha_provision")
                        .HasColumnType("date");

                    b.Property<int>("tipo_pedido_id")
                        .HasColumnType("int");

                    b.Property<double>("total_aprox")
                        .HasColumnType("double");

                    b.Property<string>("total_letra")
                        .HasColumnType("longtext");

                    b.Property<int>("usuario_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("destino_id");

                    b.HasIndex("estado_id");

                    b.HasIndex("tipo_pedido_id");

                    b.HasIndex("usuario_id");

                    b.ToTable("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.ProvisionExp", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("abreviatura")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("anio")
                        .HasColumnType("int");

                    b.Property<int>("exp_num")
                        .HasColumnType("int");

                    b.Property<int>("provision_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("provision_id");

                    b.ToTable("ProvisionExp");
                });

            modelBuilder.Entity("ContadSP.Models.SitFiscal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("sit_fiscal")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("SitFiscal");
                });

            modelBuilder.Entity("ContadSP.Models.TipoPedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("tipo")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("TipoPedido");
                });

            modelBuilder.Entity("ContadSP.Models.UnidadMedida", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("unidad")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("UnidadMedida");
                });

            modelBuilder.Entity("ContadSP.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre_usuario")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<string>("rol")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ContadSP.Models.Articulo", b =>
                {
                    b.HasOne("ContadSP.Models.Categoria", "Categoria")
                        .WithMany("Articulo")
                        .HasForeignKey("categoria_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ContadSP.Models.DetallePedido", b =>
                {
                    b.HasOne("ContadSP.Models.Articulo", "Articulo")
                        .WithMany("DetallePedido")
                        .HasForeignKey("articulo_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.Pedido", "Pedido")
                        .WithMany("DetallePedido")
                        .HasForeignKey("pedido_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.UnidadMedida", "UnidadMedida")
                        .WithMany("DetallePedido")
                        .HasForeignKey("unidad_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Pedido");

                    b.Navigation("UnidadMedida");
                });

            modelBuilder.Entity("ContadSP.Models.DetalleProvision", b =>
                {
                    b.HasOne("ContadSP.Models.Articulo", "Articulo")
                        .WithMany("DetalleProvision")
                        .HasForeignKey("articulo_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.Provision", "Provision")
                        .WithMany("DetalleProvision")
                        .HasForeignKey("provision_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.UnidadMedida", "UnidadMedida")
                        .WithMany("DetalleProvision")
                        .HasForeignKey("unidad_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Provision");

                    b.Navigation("UnidadMedida");
                });

            modelBuilder.Entity("ContadSP.Models.Pedido", b =>
                {
                    b.HasOne("ContadSP.Models.Provision", "Provision")
                        .WithMany("Pedido")
                        .HasForeignKey("provision_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.PedidoProveedor", b =>
                {
                    b.HasOne("ContadSP.Models.Pedido", "Pedido")
                        .WithMany("PedidoProveedor")
                        .HasForeignKey("pedido_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.Proveedor", "Proveedor")
                        .WithMany("PedidoProveedor")
                        .HasForeignKey("proveedor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("ContadSP.Models.Proceso", b =>
                {
                    b.HasOne("ContadSP.Models.TipoPedido", "TipoPedido")
                        .WithMany("Proceso")
                        .HasForeignKey("tipo_pedido_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPedido");
                });

            modelBuilder.Entity("ContadSP.Models.ProcesoPedido", b =>
                {
                    b.HasOne("ContadSP.Models.Pedido", "Pedido")
                        .WithMany("ProcesoPedido")
                        .HasForeignKey("pedido_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.Proceso", "Proceso")
                        .WithMany("ProcesoPedido")
                        .HasForeignKey("proceso_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Proceso");
                });

            modelBuilder.Entity("ContadSP.Models.Proveedor", b =>
                {
                    b.HasOne("ContadSP.Models.SitFiscal", "SitFiscal")
                        .WithMany("Proveedor")
                        .HasForeignKey("sit_fiscal_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SitFiscal");
                });

            modelBuilder.Entity("ContadSP.Models.Provision", b =>
                {
                    b.HasOne("ContadSP.Models.Destino", "Destino")
                        .WithMany("Provision")
                        .HasForeignKey("destino_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.Estado", "Estado")
                        .WithMany("Provision")
                        .HasForeignKey("estado_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.TipoPedido", "TipoPedido")
                        .WithMany("Provision")
                        .HasForeignKey("tipo_pedido_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.Usuario", "Usuario")
                        .WithMany("Provision")
                        .HasForeignKey("usuario_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Estado");

                    b.Navigation("TipoPedido");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ContadSP.Models.ProvisionExp", b =>
                {
                    b.HasOne("ContadSP.Models.Provision", "Provision")
                        .WithMany("ProvisionExp")
                        .HasForeignKey("provision_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.Articulo", b =>
                {
                    b.Navigation("DetallePedido");

                    b.Navigation("DetalleProvision");
                });

            modelBuilder.Entity("ContadSP.Models.Categoria", b =>
                {
                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("ContadSP.Models.Destino", b =>
                {
                    b.Navigation("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.Estado", b =>
                {
                    b.Navigation("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.Pedido", b =>
                {
                    b.Navigation("DetallePedido");

                    b.Navigation("PedidoProveedor");

                    b.Navigation("ProcesoPedido");
                });

            modelBuilder.Entity("ContadSP.Models.Proceso", b =>
                {
                    b.Navigation("ProcesoPedido");
                });

            modelBuilder.Entity("ContadSP.Models.Proveedor", b =>
                {
                    b.Navigation("PedidoProveedor");
                });

            modelBuilder.Entity("ContadSP.Models.Provision", b =>
                {
                    b.Navigation("DetalleProvision");

                    b.Navigation("Pedido");

                    b.Navigation("ProvisionExp");
                });

            modelBuilder.Entity("ContadSP.Models.SitFiscal", b =>
                {
                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("ContadSP.Models.TipoPedido", b =>
                {
                    b.Navigation("Proceso");

                    b.Navigation("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.UnidadMedida", b =>
                {
                    b.Navigation("DetallePedido");

                    b.Navigation("DetalleProvision");
                });

            modelBuilder.Entity("ContadSP.Models.Usuario", b =>
                {
                    b.Navigation("Provision");
                });
#pragma warning restore 612, 618
        }
    }
}
