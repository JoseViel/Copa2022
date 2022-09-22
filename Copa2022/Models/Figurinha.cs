namespace Copa2022.Models
{
    public enum Posicao { Goleiro, Zagueiro, Lateral, Volante, MeioCampo, Atacante }
    public enum Pais { Catar, Equador, Holanda, Senegal, EstadosUnidos, Inglaterra, Irã, PaísDeGales, Argentina, ArábiaSaudita, México, Polônia, Austrália, Dinamarca, França, Tunísia, Alemanha, CostaRica, Espanha, Japão, Bélgica, Canadá, Marrocos, Croácia, Brasil, Sérvia, Suíça, Camarões, Portugal, Gana, Uruguai, CoreiaDoSul }
    public enum Raridade { Comum, Brilhante, Bordo, Bronze, Prata, Ouro}

    public class Figurinha
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public float venda { get; set; }
        public float compra { get; set; }
        public Pais pais { get; set; }
        public Posicao posicao { get; set; }
        public Raridade raridade { get; set; }

        public ICollection<Conta> contas { get; set; }
    }
}
