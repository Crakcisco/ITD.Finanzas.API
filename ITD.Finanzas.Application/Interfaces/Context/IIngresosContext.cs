using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.Request.Gastos;
using ITD.Finanzas.Domain.DTO.Request.Ingresos;
using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Context
{
    public interface IIngresosContext
    {
        public ErrorData _errorData { get; set; }
        public Task<List<EntityIngresosContext>> GetAll();
        public Task<EntityResultContext> Patch(RequestIngresosPatch patch);
        public Task<EntityResultContext> Post(RequestIngresos post);
        public Task<EntityResultContext> Delete(int id);
    }
}
