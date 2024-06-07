using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.Request.Usuarios.Data;

namespace ITD.Finanzas.Domain.DTO.Request.Usuarios
{
    public class RequestUsuarioPatch
    {
        public RequestUsuarioDataPatch data { get; set; }
    }
}
