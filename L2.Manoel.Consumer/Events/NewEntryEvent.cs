using L2.Manoel.Core.Entities;
using L2.Manoel.Core.Helpers;
using MassTransit;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;

namespace L2.Manoel.Consumer.Events
{
    public class NewEntryEvent : IConsumer<Pedido>
    {
        private static HttpClient _entryClient = HttpClientConfiguration.EntryClient();
        public Task Consume(ConsumeContext<Pedido> context)
        {
            Console.WriteLine($"Novo lançamento com pedido_id: {context.Message.pedido_id}");

            Pedido pedido = new()
            {
                pedido_id = context.Message.pedido_id,
                produtos = context.Message.produtos,
            };

            var jsonContent = JsonConvert.SerializeObject(pedido);
            var body = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _entryClient.PostAsync("https://localhost:9003/entry", body);

            return Task.CompletedTask;
        }
    }
}
