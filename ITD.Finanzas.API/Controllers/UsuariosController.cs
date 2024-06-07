using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.Request.Usuarios;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ITD.Finanzas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioLogic _usuarioLogic;

        public UsuariosController(IUsuarioLogic usuarioLogic)
        {
            _usuarioLogic = usuarioLogic;
        }

        // GET
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(typeof(List<UsuarioResponse>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _usuarioLogic.GetAll());
        }

        // POST
        [HttpPost]
        [Route("Post")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UsuarioResponsePost), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] RequestUsuario post)
        {
            var result = await _usuarioLogic.Post(post);
            if (result != null)
                return Created("www.google.com", result);

            return BadRequest(_usuarioLogic._errorResponse);
        }

        //Post Inicio sesion


        // PATCH
        [HttpPatch]
        [Route("Patch")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UsuarioResponsePost), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Patch(RequestUsuarioPatch patch)
        {
            var result = await _usuarioLogic.Patch(patch);
            if (result != null)
                return Ok(result);

            return BadRequest(_usuarioLogic._errorResponse);
        }

        // DELETE
        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UsuarioResponseDelete), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _usuarioLogic.Delete(id);
            if (result != null)
                return Ok(result);

            return NotFound(_usuarioLogic._errorResponse);
        }
    }
}
