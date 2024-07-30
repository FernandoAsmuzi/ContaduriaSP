using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class Pedido
    {
        public Pedido()
        {
            fecha_pedido = DateOnly.FromDateTime(DateTime.Now);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? numero_acta { get; set; }
        public DateOnly fecha_pedido { get; set; }
        public bool estado { get; set; }
        public List<DetallePedido> DetallePedido { get; set; }
        public List<PedidoProveedor> PedidoProveedor { get; set; }

        [ForeignKey("provision_id")]
        public int provision_id { get; set; }
        public Provision Provision { get; set; }

    }
}
