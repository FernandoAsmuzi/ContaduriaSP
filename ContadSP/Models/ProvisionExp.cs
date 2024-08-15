using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContadSP.Models
{
    public class ProvisionExp
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int exp_num { get; set; }
        public int anio { get; set; }

        public string abreviatura { get; set; } = "EXP";

        [ForeignKey("provision_id")]
        public int provision_id { get; set; }
        public Provision Provision { get; set; }
    }
}
