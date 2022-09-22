namespace Copa2022.Models
{
    public enum Estado {RS, SC, PR, SP, RJ, ES, MG, MS, MT, TO, GO, DF, RO, AC, AM, PA, PI, PE, PB, CE, BA, RN  }

    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public Estado estado { get; set;  }
        public int idade { get; set; }

        public ICollection<Conta> contas { get; set; }
    }
}
