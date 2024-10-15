using L2.Manoel.Core.Entities;

namespace L2.Manoel.EmbalagemMS.Services.Interfaces
{
    public interface IEntryService
    {
        EmpacotamentoResultadoLote EmpacotarLoteDePedidos(List<Pedido> pedidos, CancellationToken ct);
    }
}
