using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.Request.Login;
using ITD.Finanzas.Domain.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ITD.Finanzas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class LoginController : ControllerBase
    {
        private readonly ILoginLogic _loginLogic;

        public LoginController(ILoginLogic loginLogic)
        {
            _loginLogic = loginLogic;
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(LoginResponsePost), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var result = await _loginLogic.Login(loginRequest);
            if (result != null)
            {
                if (result.data != null) // Verifica si se devolvió un resultado exitoso
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(_loginLogic._errorResponse);
                }
            }
            return StatusCode(500); // En caso de error interno del servidor
        }
    }
}
