using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;

namespace Api.Configuration
{
    //classe para as injeçoes de dependencia
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<IUsuarioService, UsuarioService>(); //Adiciona a instacia por requisição
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            

            return services;
        }
    }
}
