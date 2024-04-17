using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.DTO.DATA.Atributes
{
    public class PresupuestosAttributes
    {
        public string nombre { get; set; }
        public int usuario_id { get; set; }
        public int categoria_id { get; set; }
        public decimal monto { get; set; }
        public string periodo { get; set; }
    }
}
