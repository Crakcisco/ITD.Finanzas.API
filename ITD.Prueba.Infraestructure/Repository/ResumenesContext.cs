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
    public class ResumenesContext : IResumenesContext
    {
        private BDServices _bDServices;
        public ResumenesContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityResumenesContext>> Get(int usuario_id)
        {
            DynamicParameters dp = new();
            dp.Add("@usuario_id", usuario_id, System.Data.DbType.String);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityResumenesContext>("ResumenesGET", dp);
            List<EntityResumenesContext> resumenes = result.ToList();
            if (resumenes.Count > 0)
            {
                switch (resumenes[0].code)
                {
                    case (int)StatusResult.Success: return resumenes;
                    case (int)StatusResult.badRequest: return new List<EntityResumenesContext>();
                    default: return new List<EntityResumenesContext>();


                }

            }
            return new List<EntityResumenesContext>();

        }
    }
}

