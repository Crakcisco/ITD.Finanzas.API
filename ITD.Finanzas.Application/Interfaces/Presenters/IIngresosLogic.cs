using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Gastos;
using ITD.Finanzas.Domain.DTO.Request.Ingresos;
using ITD.Finanzas.Domain.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Presenters
{
    public interface IIngresosLogic
    {
        public ErrorResponse _errorResponse { get; set; }
        public List<string> _error { get; set; }
        public ValueTask<IngresosResponseGet> Get(int id);
        public ValueTask<IngresosResponsePost> Patch(RequestIngresos patch);
        public ValueTask<IngresosResponsePost> Post(RequestIngresos post);
        public ValueTask<IngresosResponseDelete> Delete(int id);
    }
}
