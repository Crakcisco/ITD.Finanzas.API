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
    public class RegistrosContext : IRegistrosContext
    {
        public ErrorData _errorData { get; set; }
        private BDServices _bDServices;
        public RegistrosContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityRegistrosContext>> Get(int id)
        {
            DynamicParameters dp = new();
            dp.Add("@id", id, System.Data.DbType.Int32); // Suponiendo que el nombre del parámetro en el procedimiento almacenado sea configuracionId
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityRegistrosContext>("Registros_GET", dp);
            List<EntityRegistrosContext> registros = result.ToList();

            if (registros.Count > 0)
            {
                switch (registros[0].code)
                {
                    case (int)StatusResult.Success:
                        return registros;
                    case (int)StatusResult.badRequest:
                        return new List<EntityRegistrosContext>();
                    default:
                        return new List<EntityRegistrosContext>();
                }
            }
            return new List<EntityRegistrosContext>();
        }

    }
}
