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
        public class UsuariosController : ControllerBase
        {
            private readonly IUsuarioLogic _usuariosLogic;
            public UsuariosController(IUsuarioLogic usuariosLogic)
            {
                _usuariosLogic = usuariosLogic;
            }
            [HttpGet]
            [ProducesResponseType(typeof(List<UsuarioLogic>), (int)StatusResult.Success)]
            [ProducesResponseType(typeof(Error), (int)StatusResult.badRequest)]

            public async Task<IActionResult> Get(string nombre)
            {
                return Ok(await _usuariosLogic.GetUsuarioAsync(nombre));
            }
        }
    }

