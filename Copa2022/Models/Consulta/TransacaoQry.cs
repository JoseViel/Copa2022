namespace Copa2022.Models.Consulta
{
    public class TransacaoQry
    {
        public int id { get; set; }
        public int conta { get; set; }
        public string cliente { get; set; }
        public string figurinha { get; set; }
        public DateTime data { get; set; }
        public float quantidade { get; set; }
        public float valor { get; set; }
        public float total { get; set; }
        public string operacao { get; set; }
    }
}
