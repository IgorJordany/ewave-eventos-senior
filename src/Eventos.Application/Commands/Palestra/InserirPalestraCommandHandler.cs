using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Commands.Base;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Interfaces;
using Hangfire;

namespace Eventos.Application.Commands.Palestra
{
    public class InserirPalestraCommandHandler : ICommandHandler<InserirPalestraCommand, InserirPalestraResponse>
    {
        private readonly IPalestraRepository _palestraRepository;
        private readonly ICategoriaPalestraRepository _categoriaPalestraRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEventoRepository _eventoRepository;

        public InserirPalestraCommandHandler(
            IPalestraRepository palestraRepository,
            ICategoriaPalestraRepository categoriaPalestraRepository,
            IFuncionarioRepository funcionarioRepository,
            IEventoRepository eventoRepository)
        {
            _palestraRepository = palestraRepository;
            _categoriaPalestraRepository = categoriaPalestraRepository;
            _funcionarioRepository = funcionarioRepository;
            _eventoRepository = eventoRepository;
        }

        public async Task<InserirPalestraResponse> Handler(InserirPalestraCommand command)
        {
            var categoriaValida = _categoriaPalestraRepository.ExisteCategoriaPalestraPorId(command.CategoriaId);

            if (!categoriaValida.Result)
            {
                throw new System.Exception(nameof(command.CategoriaId) + " Categoria Palestra não existente");
            }

            var palestranteValido = _funcionarioRepository.ExisteFuncionarioPorId(command.PalestranteId);

            if (!palestranteValido.Result)
            {
                throw new System.Exception(nameof(command.PalestranteId) + " Palestrante não existente");
            }

            var participantesValidos = _funcionarioRepository.ExisteFuncionariosPorIds(command.Participadores.Select(f => f.FuncionarioId).ToList());

            if (!participantesValidos)
            {
                throw new System.Exception(nameof(command.Participadores) + " Participantes não existente");
            }

            var evento = _eventoRepository.ObterEventoPorId(command.EventoId);
            if (evento == null)
            {
                throw new System.Exception(nameof(command.EventoId) + " Evento não existente");
            }

            var palestra = new Core.Entities.Palestra(
                command.CategoriaId,
                command.Tema,
                command.Local,
                command.DataInicio,
                command.Duracao,
                command.PalestranteId,
                command.EventoId
                );

            var participantes = new HashSet<Core.Entities.Participante>(); ;

            foreach (var item in command.Participadores)
            {
                var participante = new Core.Entities.Participante(palestra.Id, item.FuncionarioId, false);
                participantes.Add(participante);
            }

            palestra.AdicionarParticipantes(participantes);

            await _palestraRepository.Incluir(palestra);

            var jobId = BackgroundJob.Schedule<IPalestraService>(
              s => s.NotificarLocalPalestra(palestra.Id),
              palestra.DataInicio.AddDays(-3)
            );

            return new InserirPalestraResponse { PalestraId = palestra.Id };
        }
    }
}