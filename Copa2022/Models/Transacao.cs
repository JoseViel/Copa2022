using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Copa2022.Models
{
    public enum Operacao { Compra, Venda }

    [Table("Transacoes")]
    public class Transacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int id { get; set; }

        [Display(Name = "Conta: ")]
        public Conta conta { get; set; }
        [ForeignKey("Conta")]
        public int contaid { get; set; }

        [Display(Name = "Data: ")]
        public DateTime data { get; set; }

        [Display(Name = "Quantidade: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float quantidade { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }

        [Display(Name = "Operacao: ")]
        public Operacao operacao { get; set; }

        [Display(Name = "Total: ")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public virtual float total
        {
            get { return quantidade * valor; }
        }

        [Display(Name = "Operacao: ")]
        [NotMapped]
        public virtual string tipoOperacao
        {

            get { return (operacao == Operacao.Compra ? "Compra" : "Venda"); }
        }

        [Display(Name = "Conta: ")]
        [NotMapped]
        public virtual string nomeConta
        {
            get { return (conta.id.ToString() + " - " + conta.cliente.nome + " - " + conta.figurinha.jogador); }
        }
    }

}

