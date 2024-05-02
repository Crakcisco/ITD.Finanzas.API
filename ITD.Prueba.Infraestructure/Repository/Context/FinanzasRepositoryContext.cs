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
    public class FinanzasRepositoryContext : IFinanzasRepositoryContext
    {
        private readonly BDServices _BD;

        private readonly IConfiguration _configuration;
        public FinanzasRepositoryContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _BD = new BDServices(_configuration);
        }
        public ICategoriasContext CategoriasContext => new CategoriasContext(_BD);
        public IConfiguracionesContext ConfiguracionesContext => new ConfiguracionesContext(_BD);
        public IUsuarioContext UsuarioContext => new UsuarioContext(_BD);
        public IResumenesContext ResumenesContext => new ResumenesContext(_BD);
        public ITransaccionesContext TransaccionesContext => new TransaccionesContext(_BD);
        public IIngresosContext IngresosContext => new IngresosContext(_BD);
        public IGastosContext GastosContext => new GastosContext(_BD);
        public IRegistrosContext RegistrosContext => new RegistrosContext(_BD); 
        public IPresupuestosContext PresupuestosContext => new PresupuestosContext(_BD);

    }
}
