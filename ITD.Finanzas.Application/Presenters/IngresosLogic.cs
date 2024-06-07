using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Request.Gastos;
using ITD.Finanzas.Domain.DTO.Request.Ingresos;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Presenters
{
    public class IngresosLogic : IIngresosLogic
    {

        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }


        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;
        private readonly IFinanzasRepositoryContext _repo;

        public IngresosLogic(IFinanzasRepositoryContext repo)
        {
            _repo = repo;
            _errorResponse = new ErrorResponse();
        }

        //GET
        public async ValueTask<IngresosResponseGet> Get(int id)
        {
            var ingresos = await _repo.IngresosContext.Get(id);
            List<IngresosDto> output = new List<IngresosDto>();

            foreach (EntityIngresosContext a in ingresos)
            {
                output.Add(new IngresosDto()
                {
                    id = a.id
                });
            }

            // Devolver la respuesta después de completar el bucle foreach
            return new IngresosResponseGet() { data = new IngresosData() { attributes = output, type = "Ingresos" } };
        }

        //Agregue PATCH
        public async ValueTask<IngresosResponsePost> Patch(RequestIngresos patch)
        {
            var ingresos = await _repo.IngresosContext.Patch(patch);
            if (ingresos != null && ingresos.code == 200)
            {
                return new IngresosResponsePost()
                {
                    data = new IngresosDataPost()
                    {
                        attributes = new IngresosAttributes()
                        {
                            usuario_id = patch.data.usuario_id, // Utilizando el usuario_id proporcionado en la solicitud
                            categoria_id = patch.data.categoria_id,
                            titulo = patch.data.titulo,
                            cantidad = patch.data.cantidad,
                            fecha = patch.data.fecha,
                            hora = patch.data.hora,
                            motivo = patch.data.motivo,
                            tipo_ingreso = patch.data.tipo_ingreso,
                            notas = patch.data.notas
                        },
                        type = "ingresos"
                    }
                };
            }
            _errorResponse.errors = new List<ErrorData>()
    {
        new ErrorData()
        {
            code = ingresos?.code.ToString() ?? "500",
            detail = ingresos?.result ?? "Error interno del servidor",
            status = ingresos?.code ?? 500,
            tittle = "Error interno del servidor" // Corregido el nombre de la propiedad de 'tittle' a 'title'
        }
    };
            return null;
        }



        //POST

        public async ValueTask<IngresosResponsePost> Post(RequestIngresos post)
        {
            var ingresos = await _repo.IngresosContext.Post(post);
            if (ingresos != null && ingresos.code == 201)
            {
                return new IngresosResponsePost()
                {
                    data = new IngresosDataPost()
                    {
                        attributes = new IngresosAttributes() { mensaje = ingresos.result },
                        type = "Ingresos"
                    }
                };
            }
            else
            {
                _errorResponse.errors = new List<ErrorData>
        {
            new ErrorData
            {
                code = ingresos?.code.ToString() ?? "500",
                detail = ingresos?.result ?? "Error interno del servidor",
                status = ingresos?.code ?? 500,
                tittle = "Error interno del servidor"
            }
        };
                return null;
            }
        }



        //Delete
        public async ValueTask<IngresosResponseDelete> Delete(int id)
        {
            var ingresos = await _repo.IngresosContext.Delete(id);
            if (ingresos.code == 200)
                return new IngresosResponseDelete() { data = new IngresosDataDelete() { attributes = new IngresosAttributesDelete() { mensaje = ingresos.result }, type = "Gastos" } };
            _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = ingresos.code.ToString(), detail = ingresos.result, status = ingresos.code, tittle = "Error interno del servidor" } };
            return null;
        }

    }
}
