using Dapper;
using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
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
    public class PresupuestosContext : IPresupuestosContext
    {
        private BDServices _bDServices;
        public PresupuestosContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityPresupuestosContext>> Get(int usuario_id)
        {
            DynamicParameters dp = new();
            dp.Add("@usuario_id", usuario_id, System.Data.DbType.String);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityPresupuestosContext>("PresupuestosGET", dp);
            List<EntityPresupuestosContext> presupuestos = result.ToList();
            if (presupuestos.Count > 0)
            {
                switch (presupuestos[0].code)
                {
                    case (int)StatusResult.Success: return presupuestos;
                    case (int)StatusResult.badRequest: return new List<EntityPresupuestosContext>();
                    default: return new List<EntityPresupuestosContext>();


                }

            }
            return new List<EntityPresupuestosContext>();

        }
    }
}
