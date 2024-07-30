using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class DetallePedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int cantidad { get; set; }

        [ForeignKey("id_articulo")]
        public int articulo_id { get; set; }
        public Articulo Articulo { get; set; }

        [ForeignKey("id_pedido")]
        public int pedido_id { get; set; }
        public Pedido Pedido { get; set; }

        [ForeignKey("id_unidad")]
        public int unidad_id { get; set; }
        public UnidadMedida UnidadMedida { get; set; }
    }
}
