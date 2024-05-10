using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.Request.Gastos;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Context
{
    public interface IGastosContext
    {
        public ErrorData _errorData { get; set; }
        public Task<List<EntityGastosContext>> Get(int id);
        public  Task<EntityResultContext> Patch(RequestGastos patch);
        public Task<EntityResultContext> Post(RequestGastos post);
        public Task<EntityResultContext> Delete(int id);
    }
}
