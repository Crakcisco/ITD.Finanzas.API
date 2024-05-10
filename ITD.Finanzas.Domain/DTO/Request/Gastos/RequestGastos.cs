using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.Request.Categorias.Data;
using ITD.Finanzas.Domain.DTO.Request.Gastos.Data;

namespace ITD.Finanzas.Domain.DTO.Request.Gastos
{
    public class RequestGastos
    {
        public RequestGastosData data { get; set; }
    }
}
