using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Presenters
{
    public class TransaccionesLogic : ITransaccionesLogic
    {
        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;

        public TransaccionesLogic(IFinanzasRepositoryContext iTransaccionesRepositoryContext)
        {
            _finanzasRepositoryContext = iTransaccionesRepositoryContext;
        }
        public async Task<List<TransaccionesAttributes>> GetTransaccionesAsync()
        {
            List<EntityTransaccionesContext> transacciones = await _finanzasRepositoryContext.TransaccionesContext.Get("");
            List<TransaccionesAttributes> transaccionesAttributes = new List<TransaccionesAttributes>();
            foreach (var transaccion in transacciones)
            {
                transaccionesAttributes.Add(new TransaccionesAttributes()
                {
                    titulo = transaccion.titulo,

                });
            }
            return transaccionesAttributes;

        }

        public Task<List<TransaccionesAttributes>> GetTransaccionesAsync(string titulo)
        {
            throw new NotImplementedException();
        }
    }
}
