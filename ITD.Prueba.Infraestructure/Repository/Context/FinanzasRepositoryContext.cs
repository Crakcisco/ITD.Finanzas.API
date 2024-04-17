using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Infraestructure.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Infraestructure.Repository.Context
{
    public class FinanzasRepositoryContext 
    {
        private readonly BDServices _BD;

        private readonly IConfiguration _configuration;
        public FinanzasRepositoryContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _BD = new BDServices(_configuration);
        }
        ICategoriasContext CategoriasContext => new CategoriasContext(_BD);
    }
}
