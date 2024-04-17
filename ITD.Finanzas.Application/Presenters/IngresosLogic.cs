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
    public class IngresosLogic : IIngresosLogic
    {
        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;

        public IngresosLogic(IFinanzasRepositoryContext iIngresosRepositoryContext)
        {
            _finanzasRepositoryContext = iIngresosRepositoryContext;
        }
        public async Task<List<IngresosAttributes>> GetIngresosAsync()
        {
            List<EntityIngresosContext> ingresos = await _finanzasRepositoryContext.IngresosContext.Get("");
            List<IngresosAttributes> ingresosAttributes = new List<IngresosAttributes>();
            foreach (var ingreso in ingresos)
            {
                ingresosAttributes.Add(new IngresosAttributes()
                {
                    titulo = ingreso.titulo,

                });
            }
            return ingresosAttributes;

        }

        public Task<List<IngresosAttributes>> GetIngresosAsync(string titulo)
        {
            throw new NotImplementedException();
        }
    }
}
