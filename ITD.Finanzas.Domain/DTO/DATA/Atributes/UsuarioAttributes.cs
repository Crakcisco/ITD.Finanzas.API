using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.DTO.DATA.Atributes
{
    public class UsuarioAttributes
    {
        public int userId { get; set; }
        public string mensaje {  get; set; }
        public string nombre {  get; set; }
        public string email { get; set;}
        public string password { get; set;}
    }
}
