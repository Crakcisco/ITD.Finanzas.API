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
    public class CategoriasLogic : ICategoriasLogic
    {
        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }


        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;
        private readonly IFinanzasRepositoryContext _repo;

        public CategoriasLogic(IFinanzasRepositoryContext repo)
        {
            _repo = repo;
            _errorResponse = new ErrorResponse();
        }

        //GET
        public async ValueTask<CategoriasResponse> Get(string nombre)
        {
            var Categorias = await _repo.CategoriasContext.Get(nombre);
            List<CategoriasDto> output = new List<CategoriasDto>();
            foreach (EntityCategoriasContext a in Categorias)
            {
                output.Add(new CategoriasDto()
                {
                    id = a.id,
                    nombre = a.nombre
                });
            }

            return new CategoriasResponse() { data = new CategoriasData() { attributes = output, type = "Categorias" } };
        }

        //POST

        public async ValueTask<CategoriasResponsePost> Post(RequestCategorias post)
        {
            var categorias = await _repo.CategoriasContext.Post(post);
            if (categorias.code == 201)
                return new CategoriasResponsePost() { data = new CategoriasDataPost() { attributes = new CategoriasAttributes() { mensaje = categorias.result}, type = "Categorias" } };
            _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = categorias.code.ToString(), detail = categorias.result, status = categorias.code, tittle = "Error interno del servidor" } };
            return null;

        }

        //Agregue PATCH
            public async ValueTask<CategoriasResponsePost> Patch(RequestCategorias patch)
            {
                var categorias = await _repo.CategoriasContext.Patch(patch);
                if (categorias.code == 200) // Cambiado de 201 a 200 para reflejar el éxito en la modificación
                {
                    return new CategoriasResponsePost()
                    {
                        data = new CategoriasDataPost()
                        {
                            attributes = new CategoriasAttributes()
                            {
                                nombre = patch.data.nombre // Utilizando el nuevo nombre proporcionado en la solicitud
                            },
                            type = "categorias"
                        }
                    };
                }
                _errorResponse.errors = new List<ErrorData>()
        {
            new ErrorData()
            {
                code = categorias.code.ToString(),
                detail = categorias.result,
                status = categorias.code,
                tittle = "Error interno del servidor" // Corregido el nombre de la propiedad de 'tittle' a 'title'
            }
        };
                return null;
            }

        //Delete
        public async ValueTask<CategoriasResponseDelete> Delete(int id)
        {
            var categorias = await _repo.CategoriasContext.Delete(id);
            if (categorias.code == 200)
                return new CategoriasResponseDelete() { data = new CategoriasDataDelete() { attributes = new CategoriasAttributesDelete() { mensaje = categorias.result }, type = "Categorias" } };
            _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = categorias.code.ToString(), detail = categorias.result, status = categorias.code, tittle = "Error interno del servidor" } };
            return null;
        }







    }
}
