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
    public class PresupuestosController : ControllerBase
    {
        private readonly IPresupuestosLogic _presupuestosLogic;
        public PresupuestosController(IPresupuestosLogic presupuestosLogic)
        {
            _presupuestosLogic = presupuestosLogic;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<PresupuestosLogic>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(Error), (int)StatusResult.badRequest)]

        public async Task<IActionResult> Get(int usuario_id)
        {
            return Ok(await _presupuestosLogic.GetPresupuestosAsync(usuario_id));
        }
    }
}
