using L2.Manoel.Core.Entities;
using L2.Manoel.EmbalagemMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace L2.Manoel.EmbalagemMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;

        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpPost("empacotar-lote")]
        public IActionResult EmpacotarLote([FromBody] List<Pedido> pedidos, CancellationToken ct)
        {
            if (pedidos == null || !pedidos.Any())
            {
                return BadRequest("Nenhum pedido foi enviado.");
            }

            var resultadoLote = _entryService.EmpacotarLoteDePedidos(pedidos, ct);
            return Ok(resultadoLote);
        }
    }
}
