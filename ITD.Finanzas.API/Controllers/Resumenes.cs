using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Application.Presenters;
using ITD.Finanzas.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Mime;

namespace ITD.Finanzas.API.Controllers
{
    public class Resumenes
    {
        [Authorize]
        [Route("api/[controller]")]
        [ApiController]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public class ResumenesController : ControllerBase
        {
            private readonly IResumenesLogic _resumenesLogic;
            public ResumenesController(IResumenesLogic resumenesLogic)
            {
                _resumenesLogic = resumenesLogic;
            }
            [HttpGet]
            [ProducesResponseType(typeof(List<ResumenesLogic>), (int)StatusResult.Success)]
            [ProducesResponseType(typeof(Error), (int)StatusResult.badRequest)]

            public async Task<IActionResult> Get(int usuario_id)
            {
                return Ok(await _resumenesLogic.GetResumenesAsync(usuario_id));
            }
        }
    }
}
