using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Application.Presenters;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.Enums;
using ITD.Finanzas.Infraestructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ICategoriasPresenter = ITD.Finanzas.Application.Interfaces.Presenters.ICategoriasPresenter;

namespace ITD.Finanzas.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]


    
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasLogic _categoriasLogic;
        private readonly ICategoriasPresenter _categoriasPresenter;

        public CategoriasController(ICategoriasLogic categoriasLogic, ICategoriasPresenter categoriasPresenter)
        {
            _categoriasLogic = categoriasLogic;
            _categoriasPresenter = categoriasPresenter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriasLogic>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(Error), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Get(string nombre)
        {
            return Ok(await _categoriasLogic.GetCategoriasAsync(nombre));
        }


        //Post


        [HttpPost]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CategoriasResponse), (int)HttpStatusCode.Created)]
       
        public async Task<IActionResult> Post(RequestCategorias post)
        {
            var result = await _categoriasPresenter.Post(post);
            if (result == null)
                return Created("www.google.com", result);
            return BadRequest(_categoriasPresenter._errorResponse);

        }

        //Agregue PATCH
        [HttpPatch]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CategoriasResponse), (int)HttpStatusCode.OK)] // Cambiado HttpStatusCode.Created a HttpStatusCode.OK ya que PATCH no crea un nuevo recurso, sino que actualiza uno existente
        public async Task<IActionResult> Patch(RequestCategorias patch)
        {
            var result = await _categoriasPresenter.Patch(patch);
            if (result == null)
                return BadRequest(_categoriasPresenter._errorResponse);

            return Ok(result);
        }

        //Agregue DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CategoriasResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoriasPresenter.Delete(id);
            if (result == null)
                return NotFound(_categoriasPresenter._errorResponse);

            return Ok(result);
        }

    }

}
