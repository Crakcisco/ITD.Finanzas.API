using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.POCOS.Context
{
    public class EntityResumenesContext
    {
        public string result { get; set; }
        public int code { get; set; }
        public int usuario_id { get; set; }
        public decimal saldo_actual { get; set; }
    }
}
