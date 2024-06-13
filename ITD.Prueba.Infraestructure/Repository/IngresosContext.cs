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
            _errorData = new ErrorData();
        }

        //Get
        public async Task<List<EntityIngresosContext>> GetAll()
        {
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityIngresosContext>("Ingresos_GET_ALL");
            return result.ToList();
        }


        //Agregue PATCH
        public async Task<EntityResultContext> Patch(RequestIngresosPatch patch)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@p_id", patch.data.id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@p_titulo", patch.data.titulo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@p_cantidad", patch.data.cantidad, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            dpr.Add("@p_fecha", patch.data.fecha, System.Data.DbType.Date, System.Data.ParameterDirection.Input);
            dpr.Add("@p_hora", patch.data.hora, System.Data.DbType.Time, System.Data.ParameterDirection.Input);
            dpr.Add("@p_motivo", patch.data.motivo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@p_notas", patch.data.notas, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Ingresos_PATCH", dpr);

            if (result.code == 200)
                return result;
            else
            {
                _errorData.code = result.code.ToString();
                _errorData.detail = result.result;
                _errorData.tittle = "Error interno del servidor"; // Corregido 'tittle' a 'title'
                _errorData.status = result.code;
                return null;
            }
        }




        //Post
        public async Task<EntityResultContext> Post(RequestIngresos post)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@v_usuario_id", post.data.usuario_id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@p_categoria_id", post.data.categoria_id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            dpr.Add("@p_titulo", post.data.titulo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@p_cantidad", post.data.cantidad, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            dpr.Add("@p_fecha", post.data.fecha, System.Data.DbType.Date, System.Data.ParameterDirection.Input);
            dpr.Add("@p_hora", post.data.hora, System.Data.DbType.Time, System.Data.ParameterDirection.Input);
            dpr.Add("@p_motivo", post.data.motivo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@p_tipo_ingreso", post.data.tipo_ingreso, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            dpr.Add("@p_notas", post.data.notas, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Ingresos_POST", dpr);

            if (result != null && result.code == 200)
            {
                return result;
            }
            else
            {
                _errorData.code = result?.code.ToString() ?? "500";
                _errorData.detail = result?.result ?? "Error interno del servidor";
                _errorData.tittle = "Error interno del servidor";
                _errorData.status = result?.code ?? 500;
                return null;
            }
        }




        //Agregue DELETE

        public async Task<EntityResultContext> Delete(int id)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Ingresos_DELETE", dpr); // Asumiendo que tienes un procedimiento almacenado para eliminar categorías

            return result;
        }

    }
}
