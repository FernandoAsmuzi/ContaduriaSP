using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? nombre_usuario { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? rol { get; set; }

        public List<Provision>? Provision { get; set; }
    }
}
