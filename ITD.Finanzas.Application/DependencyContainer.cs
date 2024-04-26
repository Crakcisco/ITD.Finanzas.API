﻿using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Application.Presenters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ICategoriasPresenter = ITD.Finanzas.Application.Presenters.ICategoriasPresenter;

namespace ITD.Finanzas.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoriasPresenter, CategoriasPresenter>();
            services.AddScoped<ICategoriasLogic, CategoriasLogic >();
            return services;
        }
    }
}






