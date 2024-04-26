using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Response;

namespace ITD.Finanzas.Application.Interfaces.Presenters
{
    public interface ICategoriasPresenter 
    {

        public ErrorResponse _errorResponse { get; set; }

        public ValueTask<CategoriasResponse> Post(RequestCategorias post);

        //agregue PATCH
        public ValueTask<CategoriasResponse> Patch(RequestCategorias patch);

        //Agregue DELETE

        public ValueTask<CategoriasResponse> Delete(int id);


    }
}
