using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.POCOS.Context
{
    public class EntityPresupuestosContext
    {
        public string result { get; set; }
        public int code { get; set; }
        public string nombre { get; set; }
        public int usuario_id { get; set; }
        public int categoria_id { get; set; }
        public decimal monto { get; set; }
        public string periodo { get; set; }
    }
}
