
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


namespace ITD.Finanzas.Infraestructure.Repository
{
    public class CategoriasContext : ICategoriasContext
    {
        public List<string> _error { get; set; }
        public ErrorData _errorData { get; set; }
        private BDServices _bDServices;
        public CategoriasContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        
        public async Task<List<EntityCategoriasContext>> Get(string nombre)
        {

            DynamicParameters dp = new();
            dp.Add("@nombre", nombre, System.Data.DbType.String);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityCategoriasContext>("Categoria_GET", dp);
            List<EntityCategoriasContext> categorias = result.ToList();
            if (categorias.Count > 0)
            {
                switch (categorias[0].code)
                {
                    case (int)StatusResult.Success: { return categorias; }
                    case (int)StatusResult.badRequest: return new List<EntityCategoriasContext>();
                    default: return new List<EntityCategoriasContext>();


                }

            }
            return new List<EntityCategoriasContext>();

        }

        //Post
        public async Task<EntityResultContext> Post(RequestCategorias post)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@nombre", post.data.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Categoria_POST", dpr);
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
        public async Task<EntityResultContext> Patch(RequestCategorias patch)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@id", patch.data.id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@nombre", patch.data.nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Categoria_PATCH", dpr); // Asumiendo que tienes un procedimiento almacenado para actualizar categorías

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

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Categoria_DELETE", dpr); // Asumiendo que tienes un procedimiento almacenado para eliminar categorías

            return result;
        }

    }
}   
