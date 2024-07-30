using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContadSP.Models
{
    public class ProvisionExp
    {
        public ProvisionExp()
        {
            fecha_provision_exp = DateOnly.FromDateTime(DateTime.Now);
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? exp_num { get; set; }
        public DateOnly fecha_provision_exp { get; set; }

        [ForeignKey("provision_id")]
        public int provision_id { get; set; }
        public Provision Provision { get; set; }
    }
}
