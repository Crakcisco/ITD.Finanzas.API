using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.DTO.Request.Login;
using ITD.Finanzas.Application.Interfaces.Presenters;

namespace ITD.Finanzas.Application.Presenters
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IFinanzasRepositoryContext _repo;
        public ErrorResponse _errorResponse { get; set; }
        public ErrorData _errorData { get; set; }
        public List<string> _error { get; set; }

        public LoginLogic(IFinanzasRepositoryContext repo)
        {
            _repo = repo;
            _errorResponse = new ErrorResponse();
        }

        public async ValueTask<LoginResponsePost> Login(LoginRequest loginRequest)
        {
            var usuario = await _repo.LoginContext.Login(loginRequest);
            if (usuario != null && usuario.code == 200)
            {
                return new LoginResponsePost
                {
                    data = new LoginDataPost
                    {
                        attributes = new LoginAttributes { mensaje = "Login exitoso" },
                        type = "Usuarios"
                    }
                };
            }
            else
            {
                _errorResponse.errors = new List<ErrorData>
                {
                    new ErrorData
                    {
                        code = usuario?.code.ToString() ?? "500",
                        detail = usuario?.result ?? "Error interno del servidor",
                        status = usuario?.code ?? 500,
                        tittle = "Error interno del servidor"
                    }
                };
                return null;
            }
        }
    }
}
