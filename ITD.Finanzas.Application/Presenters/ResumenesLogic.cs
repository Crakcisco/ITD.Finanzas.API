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
    public class ResumenesLogic : IResumenesLogic
    {
        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;

        public ResumenesLogic(IFinanzasRepositoryContext iResumenesRepositoryContext)
        {
            _finanzasRepositoryContext = iResumenesRepositoryContext;
        }
        public async Task<List<ResumenesAttributes>> GetResumenesAsync()
        {
            List<EntityResumenesContext> resumenes = await _finanzasRepositoryContext.ResumenesContext.Get(0);
            List<ResumenesAttributes> resumenesAttributes = new List<ResumenesAttributes>();
            foreach (var resumen in resumenes)
            {
                resumenesAttributes.Add(new ResumenesAttributes()
                {
                    usuario_id = resumen.usuario_id,

                });
            }
            return resumenesAttributes;

        }

        public Task<List<ResumenesAttributes>> GetResumenesAsync(int usuario_id)
        {
            throw new NotImplementedException();
        }
    }
}
