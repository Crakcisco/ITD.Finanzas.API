using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Response;

namespace ITD.Finanzas.Application.Presenters
{
    public class CategoriasPresenter : ICategoriasPresenter
    {
        public ErrorResponse _errorResponse {  get; set; }
        private readonly IFinanzasRepositoryContext _repo;
        CategoriasPresenter(IFinanzasRepositoryContext repo)
        {
            _errorResponse = new ErrorResponse();   
            _repo = repo;
        }
        //[ProducesResponseType(typeof(CategoriasResponse), (int)StatusHttp.created)]
        //[ProducesResponseType(typeof(ErrorResponse), (int)IStatusCodeHttpResult.badRequest)]
        
        public async ValueTask<CategoriasResponse> Post(RequestCategorias post)
        {
            var categorias = await _repo.CategoriasContext.Post(post);
            if(categorias.code == 201) 
            return new CategoriasResponse() { data = new CategoriasData() { attributes = new CategoriasAttributes() { nombre = categorias.result }, type = "categorias" } };
            _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = categorias.code.ToString(), detail = categorias.result, status = categorias.code, tittle = "Error interno del servidor" } } ;
            return null;

        }


        //Agregue PATCH
        public async ValueTask<CategoriasResponse> Patch(RequestCategorias patch)
        {
            var categorias = await _repo.CategoriasContext.Patch(patch);
            if (categorias.code == 200) // Cambiado de 201 a 200 para reflejar el éxito en la modificación
            {
                return new CategoriasResponse()
                {
                    data = new CategoriasData()
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


        //Agregue DELETE
        public async ValueTask<CategoriasResponse> Delete(int id)
        {
            var categorias = await _repo.CategoriasContext.Delete(id);
            if (categorias.code == 200)
            {
                return new CategoriasResponse()
                {
                    data = new CategoriasData()
                    {
                        attributes = new CategoriasAttributes(),
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
            tittle = "Error interno del servidor"
        }
    };
            return null;
        }



    }
}
