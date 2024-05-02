using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.DTO.DATA
{
    public class CategoriasData
    {
        //Presentar 
        public string? type { get; set; }

        public List<CategoriasDto>? attributes { get; set; }
        //public string nombre { get; set; }

        //Agregue PATCH
        //public int id { get; set; }
    }
}
