using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Context
{
    public interface IRegistrosContext
    {
        public Task<List<EntityRegistrosContext>> Get(int usuario_id);
    }
}
