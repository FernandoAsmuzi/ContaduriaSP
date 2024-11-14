using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContadSP.Models
{
    public class Compra
    {
        public Compra()
        {
            fecha_pre_compra = DateOnly.FromDateTime(DateTime.Now);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly fecha_pre_compra { get; set; }
        public DateOnly fecha_compra { get; set; }
        public bool finalizado { get; set; } = false;

        [ForeignKey("pedido_id")]
        public int pedido_id { get; set; }
        public Pedido Pedido { get; set; }
    }
}
