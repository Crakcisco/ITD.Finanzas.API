using ITD.Finanzas.Application.Interfaces;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Infraestructure.Repository.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITD.Finanzas.Infraestructure

{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            // services.AddScoped<IUsuariosRepository, UsuariosRepositoryContext>();
            //services.AddScoped<FinanzasRepositoryContext, FinanzasRepositoryContext>();
            services.AddScoped<ICategoriasRepositoryContext, ICategoriasRepositoryContext>();
            return services;
        }

    }
}
