using AdministracaoContas.Business.Interfaces;
using AdministracaoContas.Business.Notificacoes;
using AdministracaoContas.Business.Services;
using AdministracaoContas.Data.Context;
using AdministracaoContas.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AdministracaoContas.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IDespesaRepository, DespesaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IDespesaService, DespesaService>();

            return services;
        }
    }
}
