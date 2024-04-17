using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Application.Interfaces.Context
{
    public interface IFinanzasRepositoryContext
    {
        public ICategoriasContext CategoriasContext {  get; }
        public IConfiguracionesContext ConfiguracionesContext { get; }
        public IUsuarioContext UsuarioContext { get; }
        public IResumenesContext ResumenesContext { get; }
        public ITransaccionesContext TransaccionesContext { get; }
        public IIngresosContext IngresosContext { get; }
        public IGastosContext GastosContext { get; }
        public IRegistrosContext RegistrosContext { get; }
        public IPresupuestosContext PresupuestosContext { get; }
        

    }
}
