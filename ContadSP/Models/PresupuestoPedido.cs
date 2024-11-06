using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContadSP.Models
{
    public class PresupuestoPedido
    {
        public PresupuestoPedido()
        {
            fecha_presupuesto = DateOnly.FromDateTime(DateTime.Now);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public double precio_unitario { get; set; }
        public int cantidad { get; set; }
        public double subtotal { get; set; }
        public string? subtotal_letra { get; set; }
        public string? especificacion { get; set; }
        public DateOnly fecha_presupuesto { get; set; }
        public bool seleccion { get; set; } = false;
        public List<Compra> Compra { get; set; }

        [ForeignKey("detalle_provision_id")]
        public int detalle_provision_id { get; set; }
        public DetalleProvision DetalleProvision { get; set; }

        [ForeignKey("pedido_proveedor_id")]
        public int pedido_proveedor_id { get; set; }
        public PedidoProveedor PedidoProveedor { get; set; }

        [ForeignKey("proveedor_id")]
        public int proveedor_id { get; set; }
        public Proveedor Proveedor { get; set; }

        [ForeignKey("pedido_id")]
        public int pedido_id { get; set; }
        public Pedido Pedido { get; set; }


    }
}
