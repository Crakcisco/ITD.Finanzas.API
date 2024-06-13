using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;

namespace ITD.Finanzas.Domain.DTO.DATA
{
    public class IngresosDataPatch
    {
        public string type { get; set; }
        public IngresosAttributesPatch attributes { get; set; }
    }
}
