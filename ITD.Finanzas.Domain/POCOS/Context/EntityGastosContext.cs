using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.POCOS.Context
{
    public class EntityGastosContext
    {
        public string result { get; set; }
        public int code { get; set; }
        public int usuario_id { get; set; }
        public int categoria_id { get; set; }
        public string titulo { get; set; }
        public decimal cantidad { get; set; }
        public DateOnly fecha { get; set; }
        public TimeOnly hora { get; set; }
        public string motivo { get; set; }
        public string tipo_gasto { get; set; }
        public string notas { get; set; }
    }
}
