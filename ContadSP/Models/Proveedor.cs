using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? nombre_comercial { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public string? email { get; set; }

        public List<PedidoProveedor> PedidoProveedor { get; set; }
        public List<PresupuestoPedido> PresupuestoPedido { get; set; }

        [ForeignKey("sit_fiscal_id")]
        public int sit_fiscal_id { get; set; }
        public SitFiscal SitFiscal { get; set; }
    }
}
