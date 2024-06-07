using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.Request.Login;
using ITD.Finanzas.Domain.POCOS.Context;
using ITD.Finanzas.Infraestructure.Services;

namespace ITD.Finanzas.Infraestructure.Repository
{
    public class LoginContext : ILoginContext
    {
        public List<string> _error { get; set; }
        private readonly BDServices _bDServices;
        public ErrorData _errorData { get; set; }

        public LoginContext(BDServices bDServices)
        {
            _bDServices = bDServices;
            _errorData = new ErrorData();
        }

        public async Task<EntityResultContext> Login(LoginRequest loginRequest)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@p_email", loginRequest.email, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@p_password", loginRequest.password, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Usuario_LOGIN", dpr);

            if (result != null && result.code == 200)
                return result;

            _errorData.code = result?.code.ToString() ?? "500";
            _errorData.detail = result?.result ?? "Error interno del servidor";
            _errorData.tittle = "Error interno del servidor";
            _errorData.status = result?.code ?? 500;

            return null;
        }
    }
}
