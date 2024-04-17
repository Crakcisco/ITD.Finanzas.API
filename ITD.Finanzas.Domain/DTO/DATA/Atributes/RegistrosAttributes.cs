using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.DTO.DATA.Atributes
{
    public class RegistrosAttributes
    {
        public int usuario_id { get; set; }
        public DateOnly fecha_registro {  get; set; }
        public string detalles {  get; set; }
    }
}
