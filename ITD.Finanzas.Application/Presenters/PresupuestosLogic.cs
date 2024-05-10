using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Presenters
{
    public class PresupuestosLogic : IPresupuestosLogic
    {

        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }


        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;
        private readonly IFinanzasRepositoryContext _repo;

        public PresupuestosLogic(IFinanzasRepositoryContext repo)
        {
            _repo = repo;
            _errorResponse = new ErrorResponse();
        }

        //GET
        public async ValueTask<PresupuestosResponse> Get(int id)
        {
            var presupuestos = await _repo.PresupuestosContext.Get(id);
            List<PresupuestosDto> output = new List<PresupuestosDto>();

            foreach (EntityPresupuestosContext a in presupuestos)
            {
                output.Add(new PresupuestosDto()
                {
                    id = a.id
                });
            }

            // Devolver la respuesta después de completar el bucle foreach
            return new PresupuestosResponse() { data = new PresupuestosData() { attributes = output, type = "Presupuestos" } };
        }

    }
}
