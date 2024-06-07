using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Request.Usuarios;
using ITD.Finanzas.Domain.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Presenters
{
    public interface IUsuarioLogic
    {

        public ErrorResponse _errorResponse { get; set; }
    public List<string> _error { get; set; }
        public  ValueTask<List<UsuarioResponse>> GetAll();
        public ValueTask<UsuarioResponsePost> Post(RequestUsuario post);
        public ValueTask<UsuarioResponsePost> Patch(RequestUsuarioPatch patch);
        public ValueTask<UsuarioResponseDelete> Delete(int id);
    }
}
