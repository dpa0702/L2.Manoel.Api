using L2.Manoel.Api.Services.Interfaces;
using L2.Manoel.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace L2.Manoel.Api.Controllers
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

        [HttpPost]
        public async Task<IActionResult> NewEntry([FromBody] Pedido pedido)
        {
            try
            {
                await _entryService.NewEntry(pedido);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
