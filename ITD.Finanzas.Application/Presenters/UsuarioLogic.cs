using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Usuarios;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Presenters
{
    public class UsuarioLogic : IUsuarioLogic
    {
        private readonly IFinanzasRepositoryContext _repo;
        public ErrorResponse _errorResponse { get; set; }
        public ErrorData _errorData { get; set; }
        public List<string> _error { get; set; }

        public UsuarioLogic(IFinanzasRepositoryContext repo)
        {
            _repo = repo;
            _errorResponse = new ErrorResponse();
        }

        public async ValueTask<List<UsuarioResponse>> GetAll()
        {
            var usuarios = await _repo.UsuarioContext.GetAll();
            List<UsuarioDto> output = usuarios.Select(u => new UsuarioDto { id = u.id, nombre= u.nombre, email= u.email }).ToList(); //lo que se muestra
            return new List<UsuarioResponse> { new UsuarioResponse { data = new UsuarioData { attributes = output, type = "Usuarios" } } };
        }


        public async ValueTask<UsuarioResponsePost> Post(RequestUsuario post)
        {
            var usuarios = await _repo.UsuarioContext.Post(post);
            if (usuarios != null && usuarios.code == 200)
            {
                return new UsuarioResponsePost
                {
                    data = new UsuarioDataPost
                    {
                        attributes = new UsuarioAttributes { mensaje = usuarios.result },
                        type = "Usuarios"
                    }
                };
            }
            else
            {
                _errorResponse.errors = new List<ErrorData>
                {
                    new ErrorData
                    {
                        code = usuarios?.code.ToString() ?? "500",
                        detail = usuarios?.result ?? "Error interno del servidor",
                        status = usuarios?.code ?? 500,
                        tittle = "Error interno del servidor"
                    }
                };
                return null;
            }
        }

        public async ValueTask<UsuarioResponsePost> Patch(RequestUsuarioPatch patch)
        {
            var usuarios = await _repo.UsuarioContext.Patch(patch);
            if (usuarios != null && usuarios.code == 200)
            {
                return new UsuarioResponsePost
                {
                    data = new UsuarioDataPost
                    {
                        attributes = new UsuarioAttributes
                        {
                            nombre = patch.data.newName,
                            email = patch.data.newEmail
                        },
                        type = "usuarios"
                    }
                };
            }
            else
            {
                _errorResponse.errors = new List<ErrorData>
        {
            new ErrorData
            {
                code = usuarios?.code.ToString() ?? "500",
                detail = usuarios?.result ?? "Error interno del servidor",
                status = usuarios?.code ?? 500,
                tittle = "Error interno del servidor"
            }
        };
                return null;
            }
        }


        public async ValueTask<UsuarioResponseDelete> Delete(int id)
        {
            var usuarios = await _repo.UsuarioContext.Delete(id);
            if (usuarios != null && usuarios.code == 200)
            {
                return new UsuarioResponseDelete
                {
                    data = new UsuarioDataDelete
                    {
                        attributes = new UsuarioAttributesDelete { mensaje = usuarios.result },
                        type = "usuarios"
                    }
                };
            }
            else
            {
                _errorResponse.errors = new List<ErrorData>
                {
                    new ErrorData
                    {
                        code = usuarios?.code.ToString() ?? "500",
                        detail = usuarios?.result ?? "Error interno del servidor",
                        status = usuarios?.code ?? 500,
                        tittle = "Error interno del servidor"
                    }
                };
                return null;
            }
        }
    }
}
