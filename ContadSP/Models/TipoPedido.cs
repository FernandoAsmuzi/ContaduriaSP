using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class TipoPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? tipo { get; set; }

        public List<Proceso>? Proceso { get; set; }
        public List<Provision>? Provision { get; set; }
    }
}
