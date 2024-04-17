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
    public class GastosLogic : IGastosLogic
    {
        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;

        public GastosLogic(IFinanzasRepositoryContext iGastosRepositoryContext)
        {
            _finanzasRepositoryContext = iGastosRepositoryContext;
        }
        public async Task<List<GastosAttributes>> GetGastosAsync()
        {
            List<EntityGastosContext> gastos = await _finanzasRepositoryContext.GastosContext.Get("");
            List<GastosAttributes> gastosAttributes = new List<GastosAttributes>();
            foreach (var gasto in gastos)
            {
                gastosAttributes.Add(new GastosAttributes()
                {
                    titulo = gasto.titulo,

                });
            }
            return gastosAttributes;

        }

        public Task<List<GastosAttributes>> GetGastosAsync(string titulo)
        {
            throw new NotImplementedException();
        }
    }
}
