using Copa2022.Extra;
using Copa2022.Models;
using Copa2022.Models.Consulta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Data;

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

        public IActionResult grpOperacao()
        {
            IEnumerable<TransacaoQry> lstTransacao =
                from item in contexto.transacoes
                .Include(o => o.conta).Include(o => o.conta.cliente).Include(o => o.conta.figurinha)
                .OrderBy(o => o.contaid)
                .ThenBy(o => o.operacao)
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
            IEnumerable<TransacaoGrpOperacao> lstGrpOper =
                from linha in lstTransacao
                .ToList()
                group linha by new { linha.conta, linha.operacao }
                into grupo
                orderby grupo.Key.conta
                select new TransacaoGrpOperacao
                {
                    conta = grupo.Key.conta,
                    operacao = grupo.Key.operacao,
                    valor = grupo.Sum(o => o.total)
                };

            return View(lstGrpOper);

        }

        public IActionResult grpMes()
        {
            IEnumerable<TransacaoQry> lstTransacao =
                from item in contexto.transacoes
                .Include(o => o.conta).Include(o => o.conta.cliente).Include(o => o.conta.figurinha)
                .OrderBy(o => o.contaid)
                .ThenBy(o => o.operacao)
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
            IEnumerable<ContaMes> lstGrpMes =
                from linha in lstTransacao
                .ToList()
                group linha by new { linha.conta, linha.data.Month}
                into grupo
                orderby grupo.Key.conta
                select new ContaMes
                {
                    conta = grupo.Key.conta,
                    mes = grupo.Key.Month,
                    valor = grupo.Sum(o => o.total)
                };

            return View(lstGrpMes);

        }


        public IActionResult PivotMes()
        {
            IEnumerable<TransacaoQry> lstTransacao =
                from item in contexto.transacoes
                .Include(o => o.conta).Include(o => o.conta.cliente).Include(o => o.conta.figurinha)
                .OrderBy(o => o.contaid)
                .ThenBy(o => o.operacao)
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
            IEnumerable<ContaMes> lstGrpMes =
                from linha in lstTransacao
                .ToList()
                group linha by new { linha.conta, linha.data.Month }
                into grupo
                orderby grupo.Key.conta
                select new ContaMes
                {
                    conta = grupo.Key.conta,
                    mes = grupo.Key.Month,
                    valor = grupo.Sum(o => o.total)
                };

            var PivotTableMes = lstGrpMes.ToList().ToPivotTable(
                                                          pivo => pivo.mes,  //coluna
                                                          pivo => pivo.conta, // linha
                                                          pivo => pivo.Any() ? pivo.Sum(x => x.valor) : 0); ;//valor do pivot

            List<PivotMes> lista = new List<PivotMes>();
            lista = (from DataRow coluna in PivotTableMes.Rows
                     select new PivotMes()
                     {
                         conta = Convert.ToInt32(coluna[0]),
                         mes1 = (int)Convert.ToSingle(coluna[1]),
                         mes2 = (int)Convert.ToSingle(coluna[2]),
                         mes3 = (int)Convert.ToSingle(coluna[3]),
                         mes4 = (int)Convert.ToSingle(coluna[4]),
                         mes5 = (int)Convert.ToSingle(coluna[5]),
                         mes6 = (int)Convert.ToSingle(coluna[6]),
                         mes7 = (int)Convert.ToSingle(coluna[7]),
                         mes8 = (int)Convert.ToSingle(coluna[8]),
                         mes9 = (int)Convert.ToSingle(coluna[9]),
                         mes10 = (int)Convert.ToSingle(coluna[10]),
                         mes11 = (int)Convert.ToSingle(coluna[11]),
                         mes12 = (int)Convert.ToSingle(coluna[12]),
                     }).ToList();

            return View(lista);
        }

        }

    }

