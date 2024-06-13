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
using ITD.Finanzas.Domain.DTO.Request.Ingresos;

namespace ITD.Finanzas.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class IngresosController : ControllerBase
    {
        private readonly IIngresosLogic _ingresosLogic;
        public IngresosController(IIngresosLogic ingresosLogic)
        {
            _ingresosLogic = ingresosLogic;
        }

        //GET
        [HttpGet]
        [Route("Get")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]

        [ProducesResponseType(typeof(List<IngresosResponseGet>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ingresosLogic.GetAll());
        }


        //Agregue PATCH
        [HttpPatch]
        [Route("Patch")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CategoriasResponse), (int)HttpStatusCode.OK)] // Cambiado HttpStatusCode.Created a HttpStatusCode.OK ya que PATCH no crea un nuevo recurso, sino que actualiza uno existente
        public async Task<IActionResult> Patch(RequestIngresosPatch patch)
        {
            var result = await _ingresosLogic.Patch(patch);
            if (result == null)
                return BadRequest(_ingresosLogic._errorResponse);

            return Ok(result);
        }


        //Post


        [HttpPost]
        [Route("Post")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IngresosResponsePost), (int)HttpStatusCode.Created)]

        public async Task<IActionResult> Post(RequestIngresos post)
        {
            var result = await _ingresosLogic.Post(post);
            if (result == null)
                return Created("www.google.com", result);
            return BadRequest(_ingresosLogic._errorResponse);

        }


        //Agregue DELETE
        [HttpDelete("Delete")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CategoriasResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ingresosLogic.Delete(id);
            if (result == null)
                return NotFound(_ingresosLogic._errorResponse);

            return Ok(result);
        }
    }
}
