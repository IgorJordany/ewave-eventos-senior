using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Commands.Base;
using Eventos.Core.Repositories;

namespace Eventos.Application.Commands.Participante
{
    public class ConfirmarParticipantesCommandHandler : ICommandHandler<ConfirmarParticipantesCommand, ConfirmarParticipantesResponse>
    {
        private readonly IParticipanteRepository _participanteRepository;

        public ConfirmarParticipantesCommandHandler(
            IParticipanteRepository participanteRepository)
        {
            _participanteRepository = participanteRepository;
        }

        public async Task<ConfirmarParticipantesResponse> Handler(ConfirmarParticipantesCommand command)
        {
            var participantes = await _participanteRepository.ObterParticipantesPorPalestraId(command.PalestraId);

            foreach (var item in command.Participantes)
            {
                var participante = participantes.SingleOrDefault(p => p.Id == item.ParticipanteId);
                participante.Confirmar(item.Confirmou);
            }

            return new ConfirmarParticipantesResponse();
        }
    }
}