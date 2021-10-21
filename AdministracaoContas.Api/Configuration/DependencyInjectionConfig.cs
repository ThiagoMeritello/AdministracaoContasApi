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
            services.AddScoped<INotificador, Notificador>();

            //Service
            services.AddScoped<IDespesaService, DespesaService>();
            services.AddScoped<IFormaPagamentoService, FormaPagamentoService>();           

            //Repository
            services.AddScoped<IDespesaRepository, DespesaRepository>();
            services.AddScoped<IDespesaParcelaRepository, DespesaParcelaRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            
            return services;
        }
    }
}
