using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.Request.Login;
using ITD.Finanzas.Domain.DTO.Response;

namespace ITD.Finanzas.Application.Interfaces.Presenters
{
    public interface ILoginLogic
    {
        public ErrorResponse _errorResponse { get; set; }
        public List<string> _error { get; set; }
        public ValueTask<LoginResponsePost> Login(LoginRequest loginRequest);


    }
}
