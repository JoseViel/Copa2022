using Copa2022.Models;
using Copa2022.Models.Consulta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Copa2022.Controllers
{
    public class QueryController : Controller
    {
        private readonly Contexto contexto;

        public QueryController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Cliente(string filtro)
        {

            List<Cliente> lista = new List<Cliente>();

            if (filtro == null)
            {
                lista = contexto.clientes
                    .OrderBy(o => o.nome)
                    .ThenBy(p => p.idade)
                    .ToList();
            }
            else
            {
                lista = contexto.clientes.Where(n => n.nome.Contains(filtro))
                    .OrderBy(o => o.nome)
                    .ThenBy(p => p.idade)
                    .ToList();
            }
            return View(lista);
        }

        public IActionResult Pesquisa()
        {
            return View();
        }

        public IActionResult Transacoes()
        {
            IEnumerable<TransacaoQry> lstTransacao =
                from item in contexto.transacoes
                .Include(o => o.conta).Include(o => o.conta.cliente).Include(o => o.conta.figurinha)
                .OrderBy(o => o.contaid)
                .ToList()
                select new TransacaoQry
                {
                    conta = item.contaid,
                    cliente = item.conta.cliente.nome,
                    figurinha = item.conta.figurinha.jogador,
                    data = item.data,
                    quantidade = item.quantidade,
                    valor = item.conta.figurinha.venda,
                    total = item.quantidade * item.conta.figurinha.venda,
                    operacao = (item.operacao == 0) ? "Compra" : "Venda"
                };



            return View(lstTransacao);
        }
    }
}