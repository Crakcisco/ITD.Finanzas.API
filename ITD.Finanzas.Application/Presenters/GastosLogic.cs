using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Request.Gastos;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.POCOS.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Presenters
{
    public class GastosLogic : IGastosLogic
    {
        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }


        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;
        private readonly IFinanzasRepositoryContext _repo;

        public GastosLogic(IFinanzasRepositoryContext repo)
        {
            _repo = repo;
            _errorResponse = new ErrorResponse();
        }

        public async ValueTask<GastosResponseGet> Get(int id)
        {
            var gastos = await _repo.GastosContext.Get(id);
            List<GastosDto> output = new List<GastosDto>();

            foreach (EntityGastosContext a in gastos)
            {
                output.Add(new GastosDto()
                {
                    id = a.id
                });
            }

            return new GastosResponseGet() { data = new GastosData() { attributes = output, type = "Gastos" } };
        }

        public async ValueTask<GastosResponsePost> Patch(RequestGastos patch)
        {
            var gastos = await _repo.GastosContext.Patch(patch);
            if (gastos != null && gastos.code == 200)
            {
                return new GastosResponsePost()
                {
                    data = new GastosDataPost()
                    {
                        attributes = new GastosAttributes()
                        {
                            usuario_id = patch.data.usuario_id,
                            categoria_id = patch.data.categoria_id,
                            titulo = patch.data.titulo,
                            cantidad = patch.data.cantidad,
                            fecha = patch.data.fecha,
                            hora = patch.data.hora,
                            motivo = patch.data.motivo,
                            tipo_gasto = patch.data.tipo_gasto,
                            notas = patch.data.notas
                        },
                        type = "Gastos"
                    }
                };
            }
            _errorResponse.errors = new List<ErrorData>()
            {
                new ErrorData()
                {
                    code = gastos?.code.ToString() ?? "500",
                    detail = gastos?.result ?? "Error interno del servidor",
                    status = gastos?.code ?? 500,
                    tittle = "Error interno del servidor"
                }
            };
            return null;
        }

        public async ValueTask<GastosResponsePost> Post(RequestGastos post)
        {
            var gastos = await _repo.GastosContext.Post(post);
            if (gastos != null && gastos.code == 201)
            {
                return new GastosResponsePost()
                {
                    data = new GastosDataPost()
                    {
                        attributes = new GastosAttributes() { mensaje = gastos.result },
                        type = "Gastos"
                    }
                };
            }
            _errorResponse.errors = new List<ErrorData>
            {
                new ErrorData
                {
                    code = gastos?.code.ToString() ?? "500",
                    detail = gastos?.result ?? "Error interno del servidor",
                    status = gastos?.code ?? 500,
                    tittle = "Error interno del servidor"
                }
            };
            return null;
        }

        public async ValueTask<GastosResponseDelete> Delete(int id)
        {
            var gastos = await _repo.GastosContext.Delete(id);
            if (gastos.code == 200)
                return new GastosResponseDelete() { data = new GastosDataDelete() { attributes = new GastosAttributesDelete() { mensaje = gastos.result }, type = "Gastos" } };
            _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = gastos.code.ToString(), detail = gastos.result, status = gastos.code, tittle = "Error interno del servidor" } };
            return null;
        }
    }
}
