using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Copa2022.Models
{
    [Table("Contas")]
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int id { get; set; }

        [Display(Name = "Cliente: ")]
        public Cliente cliente { get; set; }
        [Display(Name = "Cliente: ")]
        public int clienteid { get; set; }

        [Display(Name = "Figurinha: ")]
        public Figurinha figurinha { get; set; }
        [Display(Name = "Figurinha: ")]
        public int figurinhaid { get; set; }

        [Display(Name = "Quantidade: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float quantidade { get; set; }

        public ICollection<Transacao> transacoes { get; set; }
    }
}
