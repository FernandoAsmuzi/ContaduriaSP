using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class PedidoProveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public bool carga { get; set; } = false;
        public List<PresupuestoPedido> PresupuestoPedido { get; set; }

        [ForeignKey("proveedor_id")]
        public int proveedor_id { get; set; }
        public Proveedor Proveedor { get; set; }

        [ForeignKey("pedido_id")]
        public int pedido_id { get; set; }
        public Pedido Pedido { get; set; }
    }
}
