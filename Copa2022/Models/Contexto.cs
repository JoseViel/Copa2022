using Microsoft.EntityFrameworkCore;
using Copa2022.Models.Consulta;

namespace Copa2022.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) :
            base(options)
        { }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Figurinha> figurinhas { get; set; }
        public DbSet<Conta> contas { get; set; }
        public DbSet<Transacao> transacoes { get; set; }
        public DbSet<Copa2022.Models.Consulta.TransacaoQry> TransacaoQry { get; set; }

    }
}
