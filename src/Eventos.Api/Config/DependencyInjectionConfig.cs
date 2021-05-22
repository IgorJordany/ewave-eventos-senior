using Eventos.Application.Commands.Funcionario;
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

            //CommandHandlers
            //Funcionario
            services.AddScoped<InserirFuncionarioCommandHandler, InserirFuncionarioCommandHandler>();

            //QueryHandlers
            //Funcionario
            services.AddScoped<ObterFuncionarioHandler, ObterFuncionarioHandler>();

            services.AddScoped<IUow, Uow>();

            return services;
        }
    }
}