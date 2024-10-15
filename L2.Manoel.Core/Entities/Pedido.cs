namespace L2.Manoel.Core.Entities
{
    public class Pedido
    {
        public int pedido_id { get; set; }
        public List<Produto> produtos { get; set; }
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
