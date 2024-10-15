using L2.Manoel.Core.Entities;
using L2.Manoel.EmbalagemMS.Services.Interfaces;

namespace L2.Manoel.EmbalagemMS.Services
{
    public class EntryService : IEntryService
    {
        private List<Caixa> caixasDisponiveis = new List<Caixa>
        {
            new Caixa { caixa_id = "Caixa 1", altura = 30, largura = 40, comprimento = 80 },
            new Caixa { caixa_id = "Caixa 2", altura = 80, largura = 50, comprimento = 40 },
            new Caixa { caixa_id = "Caixa 3", altura = 50, largura = 80, comprimento = 60 }
        };

        public EmpacotamentoResultado EmpacotarProdutos(Pedido pedido)
        {

            var resultado = new EmpacotamentoResultado
            {
                pedido_id = pedido.pedido_id,
                caixas = new Dictionary<string, List<string>>()
            };

            List<Produto> produtosNaoCabem = pedido.produtos.ToList();

            foreach (var caixa in caixasDisponiveis.OrderBy(c => c.Volume()))
            {
                List<string> produtosNaCaixa = new List<string>();

                foreach (var produto in produtosNaoCabem.ToList())
                {
                    if (caixa.ProdutoCabe(produto))
                    {
                        produtosNaCaixa.Add(produto.produto_id);
                        produtosNaoCabem.Remove(produto);
                    }
                }

                if (produtosNaCaixa.Any())
                {
                    resultado.caixas.Add(caixa.caixa_id, produtosNaCaixa);
                }

                if (!produtosNaoCabem.Any())
                {
                    break;
                }
            }

            if (produtosNaoCabem.Any())
            {
                resultado.caixas.Add("Produto não cabe em nenhuma caixa disponível.", produtosNaoCabem.Select(p => p.produto_id).ToList());
            }

            return resultado;
        }

        public EmpacotamentoResultadoLote EmpacotarLoteDePedidos(List<Pedido> pedidos, CancellationToken ct)
        {
            var resultados = new EmpacotamentoResultadoLote
            {
                resultados = new List<EmpacotamentoResultado>()
            };

            foreach (var pedido in pedidos)
            {
                var resultado = EmpacotarProdutos(pedido);
                resultados.resultados.Add(resultado);
            }

            return resultados;
        }
    }
}
