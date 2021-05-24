using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Commands.Base;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;
using Eventos.Shared.Utilities;
using Flunt.Notifications;

namespace Eventos.Application.Commands.Funcionario
{
    public class InserirEventoCommandHandler : ICommandHandler<InserirEventoCommand, InserirEventoResponse>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEventoFuncionarioRepository _eventoFuncionarioRepository;

        public InserirEventoCommandHandler(
            IEventoRepository eventoRepository,
            IFuncionarioRepository funcionarioRepository,
            IEventoFuncionarioRepository eventoFuncionarioRepository)
        {
            _eventoRepository = eventoRepository;
            _funcionarioRepository = funcionarioRepository;
            _eventoFuncionarioRepository = eventoFuncionarioRepository;
        }

        public async Task<InserirEventoResponse> Handler(InserirEventoCommand command)
        {
            var funcionariosValidos = _funcionarioRepository.ExisteFuncionariosPorIds(command.Organizadores.Select(f=> f.FuncionarioId).ToList());

            if (!funcionariosValidos)
            {
                return new InserirEventoResponse { Erro = new Notification(nameof(command.Organizadores), "Funcionario n�o existente") };
            }

            var evento = new Evento(command.Nome, command.DataInicio, command.DataFim);

            if (evento.Notifications.Any())
            {
                return new InserirEventoResponse { Erro = evento.Notifications };
            }

            var organizadores = new HashSet<EventoFuncionario>(); ;

            foreach (var item in command.Organizadores)
            {
                var eventoFuncionario = new EventoFuncionario(evento.Id, item.FuncionarioId);
                if (eventoFuncionario.Notifications.Any())
                {
                    return new InserirEventoResponse { Erro = eventoFuncionario.Notifications };
                }
                organizadores.Add(eventoFuncionario);
            }

            evento.Organizadores = organizadores;

            await _eventoRepository.Incluir(evento);

            return new InserirEventoResponse { EventoId = evento.Id };
        }
    }
}