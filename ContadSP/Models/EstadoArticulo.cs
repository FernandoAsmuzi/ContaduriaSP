using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class EstadoArticulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? estado { get; set; } // Ejemplo: "Entregado", "Rechazado", etc.

        // Relación con Articulo
        public List<Articulo> Articulos { get; set; }
    }
}