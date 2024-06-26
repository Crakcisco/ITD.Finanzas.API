using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.POCOS.Context
{
    public class EntityIngresosContext
    {
        public int id { get; set; }
        public string result { get; set; }
        public int code { get; set; }
        public int usuario_id { get; set; }
        public int categoria_id { get; set; }
        public string titulo { get; set; }
        public decimal cantidad { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public string motivo { get; set; }
        public string tipo_ingreso { get; set; }
        public string notas { get; set; }

    }
}
