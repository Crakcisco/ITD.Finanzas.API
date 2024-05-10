using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.DTO.DATA
{
    public class ConfiguracionesData
    {
        public string? type { get; set; }

        public List<ConfiguracionesDto>? attributes { get; set; }
    }
}
