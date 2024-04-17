using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.DTO.DATA
{
    public class TransaccionesData
    {
        public int idTransacciones { get; set; }
        public List<TransaccionesAttributes> attributes { get; set; }
    }
}
