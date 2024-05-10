using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Application.Presenters;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.Enums;
using ITD.Finanzas.Infraestructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ITD.Finanzas.API.Controllers
{
    //[Authorize]
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

        //GET
        [HttpGet]
        [Route("Get")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]

        [ProducesResponseType(typeof(List<PresupuestosResponse>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _presupuestosLogic.Get(id));
        }

    }

}