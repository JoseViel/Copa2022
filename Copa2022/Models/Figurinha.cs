using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Copa2022.Models
{
    public enum Raridade { Comum, Brilhante, Bordo, Bronze, Prata, Ouro }

    [Table("Figurinhas")]
    public class Figurinha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int id { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo Jogador é obrigatório!")]
        [Display(Name = "Jogador:")]
        public string jogador { get; set; }

        [Display(Name = "Compra: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float compra { get; set; }

        [Display(Name = "Venda: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float venda { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo Pais é obrigatório!")]
        [Display(Name = "Pais:")]
        public string pais { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Campo Posicao é obrigatório!")]
        [Display(Name = "Posicao:")]
        public string posicao { get; set; }

        [Required(ErrorMessage = "Campo Raridade é obrigatório!")]
        [Display(Name = "Raridade:")]
        public Raridade raridade { get; set; }

        public ICollection<Conta> contas { get; set; }
    }
}
