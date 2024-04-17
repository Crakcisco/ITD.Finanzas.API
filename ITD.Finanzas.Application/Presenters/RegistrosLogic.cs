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
    public class RegistrosLogic : IRegistrosLogic
    {
        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;

        public RegistrosLogic(IFinanzasRepositoryContext iRegistrosRepositoryContext)
        {
            _finanzasRepositoryContext = iRegistrosRepositoryContext;
        }
        public async Task<List<RegistrosAttributes>> GetRegistrosAsync()
        {
            List<EntityRegistrosContext> registros = await _finanzasRepositoryContext.RegistrosContext.Get(0);
            List<RegistrosAttributes> registrosAttributes = new List<RegistrosAttributes>();
            foreach (var registro in registros)
            {
                registrosAttributes.Add(new RegistrosAttributes()
                {
                    usuario_id = registro.usuario_id,

                });
            }
            return registrosAttributes;

        }

        public Task<List<RegistrosAttributes>> GetRegistrosAsync(int usuario_id)
        {
            throw new NotImplementedException();
        }
    }
}
