
using Dapper;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.POCOS.Context;
using ITD.Finanzas.Infraestructure.Services;
using System.Xml.XPath;
using System.Linq;
using ITD.Finanzas.Domain.Enums;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.Request.Usuarios;


namespace ITD.Finanzas.Infraestructure.Repository
{
    public class UsuarioContext : IUsuarioContext
    {
        public List<string> _error { get; set; }
        public ErrorData _errorData { get; set; }
        private BDServices _bDServices;
        public UsuarioContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }


        public async Task<List<EntityUsuarioContext>> Get(int id)
        {
            DynamicParameters dp = new();
            dp.Add("@id", id, System.Data.DbType.Int32); // Suponiendo que el nombre del parámetro en el procedimiento almacenado sea configuracionId
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityUsuarioContext>("Usuario_GET", dp);
            List<EntityUsuarioContext> configuraciones = result.ToList();

            if (configuraciones.Count > 0)
            {
                switch (configuraciones[0].code)
                {
                    case (int)StatusResult.Success:
                        return configuraciones;
                    case (int)StatusResult.badRequest:
                        return new List<EntityUsuarioContext>();
                    default:
                        return new List<EntityUsuarioContext>();
                }
            }
            return new List<EntityUsuarioContext>();
        }

        //Post
        public async Task<EntityResultContext> Post(RequestUsuario post)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@nombre", post.data.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@email", post.data.email, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@password", post.data.password, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Usuario_POST", dpr);
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

        //Agregue PATCH
        public async Task<EntityResultContext> Patch(RequestUsuario patch)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@nombre", patch.data.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@email", patch.data.email, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Usuario_PATCH", dpr); // Asumiendo que tienes un procedimiento almacenado para actualizar categorías

            if (result.code == 200)
                return result;
            else
            {
                _errorData.code = result.code.ToString();
                _errorData.detail = result.result;
                _errorData.tittle = "Error interno del servidor"; // Cambiado 'tittle' a 'title' para corregir el error tipográfico
                _errorData.status = result.code;
                return null;
            }
        }

        //Agregue DELETE

        public async Task<EntityResultContext> Delete(int id)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Usuario_DELETE", dpr); // Asumiendo que tienes un procedimiento almacenado para eliminar categorías

            return result;
        }

    }
}
