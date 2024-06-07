using Dapper;
using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.DTO;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.Request.Gastos;
using ITD.Finanzas.Domain.Enums;
using ITD.Finanzas.Domain.POCOS.Context;
using ITD.Finanzas.Infraestructure.Services;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ITD.Finanzas.Infraestructure.Repository
{
    public class GastosContext : IGastosContext
    {
        public ErrorData _errorData { get; set; }
        private BDServices _bDServices;
        public GastosContext(BDServices bDServices)
        {
            _bDServices = bDServices;
            _errorData = new ErrorData();
        }

        public async Task<List<EntityGastosContext>> Get(int id)
        {
            var dp = new DynamicParameters();
            dp.Add("@id", id, DbType.Int32);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityGastosContext>("Gastos_GET", dp);
            var gastos = result.ToList();

            return gastos;
        }

        public async Task<EntityResultContext> Patch(RequestGastos patch)
        {
            var dpr = new DynamicParameters();
            dpr.Add("@p_id", patch.data.id, DbType.Int32);
            dpr.Add("@p_titulo", patch.data.titulo, DbType.String);
            dpr.Add("@p_cantidad", patch.data.cantidad, DbType.Decimal);
            dpr.Add("@p_fecha", patch.data.fecha, DbType.Date);
            dpr.Add("@p_hora", patch.data.hora, DbType.Time);
            dpr.Add("@p_motivo", patch.data.motivo, DbType.String);
            dpr.Add("@p_tipo_gasto", patch.data.tipo_gasto, DbType.String);
            dpr.Add("@p_notas", patch.data.notas, DbType.String);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Gastos_PATCH", dpr);

            return result;
        }

        public async Task<EntityResultContext> Post(RequestGastos post)
        {
            var dpr = new DynamicParameters();
            dpr.Add("@p_usuario_id", post.data.usuario_id, DbType.Int32);
            dpr.Add("@p_categoria_id", post.data.categoria_id, DbType.Int32);
            dpr.Add("@p_titulo", post.data.titulo, DbType.String);
            dpr.Add("@p_cantidad", post.data.cantidad, DbType.Decimal);
            dpr.Add("@p_fecha", post.data.fecha, DbType.Date);
            dpr.Add("@p_hora", post.data.hora, DbType.Time);
            dpr.Add("@p_motivo", post.data.motivo, DbType.String);
            dpr.Add("@p_tipo_gasto", post.data.tipo_gasto, DbType.String);
            dpr.Add("@p_notas", post.data.notas, DbType.String);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Gastos_POST", dpr);

            return result;
        }


        public async Task<EntityResultContext> Delete(int id)
        {
            var dpr = new DynamicParameters();
            dpr.Add("@id", id, DbType.Int32);

            var result = await _bDServices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("Gastos_DELETE", dpr);

            return result;
        }
    }
}
