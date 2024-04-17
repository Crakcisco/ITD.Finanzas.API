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
    public class RegistrosContext : IRegistrosContext
    {
        private BDServices _bDServices;
        public RegistrosContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityRegistrosContext>> Get(int usuario_id)
        {
            DynamicParameters dp = new();
            dp.Add("@usuario_id", usuario_id, System.Data.DbType.String);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityRegistrosContext>("RegistrosGET", dp);
            List<EntityRegistrosContext> registros = result.ToList();
            if (registros.Count > 0)
            {
                switch (registros[0].code)
                {
                    case (int)StatusResult.Success: return registros;
                    case (int)StatusResult.badRequest: return new List<EntityRegistrosContext>();
                    default: return new List<EntityRegistrosContext>();


                }

            }
            return new List<EntityRegistrosContext>();

        }
    }
}
