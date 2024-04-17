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
    public class PresupuestosLogic : IPresupuestosLogic
    {
        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;

        public PresupuestosLogic(IFinanzasRepositoryContext iPresupuestosRepositoryContext)
        {
            _finanzasRepositoryContext = iPresupuestosRepositoryContext;
        }
        public async Task<List<PresupuestosAttributes>> GetPresupuestosAsync()
        {
            List<EntityPresupuestosContext> presupuestos = await _finanzasRepositoryContext.PresupuestosContext.Get(0);
            List<PresupuestosAttributes> presupuestosAttributes = new List<PresupuestosAttributes>();
            foreach (var presupuesto in presupuestos)
            {
                presupuestosAttributes.Add(new PresupuestosAttributes()
                {
                    usuario_id = presupuesto.usuario_id,

                });
            }
            return presupuestosAttributes;

        }

        public Task<List<PresupuestosAttributes>> GetPresupuestosAsync(int usuario_id)
        {
            throw new NotImplementedException();
        }
    }
}
