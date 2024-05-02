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

namespace ITD.Finanzas.Application.Interfaces.Context
{
    public interface ICategoriasContext
    {
        
        public ErrorData _errorData { get; set; }

        public  Task<List<EntityCategoriasContext>> Get(string nombre);
        public  Task<EntityResultContext> Post(RequestCategorias post);
        public Task<EntityResultContext> Patch(RequestCategorias patch);
       
        public Task<EntityResultContext> Delete(int id);







    }
}
