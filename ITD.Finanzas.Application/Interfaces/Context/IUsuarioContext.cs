using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Request.Usuarios;
using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Context
{
    public interface IUsuarioContext
    {

        public ErrorData _errorData { get; set; }

        public Task<List<EntityUsuarioContext>> GetAll();
        public Task<EntityResultContext> Post(RequestUsuario post);
        public Task<EntityResultContext> Patch(RequestUsuarioPatch patch);

        public Task<EntityResultContext> Delete(int id);

    }
}
