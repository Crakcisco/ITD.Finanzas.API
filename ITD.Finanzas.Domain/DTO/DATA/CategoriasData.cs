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
        public string type;

        public string nombre { get; set; }
        public CategoriasAttributes attributes { get; set; }

        //Agregue PATCH
        public int id { get; set; }
    }
}
