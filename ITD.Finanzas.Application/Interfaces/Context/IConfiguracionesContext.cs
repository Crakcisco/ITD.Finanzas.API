using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Context
{

        public interface IConfiguracionesContext
        {
        public ErrorData _errorData { get; set; }
        public  Task<List<EntityConfiguracionesContext>> Get(int id);
    }
    
}
