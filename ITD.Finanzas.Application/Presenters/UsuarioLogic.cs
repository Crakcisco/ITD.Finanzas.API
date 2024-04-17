using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;
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
        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;

        public UsuarioLogic(IFinanzasRepositoryContext iUsuarioRepositoryContext)
        {
            _finanzasRepositoryContext = iUsuarioRepositoryContext;
        }
        public async Task<List<UsuarioAttributes>> GetUsuarioAsync()
        {
            List<EntityUsuarioContext> usuarios = await _finanzasRepositoryContext.UsuarioContext.Get("");
            List<UsuarioAttributes> usuariosAttributes = new List<UsuarioAttributes>();
            foreach (var usuario in usuarios)
            {
                usuariosAttributes.Add(new UsuarioAttributes()
                {
                    nombre = usuario.nombre,

                });
            }
            return usuariosAttributes;

        }

        public Task<List<UsuarioAttributes>> GetUsuarioAsync(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
