using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class Provision
    {
        public Provision()
        {
            fecha_provision = DateOnly.FromDateTime(DateTime.Now);
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly fecha_provision { get; set; }
        public string? descripcion { get; set; }
        
        public double total_aprox { get; set; }
        public string? total_letra { get; set; }
        public List<DetalleProvision> DetalleProvision { get; set; }
        public List<Pedido> Pedido { get; set; }
        public List<ProvisionExp> ProvisionExp { get; set; }

        [ForeignKey("destino_id")]
        public int destino_id { get; set; }
        public Destino Destino { get; set; }

        [ForeignKey("usuario_id")]
        public int usuario_id { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("tipo_pedido_id")]
        public int tipo_pedido_id { get; set; }
        public TipoPedido TipoPedido { get; set; }

        [ForeignKey("estado_id")]
        public int estado_id { get; set; }
        public Estado Estado { get; set; }

    }
}
