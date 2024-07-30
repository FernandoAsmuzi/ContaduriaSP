using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class Articulo
    {
        public Articulo()
        {
            fecha_ultimo_monto =  DateOnly.FromDateTime(DateTime.Now);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? descripcion { get; set; }
        public double monto_aprox { get; set; }
        public DateOnly fecha_ultimo_monto { get; set; }
        public string? foto { get; set; }

        public List<DetallePedido> DetallePedido { get; set; }
        public List<DetalleProvision> DetalleProvision { get; set; }

        [ForeignKey("categoria_id")]
        public int categoria_id { get; set; }
        public Categoria Categoria { get; set; }

    }
}
