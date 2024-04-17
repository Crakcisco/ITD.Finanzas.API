using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Context
{
    public interface ICategoriasContext
    {
        public Task<List<EntityCategoriasContext>> Get(string nombre);
    }
}
