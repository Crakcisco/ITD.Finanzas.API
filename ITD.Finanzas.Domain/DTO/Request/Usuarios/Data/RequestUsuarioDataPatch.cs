using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.DTO.Request.Usuarios.Data
{
    public class RequestUsuarioDataPatch
    {
        public int id { get; set; }
        public string currentEmail { get; set; }
        public string newEmail { get; set; }
        public string newName { get; set; }
    }
}
