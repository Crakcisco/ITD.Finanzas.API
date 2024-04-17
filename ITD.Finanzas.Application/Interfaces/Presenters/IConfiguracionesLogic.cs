using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Presenters
{
    public interface IConfiguracionesLogic
    {
        public Task<List<ConfiguracionesAttributes>> GetConfiguracionesAsync(bool notificaciones_activas);
    }
}
