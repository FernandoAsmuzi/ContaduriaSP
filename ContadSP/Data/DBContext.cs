using ContadSP.Models;
using Microsoft.EntityFrameworkCore;

namespace ContadSP.Data
{
    public class ContadSPContext : DbContext
    {
        public ContadSPContext(DbContextOptions<ContadSPContext> options)
            : base(options)
        {
        }

        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<DetalleProvision> DetalleProvision { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoProveedor> PedidoProveedor { get; set; }
        public DbSet<PresupuestoPedido> PresupuestoPedidos { get; set; }
        public DbSet<Proceso> Proceso { get; set; }
        public DbSet<ProcesoPedido> ProcesoPedido { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Provision> Provision { get; set; }
        public DbSet<ProvisionExp> ProvisionExp { get; set; }
        public DbSet<SitFiscal> SitFiscal { get; set; }
        public DbSet<TipoPedido> TipoPedido { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<EstadoArticulo> EstadoArticulo { get; set; } // Añadir DbSet para EstadoArticulo

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relaciones de Articulo con Categoria
            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.Categoria)
                .WithMany(c => c.Articulo)
                .HasForeignKey(a => a.categoria_id);

            // Relación de Articulo con EstadoArticulo
            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.EstadoArticulo)
                .WithMany(e => e.Articulos)
                .HasForeignKey(a => a.estado_articulo_id);

            // Relaciones de Provision con Destino, TipoPedido y Usuario
            modelBuilder.Entity<Provision>()
                .HasOne(p => p.Destino)
                .WithMany(d => d.Provision)
                .HasForeignKey(p => p.destino_id);
            modelBuilder.Entity<Provision>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Provision)
                .HasForeignKey(p => p.usuario_id);
            modelBuilder.Entity<Provision>()
                .HasOne(p => p.TipoPedido)
                .WithMany(t => t.Provision)
                .HasForeignKey(p => p.tipo_pedido_id);
            modelBuilder.Entity<Provision>()
                .HasOne(p => p.Estado)
                .WithMany(e => e.Provision)
                .HasForeignKey(p => p.estado_id);
            // Relaciones de Proceso con TipoPedido
            modelBuilder.Entity<Proceso>()
                .HasOne(p => p.TipoPedido)
                .WithMany(t => t.Proceso)
                .HasForeignKey(p => p.tipo_pedido_id);
            // Relaciones de DetalleProvision con Articulo, Proceso y UnidadMedida y Provision
            modelBuilder.Entity<DetalleProvision>()
                .HasOne(d => d.Articulo)
                .WithMany(a => a.DetalleProvision)
                .HasForeignKey(d => d.articulo_id);
            modelBuilder.Entity<DetalleProvision>()
                .HasOne(d => d.UnidadMedida)
                .WithMany(u => u.DetalleProvision)
                .HasForeignKey(d => d.unidad_id);
            modelBuilder.Entity<DetalleProvision>()
                .HasOne(d => d.Provision)
                .WithMany(p => p.DetalleProvision)
                .HasForeignKey(d => d.provision_id);
            // Relacion de Proveedor con SitFiscal
            modelBuilder.Entity<Proveedor>()
                .HasOne(s => s.SitFiscal)
                .WithMany(p => p.Proveedor)
                .HasForeignKey(s => s.sit_fiscal_id);
            // Relacion de Pedido con Provision y ProcesoPedido
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Provision)
                .WithMany(pv => pv.Pedido)
                .HasForeignKey(p => p.provision_id);
            // Relacion de ProcesoPedido con Proceso y Pedido
            modelBuilder.Entity<ProcesoPedido>()
                .HasOne(pp => pp.Proceso)
                .WithMany(p => p.ProcesoPedido)
                .HasForeignKey(pp => pp.proceso_id);
            modelBuilder.Entity<ProcesoPedido>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.ProcesoPedido)
                .HasForeignKey(pp => pp.pedido_id);
            // Relacion de PedidoProveedor con Proveedor y Provision
            modelBuilder.Entity<PedidoProveedor>()
                .HasOne(pp => pp.Proveedor)
                .WithMany(p => p.PedidoProveedor)
                .HasForeignKey(pp => pp.proveedor_id);
            modelBuilder.Entity<PedidoProveedor>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidoProveedor)
                .HasForeignKey(pp => pp.pedido_id);
            // Relacion de ProvisionExp con Provision
            modelBuilder.Entity<ProvisionExp>()
                .HasOne(pe => pe.Provision)
                .WithMany(p => p.ProvisionExp)
                .HasForeignKey(pe => pe.provision_id);
            // Relacion de PresupuestoPedido con DetalleProvision, Pedido y proveedor
            modelBuilder.Entity<PresupuestoPedido>()
                .HasOne(pp => pp.DetalleProvision)
                .WithMany(dp => dp.PresupuestoPedido)
                .HasForeignKey(pp => pp.detalle_provision_id);
            modelBuilder.Entity<PresupuestoPedido>()
                .HasOne(pp => pp.PedidoProveedor)
                .WithMany(p => p.PresupuestoPedido)
                .HasForeignKey(pp => pp.pedido_proveedor_id);
            modelBuilder.Entity<PresupuestoPedido>()
                .HasOne(pp => pp.Proveedor)
                .WithMany(p => p.PresupuestoPedido)
                .HasForeignKey(pp => pp.proveedor_id);
            modelBuilder.Entity<PresupuestoPedido>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PresupuestoPedido)
                .HasForeignKey(pp => pp.pedido_id);
            //Relacion de Compra con PresupuestoPedido
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Pedido)
                .WithMany(pp => pp.Compra)
                .HasForeignKey(c => c.pedido_id);
            // Relacion de Pago con Compra
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Compra)
                .WithMany(c => c.Pago)
                .HasForeignKey(p => p.compra_id);
        }
    }
}

