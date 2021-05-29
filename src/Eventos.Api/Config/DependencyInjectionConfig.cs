using Eventos.Application.Commands.CategoriaPalestra;
using Eventos.Application.Commands.EmailTest;
using Eventos.Application.Commands.Evento;
using Eventos.Application.Commands.Funcionario;
using Eventos.Application.Commands.Palestra;
using Eventos.Application.Commands.Participante;
using Eventos.Application.Queries.CategoriaPalestra;
using Eventos.Application.Queries.Evento;
using Eventos.Application.Queries.Funcionario;
using Eventos.Application.Queries.Palestra;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Abstractions;
using Eventos.Infrastructure.Data;
using Eventos.Infrastructure.Interfaces;
using Eventos.Infrastructure.Repositories;
using Eventos.Infrastructure.Services;
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
            services.AddScoped<ICategoriaPalestraRepository, CategoriaPalestraRepository>();
            services.AddScoped<IPalestraRepository, PalestraRepository>();
            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();

            //Services
            services.AddScoped<ICentralEmailService, CentralEmailService>();

            //CommandHandlers
            //Funcionario
            services.AddScoped<InserirFuncionarioCommandHandler, InserirFuncionarioCommandHandler>();

            //Evento
            services.AddScoped<InserirEventoCommandHandler, InserirEventoCommandHandler>();

            //CategoriaPalestra
            services.AddScoped<InserirCategoriaPalestraCommandHandler, InserirCategoriaPalestraCommandHandler>();

            //Palestra
            services.AddScoped<InserirPalestraCommandHandler, InserirPalestraCommandHandler>();
            services.AddScoped<EmailTestCommandHandler, EmailTestCommandHandler>();

            //Participante
            services.AddScoped<ConfirmarParticipantesCommandHandler, ConfirmarParticipantesCommandHandler>();

            //QueryHandlers
            //Funcionario
            services.AddScoped<ObterFuncionarioHandler, ObterFuncionarioHandler>();
            services.AddScoped<ObterFuncionariosHandler, ObterFuncionariosHandler>();

            //Evento
            services.AddScoped<ObterEventosHandler, ObterEventosHandler>();
            services.AddScoped<ObterEventoHandler, ObterEventoHandler>();

            //CategoriaPalestra
            services.AddScoped<ObterCategoriaPalestrasHandler, ObterCategoriaPalestrasHandler>();

            //Palestra
            services.AddScoped<ObterPalestrasHandler, ObterPalestrasHandler>();
            services.AddScoped<ObterPalestraHandler, ObterPalestraHandler>();

            services.AddScoped<IUow, Uow>();

            return services;
        }
    }
}