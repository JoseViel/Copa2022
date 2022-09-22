namespace Copa2022.Models
{
    public class Conta
    {
        public int id { get; set; }
        public Cliente cliente { get; set; }
        public Figurinha figurinha { get; set; }
        public float quantidade { get; set; }
    
        public ICollection<Transacao> transacoes { get; set; }
    }
}
