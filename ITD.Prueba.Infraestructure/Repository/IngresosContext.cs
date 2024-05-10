using Dapper;
using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.DTO;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Request.Gastos;
using ITD.Finanzas.Domain.DTO.Request.Ingresos;
using ITD.Finanzas.Domain.Enums;
using ITD.Finanzas.Domain.POCOS.Context;
using ITD.Finanzas.Infraestructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Infraestructure.Repository
{
    public class IngresosContext : IIngresosContext
    {
        public ErrorData _errorData { get; set; }
        private BDServices _bDServices;
        public IngresosContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityIngresosContext>> Get(int id)
        {
            DynamicParameters dp = new();
            dp.Add("@id", id, System.Data.DbType.Int32); // Suponiendo que el nombre del par�metro en el procedimiento almacenado sea configuracionId
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityIngresosContext>("Ingresos_GET", dp);
            List<EntityIngresosContext> ingresos = result.ToList();

            if (ingresos.Count > 0)
            {
                switch (ingresos[0].code)
                {
                    case (int)StatusResult.Success:
                        return ingresos;
                    case (int)StatusResult.badRequest:
                        return new List<EntityIngresosContext>();
                    default:
                        return new List<EntityIngresosContext>();
                }
            }
            return new List<EntityIngresosContext>();
        }

        //Agregue PATCH
        public async Task<EntityResultContext> Patch(RequestIngresos patch)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@usuario_id", patch.data.usuario_id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@categoria_id", patch.data.categoria_id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@titulo", patch.data.titulo, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@cantidad", patch.data.cantidad, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@fecha", patch.data.fecha, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@hora", patch.data.hora, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@motivo", patch.data.motivo, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@tipo_gasto", patch.data.tipo_ingreso, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@notas", patch.data.notas, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Ingreso_PATCH", dpr); // Asumiendo que tienes un procedimiento almacenado para actualizar categor�as

            if (result.code == 200)
                return result;
            else
            {
                _errorData.code = result.code.ToString();
                _errorData.detail = result.result;
                _errorData.tittle = "Error interno del servidor"; // Cambiado 'tittle' a 'title' para corregir el error tipogr�fico
                _errorData.status = result.code;
                return null;
            }
        }


        //Post
        public async Task<EntityResultContext> Post(RequestIngresos post)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@usuario_id", post.data.usuario_id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@categoria_id", post.data.categoria_id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@titulo", post.data.titulo, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@cantidad", post.data.cantidad, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@fecha", post.data.fecha, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@hora", post.data.hora, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@motivo", post.data.motivo, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@tipo_gasto", post.data.tipo_ingreso, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@notas", post.data.notas, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
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


        //Agregue DELETE

        public async Task<EntityResultContext> Delete(int id)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Ingreso_DELETE", dpr); // Asumiendo que tienes un procedimiento almacenado para eliminar categor�as

            return result;
        }

    }
}
