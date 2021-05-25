using Eventos.Application.Commands.Funcionario;
using Eventos.Application.Queries.Evento;
using Eventos.Application.Queries.Funcionario;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Abstractions;
using Eventos.Infrastructure.Data;
using Eventos.Infrastructure.Repositories;
using Eventos.Infrastructure.Transaction;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.Api.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DatabaseContext, DatabaseContext>();

            //Repositorios
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IEventoFuncionarioRepository, EventoFuncionarioRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();

            //CommandHandlers
            //Funcionario
            services.AddScoped<InserirFuncionarioCommandHandler, InserirFuncionarioCommandHandler>();

            //Evento
            services.AddScoped<InserirEventoCommandHandler, InserirEventoCommandHandler>();

            //QueryHandlers
            //Funcionario
            services.AddScoped<ObterFuncionarioHandler, ObterFuncionarioHandler>();
            services.AddScoped<ObterFuncionariosHandler, ObterFuncionariosHandler>();

            //Evento
            services.AddScoped<ObterEventosHandler, ObterEventosHandler>();

            services.AddScoped<IUow, Uow>();

            return services;
        }
    }
}