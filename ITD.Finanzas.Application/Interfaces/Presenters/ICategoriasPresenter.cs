using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.POCOS.Context;

namespace ITD.Finanzas.Application.Interfaces.Presenters
{
    public interface ICategoriasPresenter 
    {
        //public Task<List<EntityCategoriasContext>> Get(string nombre);
        //agregue
        //public Task<List<CategoriasAttributes>> GetCategoriasAsync(string nombre);

        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }
        //add
        //public ValueTask<CategoriasResponse> Get(string nombre);
        public  ValueTask<CategoriasResponse> Get(string nombre);
        //public ValueTask<CategoriasResponse> Post(RequestCategorias post);

        ////agregue PATCH
        //public ValueTask<CategoriasResponse> Patch(RequestCategorias patch);

        ////Agregue DELETE

        //public ValueTask<CategoriasResponse> Delete(int id);


    }
}
