using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Response;

namespace ITD.Finanzas.Application.Presenters
{
    public interface ICategoriasPresenter
    {
        public  ValueTask<CategoriasResponse> Post(RequestCategorias post);

    }
}
