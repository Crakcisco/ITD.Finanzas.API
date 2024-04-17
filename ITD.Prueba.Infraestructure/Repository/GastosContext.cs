using Dapper;
using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.DTO;
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
    public class GastosContext : IGastosContext
    {
        private BDServices _bDServices;
        public GastosContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityGastosContext>> Get(string titulo)
        {
            DynamicParameters dp = new();
            dp.Add("@titulo", titulo, System.Data.DbType.String);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityGastosContext>("GastosGET", dp);
            List<EntityGastosContext> gastos = result.ToList();
            if (gastos.Count > 0)
            {
                switch (gastos[0].code)
                {
                    case (int)StatusResult.Success: return gastos;
                    case (int)StatusResult.badRequest: return new List<EntityGastosContext>();
                    default: return new List<EntityGastosContext>();


                }

            }
            return new List<EntityGastosContext>();

        }
    }
}
