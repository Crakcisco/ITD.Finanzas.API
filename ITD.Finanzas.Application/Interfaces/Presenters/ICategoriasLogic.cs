using ITD.Finanzas.Application.Interfaces.Context;
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

namespace ITD.Finanzas.Application.Interfaces.Presenters
{
    public interface ICategoriasLogic
    {
        public ErrorResponse _errorResponse { get; set; }
        public List<string> _error {get;set;}
        public ValueTask<CategoriasResponse> Get(string nombre);
        public ValueTask<CategoriasResponsePost> Post(RequestCategorias post);
        public ValueTask<CategoriasResponsePost> Patch(RequestCategorias patch);
        public ValueTask<CategoriasResponseDelete> Delete(int id);




    }
}