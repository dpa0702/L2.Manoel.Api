using L2.Manoel.Core.Entities;
using Bogus;

namespace L2.Manoel.Tests.Entities.Mock
{
    public class PedidoMock
    {
        private readonly Faker _faker;
        public int pedido_id { get; set; }
        public List<Produto> produtos { get; set; }

        public PedidoMock()
        {
            _faker = new Faker();
            pedido_id = 1;
            produtos = new List<Produto>();
        }
    }

    public class EmpacotamentoResultado
    {
        public int pedido_id { get; set; }
        public Dictionary<string, List<string>> caixas { get; set; }
    }

    public class EmpacotamentoResultadoLote
    {
        public List<EmpacotamentoResultado> resultados { get; set; }
    }
}
