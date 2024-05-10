using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO;
using ITD.Finanzas.Domain.DTO.DATA;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
using ITD.Finanzas.Domain.DTO.Request.Categorias;
using ITD.Finanzas.Domain.DTO.Request.Usuarios;
using ITD.Finanzas.Domain.DTO.Response;
using ITD.Finanzas.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Presenters
{
    public class UsuarioLogic : IUsuarioLogic
    {
        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }


        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;
        private readonly IFinanzasRepositoryContext _repo;

        public UsuarioLogic(IFinanzasRepositoryContext repo)
        {
            _repo = repo;
            _errorResponse = new ErrorResponse();
        }

        //GET
        public async ValueTask<UsuarioResponse> Get(int id)
        {
            var usuarios = await _repo.UsuarioContext.Get(id);
            List<UsuarioDto> output = new List<UsuarioDto>();

            foreach (EntityUsuarioContext a in usuarios)
            {
                output.Add(new UsuarioDto()
                {
                    id = a.id
                });
            }

            // Devolver la respuesta después de completar el bucle foreach
            return new UsuarioResponse() { data = new UsuarioData() { attributes = output, type = "Usuarios" } };
        }

        //POST

        public async ValueTask<UsuarioResponsePost> Post(RequestUsuario post)
        {
            var usuarios = await _repo.UsuarioContext.Post(post);
            if (usuarios.code == 201)
                return new UsuarioResponsePost() { data = new UsuarioDataPost() { attributes = new UsuarioAttributes() { mensaje = usuarios.result }, type = "Categorias" } };
            _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = usuarios.code.ToString(), detail = usuarios.result, status = usuarios.code, tittle = "Error interno del servidor" } };
            return null;

        }

        //Agregue PATCH
        public async ValueTask<UsuarioResponsePost> Patch(RequestUsuario patch)
        {
            var usuarios = await _repo.UsuarioContext.Patch(patch);
            if (usuarios .code == 200) // Cambiado de 201 a 200 para reflejar el éxito en la modificación
            {
                return new UsuarioResponsePost()
                {
                    data = new UsuarioDataPost()
                    {
                        attributes = new UsuarioAttributes()
                        {

                            nombre = patch.data.nombre, // Utilizando el nuevo nombre proporcionado en la solicitud
                            email = patch.data.email
                        },
                        type = "usuarios"
                    }
                };
            }
            _errorResponse.errors = new List<ErrorData>()
        {
            new ErrorData()
            {
                code = usuarios.code.ToString(),
                detail = usuarios.result,
                status = usuarios.code,
                tittle = "Error interno del servidor" // Corregido el nombre de la propiedad de 'tittle' a 'title'
            }
        };
            return null;
        }

        //Delete
        public async ValueTask<UsuarioResponseDelete> Delete(int id)
        {
            var usuarios = await _repo.UsuarioContext.Delete(id);
            if (usuarios.code == 200)
                return new UsuarioResponseDelete() { data = new UsuarioDataDelete() { attributes = new UsuarioAttributesDelete() { mensaje = usuarios.result }, type = "usuarios" } };
            _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = usuarios.code.ToString(), detail = usuarios.result, status = usuarios.code, tittle = "Error interno del servidor" } };
            return null;
        }







    }
}
