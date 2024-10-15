using L2.Manoel.Api.Services.Interfaces;
using L2.Manoel.Core.Entities;
using MassTransit;

namespace L2.Manoel.Api.Services
{
    public class EntryService : IEntryService
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public EntryService(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public async Task NewEntry(Pedido pedido)
        {
            var entry = new Pedido
            {
                pedido_id = pedido.pedido_id,
                produtos = pedido.produtos,
            };

            var queueName = _configuration.GetSection("MassTransit")["NewEntryQueue"] ?? string.Empty;
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{queueName}"));

            await endpoint.Send(entry);
        }
    }
}
