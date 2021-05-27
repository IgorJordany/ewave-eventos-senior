using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Commands.Base;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;

namespace Eventos.Application.Commands.Evento
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
            var funcionariosValidos = _funcionarioRepository.ExisteFuncionariosPorIds(command.Organizadores.Select(f => f.FuncionarioId).ToList());

            if (!funcionariosValidos)
            {
                throw new System.Exception(nameof(command.Organizadores) + " Funcionario não existente");
            }

            var evento = new Core.Entities.Evento(command.Nome, command.DataInicio, command.DataFim);

            var organizadores = new HashSet<EventoFuncionario>(); ;

            foreach (var item in command.Organizadores)
            {
                var eventoFuncionario = new EventoFuncionario(evento.Id, item.FuncionarioId);
                organizadores.Add(eventoFuncionario);
            }

            evento.AdicionarOrganizadores(organizadores);

            await _eventoRepository.Incluir(evento);

            return new InserirEventoResponse { EventoId = evento.Id };
        }
    }
}