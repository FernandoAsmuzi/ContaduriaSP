using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class Proceso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? proceso { get; set; }
        public double monto_minimo { get; set; }
        public double monto_maximo { get; set; }
        public string? sigla { get; set; }
        public List<ProcesoPedido>? ProcesoPedido { get; set; }

        [ForeignKey("tipo_pedido_id")]
        public int tipo_pedido_id { get; set; }
        public TipoPedido TipoPedido { get; set; }
    }
}
