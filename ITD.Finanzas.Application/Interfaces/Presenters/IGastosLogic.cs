using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Gastos;
using ITD.Finanzas.Domain.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Presenters
{
    public interface IGastosLogic
    {
        public ErrorResponse _errorResponse { get; set; }
        public List<string> _error { get; set; }
        public  ValueTask<GastosResponseGet> Get(int id);
        public  ValueTask<GastosResponsePost> Patch(RequestGastos patch);
        public ValueTask<GastosResponsePost> Post(RequestGastos post);
        public ValueTask<GastosResponseDelete> Delete(int id);
    }
}
