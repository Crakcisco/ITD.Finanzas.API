using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.Request.Login;
using ITD.Finanzas.Domain.POCOS.Context;

namespace ITD.Finanzas.Application.Interfaces.Context
{
    public interface ILoginContext
    {
        public ErrorData _errorData { get; set; }
        public Task<EntityResultContext> Login(LoginRequest loginRequest);
    }
}
