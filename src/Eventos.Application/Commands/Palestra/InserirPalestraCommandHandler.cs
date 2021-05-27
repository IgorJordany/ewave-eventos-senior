using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Commands.Base;
using Eventos.Application.Commands.Funcionario;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;

namespace Eventos.Application.Commands.Palestra
{
    public class InserirPalestraCommandHandler : ICommandHandler<InserirPalestraCommand, InserirPalestraResponse>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEventoFuncionarioRepository _eventoFuncionarioRepository;

        public InserirPalestraCommandHandler(
            IEventoRepository eventoRepository,
            IFuncionarioRepository funcionarioRepository,
            IEventoFuncionarioRepository eventoFuncionarioRepository)
        {
            _eventoRepository = eventoRepository;
            _funcionarioRepository = funcionarioRepository;
            _eventoFuncionarioRepository = eventoFuncionarioRepository;
        }

        public async Task<InserirPalestraResponse> Handler(InserirPalestraCommand command)
        {
            var funcionariosValidos = _funcionarioRepository.ExisteFuncionariosPorIds(command.Organizadores.Select(f => f.FuncionarioId).ToList());

            if (!funcionariosValidos)
            {
                throw new System.Exception(nameof(command.Organizadores) + " Funcionario não existente");
            }

            var evento = new Evento(command.Nome, command.DataInicio, command.DataFim);

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