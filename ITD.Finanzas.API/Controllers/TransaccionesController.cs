using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Application.Presenters;
using ITD.Finanzas.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Mime;

namespace ITD.Finanzas.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class TransaccionesController : ControllerBase
    {
        private readonly ITransaccionesLogic _transaccionesLogic;
        public TransaccionesController(ITransaccionesLogic transaccionesLogic)
        {
            _transaccionesLogic = transaccionesLogic;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<TransaccionesLogic>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(Error), (int)StatusResult.badRequest)]

        public async Task<IActionResult> Get(string titulo)
        {
            return Ok(await _transaccionesLogic.GetTransaccionesAsync(titulo));
        }
    }
}
