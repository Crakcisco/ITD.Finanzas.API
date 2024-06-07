using Dapper;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.POCOS.Context;
using ITD.Finanzas.Infraestructure.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.Request.Usuarios;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.Enums;

namespace ITD.Finanzas.Infraestructure.Repository
{
    public class UsuarioContext : IUsuarioContext
    {
        public List<string> _error { get; set; }
        private readonly BDServices _bDServices;
        public ErrorData _errorData { get; set; }

        public UsuarioContext(BDServices bDServices)
        {
            _bDServices = bDServices;
            _errorData = new ErrorData();
        }

        public async Task<List<EntityUsuarioContext>> GetAll()
        {
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityUsuarioContext>("Usuario_GET_ALL");
            return result.ToList();
        }


        // POST
        public async Task<EntityResultContext> Post(RequestUsuario post)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@p_nombre", post.data.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@p_email", post.data.email, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@p_password", post.data.password, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Usuario_POST", dpr);
            if (result != null && result.code == 200)
                return result;

            _errorData.code = result?.code.ToString() ?? "500";
            _errorData.detail = result?.result ?? "Error interno del servidor";
            _errorData.tittle = "Error interno del servidor";
            _errorData.status = result?.code ?? 500;
            return null;
        }

        // PATCH
        public async Task<EntityResultContext> Patch(RequestUsuarioPatch patch)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@currentEmail", patch.data.currentEmail, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@newName", patch.data.newName, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@newEmail", patch.data.newEmail, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Usuario_PATCH", dpr);

            if (result.code == 200)
                return result;
            else
            {
                _errorData.code = result.code.ToString();
                _errorData.detail = result.result;
                _errorData.tittle = "Error interno del servidor";
                _errorData.status = result.code;
                return null;
            }
        }
  

        // DELETE
        public async Task<EntityResultContext> Delete(int id)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Usuario_DELETE", dpr);
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
