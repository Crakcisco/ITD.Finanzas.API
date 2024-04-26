using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.DTO.Request.Categorias.Data
{
    public class RequestCategoriasData
    {
        public string nombre { get; set; } 

        //Agregue para patch
        public int id { get; set;}
    }
}
