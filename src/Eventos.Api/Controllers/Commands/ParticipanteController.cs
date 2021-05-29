using System.Threading.Tasks;
using Eventos.Application.Commands.Palestra;
using Eventos.Application.Commands.Participante;
using Eventos.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Commands
{
    [ApiController]
    [Route("commands/participantes")]
    public class ParticipanteController : ControllerBase
    {
        private readonly ConfirmarParticipantesCommandHandler _confirmarParticipantesCommandHandler;
        private readonly IUow _uow;

        public ParticipanteController(ConfirmarParticipantesCommandHandler confirmarParticipantesCommandHandler,
            IUow uow)
        {
            _confirmarParticipantesCommandHandler = confirmarParticipantesCommandHandler;
            _uow = uow;
        }

        [HttpPost("confirmar")]
        public async Task<ConfirmarParticipantesResponse> InserirPalestra([FromBody] ConfirmarParticipantesCommand command)
        {
            var response = await _confirmarParticipantesCommandHandler.Handler(command);

            _uow.Commit();

            return response;
        }
    }
}