using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class UnidadMedida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? unidad { get; set; }

        public List<DetallePedido> DetallePedido { get; set; }

        public List<DetalleProvision> DetalleProvision { get; set; }
    }
}
