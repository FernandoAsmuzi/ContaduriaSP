using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContadSP.Models
{
    public class Pago
    {
        public Pago()
        {
            fecha_pago = DateOnly.FromDateTime(DateTime.Now);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly fecha_pago { get; set; }
        public string? factura { get; set; }
        public string? remito { get; set; }
        public string? retencion_ib { get; set; }
        public string? retencion_ganancias { get; set; }
        public double subtotal { get; set; }
        public string subtotal_letra { get; set; }
        public double total { get; set; }
        public string total_letra { get; set; }
        public string otros { get; set; }
        public string numero_transferencia { get; set; }
        [ForeignKey("compra_id")]
        public int compra_id { get; set; }
        public Compra Compra { get; set; }
    }
}
