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
    public class ConfiguracionesLogic : IConfiguracionesLogic
    {

        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }


        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;
        private readonly IFinanzasRepositoryContext _repo;

        public ConfiguracionesLogic(IFinanzasRepositoryContext repo)
        {
            _repo = repo;
            _errorResponse = new ErrorResponse();
        }

        //GET
        public async ValueTask<ConfiguracionesResponse> Get(int id)
        {
            var configuraciones = await _repo.ConfiguracionesContext.Get(id);
            List<ConfiguracionesDto> output = new List<ConfiguracionesDto>();

            foreach (EntityConfiguracionesContext a in configuraciones)
            {
                output.Add(new ConfiguracionesDto()
                {
                    id = a.id
                });
            }

            // Devolver la respuesta después de completar el bucle foreach
            return new ConfiguracionesResponse() { data = new ConfiguracionesData() { attributes = output, type = "Configuraciones" } };
        }

    }
}
