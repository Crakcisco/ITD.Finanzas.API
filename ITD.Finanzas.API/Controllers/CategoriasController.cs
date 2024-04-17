using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Application.Presenters;
using ITD.Finanzas.Domain.Enums;
using ITD.Finanzas.Infraestructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ITD.Finanzas.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasLogic _categoriasLogic;
        public CategoriasController(ICategoriasLogic categoriasLogic)
        {
            _categoriasLogic = categoriasLogic;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriasLogic>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(Error), (int)StatusResult.badRequest)]

        public async Task<IActionResult> Get(string nombre)
        {
            return Ok(await _categoriasLogic.GetCategoriasAsync(nombre));
        }
    }



}
