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
    public class CategoriasLogic : ICategoriasLogic
    {
        private readonly IFinanzasRepositoryContext _finanzasRepositoryContext;
        
        public CategoriasLogic(IFinanzasRepositoryContext iCategoriasRepositoryContext)
        {
            _finanzasRepositoryContext = iCategoriasRepositoryContext;
        }
        public async Task<List<CategoriasAttributes>> GetCategoriasAsync()
        {
            List<EntityCategoriasContext> categorias = await _finanzasRepositoryContext.CategoriasContext.Get("");
            List<CategoriasAttributes> categoriasAttributes = new List<CategoriasAttributes>();
            foreach (var categoria in categorias)
            {
                categoriasAttributes.Add(new CategoriasAttributes()
                {
                    nombre = categoria.nombre,
                    
                });
            }
            return categoriasAttributes;

        }

        public Task<List<CategoriasAttributes>> GetCategoriasAsync(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
