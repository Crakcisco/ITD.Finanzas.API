using Dapper;
using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.DTO.DATA;
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
        public ErrorData _errorData { get; set; }
        private BDServices _bDServices;
        public PresupuestosContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityPresupuestosContext>> Get(int id)
        {
            DynamicParameters dp = new();
            dp.Add("@id", id, System.Data.DbType.Int32); // Suponiendo que el nombre del parámetro en el procedimiento almacenado sea configuracionId
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityPresupuestosContext>("Presupuestos_GET", dp);
            List<EntityPresupuestosContext> configuraciones = result.ToList();

            if (configuraciones.Count > 0)
            {
                switch (configuraciones[0].code)
                {
                    case (int)StatusResult.Success:
                        return configuraciones;
                    case (int)StatusResult.badRequest:
                        return new List<EntityPresupuestosContext>();
                    default:
                        return new List<EntityPresupuestosContext>();
                }
            }
            return new List<EntityPresupuestosContext>();
        }

    }
}
