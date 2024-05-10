using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Application.Presenters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITD.Finanzas.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped < ICategoriasLogic, CategoriasLogic>();
            services.AddScoped<IConfiguracionesLogic, ConfiguracionesLogic>();
            services.AddScoped<IGastosLogic, GastosLogic>();
            services.AddScoped<IIngresosLogic, IngresosLogic>();
            services.AddScoped<IPresupuestosLogic, PresupuestosLogic>();
            services.AddScoped<IRegistrosLogic, RegistrosLogic>();
            services.AddScoped<ITransaccionesLogic, TransaccionesLogic>();
            services.AddScoped<IUsuarioLogic, UsuarioLogic>();



            return services;
        }
    }
}






