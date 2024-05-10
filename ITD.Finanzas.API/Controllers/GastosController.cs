using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Application.Presenters;
using ITD.Finanzas.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Mime;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using System.Net;
using ITD.Finanzas.Domain.DTO.Request.Gastos;

namespace ITD.Finanzas.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class GastosController : ControllerBase
    {
        private readonly IGastosLogic _gastosLogic;
        public GastosController(IGastosLogic gastosLogic)
        {
            _gastosLogic = gastosLogic;
        }

        //GET
        [HttpGet]
        [Route("Get")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]

        [ProducesResponseType(typeof(List<GastosResponseGet>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _gastosLogic.Get(id));
        }


        //Agregue PATCH
        [HttpPatch]
        [Route("Patch")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CategoriasResponse), (int)HttpStatusCode.OK)] // Cambiado HttpStatusCode.Created a HttpStatusCode.OK ya que PATCH no crea un nuevo recurso, sino que actualiza uno existente
        public async Task<IActionResult> Patch(RequestGastos patch)
        {
            var result = await _gastosLogic.Patch(patch);
            if (result == null)
                return BadRequest(_gastosLogic._errorResponse);

            return Ok(result);
        }


        //Post


        [HttpPost]
        [Route("Post")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GastosResponsePost), (int)HttpStatusCode.Created)]

        public async Task<IActionResult> Post(RequestGastos post)
        {
            var result = await _gastosLogic.Post(post);
            if (result == null)
                return Created("www.google.com", result);
            return BadRequest(_gastosLogic._errorResponse);

        }


        //Agregue DELETE
        [HttpDelete("Delete")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CategoriasResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gastosLogic.Delete(id);
            if (result == null)
                return NotFound(_gastosLogic._errorResponse);

            return Ok(result);
        }
    }
}
