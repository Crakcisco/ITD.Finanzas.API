using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces
{
    public interface ITransaccionesRepositoryContext
    {
        public List<EntityTransaccionesContext> Get();
    }
}
