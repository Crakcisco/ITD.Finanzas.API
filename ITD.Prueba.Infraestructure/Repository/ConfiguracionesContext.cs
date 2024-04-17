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
    public class ConfiguracionesContext : IConfiguracionesContext
    {
        private BDServices _bDServices;
        public ConfiguracionesContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityConfiguracionesContext>> Get(bool notificaciones_activas)
        {
            DynamicParameters dp = new();
            dp.Add("@notificaciones_activas", notificaciones_activas, System.Data.DbType.String);
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityConfiguracionesContext>("ConfiguracionesGET", dp);
            List<EntityConfiguracionesContext> configuraciones = result.ToList();
            if (configuraciones.Count > 0)
            {
                switch (configuraciones[0].code)
                {
                    case (int)StatusResult.Success: return configuraciones;
                    case (int)StatusResult.badRequest: return new List<EntityConfiguracionesContext>();
                    default: return new List<EntityConfiguracionesContext>();


                }

            }
            return new List<EntityConfiguracionesContext>();

        }
    }
}
