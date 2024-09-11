using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContadSP.Models
{
    public class DetalleProvision
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int cantidad { get; set; }
        public double subtotal_aprox { get; set; }
        public string? subtotal_letra { get; set; }
        public List<PresupuestoPedido> PresupuestoPedido { get; set; }

        [ForeignKey("id_articulo")]
        public int articulo_id { get; set; }
        public Articulo Articulo { get; set; }

        [ForeignKey("id_unidad")]
        public int unidad_id { get; set; }
        public UnidadMedida UnidadMedida { get; set; }

        [ForeignKey("id_provision")]
        public int provision_id { get; set; }
        public Provision Provision { get; set; }
    }
}
