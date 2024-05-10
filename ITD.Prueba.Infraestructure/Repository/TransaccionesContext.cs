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
    public class TransaccionesContext : ITransaccionesContext
    {
        public ErrorData _errorData { get; set; }
        private BDServices _bDServices;
        public TransaccionesContext(BDServices bDServices)
        {
            _bDServices = bDServices;
        }

        public async Task<List<EntityTransaccionesContext>> Get(int id)
        {
            DynamicParameters dp = new();
            dp.Add("@id", id, System.Data.DbType.Int32); // Suponiendo que el nombre del parámetro en el procedimiento almacenado sea configuracionId
            var result = await _bDServices.ExecuteStoredProcedureQuery<EntityTransaccionesContext>("Transacciones_GET", dp);
            List<EntityTransaccionesContext> transacciones = result.ToList();

            if (transacciones.Count > 0)
            {
                switch (transacciones[0].code)
                {
                    case (int)StatusResult.Success:
                        return  transacciones;
                    case (int)StatusResult.badRequest:
                        return new List<EntityTransaccionesContext>();
                    default:
                        return new List<EntityTransaccionesContext>();
                }
            }
            return new List<EntityTransaccionesContext>();
        }

    }
}
