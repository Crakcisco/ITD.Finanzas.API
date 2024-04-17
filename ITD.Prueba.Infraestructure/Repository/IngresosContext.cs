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
    public class IngresosContext : IIngresosContext
    {
        private BDServices _bDServices;
        public IngresosContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityIngresosContext>> Get(string titulo)
        {
            DynamicParameters dp = new();
            dp.Add("@titulo", titulo, System.Data.DbType.String);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityIngresosContext>("IngresosGET", dp);
            List<EntityIngresosContext> ingresos = result.ToList();
            if (ingresos.Count > 0)
            {
                switch (ingresos[0].code)
                {
                    case (int)StatusResult.Success: return ingresos;
                    case (int)StatusResult.badRequest: return new List<EntityIngresosContext>();
                    default: return new List<EntityIngresosContext>();


                }

            }
            return new List<EntityIngresosContext>();

        }
    }
}
