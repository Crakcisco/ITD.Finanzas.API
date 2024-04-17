using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.POCOS.Context
{
    public class EntityTransaccionesContext
    {
        public string result { get; set; }
        public int code { get; set; }
        public int gasto_id { get; set; }
        public int ingreso_id { get; set; }
        public string titulo { get; set; }
        public decimal cantidad { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string motivo { get; set; }
        public string tipo { get; set; }
        public string notas { get; set; }
    }
}
