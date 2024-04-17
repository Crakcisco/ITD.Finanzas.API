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
    public class RegistrosController : ControllerBase
    {
        private readonly IRegistrosLogic _registrosLogic;
        public RegistrosController(IRegistrosLogic registrosLogic)
        {
            _registrosLogic = registrosLogic;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<RegistrosLogic>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(Error), (int)StatusResult.badRequest)]

        public async Task<IActionResult> Get(int usuario_id)
        {
            return Ok(await _registrosLogic.GetRegistrosAsync(usuario_id));
        }
    }
}
