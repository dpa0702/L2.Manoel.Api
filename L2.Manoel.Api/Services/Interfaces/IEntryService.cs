using L2.Manoel.Core.Entities;

namespace L2.Manoel.Api.Services.Interfaces
{
    public interface IEntryService
    {
        Task NewEntry(Pedido pedido);
    }
}
