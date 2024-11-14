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
        public string abreviatura { get; set; } = "ACT";
        public int acta_num { get; set; }
        public int anio { get; set; } = DateTime.Now.Year;
        public DateOnly fecha_pedido { get; set; }
        public List<PedidoProveedor> PedidoProveedor { get; set; }
        public List<ProcesoPedido> ProcesoPedido { get; set; }
        public List<PresupuestoPedido> PresupuestoPedido { get; set; }
        public List<Compra> Compra { get; set; }

        [ForeignKey("provision_id")]
        public int provision_id { get; set; }
        public Provision Provision { get; set; }

    }
}
