using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.POCOS.Context
{
    public class EntityUsuarioContext
    {
        public string result {  get; set; }
        public int code { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
